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

        protected void gvJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Client currClient = new Client();
            currClient.Client_Id = Convert.ToInt32(Session["Client_Id"].ToString());
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvJobs.Rows[rowIndex];
            if (e.CommandName == "Submit")
            {
                // int.tryparse
               string feedback = row.FindControl("feedBackTxt").ToString().Trim();
                currClient.SubmitFeedback(Convert.ToInt32(row.Cells[2].Text), feedback);
                gvJobs.DataSource = currClient.AllJobs().DefaultView;
                gvJobs.DataBind();
            }
        }
    }
}