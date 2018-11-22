using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace 项目管理系统
{
    class Mysqlhelp
    {
        private static readonly string connStr = "Data Source=10.15.1.252;User ID = root; Password=root;DataBase=zkxj_erp_new";
        public static DataTable GetDataTable1(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlDataAdapter apter = new MySqlDataAdapter(sql, conn))
                {
                    if (pars != null)
                    {
                        apter.SelectCommand.Parameters.AddRange(pars);
                    }
                    apter.SelectCommand.CommandType = type;
                    DataTable da = new DataTable();
                    apter.Fill(da);

                    return da;

                }
            }
        }
        public static object ExecuteScalar1(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
