
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using Entities;
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text.pdf;
    using System;
    using System.IO;
    using System.Web;

    public partial class PayOnLineQuoteC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var arrayLogin = User.Identity.Name.Split('¬');
            var token = string.Empty;
            var numberQuotes = 0;
            int id = 0;

            token = Request["TokenId"];
            numberQuotes = int.Parse(Request["ddlQuote"]);
            var currencyCodePay = Request["ddlcurrencyCode"].ToString().Trim();


            var amountPay = 0d;
            var currencyCodecro = string.Empty;

            if (Session["quotePay"] != null)
            {
                amountPay = double.Parse(Session["quotePay"].ToString());
            }
            if (Session["CurrencyCode"] != null)
            {
                currencyCodecro = Session["CurrencyCode"].ToString();
            }

            id = int.Parse(Session["IdImg"].ToString());

            BrTypeChange brTypeChange = new BrTypeChange();
            MyConstants mc = new MyConstants();
            PayCulqi payCulqi = new PayCulqi();
            MyFunctions mf = new MyFunctions();

            var arrayTypes = brTypeChange.GetTypesChange().Split('|');
            var tcSale = double.Parse(arrayTypes[0]);
            var tcBuy = double.Parse(arrayTypes[1]);

            var tcCro = double.Parse(Session["tcCro"].ToString());

            if (currencyCodecro == "USD")
            {
                if (currencyCodePay == "PEN")
                {
                    amountPay = amountPay * tcSale;
                }
            }

            if (currencyCodecro == "PEN")
            {
                if (currencyCodePay == "USD")
                {
                    amountPay = amountPay * tcCro;
                }
            }

            var amountTotal = amountPay * double.Parse((1 + mc.Surcharge).ToString());

            amountTotal = double.Parse(amountTotal.ToString("0.00"));

            var respoonsePay = payCulqi.newPayment(arrayLogin[1], arrayLogin[8], amountTotal, token, numberQuotes, currencyCodecro).Split('¬');

            var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-'); ;
            string date = dateCurrent[2] + " de " + GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];
            var hour = DateTime.Now.ToShortTimeString();
            var description = amountTotal + " " + currencyCodePay + " Atravez de Culqi.";
            var ticketImage = GetRecibo(arrayLogin[1], date, mf.ToCapitalize(arrayLogin[0]), hour, "Pago de Cuota", description);

            string answer = "";
            if (respoonsePay[0] == "true")
            {
                BrMembershipPayDetail brMembershipPayDetail = new BrMembershipPayDetail();

                var answerPay = brMembershipPayDetail.PayQuote(id, arrayLogin[1], ticketImage);
                answer = "true";
            }

            Response.Write(answer);
        }

        #region Metods
        public string GetRecibo(string username, string date, string namePeson, string hour, string concepto, string amountCC)
        {
            string fechaVar = DateTime.Now.ToString("yyyyMMddHHmmss");
            string nameTicket = username + "_" + fechaVar;
            string dni = username.Substring(2, (username.Length - 2));
            using (Document document = new Document(PageSize.A4, 10, 10, 10, 10))
            {
                string rutaImg = HttpContext.Current.Server.MapPath("~/Resources/Images/");
                string ruta = HttpContext.Current.Server.MapPath("~/Resources/RecibosRegister/") + nameTicket + ".pdf";
                FileStream stream = new FileStream(ruta, FileMode.Create);
                PdfWriter.GetInstance(document, stream);
                document.Open();


                string cadenfinal = string.Empty;
                cadenfinal += "<!DOCTYPE html ><html><head><title></title></head><body>";
                cadenfinal += "<div style='font-family: sans-serif;display: block;padding:20px;margin:10px auto;width:700px;height: 700px;background-color: white;'>";
                //cadenfinal += "<img src='" + rutaImg + "rec.png' style='position: absolute;top: 24%;left:28%;opacity: 0.1;z-index:1;width:515px;'/>";
                //cadenfinal += "<div style='display:flex;justify-content:space-between;text-align:center;' >";
                //cadenfinal += "<img src='" + rutaImg + "rec.png'/>";
                //cadenfinal += "<div><div style='font-size: 24px' ><b> RECIBO </b> Nro. 002044 </div><label> 20 de marzo del 2019 </label></div></div>";

                cadenfinal += "<div style='display:block;margin:10px auto;text-align: center;' ><h2><b> VALLE ENCANTADO S.A.C </b></h2>";
                cadenfinal += "<h4><b> RUC 20601460271 </b></h4></div><div style='display: flex;justify-content: space-between;'>";
                //cadenfinal += "<div style='display:block' ><div style='margin:5px 0'><b> Nro. MEMBRESIA:</b> AR00101 </div>";
                cadenfinal += "<div style='display:block' ><div style='margin:5px 0'><b> Codigo:</b> " + username + " </div>";
                cadenfinal += "<label><b> Nombre: </b> " + namePeson.ToUpper() + "</label></div><div><div><b> Codido Membresia: </b></div>";
                cadenfinal += "<label><b> DNI: </b> " + dni + " </label></div></div><div style = 'margin:15px auto;'><label><B> Codigo de operacion: </B></label>";
                cadenfinal += "</div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Fecha: </b>" + date + " HORA: " + hour + " </div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Concepto: </b> " + concepto + " </div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Monto: </b>" + amountCC + " </div>";
                cadenfinal += "<div style='margin: 15px auto' ><b>  </b> </div>";
                cadenfinal += "<center><img src='" + rutaImg + "rec.png' style='position: absolute;top: 24%;left:28%;opacity: 0.1;z-index:1;width:515px;'></center>";

                cadenfinal += "</div></body></html>";

                var parsehtml = HTMLWorker.ParseToList(new StringReader(cadenfinal), null);

                foreach (var htmlElement in parsehtml)
                {
                    document.Add(htmlElement as IElement);
                }
                document.Close();

            }
            return nameTicket + ".pdf";
        }

        private string GetMonth(string _months)
        {
            int _month = int.Parse(_months);
            string month = "";
            if (_month == 1)
            {
                month = "Enero";
            }
            if (_month == 2)
            {
                month = "Febrero";
            }
            if (_month == 3)
            {
                month = "Marzo";
            }
            if (_month == 4)
            {
                month = "Abril";
            }
            if (_month == 5)
            {
                month = "Mayo";
            }
            if (_month == 6)
            {
                month = "Junio";
            }
            if (_month == 7)
            {
                month = "Julio";
            }
            if (_month == 8)
            {
                month = "Agosto";
            }
            if (_month == 9)
            {
                month = "Septiembre";
            }
            if (_month == 10)
            {
                month = "Octubre";
            }
            if (_month == 11)
            {
                month = "Noviembre";
            }
            if (_month == 12)
            {
                month = "Diciembre";
            }
            return month;
        }
        #endregion


    }
}