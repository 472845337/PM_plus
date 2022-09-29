using PM_plus.SelfEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM_plus.pojo {
    /// <summary>
    /// http请求数据对象
    /// </summary>
    /// 
    [Table("http_send")]
    class HttpSendHistory {
        // 主键
        [TableParam(true, "id", "INTEGER")]
        public int? id { get; set; }
        // 请求地址
        [TableParam("url", "VARCHAR")]
        public String url { get; set; }
        // 请求类型
        [TableParam("type", "VARCHAR")]
        public String type { get; set; }
        // 创建时间
        [TableParam("create_time", "VARCHAR")]
        public String createTime { get; set; }
        // 最后使用时间
        [TableParam("last_used_time", "VARCHAR")]
        public String lastUsedTime { get; set; }
    }
}
