using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibraryAss.Models
{
    public class DBManager
    {
        private SqlConnection con;

        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["AssCon"].ToString();
            con = new SqlConnection(constring);
        }

        public int ExecuteNonQuery(string query)
        {
            Connection();
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetDataTable(string query)
        {
            Connection();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}