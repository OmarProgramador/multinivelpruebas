using BussinesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class MailDeleteBussinesC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string res = "error";
            // var obj = HttpContext.Current.User.Identity.Name.Split('¬');
            var obj = (string)(Request["params"]);
            BrPartner brPartner = new BrPartner();
            bool data = brPartner.DeleteEmailBussines(obj);
            if (data)
            {
                res = "Operacion realziada con exito";
            }
            Response.Write(res);
            return;

        }
    }
}