using PM_plus.SelfEnum;
using System;

namespace PM_plus.pojo {
    /// <summary>
    /// http请求数据对象
    /// </summary>
    /// 
    [Table("http_send")]
    class HttpSendHistory {
        // 主键
        [TableParam(true, "id", "INTEGER")]
        public int? Id { get; set; }
        // 请求地址
        [TableParam("url", "VARCHAR")]
        public String Url { get; set; }
        // 请求类型
        [TableParam("type", "VARCHAR")]
        public String Type { get; set; }
        // 创建时间
        [TableParam("create_time", "VARCHAR")]
        public String CreateTime { get; set; }
        // 最后使用时间
        [TableParam("last_used_time", "VARCHAR")]
        public String LastUsedTime { get; set; }
    }
}
