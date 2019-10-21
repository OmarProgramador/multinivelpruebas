using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class UpdateComission : System.Web.UI.Page
    {
        BrPayments brPayments;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _aux = Request["id"];
            // var _aux2 = Request["id"];
            Int32 value = Int32.Parse(_aux);
            brPayments = new BrPayments();
            bool ans = brPayments.UpdateComissionStatus(value);

            Response.Write(ans);
        }
    }
}