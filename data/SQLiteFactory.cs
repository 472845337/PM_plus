﻿using PM_plus.utils;
using System;
using System.Collections.Generic;

namespace PM_plus.data {
    class SQLiteFactory {
        private static readonly Dictionary<String, SQLiteHelper> SQLiteHelperDic = new Dictionary<string, SQLiteHelper>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName">数据库名，在当前运行位置生成dbName，示例："/database.db"</param>
        /// <param name="password">数据库密码</param>
        /// <returns></returns>
        public static SQLiteHelper GetSQLiteHelper(String dbName, String password) {
            if (SQLiteHelperDic.ContainsKey(dbName)) {
                // 存在该库，直接返回库工具类
                return SQLiteHelperDic[dbName];
            } else {
                // 没有该库，创建库并打开库
                SQLiteHelper sqliteHeper = StringUtils.IsEmpty(password) ? new SQLiteHelper(dbName) : new SQLiteHelper(dbName, password);
                sqliteHeper.Open();
                SQLiteHelperDic.Add(dbName, sqliteHeper);
                return sqliteHeper;
            }

        }

        public static void CloseAllSQLite() {
            foreach (KeyValuePair<String, SQLiteHelper> pair in SQLiteHelperDic) {
                pair.Value.Close();
            }
        }
    }
}
