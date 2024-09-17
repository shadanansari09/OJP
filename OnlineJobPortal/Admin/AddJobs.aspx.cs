using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.Admin
{
    public partial class AddJobs : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["ConnSt"].ConnectionString;
        string query;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            Session["title"] = "Add Job";
            if (!IsPostBack)
            {
                fillData();
            }
        }

        private void fillData()
        {
            if(Request.QueryString["id"] != null)
            {
                conn = new SqlConnection(str);
                query = "SELECT * FROM Jobs WHERE JobId = '" + Request.QueryString["id"] +"'";
                cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtJobTitle.Text = sdr["Title"].ToString();
                        txtVacancies.Text = sdr["Vacancies"].ToString();
                        txtDescription.Text = sdr["Description"].ToString();
                        txtQualification.Text = sdr["Qualification"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtKeySkills.Text = sdr["KeySkills"].ToString();
                        txtDeadline.Text = Convert.ToDateTime(sdr["Deadline"]).ToString("yyyy-MM-dd");
                        txtSalary.Text = sdr["Salary"].ToString();
                        ddlJobType.SelectedValue = sdr["JobType"].ToString();
                        txtCompany.Text = sdr["CompanyName"].ToString();
                        txtWebsite.Text = sdr["Website"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();
                        txtState.Text = sdr["State"].ToString();
                        btnAdd.Text = "Update";
                        backLink.Visible = true;
                        Session["title"] = "Edit Job";
                    }
                }
                else
                {
                    lblMsg.Text = "Job not found!";
                    lblMsg.CssClass = "alert alert-danger";
                }

                sdr.Close();
                conn.Close();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string type, concatQuery, imagePath = string.Empty;
                bool isValidToExecute = false;
                conn = new SqlConnection(str);

                if (Request.QueryString["id"] != null)
                {
                    if (fuCompanyLogo.HasFile)
                    {
                        if (Utils.isValidExtension(fuCompanyLogo.FileName))
                        {
                            concatQuery = "CompanyLogo=@CompanyLogo,";
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
                    query = @"update Jobs set Title=@Title,Vacancies=@Vacancies,Description=@Description,Qualification=@Qualification,
                                           Experience=@Experience,KeySkills=@KeySkills,Deadline=@Deadline,Salary=@Salary,
                                           JobType=@JobType,CompanyName=@CompanyName,"+ concatQuery +@"Website=@Website,
                                           Email=@Email,Address=@Address,Country=@Country,State=@State where JobId=@id";
                    type = "updated";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Vacancies", txtVacancies.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@KeySkills", txtKeySkills.Text.Trim());
                    cmd.Parameters.AddWithValue("@Deadline", txtDeadline.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@State", txtState.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());

                    if (fuCompanyLogo.HasFile)
                    {
                        if (Utils.isValidExtension(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/images/") + obj.ToString() + fuCompanyLogo.FileName);

                            cmd.Parameters.AddWithValue("@CompanyLogo", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Selected file extension is not supported";
                            lblMsg.CssClass = "alert alert-danger";
                        }

                    }

                    else
                    {
                  
                        isValidToExecute = true;
                    }
                }
                else 
                {
                    query = @"INSERT INTO Jobs Values(@Title,@Vacancies,@Description,@Qualification,@Experience,@KeySkills,@Deadline,
                                           @Salary,@JobType,@CompanyName,@CompanyLogo,@Website,@Email,@Address,
                                           @Country,@State,@CreatedOn)";
                    type = "created";
                    DateTime time = DateTime.Now;
                    
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Vacancies", txtVacancies.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@KeySkills", txtKeySkills.Text.Trim());
                    
                    cmd.Parameters.AddWithValue("@Deadline", txtDeadline.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@State", txtState.Text.Trim());
                    cmd.Parameters.AddWithValue("@CreatedOn", time.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (fuCompanyLogo.HasFile)
                    {
                        if (Utils.isValidExtension(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/images/") + obj.ToString() + fuCompanyLogo.FileName);

                            cmd.Parameters.AddWithValue("@CompanyLogo", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Selected file extension is not supported";
                            lblMsg.CssClass = "alert alert-danger";
                        }

                    }

                    else
                    {
                        cmd.Parameters.AddWithValue("@CompanyLogo", imagePath);
                        isValidToExecute = true;
                    }

                   
                }

                if (isValidToExecute)
                {
                    conn.Open();
                    int res = cmd.ExecuteNonQuery();

                    if (res > 0)
                    {
                        lblMsg.Text = "Job " + type + "successfully! <3 UwU";
                        lblMsg.CssClass = "alert alert-success";
                        clear();
                    }
                    else
                    {
                        lblMsg.Text = "failed to" + type + "Job.. </3 T_T";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
            }
            catch (SqlException ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
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

        private void clear()
        {
            txtJobTitle.Text = string.Empty;
            txtVacancies.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtKeySkills.Text = string.Empty;
            txtExperience.Text = string.Empty;
            txtDeadline.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            txtState.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlCountry.ClearSelection();
            ddlJobType.ClearSelection();
        }

        //private bool Utils.isValidExtension(string fileName)
        //{
        //    bool isValid = false;
        //    string[] fileExtensions = { ".jpg", ".png", ".jpeg" };
        //    for (int i = 0; i <= fileExtensions.Length - 1; i++)
        //    {
        //        if (fileName.Contains(fileExtensions[i]))
        //        {
        //            isValid = true;
        //            break;
        //        }
        //    }
        //    return isValid;
        //}
    }
}