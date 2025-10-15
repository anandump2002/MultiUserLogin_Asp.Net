using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TwoLayerMultiUser
{   
    public class ConnectionCLS
    {
        SqlConnection con;
        SqlCommand cmd;
        public ConnectionCLS()
        {
            con = new SqlConnection(@"server=LAPTOP-BK55BJ9U\SQLEXPRESS;database=TwoThreeLayerDB;Integrated Security=true");
        }
        public int Fn_Non_Query(string sql) // insert,delete,update
        {
            cmd = new SqlCommand(sql, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string Fn_scalar(string sql) // SCALAR Fns 
        {
            cmd = new SqlCommand(sql, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }
    }
}