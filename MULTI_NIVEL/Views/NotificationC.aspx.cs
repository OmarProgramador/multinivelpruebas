using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    
    public partial class NotificationC : System.Web.UI.Page
    {
        BrUser brUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            //var http = "hello";
            string userName = User.Identity.Name.Split('¬')[1];

            brUser = new BrUser();
            string stackFb = brUser.GetNotifications(userName);
            if (string.IsNullOrEmpty(stackFb))
            {
                stackFb = "there is a trouble";
            }
            Response.Write(stackFb);
        }
    }
}