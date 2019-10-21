using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class DisabledAccountC : System.Web.UI.Page
    {
        BrUser brUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            var value = (Request["params"]);
            brUser = new BrUser();
            bool n = brUser.DisabledAccount(int.Parse(value));
            if (!n)
            {
                Response.Write("Hubo un problema");
                return;
            }
            Response.Write("Transaccion Realizada Con Exito");
            return;
        }
    }
}