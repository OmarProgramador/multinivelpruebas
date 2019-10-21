
namespace MULTI_NIVEL.Views
{ 
    using System;
    using BussinesRules;
    using BussinesRules.User;
    using Entities;

    public partial class BextornoC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];
            string answer = string.Empty;

            if (action == "verif")
            {
                string username = Request["username"];
                MyFunctions mf = new MyFunctions();
                BrUser brUser = new BrUser();
                var data = brUser.GetPersonalInformation(username).Split('|');
                if (data.Length > 1)
                {
                    answer = mf.ToCapitalize(data[1]) + " " + mf.ToCapitalize(data[2]);
                    //string username = Request["username"];
                    //int idNmembership = int.Parse(Request["idNmembership"]);
                    BrMembershipPayDetail payDetail = new BrMembershipPayDetail();
                    var crono = payDetail.GetFullSchedule(username, 1);
                    answer += "$" + crono;
                }

            }

            if (action == "info")
            {


            }

            if (action == "extornar")
            {
                string username = Request["username"];
                BrExtorno brExtorno = new BrExtorno();
                var _response = brExtorno.ExtornarAccount(username);
            }

            Response.Write(answer);
        }
    }
}