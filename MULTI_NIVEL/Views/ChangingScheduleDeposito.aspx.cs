using BussinesRules;
using Entities;
using System;
using System.Collections.Generic;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class ChangingScheduleDeposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var formPay = Request["fp"] == null ? "2" : Request["fp"];
                var asd = int.Parse(formPay.ToString());

                MyConstants mc = new MyConstants();

                LblBankAccount.Text = mc.BankAccount;
                LblInterbankAccount.Text = mc.InterbankAccount;
                string[] arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');

                if (asd == 2)
                {
                    imgfpd.ImageUrl = "~/Views/img/agente.jpg";
                    lbpaso1.Text = "Acercarse a una oficina del BCP o Agente BCP";
                    lbpaso2.Text = "Realizar el abono correspondiente en nuestra cuenta corriente";
                    lbpaso3.Text = "Subir el comprobante de pago en la sección de validación";
                    lbpaso4.Text = "Su pago estara validado dentro de las proximas 24 horas";

                }
                else if (asd == 3)
                {
                    imgfpd.ImageUrl = "~/Views/img/banco.png";
                    lbpaso1.Text = "Ir a la sección pagar y transferir - Hacer una transferencia";
                    lbpaso2.Text = "Seleccionar la opción a otras cuentas BCP";
                    lbpaso3.Text = "Poner la cuenta corriente de la compañia en cuenta destino y pagar";
                    lbpaso4.Text = "Subir el comprobante de pago en la sección de validación. Su pago estara validado dentro de las proximas 24 horas";
                }
                else if (asd == 4)
                {
                    imgfpd.ImageUrl = "~/Views/img/logosf2.png";
                    lbpaso1.Text = "Acercarse a la oficina o al Club";
                    lbpaso2.Text = "Realizar el abono correspondiente ya se en efectivo o con tarjeta de debito o credito";
                    lbpaso3.Text = "Un encargado de la compañia subira el comprobante de pago en la sección de validación";
                    lbpaso4.Text = "Su pago estara validado en el momento.";
                }
            }
        }

        protected void btnSendNow_Click(object sender, EventArgs e)
        {
            PayCulqi culqi = new PayCulqi();
            BrMembershipPayDetail payDetail = new BrMembershipPayDetail();

            if (!fuRecibo.HasFile)
            {
                //no hay imagen en el control
                return;
            }
            //si hay una archivo.

            string[] arraynombreArchivo2 = fuRecibo.FileName.Split('.');

            int indice = (arraynombreArchivo2.Length - 1);

            string extension = arraynombreArchivo2[indice];

            string userRec = User.Identity.Name.Split('¬')[1] + DateTime.Now.ToString("yyyyMMddHHmmss");

            string nameImage = userRec + "." + extension;

            string ruta = "~/Resources/RecibosRegister/" + nameImage;
            fuRecibo.SaveAs(Server.MapPath(ruta));

            var data = (Dictionary<string, object>)Session["changingschedule"];

            var action = data["Action"];
            var valueQuote = Convert.ToDouble(data["ValueQuote"]);
            var numQuote = Convert.ToDouble(data["NumQuote"]);
            var idMembership = Convert.ToInt32(data["IdMembership"]);
            var lastpaydate = Convert.ToDateTime(data["PayDate"]);

            var smallDate = DateTime.Now - lastpaydate;

            var numberDays = smallDate.Days;

            var valueTotal = valueQuote * numQuote;

            Session.RemoveAll();
            int numQuotes = int.Parse(numQuote.ToString());


            bool responseb = payDetail.PutQuotesChangingSchedule(idMembership, numQuotes, nameImage, 2);

            if (numberDays > 0) {
                BrDaysFree brDaysFree = new BrDaysFree();
                var dataanw = brDaysFree.Put(User.Identity.Name.Split('¬')[1], numberDays, idMembership);
            }
            string message = "";
            if (responseb)
            {
                message = "La operación se realizó con éxito.";
            }
            Response.Redirect("Payments.aspx?msg=" + message);
        }
    }
}