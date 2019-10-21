
namespace MULTI_NIVEL.Views
{
    using BussinesRules.User;
    using System;

    public partial class PaymentsC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = string.Empty;
            string answer = string.Empty;

            action = Request["action"];

            var arrayLogin = User.Identity.Name.Split('¬');

            if (action == "reject")
            {
                int id = int.Parse(Request["id"]);

                if (id > 0)
                {
                    BrPayments brPayments = new BrPayments();

                    bool dataAnsw = brPayments.QuoteRefuse(id, arrayLogin[1]);

                    if (dataAnsw)
                    {


                        answer = "La operacion se realizo com exito";
                    }
                }
            }

            Response.Write(answer);
        }
    }
}