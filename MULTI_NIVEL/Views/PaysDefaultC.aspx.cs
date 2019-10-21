using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class PaysDefaultC : System.Web.UI.Page
    {
        BrPayments brPayments;
        protected void Page_Load(object sender, EventArgs e)
        {
            brPayments = new BrPayments();
            string table = brPayments.GetListPayDefault();
            Response.Write(table);
        }
    }
}