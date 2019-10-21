using System;
using BussinesRules;


namespace MULTI_NIVEL.Views
{
    public partial class TransactionsDetailC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] arrayLogin = User.Identity.Name.Split('¬');
            BrTransactionsDetail brTransactions = new BrTransactionsDetail();

            Response.Write(brTransactions.Get(arrayLogin[1]));
        }
    }
}