using System;
using System.Windows.Forms;
using System.Drawing;

namespace NieR_Replicant_Viet_Hoa
{
    public partial class CreditUI : Form
    {
        public CreditUI()
        {
            InitializeComponent();
        }

        private void CreditUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void linkVHG_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Operation.OpenUrl("https://viethoagame.com/");
        }

        private void linkDC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Operation.OpenUrl("https://viethoagame.com/members/dc.2/");
        }

        private void linkLH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Operation.OpenUrl("https://www.facebook.com/100004440041815");
        }

        private void linkLH2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Operation.OpenUrl("https://www.facebook.com/100004440041815");
        }

        private void linkOb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Operation.OpenUrl("https://viethoagame.com/members/oblivion.4/");
        }

        private void CreditUI_Load(object sender, EventArgs e)
        {
            webBrowser.ScrollBarsEnabled = false;
            webBrowser.DocumentText = "";
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser.Document.BackColor = this.BackColor;
        }
    }
}
