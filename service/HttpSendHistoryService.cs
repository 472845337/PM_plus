using System;
using System.Collections.Generic;
using PM_plus.data;
using System.Reflection;
using PM_plus.SelfEnum;
using System.Data.SQLite;
using PM_plus.pojo;
using PM_plus.utils;
using PM_plus.config;

namespace PM_plus.service {
    /// <summary>
    /// 操作http发送历史数据
    /// </summary>
    class HttpSendHistoryService {

        static SQLiteHelper sqlLiteHelper = null;


        public HttpSendHistoryService() {
            if (null == sqlLiteHelper) {
                sqlLiteHelper = data.SQLiteFactory.GetSQLiteHelper(Config.DB_NAME, Config.DB_PASSWORD);
            }
            InitTable();
        }
        public void InitTable() {
            // 判断表是否存在
            if (!sqlLiteHelper.TableExists(GetTableName())) {
                // 创建表
                CreateTable();
            }
        }
       
        public int SaveData(HttpSendHistory httpSendHistory) {
            // 查询是否存在类似数据
            HttpSendHistory queryModel = new HttpSendHistory {
                Url = httpSendHistory.Url,
                Type = httpSendHistory.Type
            };
            List<HttpSendHistory> list = SelectList(queryModel);
            if (null != list && list.Count > 0) {
                // 存在相同数据
                HttpSendHistory history = list[0];
                history.LastUsedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                return UpdateData(history);
            }else {
                return InsertData(httpSendHistory);
            }
        }

        /// <summary>
        /// 清除所有数据
        /// </summary>
        internal void Clear() {
            // 清空所有的数据
            sqlLiteHelper.ExecuteNonQuery("DELETE FROM "+GetTableName(), null);
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="httpSendHistory"></param>
        /// <returns></returns>
        public int InsertData(HttpSendHistory httpSendHistory) {
            httpSendHistory.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return sqlLiteHelper.InsertData(GetTableName(), GetParams(httpSendHistory));
        }

        /// <summary>
        /// 删除某个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteData(int? id) {
            if(null == id) {
                return 0;
            } else {
                return sqlLiteHelper.ExecuteNonQuery("DELETE FROM " + GetTableName() + " where id=@id", new SQLiteParameter[] { new SQLiteParameter("id", id) });
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="httpSendHistory"></param>
        /// <returns></returns>
        public int UpdateData(HttpSendHistory httpSendHistory) {
            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            SQLiteParameter idParame = new SQLiteParameter("id", httpSendHistory.Id);
            paramList.Add(idParame);
            return sqlLiteHelper.Update(GetTableName(), GetParams(httpSendHistory), "id=@id", paramList.ToArray());
        }

        /// <summary>
        /// 根据对象查询匹配的数据
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<HttpSendHistory> SelectList(HttpSendHistory queryModel) {
            List<HttpSendHistory> list = new List<HttpSendHistory>();
            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            String paramSql = "";
            String whereSql = "";
            String selectSql = "";
            InitSql(queryModel,ref paramSql,ref whereSql,ref paramList);
            selectSql += "SELECT ";
            selectSql += paramSql;
            selectSql += " FROM " + GetTableName();
            if (StringUtils.IsNotEmpty(whereSql)) {
                selectSql += " WHERE ";
                selectSql += whereSql;
            }
            

            SQLiteDataReader reader = sqlLiteHelper.ExecuteReader(selectSql, paramList.ToArray());
            while (reader.Read()) {
                HttpSendHistory httpSendHistory = new HttpSendHistory {
                    Id = Int32.Parse(reader["id"].ToString()),
                    Url = reader["url"].ToString(),
                    Type = reader["type"].ToString(),
                    CreateTime = reader["create_time"].ToString(),
                    LastUsedTime = reader["last_used_time"].ToString()
                };
                list.Add(httpSendHistory);
            }
            return list;
        }

        private void InitSql(HttpSendHistory httpSendHistory,ref String paramSql, ref String whereSql, ref List<SQLiteParameter> paramList) {
            PropertyInfo[] infos = typeof(HttpSendHistory).GetProperties();
            paramList = new List<SQLiteParameter>();
            paramSql = "";
            whereSql = "";
            for (int i = 0; i < infos.Length; i++) {
                PropertyInfo property = infos[i];
                TableParam tableParam = GetAttributeByProperty<TableParam>(property);
                if (null != property.GetValue(httpSendHistory, null)) {
                    whereSql += tableParam.param;
                    whereSql += "=@";
                    whereSql += property.Name;
                    whereSql += " AND ";

                    SQLiteParameter param = new SQLiteParameter(property.Name, property.GetValue(httpSendHistory, null));
                    paramList.Add(param);
                }
                paramSql += tableParam.param;
                if (i < infos.Length - 1) {
                    paramSql += ", ";
                }

            }

            if (whereSql.Contains(" AND ")) {
                // 去掉最后一个and
                whereSql = whereSql.Substring(0, whereSql.LastIndexOf("AND "));
            }
        }

        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="httpSendHistory"></param>
        private void CreateTable() {
            PropertyInfo[] infos = typeof(HttpSendHistory).GetProperties();
            String insertSql = "create table " + GetTableName() + " (";
            for (int i = 0; i < infos.Length; i++) {
                PropertyInfo info = infos[i];
                TableParam tableParam = GetAttributeByProperty<TableParam>(info);
                insertSql += tableParam.param;
                insertSql += " ";
                insertSql += tableParam.type;
                if (tableParam.isKey) {
                    insertSql += " PRIMARY KEY AUTOINCREMENT";
                }
                if (i < infos.Length - 1) {
                    insertSql += ",";
                }
            }
            insertSql += ")";
            sqlLiteHelper.ExecuteNonQuery(insertSql, null);
        }

        private String GetTableName() {
            String tableName;
            object[] tableAttrs = typeof(HttpSendHistory).GetCustomAttributes(typeof(Table), true);
            if (tableAttrs != null && tableAttrs.Length > 0) {
                Table table = (Table)tableAttrs[0];
                tableName = table.TableName;
            } else {
                throw new Exception("HttpSendHistory class not set Table attributes");
            }
            return tableName;
        }

        /// <summary>
        /// 获取属性对应的参数字典项
        ///，自动排除主键属性 比如ID
        ///
        /// 
        /// </summary>
        /// <param name="httpSendHistory"></param>
        /// <returns></returns>
        private Dictionary<string, object> GetParams(HttpSendHistory httpSendHistory) {
            Dictionary<string, object> dict = null;
            if (null != httpSendHistory) {
                dict = new Dictionary<string, object>();
                // 遍历所有的属性
                PropertyInfo[] infos = typeof(HttpSendHistory).GetProperties();
                foreach (PropertyInfo info in infos) {
                    TableParam tableParam = GetAttributeByProperty<TableParam>(info);
                    if (null != tableParam && !tableParam.isKey) {
                        dict.Add(tableParam.param, info.GetValue(httpSendHistory, null));
                    } else {
                        dict.Add(info.Name, info.GetValue(httpSendHistory, null));
                    }
                }
            }
            return dict;
        }

        private T GetAttributeByProperty<T>(PropertyInfo propertyInfo) where T : Attribute {
            object[] attributes = propertyInfo.GetCustomAttributes(typeof(T), true);
            T attribute = null;
            if (attributes != null && attributes.Length > 0) {
                attribute = (T)attributes[0];
            }
            return attribute;
        }
    }
}
