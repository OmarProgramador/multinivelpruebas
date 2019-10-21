using BussinesRules;
using Entities;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class AdvancepayCulqiC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PayCulqi culqi = new PayCulqi();
                BrMembershipPayDetail payDetail = new BrMembershipPayDetail();
                string userName = "", email = "", token = "", typeMembresia = "", namePerson = "";
                int numberQuotes = 0;

                token = Request["token"] == null ? "" : Request["token"];
                numberQuotes = Request["numcuotes"] == null ? 0 : int.Parse(Request["numcuotes"]);

                if (string.IsNullOrEmpty(token) || numberQuotes <= 0 || numberQuotes >= 20)
                {
                    Response.Write("[{data:{'success':false,'message':'Ocurrio un error'}}]");
                    return;
                }

                if (Session["advancePay"] == null)
                {
                    Response.Write("[{data:{'success':false,'message':'Ocurrio un error'}}]");
                    return;
                }

                var data = (Dictionary<string, object>)Session["advancePay"];

                var action = data["Action"];
                var valueQuote = Convert.ToDouble(data["ValueQuote"]);
                var numQuote = Convert.ToDouble(data["NumQuote"]);
                var idMembership = Convert.ToInt32(data["IdMembership"]);

                var valueTotal = valueQuote * numQuote;

                userName = User.Identity.Name.Split('¬')[1].Trim();
                email = User.Identity.Name.Split('¬')[8].Trim();
                string currencyCode = "PEN";
                var response = culqi.newPayment(userName, email, valueTotal, token, numberQuotes, currencyCode).Split('¬');

                if (!bool.Parse(response[0]))
                {
                    Response.Write("[{data:{'success':false,'message':'Ocurrio un error'}}]");
                    return;
                }
                Session.RemoveAll();
                int numQuotes = int.Parse(numQuote.ToString());
                string nameImage = "";

                var info = payDetail.GetInfoForRecibo(idMembership).Split('|');

                if (info.Length > 1)
                {
                    typeMembresia = info[0].ToUpper();
                    namePerson = info[1].ToUpper();
                }
                else
                {
                    typeMembresia = userName;
                    namePerson = userName;
                }

                var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-');

                string tranferId = response[2] == null ? "" : response[2];
                string date = dateCurrent[2] + " de " + GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];

                string hour = DateTime.Now.ToString("HH:mm:ss");
                string detalle = valueTotal.ToString();
                string concepto = "Adelanto de " + numQuotes.ToString() + " cuotas.";
                nameImage = GetRecibo(tranferId, userName, date, typeMembresia, namePerson, hour, detalle, concepto);

                bool responseb = payDetail.PutQuotes(idMembership, numQuotes, nameImage, 1);

                Response.Write("[{data:{'success':true,'message':'" + response[1] + "'}}]");
            }
        }

        #region Methods
        public string GetRecibo(string tranferId, string username, string date, string typeMembresia, string namePerson, string hour, string detalle, string concepto)
        {
            string fechaVar = DateTime.Now.ToString("yyyyMMddHHmmss");
            string nameTicket = username + "_" + tranferId + fechaVar;
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
                cadenfinal += "<label><b> Nombre: </b> " + namePerson.ToUpper() + "</label></div><div><div><b> Codido Membresia: </b>" + typeMembresia + "</div>";
                cadenfinal += "<label><b> DNI: </b> " + dni + " </label></div></div><div style = 'margin:15px auto;'><label><B> Codigo de operacion: </B> " + tranferId + " </label>";
                cadenfinal += "</div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Fecha: </b>" + date + " HORA: " + hour + " </div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Concepto: </b>" + concepto + "</div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Monto: </b>" + detalle + " </div>";
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