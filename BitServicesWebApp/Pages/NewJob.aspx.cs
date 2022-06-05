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
    public partial class NewJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

                if (Session["Client_Id"] != null)
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
                else
                {
                    Response.Redirect("Login.aspx");
                }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            Job newjob = new Job();
            newjob.Client_Id = Convert.ToInt32(Session["Client_Id"].ToString());
            newjob.Street = streetTxt.Text;
            newjob.Suburb = suburbTxt.Text;
            newjob.Postcode = postCodeTxt.Text;
            newjob.Priority = priorityDdl.SelectedValue.Trim();
            newjob.Date = jobDateCal.SelectedDate;
            newjob.Status = "Unassigned";
            newjob.Description = descriptionTxt.Text;
            newjob.InsertJobReq();
        }
    }
}