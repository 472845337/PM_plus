using PM_plus.config;
using PM_plus.service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PM_plus.utils {
    class ProjectUtils {
        public static String profile;
        public static String jdkPath;
        /** 项目启动
         * 
         * */
        public static void projectStart(ProjectSections.ProjectSection projectSection) {
            // 置为启动中状态
            projectSection.runStat = Config.PROJECT_RUN_STAT_RUNNING;
            projectSection.isRunning = true;
            // 运行启动脚本
            Process.Start(FileUtils.getBatFilePath(projectSection.title, Config.BAT_FILE_TYPE_START));
        }

        /**
         * 创建杀进程的脚本文件
         * 
         * */
        public static void createStartBat(ProjectSections.ProjectSection projectSection, String LogFilePath, String LogFileName, String ErrorLogFileName) {
            if (null == profile || "".Equals(profile)) {
                MessageBox.Show("运行环境未配置或未保存！");
                return;
            }
            if (null == jdkPath || "".Equals(jdkPath)) {
                MessageBox.Show("JDK未配置或未保存！");
                return;
            }
            if (!FileUtils.Boo_DirExist(jdkPath)) {
                MessageBox.Show("JDK路径不存在，请重新配置！");
                return;
            }
            StringBuilder script = new StringBuilder();
            script.Append("@echo off").Append(Config.ENTER_STR);
            script.Append("title ").Append(projectSection.title).Append(Config.ENTER_STR);
            // jdk路径
            Boolean JDKPathIsExist = FileUtils.Boo_DirExist(jdkPath);
            if (JDKPathIsExist) {
                script.Append("\"").Append(jdkPath).Append("\\bin\\java.exe\"");
            } else {
                script.Append("java");
            }
            // 参数
            if (StringUtils.isNotEmpty(projectSection.param)) {
                script.Append(" ").Append(projectSection.param);
            }
            // jar包路径
            script.Append(" -jar ").Append(projectSection.jar);
            // profile配置
            script.Append(" --spring.profiles.active=").Append(profile);
            // 指定启动端口
            script.Append(" --server.port=").Append(projectSection.port);
            // 是否将运行日志输出，配置文件后，日志将不会在console中输出
            if (!projectSection.isPrintLog && StringUtils.isNotEmpty(LogFilePath) && StringUtils.isNotEmpty(LogFileName)) {
                LogFilePath = LogFilePath.EndsWith(Config.PATH_CHARACTER) ? LogFilePath : LogFilePath + Config.PATH_CHARACTER;
                Boolean DirIsExist = FileUtils.Boo_DirExist(LogFilePath);
                if (!DirIsExist) {
                    FileUtils.DirCreate(LogFilePath);
                }
                // 日志文件
                script.Append(" > ").Append(LogFilePath).Append(LogFileName);
                if (StringUtils.isNotEmpty(ErrorLogFileName)) {
                    // 异常日志
                    script.Append(" 2>").Append(LogFilePath).Append(ErrorLogFileName);
                }
                script.Append(" &");
            }
            script.Append(Config.ENTER_STR);
            // 窗口不关闭
            script.Append("pause");
            //创建启动bat文件，使用ANSI编码
            // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FileUtils.createFile(FileUtils.getBatFilePath(projectSection.title, Config.BAT_FILE_TYPE_START), script.ToString(), Encoding.GetEncoding("GB2312"));
        }

        /**
         * 应用停止
         * 判断是否配置监控，有配置监控则调用监控下的shutdown节点进行关闭
         * 
         */
        public static void projectStop(ProjectSections.ProjectSection projectSection) {
           /* // 定义委托
            StopProjectBySection stopProjectBySection = new StopProjectBySection(StopProjectBySectionImpl);
            stopProjectBySection.Invoke(projectSection);*/

            // 如果项目未配置监控，则调用自动生成的stop.bat脚本结束进程，有配置actuator则调用/shutdown结束进程
            String actuator = projectSection.actuator;
            if (StringUtils.isEmpty(actuator)) {
                Process.Start(FileUtils.getBatFilePath(projectSection.title, Config.BAT_FILE_TYPE_STOP));
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
            projectSection.runStat = Config.PROJECT_RUN_STAT_STOPPING;
            projectSection.isRunning = false;
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
            String actuator = projectSection.actuator;
            if (StringUtils.isEmpty(actuator)) {
                Process.Start(FileUtils.getBatFilePath(projectSection.title, Config.BAT_FILE_TYPE_STOP));
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
            projectSection.runStat = Config.PROJECT_RUN_STAT_STOPPING;
            projectSection.isRunning = false;
        }

        /**
         * 创建杀进程的脚本文件
         * 
         * */
        public static void createStopBat(ProjectSections.ProjectSection projectSection) {
            StringBuilder script = new StringBuilder();
            script.Append("@echo off").Append(Config.ENTER_STR);
            script.Append("setlocal enabledelayedexpansion").Append(Config.ENTER_STR);
            script.Append("for /f \"tokens=1-5\" %%a in ('netstat -ano ^| find \":").Append(projectSection.port).Append("\"') do (").Append(Config.ENTER_STR);
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
            FileUtils.createFile(FileUtils.getBatFilePath(projectSection.title, Config.BAT_FILE_TYPE_STOP), script.ToString(), Encoding.GetEncoding("GB2312"));
        }

        public static void removeBat(String title) {
            FileUtils.deleteFile(FileUtils.getBatFilePath(title, Config.BAT_FILE_TYPE_STOP));
            FileUtils.deleteFile(FileUtils.getBatFilePath(title, Config.BAT_FILE_TYPE_START));
        }


        /// <summary>
        /// 项目全部操作函数
        /// 根据type区分启动或停止
        /// </summary>
        /// <param name="type">Config.ProjectOperateTypeStart</param>
        public static void allProjectOperate(int type) {
            Dictionary<String, ProjectSections.ProjectSection> sectionList = ProjectSections.getAllSectionDic();
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

                    if (Config.PROJECT_OPERATE_TYPE_START == type && (Config.PROJECT_RUN_STAT_UNRUN == section.runStat || Config.PROJECT_RUN_STAT_FAIL == section.runStat)) {
                        // 项目状态为未运行或运行失败才可运行
                        projectStart(section);
                    } else if (Config.PROJECT_OPERATE_TYPE_STOP == type && Config.PROJECT_RUN_STAT_SUCCESS == section.runStat) {
                        // 项目状态必须为运行中
                        projectStop(section);
                    }
                }
            }
        }
    }
}
