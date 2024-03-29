﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PM_plus.config {
    class Config {
        public const String ENTER_STR = "\r\n";
        public const String BLANK_STR = "";

        public const String PATH_CHARACTER = "\\";
        public const String ProjectsIniPath = "ini\\Projects.ini";
        public const String SystemIniPath = "ini\\System.ini";
        public const String BatPath = "bat\\";
        public const String BAT_FILE_TYPE_START = "start";
        public const String BAT_FILE_NAME_START = "_start.bat";
        public const String BAT_FILE_TYPE_STOP = "stop";
        public const String BAT_FILE_NAME_STOP = "_stop.bat";
        public const String LOG_FILE_INFO = "info.log";
        public const String LOG_FILE_ERROR = "error.log";
        public const String DEFAULT_SKIN = "Skins\\Calmness\\Calmness.ssk";
        public const String DEFAULT_FONT_FAMILY = "微软雅黑";
        public const int DEFAULT_FONT_SIZE = 10;
        public const String DEFAULT_FONT_COLOR = "#000000";

        public const String IS_PRINT_LOG_YES = "1";
        public const String IS_PRINT_LOG_NO = "0";

        /** actuator监控的子节点路径 */
        // 关闭应用节点
        public const String ACTUATOR_SHUTDOWN = "shutdown";

        /** 项目运行状态 */
        public const short PROJECT_RUN_STAT_FAIL = -1;
        public const short PROJECT_RUN_STAT_UNRUN = 0;
        public const short PROJECT_RUN_STAT_RUNNING = 1;
        public const short PROJECT_RUN_STAT_SUCCESS = 2;
        public const short PROJECT_RUN_STAT_STOPPING = 3;

        public const short OPERATE_TYPE_ADD = 1;
        public const short OPERATE_TYPE_UPDATE = 2;
        public const short OPERATE_TYPE_DETAIL = 3;

        /** 项目属性INI Key名 */
        public const String INI_SECTION_SYSTEM = "system";
        public const String INI_SECTION_LOG = "log";
        public const String INI_SECTION_MONITOR = "monitor";

        public const String INI_KEY_SYSTEM_FORM_HEIGHT = "height";
        public const String INI_KEY_SYSTEM_FORM_WIDTH = "width";
        public const String INI_KEY_SYSTEM_PROFILE = "profile";
        public const String INI_KEY_SYSTEM_JDKPATH = "JDKPath";
        public const String INI_KEY_SYSTEM_LOGPATH = "LogPath";
        public const String INI_KEY_SYSTEM_INTERVAL = "interval";
        public const String INI_KEY_SYSTEM_TIMEOUT = "timeout";
        public const String INI_KEY_SYSTEM_EXITAFTERCLOSE = "exitAfterClose";
        public const String INI_KEY_SYSTEM_SKIN = "skin";
        public const String INI_KEY_SYSTEM_SKIN_SWITCH = "skin_switch";
        public const String INI_KEY_SYSTEM_FONT_FAMILY = "font_family";
        public const String INI_KEY_SYSTEM_FONT_SIZE = "font_size";
        public const String INI_KEY_SYSTEM_FONT_COLOR = "font_color";
        public const String INI_KEY_SYSTEM_CLICK_ACTIVE = "click_active";

        public const String INI_KEY_LOG_SWITCH = "switch";
        public const String INI_KEY_LOG_FILENAME = "filename";

        public const String INI_KEY_PROJECT_TITLE = "title";
        public const String INI_KEY_PROJECT_JAR = "jar";
        public const String INI_KEY_PROJECT_PORT = "port";
        public const String INI_KEY_PROJECT_PRINT_LOG = "printLog";
        public const String INI_KEY_PROJECT_HEART_BEAT = "heartBeat";
        public const String INI_KEY_PROJECT_ACTUATOR = "actuator";
        public const String INI_KEY_PROJECT_EXT = "ext";
        public const String INI_KEY_PROJECT_PARAM = "param";
        public const String INI_KEY_PROJECT_ENV = "env";
        public const String INI_KEY_PROJECT_SORT = "sort";


        public const String INI_KEY_MONITOR_SERVER_FREQUENCE = "server_freq";

        /** 项目操作类型 */
        public const int PROJECT_OPERATE_TYPE_START = 1;
        public const int PROJECT_OPERATE_TYPE_STOP = 2;
        /// <summary>
        /// 项目窗口相关控件参数
        /// </summary>
        /// 
        #region 右键name和text区
        // 项目面板右键刷新
        public const String PROJECT_PANEL_RIGHT_FRESH_NAME = "ProjectPanel_MouseRightMenu_Fresh";
        public const String PROJECT_PANEL_RIGHT_FRESH_TEXT = "刷新";
        // 项目面板右键添加
        public const String PROJECT_PANEL_RIGHT_ADD_NAME = "ProjectPanel_MouseRightMenu_Add";
        public const String PROJECT_PANEL_RIGHT_ADD_TEXT = "添加";
        public const String PROJECT_PANEL_RIGHT_ADD_IMAGE = "resources\\menu-icon\\add.ico";
        // 项目面板右键全部启动
        public const String PROJECT_PANEL_RIGHT_ALLSTART_NAME = "ProjectPanel_MouseRightMenu_AllStart";
        public const String PROJECT_PANEL_RIGHT_ALLSTART_TEXT = "全部启动";
        // 项目面板右键全部停止
        public const String PROJECT_PANEL_RIGHT_ALLSTOP_NAME = "ProjectPanel_MouseRightMenu_AllStop";
        public const String PROJECT_PANEL_RIGHT_ALLSTOP_TEXT = "全部停止";

        // 项目按钮右键刷新
        public const String RIGHT_BUTTON_FRESH_NAME = "MouseRightMenu_Fresh";
        public const String RIGHT_BUTTON_FRESH_TEXT = "刷新";
        public const String RIGHT_BUTTON_FRESH_IMAGE = "resources\\menu-icon\\fresh.ico";
        // 项目按钮右键查看
        public const String RIGHT_BUTTON_DETAIL_NAME = "MouseRightMenu_Detail";
        public const String RIGHT_BUTTON_DETAIL_TEXT = "查看";
        public const String RIGHT_BUTTON_DETAIL_IMAGE = "resources\\menu-icon\\detail.ico";
        // 项目按钮右键启动
        public const String RIGHT_BUTTON_START_NAME = "MouseRightMenu_Start";
        public const String RIGHT_BUTTON_START_TEXT = "启动";
        public const String RIGHT_BUTTON_START_IMAGE = "resources\\menu-icon\\start.ico";
        // 项目按钮右键停止
        public const String RIGHT_BUTTON_STOP_NAME = "MouseRightMenu_Stop";
        public const String RIGHT_BUTTON_STOP_TEXT = "停止";
        public const String RIGHT_BUTTON_STOP_IMAGE = "resources\\menu-icon\\stop.ico";
        // 项目按钮右键编辑
        public const String RIGHT_BUTTON_UPDATE_NAME = "MouseRightMenu_Update";
        public const String RIGHT_BUTTON_UPDATE_TEXT = "编辑";
        public const String RIGHT_BUTTON_UPDATE_IMAGE = "resources\\menu-icon\\edit.ico";
        // 项目按钮右键删除
        public const String RIGHT_BUTTON_DELETE_NAME = "MouseRightMenu_Delete";
        public const String RIGHT_BUTTON_DELETE_TEXT = "删除";
        public const String RIGHT_BUTTON_DELETE_IMAGE = "resources\\menu-icon\\remove.ico";
        #endregion
        /************** 运行窗口 相关控件参数,尺寸，位置，文本，名称 */
        #region
        // TabPage参数
        public const String RUNTAB_CONTROL_NAME_TABPAGE = "TabPage";
        public static Size RUNTAB_CONTROL_TABPAGE_SIZE = new Size(622, 424);

        // RichTextBox参数
        public const String RUNTAB_CONTROL_NAME_RICHTEXTBOX = "RichTextBox";
        public static Size RUNTAB_CONTROL_RICHTEXTBOX_SIZE = new Size(609, 379);
        public static Point RUNTAB_CONTROL_RICHTEXTBOX_LOCATION = new Point(7, 7);

        // 按钮参数
        public static Size RUNTAB_CONTROL_BUTTON_SIZE = new Size(47, 23);
        // 清除按钮参数
        public const String RUNTAB_CONTROL_NAME_CLEAR_BUTTON_NAME = "ClearButton";
        public const String RUNTAB_CONTROL_NAME_CLEAR_BUTTON_TEXT = "清除";
        public static Point RUNTAB_CONTROL_NAME_CLEAR_BUTTON_LOCATION = new Point(6, 392);
        // 启动按钮参数
        public const String RUNTAB_CONTROL_NAME_START_BUTTON_NAME = "StartButton";
        public const String RUNTAB_CONTROL_NAME_START_BUTTON_TEXT = "启动";
        public static Point RUNTAB_CONTROL_NAME_START_BUTTON_LOCATION = new Point(516, 392);
        // 终止按钮参数
        public const String RUNTAB_CONTROL_NAME_STOP_BUTTON_NAME = "StopButton";
        public const String RUNTAB_CONTROL_NAME_STOP_BUTTON_TEXT = "终止";
        public static Point RUNTAB_CONTROL_NAME_STOP_BUTTON_LOCATION = new Point(569, 392);
        #endregion

        public const String DB_NAME = "data.db";
        public const String DB_PASSWORD = "123456";

        public const String HTTP_TYPE_POST = "Post";
        public const String HTTP_TYPE_GET = "Get";

        public static String logFileName;
        public static String AppPath = System.AppDomain.CurrentDomain.BaseDirectory;

        public static bool logSwitch;
        // 窗体，初始化时会赋值，用于其它窗口或方法中
        public static WaitForm waitForm;
        public static Form1 mainForm;
        // 单位是秒
        public static int interval;
        // 单位是秒
        public static int timeout;
        // 关闭退出
        public static bool exitAfterClose;
        // 控件映射
        public static Dictionary<String, RichTextBox> richTextBoxControlDic = new Dictionary<string, RichTextBox>();

        public static int monitorServerInterval;

        public static bool historyFormShow = false;
    }
}
