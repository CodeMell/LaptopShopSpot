using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ite264project.DataModel;
using ite264project.DBClasses;

namespace ite264project.Admin
{
    public partial class ModifyCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] != null)
            {
                int id = (int)Session["CustomerID"];
                CustomerTier theTier = new CustomerTier();
                Customer theCustomer = theTier.getCustomerByID(id);

                idLabel.InnerText = "Customer ID: " + theCustomer.custID.ToString();
                if (!IsPostBack)
                {
                    txtFirstName.Text = theCustomer.firstName;
                    txtLastName.Text = theCustomer.lastName;
                    txtEmail.Text = theCustomer.email;
                    txtAddress.Text = theCustomer.address;
                    txtAddress2.Text = theCustomer.address2;
                    txtCity.Text = theCustomer.city;
                    txtState.Text = theCustomer.state;
                    txtZip.Text = theCustomer.zip.ToString();
                }

            }else
            {
                Response.Redirect("/Admin/CustomerInfo.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CustomerTier theTier = new CustomerTier();
            Customer theCustomer = new Customer();
            theCustomer.custID = (int)Session["CustomerID"];
            theCustomer.firstName = txtFirstName.Text;
            theCustomer.lastName = txtLastName.Text;
            theCustomer.email = txtEmail.Text;
            theCustomer.address = txtAddress.Text;
            theCustomer.address2 = txtAddress2.Text;
            theCustomer.city = txtCity.Text;
            theCustomer.state = txtState.Text;
            theCustomer.zip = int.Parse(txtZip.Text);

            if (theTier.modifyCustomer(theCustomer))
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
    }
}