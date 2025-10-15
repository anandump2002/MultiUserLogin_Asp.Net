using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TwoLayerMultiUser
{
    public partial class AdminReg : System.Web.UI.Page
    {
        ConnectionCLS obj = new ConnectionCLS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Reg_Id) from Login";
            string maxregid = obj.Fn_scalar(sel);
            int reg_id = 0;
            if(maxregid =="")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(maxregid);
                reg_id = newregid + 1;

            }

            string ins = "insert into Admin values(" + reg_id + ",'" + TextBox1.Text + "' , '" + TextBox2.Text + "',)";
            int i = obj.Fn_Non_Query(ins);
            if(i==1)
            {
                string inslog = "insert into Login values(" + reg_id + ",'" + TextBox3.Text + "' , '" + TextBox4.Text + "','admin','active')";
                int j = obj.Fn_Non_Query(inslog);
                if (i==1&&j == 1)
                {
                    Label5.Text = "Successfully Registered";
                }
            }
            else
            {
                Label5.Text = "Invalid Entry";
            }
        }
        
    }
}