
using PM_plus.config;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PM_plus.utils
{
    class Monitor
    {
        private String title;
        private String url;
        private String warn;
        private Button button;

        public Monitor(String title, String url, String warn, Button button)
        {
            this.title = title;
            this.url = url;
            this.warn = warn;
            this.button = button;
        }
        public void monitorUrl()
        {
            String result = HttpUtils.postRequest(url, Config.BLANK_STR, null);
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
