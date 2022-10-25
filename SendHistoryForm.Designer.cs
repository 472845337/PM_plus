namespace PM_plus {
    partial class SendHistoryForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendHistoryForm));
            this.HistoryListBox = new System.Windows.Forms.ListBox();
            this.HistoryClearButton = new System.Windows.Forms.Button();
            this.HistoryFreshButton = new System.Windows.Forms.Button();
            this.HistoryDeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HistoryListBox
            // 
            this.HistoryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryListBox.FormattingEnabled = true;
            this.HistoryListBox.ItemHeight = 12;
            this.HistoryListBox.Location = new System.Drawing.Point(13, 13);
            this.HistoryListBox.Name = "HistoryListBox";
            this.HistoryListBox.Size = new System.Drawing.Size(322, 256);
            this.HistoryListBox.TabIndex = 0;
            this.HistoryListBox.SelectedIndexChanged += new System.EventHandler(this.HistoryListBox_SelectedIndexChanged);
            // 
            // HistoryClearButton
            // 
            this.HistoryClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryClearButton.Location = new System.Drawing.Point(293, 279);
            this.HistoryClearButton.Name = "HistoryClearButton";
            this.HistoryClearButton.Size = new System.Drawing.Size(42, 23);
            this.HistoryClearButton.TabIndex = 1;
            this.HistoryClearButton.Text = "清空";
            this.HistoryClearButton.UseVisualStyleBackColor = true;
            this.HistoryClearButton.Click += new System.EventHandler(this.HistoryClearButton_Click);
            // 
            // HistoryFreshButton
            // 
            this.HistoryFreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryFreshButton.Location = new System.Drawing.Point(201, 279);
            this.HistoryFreshButton.Name = "HistoryFreshButton";
            this.HistoryFreshButton.Size = new System.Drawing.Size(40, 23);
            this.HistoryFreshButton.TabIndex = 2;
            this.HistoryFreshButton.Text = "刷新";
            this.HistoryFreshButton.UseVisualStyleBackColor = true;
            this.HistoryFreshButton.Click += new System.EventHandler(this.HistoryFreshButton_Click);
            // 
            // HistoryDeleteButton
            // 
            this.HistoryDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryDeleteButton.Location = new System.Drawing.Point(247, 279);
            this.HistoryDeleteButton.Name = "HistoryDeleteButton";
            this.HistoryDeleteButton.Size = new System.Drawing.Size(40, 23);
            this.HistoryDeleteButton.TabIndex = 3;
            this.HistoryDeleteButton.Text = "删除";
            this.HistoryDeleteButton.UseVisualStyleBackColor = true;
            this.HistoryDeleteButton.Click += new System.EventHandler(this.HistoryDeleteButton_Click);
            // 
            // SendHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 314);
            this.Controls.Add(this.HistoryDeleteButton);
            this.Controls.Add(this.HistoryFreshButton);
            this.Controls.Add(this.HistoryClearButton);
            this.Controls.Add(this.HistoryListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SendHistoryForm";
            this.Text = "SendHistoryForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SendHistoryForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox HistoryListBox;
        private System.Windows.Forms.Button HistoryClearButton;
        private System.Windows.Forms.Button HistoryFreshButton;
        private System.Windows.Forms.Button HistoryDeleteButton;
    }
}