using BussinesRules.User;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class PayServices2 : System.Web.UI.Page
    {
        BrUser brUser;
        BrPayments brPayment;
        string newUserName = null;
        string nombreArchivo = "";
        double tipocambio = 0.00;
        int idMemberDetails = 0;
        Email oEmail = null;
        string nombreBenef = "";
        string vigencia = "";
        int cantidad = 0;
        string CodigoReserva = "";
        MyMessages myMessages = new MyMessages();

        string[] obj = HttpContext.Current.User.Identity.Name.Split('¬');
        protected void Page_Load(object sender, EventArgs e)
        {

            var qwe = Session["formPayd"].ToString();
            var asd = int.Parse(qwe.ToString());

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



            if (!string.IsNullOrEmpty((string)Session["servicio"]))
            {
                double tipocambio = 0.00;

                string[] acarrito = Session["servicio"].ToString().Split('|');


                //tipocambio = Double.Parse(acarrito[4]);
                lblAmount.Text = Session["precio"].ToString();

                if (Session["servicio"] == null)
                {
                    Response.Redirect("Index.aspx", true);
                }
            }
            //else
            //{
            //    //no tener la opcion de enviar despues cuando viene de pago
            //    if (Session["StatusCalendar"] != null)
            //    {
            //        pnEnviarDesp.Style.Add("Display", "none");

            //        lblAmount.Text = (string)Session["quotePay"];
            //    }
            //}
        }



        protected void btnEnviarAhora_Click(object sender, EventArgs e)
        {
            if (Session["servicio"] != null)
            {
                string dataPerson = Session["servicio"].ToString();
                
                if (string.IsNullOrEmpty(dataPerson))
                {
                    Response.Redirect("Register.aspx");
                }

                if (!fuRecibo.HasFile)
                {
                    //no hay imagen en el control
                    return;
                }
                //si hay una archivo.

                string[] arraydata = dataPerson.Split('|');
                string[] arraynombreArchivo2 = fuRecibo.FileName.Split('.');

                int indice = (arraynombreArchivo2.Length - 1);
                string extension = arraynombreArchivo2[indice];
                nombreArchivo = arraydata[0] + "." + extension;

                string ruta = "~/Resources/ImgServices/" + nombreArchivo;
                fuRecibo.SaveAs(Server.MapPath(ruta));
                brPayment = new BrPayments();
                var log = HttpContext.Current.User.Identity.Name.Split('¬');

                var fAdqui = Session["fAdqui"];
                var IdServicio = Session["IdServicio"];
                newUserName = obj[3];
                var emailNewUser = "prueba@gmail.com";
                var amountPay = (int)Session["precio"];
                oEmail = new Email();
                brUser = new BrUser();
                nombreBenef = arraydata[0];
                vigencia = arraydata[1];
                
                cantidad = int.Parse(arraydata[2]);
                bool awnserEmailDoc = oEmail.SubmitEmailNotFiles3(emailNewUser, "[RIBERA DEL RIO - BIENVENIDO]", myMessages.EmailPago(), true);
                var reg = nombreBenef + "|" + vigencia + "|" + CodigoReserva + "|" + cantidad + "|" + fAdqui + "|" + IdServicio + "|" + obj[3] +"|"+ "2" + "|" + nombreArchivo + "|" + amountPay;
                brUser.RegisterService(reg);

                Response.Redirect("EndPaymentServices.aspx", true);
            }
            
        }
    }
}