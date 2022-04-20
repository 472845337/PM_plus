
using PM_plus.config;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PM_plus.utils
{
    class Monitor
    {
        private readonly String url;
        private readonly Button button;

        public Monitor(String url, Button button)
        {
            this.url = url;
            this.button = button;
        }
        public void MonitorUrl()
        {
            String result = HttpUtils.PostRequest(url, Config.BLANK_STR, null);
            if ("success".Equals(result))
            {
                button.BackColor = Color.LimeGreen;
            }
            else
            {
                button.BackColor = Color.OrangeRed;
            }
        }
    }
}
