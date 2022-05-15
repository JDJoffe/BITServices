using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//add
using BitServicesWebApp.BLL;

namespace BitServicesWebApp.Pages
{
    public partial class ClientJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Client_Id"] != null)
            {               
                LinkButton login = (LinkButton)Master.FindControl("loginLbtn");
                LinkButton newJob = (LinkButton)Master.FindControl("newJobLbtn");
                LinkButton logout = (LinkButton)Master.FindControl("logoutLbtn");
              
                login.Visible = false;
                newJob.Visible = true;
                logout.Visible = true;
                Client currClient = new Client();
                currClient.Client_Id = Convert.ToInt32(Session["Client_Id"].ToString());
                gvJobs.DataSource = currClient.AllJobs().DefaultView;
                gvJobs.DataBind();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}