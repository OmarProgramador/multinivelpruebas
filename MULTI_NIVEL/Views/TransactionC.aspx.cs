using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class TransactionC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // var obj = HttpContext.Current.User.Identity.Name.Split('¬');
            var obj = (string)(Request["params"]);
            BrPayments brPayments = new BrPayments();
            bool data = brPayments.PayComissions(obj);


            Response.Write(data);
            return;
        }
    }
}