using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class PaymentsData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            BrPayments brPayments = new BrPayments();
            String parametro = Request["id"];
            
            var login = HttpContext.Current.User.Identity.Name.Split('¬');
            string data = brPayments.GetListPayments(login[1]);


            Response.Write(data);
            return;
        }
    }
}