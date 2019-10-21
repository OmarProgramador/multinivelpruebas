using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class UpdateNotifC : System.Web.UI.Page
    {
        BrUser brUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            var value = "";

            value = User.Identity.Name.Split('¬')[1];


            if (!string.IsNullOrEmpty(value))
            {
                brUser = new BrUser();
                bool req = brUser.UpdateNotifications(value);
                if (!req) value = "ERROR";
            }
            else
            {
                value = "ERROR";
            }
            
            Response.Write(value);
        }
    }
}