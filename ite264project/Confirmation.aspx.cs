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
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["theCustomer"] != null)
            {
                Customer theCustomer = (Customer)Session["theCustomer"];

                lblFirstName.Text = theCustomer.firstName;
                lblLastName.Text = theCustomer.lastName;
                lblEmail.Text = theCustomer.email;
                lblAddress.Text = theCustomer.address;
                lblAddress2.Text = theCustomer.address2;
                lblCity.Text = theCustomer.city;
                lblState.Text = theCustomer.state;
                lblZip.Text = theCustomer.zip.ToString();

                
            }else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnOkay_Click(object sender, EventArgs e)
        {
            if (Session["theCustomer"] != null)
            {
                CustomerTier theTier = new CustomerTier();

                Customer theCustomer = (Customer)Session["theCustomer"];

                if (theTier.insertCustomer(theCustomer))
                {
                    Session["theCustomer"] = null;
                    Response.Redirect("SuccessfulSubmission.aspx");
                }
                else
                {
                    Response.Redirect("FailedSubmission.aspx");
                }
            }
        }
    }
}