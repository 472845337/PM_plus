
using PM_plus.config;
using PM_plus.service;
using PM_plus.utils;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PM_plus {
    public partial class ProjectForm : Form {
        private readonly short operateType;
        public string Section { get; set; }
        public ProjectForm(short operateType) {
            InitializeComponent();
            this.operateType = operateType;
        }

        private void ProjectForm_Load(object sender, EventArgs e) {
            // 根据不同的操作类型进行不同的设置
            if (Config.OPERATE_TYPE_ADD == operateType || Config.OPERATE_TYPE_UPDATE == operateType) {
                // 新增操作或编辑操作
                AddForm_Jar_TextBox.Click += new EventHandler(Jar_Path_Dialog_Show);
                if (Config.OPERATE_TYPE_ADD == operateType) {
                    this.Text = "新增";
                } else if (Config.OPERATE_TYPE_UPDATE == operateType) {
                    this.Text = "修改";

                }
            } else if (Config.OPERATE_TYPE_DETAIL == operateType) {
                this.Text = "查看";
                // 查看操作
                AddForm_Title_TextBox.ReadOnly = true;
                AddForm_Jar_TextBox.ReadOnly = true;
                AddForm_Port_TextBox.ReadOnly = true;
                AddForm_HeartBeat_TextBox.ReadOnly = true;
                AddForm_Actuator_Textbox.ReadOnly = true;
                AddForm_ParamRichTextBox.ReadOnly = true;
                ProjectForm_EnvRichTextBox.ReadOnly = true;
                AddForm_Save_Button.Visible = false;
            }
            if (Config.OPERATE_TYPE_UPDATE == operateType || Config.OPERATE_TYPE_DETAIL == operateType) {
                ProjectSections.ProjectSection monitorSection = ProjectSections.GetProjectBySection(Section);
                String title = monitorSection.Title;
                String jar = monitorSection.Jar;
                String port = monitorSection.Port;
                bool isPrintLog = monitorSection.IsPrintLog;
                String heartBeat = monitorSection.HeartBeat;
                String actuator = monitorSection.Actuator;
                String param = monitorSection.Param;
                String env = monitorSection.Env;
                AddForm_Title_TextBox.Text = title;
                AddForm_Jar_TextBox.Text = jar;
                AddForm_Port_TextBox.Text = port;
                AddForm_IsPrintLogCheckBox.Checked = isPrintLog;
                AddForm_HeartBeat_TextBox.Text = heartBeat;
                AddForm_Actuator_Textbox.Text = actuator;
                AddForm_ParamRichTextBox.Text = param;
                ProjectForm_EnvRichTextBox.Text = env;
            }
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
            String env = ProjectForm_EnvRichTextBox.Text;
            Boolean checkFlag = true;
            StringBuilder checkMsg = new StringBuilder();
            if (StringUtils.IsEmpty(title)) {
                checkFlag = false;
                checkMsg.Append("名称未填写").Append(Config.ENTER_STR);
            }
            if (StringUtils.IsEmpty(jar)) {
                checkFlag = false;
                checkMsg.Append("jar包路径未选择").Append(Config.ENTER_STR);
            }
            if (StringUtils.IsEmpty(port)) {
                checkFlag = false;
                checkMsg.Append("端口未配置").Append(Config.ENTER_STR);
            } else {
                if (!Regex.IsMatch(port, @"^\d*$")) {
                    // 端口必须要是数字
                    checkFlag = false;
                    checkMsg.Append("端口必须是数字").Append(Config.ENTER_STR);
                } else if(Convert.ToInt32(port) > 65535) {
                    // 端口不能大于65535
                    checkFlag = false;
                    checkMsg.Append("端口不能大于65535").Append(Config.ENTER_STR);
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
                String operateSection = Config.OPERATE_TYPE_ADD.Equals(operateType) ? Guid.NewGuid().ToString() : Section;
                // 生成title
                IniUtils.IniWriteValue(Config.ProjectsIniPath, operateSection, Config.INI_KEY_PROJECT_TITLE, title);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, operateSection, Config.INI_KEY_PROJECT_JAR, jar);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, operateSection, Config.INI_KEY_PROJECT_PORT, port);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, operateSection, Config.INI_KEY_PROJECT_PRINT_LOG, isPrintLog);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, operateSection, Config.INI_KEY_PROJECT_HEART_BEAT, heartBeat);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, operateSection, Config.INI_KEY_PROJECT_ACTUATOR, actuator);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, operateSection, Config.INI_KEY_PROJECT_PARAM, param);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, operateSection, Config.INI_KEY_PROJECT_ENV, env);
                // 项目对象赋值
                ProjectSections.ProjectSection projectModel = new ProjectSections.ProjectSection {
                    Section = operateSection,
                    Title = title,
                    Jar = jar,
                    Port = port,
                    IsPrintLog = isPrintLogBl,
                    HeartBeat = heartBeat,
                    Actuator = actuator,
                    Param = param,
                    Env = env
                };
                // 生成start.bat
                String result = ProjectUtils.CreateStartBat(projectModel, Config.LOG_FILE_INFO, Config.LOG_FILE_ERROR);
                if (!bool.TrueString.Equals(result)) {
                    MessageBox.Show(result);
                }
                // 生成stop.bat
                ProjectUtils.CreateStopBat(projectModel);

                if (Config.OPERATE_TYPE_ADD.Equals(operateType)) {
                    /* StartForm中添加新服务按钮 *************/
                    FormService.AddButton(projectModel);

                    // 初始化为未运行
                    projectModel.RunStat = Config.PROJECT_RUN_STAT_UNRUN;
                    projectModel.IsRunning = false;

                } else if (Config.OPERATE_TYPE_UPDATE.Equals(operateType)) {
                    FormService.UpdateButton(projectModel);
                }
                #region 数据写进缓存
                ProjectSections.UpdateProjectSection(operateSection, projectModel);
                #endregion
                /* 添加新服务按钮完成****** *************/
                // ControlUtils.addTabPage2TabControl(Config.mainForm.ProjectRunTabControl, newSection);
                // 关闭新增窗口
                this.Close();
            }
        }

        private void Jar_Path_Dialog_Show(object sender, EventArgs e) {
            if (Jar_OpenFileDialog.ShowDialog() == DialogResult.OK) {
                AddForm_Jar_TextBox.Text = Jar_OpenFileDialog.FileName;
            }
        }


    }
}
