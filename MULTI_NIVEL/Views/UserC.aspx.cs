

namespace MULTI_NIVEL.Views
{
    using BussinesRules.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class UserC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BrUser brUser = new BrUser();
            string data = brUser.getPersons();

            //data = "descripcion|siguienteven|balancecapital|amortizacion|interes|cuota|estado|imagen|obs¬descripcion2|siguienteven2|balancecapital2|amortizacion2|interes2|cuota2|estado2|imagen2|obs2";
            Response.Write(data);
            return;
        }
    }
}

/*merge*/