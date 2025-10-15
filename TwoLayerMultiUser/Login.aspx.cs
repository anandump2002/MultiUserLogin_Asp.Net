using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TwoLayerMultiUser
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectionCLS obj1 = new ConnectionCLS();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count (Reg_Id) from Login where Username ='" + TextBox1.Text + "'and Password ='" + TextBox2.Text + "'";
            string cid = obj1.Fn_scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if(cid1 == 1)
            {
                string str1 = "select Reg_Id from Login where Username ='" + TextBox1.Text + "'and Password ='" + TextBox2.Text + "'";
                string regid = obj1.Fn_scalar(str1);
                Session["userid"] = regid;

                string str2 = "select Log_type from Login where Username ='" + TextBox1.Text + "'and Password ='" + TextBox2.Text + "'";
                string logtype = obj1.Fn_scalar(str2);
                if(logtype == "admin")
                {
                    Response.Redirect("AdminHome.aspx");

                }
                else if(logtype =="user")
                {
                    Response.Redirect("UserHome.aspx");
                }
            }

        }
    }
}