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
    public partial class AllUnassignedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)


                if (Session["Coordinator_Id"] != null)
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

                    cliJob.Visible = false;
                    newJob.Visible = false;

                    assignedJobs.Visible = true;
                    rejectedJobs.Visible = true;
                    completedJobs.Visible = true;

                    conJobs.Visible = false;
                    acceptedJobs.Visible = false;
                    RefreshGrid();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
        }

        protected void gvUnassignedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        private void RefreshGrid()
        {
            UnassignedJobs AllUnassignedJobs = new UnassignedJobs();
            gvUnassignedJobs.DataSource = AllUnassignedJobs.AllUnassignedJobs();
            gvUnassignedJobs.DataBind();
        }
    }
}