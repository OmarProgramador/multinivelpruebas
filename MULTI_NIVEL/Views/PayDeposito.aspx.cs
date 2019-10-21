
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using BussinesRules.User;
    using Entities;
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text.pdf;
    using System;
    using System.IO;
    using System.Web;

    public partial class PayDeposito : System.Web.UI.Page
    {
        BrUser brUser;
        BrPayments brPayment;
        string newUserName = null;
        string nombreArchivo = "";
        double tipocambio = 0.00;
        int idMemberDetails = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                MyConstants mc = new MyConstants();

                LblBankAccount.Text = mc.BankAccount;
                LblBankAccountDolar.Text = mc.BankAccountDolar;
                LblInterbankAccount.Text = mc.InterbankAccount;
                LblInterbankAccountDolar.Text = mc.InterbankAccountDolar;

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

                if (!string.IsNullOrEmpty((string)Session["carrito"]))
                {
                    string currencyCode = Session["TypeCurrency"].ToString();
                    cc.Text = " " + currencyCode + " ";
                    decimal tipocambio = 0, amount = 0;

                    string[] acarrito = Session["carrito"].ToString().Split('|');


                    tipocambio = decimal.Parse(acarrito[4]);

                    Typechange.Text = tipocambio.ToString();

                    amount = decimal.Parse(Session["Amount"].ToString());

                    if (currencyCode == "USD")
                    {
                        amount = amount / tipocambio;
                    }

                    lblAmount.Text = amount.ToString();

                    if (Session["datos"] == null)
                    {
                        Response.Redirect("Index.aspx", true);
                    }
                }
                else
                {

                    //no tener la opcion de enviar despues cuando viene de pago
                    if (Session["StatusCalendar"] != null)
                    {
                        string currencyCode = Session["CurrencyCode"].ToString();
                        pnEnviarDesp.Style.Add("Display", "none");

                        string squotePay = Session["quotePay"].ToString().Replace("S/.", "");
                        decimal quotePay = decimal.Parse(squotePay);

                        cc.Text = " " + currencyCode + " ";
                        lblAmount.Text = quotePay.ToString();
                    }
                }
            }
        }

        protected void btnEnviarDespues_Click(object sender, EventArgs e)
        {
            #region Realizar Pago Link formpay 2

            string moneda = string.Empty;

            moneda = ddlMoneda.SelectedValue.Trim();

            Session["moneda"] = moneda;


            //validamos si viene por pagos no permitir enviar depues 
            if (Session["StatusCalendar"] != null)
            {
                return;
            }

            registerTodo(2);

            int nAfiliate = int.Parse(brUser.GetNafiliate(idMemberDetails));
            Cronograma2(nAfiliate);

            Response.Redirect("EndPayments3.aspx");
            #endregion
        }

        protected void btnEnviarAhora_Click(object sender, EventArgs e)
        {
            string moneda = string.Empty;

            moneda = ddlMoneda.SelectedValue.Trim();

            Session["moneda"] = moneda;

            //if (Session["JustKit"] != null)
            //{

            //string arrayKit = Session["arrayKit"].ToString() + "¬" + newUserName;
            ////'2018-10-19¬31¬31¬31¬userName'
            //string data3 = Session["financedAmount"].ToString();
            //Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, data3, 1);

            //if (ansNmembershi > 0)
            //{
            //    //GeneracionDePuntos
            //    bool isRegister = brUser.PutRegisterkIT(arrayKit, ansNmembershi);
            //}

            ////monto a pagar

            ///*subidaDeRecibo con newUserName*/
            //brUser = new BrUser();
            //BrPayments brPayments = new BrPayments();
            //bool upload = brPayments.UploadReceipt(ansNmembershi.ToString() + '|' + nombreArchivo);

            //bool UpdateD = brUser.UpdateInitialQuoteDescription(newUserName);

            //string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
            //if (username_idmen_amount_email.Length < 4)
            //{
            //    Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
            //    return;
            //}
            //idMemberDetails = int.Parse(username_idmen_amount_email[1]);

            //double amountPay = double.Parse(username_idmen_amount_email[2]);
            //string emailNewUser = username_idmen_amount_email[3];
            //username_idmen_amount_email = null;
            //}
            //else
            //{
            if (Session["datos"] != null)
            {
                string dataPerson = Session["datos"].ToString();
                int typeRegister = 0;
                typeRegister = int.Parse(Session["typeRegister"].ToString());
                if (typeRegister != 1)
                {
                    string dataMember = Session["cronograma"].ToString();

                    if (string.IsNullOrEmpty(dataPerson) || string.IsNullOrEmpty(dataMember))
                    {
                        Response.Redirect("Register.aspx");
                    }
                }
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
                string[] parameterPerson = dataPerson.Split('$');
                string[] arraydata = parameterPerson[0].Split('|');
                string[] arraynombreArchivo2 = fuRecibo.FileName.Split('.');

                int indice = (arraynombreArchivo2.Length - 1);

                string extension = arraynombreArchivo2[indice];

                nombreArchivo = arraydata[5] + "." + extension;

                string ruta = "~/Resources/RecibosRegister/" + nombreArchivo;
                fuRecibo.SaveAs(Server.MapPath(ruta));

                registerTodo(1);

                int nAfiliate = int.Parse(brUser.GetNafiliate(idMemberDetails));

                Cronograma2(nAfiliate);


                brPayment = new BrPayments();
                var log = HttpContext.Current.User.Identity.Name.Split('¬');

                Response.Redirect("EndPayments2.aspx", true);
            }
            else
            {
                var log = HttpContext.Current.User.Identity.Name.Split('¬');
                brUser = new BrUser();
                brPayment = new BrPayments();
                var nroDoc = brUser.getDoc(log[1]);

                if (!fuRecibo.HasFile)
                {
                    //no hay imagen en el control
                    return;
                }

                int id = int.Parse(Session["IdImg"].ToString());
                nombreArchivo = nroDoc + id.ToString() + "." + "jpg";
                string ruta = "~/Resources/RecibosRegister/" + nombreArchivo;
                fuRecibo.SaveAs(Server.MapPath(ruta));
                string Amount = "";
                if (!string.IsNullOrEmpty((string)Session["quotePay"]))
                {
                    Amount = (string)Session["quotePay"];
                }
                //TODO: la fecha de pago debe ser el dia que el usuario ingresas el voucher
                bool ans = brPayment.UploadReceiptCalendar(id.ToString() + '|' + nombreArchivo);
                Session.Remove("quotePay");
                Session.Remove("StatusCalendar");

                Response.Redirect("EndPayments2.aspx", true);
            }

            //}
        }

        public void registerTodo(int metodo)
        {
            brPayment = new BrPayments();
            brUser = new BrUser();
            int typeRegister = 0;
            if (Session["typeRegister"] == null)
                Session["typeRegister"] = 0;

            typeRegister = int.Parse(Session["typeRegister"].ToString());
            //REGISTER
            string[] dataLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            string userCurrent = dataLogin[0];

            if (dataLogin.Length > 1)
            {
                userCurrent = dataLogin[1];
            }
            string dataBdd = Session["datos"].ToString();
            string TypeMembership = (dataBdd.Split('$')[3]).Split('|')[7];

            if (!string.IsNullOrEmpty((string)Session["tienda"]))
            {
                if (Session["tienda"].ToString() != "1")
                {
                    string data2 = (string)Session["civilState"];
                    string[] oIdMembreship_amount = brUser.RegisterUser(dataBdd, data2).Split('¬');

                    if (oIdMembreship_amount.Length < 2)
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario");
                        return;
                    }
                    string[] array1 = Session["cronogramaYa"].ToString().Split('^');
                    string[] datosMem = array1[0].Split('|');
                    string[] array2 = array1[1].Split('~');
                    string[] cuotas = array2[0].Split('¬');
                    string cronoActiv = "";
                    for (int i = 0; i < cuotas.Length - 1; i++)
                    {
                        var fila = cuotas[i].Split('|');
                        if (fila[0].Substring(0, 7) != "Inicial")
                        {
                            cronoActiv += DateTime.Parse(fila[1]).ToString("yyyy-MM-dd");
                            //amountFinanciade = double.Parse(fila[2].Replace("S/.", ""));
                            break;
                        }
                        else
                        {
                            cronoActiv += DateTime.Parse(fila[1]).ToString("yyyy-MM-dd") + "¬";
                        }
                    }

                    string[] parameterPerson = dataBdd.Split('$');
                    string[] arraydata = parameterPerson[0].Split('|');
                    string[] arrayTypeaccount = parameterPerson[2].Split('|');
                    string[] arrayaccount = parameterPerson[3].Split('|');

                    string parameterAccount = arraydata[5].Trim() + "|" + arrayTypeaccount[7].Trim() + '|' + userCurrent + '|' + oIdMembreship_amount[0];

                    newUserName = brUser.GenerateAccount(parameterAccount);
                    bool notAvilable = brUser.NotAvailableUser(newUserName);
                    if (string.IsNullOrEmpty(newUserName))
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario");
                        return;
                    }


                    //END REGISTER
                    if (typeRegister == 1)
                    {
                        string arrayKit = Session["arrayKit"].ToString() + "¬" + newUserName;
                        //'2018-10-19¬31¬31¬31¬userName'
                        string data3 = Session["financedAmount"].ToString();
                        string codeCurrency = Session["TypeCurrency"].ToString();

                        Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, data3, 1, codeCurrency);

                        if (ansNmembershi > 0)
                        {
                            //GeneracionDePuntos
                            bool isRegister = brUser.PutRegisterkIT(arrayKit, ansNmembershi);
                        }

                        //monto a pagar

                        /*subidaDeRecibo con newUserName*/
                        brUser = new BrUser();
                        BrPayments brPayments = new BrPayments();
                        bool upload = brPayments.UploadReceipt(ansNmembershi.ToString() + '|' + nombreArchivo);
                        if (!string.IsNullOrEmpty(newUserName))
                        {
                            bool UpdateD = brUser.UpdateInitialQuoteDescription(newUserName);
                        }
                        else
                        {
                            bool UpdateD = brUser.UpdateInitialQuoteDescription(userCurrent);
                        }

                        BrActivation brActivation = new BrActivation();
                        bool registerActi = brActivation.PutCronograma(cronoActiv, newUserName, ansNmembershi);

                        string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                        if (username_idmen_amount_email.Length < 4)
                        {
                            Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                            return;
                        }
                        idMemberDetails = int.Parse(username_idmen_amount_email[1]);

                        double amountPay = double.Parse(username_idmen_amount_email[2]);
                        string emailNewUser = username_idmen_amount_email[3];
                        username_idmen_amount_email = null;
                    }

                    if (typeRegister == 2)
                    {
                        string dataKitMember = Session["cronograma"].ToString();
                        string date = dataKitMember.Split('$')[1];
                        BrPayments brPayments = new BrPayments();
                        string respData = brPayments.PersonGetData(newUserName);
                        respData = respData + '^' + dataKitMember;
                        brUser = new BrUser();
                        string data3 = Session["financedAmount"].ToString();
                        string codeCurrency = Session["TypeCurrency"].ToString();

                        Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, data3, 1, codeCurrency);
                        //GeneracionDePuntosConLaInicialDeLaMembresia
                        //string exchange2 = "";
                        var exchange = Session["exchange"];

                        bool isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName, ansNmembershi, exchange.ToString(), 0);
                        brUser = new BrUser();
                        //TODO: la fecha de pago debe ser el dia de subida del voucher
                        bool upload = brPayments.UploadReceipt(ansNmembershi.ToString() + '|' + nombreArchivo);


                        BrActivation brActivation = new BrActivation();
                        bool registerActi = brActivation.PutCronograma(cronoActiv, newUserName, ansNmembershi);



                        if (!isRegister)
                        {
                            Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                            return;
                        }
                        //obtengo el monto a pagar

                        string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                        if (username_idmen_amount_email.Length < 4)
                        {
                            Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                            return;
                        }
                        idMemberDetails = int.Parse(username_idmen_amount_email[1]);


                        date = null;
                        username_idmen_amount_email = null;
                        dataKitMember = null;
                        respData = null;
                    }
                }
            }
            else
            {

                //entra aqui pagar despues
                string data2 = (string)Session["civilState"];
                string[] oIdMembreship_amount = brUser.RegisterUser(dataBdd, data2).Split('¬');

                if (oIdMembreship_amount.Length < 2)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario");
                    return;
                }

                string[] parameterPerson = dataBdd.Split('$');
                string[] arraydata = parameterPerson[0].Split('|');
                string[] arrayTypeaccount = parameterPerson[2].Split('|');
                string[] arrayaccount = parameterPerson[3].Split('|');

                string parameterAccount = arraydata[5].Trim() + "|" + arrayTypeaccount[7].Trim() + '|' + userCurrent + '|' + oIdMembreship_amount[0];

                newUserName = brUser.GenerateAccount(parameterAccount);


                string dataKitMember = "";
                string date = "";
                if (!string.IsNullOrEmpty((string)Session["cronograma"]))
                {
                    dataKitMember = Session["cronograma"].ToString();
                    date = dataKitMember.Split('$')[1];
                }

                string[] array1 = Session["cronogramaYa"].ToString().Split('^');
                string[] datosMem = array1[0].Split('|');
                string[] array2 = array1[1].Split('~');
                string[] cuotas = array2[0].Split('¬');
                string cronoActiv = "";
                for (int i = 0; i < cuotas.Length - 1; i++)
                {
                    var fila = cuotas[i].Split('|');
                    if (fila[0].Substring(0, 7) != "Inicial")
                    {
                        cronoActiv += fila[1];
                        break;
                    }
                    else
                    {
                        cronoActiv += fila[1] + "¬";
                    }
                }

                BrPayments brPayments = new BrPayments();
                string respData = brPayments.PersonGetData(dataLogin[0]);
                respData = respData + '^' + dataKitMember;
                brUser = new BrUser();
                string financedAmountsa = Session["financedAmount"].ToString();
                string codeCurrency = Session["TypeCurrency"].ToString();

                Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, financedAmountsa, 1, codeCurrency);
                //GeneracionDePuntosConLaInicialDeLaMembresia
                string exchange = "";
                BrInformacion brInformacion = new BrInformacion();
                string[] info = brInformacion.GetInformation().Split('¬');



                if (!string.IsNullOrEmpty(info[1]))
                {
                    exchange = info[1];
                }
                else
                {
                    exchange = "0.00";
                }
                string currentUser = "";
                string[] arrayLink = Session["link"].ToString().Split('|');
                if (arrayLink.Length > 1)
                {
                    currentUser = arrayLink[0];
                }
                else
                {
                    currentUser = dataLogin[0];
                }

                bool isRegister = brPayments.GetCalculatePaymentSchedule(respData, currentUser, ansNmembershi, exchange, 0);

                BrActivation brActivation = new BrActivation();
                bool registerActi = brActivation.PutCronograma(cronoActiv, newUserName, ansNmembershi);

                /*subidaDeRecibo con newUserName*/
                if (!string.IsNullOrEmpty(nombreArchivo))
                {
                    brUser = new BrUser();
                    bool upload = brPayments.UploadReceipt(currentUser + '|' + nombreArchivo);
                    if (!string.IsNullOrEmpty(newUserName))
                    {
                        bool UpdateD = brUser.UpdateInitialQuoteDescription(newUserName);
                        //bool ans = brPayment.UploadReceiptCalendar(newUserName + '|' + nombreArchivo);
                    }
                    else
                    {
                        bool UpdateD = brUser.UpdateInitialQuoteDescription(userCurrent);
                        //bool ans = brPayment.UploadReceiptCalendar(newUserName + '|' + nombreArchivo);
                    }
                }

                if (!isRegister)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                    return;
                }
                return;
            }
            return;
            /*TRY MERGE*/
        }

        public void Cronograma2(int _nAfiliate)
        {
            string[] arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            string tipocambio = "", numerodecuotas = "", nombre = "", dni = "", domicilio = "", distrito = "", correo = "", telefono = "", codemem = "";

            string username = "", fecha = "";


            //Session["cronogramaya"] = "6857.5|6142.5|0|11/2/2018¬89.57|24|10|Mensual^Inicial nro: 1|11/2/2018|S/. 6857.5|S/. 715|S/. 0|S/. 715¬Inicial nro: 2|12/2/2018|S/. 6142.5|S/. 800|S/. 0|S/. 800¬Inicial nro: 3|1/2/2018|S/. 5342.5|S/. 1000|S/. 0|S/. 1000¬Cuota nro: 1|11/1/2018|S/. 4342.5|S/. 164.89|S/. 34.63|S/. 199.52¬Cuota nro: 2|12/1/2018|S/. 4177.61|S/. 166.21|S/. 33.31|S/. 199.52¬Cuota nro: 3|1/1/2019|S/. 4011.4|S/. 167.53|S/. 31.99|S/. 199.52¬Cuota nro: 4|2/1/2019|S/. 3843.87|S/. 168.87|S/. 30.65|S/. 199.52¬Cuota nro: 5|3/1/2019|S/. 3675|S/. 170.22|S/. 29.3|S/. 199.52¬Cuota nro: 6|4/1/2019|S/. 3504.78|S/. 171.57|S/. 27.95|S/. 199.52¬Cuota nro: 7|5/1/2019|S/. 3333.21|S/. 172.94|S/. 26.58|S/. 199.52¬Cuota nro: 8|6/1/2019|S/. 3160.27|S/. 174.32|S/. 25.2|S/. 199.52¬Cuota nro: 9|7/1/2019|S/. 2985.95|S/. 175.71|S/. 23.81|S/. 199.52¬Cuota nro: 10|8/1/2019|S/. 2810.24|S/. 177.11|S/. 22.41|S/. 199.52¬Cuota nro: 11|9/1/2019|S/. 2633.13|S/. 178.52|S/. 21|S/. 199.52¬Cuota nro: 12|10/1/2019|S/. 2454.61|S/. 179.95|S/. 19.57|S/. 199.52¬Cuota nro: 13|11/1/2019|S/. 2274.66|S/. 181.38|S/. 18.14|S/. 199.52¬Cuota nro: 14|12/1/2019|S/. 2093.28|S/. 182.83|S/. 16.69|S/. 199.52¬Cuota nro: 15|1/1/2020|S/. 1910.45|S/. 184.29|S/. 15.23|S/. 199.52¬Cuota nro: 16|2/1/2020|S/. 1726.16|S/. 185.76|S/. 13.76|S/. 199.52¬Cuota nro: 17|3/1/2020|S/. 1540.4|S/. 187.24|S/. 12.28|S/. 199.52¬Cuota nro: 18|4/1/2020|S/. 1353.16|S/. 188.73|S/. 10.79|S/. 199.52¬Cuota nro: 19|5/1/2020|S/. 1164.43|S/. 190.24|S/. 9.29|S/. 199.52¬Cuota nro: 20|6/1/2020|S/. 974.19|S/. 191.75|S/. 7.77|S/. 199.52¬Cuota nro: 21|7/1/2020|S/. 782.44|S/. 193.28|S/. 6.24|S/. 199.52¬Cuota nro: 22|8/1/2020|S/. 589.16|S/. 194.82|S/. 4.7|S/. 199.52¬Cuota nro: 23|9/1/2020|S/. 394.34|S/. 196.38|S/. 3.14|S/. 199.52¬Cuota nro: 24|10/1/2020|S/. 197.96|S/. 197.94|S/. 1.58|S/. 199.52¬~446.01~4788.5";
            //Session["datos"] = "Nombre|Apellidos|birthDay|M|DocumentType|NroDoc$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$email|nroCell|nroCell2|country|State|City|Adress";
            //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";


            string[] datos = Session["datos"].ToString().Split('$');
            string[] carrito = Session["carrito"].ToString().Split('|');
            string[] cronograma = Session["cronogramaYa"].ToString().Split('|');

            string[] arrayperson = datos[0].Split('|');
            string[] arraycontacto = datos[3].Split('|');
            string totaldolares = cronograma[0];
            string primeracuota = carrito[3];
            tipocambio = carrito[4];
            numerodecuotas = carrito[2];
            codemem = carrito[1];

            nombre = arrayperson[0].ToUpper() + " " + arrayperson[1].ToUpper();
            dni = arrayperson[5];
            username = (arrayperson[0].Substring(0, 1) + arrayperson[1].Substring(0, 1) + dni).ToUpper();

            domicilio = arraycontacto[6];
            distrito = arraycontacto[5];
            correo = arraycontacto[0];
            telefono = arraycontacto[1];

            fecha = DateTime.Now.ToString("dd-MM-yyyy");



            string[] array1 = Session["cronogramaYa"].ToString().Split('^');
            string[] datosMem = array1[0].Split('|');
            string[] array2 = array1[1].Split('~');

            string[] cuotas = array2[0].Split('¬');

            decimal totalpagar = 0, interestotal = 0, importefinanciado = 0, porcefinanciado = 0;
            int ncuotas = 0, interruptor = 0;

            for (int i = 0; i < cuotas.Length - 1; i++)
            {
                var fila = cuotas[i].Split('|');
                if (fila[0].Substring(0, 7) != "Inicial")
                {
                    totalpagar += decimal.Parse(fila[5].Replace("S/.", ""));
                    interestotal += decimal.Parse(fila[4].Replace("S/.", ""));
                    ncuotas++;
                    if (interruptor != 1)
                    {
                        interruptor = 1;
                        importefinanciado = decimal.Parse(fila[2].Replace("S/.", ""));
                        Session["financedAmount"] = importefinanciado;
                    }
                }
            }
            porcefinanciado = (importefinanciado * 100) / decimal.Parse(datosMem[0]);


            using (Document document = new Document(PageSize.A4, 10, 10, 10, 10))
            {

                string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/") + "CRO" + username + ".pdf";

                FileStream stream = new FileStream(ruta, FileMode.Create);
                PdfWriter.GetInstance(document, stream);


                document.Open();

                string cadenfinal = string.Empty;
                cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 12pt;font-weight: bold;'>CRONOGRAMA DE PAGOS</div>";
                cadenfinal += "<p style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Número de Membresia: AR" + _nAfiliate.ToString("00000") + " </p>";
                cadenfinal += "<p style='font-family:cambria;font-size: 10pt;line-height:13px;'>Código: " + username + " </p>";
                //cadenfinal += "<p style='font-family:cambria;font-size: 10pt;line-height: 13px;'><b>Nombre:</b>" + datosMem[0] + "</p>";
                //cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Importe Membresia: S/. " + datosMem[0] + "</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Nombre del Cliente: " + nombre + " </p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Documento de Identidad: " + dni + "</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Correo Electronico: " + correo + " </p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Telefono de Contacto: " + telefono + " </p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Producto: Membresia " + codemem + "</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'> </p>";


                //
                cadenfinal += "<br/> <table ><tr>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Importe de la Membresia </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> S/." + datosMem[0] + "</td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>% Financiamiento </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + porcefinanciado.ToString("0.00") + "% </td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Importe Financiado </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> S/. " + importefinanciado + " </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Cuotas a Pagar </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + ncuotas + " </td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Cantidad Total a Pagar </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> S/. " + totalpagar + " </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Tasa Efectiva Anual </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> 10%</td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Monto total de Interes </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> S/. " + interestotal + " </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Periodicidad </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> Mensual </td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Fecha Emision Cronograma</td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + fecha + " </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> </td></tr>";
                cadenfinal += "</tr></table>";


                cadenfinal += "<table border='1' height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>";
                cadenfinal += "<tr height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>N°</th>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Vencimiento</th>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Capital</th>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Amortizacion</th>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Interes</th>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Cuota</th>";
                cadenfinal += "</tr>";

                for (int i = 0; i < cuotas.Length - 1; i++)
                {
                    var fila = cuotas[i].Split('|');
                    cadenfinal += "<tr height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + fila[0] + "</td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + DateTime.Parse(fila[1]).ToString("dd-MM-yyyy") + " </td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + fila[2] + "</td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + fila[3] + "</td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + fila[4] + "</td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + fila[5] + "</td>";

                    cadenfinal += "</tr>";
                }

                cadenfinal += "</table>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Este Cronograma se elabora bajo el supuesto cumpliento de pagos de las cuotas en las fechas indicadas.Cualquier alteracion en los pagos o en las condiciones del financiamiento,deja sin efecto este documento.</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>El atraso de una cuota mensual por mas de 8 días generará una penalidad de S/.30 soles.</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Si tuviera alguna consulta sirvase comunicarse con su asesor de membresías o a la línea de atención al cliente (01)-434-9481.</p>";

                cadenfinal += "<br />";
                cadenfinal += "<br />";
                cadenfinal += "<br />";

                cadenfinal += "<div style='text-align: right;'>";

                cadenfinal += "<div style='text-align: left;width: 200px;margin-left:100px' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_____________________________</div>";
                cadenfinal += "<div style='text-align: left;width: 200px;margin-left:100px'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Omar Urteaga Cabrera</div>";
                cadenfinal += "<div style='text-align: left;width: 200px;margin-left:100px'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Gerente General</div>";
                cadenfinal += "<div style='text-align: left;width: 200px;margin-left:100px'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ribera del Rio Club Resort</div>";
                cadenfinal += "</div>";


                var parsehtml = HTMLWorker.ParseToList(new StringReader(cadenfinal), null);

                foreach (var htmlElement in parsehtml)
                {
                    document.Add(htmlElement as IElement);

                }
                document.Close();

            }
        }

    }
}