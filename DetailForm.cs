using PM_plus.config;
using PM_plus.utils;
using System;
using System.Windows.Forms;

namespace PM_plus {
    public partial class DetailForm : Form
    {
        IniUtils iniUtils = new IniUtils();
        public String section { get; set; }
        public DetailForm()
        {
            InitializeComponent();
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            ProjectSections.ProjectSection monitorSection = ProjectSections.getProjectBySection(section);
            String title = monitorSection.title;
            String jar = monitorSection.jar;
            String port = monitorSection.port;
            bool isPrintLogBl = monitorSection.isPrintLog;
            String heartBeat = monitorSection.heartBeat;
            String actuator = monitorSection.actuator;
            String param = monitorSection.param;
            Title_TextBox.Text = title;
            Jar_TextBox.Text = jar;
            Port_TextBox.Text = port;
            DetailForm_IsPrintLogCheckBox.Checked = isPrintLogBl;
            HeartBeat_TextBox.Text = heartBeat;
            Actuator_Textbox.Text = actuator;
            DetailForm_ParamRichTextBox.Text = param;

            Title_TextBox.ReadOnly = true;
            Jar_TextBox.ReadOnly = true;
            Port_TextBox.ReadOnly = true;
            HeartBeat_TextBox.ReadOnly = true;
            Actuator_Textbox.ReadOnly = true;
            DetailForm_ParamRichTextBox.ReadOnly = true;
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
