using PM_plus.config;
using PM_plus.utils;
using System;
using System.Windows.Forms;

namespace PM_plus.service {
    class TimerService {
        /** 强制GC API函数**/
        [System.Runtime.InteropServices.DllImport("kernel32")]
        public static extern Int32 SetProcessWorkingSetSize(IntPtr process, Int32 minSize, Int32 maxSize);
        // 不能使用窗体中的timer控件，要使用线程timer
        private static readonly System.Timers.Timer GcTimer = new System.Timers.Timer();
        private static readonly System.Timers.Timer MonitorTimer = new System.Timers.Timer();
        private static readonly System.Timers.Timer BtnDoubleCheckTimer = new System.Timers.Timer(500);

        static TimerService() {
            // 双击计时器不开启
            BtnDoubleCheckTimer.Enabled = false;
            BtnDoubleCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(BtnDoubleCheckTimer_Tick);
        }
        internal static void AutoGc() {
            GcTimer.Interval = 20000;
            GcTimer.Enabled = true;
            // 给时间控件绑定事件
            GcTimer.Elapsed += new System.Timers.ElapsedEventHandler(GCTimer_Tick);
            GcTimer.AutoReset = true;
        }

        internal static void Monitor() {
            MonitorTimer.Interval = Config.interval;
            MonitorTimer.Enabled = true;
            MonitorTimer.Elapsed += new System.Timers.ElapsedEventHandler(MonitorTimer_Tick);
            MonitorTimer.AutoReset = true;
        }


        static Object preSender;
        /// <summary>
        /// 是否双击的判断
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        internal static bool IsDoubleClick(Object sender) {
            bool isDoubleClick = false;
            if (BtnDoubleCheckTimer.Enabled == false) {
                BtnDoubleCheckTimer.Enabled = true;
                preSender = sender;
            } else {
                if (sender.Equals(preSender)) {
                    preSender = null;
                    // 判断为点击的同一个控件
                    isDoubleClick = true;
                }
            }

            return isDoubleClick;
        }

        /// <summary>
        /// 双击计时器
        /// 将第一次单击的实体清空，将自身置为不运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnDoubleCheckTimer_Tick(object sender, EventArgs e) {
            preSender = null;
            BtnDoubleCheckTimer.Enabled = false;
        }
        /// <summary>
        /// 定时GC任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void GCTimer_Tick(object sender, EventArgs e) {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
                //  配置工作使用空间
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MonitorTimer_Tick(object sender, EventArgs e) {
            if (null != ProjectSections.GetAllSections()) {
                try {
                    foreach (String section in ProjectSections.GetAllSections()) {
                        ProjectSections.ProjectSection projectSection = ProjectSections.GetProjectBySection(section);
                        if (null != projectSection) {
                            String heartBeatUrl = projectSection.HeartBeat;
                            String result = null;
                            if (StringUtils.IsNotEmpty(heartBeatUrl)) {
                                result = HttpUtils.PostRequest(heartBeatUrl, null, null);

                            } else {
                                if (PortUtils.PortInUse(Convert.ToInt16(projectSection.Port))) {
                                    result = "success";
                                }
                            }
                            short runStat = projectSection.RunStat;
                            if ("success".Equals(result)) {
                                projectSection.RunStat = Config.PROJECT_RUN_STAT_SUCCESS;
                                // 变更按钮状态和颜色
                                FormService.UpdateButtonEnabledOfMenuStrip(section, Config.PROJECT_RUN_STAT_SUCCESS);
                            } else {
                                if (projectSection.IsRunning) {
                                    switch (projectSection.RunStat) {
                                        case Config.PROJECT_RUN_STAT_STOPPING:
                                        case Config.PROJECT_RUN_STAT_UNRUN:
                                            // 未运行,停止中
                                            runStat = Config.PROJECT_RUN_STAT_UNRUN;
                                            break;
                                        case Config.PROJECT_RUN_STAT_RUNNING:
                                        case Config.PROJECT_RUN_STAT_SUCCESS:
                                        case Config.PROJECT_RUN_STAT_FAIL:
                                            // 运行中,运行成功,运行失败
                                            runStat = Config.PROJECT_RUN_STAT_FAIL;
                                            break;
                                        default:
                                            break;
                                    }
                                } else {
                                    runStat = Config.PROJECT_RUN_STAT_UNRUN;
                                }
                                projectSection.RunStat = runStat;
                                // 未运行
                                FormService.UpdateButtonEnabledOfMenuStrip(section, runStat);
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
