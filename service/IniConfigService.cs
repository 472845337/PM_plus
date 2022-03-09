using PM_plus.config;
using PM_plus.utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PM_plus.service
{
    class IniConfigService
    {
        /// <summary>
        /// 加载系统参数配置，返回加载节点值
        /// </summary>
        /// <param name="progress"></param>
        /// <returns>progress 进度条占用</returns>
        public static int initSystemConfig(int usedProgress, int giveProgress)
        {
            String logFileName = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_LOG, Config.INI_KEY_LOG_FILENAME);
            String logSwitchIni = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_LOG, Config.INI_KEY_LOG_SWITCH);
            String exitAfterCloseIni = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_EXITAFTERCLOSE);
            Config.logFileName = logFileName;

            bool logSwitch = StringUtils.isEmpty(logSwitchIni) ? false : Convert.ToBoolean(logSwitchIni);
            Config.logSwitch = logSwitch;
            Config.mainForm.LogSwitch_CheckBox.Checked = Config.logSwitch;

            bool exitAfterClose = StringUtils.isEmpty(exitAfterCloseIni) ? false : Convert.ToBoolean(exitAfterCloseIni);
            Config.exitAfterClose = exitAfterClose;
            Config.mainForm.ExitAfterClose_CheckBox.Checked = Config.exitAfterClose;


            Config.waitForm.freshProgress(usedProgress + giveProgress);
            Thread.Sleep(200);
            return usedProgress + giveProgress;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public static int initProjectConfig(int usedProgress, int giveProgress)
        {
            String profile = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_PROFILE);
            Config.waitForm.freshProgress(usedProgress + (giveProgress / 5) * 1);
            Thread.Sleep(100);
            String JDKPath = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_JDKPATH);
            Config.waitForm.freshProgress(usedProgress + (giveProgress / 5) * 2);
            Thread.Sleep(100);
            // 计时器频率
            String intervalStr = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_INTERVAL);
            Config.waitForm.freshProgress(usedProgress + (giveProgress / 5) * 3);
            Thread.Sleep(100);
            // 请求超时时间
            String timeoutStr = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_TIMEOUT);
            Config.waitForm.freshProgress(usedProgress + (giveProgress / 5) * 4);
            Thread.Sleep(100);
            if (StringUtils.isEmpty(intervalStr))
            {
                intervalStr = "5000";
                IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_INTERVAL, intervalStr);
            }
            if (StringUtils.isEmpty(timeoutStr))
            {
                timeoutStr = "20";
                IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_TIMEOUT, timeoutStr);
            }

            // 监控器开
            Config.interval = Convert.ToInt32(intervalStr);
            // http调用时的超时时间（单位秒，httputils已乘1000）
            Config.timeout = Convert.ToInt32(timeoutStr);



            Config.waitForm.freshProgress(usedProgress + giveProgress);
            Thread.Sleep(100);

            Config.mainForm.Profile_ComboBox.Text = profile;
            ProjectUtils.profile = profile;
            Config.mainForm.JDKPath_TextBox.Text = JDKPath;
            ProjectUtils.jdkPath = JDKPath;
            return usedProgress+giveProgress;
        }
    }
}
