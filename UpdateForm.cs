using PM_plus.config;
using PM_plus.service;
using PM_plus.utils;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PM_plus {
    public partial class UpdateForm : Form {
        public String section { get; set; }

        public UpdateForm() {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e) {
            ProjectSections.ProjectSection monitorSection = ProjectSections.getProjectBySection(section);
            String title = monitorSection.title;
            String jar = monitorSection.jar;
            String port = monitorSection.port;
            bool isPrintLog = monitorSection.isPrintLog;
            String heartBeat = monitorSection.heartBeat;
            String actuator = monitorSection.actuator;
            String param = monitorSection.param;
            UpdateForm_Title_TextBox.Text = title;
            UpdateForm_Jar_TextBox.Text = jar;
            UpdateForm_Port_TextBox.Text = port;
            UpdateForm_IsPrintLogCheckBox.Checked = isPrintLog;
            UpdateForm_HeartBeat_TextBox.Text = heartBeat;
            UpdateForm_Actuator_Textbox.Text = actuator;
            UpdateForm_ParamRichTextBox.Text = param;
        }

        private void UpdateForm_Cancel_Button_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void UpdateForm_Save_Button_Click(object sender, EventArgs e) {
            String title = UpdateForm_Title_TextBox.Text;
            String jar = UpdateForm_Jar_TextBox.Text;
            String port = UpdateForm_Port_TextBox.Text;
            bool isPrintLogBl = UpdateForm_IsPrintLogCheckBox.Checked;
            String isPrintLog = isPrintLogBl ? Config.IS_PRINT_LOG_YES : Config.IS_PRINT_LOG_NO;
            String heartBeat = UpdateForm_HeartBeat_TextBox.Text;
            String actuator = UpdateForm_Actuator_Textbox.Text;
            String param = UpdateForm_ParamRichTextBox.Text;
            Boolean checkFlag = true;
            StringBuilder checkMsg = new StringBuilder();
            if (StringUtils.isEmpty(title)) {
                checkFlag = false;
                checkMsg.Append("名称未填写").Append(Config.ENTER_STR);
            }
            if (StringUtils.isEmpty(jar)) {
                checkFlag = false;
                checkMsg.Append("jar包路径未选择").Append(Config.ENTER_STR);
            }
            if (StringUtils.isEmpty(port)) {
                checkFlag = false;
                checkMsg.Append("端口未配置").Append(Config.ENTER_STR);
            } else {
                if (!Regex.IsMatch(port, @"^[+-]?\d*$")) {
                    // 端口必须要是数字
                    checkFlag = false;
                    checkMsg.Append("端口不合法").Append(Config.ENTER_STR);
                }
            }
            /*if (StringUtils.isEmpty(heartBeat)) {
                checkFlag = false;
                checkMsg.Append("心跳地址未配置").Append(Config.ENTER_STR);
            }*/
            if (!checkFlag) {
                MessageBox.Show(checkMsg.ToString(), "错误");
            } else {
                /** 数据正常，修改ini数据，执行StartForm添加按钮和新增rdp文件操作 */
                // 生成title
                IniUtils.IniWriteValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_TITLE, title);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_JAR, jar);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_PORT, port);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_PRINT_LOG, isPrintLog);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_HEART_BEAT, heartBeat);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_ACTUATOR, actuator);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_PARAM, param);
                /* 生成新INI结束 ************************/
                // sections缓存数据修改
                ProjectSections.ProjectSection monitorSection = ProjectSections.getProjectBySection(section);
                monitorSection.title = title;
                monitorSection.jar = jar;
                monitorSection.port = port;
                monitorSection.isPrintLog = isPrintLogBl;
                monitorSection.heartBeat = heartBeat;
                monitorSection.actuator = actuator;
                monitorSection.param = param;
                ProjectSections.updateProjectSection(section, monitorSection);
                // 生成start.bat
                String logPath = Path.GetDirectoryName(jar) + Config.PATH_CHARACTER + title;
                ProjectUtils.createStartBat(monitorSection, logPath, Config.LOG_FILE_INFO, Config.LOG_FILE_ERROR);
                // 生成stop.bat
                ProjectUtils.createStopBat(monitorSection);
                /* StartForm中更新服务按钮 *************/
                FormService.updateButton(section);
                /* 更新服务按钮完成****** *************/
                // 关闭窗口
                this.Close();
            }
        }


        private void UpdateForm_Jar_Dialog_Button_Click(object sender, EventArgs e) {
            Jar_UpdateOpenFileDialog.InitialDirectory = UpdateForm_Jar_TextBox.Text;
            if (Jar_UpdateOpenFileDialog.ShowDialog() == DialogResult.OK) {
                UpdateForm_Jar_TextBox.Text = Jar_UpdateOpenFileDialog.FileName;
            }
        }
    }
}
