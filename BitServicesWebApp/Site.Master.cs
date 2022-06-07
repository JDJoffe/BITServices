using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitServicesWebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region Neutral
        protected void loginLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void logoutLbtn_Click(object sender, EventArgs e)
        {
            Session.Remove("Client_Id");
            Session.Remove("Contractor_Id");
            Session.Remove("Coordinator_Id");
            // remove all
            //Session.RemoveAll();
            // abandon ones currently logged on
            //Session.Abandon();
            // clear memory of session var but keep session
            //Session.Clear();
            Response.Redirect("Login.aspx");
        }
        #endregion

        #region Client
        protected void cliJobLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientJobs.aspx");
        }
        protected void newJobLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewJob.aspx");
        }
        #endregion

        #region Coordinator
        protected void asgJobbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllUnassignedJobs.aspx");
        }
        protected void rejJobLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllRejectedJobs.aspx");
        }
        protected void comJobLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllCompletedJobs.aspx");
        }
        #endregion

        #region Contractor
        protected void conJobLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContractorJobs.aspx");
        }
        protected void accJobLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AcceptedJobs.aspx");
        }
        #endregion

    }
}