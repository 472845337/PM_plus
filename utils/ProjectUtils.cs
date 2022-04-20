using PM_plus.config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace PM_plus.utils {
    class ProjectUtils {
        public static String profile;
        public static String jdkPath;
        public static String logPath;
        /** 项目启动
         * 
         * */
        public static void ProjectStart(ProjectSections.ProjectSection projectSection) {
            // 置为启动中状态
            projectSection.RunStat = Config.PROJECT_RUN_STAT_RUNNING;
            projectSection.IsRunning = true;
            // 运行启动脚本
            Process.Start(FileUtils.GetBatFilePath(projectSection.Title, Config.BAT_FILE_TYPE_START));
        }

        /**
        * 创建杀进程的脚本文件
        * 
        * */
        public static String CreateStartBat(ProjectSections.ProjectSection projectSection, String LogFileName, String ErrorLogFileName) {
            String result = bool.TrueString;
            if (null == profile || "".Equals(profile)) {
                return "运行环境未配置或未保存！";
            }
            if (null == jdkPath || "".Equals(jdkPath)) {
                return "JDK未配置或未保存！";
            }
            if (!FileUtils.Boo_DirExist(jdkPath)) {
                return "JDK路径不存在，请重新配置！";
            }
            StringBuilder script = new StringBuilder();
            script.Append("@echo off").Append(Config.ENTER_STR);
            script.Append("title ").Append(projectSection.Title).Append(Config.ENTER_STR);
            // jdk路径
            Boolean JDKPathIsExist = FileUtils.Boo_DirExist(jdkPath);
            if (JDKPathIsExist) {
                script.Append("\"").Append(jdkPath).Append("\\bin\\java.exe\"");
            } else {
                script.Append("java");
            }
            // 参数
            if (StringUtils.IsNotEmpty(projectSection.Param)) {
                script.Append(" ").Append(projectSection.Param);
            }
            // jar包路径
            script.Append(" -jar ").Append(projectSection.Jar);
            // profile配置
            script.Append(" --spring.profiles.active=").Append(profile);
            // 指定启动端口
            script.Append(" --server.port=").Append(projectSection.Port);
            // 是否将运行日志输出，配置文件后，日志将不会在console中输出
            if (!projectSection.IsPrintLog && StringUtils.IsNotEmpty(logPath) && StringUtils.IsNotEmpty(LogFileName)) {
                String projectLogPath = (logPath.EndsWith(Config.PATH_CHARACTER) ? logPath : logPath + Config.PATH_CHARACTER) + projectSection.Title + Config.PATH_CHARACTER;
                Boolean DirIsExist = FileUtils.Boo_DirExist(projectLogPath);
                if (!DirIsExist) {
                    FileUtils.DirCreate(projectLogPath);
                }
                // 日志文件
                script.Append(" > ").Append(projectLogPath).Append(LogFileName);
                if (StringUtils.IsNotEmpty(ErrorLogFileName)) {
                    // 异常日志
                    script.Append(" 2>").Append(projectLogPath).Append(ErrorLogFileName);
                }
                script.Append(" &");
            }
            script.Append(Config.ENTER_STR);
            // 窗口不关闭
            script.Append("pause");
            //创建启动bat文件，使用ANSI编码
            // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FileUtils.CreateFile(FileUtils.GetBatFilePath(projectSection.Title, Config.BAT_FILE_TYPE_START), script.ToString(), Encoding.GetEncoding("GB2312"));
            return result;
        }

        /**
         * 应用停止
         * 判断是否配置监控，有配置监控则调用监控下的shutdown节点进行关闭
         * 
         */
        public static void ProjectStop(ProjectSections.ProjectSection projectSection) {
           /* // 定义委托
            StopProjectBySection stopProjectBySection = new StopProjectBySection(StopProjectBySectionImpl);
            stopProjectBySection.Invoke(projectSection);*/

            // 如果项目未配置监控，则调用自动生成的stop.bat脚本结束进程，有配置actuator则调用/shutdown结束进程
            String actuator = projectSection.Actuator;
            if (StringUtils.IsEmpty(actuator)) {
                Process.Start(FileUtils.GetBatFilePath(projectSection.Title, Config.BAT_FILE_TYPE_STOP));
            } else {
                String shutDownUrl = (actuator.EndsWith(Config.PATH_CHARACTER) ? actuator : actuator + Config.PATH_CHARACTER) + Config.ACTUATOR_SHUTDOWN;
                try {
                    // actuator请求要使用post，使用默认的application/json方式请求
                    HttpUtils.postRequest(shutDownUrl, null, null);
                } catch (Exception e) {
                    if (Config.logSwitch) {
                        LogUtils.writeLog(e.StackTrace);
                    }
                    MessageBox.Show("监控节点shutdown无法请求，请重新配置！");
                }

            }
            //停止中状态
            projectSection.RunStat = Config.PROJECT_RUN_STAT_STOPPING;
            projectSection.IsRunning = false;
        }
        /// <summary>
        /// 委托接口
        /// </summary>
        /// <param name="projectSection"></param>
        public delegate void StopProjectBySection(ProjectSections.ProjectSection projectSection);

        /// <summary>
        /// 委托实现
        /// </summary>
        /// <param name="projectSection"></param>
        public static void StopProjectBySectionImpl(ProjectSections.ProjectSection projectSection) {
            // 如果项目未配置监控，则调用自动生成的stop.bat脚本结束进程，有配置actuator则调用/shutdown结束进程
            String actuator = projectSection.Actuator;
            if (StringUtils.IsEmpty(actuator)) {
                Process.Start(FileUtils.GetBatFilePath(projectSection.Title, Config.BAT_FILE_TYPE_STOP));
            } else {
                String shutDownUrl = (actuator.EndsWith(Config.PATH_CHARACTER) ? actuator : actuator + Config.PATH_CHARACTER) + Config.ACTUATOR_SHUTDOWN;
                try {
                    // actuator请求要使用post，使用默认的application/json方式请求
                    HttpUtils.postRequest(shutDownUrl, null, null);
                } catch (Exception e) {
                    if (Config.logSwitch) {
                        LogUtils.writeLog(e.StackTrace);
                    }
                    MessageBox.Show("监控节点shutdown无法请求，请重新配置！");
                }

            }
            //停止中状态
            projectSection.RunStat = Config.PROJECT_RUN_STAT_STOPPING;
            projectSection.IsRunning = false;
        }

        /**
         * 创建杀进程的脚本文件
         * 
         * */
        public static void CreateStopBat(ProjectSections.ProjectSection projectSection) {
            StringBuilder script = new StringBuilder();
            script.Append("@echo off").Append(Config.ENTER_STR);
            script.Append("setlocal enabledelayedexpansion").Append(Config.ENTER_STR);
            script.Append("for /f \"tokens=1-5\" %%a in ('netstat -ano ^| find \":").Append(projectSection.Port).Append("\"') do (").Append(Config.ENTER_STR);
            script.Append("    if \"%%e%\" == \"\" (").Append(Config.ENTER_STR);
            script.Append("        set pid=%%d").Append(Config.ENTER_STR);
            script.Append("    ) else (").Append(Config.ENTER_STR);
            script.Append("        set pid=%%e").Append(Config.ENTER_STR);
            script.Append("    )").Append(Config.ENTER_STR);
            script.Append("    echo will kill java progress:!pid!").Append(Config.ENTER_STR);
            script.Append("    taskkill -f -pid !pid!").Append(Config.ENTER_STR);
            script.Append("    echo kill java progress success").Append(Config.ENTER_STR);
            script.Append(")").Append(Config.ENTER_STR);
            // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FileUtils.CreateFile(FileUtils.GetBatFilePath(projectSection.Title, Config.BAT_FILE_TYPE_STOP), script.ToString(), Encoding.GetEncoding("GB2312"));
        }

        public static void RemoveBat(String title) {
            FileUtils.DeleteFile(FileUtils.GetBatFilePath(title, Config.BAT_FILE_TYPE_STOP));
            FileUtils.DeleteFile(FileUtils.GetBatFilePath(title, Config.BAT_FILE_TYPE_START));
        }


        /// <summary>
        /// 项目全部操作函数
        /// 根据type区分启动或停止
        /// </summary>
        /// <param name="type">Config.ProjectOperateTypeStart</param>
        public static void AllProjectOperate(int type) {
            Dictionary<String, ProjectSections.ProjectSection> sectionList = ProjectSections.GetAllSectionDic();
            if (null == sectionList || 0 == sectionList.Count) {
                MessageBox.Show("项目配置为空，请先添加项目", "提示");
                return;
            }
            String operateMsg = Config.BLANK_STR;
            if (Config.PROJECT_OPERATE_TYPE_START == type) {
                // 启动
                operateMsg = "确认全部启动吗?";
            } else if (Config.PROJECT_OPERATE_TYPE_STOP == type) {
                // 停止
                operateMsg = "确认全部停止吗?";
            }
            if (MessageBox.Show(operateMsg, "信息", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                //点确定后的逻辑
                foreach (KeyValuePair<String, ProjectSections.ProjectSection> sectionMap in sectionList) {
                    ProjectSections.ProjectSection section = sectionMap.Value;

                    if (Config.PROJECT_OPERATE_TYPE_START == type && (Config.PROJECT_RUN_STAT_UNRUN == section.RunStat || Config.PROJECT_RUN_STAT_FAIL == section.RunStat)) {
                        // 项目状态为未运行或运行失败才可运行
                        ProjectStart(section);
                    } else if (Config.PROJECT_OPERATE_TYPE_STOP == type && Config.PROJECT_RUN_STAT_SUCCESS == section.RunStat) {
                        // 项目状态必须为运行中
                        ProjectStop(section);
                    }
                }
            }
        }
    }
}
