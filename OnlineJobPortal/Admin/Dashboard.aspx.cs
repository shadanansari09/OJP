using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlDataAdapter sda;
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
                Users();
                Jobs();
                AppliedJobs();
                ContactCount();
            }
        }

        private void Users()
        {
            conn = new SqlConnection(str);
            sda = new SqlDataAdapter("Select Count(*) from [User]", conn);
            dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["Users"] = dt.Rows[0][0];
            }
            else
            {
                Session["Users"] = 0;
            }
        }

        private void Jobs()
        {
            conn = new SqlConnection(str);
            sda = new SqlDataAdapter("Select Count(*) from Jobs", conn);
            dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["Jobs"] = dt.Rows[0][0];
            }
            else
            {
                Session["Jobs"] = 0;
            }
        }

        private void AppliedJobs()
        {
            conn = new SqlConnection(str);
            sda = new SqlDataAdapter("Select Count(*) from Applications", conn);
            dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["Applications"] = dt.Rows[0][0];
            }
            else
            {
                Session["Applications"] = 0;
            }
        }

        private void ContactCount()
        {
            conn = new SqlConnection(str);
            sda = new SqlDataAdapter("Select Count(*) from Contact", conn);
            dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                Session["Contact"] = dt.Rows[0][0];
            }
            else
            {
                Session["Contact"] = 0;
            }
        }
    }
}