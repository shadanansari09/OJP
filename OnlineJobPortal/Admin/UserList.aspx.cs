using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["ConnSt"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!IsPostBack)
            {
                DisplayUser();
            }
        }
        private void DisplayUser()
        {
            string query = string.Empty;
            conn = new SqlConnection(str);
            query = @"SELECT Row_Number() over(Order by (Select 1)) as [Sr.No], UserId, Name, Email, Contact, Country From [User]";
            cmd = new SqlCommand(query, conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            dt = new DataTable();

            dataAdapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DisplayUser();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

                conn = new SqlConnection(str);

                cmd = new SqlCommand("DELETE FROM [User] WHERE UserId = @id", conn);
                cmd.Parameters.AddWithValue("id", userid);

                conn.Open();

                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    lblMsg.Text = "Account Successfully Removed";
                    lblMsg.CssClass = "alert alert-success";
                }
                else
                {
                    lblMsg.Text = "Account couldn't be removed right now..try again later";
                    lblMsg.CssClass = "alert alet-danger";
                }
                
                GridView1.EditIndex = -1;
                DisplayUser();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}