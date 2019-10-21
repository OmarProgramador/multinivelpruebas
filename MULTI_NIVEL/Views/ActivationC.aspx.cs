using BussinesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class ActivationC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "", answer = "Ocurrio error", userName = "";
            action = Request["action"];
            userName = User.Identity.Name.Split('¬')[1];
            BrActivation brActivation = new BrActivation();
            if (action == "get")
            {
                answer = brActivation.Get(userName); 
            }


            Response.Write(answer);
        }
    }
}