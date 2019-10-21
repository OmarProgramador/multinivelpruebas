using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class CommissionsData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var obj = HttpContext.Current.User.Identity.Name.Split('¬');
            BrCommissions brCommissions = new BrCommissions();
            string data = brCommissions.getCommissions(obj[1]);
            Response.Write(data);
            return;
        }
    }
}