using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ite264project.DataModel;
using ite264project.DBClasses;

namespace ite264project.Admin
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Stream fs = flUpload.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);

            Byte[] theImage = br.ReadBytes((Int32)fs.Length);
            Product theProduct = new Product();
            theProduct.prodName = txtProdName.Text;
            theProduct.prodDesc = txtDesc.Text;
            if (theImage != null)
            {
                theProduct.prodImg = theImage;
            }
            theProduct.price = double.Parse(txtPrice.Text);
            theProduct.inventory = int.Parse(txtInv.Text);

            Session["theProduct"] = theProduct;

            Response.Redirect("/Admin/ProductConfirmation.aspx");
        }
    }
}