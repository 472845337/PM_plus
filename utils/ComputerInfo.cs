using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;

namespace PM_plus.utils {
    class ComputerInfo {
        public string ComputerName { get; set; }
        public List<DeviceInfo> RemovableDeviceID { get; set; }
        public string SystemNameInfo { get; set; }
        public string SystemTypeInfo { get; set; }
        public string CupInfo { get; set; }
        public string SystemMemorySizeOfGB { get; set; }
        public string MemoryAvailable { get; set; }

        public static ComputerInfo GetComputerInfo() {
            ComputerInfo computerInfo = new ComputerInfo();
            computerInfo.ComputerName = GetComputerName();
            computerInfo.RemovableDeviceID = GetRemovableDeviceID();
            computerInfo.SystemNameInfo = GetSystemName();
            computerInfo.SystemTypeInfo = GetSystemType();
            computerInfo.CupInfo = GetCPUInfo();
            computerInfo.SystemMemorySizeOfGB = GetSystemMemorySizeOfGB();
            computerInfo.MemoryAvailable = GetMemoryAvailable();
            return computerInfo;
        }
        /// <summary> 
        /// 操作系统的登录用户名 
        /// </summary> 
        /// <returns></returns> 
        public static string GetUserName() {
            try {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc) {
                    st = mo["UserName"].ToString();
                }
                mc = null;
                moc.Dispose();
                return st;
            } catch {
                return "unknow";
            }
        }

