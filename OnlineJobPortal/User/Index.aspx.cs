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
    public partial class Index : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["ConnSt"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Jobbs();
            }
        }



        private void Jobbs()
        {
            if (dt == null)
            {
                conn = new SqlConnection(str);
                string query = @"Select TOP 3 JobId,Title,CompanyName,CompanyLogo,Address,Country,State,Salary,Description from Jobs";
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();

        }
        protected string GetImageUrl(object url)
        {
            string url1 = "";
            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                url1 = "~/images/No_image.png";
            }
            else
            {
                url1 = string.Format("~/{0}", url);
            }

            return ResolveUrl(url1);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           
        }

        protected void lb101_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {

                Response.Redirect("Login.aspx");
               
            }
            else
            {
                Response.Redirect("FindAJob.aspx");
            }
        }
    }
}