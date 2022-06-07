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
    public partial class ContractorJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

                if (Session["Contractor_Id"] != null)
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

                    assignedJobs.Visible = false;
                    rejectedJobs.Visible = false;
                    completedJobs.Visible = false;

                    conJobs.Visible = true;
                    acceptedJobs.Visible = true;
                    RefreshGrid();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

        }

        protected void gvJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Contractor currContractor = new Contractor();
            currContractor.Contractor_Id = Convert.ToInt32(Session["Contractor_Id"].ToString());
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvJobs.Rows[rowIndex];

            int Job_Id = Convert.ToInt32(row.Cells[2].Text);

            if (e.CommandName == "Accept")
            {

                currContractor.AcceptJob(Job_Id);
            }
            else if (e.CommandName == "Reject")
            {
                currContractor.RejectJob(Job_Id);
            }
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            Contractor currContractor = new Contractor();
            currContractor.Contractor_Id = Convert.ToInt32(Session["Contractor_Id"].ToString());
            gvJobs.DataSource = currContractor.AllAssignedJobs().DefaultView;
            gvJobs.DataBind();
        }
    }
}