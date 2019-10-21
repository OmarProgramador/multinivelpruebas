
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using BussinesRules.TypeMembership;
    using BussinesRules.User;
    using Entities;
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text.pdf;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Web;

    public partial class AddMembPolitics : System.Web.UI.Page
    {
        public string RutaUrlPagare { get; set; }
        public string RutaUrlCronog { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                //Response.Cache.SetAllowResponseInBrowserHistory(false);
                //Response.Cache.SetNoStore();
                string correlativo = "";
                string userName = "";
                //
                userName = User.Identity.Name.Split('¬')[1];
                BrTypeMembership brTypeMembership = new BrTypeMembership();
                correlativo = int.Parse(brTypeMembership.GetTotalMemberships(userName)).ToString();
                Session["correlativoDoc"] = correlativo;
                string currencyCode = Session["TypeCurrency"].ToString();

                Cronograma2(correlativo, currencyCode);
                Pagares2(correlativo, currencyCode);

                hlPagares.NavigateUrl = this.RutaUrlPagare;
                hlCronograma.NavigateUrl = this.RutaUrlCronog;
            }
        }

        protected void btnPolitics_Click(object sender, EventArgs e)
        {
            if (cbagree.Checked && cbagree2.Checked && cbagree3.Checked && cbagree4.Checked && cbagree5.Checked)
            {
                if (IsInititalCero())
                {
                    //registrar con inicial cero
                    Session["typeBuy"] = "store";
                    RegisterMembership("upgrade.png");
                    Response.Redirect("EndPayments.aspx");
                }
                else
                {
                    Response.Redirect("AddMembPagos.aspx");
                }

            }
        }

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
                    // Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
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
                    //Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
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
                    //  Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                    return;
                }
                BrActivation brActivation = new BrActivation();
                string fechaAnterior = Session["fechaanterior"].ToString();
                bool registerActi = brActivation.PutCronogramaUpgrade(fechaAnterior, userName, ansNmembershi, codeUpgrate);

                //cambia el estado de la cuota upgrate y si el segundo parametro es 1 paga la primera cuota
                BrMembershipPayDetail brMembershipPayDetail = new BrMembershipPayDetail();
                isRegister = brMembershipPayDetail.UpgrateStatusPaymentInitial(ansNmembershi, 0, "upgrade.png");
            }

            if (nameImages != null)
            {
                bool upload = brPayments.UploadReceiptUpgradeCerooInitial(ansNmembershi.ToString() + '|' + nameImages);
            }

            if (!isRegister)
            {
                //Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                return;
            }

            brPayments = null;
            brUser = null;

        }

        public bool IsInititalCero()
        {
            bool anwser = true;
            string[] array1 = Session["cronogramaYa"].ToString().Split('^');
            string[] datosMem = array1[0].Split('|');
            string[] array2 = array1[1].Split('~');

            string[] cuotas = array2[0].Split('¬');

            decimal totalpagar = 0, interestotal = 0, importefinanciado = 0, valorcuotas = 0;
            int ncuotas = 0, interruptor = 0;
            string fechacuotas = "";

            List<Pagare> listPagare = new List<Pagare>();
            for (int i = 0; i < cuotas.Length - 1; i++)
            {
                var fila = cuotas[i].Split('|');
                var descrip = fila[0].Substring(0, 7);
                //&& descrip != "Upgrade"
                if (descrip != "Inicial")
                {
                    if (descrip != "Upgrade")
                    {
                        totalpagar += decimal.Parse(fila[5].Replace("S/.", ""));
                        interestotal += decimal.Parse(fila[4].Replace("S/.", ""));
                        ncuotas++;

                        if (interruptor != 1)
                        {
                            interruptor = 1;
                            importefinanciado = decimal.Parse(fila[2].Replace("S/.", ""));
                            fechacuotas = DateTime.Parse(fila[1]).ToString("dd/MM/yyyy");
                            valorcuotas = decimal.Parse(fila[5].Replace("S/.", ""));
                        }
                    }
                }
              
                decimal cero = 0;
                decimal montoInter = decimal.Parse(fila[5].Replace("S/.", ""));

                MyFunctions mf = new MyFunctions();
                MyConstants mc = new MyConstants();

                var gFormat = CultureInfo.CreateSpecificCulture("en-EN");
                var date = DateTime.Parse(Convert.ToDateTime(fila[1]).ToString(mc.DateFormatBd));

                var datecurrent = DateTime.Parse(DateTime.Now.ToString(mc.DateFormatBd));

                if (date == datecurrent)
                {
                    if (montoInter > cero)
                    {
                        anwser = false;
                    }
                }

            }
            return anwser;
        }

        #region Doc
        public void Pagares2(string _correlativo, string _cc)
        {
            string[] arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            //Session["cronogramaya"] = "6857.5|6142.5|0|11/2/2018¬89.57|24|10|Mensual^Inicial nro: 1|11/2/2018|S/. 6857.5|S/. 715|S/. 0|S/. 715¬Inicial nro: 2|12/2/2018|S/. 6142.5|S/. 800|S/. 0|S/. 800¬Inicial nro: 3|1/2/2018|S/. 5342.5|S/. 1000|S/. 0|S/. 1000¬Cuota nro: 1|11/1/2018|S/. 4342.5|S/. 164.89|S/. 34.63|S/. 199.52¬Cuota nro: 2|12/1/2018|S/. 4177.61|S/. 166.21|S/. 33.31|S/. 199.52¬Cuota nro: 3|1/1/2019|S/. 4011.4|S/. 167.53|S/. 31.99|S/. 199.52¬Cuota nro: 4|2/1/2019|S/. 3843.87|S/. 168.87|S/. 30.65|S/. 199.52¬Cuota nro: 5|3/1/2019|S/. 3675|S/. 170.22|S/. 29.3|S/. 199.52¬Cuota nro: 6|4/1/2019|S/. 3504.78|S/. 171.57|S/. 27.95|S/. 199.52¬Cuota nro: 7|5/1/2019|S/. 3333.21|S/. 172.94|S/. 26.58|S/. 199.52¬Cuota nro: 8|6/1/2019|S/. 3160.27|S/. 174.32|S/. 25.2|S/. 199.52¬Cuota nro: 9|7/1/2019|S/. 2985.95|S/. 175.71|S/. 23.81|S/. 199.52¬Cuota nro: 10|8/1/2019|S/. 2810.24|S/. 177.11|S/. 22.41|S/. 199.52¬Cuota nro: 11|9/1/2019|S/. 2633.13|S/. 178.52|S/. 21|S/. 199.52¬Cuota nro: 12|10/1/2019|S/. 2454.61|S/. 179.95|S/. 19.57|S/. 199.52¬Cuota nro: 13|11/1/2019|S/. 2274.66|S/. 181.38|S/. 18.14|S/. 199.52¬Cuota nro: 14|12/1/2019|S/. 2093.28|S/. 182.83|S/. 16.69|S/. 199.52¬Cuota nro: 15|1/1/2020|S/. 1910.45|S/. 184.29|S/. 15.23|S/. 199.52¬Cuota nro: 16|2/1/2020|S/. 1726.16|S/. 185.76|S/. 13.76|S/. 199.52¬Cuota nro: 17|3/1/2020|S/. 1540.4|S/. 187.24|S/. 12.28|S/. 199.52¬Cuota nro: 18|4/1/2020|S/. 1353.16|S/. 188.73|S/. 10.79|S/. 199.52¬Cuota nro: 19|5/1/2020|S/. 1164.43|S/. 190.24|S/. 9.29|S/. 199.52¬Cuota nro: 20|6/1/2020|S/. 974.19|S/. 191.75|S/. 7.77|S/. 199.52¬Cuota nro: 21|7/1/2020|S/. 782.44|S/. 193.28|S/. 6.24|S/. 199.52¬Cuota nro: 22|8/1/2020|S/. 589.16|S/. 194.82|S/. 4.7|S/. 199.52¬Cuota nro: 23|9/1/2020|S/. 394.34|S/. 196.38|S/. 3.14|S/. 199.52¬Cuota nro: 24|10/1/2020|S/. 197.96|S/. 197.94|S/. 1.58|S/. 199.52¬~446.01~4788.5";
            //Session["datos"] = "Jorge Samir|Pazo Torres|birthDay|M|DocumentType|73680055$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$email|nroCell|nroCell2|country|State|City|Calle comercio 715 El Agustino";
            //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";
            string[] datos = Session["datos"].ToString().Split('$');
            string[] carrito = Session["carrito"].ToString().Split('|');
            string[] cronograma = Session["cronogramaYa"].ToString().Split('|');

            string[] arrayperson = datos[0].Split('|');
            string[] arraycontacto = datos[3].Split('|');
            string totaldolares = cronograma[0];
            string primeracuota = carrito[3];
            string tipocambio = carrito[4];
            decimal typeChange = decimal.Parse(tipocambio);
            string numerodecuotas = carrito[2];
            string codemem = carrito[6];


            Numalet numalet = new Numalet();
            MyFunctions mf = new MyFunctions();
            MyConstants mc = new MyConstants();


            //string fechaActual = DateTime.Now.ToLongDateString();
            var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-'); ;

            string fechaActual = dateCurrent[2] + " de " + mf.GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];


            var bankAccount = mc.BankAccount;

            string codigo = "";
            string nombre = "";
            string dni = "";
            string domicilio = "";
            string username = "";


            nombre = arrayperson[0].ToUpper() + " " + arrayperson[1].ToUpper();
            dni = arrayperson[5];
            username = (arrayperson[0].Substring(0, 1).ToUpper() + arrayperson[1].Substring(0, 1).ToUpper() + dni).ToUpper();

            dni = arrayperson[5];
            string userName = (arrayperson[0].Substring(0, 1) + arrayperson[1].Substring(0, 1) + dni).ToUpper();

            domicilio = arraycontacto[6];
            string distrito = arraycontacto[5];
            string correo = arraycontacto[0];
            string telefono = arraycontacto[1];

            string fecha = DateTime.Now.ToString("dd-MM-yyyy");

            string[] array1 = Session["cronogramaYa"].ToString().Split('^');
            string[] datosMem = array1[0].Split('|');
            string[] array2 = array1[1].Split('~');

            string[] cuotas = array2[0].Split('¬');

            decimal totalpagar = 0, interestotal = 0, importefinanciado = 0, porcefinanciado = 0, valorcuotas = 0;
            int ncuotas = 0, interruptor = 0;
            string fechacuotas = "";

            List<Pagare> listPagare = new List<Pagare>();
            for (int i = 0; i < cuotas.Length - 1; i++)
            {
                var fila = cuotas[i].Split('|');
                if (fila[0].Substring(0, 7) != "Inicial")
                {
                    if (fila[0].Substring(0, 7) != "Upgrade")
                    {
                        totalpagar += decimal.Parse(fila[5].Replace("S/.", ""));
                        interestotal += decimal.Parse(fila[4].Replace("S/.", ""));
                        ncuotas++;

                        if (interruptor != 1)
                        {
                            interruptor = 1;
                            importefinanciado = decimal.Parse(fila[2].Replace("S/.", ""));
                            fechacuotas = DateTime.Parse(fila[1]).ToString("dd/MM/yyyy");
                            valorcuotas = decimal.Parse(fila[5].Replace("S/.", ""));
                        }
                    }
                }
                else
                {
                    if (i != 0)
                    {
                        listPagare.Add(new Pagare
                        {
                            Id = 1,
                            Codigo = codigo,
                            NombreCompleto = nombre,
                            Dni = dni,
                            Domicilio = domicilio,
                            Fecha = fechaActual,
                            FechaCuotas = DateTime.Parse(fila[1]).ToString("dd/MM/yyyy"),
                            MontoSoles = decimal.Parse(fila[5].Replace("S/.", "")),
                            MontoSolesLetras = numalet.ToCustomCardinal(decimal.Parse(mf.GetAmountCurrency(fila[5].Replace("S/.", ""), _cc, typeChange))),
                            NCuotas = 1,
                            ValorCuotas = decimal.Parse(fila[5].Replace("S/.", ""))
                        });
                    }
                }
            }
            porcefinanciado = (importefinanciado * 100) / decimal.Parse(datosMem[0]);

            listPagare.Add(new Pagare
            {
                Id = 1,
                Codigo = codigo,
                NombreCompleto = nombre,
                Dni = dni,
                Domicilio = domicilio,
                Fecha = fechaActual,
                FechaCuotas = fechacuotas,
                MontoSoles = importefinanciado,
                MontoSolesLetras = numalet.ToCustomCardinal(double.Parse(mf.GetAmountCurrency(importefinanciado.ToString(), _cc, typeChange))),
                NCuotas = ncuotas,
                ValorCuotas = valorcuotas
            });


            using (Document document = new Document(PageSize.A4, 10, 10, 10, 10))
            {
                string datecur = DateTime.Now.ToString("yyyy;MM;dd;hh;mm;ss;fff");
                string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/") + "PAG" + username + _correlativo + ".pdf";
                this.RutaUrlPagare = "~/Resources/PoliticsPdf/" + "PAG" + username + _correlativo + ".pdf";
                string destin = HttpContext.Current.Server.MapPath("~/Resources/trash/") + "PAG" + username + _correlativo + datecur + ".pdf";
                if (File.Exists(ruta))
                {
                    File.Move(ruta, destin);
                }

                FileStream stream = new FileStream(ruta, FileMode.Create);
                PdfWriter.GetInstance(document, stream);

                document.Open();
                string cadenfinal = string.Empty;

                for (int i = 0; i < listPagare.Count; i++)
                {
                    cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 12pt;font-weight: bold;'>PAGARÉ CODIGO: " + userName.ToUpper() + "-" + (i + 1).ToString() + "</div>";
                    cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 10pt;font-weight: bold;'>POR UN VALOR DE( " + listPagare[i].MontoSolesLetras.ToUpper() + " " + _cc + " )</div>";
                    cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 10pt;font-weight: bold;'>( " + mf.GetAmountCurrency(listPagare[i].MontoSoles.ToString(), _cc, typeChange) + " " + _cc + " )ESTE VALOR ES EL SALDO A FINANCIAR</div>";
                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Yo <b>" + listPagare[i].NombreCompleto + "</b> identificado(a) con DNI Nº <b>" + listPagare[i].Dni + "</b> con domicilio y residencia en <b>" + listPagare[i].Domicilio + "</b>.</p>" +
                        "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Me comprometo a pagar incondicionalmente a VALLE ENCANTADO S.A.C " +
                        "la suma de <b>" + listPagare[i].MontoSolesLetras + " " + _cc + " ( " + mf.GetAmountCurrency(listPagare[i].MontoSoles.ToString(), _cc, typeChange) + " " + _cc + " ) </b> pagadero en <b>" + listPagare[i].NCuotas + "</b> cuotas mensuales y consecutivas con vencimiento la primera " +
                        "de ella el día <b>" + listPagare[i].FechaCuotas + "</b>, por valor de <b>( " + mf.GetAmountCurrency(listPagare[i].ValorCuotas.ToString(), _cc, typeChange) + " " + _cc + ")</b>.El pago de dichas cuotas se realizará en Soles a razón del cambio oficial vigente" +
                        " a la fecha en que se efectúe éste. En caso de mora y mientras ella subsista pagaré intereses moratorios a la tasa máxima establecida para" +
                        " el periodo correspondiente. De igual manera me obligo a pagar todos los gastos y costos de la cobranza judicial. </p>";
                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>En el evento en que el deudor no pague en el plazo" +
                        " estipulado una o más cuotas, el tenedor de este título podrá declarar vencidos todos los plazos de esta obligación y pedir su inmediato" +
                        " pago total o el pago del saldo.</p>";

                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>También acepto que <b>VALLE ENCANTADO S.A.C</b>, declare de plazo vencido la obligación a la que se refiere este pagaré y exigir su pago total en el evento en que sea perseguido judicialmente. El recibo de abono de parciales no implica novación y cualquier pago que se efectúe se imputará primero a gastos, penalidades, y por último a capital. El suscriptor de este pagaré hace constatar que la obligación de pagarla indivisiblemente y solidariamente subsiste en caso de prórroga o prórrogas o de cualquier modificación a lo estipulado. El deudor declara que la suma que debe conforme a este pagaré, no estará sujeta ni a deducción ni a descuentos de cualquier naturaleza, incluyendo sin limitación cualquier impuesto que pueda gravar su pago, por lo tanto, en caso de existir alguna de estas deducciones o descuentos, el deudor deberá aumentar la suma a pagar de tal manera que el tenedor reciba siempre el valor estipulado del pagaré. El deudor acepta desde ahora el endoso, cesión o transferencia que de este pagaré a VALLE ENCANTADO S.A.C. todos los gastos e impuestos relacionados con la suscripción de este pagaré serán por cuenta del deudor.</p>";
                    cadenfinal += $"<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Todos los pagos que deban hacerse según este pagaré serán hechos exclusivamente en Soles, a la<b> Cuenta Recaudadora Soles BCP N° {bankAccount}</b>, en su oficina central ubicada en Av. Guardia Civil 1321 oficina 602 – Surquillo o en Ribera del Río Club Resort ubicada en Mz. B Lt. 72. Tercera Etapa - Cieneguilla.</p>";
                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Todos los cálculos de intereses se efectuarán sobre la base de un año de trescientos sesenta (360) días, en cada caso por el número de días efectivamente transcurridos (incluyendo el primer día, pero excluyendo el último día) durante el pazo por el cual deban pagarse tale intereses. Si cualquiera de las fechas de pago de principal o intereses antes indicadas coincidiera con un día no hábil, se entenderá que el pago respectivo deberá ser efectuado el día hábil inmediatamente siguiente." +
                    "Cualquier referencia en este pagaré al agente deberá entenderse efectuada a cualquier tenedor del mismo, sea que lo adquiera por endoso o de otro modo.</p>";

                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>En caso de mora, no será necesario requerimiento alguno para que el Cliente incurra en la misma, de acuerdo a lo establecido en el artículo 1333 inciso 1 del Código Civil Peruano. En dicho caso, durante todo el periodo de incumplimiento el cliente pagara a una tasa equivalente al máximo de interés permitido por la ley, por concepto de interés moratorio.</p>";
                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>De conformidad con lo establecido por el artículo 158.2 concordante con el artículo 52° de la Ley de Títulos Valores, este pagaré no requerirá ser protestado por la falta de pago de cualquiera de las cuotas para ejercitar las acciones derivadas del mismo.</p>";
                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Adicionalmente, el cliente se obliga incondicionalmente a pagar al Agente todos los gastos en que éste incurra en razón de su incumplimiento, obligándose a pagar sobre éstos el mismo interés moratorio pactado en este pagaré.</p>";
                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Asimismo, el cliente acepta las renovaciones y prórrogas de vencimiento de este pagaré que el agente considere conveniente efectuar, ya sea por su importe parcial o total, aun cuando no hayan sido comunicadas al cliente. Dichas modificaciones serán anotadas en este mismo instrumento o en hoja anexa, sin que sea necesaria la suscripción de tal instrumento.</p>";

                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Este pagare se devolverá a su cancelación total. Queda expresamente establecido que el domicilio del cliente es <b>" + listPagare[i].Domicilio + " - Lima Perú</b>, lugar a donde se dirigirán todas las comunicaciones y notificaciones derivadas de este pagaré.</p>";
                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Queda establecido que las obligaciones contenidas en este pagaré, constituyendo el presente acuerdo pacto en contrario a lo dispuesto por el artículo 1233° del Código Civil.</p>";
                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Este pagaré se regirá bajo las leyes de la República del Perú.</p>";
                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Cualquier acción o procedimiento legal relacionado con y derivado del presente pagaré podrá ser iniciado ante los órganos judiciales del Cercado de Lima, Lima, Perú. El cliente renuncia a la jurisdicción de cualquier otro tribunal que pudiere corresponderle por cualquier otra razón.</p>";
                    cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>En constancia de lo anterior, se firma el presente pagaré el día <b>" + listPagare[i].Fecha + "</b> en la ciudad de Lima,El Deudor.</p>";

                    cadenfinal += "<br /><br /><br /><br />";
                    cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 10pt;line-height: 13px;'>______________________________</div>";
                    cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 10pt;line-height: 13px;'>FIRMA</div>";
                    cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 10pt;line-height: 13px;'>DNI:<b>" + listPagare[i].Dni + "</b></div>";
                    if (listPagare[i].Domicilio.Length < 30)
                    {
                        cadenfinal += "<br />";
                    }
                    cadenfinal += "<br />";
                }
                StyleSheet styleSheet = new StyleSheet();

                Dictionary<string, string> stylep = new Dictionary<string, string>()
                {
                    { "font-family","Calibri" },
                    { "text-align","justify" },
                    { "line-height","normal" },
                    { "font-size","10pt" }
                };

                styleSheet.ApplyStyle("p", stylep);


                var parsehtml = HTMLWorker.ParseToList(new StringReader(cadenfinal), styleSheet);

                foreach (var htmlElement in parsehtml)
                {
                    document.Add(htmlElement as IElement);
                }
                document.Close();
            }
        }

        public void Cronograma2(string _correlativo, string _cc)
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
            decimal typeChange = decimal.Parse(tipocambio);
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
            MyConstants myConstants = new MyConstants();
            MyFunctions mf = new MyFunctions();
            string[] cuotas = array2[0].Split('¬');

            decimal totalpagar = 0, interestotal = 0, importefinanciado = 0, porcefinanciado = 0;
            int ncuotas = 0, interruptor = 0;

            for (int i = 0; i < cuotas.Length - 1; i++)
            {
                var fila = cuotas[i].Split('|');
                if (fila[0].Substring(0, 7) != "Inicial")
                {
                    if (fila[0].Substring(0, 7) != "Upgrade")
                    {
                        totalpagar += decimal.Parse(fila[5].Replace("S/.", ""));
                        interestotal += decimal.Parse(fila[4].Replace("S/.", ""));
                        ncuotas++;
                    }
                    if (interruptor != 1)
                    {
                        interruptor = 1;
                        importefinanciado = decimal.Parse(fila[2].Replace("S/.", ""));
                        Session["financedAmount"] = importefinanciado;
                    }
                }
            }
            porcefinanciado = (importefinanciado * 100) / decimal.Parse(datosMem[0]);
            decimal totalPagarDolar = totalpagar / typeChange;
            using (Document document = new Document(PageSize.A4, 10, 10, 10, 10))
            {
                string datecur = DateTime.Now.ToString("yyyy;MM;dd;hh;mm;ss;fff");
                string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/") + "CRO" + username + _correlativo + ".pdf";
                string destin = HttpContext.Current.Server.MapPath("~/Resources/trash/") + "CRO" + username + _correlativo + datecur + ".pdf";
                this.RutaUrlCronog = "~/Resources/PoliticsPdf/" + "CRO" + username + _correlativo + ".pdf";
                if (File.Exists(ruta))
                {
                    File.Move(ruta, destin);
                }

                FileStream stream = new FileStream(ruta, FileMode.Create);
                PdfWriter.GetInstance(document, stream);
                document.Open();

                string cadenfinal = string.Empty;
                cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 12pt;font-weight: bold;'>CRONOGRAMA DE PAGOS</div>";
                cadenfinal += "<p style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Código: " + username + " </p>";
                //cadenfinal += "<p style='font-family:cambria;font-size: 10pt;line-height: 13px;'><b>Nombre:</b>" + datosMem[0] + "</p>";
                //cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Importe Membresia: S/. " + datosMem[0] + "</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Nombre del Cliente: " + nombre + " </p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Documento de Identidad: " + dni + "</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Correo Electronico: " + correo + " </p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Telefono de Contacto: " + telefono + " </p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Producto: Membresia " + codemem + "</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'> </p>";

                cadenfinal += "<br/> <table ><tr>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Importe de la Membresia </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + mf.GetAmountCurrency(datosMem[0], _cc, typeChange) + " " + _cc + "</td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>% Financiamiento </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + porcefinanciado.ToString("0.00") + "% </td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Importe Financiado </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + mf.GetAmountCurrency(importefinanciado.ToString(), _cc, typeChange) + " " + _cc + " </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Cuotas a Pagar </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + ncuotas + " </td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Cantidad Total a Pagar </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + mf.GetAmountCurrency(totalpagar.ToString(), _cc, typeChange) + " " + _cc + " </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Tasa Efectiva Anual </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + myConstants.AmountInteresAnual.ToString() + "%</td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Monto total de Interes </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + mf.GetAmountCurrency(interestotal.ToString(), _cc, typeChange) + " " + _cc + " </td>";
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
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + mf.GetAmountCurrency(fila[2].Replace("S/.", ""), _cc, typeChange) + " " + _cc + "</td>";

                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + mf.GetAmountCurrency(fila[3].Replace("S/.", ""), _cc, typeChange) + " " + _cc + "</td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + mf.GetAmountCurrency(fila[4].Replace("S/.", ""), _cc, typeChange) + " " + _cc + "</td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + mf.GetAmountCurrency(fila[5].Replace("S/.", ""), _cc, typeChange) + " " + _cc + "</td>";
                    
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
        #endregion
    }
}