

namespace MULTI_NIVEL.Views
{
    using BussinesRules.User;
    using System;
    using System.Web;
    using System.Web.Security;

    public partial class ReceiptsUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["backendLogin"] == null)
            {
                Response.Redirect("Backend.aspx", true);
            }

            if (Session["backendLogin"].ToString() != "1")
            {
                Response.Redirect("Backend.aspx", true);
            }


            Session["params"] = (Request["variable1"]);
           // BrUser brUser = new BrUser();
            //string data = brUser.getPersons();
           // Response.Write("halo");
           // return;

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }
    }
}