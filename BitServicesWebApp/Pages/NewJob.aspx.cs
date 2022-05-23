using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitServicesWebApp.Pages
{
    public partial class NewJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Neutral
            LinkButton login = (LinkButton)Master.FindControl("loginLbtn");
            LinkButton logout = (LinkButton)Master.FindControl("logoutLbtn");
            //Client
            LinkButton cliJob = (LinkButton)Master.FindControl("cliJobLbtn");
            LinkButton newJob = (LinkButton)Master.FindControl("newJobLbtn");
            //Coordinator
            LinkButton assignedJobs = (LinkButton)Master.FindControl("asgJobLbtn");
            LinkButton rejectedJobs = (LinkButton)Master.FindControl("rejJobLbtn");
            LinkButton completedJobs = (LinkButton)Master.FindControl("comJobLbtn");
            //Contractor
            LinkButton conJobs = (LinkButton)Master.FindControl("conJobLbtn");
            LinkButton acceptedJobs = (LinkButton)Master.FindControl("accJobLbtn");
            login.Visible = false;
            logout.Visible = true;

            cliJob.Visible = true;
            newJob.Visible = true;

            assignedJobs.Visible = false;
            rejectedJobs.Visible = false;
            completedJobs.Visible = false;

            conJobs.Visible = false;
            acceptedJobs.Visible = false;
        }
    }
}