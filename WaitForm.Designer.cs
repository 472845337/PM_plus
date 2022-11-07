
namespace PM_plus {
    partial class WaitForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForm));
            this.WaitForm_Label = new System.Windows.Forms.Label();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WaitForm_Label
            // 
            this.WaitForm_Label.AutoSize = true;
            this.WaitForm_Label.Location = new System.Drawing.Point(72, 28);
            this.WaitForm_Label.Name = "WaitForm_Label";
            this.WaitForm_Label.Size = new System.Drawing.Size(41, 12);
            this.WaitForm_Label.TabIndex = 2;
            this.WaitForm_Label.Text = "加载中";
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.AutoSize = true;
            this.LoadingLabel.Location = new System.Drawing.Point(120, 28);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(11, 12);
            this.LoadingLabel.TabIndex = 3;
            this.LoadingLabel.Text = ".";
            // 
            // WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 60);
            this.Controls.Add(this.LoadingLabel);
            this.Controls.Add(this.WaitForm_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "加载数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaitForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WaitForm_FormClosed);
            this.Load += new System.EventHandler(this.WaitForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label WaitForm_Label;
        private System.Windows.Forms.Label LoadingLabel;
    }
}