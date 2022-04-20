using PM_plus.config;
using System;
using System.Windows.Forms;

namespace PM_plus
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        
        private void WaitForm_Load(object sender, EventArgs e)
        {
            Config.mainForm.Enabled = false;
        }

        public void FreshProgress(Int32 value)
        {
            WaitForm_ProgressBar.Value = value;
        }

        private void WaitForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Config.mainForm.Enabled = true;
            WaitForm_ProgressBar.Value = 0;
        }
    }
}
