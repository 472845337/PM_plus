﻿using PM_plus.config;
using PM_plus.utils;
using System;

namespace PM_plus.service {
    class IniConfigService {
        /// <summary>
        /// 加载系统参数配置，返回加载节点值
        /// </summary>
        /// <param name="progress"></param>
        /// <returns>progress 进度条占用</returns>
        public static void InitSystemConfig() {
            String logFileName = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_LOG, Config.INI_KEY_LOG_FILENAME);
            String logSwitchIni = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_LOG, Config.INI_KEY_LOG_SWITCH);
            String exitAfterCloseIni = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_EXITAFTERCLOSE);
            Config.logFileName = logFileName;

            bool logSwitch = !StringUtils.IsEmpty(logSwitchIni) && Convert.ToBoolean(logSwitchIni);
            Config.logSwitch = logSwitch;
            Config.mainForm.LogSwitch_CheckBox.Checked = Config.logSwitch;

            bool exitAfterClose = !StringUtils.IsEmpty(exitAfterCloseIni) && Convert.ToBoolean(exitAfterCloseIni);
            Config.exitAfterClose = exitAfterClose;
            Config.mainForm.ExitAfterClose_CheckBox.Checked = Config.exitAfterClose;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public static void InitProjectConfig() {
            String profile = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_PROFILE);
            String JDKPath = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_JDKPATH);
            String LogPath = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_LOGPATH);
            // 计时器频率
            String intervalStr = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_INTERVAL);
            // 监控时间
            String timeoutStr = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_TIMEOUT);
            // 计时器频率
            String monitorIntervalStr = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_MONITOR, Config.INI_KEY_MONITOR_SERVER_FREQUENCE);
            if (StringUtils.IsEmpty(intervalStr)) {
                intervalStr = "5000";
                IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_INTERVAL, intervalStr);
            }
            if (StringUtils.IsEmpty(timeoutStr)) {
                timeoutStr = "20";
                IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_TIMEOUT, timeoutStr);
            }
            if (StringUtils.IsEmpty(monitorIntervalStr)) {
                monitorIntervalStr = "0";
                IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_MONITOR, Config.INI_KEY_MONITOR_SERVER_FREQUENCE, monitorIntervalStr);
            }
            // 监控器开
            Config.interval = Convert.ToInt32(intervalStr);
            // http调用时的超时时间（单位秒，httputils已乘1000）
            Config.timeout = Convert.ToInt32(timeoutStr);
            // 服务监控
            Config.monitorServerInterval = Convert.ToInt32(monitorIntervalStr);
            Config.mainForm.MonitorFreqComboBox.Text = monitorIntervalStr;


            Config.mainForm.Profile_TextBox.Text = profile;
            ProjectUtils.profile = profile;
            Config.mainForm.JDKPath_TextBox.Text = JDKPath;
            ProjectUtils.jdkPath = JDKPath;
            Config.mainForm.LogPath_TextBox.Text = LogPath;
            ProjectUtils.logPath = LogPath;
            Config.mainForm.MemoryTotalTextBox.Text = (ComputerInfo.GetTotalPhysicalMemory() / 1024.0 / 1024.0 / 1024.0).ToString("f2") + "GB";
        }
    }
}
