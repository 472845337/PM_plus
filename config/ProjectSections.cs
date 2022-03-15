using System;
using System.Collections.Generic;

namespace PM_plus.config {
    public class ProjectSections {
        private static List<String> sections;
        private static Dictionary<String, ProjectSection> dictionarys;


        public static void clear() {
            sections = null;
            dictionarys = null;
        }
        public static List<String> getAllSections() {
            return sections;
        }
        public static Dictionary<String, ProjectSection> getAllSectionDic() {
            return dictionarys;
        }

        public static ProjectSection getProjectBySection(String section) {
            if (null == dictionarys) {
                return null;
            } else {
                if (dictionarys.ContainsKey(section)) {
                    return dictionarys[section];
                } else {
                    return null;
                }

            }
        }

        public static void removeProjectBySection(String section) {
            if (null != dictionarys) {
                if (dictionarys.ContainsKey(section)) {
                    dictionarys.Remove(section);
                }
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="section"></param>
        /// <param name="monitor"></param>
        public static void updateProjectSection(String section, ProjectSection projectSection) {
            if (dictionarys == null) {
                dictionarys = new Dictionary<string, ProjectSection>();
                sections = new List<String>();
            }
            bool isExist = dictionarys.ContainsKey(section);
            if (isExist) {
                // 已经存在，修改原数据
                dictionarys[section] = projectSection;
            } else {
                dictionarys.Add(section, projectSection);
                sections.Add(section);
            }
        }
        public class ProjectSection {
            /// <summary>
            /// 项目section
            /// </summary>
            public String section { get; set; }
            /// <summary>
            /// 项目名
            /// </summary>
            public String title { get; set; }
            /// <summary>
            /// 项目jar包路径
            /// </summary>
            public String jar { get; set; }
            /// <summary>
            /// 是否打印日志
            /// </summary>
            public bool isPrintLog { get; set; }
            /// <summary>
            /// 项目启动端口
            /// </summary>
            public String port { get; set; }
            /// <summary>
            /// 心跳监测地址，返回success则为成功
            /// </summary>
            public String heartBeat { get; set; }
            /// <summary>
            /// 是否正在运行
            /// </summary>
            public Boolean isRunning { get; set; }
            /// <summary>
            /// 运行状态，0：未运行，1：启动中，2：启动成功，-1：启动失败
            /// </summary>
            public short runStat { get; set; }
            /// <summary>
            /// 是否配置有spring的actuator地址，存在配置则在停止时调用 shutdown，要该项目开启了shutdown节点
            /// </summary>
            public String actuator { get; set; }

            /// <summary>
            /// 启动参数
            /// </summary>
            public String param { get; set; }
        }
    }
}
