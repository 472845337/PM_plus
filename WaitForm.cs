using PM_plus.config;
using System;
using System.IO;
using System.Windows.Forms;

namespace PM_plus {
    public partial class WaitForm : Form {

        public WaitForm() {
            InitializeComponent();
        }
        System.Threading.Thread loadingThread;
        private void WaitForm_Load(object sender, EventArgs e) {
            Config.mainForm.Enabled = false;
            loadingThread = new System.Threading.Thread(ThreadShowLoading);
            // 线程启动
            loadingThread.Start();
        }

        private void WaitForm_FormClosed(object sender, FormClosedEventArgs e) {
            Config.mainForm.Enabled = true;
        }

        private void ThreadShowLoading() {
            while (true) {
                String text = LoadingLabel.Text;
                if (text.Length >= 6) {
                    text = ".";
                } else {
                    text += ".";
                }
                LoadingLabel.Text = text;
                System.Threading.Thread.Sleep(500);
            }
        }

        /// <summary>
        /// 等待关闭之前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaitForm_FormClosing(object sender, FormClosingEventArgs e) {
            // 关闭线程
            loadingThread.Abort();
        }
    }
}
