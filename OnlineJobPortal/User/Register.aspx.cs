using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineJobPortal.User
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["ConnSt"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        } 

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {

                conn = new SqlConnection(str);
                string query = @"Insert into [User] (Username, Password, Name, Address, Contact, Email, Country) values (@Username, @Password, @Name, @Address, @Contact, @Email, @Country)";
                cmd = new SqlCommand(query, conn);
                
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", ConfirmPass.Text.Trim());
                cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Registeration Successful";
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
            catch(SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = $"<b>{txtUserName.Text.Trim()}</b> is already taken";
                    lblMsg.CssClass = "alert alert-warning";
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }

            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            finally { conn.Close(); }
        }

        private void clear()
        {
            txtUserName.Text = string.Empty;
            Password.Text = string.Empty;
            ConfirmPass.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlCountry.ClearSelection();

        }
    }
}