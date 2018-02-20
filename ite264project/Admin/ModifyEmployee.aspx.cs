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
    public partial class ModifyEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                int id = (int)Session["EmployeeID"];
                EmployeeTier theTier = new EmployeeTier();
                Employee theEmployee = theTier.getEmployeeByID(id);

                idLabel.InnerText = "Employee ID: " + theEmployee.empID.ToString();
                if (!IsPostBack)
                {
                    txtFirstName.Text = theEmployee.firstName;
                    txtLastName.Text = theEmployee.lastName;
                    txtEmail.Text = theEmployee.email;
                    txtAddress.Text = theEmployee.address;
                    txtAddress2.Text = theEmployee.address2;
                    txtCity.Text = theEmployee.city;
                    txtState.Text = theEmployee.state;
                    txtZip.Text = theEmployee.zip.ToString();
                    lblHireDate.Text = theEmployee.hireDate.ToShortDateString();
                    lblTermDate.Text = theEmployee.termDate.ToShortDateString();
                }

            }
            else
            {
                Response.Redirect("/Admin/EmployeeInfo.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Employee theEmployee = new Employee();
            EmployeeTier theTier = new EmployeeTier();

            theEmployee.firstName = txtFirstName.Text;
            theEmployee.lastName = txtLastName.Text;
            theEmployee.email = txtEmail.Text;
            theEmployee.address = txtAddress.Text;
            theEmployee.address2 = txtAddress2.Text;
            theEmployee.city = txtCity.Text;
            theEmployee.state = txtState.Text;
            theEmployee.zip = int.Parse(txtZip.Text);
            if (calHireDate.SelectedDate != null)
            {
                theEmployee.hireDate = calHireDate.SelectedDate;
            }
            if (calTermDate.SelectedDate != null)
            {
                theEmployee.termDate = calTermDate.SelectedDate;
            }

            if (theTier.modifyEmployee(theEmployee))
            {
                Response.Redirect("/SuccessfulSubmission.aspx");
            }
            else
            {
                Response.Redirect("/FailedSubmission.aspx");
            }

            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/AdminPage.aspx");
        }

        protected void btnDate1_Click(object sender, EventArgs e)
        {
            if (!calHireDate.Visible)
            {
                calHireDate.Visible = true;
            }
            else
            {
                calHireDate.Visible = false;
            }
        }

        protected void btnDate2_Click(object sender, EventArgs e)
        {
            if (!calTermDate.Visible)
            {
                calTermDate.Visible = true;
            }
            else
            {
                calTermDate.Visible = false;
            }

        }

        protected void calHireDate_SelectionChanged(object sender, EventArgs e)
        {
            lblHireDate.Text = calHireDate.SelectedDate.ToShortDateString();
            calHireDate.Visible = false;
        }

        protected void calTermDate_SelectionChanged(object sender, EventArgs e)
        {
            lblTermDate.Text = calTermDate.SelectedDate.ToShortDateString();
            calTermDate.Visible = false;
        }
    }
}