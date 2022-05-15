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

        protected void loginLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void accJobLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AcceptedJobs.aspx");
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

        protected void newJobLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewJob.aspx");
        }

        protected void rejJobLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("RejectedJobs.aspx");
        }
    }
}