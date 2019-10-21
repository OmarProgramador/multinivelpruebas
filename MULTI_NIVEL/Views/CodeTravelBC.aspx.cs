using BussinesRules;
using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class CodeTravelBC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];
            string answer = "";
            BrCodeTravel brCodeTravel = new BrCodeTravel();
            if (action == "getNotConfirmed")
            {
                answer = brCodeTravel.GetNotConfirmed();
            }

            if (action == "confirm")
            {
                //string user = Request["user"];
                string pass = Request["pass"];
                string code = Request["code"];
                int id = int.Parse(Request["id"]);

                bool response = brCodeTravel.Acceptance(id, "", pass, code);
                if (response)
                {
                    answer = "La operacion se realizo con exito.";
                }
            }
            if (action == "infoPerson")
            {
                BrUser brUser = new BrUser();
                answer = brUser.GetPersonalInformation(User.Identity.Name.Split('¬')[1]);
            }
            if (action == "putTravel")
            {

                bool response = brCodeTravel.VerifMaximo(User.Identity.Name.Split('¬')[1]);
                if (response)
                {
                    answer = "Haz solicitado el maximo de codigos disponibles, ya no Puede solicitar mas codigos.";
                }
                else
                {
                    string name = Request["name"];
                    string lastname = Request["lastname"];
                    string email = Request["email"];
                    string phone = Request["phone"];
                    string duration = Request["duration"];
                    int idperson = int.Parse(User.Identity.Name.Split('¬')[2]);
                    int idaccount = int.Parse(User.Identity.Name.Split('¬')[4]);
                    duration = DateTime.Now.AddDays(int.Parse(duration)).ToString("yyyy-MM-dd");
                    response = brCodeTravel.Put(idperson, idaccount, name, lastname, email, phone, duration);
                    if (response)
                    {
                        answer = "La solicitud se registro con exito, en un plazo maximo de 24 hrs se confirmara su codigo.";
                    }
                }
            }
            if (action == "listCode")
            {
                answer = brCodeTravel.Get(User.Identity.Name.Split('¬')[1]);
            }
            if (action == "listHotel2")
            {
                BrServices brServices = new BrServices();
                answer = brServices.GetHotel2(User.Identity.Name.Split('¬')[1]);
                brServices = null;
            }
            

            Response.Write(answer);
        }
    }
}