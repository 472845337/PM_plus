using PM_plus.config;
using System;
using System.IO;
using System.Text;

namespace PM_plus.utils {
    class FileUtils {
        public static String getBatFilePath(String projectTitle, String type) {
            String batTypePath;
            if (Config.BAT_FILE_TYPE_START.Equals(type)) {
                batTypePath = Config.BAT_FILE_NAME_START;
            } else if (Config.BAT_FILE_TYPE_STOP.Equals(type)) {
                batTypePath = Config.BAT_FILE_NAME_STOP;
            } else {
                batTypePath = Config.BLANK_STR;
            }
            return Config.BatPath + projectTitle + batTypePath;
        }
        public static Boolean Boo_DirExist(String DirPath) {
            return Directory.Exists(@DirPath);
        }

        public static Boolean Boo_FileExist(String FilePath) {
            return File.Exists(@FilePath);
        }

        public static void DirCreate(String DirPath) {
            Directory.CreateDirectory(@DirPath);
        }

        public static void FileCreate(String FilePath) {
            System.IO.File.Create(@FilePath);
        }

        public static void createFile(String filePath, String content, Encoding encoding) {
            String directPath = Path.GetDirectoryName(filePath);
            if (!Boo_DirExist(directPath)) {
                DirCreate(directPath);
            }
            if (null == encoding) {
                // 默认utf8
                encoding = Encoding.UTF8;
            }
            File.WriteAllText(filePath, content, encoding);
        }

        internal static void deleteFile(string filePath) {
            File.Delete(filePath);
        }
    }
}
