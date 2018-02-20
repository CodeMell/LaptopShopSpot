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
    public partial class ProductConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["theProduct"] != null) {
                Product theProduct = (Product)Session["theProduct"];
                lblProdName.Text = theProduct.prodName;
                lblDesc.Text = theProduct.prodDesc;
                lblPrice.Text = theProduct.price.ToString();
                lblInventory.Text = theProduct.inventory.ToString();
                if (theProduct.prodImg != null)
                {
                    Session["theImage"] = theProduct.prodImg;
                    prodImg.ImageUrl = "/Handlers/imgConverter.ashx?Session=" + "theImage";
                    prodImg.Visible = true;
                }


            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

        }

        protected void btnOkay_Click(object sender, EventArgs e)
        {
            if (Session["theProduct"] != null) {

                ProductTier theTier = new ProductTier();
                Product theProduct = (Product)Session["theProduct"];

                if (theTier.insertProduct(theProduct))
                {
                    Session["theProduct"] = null;
                    Response.Redirect("/SuccessfulSubmission.aspx");
                }
                else
                {
                    Response.Redirect("/FailedSubmission.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/InsertProduct.aspx");
        }
    }
}