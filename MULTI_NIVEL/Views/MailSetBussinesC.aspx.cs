using BussinesRules;
using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class MailSetBussinesC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string res = "error";
            // var obj = HttpContext.Current.User.Identity.Name.Split('¬');
            var obj = (string)(Request["params"]);
            BrPartner brPartner = new BrPartner();
            bool data = brPartner.SetEmailBussines(obj);
            if (data)
            {
                res = "Operacion realziada con exito" ;
            }
            Response.Write(res);
            return;
        }
    }
}