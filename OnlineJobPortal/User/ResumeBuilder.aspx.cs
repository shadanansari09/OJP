using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class ResumeBuilder : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader sdr;
        string str = ConfigurationManager.ConnectionStrings["ConnSt"].ConnectionString;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    showUserInfo();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void showUserInfo()
        {
            try
            {
                conn = new SqlConnection(str);
                string query = "Select * from [User] where UserId=@userId";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", Request.QueryString["id"]);
                conn.Open();
                sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtUserName.Text = sdr["Username"].ToString();
                        txtFullName.Text = sdr["Name"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtContact.Text = sdr["Contact"].ToString();
                        txtTenth.Text = sdr["XGrade"].ToString();
                        txtTwelfth.Text = sdr["XIIGrade"].ToString();
                        txtUG.Text = sdr["UGGrade"].ToString();
                        txtPG.Text = sdr["PGGrade"].ToString();
                        txtPhd.Text = sdr["Phd"].ToString();
                        txtWork.Text = sdr["WorksOn"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "404! User not Found";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string concatQuery = string.Empty;
                    string filePath = string.Empty;
                    // bool isValidToExecute = false;
                    bool isValid = false;
                    conn = new SqlConnection(str);

                    if (fuResume.HasFile)
                    {
                        if (Utils.isValidResumeExtension(fuResume.FileName))
                        {
                            concatQuery = "Resume=@resume,";
                            isValid = true;
                        }
                        else
                        {
                            concatQuery = string.Empty;
                        }
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }

                    query = @"Update [User] set Username=@Username,Name=@Name,Email=@Email,Contact=@Contact,
                                XGrade=@Xgrade,XIIGrade=@XIIGrade,UGGrade=@UGGrade,PGGrade=@PGGrade,Phd=@Phd,
                                WorksOn=@WorksOn,Experience=@Experience," + concatQuery + "Address=@Address,Country=@Country where UserId=@userId";

                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@Xgrade", txtTenth.Text.Trim());
                    cmd.Parameters.AddWithValue("@XIIGrade", txtTwelfth.Text.Trim());
                    cmd.Parameters.AddWithValue("@UGGrade", txtUG.Text.Trim());
                    cmd.Parameters.AddWithValue("@PGGrade", txtPG.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phd", txtPhd.Text.Trim());
                    cmd.Parameters.AddWithValue("@WorksOn", txtWork.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@userId", Request.QueryString["id"]);
                    if (fuResume.HasFile)
                    {
                        if (Utils.isValidResumeExtension(fuResume.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            filePath = "Resumes/" + obj.ToString() + fuResume.FileName;
                            fuResume.PostedFile.SaveAs(Server.MapPath("~/Resumes/") + obj.ToString() + fuResume.FileName);
                            cmd.Parameters.AddWithValue("@resume", filePath);
                            isValid = true;
                           
                        }
                        else
                        {
                            concatQuery = string.Empty;
                            lblMsg.Visible = true;
                            lblMsg.Text = "Please Select a Valid Resume file";
                            lblMsg.CssClass = "alert alert-danger";
                        }

                    }
                    else
                    {
                        isValid = true;
                    }

                    if (isValid)
                    {
                        conn.Open();
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Resume details updated successfully";
                            lblMsg.CssClass = "alert alert-success";

                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Couldn't Update Details...pls try again later";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }

                }

                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cannot update, <b>try loging-in again</b>";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (SqlException ex)
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