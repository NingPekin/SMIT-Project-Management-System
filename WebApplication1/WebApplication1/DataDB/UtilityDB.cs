using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WebApplication1.DataDB
{
    public class UtilityDB
    {
        public static SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myDatabase"].ToString();
            return conn;

        }
        public static void ConnectDB()
        {
            SqlConnection conn = GetConn();
            conn.Open();
            MessageBox.Show(conn.State.ToString());
        }
    }
}