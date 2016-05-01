using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradePredictor.Util
{
    class StatusEventArgs : EventArgs
    {
        private string message;
        private ProgressBarStyle style;
        private int value;

        public string Message { get { return this.message; } }
        public ProgressBarStyle Style { get { return this.style; } }
        public int Value { get { return this.value; } }


        public StatusEventArgs(string m, ProgressBarStyle s, int v)
        {
            this.message = m;
            this.style = s;
            this.value = v;
        }
    }
}
