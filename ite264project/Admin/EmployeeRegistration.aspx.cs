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
    public partial class EmployeeRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Employee theEmployee = new Employee();

            theEmployee.firstName = txtFirstName.Text;
            theEmployee.lastName = txtLastName.Text;
            theEmployee.email = txtEmail.Text;
            theEmployee.address = txtAddress.Text;
            theEmployee.address2 = txtAddress2.Text;
            theEmployee.city = txtCity.Text;
            theEmployee.state = txtState.Text;
            theEmployee.zip = int.Parse(txtZip.Text);
            theEmployee.hireDate = calHireDate.SelectedDate;
            if (calTermDate.SelectedDate != null)
            {
                theEmployee.termDate = calTermDate.SelectedDate;
            }

            Session["theEmployee"] = theEmployee;

            Response.Redirect("/Admin/EmployeeConfirmation.aspx");
        }

        protected void btnDate1_Click(object sender, EventArgs e)
        {
            if(!calHireDate.Visible)
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