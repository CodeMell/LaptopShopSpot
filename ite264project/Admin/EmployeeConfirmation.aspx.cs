using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ite264project.DBClasses;
using ite264project.DataModel;

namespace ite264project.Admin
{
    public partial class EmployeeConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["theEmployee"] != null)
            {
                Employee theEmployee = (Employee)Session["theEmployee"];

                lblFirstName.Text = theEmployee.firstName;
                lblLastName.Text = theEmployee.lastName;
                lblEmail.Text = theEmployee.email;
                lblAddress.Text = theEmployee.address;
                lblAddress2.Text = theEmployee.address2;
                lblCity.Text = theEmployee.city;
                lblState.Text = theEmployee.state;
                lblZip.Text = theEmployee.zip.ToString();
                lblHireDate.Text = theEmployee.hireDate.ToString();
                lblTermDate.Text = theEmployee.termDate.ToString();
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/EmployeeRegistration.aspx");

        }

        protected void btnOkay_Click(object sender, EventArgs e)
        {
            if (Session["theEmployee"] != null)
            {
                EmployeeTier theTier = new EmployeeTier();

                Employee theEmployee = (Employee)Session["theEmployee"];

                if (theTier.insertEmployee(theEmployee))
                {
                    Session["theEmployee"] = null;
                    Response.Redirect("/SuccessfulSubmission.aspx");
                }
                else
                {
                    Response.Redirect("/FailedSubmission.aspx");
                }
            }
        }
    }
}