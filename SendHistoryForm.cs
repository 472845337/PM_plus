using PM_plus.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PM_plus {
    
    public partial class SendHistoryForm : Form {

        internal HttpSendHistoryService hshs = new HttpSendHistoryService();
        public SendHistoryForm() {
            InitializeComponent();
            hshs.selectList(new pojo.HttpSendHistory());
        }

        private void HistoryClearButton_Click(object sender, EventArgs e) {
            hshs.clear();
        }
    }
}
