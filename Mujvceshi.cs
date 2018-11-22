using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace 项目管理系统
{
    class Mujvceshi
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["mujv"].ConnectionString;
      
        public static DataTable GetDataTable(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter apter = new SqlDataAdapter(sql, conn))
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

        public static int ExecuteNonquery(string sql, CommandType type, byte[] files, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //if (pars != null)
                    //{
                    //    cmd.Parameters.AddRange(pars);
                    //}
                    conn.Open();
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@pic", SqlDbType.VarBinary).Value = files;
                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public static int ExecuteNonquerytuzhi(string sql, CommandType type, byte[] tuzhifiles, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //if (pars != null)
                    //{
                    //    cmd.Parameters.AddRange(pars);
                    //}
                    conn.Open();
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@pictuzhi", SqlDbType.VarBinary).Value = tuzhifiles;
                    return cmd.ExecuteNonQuery();

                }
            }
        }
        public static int ExecuteNonquery1(string sql, CommandType type, byte[] files, byte[] tuzhifiles, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //if (pars != null)
                    //{
                    //    cmd.Parameters.AddRange(pars);
                    //}
                    conn.Open();
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@pic", SqlDbType.VarBinary).Value = files;
                    cmd.Parameters.Add("@pictuzhi", SqlDbType.VarBinary).Value = tuzhifiles;
                    return cmd.ExecuteNonQuery();

                }
            }
        }
        public static int ExecuteNonquery2(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //if (pars != null)
                    //{
                    //    cmd.Parameters.AddRange(pars);
                    //}
                    conn.Open();
                    cmd.Parameters.Clear();

                    return cmd.ExecuteNonQuery();

                }
            }
        }
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
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
        public static object ExecuteScalar_db_office(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
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
        public static int innn(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static byte[] duqu(string sql, CommandType type, params SqlParameter[] pars)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    byte[] mybuffer = null;
                    while (dr.Read())
                    {
                        mybuffer = (byte[])dr.GetValue(0);

                    }
                    return mybuffer;

                }
            }

        }
    }
}
