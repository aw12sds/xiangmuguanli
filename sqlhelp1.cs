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
    class sqlhelp1
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["mysqlserver"].ConnectionString;
        public static DataTable GetDataTable(string sql, CommandType type, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlDataAdapter apter = new SqlDataAdapter(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            apter.SelectCommand.Parameters.AddRange(pars);
            //        }
            //        apter.SelectCommand.CommandType = type;
            //        DataTable da = new DataTable();
            //        apter.Fill(da);

            //        return da;

            //    }
            //}
            return getData.getdata(sql, "db_ShengChanBu");
        }

        public static int ExecuteNonquery(string sql, CommandType type, byte[] files, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        //if (pars != null)
            //        //{
            //        //    cmd.Parameters.AddRange(pars);
            //        //}
            //        conn.Open();
            //        cmd.Parameters.Clear();

            //        cmd.Parameters.Add("@pic", SqlDbType.VarBinary).Value = files;
            //        return cmd.ExecuteNonQuery();

            //    }
            //}
            return getData.ExecuteNonquery(sql, "db_ShengChanBu", files);
        }
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            cmd.Parameters.AddRange(pars);
            //        }
            //        cmd.CommandType = type;
            //        conn.Open();
            //        return cmd.ExecuteScalar();
            //    }
            //}
            return getData.ExecuteScalar(sql, "db_ShengChanBu");
        }
        public static int innn(string sql, CommandType type, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            cmd.Parameters.AddRange(pars);
            //        }
            //        cmd.CommandType = type;
            //        conn.Open();
            //        return cmd.ExecuteNonQuery();
            //    }
            //}
            return getData.innn(sql, "db_ShengChanBu");
        }
        public static byte[] duqu(string sql, CommandType type, params SqlParameter[] pars)
        {

            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            cmd.Parameters.AddRange(pars);
            //        }
            //        cmd.CommandType = type;
            //        conn.Open();
            //        SqlDataReader dr = cmd.ExecuteReader();
            //        byte[] mybuffer = null;
            //        while (dr.Read())
            //        {
            //            mybuffer = (byte[])dr.GetValue(0);

            //        }
            //        return mybuffer;

            //    }
            //}
            byte[] bt = getData.duqu(sql, "db_ShengChanBu");
            return bt;
        }
    }

}
