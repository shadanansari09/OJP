using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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