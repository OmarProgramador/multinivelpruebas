using BussinesRules;
using BussinesRules.User;
using Entities;
using System;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class PayDepositoQuote : System.Web.UI.Page
    {
        BrPayments brPayment;
        BrUser brUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string[] arrayLogin = User.Identity.Name.Split('¬');
                    var typeChange = decimal.Parse(arrayLogin[5]);

                    MyConstants mc = new MyConstants();

                    LblBankAccount.Text = mc.BankAccount;
                    LblBankAccountDolar.Text = mc.BankAccountDolar;
                    LblInterbankAccount.Text = mc.InterbankAccount;
                    LblInterbankAccountDolar.Text = mc.InterbankAccountDolar;

                    var qwe = Session["formPayd"].ToString();
                    var asd = int.Parse(qwe.ToString());
                    lblAmount.Text = Session["Amount"].ToString();

                    var ocurrency = Session["CurrencyCode"];
                    int id = int.Parse(Session["IdImg"].ToString());
                    Typechange.Text = typeChange.ToString();


                    if (ocurrency != null)
                    {
                        cc.Text = ocurrency.ToString();

                        if (ocurrency.ToString() == "PEN")
                        {
                            ddlMoneda.SelectedValue = "PEN";
                            BrMembershipPayDetail brMembershipPayDetail = new BrMembershipPayDetail();

                            var data = brMembershipPayDetail.GetQuote(id, User.Identity.Name.Split('¬')[1]).Split('|');
                            Typechange.Text = decimal.Parse(data[4]).ToString("0.0000");
                        }
                    }

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

                    var objAmortiz = Session["dataAmort"];
                    if (objAmortiz != null)
                    {
                        divSendLater.Style.Add("display","none");

                        Typechange.Text = objAmortiz.ToString().Split('|')[4];
                    }

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        protected void btnEnviarAhora_Click(object sender, EventArgs e)
        {
            var data = (string)Session["dataQuote"];
            if (!string.IsNullOrEmpty(data))
            {
                string IdMembershipPayDetail = data.Split('|')[0];
                var log = HttpContext.Current.User.Identity.Name.Split('¬');
                string User = log[1];
                if (!string.IsNullOrEmpty(IdMembershipPayDetail))
                {
                    // string[] parameterPerson = dataPerson.Split('$');
                    // string[] arraydata = parameterPerson[0].Split('|');
                    string[] arraynombreArchivo2 = fuRecibo.FileName.Split('.');

                    int indice = (arraynombreArchivo2.Length - 1);

                    string extension = arraynombreArchivo2[indice];

                    string nombreArchivo = User + "." + extension;

                    brUser = new BrUser();
                    var nroDoc = brUser.getDoc(log[1]);
                    int id = int.Parse(Session["IdImg"].ToString());
                    nombreArchivo = nroDoc + id.ToString() + "." + extension;

                    string ruta = "~/Resources/RecibosRegister/" + nombreArchivo;
                    fuRecibo.SaveAs(Server.MapPath(ruta));
                    brPayment = new BrPayments();
                    bool ans = brPayment.UploadReceiptCalendar(IdMembershipPayDetail + '|' + nombreArchivo);
                    if (ans)
                    {
                        Session["SwitchEmailPayQuote"] = "1";
                        Response.Redirect("EndPaymentQuote.aspx");
                    }
                    else
                    {
                        Response.Redirect("Index.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
            }
            else
            {
                var values = (string)Session["dataAmort"];
                
                if (!string.IsNullOrEmpty(values))
                {
                    var arrayValues = values.Split('|');
                    brPayment = new BrPayments();
                    // (int TypePay, string IdMembershipDetail, int nQuotes, decimal NewAmort, int Rate)
                    string[] arraynombreArchivo2 = fuRecibo.FileName.Split('.');
                    var log = HttpContext.Current.User.Identity.Name.Split('¬');
                    string User = log[1];
                    int indice = (arraynombreArchivo2.Length - 1);
                    string extension = arraynombreArchivo2[indice];

                    brUser = new BrUser();
                    var nroDoc = brUser.getDoc(log[1]);
                    int id = int.Parse(Session["IdImg"].ToString());
                    string nombreArchivo = nroDoc + id.ToString() + "." + extension;

                    //string nombreArchivo = arraynombreArchivo2[0] + "." + extension;
                    string ruta = "~/Resources/RecibosRegister/" + nombreArchivo;

                    fuRecibo.SaveAs(Server.MapPath(ruta));
                    decimal value2 = decimal.Parse(arrayValues[2]);
                    bool ans = brPayment.Amortization(2, arrayValues[0], Int32.Parse(arrayValues[1]), value2, Int32.Parse(arrayValues[3]), nombreArchivo);

                    Response.Redirect("EndPaymentQuote.aspx");
                    return;
                }
            }
        }

        protected void btnEnviarDespues_Click(object sender, EventArgs e)
        {

            decimal amount = 0;
            string currencyCodecro = "";
            string currencyCode = "";
            bool answer = false;

            amount = decimal.Parse(Session["Amount"].ToString());
            currencyCodecro = Session["CurrencyCode"].ToString();
            currencyCode = ddlMoneda.SelectedValue;

            int id = int.Parse(Session["IdImg"].ToString());
            string description = Session["numCuota"].ToString();

            if (currencyCodecro == "USD")
            {
                if (currencyCode == "USD")
                {
                    answer = SendEmailAmountPay(amount.ToString(), id.ToString(), description, "USD");
                }

                if (currencyCode == "PEN")
                {
                    BrTypeChange brTypeChange = new BrTypeChange();
                    var arraychanges = brTypeChange.GetTypesChange().Split('|');

                    var tcVenta = decimal.Parse(arraychanges[0]);
                    var tcCompra = decimal.Parse(arraychanges[1]);

                    amount = amount * tcCompra;

                    answer = SendEmailAmountPay(amount.ToString("0.00"), id.ToString(), description, "PEN");
                }
            }

            if (currencyCodecro == "PEN")
            {
                if (currencyCode == "PEN")
                {
                    answer = SendEmailAmountPay(amount.ToString(), id.ToString(), description, "PEN");
                }

                if (currencyCode == "USD")
                {
                    BrMembershipPayDetail brMembershipPayDetail = new BrMembershipPayDetail();

                    var data = brMembershipPayDetail.GetQuote(id, User.Identity.Name.Split('¬')[1]).Split('|');
                    var tc = decimal.Parse(data[4]);

                    amount = amount / tc;

                    answer = SendEmailAmountPay(amount.ToString(), id.ToString(), description, "USD");
                }
            }

            if (answer)
            {
                Response.Redirect("EndPaymentSendLater.aspx");
            }
        }

        #region Methods
        public bool SendEmailAmountPay(string amount, string idMembershipDetail, string description, string currencyCode)
        {
            MyConstants mc = new MyConstants();
            MyFunctions mf = new MyFunctions();
            var bankAccount = mc.BankAccount;

            var symbol = "S/";

            if (currencyCode == "USD")
            {
                symbol = "$";
                bankAccount = mc.BankAccountDolar;
            }

            //1|Omar Fernando|Urteaga Cabrera|14/01/1983|M|omarurteaga@gmail.com|938627011||Peru|Lima|Lima|addres|DNI|41958311|1|admin987|Solter(a)
            BrUser brPerson = new BrUser();
            var arrayperson = brPerson.GetPersonalInformation(User.Identity.Name.Split('¬')[1]).Split('|');

            var correo = arrayperson[5];
            var nombre = arrayperson[1] + " " + arrayperson[2];
            var dni = arrayperson[13];
            var username = arrayperson[1].Substring(0, 1).ToUpper() + arrayperson[2].Substring(0, 1).ToUpper() + dni;
            string fullname = arrayperson[1].Trim().ToLower() + " " + arrayperson[2].Trim().ToLower();
            fullname = mf.ToCapitalize(fullname);
            string[] sepName = arrayperson[1].Split(' ');
            var fName = mf.ToCapitalize(sepName[0]);

            var bienvenido = "Estimado";
            if (arrayperson[4] == "F")
            {
                bienvenido = "Estimada";
            }
            var cuerpo = "<html><head><title></title></head><body style='color:black'>";
            cuerpo += "<div style='width: 100%'>";
            cuerpo += "<div style='display:flex;'>";
            cuerpo += "<div style='width:50%;'>";
            cuerpo += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            cuerpo += "</div>";
            cuerpo += "<div style='width:50%;'>";
            cuerpo += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            cuerpo += "</div>";
            cuerpo += "</div>";
            cuerpo += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            cuerpo += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'>" + bienvenido + " " + fName + "</h1>";
            cuerpo += "<h2 style='text-align: center;'>Aqui te detallamos el pago de tu Cuota. Estamos a la espera de que nos brindes tu comprobante de pago</h2>";
            cuerpo += $"<center><p style='margin-left: 10%;margin-right: 10%;'>Monto a pagar por concepto de tu {description}</p></center> ";
            cuerpo += $"<center><p style='margin-left: 10%;margin-right: 10%;'>Monto : {symbol} " + amount + "</p></center> ";
            cuerpo += "<br />";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Cuando lo tengas listo, solo tienes que subirlo a nuestra pagina y enseguida lo estaremos validando</p></center> ";
            cuerpo += "";
            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '> Click en el boton para validar el pago.</p>";
            cuerpo += "<a style='text-decoration: none;' href='https://inresorts.club/Views/Login.aspx?usuario=" + dni + "&fullname=" + fullname + "&cod=" + idMembershipDetail + "&description=" + description + "'>";
            cuerpo += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Validar pago<div></center>";
            cuerpo += "</a></div></center>";

            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '></p>";
            cuerpo += "<center>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente atravez de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</center>";
            cuerpo += "</div></center>";


            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>Cuenta Bancaria </p>";
            cuerpo += $"<center>BCP: N° {bankAccount} - Valle Encantado S.A.C</center>";
            cuerpo += "</div></center>";

            cuerpo += "<center><div style='width: 50%;display: flex;border-radius: 10px;margin: 11px;'>";
            //cuerpo += "<p style='margin-left: 10%;margin-right: 10%;'>Monto a depositar</p>";

            //cuerpo += $"<center style=' margin: 12px;'> {symbol} {amountRestn} ( {currencyCode} )</center>";
            cuerpo += "</div></center>";

            //cuerpo += "<center><img src='http://www.inresorts.club/Views/img/recibo.png' align='left' style='width: 100%'></center></div>";
            cuerpo += "<div style='margin-left: 9%;'>";
            cuerpo += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            cuerpo += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            cuerpo += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            cuerpo += "</div>";

            cuerpo += "</body>";
            cuerpo += "</html>";

            Email email = new Email();
            //string correoOamr = "samirpazo08@gmail.com";
            //var send = email.SubmitEmail(correoOamr, "[Detalle de Pago, Ribera del Rio - Inresorts] ", cuerpo);

            var send = email.SubmitEmail(correo, "[Detalle de Pago, Ribera del Rio - Inresorts]", cuerpo);
            string correoOamr = "omarurteaga@gmail.com";
            email.SubmitEmail(correoOamr, "[Detalle de Pago, Ribera del Rio - Inresorts]", cuerpo);

            Session.Contents.RemoveAll();
            return send;
        }

        #endregion
    }
}