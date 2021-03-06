using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace NieR_Replicant_Viet_Hoa
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }
        public Button _BtnUpdate
        {
            get { return this.btnUpdate; }
        }
        private void textBoxGameLocation_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void textBoxGameLocation_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                textBoxGameLocation.Text = fileNames.FirstOrDefault();
            }
        }

        private void btnGameLocation_Click(object sender, EventArgs e)
        {
            if (Default._InProgress)
            {
                MessageBox.Show(Default._Messages["InProgress"], Default._MessageTitle);
            }
            else
            {
                Default._InProgress = true;
                string folderPath = DialogManager.FolderBrowser(Default._Messages["GameLocation"]);
                if (!string.IsNullOrEmpty(folderPath))
                {
                    textBoxGameLocation.Text = folderPath;
                    if (Default._JsonConfig != null && Default._JsonConfig.ContainsKey("GameLocation"))
                    {
                        Default._JsonConfig["GameLocation"] = folderPath;
                    }
                    else
                    {
                        if (Default._JsonConfig == null) Default._JsonConfig = new Dictionary<string, string>();
                        Default._JsonConfig.Add("GameLocation", folderPath);
                    }
                    string config = new JavaScriptSerializer().Serialize(Default._JsonConfig);
                    try
                    {
                        File.WriteAllText(Default._ConfigFile, config);
                    }
                    catch (Exception err)
                    {
                        Default._InProgress = false;
                        MessageBox.Show(Operation.GetExceptionMessage(err, Default._Messages["WriteFailed"]), $"{Default._MessageTitle} - {err.GetType().Name}");
                    }
                }
                Default._InProgress = false;
            }
        }
        private void MainUI_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(Default._ConfigFile))) Directory.CreateDirectory(Path.GetDirectoryName(Default._ConfigFile));
                if (!File.Exists(Default._ConfigFile)) File.WriteAllText(Default._ConfigFile, "{}");
            }
            catch (Exception err)
            {
                MessageBox.Show(Operation.GetExceptionMessage(err, Default._Messages["WriteFailed"]), $"{Default._MessageTitle} - {err.GetType().Name}");
            }

            try
            {
                Default._JsonConfig = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(File.ReadAllText(Default._ConfigFile));
                if (Default._JsonConfig.ContainsKey("GameLocation"))
                {
                    textBoxGameLocation.Text = Default._JsonConfig["GameLocation"];
                }
                else
                {
                    string registryPath = @"SOFTWARE\Wow6432Node\Valve\Steam";
                    string steamPath = Registry.LocalMachine.OpenSubKey(registryPath).GetValue("InstallPath")?.ToString();
                    if (!string.IsNullOrWhiteSpace(steamPath))
                    {
                        string steamGameInfo = Path.Combine(steamPath, "steamapps", "appmanifest_1113560.acf");
                        if (File.Exists(steamGameInfo))
                        {
                            string gameLocation = Path.Combine(steamPath, "steamapps", "common", "NieR Replicant ver.1.22474487139");
                            if (Directory.Exists(gameLocation) && Operation.CheckDirectory(gameLocation))
                            {
                                textBoxGameLocation.Text = gameLocation;
                                Default._JsonConfig.Add("GameLocation", textBoxGameLocation.Text);
                            }
                        }
                        else
                        {
                            string libraryFolders = Path.Combine(steamPath, "steamapps", "libraryfolders.vdf");
                            if (File.Exists(libraryFolders))
                            {
                                string libContent = File.ReadAllText(libraryFolders);
                                MatchCollection result = Regex.Matches(libContent, "\"path\"(.+)\"(.+)\"");
                                for (int i = 0; i < result.Count; i++)
                                {
                                    steamGameInfo = Path.Combine(result[i].Groups[2].Value.Replace(@":\\", @":\"), "steamapps", "appmanifest_1113560.acf");
                                    if (File.Exists(steamGameInfo))
                                    {
                                        string gameLocation = Path.Combine(Path.GetDirectoryName(steamGameInfo), "common", "NieR Replicant ver.1.22474487139");
                                        
                                        if (Directory.Exists(gameLocation) && Operation.CheckDirectory(gameLocation))
                                        {
                                            textBoxGameLocation.Text = gameLocation;
                                            Default._JsonConfig.Add("GameLocation", textBoxGameLocation.Text);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(Operation.GetExceptionMessage(err, Default._Messages["ReadFailed"]), $"{Default._MessageTitle} - {err.GetType().Name}");
            }
        }
        private void linkLH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Operation.OpenUrl("https://www.facebook.com/100004440041815");
        }
        private void linkVHG_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Operation.OpenUrl("https://viethoagame.com/threads/pc-nier-replicant-ver-1-22474487139-viet-hoa.305/");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Default._InProgress)
            {
                MessageBox.Show(Default._Messages["InProgress"], Default._MessageTitle);
            }
            else
            {
                Default._InProgress = true;
                listBoxLog.Items.Clear();
                Task.Run(() =>
                {
                    try
                    {
                        ProgressManager progress = new ProgressManager(progressBar);
                        LogManager log = new LogManager(listBoxLog);
                        Operation.Update(progress, log);
                    }
                    catch (Exception err)
                    {
                        Default._InProgress = false;
                        MessageBox.Show(err.Message, Default._MessageTitle);
                        listBoxLog.Items.Add(Default._Messages["Cancel"].Replace("{Action}", "cập nhật"));
                    }
                }).GetAwaiter().OnCompleted(() => { 
                    Default._InProgress = false;
                });
            }
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            if (Default._InProgress)
            {
                MessageBox.Show(Default._Messages["InProgress"], Default._MessageTitle);
            }
            else
            {
                if (Operation.CheckDirectory())
                {
                    Default._InProgress = true;
                    Task.Run(() =>
                    {
                        try
                        {
                            ProgressManager progress = new ProgressManager(progressBar);
                            LogManager log = new LogManager(listBoxLog);
                            Operation.Uninstall(progress, log);
                        }
                        catch (Exception err)
                        {
                            Default._InProgress = false;
                            MessageBox.Show(err.Message, Default._MessageTitle);
                            listBoxLog.Items.Add(Default._Messages["Cancel"].Replace("{Action}", "gỡ cài đặt"));
                        }
                    }).GetAwaiter().OnCompleted(() => { Default._InProgress = false; });
                }
                else
                {
                    MessageBox.Show(Default._Messages["LocationException"], Default._MessageTitle);
                }
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (Default._InProgress)
            {
                MessageBox.Show(Default._Messages["InProgress"], Default._MessageTitle);
            }
            else
            {
                if (Operation.CheckDirectory())
                {
                    Default._InProgress = true;
                    Task.Run(() =>
                    {
                        try
                        {
                            ProgressManager progress = new ProgressManager(progressBar);
                            LogManager log = new LogManager(listBoxLog);
                            Operation.Install(progress, log);
                        }
                        catch (Exception err)
                        {
                            Default._InProgress = false;
                            MessageBox.Show(err.Message, Default._MessageTitle);
                            listBoxLog.Items.Add(Default._Messages["Cancel"].Replace("{Action}", "cài đặt"));
                        }
                    }).GetAwaiter().OnCompleted(() => { Default._InProgress = false; }); ;
                }
                else
                {
                    MessageBox.Show(Default._Messages["LocationException"], Default._MessageTitle);
                }
            }
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            if (!Default._CreditForm.Visible) Default._CreditForm.Show();
        }

        private void listBoxLog_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(listBoxLog.Items[e.Index].ToString(), listBoxLog.Font, listBoxLog.Width).Height;
        }

        private void listBoxLog_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(listBoxLog.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void MainUI_Shown(object sender, EventArgs e)
        {
            try
            {
                Operation.CheckUpdate(this);
            }
            catch { }
        }
    }
}
