using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM_plus.SelfEnum {
    class Table:Attribute {

        public Table(String tableName) {
            this.tableName = tableName;
        }

        public String tableName { get; set; }
    }
}
