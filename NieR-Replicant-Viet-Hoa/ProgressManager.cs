using System;
using System.Windows.Forms;

namespace NieR_Replicant_Viet_Hoa
{
    public class ProgressManager
    {
        private double _Current;
        private ProgressBar _ProgressB;
        public ProgressBar ProgressB
        {
            get { return _ProgressB; }
        }
        public double Current
        {
            get { return _Current; }
            set { _Current = value; }
        }
        public ProgressManager(ProgressBar progressBar)
        {
            _Current = 0;
            _ProgressB = progressBar;
        }
        public void Increase(double value)
        {
            _Current += value;
            _ProgressB.BeginInvoke((MethodInvoker)delegate
            {
                if (Math.Round(_Current) < 100) _ProgressB.Value = (int)Math.Round(_Current);
                else _ProgressB.Value = 100;
            });
        }
        public void SetPercent(int value)
        {
            _ProgressB.BeginInvoke((MethodInvoker)delegate
            {
                if (value < 100) _ProgressB.Value = value;
                else _ProgressB.Value = 100;
            });
        }
        public void Begin()
        {
            _Current = 0;
            _ProgressB.BeginInvoke((MethodInvoker)delegate
            {
                _ProgressB.Value = 0;
            });
        }
        public void Finish()
        {
            _Current = 100;
            _ProgressB.BeginInvoke((MethodInvoker)delegate
            {
                _ProgressB.Value = 100;
            });
        }
    }
}
