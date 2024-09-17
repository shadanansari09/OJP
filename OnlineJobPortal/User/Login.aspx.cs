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
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        string str = ConfigurationManager.ConnectionStrings["ConnSt"].ConnectionString;
        string username, password = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try 
            {
                if(ddlLogin.SelectedValue == "Admin")
                {
                    username = ConfigurationManager.AppSettings["username"];
                    password = ConfigurationManager.AppSettings["password"];
                    if (username == txtUserName.Text.Trim() && password == LoginPassword.Text.Trim())
                    {
                        Session["admin"] = username;
                        Response.Redirect("../Admin/Dashboard.aspx", false);
                    }
                    else
                    {
                        showError("Admin");
                    }
                }
                else
                {
                    conn = new SqlConnection(str);
                    string query = @"Select * from [User] Where Username = @Username And Password = @Password";
                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", LoginPassword.Text.Trim());
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["user"] = reader["Username"].ToString();
                        Session["userId"] = reader["userId"].ToString();
                        Response.Redirect("Index.aspx", false);
                    }
                    else
                    {
                        showError("User");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                conn.Close();
            }
        }

        private void showError(string userType)
        {
            lblMsg.Visible = true;
            lblMsg.Text = $"<b>{userType}</b> credentials are incorrect";
            lblMsg.CssClass = "alert alert-danger";
        }
    }
}