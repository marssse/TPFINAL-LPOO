using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace ClaseBase
{
    public class DatabaseHelper
    {
        private static string connectionString = ClaseBase.Properties.Settings.Default.prestamosConnectionString;

        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            int affectedRows = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                affectedRows = cmd.ExecuteNonQuery();
            }
            return affectedRows;
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                result = cmd.ExecuteScalar();
            }
            return result;
        }
    }
}
