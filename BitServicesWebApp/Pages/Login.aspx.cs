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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Email = userNameTxt.Text,
                Password = passwordTxt.Text
            };

            int cli_Id = user.CheckClient();
            int con_Id = user.CheckContractor();
            int coo_Id = user.CheckCoordinator();
            if (cli_Id > 0)
            {
                Session.Add("Client_Id", cli_Id);
                // Session variable is added with the name : CustomerId
                // and the value of id gets set to CustomerId Session variable
                Response.Redirect("ClientJobs.aspx");
            }
            else if (con_Id > 0)
            {


                Session.Add("Contractor_Id", con_Id);
                // Session variable is added with the name : InstructorId
                // and the value of id gets set to InstructorId Session variable
                Response.Redirect("ContractorJobs.aspx");


            }
            else if (coo_Id > 0)
            {
                Session.Add("Coordinator_Id", coo_Id);
                // Session variable is added with the name : StaffId
                // and the value of id gets set to CustomerId Session variable
                Response.Redirect("AllCompletedJobs.aspx");
            }
            else
            {
                Response.Write("<script>alert('Incorrect username or password')</script>");
            }

        }
    }
}