using BussinesRules;
using System;

namespace MULTI_NIVEL.Views
{
    public partial class TravelBenefitsC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];
            string answer = "ocurred error";
            BrCodeTravel brCodeTravel = new BrCodeTravel();
            if (action == "edit")
            {
                string name = Request["name"];
                string lastName = Request["lastName"];
                string email = Request["email"];
                string telef = Request["telef"];
                int id = int.Parse(Request["id"]);
                string code = Request["code"];
                bool response = brCodeTravel.EditBenef(name, lastName, email, telef, id, code);
                if (response)
                {
                    answer = "La operación fue exitosa.";
                }
            }

            if (action == "delete")
            {
                int id = int.Parse(Request["id"]);
                bool response = brCodeTravel.DisposeBenef(id);
                if (response)
                {
                    answer = "La operación fue exitosa.";
                }
            }
            Response.Write(answer);
        }
    }
}