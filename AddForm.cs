
using PM_plus.config;
using PM_plus.service;
using PM_plus.utils;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PM_plus {
    public partial class AddForm : Form {

        public AddForm() {
            InitializeComponent();
        }

        private void AddForm_Cancel_Button_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void AddForm_Save_Button_Click(object sender, EventArgs e) {
            String title = AddForm_Title_TextBox.Text;
            String jar = AddForm_Jar_TextBox.Text;
            String port = AddForm_Port_TextBox.Text;
            bool isPrintLogBl = AddForm_IsPrintLogCheckBox.Checked;
            String isPrintLog = isPrintLogBl ? Config.IS_PRINT_LOG_YES : Config.IS_PRINT_LOG_NO;
            String heartBeat = AddForm_HeartBeat_TextBox.Text;
            String actuator = AddForm_Actuator_Textbox.Text;
            String param = AddForm_ParamRichTextBox.Text;

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
            /*if ("".Equals(heartBeat ))
            {
                checkFlag = false;
                checkMsg.Append("心跳地址未配置\r\n");
            }*/

            if (!checkFlag) {
                MessageBox.Show(checkMsg.ToString(), "错误");
            } else {
                /** 数据正常，生成新的ini数据，执行StartForm添加按钮和新增rdp文件操作 */
                /* 生成新INI ****************************/
                String newSection = Guid.NewGuid().ToString();
                // 生成title
                IniUtils.IniWriteValue(Config.ProjectsIniPath, newSection, Config.INI_KEY_PROJECT_TITLE, title);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, newSection, Config.INI_KEY_PROJECT_JAR, jar);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, newSection, Config.INI_KEY_PROJECT_PORT, port);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, newSection, Config.INI_KEY_PROJECT_PRINT_LOG, isPrintLog);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, newSection, Config.INI_KEY_PROJECT_HEART_BEAT, heartBeat);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, newSection, Config.INI_KEY_PROJECT_ACTUATOR, actuator);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, newSection, Config.INI_KEY_PROJECT_PARAM, param);
                // 项目对象赋值
                String logPath = Path.GetDirectoryName(jar) + Config.PATH_CHARACTER + title;
                ProjectSections.ProjectSection addModel = new ProjectSections.ProjectSection();
                addModel.section = newSection;
                addModel.title = title;
                addModel.jar = jar;
                addModel.port = port;
                addModel.isPrintLog = isPrintLogBl;
                addModel.heartBeat = heartBeat;
                addModel.actuator = actuator;
                // 生成start.bat
                ProjectUtils.createStartBat(addModel, logPath, Config.LOG_FILE_INFO, Config.LOG_FILE_ERROR);
                // 生成stop.bat
                ProjectUtils.createStopBat(addModel);
                /* StartForm中添加新服务按钮 *************/
                FormService.addButton(addModel);
                /* 添加新服务按钮完成****** *************/
                // ControlUtils.addTabPage2TabControl(Config.mainForm.ProjectRunTabControl, newSection);
                // 关闭新增窗口
                this.Close();
            }
        }

        private void Jar_Dialog_Button_Click(object sender, EventArgs e) {
            if (Jar_OpenFileDialog.ShowDialog() == DialogResult.OK) {
                AddForm_Jar_TextBox.Text = Jar_OpenFileDialog.FileName;
            }
        }
    }
}
