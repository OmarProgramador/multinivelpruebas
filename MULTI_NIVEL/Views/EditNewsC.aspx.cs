using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class EditNewsC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] arraylogin = HttpContext.Current.User.Identity.Name.Split('¬');
            string userName = arraylogin[1];


            BrUser brUser = new BrUser();
            Response.Write(brUser.GetNews());
        }
    }
}