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
                    LinkButton login = (LinkButton)Master.FindControl("loginLbtn");
                    LinkButton acceptedJobs = (LinkButton)Master.FindControl("accJobLbtn");
                    // LinkButton newJob = (LinkButton)Master.FindControl("newJobLbtn");
                    LinkButton logout = (LinkButton)Master.FindControl("logoutLbtn");
                    LinkButton rejectedJobs = (LinkButton)Master.FindControl("rejJobLbtn");                    
                    login.Visible = false;
                    acceptedJobs.Visible = true;
                    //  newJob.Visible = true;
                    logout.Visible = true;
                    rejectedJobs.Visible = true;
                    Contractor currContractor = new Contractor();
                    currContractor.Contractor_Id = Convert.ToInt32(Session["Contractor_Id"].ToString());
                    gvJobs.DataSource = currContractor.AllJobs().DefaultView;
                    gvJobs.DataBind();
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
            gvJobs.DataSource = currContractor.AllJobs().DefaultView;
            gvJobs.DataBind();
        }
    }
}