        /// <summary> 
        /// PC类型 
        /// </summary> 
        /// <returns></returns> 
        public static string GetSystemType() {
            try {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc) {
                    st = mo["SystemType"].ToString();
                }
                mc = null;
                moc.Dispose();
                return st;
            } catch {
                return "unknow";
            }
        }

        /// <summary> 
        /// 物理内存 
        /// </summary> 
        /// <returns></returns> 
        public static long GetTotalPhysicalMemory() {
            long memorySize = 0L;
            try {
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc) {
                    memorySize = Convert.ToInt64(mo["TotalPhysicalMemory"].ToString());
                }
                mc = null;
                moc.Dispose();
            } catch {
            }
            return memorySize;
        }

        /// <summary> 
        ///  获取计算机名称
        /// </summary> 
        /// <returns></returns> 
        public static string GetComputerName() {
            try {
                return System.Environment.GetEnvironmentVariable("ComputerName");
            } catch {
                return "unknow";
            }
        }

        /// <summary>
        /// 取得设备硬盘的卷标号
        /// </summary>
        /// <returns></returns>
        public static string GetDiskVolumeSerialNumber() {
            try {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObject mo = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
                mo.Get();
                mc = null;
                mo.Dispose();
                return mo.GetPropertyValue("VolumeSerialNumber").ToString();
            } catch (Exception) {
                return "unknow";
            }
        }


        /// <summary>
        /// 获取电脑盘符下的各个的使用情况
        /// </summary>
        /// <returns></returns>
        public static List<DeviceInfo> GetRemovableDeviceID() {
            List<DeviceInfo> deviceList = new List<DeviceInfo>();
            try {
                ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT  *  From  Win32_LogicalDisk ");
                ManagementObjectCollection queryCollection = query.Get();
                foreach (ManagementObject mo in queryCollection) {
                    DeviceInfo deviceInfo = new DeviceInfo();
                    string[] deviceIDFreeSpace = GetHardDiskFreeSpace(mo["DeviceID"].ToString());
                    deviceInfo.DeviceId = mo["DeviceID"].ToString();
                    deviceInfo.TotalSize = deviceIDFreeSpace[0];
                    deviceInfo.FreeSpaceSize = deviceIDFreeSpace[1];
                    deviceList.Add(deviceInfo);
                }
                query = null;
                queryCollection.Dispose();
                
            } catch (Exception e) {
                LogUtils.WriteLog(e.Message);
            }
            return deviceList;
        }

        /// <summary>
        /// 获取磁盘得大小
        /// </summary>
        /// <param name="str_HardDiskName"></param>
        /// <returns></returns>
        private static string[] GetHardDiskFreeSpace(string str_HardDiskName) {
            try {
                string[] hardDisk = new string[2];
                long numTotalSize = 0L;
                long numAvailableFreeSpace = 0L;
                string strTotalSize = "";
                string strAvailableFreeSpace = "";
                str_HardDiskName = str_HardDiskName + @"\";
                foreach (DriveInfo info in DriveInfo.GetDrives()) {
                    if (info.Name.ToUpper() == str_HardDiskName.ToUpper()) {
                        numTotalSize = info.TotalSize;
                        numAvailableFreeSpace = info.AvailableFreeSpace;
                        strTotalSize = numTotalSize/1024/1024/1024+"GB";
                        strAvailableFreeSpace = numAvailableFreeSpace / 1024 / 1024 / 1024 + "GB";
                    }
                }
                hardDisk[0] = strTotalSize;
                hardDisk[1] = strAvailableFreeSpace;
                return hardDisk;
            } catch (Exception) {
                return null;
            }
        }


        /// <summary>
        /// 获取到系统名称
        /// </summary>
        /// <returns>返回当前电脑系统的名称</returns>
        public static string GetSystemName() {
            try {
                string str = null;
                ManagementClass mc = new ManagementClass("Win32_OperatingSystem");
                ManagementObjectCollection mo = mc.GetInstances();
                foreach (ManagementObject m in mo) {
                    str = m["Name"].ToString();
                    break;
                }
                mc = null;
                mo.Dispose();
                return str;
            } catch (Exception) {
                return "unknow";
            }
        }

        /// <summary>
        /// 获取到GPU的名称
        /// </summary>
        /// <returns>返回当前电脑的GPU名称</returns>
        public static string GetGPUName() {
            string str = null;
            ManagementClass manage = new ManagementClass("Win32_VideoController");
            ManagementObjectCollection manageCollection = manage.GetInstances();
            foreach (ManagementObject m in manageCollection) {
                str = m["VideoProcessor"].ToString().Replace("Family", "");
                break;
            }
            manage = null;
            manageCollection.Dispose();
            return str;
        }
        /// <summary>
        /// 获取到CPU的名称
        /// </summary>
        /// <returns>返回当前电脑CPU的名称</returns>
        public static string GetCPUInfo() {
            string str = null;
            ManagementClass mcCPU = new ManagementClass("Win32_Processor");
            ManagementObjectCollection mocCPU = mcCPU.GetInstances();
            foreach (ManagementObject m in mocCPU) {
                str = m["Name"].ToString();
                break;
            }
            mcCPU = null;
            mocCPU.Dispose();
            return str;
        }
        /// <summary>
        /// 获取到系统的内存(GB)
        /// </summary>
        /// <returns>返回当前电脑内存的大小</returns>
        public static string GetSystemMemorySizeOfGB() {
            float size = 0;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher();   //用于查询一些如系统信息的管理对象
            searcher.Query = new SelectQuery("Win32_PhysicalMemory", "", new string[] { "Capacity" });//设置查询条件
            ManagementObjectCollection collection = searcher.Get();   //获取内存容量 
            ManagementObjectCollection.ManagementObjectEnumerator em = collection.GetEnumerator();
            long capacity = 0;
            while (em.MoveNext()) {
                ManagementBaseObject baseObj = em.Current;
                if (baseObj.Properties["Capacity"].Value != null) {
                    capacity += long.Parse(baseObj.Properties["Capacity"].Value.ToString());
                }
            }
            size = (capacity / 1024 / 1024 / 1024);
            em.Dispose();
            return size.ToString() + "G";
        }

        /// <summary>
        /// 获取可用内存
        /// </summary>
        public static string GetMemoryAvailable() {
            try {
                float size = 0;
                long availablebytes = 0;
                ManagementClass mos = new ManagementClass("Win32_OperatingSystem");
                foreach (ManagementObject mo in mos.GetInstances()) {
                    if (mo["FreePhysicalMemory"] != null) {
                        availablebytes = 1024 * long.Parse(mo["FreePhysicalMemory"].ToString());
                    }
                }
                mos.Dispose();
                size = (availablebytes / 1024 / 1024 / 1024);
                return size.ToString() + "G";
            } catch (Exception) {
                return "unknow";
            }
        }
        public class DeviceInfo {
            public string DeviceId { get; set; }
            public string TotalSize { get; set; }
            public string FreeSpaceSize { get; set; }
        }
    }
    
}
