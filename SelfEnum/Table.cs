using System;

namespace PM_plus.SelfEnum {
    class Table:Attribute {

        public Table(String tableName) {
            this.TableName = tableName;
        }

        public String TableName { get; set; }
    }
}
