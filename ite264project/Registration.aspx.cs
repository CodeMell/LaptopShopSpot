using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ite264project.DBClasses;
using ite264project.DataModel;

namespace ite264project
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Customer theCustomer = new Customer();

            theCustomer.firstName = txtFirstName.Text;
            theCustomer.lastName = txtLastName.Text;
            theCustomer.email = txtEmail.Text;
            theCustomer.address = txtAddress.Text;
            theCustomer.address2 = txtAddress2.Text;
            theCustomer.city = txtCity.Text;
            theCustomer.state = txtState.Text;
            theCustomer.zip = int.Parse(txtZip.Text);

            Session["theCustomer"] = theCustomer;

            Response.Redirect("Confirmation.aspx");
        }
    }
}