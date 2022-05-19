using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitServicesWebApp.Pages
{
    public partial class RejectedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["InstructorId"] != null)
                {
                    // LinkButton signUp = (LinkButton)Master.FindControl("signUpLbtn");
                    // LinkButton login = (LinkButton)Master.FindControl("loginLbtn");
                    //  LinkButton logout = (LinkButton)Master.FindControl("logoutLbtn");
                    // signUp.Visible = false;
                    // login.Visible = false;
                    //  newBooking.Visible = true;
                    //  logout.Visible = true;
                    //RefreshGrid();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}