using BussinesRules;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class AdvancePayWallet : System.Web.UI.Page
    {
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
                this.lblUser.Text = "Hola " + arrayLogin[0];
                this.lblUserName.Text = arrayLogin[0];
                if (arrayLogin.Length > 2)
                {
                    this.lblNumPartner.Text = "N° Asociado: " + arrayLogin[4];
                }
                // Imagen de PErfil
                var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                nombreu = arrayLogin[1];
                foreach (var fi2 in di1.GetFiles())
                {
                    var archivo = fi2.Name.Split('.');
                    name = archivo[archivo.Length - 2];
                    extension = archivo[archivo.Length - 1];
                    if (name == nombreu) { def = nombreu + "." + extension; }
                }
                if (!string.IsNullOrEmpty(def))
                {
                    imgProfile.ImageUrl = "~/Resources/imguser/" + def;
                    imgProfile.Style.Add("width", "40px");
                    imgProfile.Style.Add("height", "40px");
                    imgProfile.Style.Add("margin", "0 auto");
                    imgProfileFl.ImageUrl = "~/Resources/imguser/" + def;
                    imgProfileFl.Style.Add("width", "80px");
                    imgProfileFl.Style.Add("height", "80px");
                    imgProfileFl.Style.Add("margin", "0 auto");

                }


                BrWallet brWallet = new BrWallet();
                var amountWallet = decimal.Parse(brWallet.GetAmount(arrayLogin[1]));
                Wallet.Text = $"Wallet : {amountWallet.ToString()}";

                var objadvancePay = Session["advancePay"];
                if (objadvancePay != null)
                {

                    var advancePay = (Dictionary<string, object>)Session["advancePay"];
                    var valueQuote = decimal.Parse(advancePay["ValueQuote"].ToString());
                    var numQuote = int.Parse(advancePay["NumQuote"].ToString());
                    var idMembership = int.Parse(advancePay["IdMembership"].ToString());
                    var currencyCode = advancePay["CurrencyCode"].ToString();
                    var typeChangeCro = decimal.Parse(advancePay["TypeChangeCro"].ToString());

                    var amountTotal = valueQuote * numQuote;


                    Description.Text = $"Adelanto de {numQuote} Cuotas con un valor de {valueQuote.ToString("0.00")} {currencyCode} cada una.";
                    Amount.Text = $"{amountTotal.ToString("0.00")} {currencyCode}";
                }

            }
        }

        protected void PayByWallet_Click(object sender, EventArgs e)
        {
            var arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            BrWallet brWallet = new BrWallet();
            BrTypeChange brTypeChange = new BrTypeChange();
            BrMembershipPayDetail payDetail = new BrMembershipPayDetail();

            var amountWallet = decimal.Parse(brWallet.GetAmount(arrayLogin[1]));
            var arrayTypes = brTypeChange.GetTypesChange().Split('|');
            var tcBuy = decimal.Parse(arrayTypes[1]);

            var objadvancePay = Session["advancePay"];
            if (objadvancePay == null)
            {
                MessageError.Text = "ocurrio un error";
                return;
            }

            var advancePay = (Dictionary<string, object>)Session["advancePay"];
            var valueQuote = decimal.Parse(advancePay["ValueQuote"].ToString());
            var numQuote = int.Parse(advancePay["NumQuote"].ToString());
            var idMembership = int.Parse(advancePay["IdMembership"].ToString());
            var currencyCode = advancePay["CurrencyCode"].ToString();
            var typeChangeCro = decimal.Parse(advancePay["TypeChangeCro"].ToString());

            var amountTotal = valueQuote * numQuote;

             
            if (currencyCode == "PEN")
            {
                amountTotal = amountTotal / tcBuy;
            }

            if (amountWallet < amountTotal)
            {
                MessageError.Text = "wallet insuficiente";
                return;
            }

            var answer = brWallet.PutAdvancePay(amountTotal * tcBuy, tcBuy, arrayLogin[1], idMembership);
            if (!answer)
            {
                MessageError.Text = "ocurrio un error.";
                return;
            }

            var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-'); ;
            string date = dateCurrent[2] + " de " + GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];
            var hour = DateTime.Now.ToShortTimeString();
            var description = amountTotal + " " + currencyCode;

            var nameImage = GetRecibo(arrayLogin[1], date, arrayLogin[0], hour, "Adelanto de Cuotas", description);

            bool responseb = payDetail.PutQuotes(idMembership, numQuote, nameImage, 2);
            string message = "";
            if (responseb)
            {
                message = "La operación se realizó con éxito.";
            }
            Response.Redirect("Payments.aspx?msg=" + message);

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