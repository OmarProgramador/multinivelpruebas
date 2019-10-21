using BussinesRules;
using BussinesRules.TypeMembership;
using BussinesRules.User;
using Entities;
using System;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class AddMembPayDeposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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


                    var typeChange = decimal.Parse(User.Identity.Name.Split('¬')[5]);


                    string currencyCode = Session["TypeCurrency"].ToString();

                    string showReport = Session["cronogramaYa"].ToString();
                    string[] macro = showReport.Split('^');
                    string[] micro = macro[1].Split('¬');

                    decimal quoteReference = 0;

                    for (int i = 0; i <= micro.Length; i++)
                    {
                        string[] listRegisters = micro[i].Split('|');

                        if (listRegisters[0] == "Inicial nro: 1")
                        {
                            quoteReference += decimal.Parse(listRegisters[5].Replace("S/. ", ""));
                            break;
                        }
                        if (listRegisters[0] == "Upgrade")
                        {
                            quoteReference += decimal.Parse(listRegisters[5].Replace("S/. ", ""));
                            //break;
                        }
                    }
                    decimal amountTotal = quoteReference;
                    if (currencyCode == "USD")
                    {
                        amountTotal = amountTotal / typeChange;
                    }
                    lblAmount.Text = Math.Floor(amountTotal).ToString("###,###,##0.00");

                    BrTypeChange brTypeChange = new BrTypeChange();
                    var arrayTypes = brTypeChange.GetTypesChange().Split('|');
                    decimal typeChangeCompra = decimal.Parse(arrayTypes[0]);

                    Typechange.Text = typeChangeCompra.ToString();
                }
            }
            catch (Exception ex)
            {
                MyConstants mc = new MyConstants();
                Email email = new Email();
                email.SendEmail(mc.ErrorEmail, "error-inresorts", ex.StackTrace + '¬' + DateTime.Now.ToLongDateString(), false);

            }
        }

        protected void btnEnviarAhora_Click(object sender, EventArgs e)
        {
            if (!fuRecibo.HasFile)
            {
                //no hay imagen en el control
                return;
            }
            //si hay una archivo.
            string dataPerson = Session["datos"].ToString();
            string[] parameterPerson = dataPerson.Split('$');
            string[] arraydata = parameterPerson[0].Split('|');
            string[] arraynombreArchivo2 = fuRecibo.FileName.Split('.');

            int indice = (arraynombreArchivo2.Length - 1);

            string extension = arraynombreArchivo2[indice];

            string nombreArchivo = arraydata[5] + "." + extension;
            string ruta = "~/Resources/RecibosRegister/" + nombreArchivo;
            fuRecibo.SaveAs(Server.MapPath(ruta));
            RegisterMembership(nombreArchivo);
            Response.Redirect("EndPayments2.aspx");
        }

        protected void btnEnviarDespues_Click(object sender, EventArgs e)
        {
            string option = "";
            option = Session["option"].ToString();

            if (option == "ug" || option == "np")
            {
                return;
            }
            RegisterMembership(null);
            Response.Redirect("EndPayments3.aspx");
        }

        #region Methods

        public void RegisterMembership(string nameImages)
        {
            BrPayments brPayments = new BrPayments();
            BrUser brUser = new BrUser();
            BrTypeMembership brTypeMemb = new BrTypeMembership();

            string[] dataLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            string userName = dataLogin[0];

            if (dataLogin.Length > 1)
            {
                userName = dataLogin[1];
            }
            string dataBdd = Session["datos"].ToString();
            string[] acarrito = Session["carrito"].ToString().Split('|');
            string TypeMembership = acarrito[6];

            string cronograma = Session["cronograma"].ToString();
            //string respData = brPayments.PersonGetData(userName);
            string respData = "";
            respData = respData + '^' + cronograma;
            double amountFinanciade = 0;

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
                    amountFinanciade = double.Parse(fila[2].Replace("S/.", ""));
                    break;
                }
                else
                {
                    cronoActiv += DateTime.Parse(fila[1]).ToString("yyyy-MM-dd") + "¬";
                }
            }

            string codeCurrency = Session["TypeCurrency"].ToString();

            int ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + userName, amountFinanciade.ToString(), Int32.Parse(Session["membPred"].ToString()), codeCurrency);

            bool isRegister = false;
            if (Session["codeUpgrate"] != null)
            {
                //si es upgrate
                string exchange = Session["carrito"].ToString().Split('|')[4];
                //ultParametroSinCalculoDePuntaje
                isRegister = brPayments.GetCalculatePaymentScheduleUpgrate(respData, userName, ansNmembershi, exchange, 0);
                if (!isRegister)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                    return;
                }

                if (Session["dateup"] != null)
                {
                    string dateup = Session["dateup"].ToString();
                    bool an = brPayments.PutDateUpgrate(ansNmembershi, dateup);
                }

            }
            else
            {
                //si no es upgrate
                string exchange = Session["carrito"].ToString().Split('|')[4];
                isRegister = brPayments.GetCalculatePaymentSchedule(respData, userName, ansNmembershi, exchange, 0);
                if (!isRegister)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                    return;
                }
                BrActivation brActivation = new BrActivation();
                bool registerActi = brActivation.PutCronograma(cronoActiv, userName, ansNmembershi);
            }

            if (Session["codeUpgrate"] != null)
            {
                int codeUpgrate = int.Parse(Session["codeUpgrate"].ToString());
                bool upgrate = brTypeMemb.CancelMembershipUpgrate(codeUpgrate, ansNmembershi);
                if (!upgrate)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                    return;
                }
                BrActivation brActivation = new BrActivation();
                string fechaAnterior = Session["fechaanterior"].ToString();
                bool registerActi = brActivation.PutCronogramaUpgrade(fechaAnterior, userName, ansNmembershi, codeUpgrate);


                //cambia el estado de la cuota upgrate y si el segundo parametro es 1 paga la primera cuota
                BrMembershipPayDetail brMembershipPayDetail = new BrMembershipPayDetail();
                isRegister = brMembershipPayDetail.UpgrateStatusPaymentInitial(ansNmembershi, 0, "upgrade.PNG");
            }

            if (nameImages != null)
            {
                bool upload = brPayments.UploadReceipt(ansNmembershi.ToString() + '|' + nameImages);
            }

            if (!isRegister)
            {
                Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                return;
            }

            brPayments = null;
            brUser = null;
        }


        #endregion
    }
}