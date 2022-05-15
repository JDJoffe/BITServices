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
    public partial class CompletedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCompletedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Job Job = new Job();
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvCompletedJobs.Rows[rowIndex];
            Job.JobId = Convert.ToInt32(row.Cells[2].Text);
            if (e.CommandName == "Approve")
            {

                Job.ApproveJob();
            }
            else if (e.CommandName == "Reject")
            {
                Job.RejectJob();
            }
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            CompletedJobs allJobs = new CompletedJobs();
            gvCompletedJobs.DataSource = allJobs.AllCompletedJobs().DefaultView;
            gvCompletedJobs.DataBind();
        }
    }
}