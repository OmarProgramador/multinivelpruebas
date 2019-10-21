using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class CurrentPointsC : System.Web.UI.Page
    {
        BrPayments brPayments;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] arrayLogin = User.Identity.Name.Split('¬');
            var value = (Request["Key"]);
            value = value.Replace('Â', ' ').Trim();
            var parameters = value.Split('¬')[1];
            brPayments = new BrPayments();
            string stackFb = brPayments.GetPointsGeneral(arrayLogin[1]);
            if (string.IsNullOrEmpty(stackFb))
            {
                stackFb = "there is a trouble";
            }
            Response.Write(stackFb);
        }
    }
}