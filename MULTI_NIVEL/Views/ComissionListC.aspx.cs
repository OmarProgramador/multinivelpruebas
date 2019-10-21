using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesRules.User;

namespace MULTI_NIVEL.Views
{
    public partial class ComissionListC : System.Web.UI.Page
    {
        


        protected void Page_Load(object sender, EventArgs e)
        {
           // var obj = HttpContext.Current.User.Identity.Name.Split('¬');
            var obj = (Request["params"]);
            BrCommissions brCommissions = new BrCommissions();
            string data = brCommissions.getCommissionsManagement(obj);


            Response.Write(data);
            return;
        }
    }
}