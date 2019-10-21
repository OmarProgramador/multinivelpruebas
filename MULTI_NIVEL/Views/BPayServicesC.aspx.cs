using BussinesRules;
using System;

namespace MULTI_NIVEL.Views
{
    public partial class BPayServicesC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string action = "";
                string userName = "", obs = "";
                decimal price = 0;
                int id = 0;
                if (Session["backendLogin"] == null)
                {
                    Response.Write("");
                }

                if (Session["backendLogin"].ToString() != "1")
                {
                    Response.Write("");
                }

                action = Request["action"].ToString();
                if (action == "Get")
                {
                    BrServices brServices = new BrServices();
                    Response.Write(brServices.GetPendient());
                }
                if (action == "AceptarPay")
                {
                    id = int.Parse(Request["id"].ToString());
                    userName = Request["userName"].ToString();
                    obs = Request["obs"].ToString();
                    price = decimal.Parse(Request["price"].ToString());

                    BrServices brServices = new BrServices();
                    bool anwserb = brServices.PayService(id, userName, 1, obs, price);
                    string anwser = "Ha ocurrido un error";
                    if (anwserb)
                    {
                        anwser = "La operacion se ha realizado con éxito";
                    }
                    Response.Write(anwser);
                }
                if (action == "RechazarPay")
                {
                    id = int.Parse(Request["id"].ToString());
                    userName = Request["userName"].ToString();
                    obs = Request["obs"].ToString();
                    price = decimal.Parse(Request["price"].ToString());

                    BrServices brServices = new BrServices();
                    bool anwserb = brServices.PayService(id, userName, 0, obs, price);
                    string anwser = "Ha ocurrido un error";
                    if (anwserb)
                    {
                        anwser = "La operacion se ha realizado con éxito";
                    }
                    Response.Write(anwser);
                }
                if (action == "ConformePay")
                {
                    id = int.Parse(Request["id"].ToString());
                    userName = Request["userName"].ToString();
                    obs = Request["obs"].ToString();
                    price = decimal.Parse(Request["price"].ToString());

                    BrServices brServices = new BrServices();
                    bool anwserb = brServices.PayService(id, userName, 3, obs, price);
                    string anwser = "Ha ocurrido un error";
                    if (anwserb)
                    {
                        anwser = "La operacion se ha realizado con éxito";
                    }
                    Response.Write(anwser);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Ha ocurrido un error: " + ex.Message);
            }
        }
    }
}