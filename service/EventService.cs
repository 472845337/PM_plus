using PM_plus.config;
using PM_plus.utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PM_plus.service {
    /// <summary>
    /// 事件服务费类
    /// </summary>
    class EventService {
        static readonly ToolTip toolTip = new ToolTip();
        /// <summary>
        /// 鼠标移动到按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void BtnMouseHover(Object sender, EventArgs e) {
            ProjectSections.ProjectSection currentSection = GetCurrentProjectSectionBySender(sender);
            if (null != currentSection) {
                String title = currentSection.Title;
                String port = currentSection.Port;
                // 设置显示样式
                //toolTip.AutoPopDelay = 5000;//提示信息的可见时间
                toolTip.InitialDelay = 200;//事件触发多久后出现提示
                toolTip.ReshowDelay = 0;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
                toolTip.ShowAlways = true;//是否显示提示框
                                          //  设置伴随的对象.
                toolTip.SetToolTip(GetCurrentBtnBySender(sender), title + ":" + port);
            }
        }
        /** 左键双击,打开jar包路径 */
        public static void BtnDoubleClick(Object sender, EventArgs e) {
            // 判断是否双击事件
            bool isDoubleClick = TimerService.IsDoubleClick(sender);
            if (isDoubleClick) {
                ProjectSections.ProjectSection projectSection = GetCurrentProjectSectionBySender(sender);
                if (!FileUtils.Boo_FileExist(projectSection.Jar)) {
                    MessageBox.Show("该jar配置的文件被删除，请重新配置");
                } else {
                    Process.Start("explorer.exe", " /select," + projectSection.Jar);
                }
            }

        }

        /// <summary>
        /// 右键刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void BtnRightFreshClick(Object sender, EventArgs e) {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            String section = (String)menuItem.Tag;
            ProjectSections.ProjectSection projectSection = ProjectSections.GetProjectBySection(section);
            if (null != projectSection) {
                // 刷新bat文件
                FormService.CheckSection(projectSection, true);
                Config.mainForm.OperateMsg_Label.Text = "刷新成功";
                Config.mainForm.OperateMsg_Label.ForeColor = Color.Green;
                Config.mainForm.InitLabelMsgTimerout();
            } else {
                MessageBox.Show("项目未找到，请重启程序!");
            }
        }

        /**
      * 右键启动
      * */
        public static void BtnRightStartClick(Object sender, EventArgs e) {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            String section = (String)menuItem.Tag;
            // 按钮置为灰，避免重复点击
            menuItem.Enabled = false;
            ProjectSections.ProjectSection projectSection = ProjectSections.GetProjectBySection(section);
            if (null != projectSection && Config.PROJECT_RUN_STAT_SUCCESS != projectSection.RunStat) {
                // 准备启动
                ProjectUtils.projectStart(projectSection);
            } else {
                MessageBox.Show("项目不可重复启动!");
            }
        }
        /**
         * 右键停止
         * */
        public static void BtnRightStopClick(Object sender, EventArgs e) {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Enabled = false;
            String section = (String)menuItem.Tag;
            ProjectSections.ProjectSection projectSection = ProjectSections.GetProjectBySection(section);
            if (null != projectSection) {
                // 停止
                ProjectUtils.projectStop(projectSection);
            }
        }

        /**
        * 右键修改按钮点击事件
        * */
        public static void BtnRightUpdateClick(Object sender, EventArgs e) {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ProjectForm updateForm = new ProjectForm(Config.OPERATE_TYPE_UPDATE) {
                Section = (String)menuItem.Tag
            };
            updateForm.ShowDialog();
        }

        /// <summary>
        /// 右键查看按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void BtnRightDetailClick(Object sender, EventArgs e) {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ProjectForm detailForm = new ProjectForm(Config.OPERATE_TYPE_DETAIL) {
                Section = (String)menuItem.Tag
            };
            detailForm.ShowDialog();
        }
        /// <summary>
        /// 右键删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void BtnRightDeleteClick(Object sender, EventArgs e) {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Enabled = false;
            String section = (String)menuItem.Tag;
            // 移除缓存中的项目信息
            ProjectSections.RemoveProjectBySection(section);
            // 移除panel中的按钮
            FormService.RemoveButton(section);
            // 删除ini文件中的配置信息
            IniUtils.EraseSection(Config.ProjectsIniPath, section);

            MessageBox.Show("删除成功！");
        }


        #region 项目按钮拖动事件
        private static bool down = false;
        public static void Btn_MouseUp(object sender, MouseEventArgs e) {
            down = false;
        }

        public static void Btn_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                down = true;
            }
        }
        public static void Btn_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && down) {
                down = false;
                if (!(sender is Button btn)) {
                    return;
                }
                Config.mainForm.Projects_Panel.DoDragDrop(btn, DragDropEffects.Move);
            }
        }
        #endregion

        /// <summary>
        /// 运行窗口中清除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void RunTab_ClearButtonClick(Object sender, MouseEventArgs e) {
            Button button = (Button)sender;
            String section = (String)button.Tag;
            RichTextBox richTextBox = ControlUtils.GetRichTextBoxControlBySection(section);
            richTextBox.Text = "";
        }

        /// <summary>
        /// 运行窗口中启动按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void RunTab_StartButtonClick(Object sender, MouseEventArgs e) {
            Button button = (Button)sender;
            String section = (String)button.Tag;
            ProjectSections.ProjectSection projectSection = ProjectSections.GetProjectBySection(section);
            if (null != projectSection) {
                // 准备启动
                ProjectUtils.projectStart(projectSection);
            }
        }

        /// <summary>
        /// 运行窗口中终止按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void RunTab_StopButtonClick(Object sender, MouseEventArgs e) {
            Button button = (Button)sender;
            String section = (String)button.Tag;
            ProjectSections.ProjectSection projectSection = ProjectSections.GetProjectBySection(section);
            if (null != projectSection) {
                // 停止
                ProjectUtils.projectStop(projectSection);
            }
        }

        private static ProjectSections.ProjectSection GetCurrentProjectSectionBySender(Object sender) {
            Button currentBtn = GetCurrentBtnBySender(sender);
            String section = currentBtn.Name;
            ProjectSections.ProjectSection currentSection = ProjectSections.GetProjectBySection(section);
            return currentSection;
        }

        private static Button GetCurrentBtnBySender(Object sender) {
            Button currentBtn = (Button)sender;
            return currentBtn;
        }
    }
}
