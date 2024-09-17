using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class JobDetails : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataTable dt1, dt2;
        string str = ConfigurationManager.ConnectionStrings["ConnSt"].ConnectionString;
        public string jobTitle = string.Empty;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                showJobDetails();
                DataBind();
            }
            else
            {
                Response.Redirect("FindAJob.aspx");
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void showJobDetails()
        {

            conn = new SqlConnection(str);
            string query = @"Select * from Jobs where JobId = @id";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
            sda = new SqlDataAdapter(cmd);
            dt1 = new DataTable();
            sda.Fill(dt1);

            DataList1.DataSource = dt1;
            DataList1.DataBind();
            jobTitle = dt1.Rows[0]["Title"].ToString();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName == "ApplyJob")
            {
                if (Session["user"] !=null)
                {
                    try
                    {
                        conn = new SqlConnection(str);
                        string query = @"Insert into Applications values (@JobId, @UserId)";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
                        cmd.Parameters.AddWithValue("@UserId", Session["userId"]);
                        conn.Open();
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0 )
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Application Sent Successfully <3";
                            lblMsg.CssClass = "alert alert-success";
                            showJobDetails();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Failed To Send Application </3";
                            lblMsg.CssClass = "alert alert-danger";
                        }
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
                else
                {
                    Response.Write("<script>alert('please Login first');</script>");
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (Session["user"] != null)
            {
                LinkButton btnApplyJob = e.Item.FindControl("lblApplyJob") as LinkButton;

                if (isApplied())
                {
                    btnApplyJob.Enabled = false;
                    btnApplyJob.Text = "Applied";
                }
                else
                {
                    btnApplyJob.Enabled = true;
                    btnApplyJob.Text = "Apply Now";
                }
            }
        }

        bool isApplied()
        {
            conn = new SqlConnection(str);
            string query = @"Select * from Applications where UserId = @UserId and JobId = @JobId";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserId", Session["userId"]);
            cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
            sda = new SqlDataAdapter(cmd);
            dt2 = new DataTable();
            sda.Fill(dt2);
            if(dt2.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Setting default image if there is no image for the job
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
    }
}