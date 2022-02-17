using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ZstdNet;
using System.Net;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace NieR_Replicant_Viet_Hoa
{
    public class Operation
    {
        public static void OpenUrl(string uri)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            Process.Start(psi);
        }
        public static string GetExceptionMessage(Exception err, string defaultMsg = null)
        {
            string errName = err.GetType().Name;
            if (Default._Messages.ContainsKey(errName)) return Default._Messages[errName];
            else return defaultMsg;
        }
        private static void MoveDirectory(string source, string des)
        {
            if (!Directory.Exists(des)) Directory.CreateDirectory(des);
            string[] files = Directory.GetFiles(source, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                if (File.Exists(Path.Combine(des, Path.GetFileName(file)))) File.Delete(Path.Combine(des, Path.GetFileName(file)));
                File.Move(file, Path.Combine(des, Path.GetFileName(file)));
            }
            string[] folders = Directory.GetDirectories(source);
            foreach (string folder in folders)
            {
                MoveDirectory(folder, Path.Combine(des, Path.GetFileName(folder)));
            }
        }
        public static void CheckUpdate(MainUI form)
        {
            using (var wc = new WebClient())
            {
                wc.DownloadStringAsync(new Uri(Default._Uri));
                wc.DownloadStringCompleted += (s, y) =>
                {
                    Dictionary<string, string> json = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(y.Result);
                    string updateMessage = Default._Messages["UpdateTrans"];
                    if (json.ContainsKey("Changelog")) updateMessage = $"{updateMessage}{Default._Messages["Changelog"]}{json["Changelog"]}";
                    if (!Default._JsonConfig.ContainsKey("TranslationID"))
                    {
                        DialogResult confirm = MessageBox.Show(updateMessage, Default._MessageTitle, MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            form._BtnUpdate.PerformClick();
                        }
                    }
                    else
                    {
                        string appUpdateMessage = Default._Messages["UpdateApp"];
                        if (json.ContainsKey("AppChangelog")) appUpdateMessage = $"{appUpdateMessage}{Default._Messages["Changelog"]}{json["AppChangelog"]}";
                        if (json.ContainsKey("AppVersion") && Application.ProductVersion != json["AppVersion"])
                        {
                            DialogResult confirm = MessageBox.Show(appUpdateMessage, Default._MessageTitle, MessageBoxButtons.YesNo);
                            if (confirm == DialogResult.Yes)
                            {
                                form._BtnUpdate.PerformClick();
                            }
                        }
                        else
                        {
                            if (json.ContainsKey("TranslationID") && Default._JsonConfig["TranslationID"] != json["TranslationID"])
                            {
                                DialogResult confirm = MessageBox.Show(updateMessage, Default._MessageTitle, MessageBoxButtons.YesNo);
                                if (confirm == DialogResult.Yes)
                                {
                                    form._BtnUpdate.PerformClick();
                                }
                            }
                        }
                    }
                };
            }
        }
        public static void Backup(ProgressManager progress, LogManager log)
        {
            progress.Begin();
            log.Push(Default._Messages["Begin"].Replace("{Action}", "sao lưu"));
            string backupDir = Path.Combine(Default._JsonConfig["GameLocation"], Default._BackupDirectory);
            if (!Directory.Exists(backupDir)) Directory.CreateDirectory(backupDir);
            double percent = 100.0 / (Default._DataDirectories.Length + 1);
            foreach (var dir in Default._DataDirectories)
            {
                string des = Path.Combine(backupDir, dir);
                MoveDirectory(Path.Combine(Default._JsonConfig["GameLocation"], dir), des);
                Directory.Delete(Path.Combine(Default._JsonConfig["GameLocation"], dir), true);
                progress.Increase(percent);
            }
            string exe = Path.Combine(Default._JsonConfig["GameLocation"], Default._ExeFile);
            if (File.Exists(exe))
            {
                File.Copy(exe, Path.Combine(backupDir, Path.GetFileName(exe)), true);
                progress.Increase(percent);
            }
            progress.Finish();
        }
        public async static void Update(ProgressManager progress, LogManager log)
        {
            progress.Begin();
            if (!Directory.Exists(Path.GetDirectoryName(Default._Resources))) Directory.CreateDirectory(Path.GetDirectoryName(Default._Resources));
            log.Push(Default._Messages["Begin"].Replace("{Action}", "lấy thông tin từ máy chủ"));
            using (var wc = new WebClient())
            {
                string jsonData = wc.DownloadString(new Uri(Default._Uri));
                Dictionary<string, string> json = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(jsonData);
                log.Push(Default._Messages["AppVersion"].Replace("{Version}", json["AppVersion"]));
                log.Push(Default._Messages["TranslationID"].Replace("{ID}", json["TranslationID"]));
                log.Push(Default._Messages["UpdateTime"].Replace("{Date}", ConvertFromUnixTimestamp(long.Parse(json["TranslationID"]))));
                if (Default._JsonConfig.ContainsKey("TranslationID")  && Application.ProductVersion == json["AppVersion"] && json["TranslationID"] == Default._JsonConfig["TranslationID"] && File.Exists(Default._Resources) && ReadID() == json["TranslationID"])
                {
                    log.Push(Default._Messages["UpToDate"]);
                    return;
                }
                wc.DownloadProgressChanged += (s, y) =>
                {
                    progress.SetPercent(y.ProgressPercentage);
                };
                if (Application.ProductVersion != json["AppVersion"])
                {
                    if (File.Exists(Default._AppUpdate))
                    {
                        Process.Start(Default._AppUpdate);
                        Application.Exit();
                    }
                    else
                    {
                        Uri uri = new Uri(json["UpdateUrl"]);
                        log.Push(Default._Messages["Begin"].Replace("{Action}", "tải chương trình cập nhật"));
                        await wc.DownloadFileTaskAsync(uri, Default._AppUpdate);
                        Process.Start(Default._AppUpdate);
                        Application.Exit();
                    }
                }
                if (!Default._JsonConfig.ContainsKey("TranslationID") || json["TranslationID"] != Default._JsonConfig["TranslationID"] || !File.Exists(Default._Resources) || ReadID() != json["TranslationID"])
                {
                    Uri uri = new Uri(json["TranslationUrl"]);
                    log.Push(Default._Messages["Begin"].Replace("{Action}", "tải bản dịch"));
                    await wc.DownloadFileTaskAsync(uri, Default._Resources);
                    log.Push(Default._Messages["Complete"].Replace("{Action}", "Tải bản dịch"));
                    if (Default._JsonConfig.ContainsKey("TranslationID")) Default._JsonConfig["TranslationID"] = json["TranslationID"];
                    else Default._JsonConfig.Add("TranslationID", json["TranslationID"]);
                    UpdateConfig();
                    if (Default._JsonConfig.ContainsKey("GameLocation") && Directory.Exists(Path.Combine(Default._JsonConfig["GameLocation"], Default._PatchDirectory))) Install(progress, log);
                }
            }
        }
        public static string ConvertFromUnixTimestamp(long timestamp, string format = "dd-MM-yyyy")
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp).ToLocalTime().ToString(format);
        }
        public static void UpdateConfig()
        {
            string json = new JavaScriptSerializer().Serialize(Default._JsonConfig);
            File.WriteAllText(Default._ConfigFile, json);
        }
        private static string ReadID()
        {
            using (FileStream stream = File.OpenRead(Default._Resources))
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    string id = br.ReadInt64().ToString();
                    return id;
                }
            }
        }
        public static bool Install(ProgressManager progress, LogManager log)
        {
            if (!Directory.Exists(Path.Combine(Default._JsonConfig["GameLocation"], Default._PatchDirectory)))
            {
                string driveName = Path.GetPathRoot(new FileInfo(Default._JsonConfig["GameLocation"]).FullName);
                DriveInfo drive = Array.Find(DriveInfo.GetDrives(), d => d.Name == driveName);
                string freeSpace = (drive.TotalFreeSpace / 1024 / 1024 / 1024).ToString();
                DialogResult confirm = MessageBox.Show(Default._Messages["FreeSpace"].Replace("{TotalFreeSpace}", freeSpace), Default._MessageTitle, MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    log.Clear();
                    progress.Begin();
                    log.Push(Default._Messages["BeginInstall"].Replace("{PatchDirectory}", Default._PatchDirectory), true);
                    Unpacker unpacker = new Unpacker(Default._JsonConfig["GameLocation"]);
                    unpacker.Unpack(Path.Combine(Default._JsonConfig["GameLocation"], Default._PatchDirectory), "data", progress, log);
                    unpacker.Unpack(Path.Combine(Default._JsonConfig["GameLocation"], Default._PatchDirectory), @"dlc\dlc01", progress, log);
                    string[] movies = Directory.GetFiles(Path.Combine(Default._JsonConfig["GameLocation"], Default._MovieDirectory), "*.arc", SearchOption.TopDirectoryOnly);
                    string[] sounds = Directory.GetFiles(Path.Combine(Default._JsonConfig["GameLocation"], Default._SoundDirectory), "*.pck", SearchOption.TopDirectoryOnly);
                    log.Push(Default._Messages["Begin"].Replace("{Action}", $"sao chép Movie và Sound. Tổng: {movies.Length + sounds.Length} tệp"));
                    progress.Begin();
                    double percent = 100.0 / (movies.Length + sounds.Length);
                    string moviePath = Path.Combine(Default._JsonConfig["GameLocation"], Default._PatchDirectory, Path.GetFileName(Default._MovieDirectory));
                    string soundPath = Path.Combine(Default._JsonConfig["GameLocation"], Default._PatchDirectory, Path.GetFileName(Default._SoundDirectory));
                    if (!Directory.Exists(moviePath)) Directory.CreateDirectory(moviePath);
                    if (!Directory.Exists(soundPath)) Directory.CreateDirectory(soundPath);
                    foreach (var file in movies)
                    {
                        if (File.Exists(Path.Combine(moviePath, Path.GetFileName(file)))) File.Delete(Path.Combine(moviePath, Path.GetFileName(file)));
                        File.Move(file, Path.Combine(moviePath, Path.GetFileName(file)));
                        progress.Increase(percent);
                    }
                    Directory.Delete(Path.Combine(Default._JsonConfig["GameLocation"], Default._MovieDirectory), true);
                    foreach (var file in sounds)
                    {
                        if (File.Exists(Path.Combine(soundPath, Path.GetFileName(file)))) File.Delete(Path.Combine(soundPath, Path.GetFileName(file)));
                        File.Move(file, Path.Combine(soundPath, Path.GetFileName(file)));
                        progress.Increase(percent);
                    }
                    Directory.Delete(Path.Combine(Default._JsonConfig["GameLocation"], Default._SoundDirectory), true);
                    progress.Finish();
                    Backup(progress, log);
                    PatchExe(progress, log);
                }
                else
                {
                    log.Push(Default._Messages["Cancel"].Replace("{Action}", "cài đặt"));
                    return false;
                }
            }
            if (!File.Exists(Default._Resources))
            {
                /*if (!Directory.Exists(Path.GetDirectoryName(Default._Resources))) Directory.CreateDirectory(Path.GetDirectoryName(Default._Resources));
                Update(progress, log);*/
                if (!File.Exists(Default._Resources)) throw new Exception(Default._Messages["BinNotFound"]);
            }
            progress.Begin();
            byte[] input = File.ReadAllBytes(Default._Resources);
            using (MemoryStream stream = new MemoryStream(input))
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    br.BaseStream.Seek(0, SeekOrigin.Begin);
                    string id = $"{br.ReadInt64()}";
                    if (!Default._JsonConfig.ContainsKey("TranslationID") || id != Default._JsonConfig["TranslationID"])
                    {
                        log.Push(Default._Messages["Cancel"].Replace("{Action}", "cài đặt"));
                        throw new Exception(Default._Messages["InvalidID"]);
                    }
                    int fileCount = br.ReadInt32();
                    log.Push(Default._Messages["Extract"].Replace("{Item}", "bản dịch") + $" Tổng: {fileCount} tệp.");
                    double percent = 100.0 / fileCount;
                    for (int i = 0; i < fileCount; i++)
                    {
                        int pathLen = br.ReadInt32();
                        string pathName = Encoding.ASCII.GetString(br.ReadBytes(pathLen));
                        int dataLen = br.ReadInt32();
                        byte[] data = br.ReadBytes(dataLen);
                        bool isCompressed = br.ReadBoolean();
                        if (isCompressed)
                        {
                            using (var decompressor = new Decompressor())
                            {
                                byte[] decompressedData = decompressor.Unwrap(data);
                                File.WriteAllBytes(Path.Combine(Default._JsonConfig["GameLocation"], Default._PatchDirectory, pathName), decompressedData);
                            }
                        }
                        else
                        {
                            File.WriteAllBytes(Path.Combine(Default._JsonConfig["GameLocation"], Default._PatchDirectory, pathName), data);
                        }
                        progress.Increase(percent);
                    }
                    progress.Finish();
                }
            }
            log.Push(Default._Messages["Complete"].Replace("{Action}", "Cài đặt"));
            return true;
        }
        public static bool Uninstall(ProgressManager progress, LogManager log)
        {
            DialogResult confirm = MessageBox.Show(Default._Messages["Confirm"].Replace("{Action}", "gỡ cài đặt"), Default._MessageTitle, MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                log.Clear();
                progress.Begin();
                log.Push(Default._Messages["BeginUninstall"]);
                string patchDir = Path.Combine(Default._JsonConfig["GameLocation"], Default._PatchDirectory);
                string backupDir = Path.Combine(Default._JsonConfig["GameLocation"], Default._BackupDirectory);
                double percent = 100.0 / (1 + Default._DataDirectories.Length + 2 + 2);
                if (!Directory.Exists(patchDir) || !Directory.Exists(backupDir) || !File.Exists(Path.Combine(backupDir, Default._ExeFile))) throw new Exception(Default._Messages["UninstallFailed"]);
                if (File.Exists(Path.Combine(Default._JsonConfig["GameLocation"], Default._ExeFile))) File.Delete(Path.Combine(Default._JsonConfig["GameLocation"], Default._ExeFile));
                File.Move(Path.Combine(backupDir, Default._ExeFile), Path.Combine(Default._JsonConfig["GameLocation"], Default._ExeFile));
                progress.Increase(percent);
                foreach (var dir in Default._DataDirectories)
                {
                    string des = Path.Combine(Default._JsonConfig["GameLocation"], dir);
                    MoveDirectory(Path.Combine(backupDir, dir), des);
                    progress.Increase(percent);
                }
                MoveDirectory(Path.Combine(patchDir, Path.GetFileName(Default._MovieDirectory)), Path.Combine(Default._JsonConfig["GameLocation"], Default._MovieDirectory));
                progress.Increase(percent);
                MoveDirectory(Path.Combine(patchDir, Path.GetFileName(Default._SoundDirectory)), Path.Combine(Default._JsonConfig["GameLocation"], Default._SoundDirectory));
                progress.Increase(percent);
                Directory.Delete(patchDir, true);
                progress.Increase(percent);
                Directory.Delete(backupDir, true);
                progress.Increase(percent);
                progress.Finish();
                log.Push(Default._Messages["Complete"].Replace("{Action}", "Gỡ cài đặt"));
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void PatchExe(ProgressManager progress, LogManager log)
        {
            progress.Begin();
            log.Push(Default._Messages["PatchExe"]);
            double percent = 100.0 / Default._ExePointers.Count;
            string assetsPath = $"./{Default._PatchDirectory}/";
            using (FileStream stream = File.Open(Path.Combine(Default._JsonConfig["GameLocation"], Default._ExeFile), FileMode.Open, FileAccess.Write))
            {
                using (BinaryWriter bw = new BinaryWriter(stream))
                {
                    foreach (KeyValuePair<long, string> entry in Default._ExePointers)
                    {
                        byte[] oldBytes = Encoding.ASCII.GetBytes(entry.Value);
                        byte[] newBytes = Encoding.ASCII.GetBytes(entry.Value.Replace(Default._ExeAssetsPath, assetsPath));
                        byte[] bytes = new byte[oldBytes.Length];
                        newBytes.CopyTo(bytes, 0);
                        bw.BaseStream.Seek(entry.Key, SeekOrigin.Begin);
                        bw.Write(bytes);
                        progress.Increase(percent);
                    }
                }
            }
            progress.Finish();
        }
        public static bool CheckDirectory(string root = "")
        {
            bool exe = false;
            if (Default._JsonConfig.ContainsKey("GameLocation") && root.Length < 1)
            {
                exe = File.Exists(Path.Combine(Default._JsonConfig["GameLocation"], Default._ExeFile));
            }
            else
            {
                exe = File.Exists(Path.Combine(root, Default._ExeFile));
            }   
            return exe;
        }
    }
}
