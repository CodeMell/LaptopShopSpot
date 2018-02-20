using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ite264project.Handlers
{
    /// <summary>
    /// Summary description for imgConverter
    /// </summary>
    public class imgConverter : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session[context.Request.QueryString["Session"]] != null)
            {
                
                Byte[] theImage = (Byte[])context.Session[context.Request.QueryString["Session"]];
                context.Response.BinaryWrite(theImage);
            }

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