
namespace PM_plus {
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddForm_Save_Button = new System.Windows.Forms.Button();
            this.AddForm_Cancel_Button = new System.Windows.Forms.Button();
            this.AddForm_Title_Label = new System.Windows.Forms.Label();
            this.AddForm_Title_TextBox = new System.Windows.Forms.TextBox();
            this.AddForm_Jar_Label = new System.Windows.Forms.Label();
            this.AddForm_Jar_TextBox = new System.Windows.Forms.TextBox();
            this.AddForm_Port_TextBox = new System.Windows.Forms.TextBox();
            this.AddForm_Port_Label = new System.Windows.Forms.Label();
            this.AddForm_HeartBeat_TextBox = new System.Windows.Forms.TextBox();
            this.AddForm_HeartBeat_Label = new System.Windows.Forms.Label();
            this.Jar_Dialog_Button = new System.Windows.Forms.Button();
            this.Jar_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AddForm_Actuator_Textbox = new System.Windows.Forms.TextBox();
            this.AddForm_Actuator_Label = new System.Windows.Forms.Label();
            this.AddForm_IsPrintLogCheckBox = new System.Windows.Forms.CheckBox();
            this.AddForm_ParamLabel = new System.Windows.Forms.Label();
            this.AddForm_ParamRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // AddForm_Save_Button
            // 
            this.AddForm_Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddForm_Save_Button.Location = new System.Drawing.Point(239, 226);
            this.AddForm_Save_Button.Name = "AddForm_Save_Button";
            this.AddForm_Save_Button.Size = new System.Drawing.Size(55, 23);
            this.AddForm_Save_Button.TabIndex = 0;
            this.AddForm_Save_Button.Text = "保存";
            this.AddForm_Save_Button.UseVisualStyleBackColor = true;
            this.AddForm_Save_Button.Click += new System.EventHandler(this.AddForm_Save_Button_Click);
            // 
            // AddForm_Cancel_Button
            // 
            this.AddForm_Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddForm_Cancel_Button.Location = new System.Drawing.Point(299, 226);
            this.AddForm_Cancel_Button.Name = "AddForm_Cancel_Button";
            this.AddForm_Cancel_Button.Size = new System.Drawing.Size(50, 23);
            this.AddForm_Cancel_Button.TabIndex = 1;
            this.AddForm_Cancel_Button.Text = "取消";
            this.AddForm_Cancel_Button.UseVisualStyleBackColor = true;
            this.AddForm_Cancel_Button.Click += new System.EventHandler(this.AddForm_Cancel_Button_Click);
            // 
            // AddForm_Title_Label
            // 
            this.AddForm_Title_Label.AutoSize = true;
            this.AddForm_Title_Label.Location = new System.Drawing.Point(18, 16);
            this.AddForm_Title_Label.Name = "AddForm_Title_Label";
            this.AddForm_Title_Label.Size = new System.Drawing.Size(40, 17);
            this.AddForm_Title_Label.TabIndex = 2;
            this.AddForm_Title_Label.Text = "名  称";
            // 
            // AddForm_Title_TextBox
            // 
            this.AddForm_Title_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddForm_Title_TextBox.Location = new System.Drawing.Point(64, 12);
            this.AddForm_Title_TextBox.Name = "AddForm_Title_TextBox";
            this.AddForm_Title_TextBox.Size = new System.Drawing.Size(284, 23);
            this.AddForm_Title_TextBox.TabIndex = 3;
            // 
            // AddForm_Jar_Label
            // 
            this.AddForm_Jar_Label.AutoSize = true;
            this.AddForm_Jar_Label.Location = new System.Drawing.Point(18, 44);
            this.AddForm_Jar_Label.Name = "AddForm_Jar_Label";
            this.AddForm_Jar_Label.Size = new System.Drawing.Size(40, 17);
            this.AddForm_Jar_Label.TabIndex = 4;
            this.AddForm_Jar_Label.Text = "路  径";
            // 
            // AddForm_Jar_TextBox
            // 
            this.AddForm_Jar_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddForm_Jar_TextBox.Location = new System.Drawing.Point(64, 41);
            this.AddForm_Jar_TextBox.Name = "AddForm_Jar_TextBox";
            this.AddForm_Jar_TextBox.Size = new System.Drawing.Size(248, 23);
            this.AddForm_Jar_TextBox.TabIndex = 5;
            // 
            // AddForm_Port_TextBox
            // 
            this.AddForm_Port_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddForm_Port_TextBox.Location = new System.Drawing.Point(64, 70);
            this.AddForm_Port_TextBox.Name = "AddForm_Port_TextBox";
            this.AddForm_Port_TextBox.Size = new System.Drawing.Size(284, 23);
            this.AddForm_Port_TextBox.TabIndex = 7;
            // 
            // AddForm_Port_Label
            // 
            this.AddForm_Port_Label.AutoSize = true;
            this.AddForm_Port_Label.Location = new System.Drawing.Point(18, 73);
            this.AddForm_Port_Label.Name = "AddForm_Port_Label";
            this.AddForm_Port_Label.Size = new System.Drawing.Size(40, 17);
            this.AddForm_Port_Label.TabIndex = 6;
            this.AddForm_Port_Label.Text = "端  口";
            // 
            // AddForm_HeartBeat_TextBox
            // 
            this.AddForm_HeartBeat_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddForm_HeartBeat_TextBox.Location = new System.Drawing.Point(64, 99);
            this.AddForm_HeartBeat_TextBox.Name = "AddForm_HeartBeat_TextBox";
            this.AddForm_HeartBeat_TextBox.Size = new System.Drawing.Size(284, 23);
            this.AddForm_HeartBeat_TextBox.TabIndex = 9;
            // 
            // AddForm_HeartBeat_Label
            // 
            this.AddForm_HeartBeat_Label.AutoSize = true;
            this.AddForm_HeartBeat_Label.Location = new System.Drawing.Point(18, 102);
            this.AddForm_HeartBeat_Label.Name = "AddForm_HeartBeat_Label";
            this.AddForm_HeartBeat_Label.Size = new System.Drawing.Size(40, 17);
            this.AddForm_HeartBeat_Label.TabIndex = 8;
            this.AddForm_HeartBeat_Label.Text = "心  跳";
            // 
            // Jar_Dialog_Button
            // 
            this.Jar_Dialog_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Jar_Dialog_Button.Location = new System.Drawing.Point(318, 41);
            this.Jar_Dialog_Button.Name = "Jar_Dialog_Button";
            this.Jar_Dialog_Button.Size = new System.Drawing.Size(29, 23);
            this.Jar_Dialog_Button.TabIndex = 10;
            this.Jar_Dialog_Button.Text = "...";
            this.Jar_Dialog_Button.UseVisualStyleBackColor = true;
            this.Jar_Dialog_Button.Click += new System.EventHandler(this.Jar_Dialog_Button_Click);
            // 
            // Jar_OpenFileDialog
            // 
            this.Jar_OpenFileDialog.Filter = "Jar Fies(*.jar)|*.jar|All Files(*.*)|*.*";
            // 
            // AddForm_Actuator_Textbox
            // 
            this.AddForm_Actuator_Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddForm_Actuator_Textbox.Location = new System.Drawing.Point(64, 128);
            this.AddForm_Actuator_Textbox.Name = "AddForm_Actuator_Textbox";
            this.AddForm_Actuator_Textbox.Size = new System.Drawing.Size(284, 23);
            this.AddForm_Actuator_Textbox.TabIndex = 12;
            // 
            // AddForm_Actuator_Label
            // 
            this.AddForm_Actuator_Label.AutoSize = true;
            this.AddForm_Actuator_Label.Location = new System.Drawing.Point(18, 131);
            this.AddForm_Actuator_Label.Name = "AddForm_Actuator_Label";
            this.AddForm_Actuator_Label.Size = new System.Drawing.Size(40, 17);
            this.AddForm_Actuator_Label.TabIndex = 11;
            this.AddForm_Actuator_Label.Text = "监  控";
            // 
            // AddForm_IsPrintLogCheckBox
            // 
            this.AddForm_IsPrintLogCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddForm_IsPrintLogCheckBox.AutoSize = true;
            this.AddForm_IsPrintLogCheckBox.Checked = true;
            this.AddForm_IsPrintLogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AddForm_IsPrintLogCheckBox.Location = new System.Drawing.Point(64, 226);
            this.AddForm_IsPrintLogCheckBox.Name = "AddForm_IsPrintLogCheckBox";
            this.AddForm_IsPrintLogCheckBox.Size = new System.Drawing.Size(99, 21);
            this.AddForm_IsPrintLogCheckBox.TabIndex = 14;
            this.AddForm_IsPrintLogCheckBox.Text = "是否打印日志";
            this.AddForm_IsPrintLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddForm_ParamLabel
            // 
            this.AddForm_ParamLabel.AutoSize = true;
            this.AddForm_ParamLabel.Location = new System.Drawing.Point(18, 160);
            this.AddForm_ParamLabel.Name = "AddForm_ParamLabel";
            this.AddForm_ParamLabel.Size = new System.Drawing.Size(40, 17);
            this.AddForm_ParamLabel.TabIndex = 15;
            this.AddForm_ParamLabel.Text = "参  数";
            // 
            // AddForm_ParamRichTextBox
            // 
            this.AddForm_ParamRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddForm_ParamRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddForm_ParamRichTextBox.Location = new System.Drawing.Point(65, 160);
            this.AddForm_ParamRichTextBox.Name = "AddForm_ParamRichTextBox";
            this.AddForm_ParamRichTextBox.Size = new System.Drawing.Size(282, 60);
            this.AddForm_ParamRichTextBox.TabIndex = 16;
            this.AddForm_ParamRichTextBox.Text = "";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 259);
            this.Controls.Add(this.AddForm_ParamRichTextBox);
            this.Controls.Add(this.AddForm_ParamLabel);
            this.Controls.Add(this.AddForm_IsPrintLogCheckBox);
            this.Controls.Add(this.AddForm_Actuator_Textbox);
            this.Controls.Add(this.AddForm_Actuator_Label);
            this.Controls.Add(this.Jar_Dialog_Button);
            this.Controls.Add(this.AddForm_HeartBeat_TextBox);
            this.Controls.Add(this.AddForm_HeartBeat_Label);
            this.Controls.Add(this.AddForm_Port_TextBox);
            this.Controls.Add(this.AddForm_Port_Label);
            this.Controls.Add(this.AddForm_Jar_TextBox);
            this.Controls.Add(this.AddForm_Jar_Label);
            this.Controls.Add(this.AddForm_Title_TextBox);
            this.Controls.Add(this.AddForm_Title_Label);
            this.Controls.Add(this.AddForm_Cancel_Button);
            this.Controls.Add(this.AddForm_Save_Button);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddForm_Save_Button;
        private System.Windows.Forms.Button AddForm_Cancel_Button;
        private System.Windows.Forms.Label AddForm_Title_Label;
        private System.Windows.Forms.TextBox AddForm_Title_TextBox;
        private System.Windows.Forms.Label AddForm_Jar_Label;
        private System.Windows.Forms.TextBox AddForm_Jar_TextBox;
        private System.Windows.Forms.TextBox AddForm_Port_TextBox;
        private System.Windows.Forms.Label AddForm_Port_Label;
        private System.Windows.Forms.TextBox AddForm_HeartBeat_TextBox;
        private System.Windows.Forms.Label AddForm_HeartBeat_Label;
        private System.Windows.Forms.Button Jar_Dialog_Button;
        private System.Windows.Forms.OpenFileDialog Jar_OpenFileDialog;
        private System.Windows.Forms.TextBox AddForm_Actuator_Textbox;
        private System.Windows.Forms.Label AddForm_Actuator_Label;
        private System.Windows.Forms.CheckBox AddForm_IsPrintLogCheckBox;
        private System.Windows.Forms.Label AddForm_ParamLabel;
        private System.Windows.Forms.RichTextBox AddForm_ParamRichTextBox;
    }
}