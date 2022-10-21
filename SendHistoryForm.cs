using PM_plus.config;
using PM_plus.pojo;
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
            initListBox();
        }

        private void HistoryClearButton_Click(object sender, EventArgs e) {
            hshs.clear();
            HistoryListBox.Items.Clear();
        }

        private void HistoryListBox_SelectedIndexChanged(object sender, EventArgs e) {
            int count = HistoryListBox.SelectedItems.Count;
            if (count > 0) {
                HttpSendHistory history = (HistoryListBox.SelectedItem as HttpSendHistory);
                Config.mainForm.UrlTextBox.Text = history.Url;
                Config.mainForm.TypeComboBox.SelectedItem = history.Type;
            }
        }

        private void HistoryDeleteButton_Click(object sender, EventArgs e) {
            int count = HistoryListBox.SelectedItems.Count;
            if(count > 0) {
                HttpSendHistory history = (HistoryListBox.SelectedItem as HttpSendHistory);
                hshs.deleteData(history.Id);
                HistoryListBox.Items.Remove(HistoryListBox.SelectedItem);
            } else {
                MessageBox.Show("请选择删除数据！");
            }
            
        }

        private void HistoryFreshButton_Click(object sender, EventArgs e) {
            HistoryListBox.Items.Clear();
            initListBox();
        }

        private void initListBox() {
            List<HttpSendHistory> sendHistoryList = hshs.selectList(new HttpSendHistory());
            foreach (HttpSendHistory history in sendHistoryList) {
                HistoryListBox.Items.Add(history);
            }
            // 不能使用DataSource方式赋值，不然无法remove
            // HistoryListBox.DataSource = sendHistoryList;
            // HistoryListBox.SelectedIndex = -1;
            // HistoryListBox.SelectedIndexChanged += HistoryListBox_SelectedIndexChanged;
            // 历史记录中的url
            HistoryListBox.DisplayMember = "url";
        }
    }
}
