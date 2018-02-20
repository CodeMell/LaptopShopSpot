using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ite264project.DataModel;
using ite264project.DBClasses;
using System.IO;

namespace ite264project.Admin
{
    public partial class ModifyProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ProductID"] != null)
            {
                int id = (int)Session["ProductID"];
                ProductTier theTier = new ProductTier();
                Product theProduct = theTier.getProductById(id);
                Session["theImage"] = theProduct.prodImg;

                if (!IsPostBack)
                {
                    idLabel.InnerText = "Product ID: " + theProduct.prodID.ToString();
                    txtProdName.Text = theProduct.prodName;
                    txtProdDesc.Text = theProduct.prodDesc;
                    txtPrice.Text = Math.Round(theProduct.price, 2).ToString();
                    txtInventory.Text = theProduct.inventory.ToString();
                    prodImg.ImageUrl = "/Handlers/imgHandler.ashx?ID=" + theProduct.prodID;
                }
            }
            else
            {
                Response.Redirect("/Admin/ProductInfo.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductTier theTier = new ProductTier();
            Product theProduct = new Product();
            theProduct.prodID = (int)Session["ProductID"];
            theProduct.prodName = txtProdName.Text;
            theProduct.prodDesc = txtProdDesc.Text;
            theProduct.price = Double.Parse(txtPrice.Text);
            theProduct.inventory = int.Parse(txtInventory.Text);
            if (newImg.HasFile)
            {
                Stream fs = newImg.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);

                Byte[] theImage = br.ReadBytes((Int32)fs.Length);
                theProduct.prodImg = theImage;
            }
            else
            {
                theProduct.prodImg = (Byte[])Session["theImage"];
            }

            if (theTier.modifyProduct(theProduct))
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