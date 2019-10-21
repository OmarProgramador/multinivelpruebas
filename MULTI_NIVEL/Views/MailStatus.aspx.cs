using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class MailStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnActive_Click(object sender, EventArgs e)
        {
            Response.Redirect("MailAccountActive.aspx");
        }

        protected void btnPending_Click(object sender, EventArgs e)
        {
            Response.Redirect("MailAccount.aspx");
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }
    }
}