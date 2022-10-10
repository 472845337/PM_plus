using System;
using System.Collections.Generic;

namespace PM_plus.config {
    public class ProjectSections {
        private static List<String> sections;
        private static Dictionary<String, ProjectSection> dictionarys;


        public static void Clear() {
            sections = null;
            dictionarys = null;
        }
        public static List<String> GetAllSections() {
            return sections;
        }
        public static Dictionary<String, ProjectSection> GetAllSectionDic() {
            return dictionarys;
        }

        public static ProjectSection GetProjectBySection(String section) {
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

        public static void RemoveProjectBySection(String section) {
            if (null != dictionarys) {
                if (dictionarys.ContainsKey(section)) {
                    dictionarys.Remove(section);
                }
            }
            if (null != sections) {
                if (sections.Contains(section)) {
                    sections.Remove(section);
                }
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="section"></param>
        /// <param name="monitor"></param>
        public static void UpdateProjectSection(String section, ProjectSection projectSection) {
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
            public string Section { get; set; }
            /// <summary>
            /// 项目名
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// 项目jar包路径
            /// </summary>
            public string Jar { get; set; }
            /// <summary>
            /// 是否打印日志
            /// </summary>
            public bool IsPrintLog { get; set; }
            /// <summary>
            /// 项目启动端口
            /// </summary>
            public string Port { get; set; }
            /// <summary>
            /// 心跳监测地址，返回success则为成功
            /// </summary>
            public string HeartBeat { get; set; }
            /// <summary>
            /// 是否正在运行
            /// </summary>
            public bool IsRunning { get; set; }
            /// <summary>
            /// 运行状态，0：未运行，1：启动中，2：启动成功，-1：启动失败
            /// </summary>
            public short RunStat { get; set; }
            /// <summary>
            /// 是否配置有spring的actuator地址，存在配置则在停止时调用 shutdown，要该项目开启了shutdown节点
            /// </summary>
            public string Actuator { get; set; }

            /// <summary>
            /// 启动参数
            /// </summary>
            public string Param { get; set; }
            /// <summary>
            /// 环境参数
            /// </summary>
            public String Env { get; set; }
        }
    }
}
