﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//add
using BitServicesWebApp.BLL;

namespace BitServicesWebApp.Pages
{
    public partial class AllRejectedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        }

        protected void gvRejectedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvRejectedJobs.Rows[rowIndex];


            if (e.CommandName == "Find")
            {
                Session.Add("suburb", row.Cells[5].Text);
                DateTime jobDate = Convert.ToDateTime(row.Cells[9].Text);
                string time = row.Cells[10].Text;
                // collect all the required data into temp session var
                Session.Add("Client_id", Convert.ToInt32(row.Cells[2].Text));
                Session.Add("street", row.Cells[4].Text);
                Session.Add("postcode", row.Cells[6].Text);
                //Session.Add("state", row.Cells[7].Text);
                Availability allSessions = new Availability();
              //  gvAvailableSessions.DataSource = allSessions.CheckAvailability(jobDate, time, Session["suburb"].ToString(),Session["postcode"].ToString()).DefaultView;
                gvAvailableSessions.DataBind();
            }
            RefreshGrid();
        }

        protected void gvAvailableSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void RefreshGrid()
        {
            RejectedJobs allRejJobs = new RejectedJobs();
            gvRejectedJobs.DataSource = allRejJobs.AllRejectedJobs().DefaultView;
            gvRejectedJobs.DataBind();
        }
    }
}