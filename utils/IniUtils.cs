using PM_plus.config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

/**
 * INI文件工具类
 * 
 * */
namespace PM_plus.utils
{
    class IniUtils
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        //需要调用GetPrivateProfileString的重载
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern uint GetPrivateProfileStringA(string section, string key, string def, Byte[] retVal, int size, string filePath);

        //类的构造函数，传递INI文件名  
        public static long IniWriteValue(String iniPath, string Section, string Key, string Value)
        {
            // 如果文件不存在，创建文件
            if (!FileUtils.Boo_DirExist(iniPath))
            {
                FileUtils.DirCreate(Path.GetDirectoryName(iniPath));
            }
            return WritePrivateProfileString(Section, Key, Value, iniPath);
        }

        //读取section中某个值  
        public static string IniReadValue(String iniPath, string Section, string Key)
        {
            StringBuilder temp = new StringBuilder();
            long i = GetPrivateProfileString(Section, Key, "", temp, 255, iniPath);
            return temp.ToString();
        }
        // 封装的方法中，最有价值的是获取所有Sections和所有的Keys，网上关于这个的代码大部分是错误的，这里给出一个正确的方法：  
        /// 返回该配置文件中所有Section名称的集合  
        public static List<String> ReadSections(String iniPath)
        {
            byte[] buffer = new byte[65535];
            uint len = GetPrivateProfileStringA(null, null, null, buffer, buffer.Length, iniPath);
            int j = 0;
            List<String> list = new List<String>();
            for (int i = 0; i < len; i++) {
                if (buffer[i] == 0) {
                    list.Add(Encoding.Default.GetString(buffer, j, i - j));
                    j = i + 1;
                }
            }
            list.Sort(delegate (String section1, String section2) {
                String sort1 = IniReadValue(Config.ProjectsIniPath, section1, Config.INI_KEY_PROJECT_SORT);
                String sort2 = IniReadValue(Config.ProjectsIniPath, section2, Config.INI_KEY_PROJECT_SORT);
                if(StringUtils.isNotEmpty(sort1) && StringUtils.isNotEmpty(sort2)) {
                    return Convert.ToInt16(sort1).CompareTo(Convert.ToInt16(sort2));
                } else {
                    if (StringUtils.isEmpty(sort1)) {
                        return 1;
                    } else {
                        return -1;
                    }
                }
                
            });
            return list;
        }

        // 获取节点的所有KEY值  

        public static List<String> ReadKeys(String iniPath, string sectionName)
        {

            byte[] buffer = new byte[5120];
            uint rel = GetPrivateProfileStringA(sectionName, null, Config.BLANK_STR, buffer, buffer.GetUpperBound(0), iniPath);

            int iCnt, iPos;
            List<String> list = new List<String>();
            string tmp;
            if (rel > 0)
            {
                iCnt = 0; iPos = 0;
                for (iCnt = 0; iCnt < rel; iCnt++)
                {
                    if (buffer[iCnt] == 0x00)
                    {
                        tmp = ASCIIEncoding.Default.GetString(buffer, iPos, iCnt - iPos).Trim();
                        iPos = iCnt + 1;
                        if (StringUtils.isNotEmpty(tmp))
                            list.Add(tmp);
                    }
                }
            }
            return list;
        }
        ///   <summary> 
        ///   删除这个项现有的字串。 
        ///   </summary> 
        ///   <param   name= "sectionName "> 要设置的项名或条目名。这个字串不区分大小写。 </param> 
        ///   <param   name= "keyName "> 要删除的项名或条目名。这个字串不区分大小写。 </param> 

        public static void DeleteKey(String iniPath, string sectionName, string keyName)
        {
            WritePrivateProfileString(sectionName, keyName, null, iniPath);
        }

        ///   <summary> 
        ///   删除这个小节的所有设置项。 
        ///   </summary> 
        ///   <param   name= "sectionName "> 要删除的小节名。这个字串不区分大小写。 </param> 

        public static void EraseSection(String iniPath, String section)

        {
            WritePrivateProfileString(section, null, null, iniPath);
        }
    }
}
