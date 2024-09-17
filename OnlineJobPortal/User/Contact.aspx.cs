using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class Contact : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["ConnSt"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(str);
                string query = @"Insert into Contact values (@Name, @email, @Subject, @Message)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name.Value.Trim());
                cmd.Parameters.AddWithValue("@email", email.Value.Trim());
                cmd.Parameters.AddWithValue("@Subject", subject.Value.Trim());
                cmd.Parameters.AddWithValue("@Message", message.Value.Trim());
                conn.Open();
                int result  = cmd.ExecuteNonQuery();
                if (result > 0) 
                {
                    lblMsg.Visible= true;
                    lblMsg.Text = "Thank You for Your valuable Feedback We will surely look into it";
                    lblMsg.CssClass = "alert alert-success";
                    clear();

                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "haan nikal ab";
                    lblMsg.CssClass = "alert alert-warning";
                }
            }
            catch(Exception ex)
            { 
                Response.Write("<script>alert('" +ex.Message+ "');</script>");
            }
            finally 
            {
                conn.Close(); 
            }
        }

        private void clear()
        {
            name.Value = string.Empty;
            email.Value= string.Empty;
            subject.Value = string.Empty;
            message.Value = string.Empty;
        }
    }
}