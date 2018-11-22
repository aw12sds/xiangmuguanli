using MySql.Data.MySqlClient;
using NetWork.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace 项目管理系统
{
    class SQLhelp
    {
      
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["default1"].ConnectionString;
        public static DataTable GetDataTable(string sql, CommandType type, params SqlParameter[] pars)
        {          
           return getData.getdata(sql, "db_xiangmuguanli");
        }

        public static int ExecuteNonquery(string sql, CommandType type, byte[] files, params SqlParameter[] pars)
        {        
           return getData.ExecuteNonquery(sql, "db_xiangmuguanli", files);
        }
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {       
            return getData.ExecuteScalar(sql, "db_xiangmuguanli");
        }
        public static int innn(string sql, CommandType type, params SqlParameter[] pars)
        {         
            return getData.innn(sql, "db_xiangmuguanli");
        }
        public static byte[] duqu(string sql, CommandType type, params SqlParameter[] pars)
        {         
            byte[] bt = getData.duqu(sql, "db_xiangmuguanli");
            return bt;

        }

        public static int ExecuteNonqueryShengchan(string sql, CommandType type, params SqlParameter[] pars)
        {
            return getData.innn(sql, "db_ShengChanBu");
        }

        public static object ExecuteScalarShengchan(string sql, CommandType type, params SqlParameter[] pars)
        {

            return getData.ExecuteScalar(sql, "db_ShengChanBu");
        }

        public static DataTable GetDataTableShengchan(string sql, CommandType type, params SqlParameter[] pars)
        {
            return getData.getdata(sql, "db_ShengChanBu");
        }

    }
}
