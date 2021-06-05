using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace _6HW
{
    public partial class _6HW : System.Web.UI.Page
    {
        public string s_ConnS = "Data Source=(localdb)\\ProjectsV13;" +
                      "Initial Catalog=Test;" +
                      "Integrated Security=True;" +
                      "Connect Timeout=30;Encrypt=False;" +
                      "TrustServerCertificate=False;" +
                      "ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"+
                      "User ID = sa ; Password = 12345";


        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection o_Conn = new SqlConnection(s_ConnS);
                o_Conn.Open();
                SqlCommand o_Com = new SqlCommand("Select * from Users", o_Conn);
                SqlDataReader o_R = o_Com.ExecuteReader();
                for ( ; o_R.Read(); ){
                    for ( int i_col = 0; i_col < o_R.FieldCount; i_col++)
                    {
                        Response.Write("&nbsp;&nbsp;" + o_R[i_col].ToString());
                    }
                    Response.Write("<br />");
                }
                o_Conn.Close();
                
            }
            catch (Exception o_Exc)
            {
                Response.Write(o_Exc.ToString());
            }

           
           
           
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {
            // Delete from Users where Name = '';
            try
            {
                SqlConnection o_Conn = new SqlConnection(s_ConnS);
                o_Conn.Open();
                SqlCommand o_Com = new SqlCommand("Delete from Users where Name = '"+ tb_Name.Text + "' ", o_Conn);
                o_Com.ExecuteNonQuery();       
                o_Conn.Close();
                Response.Redirect("6HW.aspx");
            }
            catch (Exception o_Exc)
            {
                Response.Write(o_Exc.ToString());
            }
        }
    }
}