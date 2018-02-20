using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ite264project.DBClasses;
using ite264project.DataModel;

namespace ite264project.Handlers
{
    /// <summary>
    /// Summary description for imgHandler
    /// </summary>
    public class imgHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Byte[] theImage;
            ProductTier theTier = new ProductTier();
            Int32 imageID = Int32.Parse(context.Request.QueryString["ID"]);
            theImage = theTier.getImage(imageID);

            context.Response.BinaryWrite(theImage);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}