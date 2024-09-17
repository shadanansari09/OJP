using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace OnlineJobPortal.Admin
{
    public partial class ViewResume : System.Web.UI.Page
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
                ShowAppliedJob();
            }
        }
        private void ShowAppliedJob()
        {
            string query = string.Empty;
            conn = new SqlConnection(str);
            query = @"SELECT Row_Number() over(Order by (Select 1)) 
                    as [Sr.No],aj.AppliedJobId,j.CompanyName,aj.JobId,j.Title,
                    u.Contact,u.Name, u.Email,u.Resume
                    from Applications aj
                    Inner Join [User] u on aj.UserId = u.UserId
                    Inner Join Jobs j on aj.JobId = j.JobId";
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
            ShowAppliedJob();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int appliedjobId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

                conn = new SqlConnection(str);

                cmd = new SqlCommand("DELETE FROM Applications WHERE AppliedJobId = @id", conn);
                cmd.Parameters.AddWithValue("id", appliedjobId);

                conn.Open();

                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    lblMsg.Text = "resume Successfully deleted";
                    lblMsg.CssClass = "alert alert-success";
                }
                else
                {
                    lblMsg.Text = "Job couldn't be deleted right now..try again later";
                    lblMsg.CssClass = "alert alet-danger";
                }
                
                GridView1.EditIndex = -1;
                ShowAppliedJob();
            }
            catch (Exception ex)
            {

                
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                conn.Close() ;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1,"Select$"+ e.Row.RowIndex);
            e.Row.ToolTip = "Click to view job details";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(GridViewRow row in GridView1.Rows)
            {
                if(row.RowIndex == GridView1.SelectedIndex)
                {
                    HiddenField jobId = (HiddenField)row.FindControl("hdnJobId");
                    Response.Redirect("JobList.aspx?id=" + jobId.Value);
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row";
                }
            }
        }
    }
}