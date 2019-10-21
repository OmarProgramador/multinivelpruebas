using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["backendLogin"] == null)
            {
                Response.Redirect("Backend.aspx",true);
            }

            if (Session["backendLogin"].ToString() != "1")
            {
                Response.Redirect("Backend.aspx", true);
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            Response.Redirect("Index.aspx", true); /*try merge*/
        }
    }
}