using System;
using System.Windows.Forms;

namespace NieR_Replicant_Viet_Hoa
{
    public class LogManager
    {
        private ListBox _Log;
        public ListBox Log
        {
            get { return Log; }
            set { _Log = value; }
        }
        public LogManager(ListBox listBox)
        {
            _Log = listBox;
        }
        public void Push(string content, bool log = false)
        {
            _Log.BeginInvoke((MethodInvoker)delegate
            {
                if (log)
                {
                    string[] lines = content.Split(new string[] { "\n" }, StringSplitOptions.None);
                    foreach (string line in lines)
                    {
                        _Log.Items.Add(line);
                    }
                }
                else
                {
                    _Log.Items.Add(content);
                }
                _Log.SelectedIndex = _Log.Items.Count - 1;
                _Log.SelectedIndex = -1;
            });
        }
        public void Clear()
        {
            _Log.BeginInvoke((MethodInvoker)delegate
            {
                _Log.Items.Clear();
            });
        }
    }
}
