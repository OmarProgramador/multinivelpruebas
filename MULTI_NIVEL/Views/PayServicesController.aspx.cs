using BussinesRules.User;
using Entities;
using System;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class PayServicesController : System.Web.UI.Page
    {
        string nombreBenef = "";
        string vigencia = "";
        int cantidad = 0;
        string CodigoReserva = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Declaracion de variables
            string[] dataLogin = null;
            string[] obj = HttpContext.Current.User.Identity.Name.Split('¬');
            int typeRegister = 0, numberQuotes = 0, formPay = 0, idMemberDetails = 0;

            //string dataKit = null, dataKitMember = null, dataMemberSinKit;
            string token = null, userCurrent = null, newUserName = null, emailNewUser = null;
            int amountPay = 0;
            //bool isRegister = false;
            BrUser brUser = null;
            //BrTypeMembership brTypeMembership = null;
            Email oEmail = null;
            BrPayments brPayments = null;
            //BrConsuption brConsuption;

            #endregion

            #region Entradas de valores

            //var _var = (string)Session["typeRegister"];
            //if (!string.IsNullOrEmpty(_var))
            //{
            //    typeRegister = int.Parse(Session["typeRegister"].ToString());
            //}
            formPay = int.Parse("1");
            token = Request["token"].ToString();
            numberQuotes = int.Parse(Request["numcuotes"].ToString());
            brUser = new BrUser();
            //brTypeMembership = new BrTypeMembership();
            dataLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            oEmail = new Email();
            brPayments = new BrPayments();
            //brConsuption = new BrConsuption();
            #endregion

            #region Realizar Pago Culqi

            if (formPay == 1)
            {
                amountPay = (int)Session["precio"];
                if (amountPay <= 0)
                {
                    Response.Write("false¬Ha Ocurrido Un Error id idMemberDetails vacio,amountPay vacio");
                    return;
                }
                PayCulqi payCulqi = new PayCulqi();
                MyMessages myMessages = new MyMessages();

                newUserName = obj[3];
                emailNewUser = "prueba@gmail.com";

                string currencyCode = "PEN";
                string[] culqiAnwser = payCulqi.newPayment(newUserName, emailNewUser, amountPay, token, numberQuotes, currencyCode).Split('¬');
                if (culqiAnwser[0] == "false")
                {
                    Response.Write("false¬" + culqiAnwser[1]);
                    return;
                }
                //marcar como pagado en la tabla membershipdetails
                // bool habiliAccount = brUser.enableAcount(idMemberDetails);

                //int nAfiliate = int.Parse(brUser.GetNafiliate(idMemberDetails));

                //Cronograma2(nAfiliate);

                // enviar el email de confirmacion con la data y lo redirecciona al post register
                //if (!habiliAccount)
                //{
                //    Response.Write("false¬Ha Ocurrido un Error al Intentar Habilitar Su Cuenta.Sin embargo su Pago fue Exitoso");
                //    return;
                //}

                //string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/");
                //enviar email con los documentos
                string nombreBenef = Session["servicio"].ToString().Split('|')[0];
                string vigencia = Session["servicio"].ToString().Split('|')[1];
                string cantidad = Session["servicio"].ToString().Split('|')[2];
                string fAdqui = Session["servicio"].ToString().Split('|')[3];
                amountPay = int.Parse(Session["precio"].ToString());

                var IdServicio = Session["IdServicio"];
                bool awnserEmailDoc = oEmail.SubmitEmailNotFiles3(emailNewUser, "[RIBERA DEL RIO - BIENVENIDO]", myMessages.EmailPago(), true);
                var reg = nombreBenef + "|" + vigencia + "|" + CodigoReserva + "|" + cantidad + "|" + fAdqui + "|" + IdServicio + "|" + obj[3] + "|" + "2" + "|" + "culqui.png" + "|" + amountPay;
                bool qwe = brUser.RegisterService(reg);

                //bool awnserEmail = oEmail.submitEmail(emailNewUser, "[RIBERA DEL RIO - PAGO]", myMessages.EmailPago());

                //ejecutamos el core para los puntos de equipo
                // BrCore_Automation brCore_Automation = new BrCore_Automation();
                //bool isCoreRegister = brCore_Automation.ExecuteCore();

                Response.Write("true¬" + culqiAnwser[1]);
                return;
            }

            #endregion
        }
    }
}