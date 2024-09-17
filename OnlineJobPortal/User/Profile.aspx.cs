using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class Profile : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        string str = ConfigurationManager.ConnectionStrings["ConnSt"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowUserProfile();
            }
        }

        private void ShowUserProfile()
        {
            conn = new SqlConnection(str);
            string query = "Select UserId,Username,Name,Address,Contact,Email,Country,Resume from [User] where Username=@username";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", Session["user"]);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count > 0)
            {
            dlProfile.DataSource = dt;
            dlProfile.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Some error occured, please login again ');</script>");
            }
        }

        protected void dlProfile_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName == "EditUserProfile")
            {
                Response.Redirect("ResumeBuilder.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}