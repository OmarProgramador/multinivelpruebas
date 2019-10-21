using BussinesRules.User;
using System;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using System.IO;

namespace MULTI_NIVEL.Views
{
    public partial class VysorCertificado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nombre = "", dni = "", domicilio = "", distrito = "";
                string top = "OK al 100%", username = "";
                string correlativo = "";
                correlativo =  Session["correlativoDoc"].ToString();
                ///*push*/
                //Session["datos"] = "William Alexander|Moreno Nava|birthDay|M|DocumentType|73680066$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$email|nroCell|nroCell2|country|State|City|Adress";
                //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";
                //Session["cronograma"] = "6000|222";

                string[] datos = Session["datos"].ToString().Split('$');
                string[] carrito = Session["carrito"].ToString().Split('|');
                string[] cronograma = Session["cronograma"].ToString().Split('|');

                string[] arrayperson = datos[0].Split('|');
                string[] arraycontacto = datos[3].Split('|');
                string totaldolares = cronograma[0];
                string primeracuota = carrito[3];
                string nameMembership = carrito[1].ToUpper();

                nombre = arrayperson[0] + " " + arrayperson[1];
                dni = arrayperson[5];
                username = (arrayperson[0].Substring(0,1).ToUpper() + arrayperson[1].Substring(0,1).ToUpper() + dni).ToUpper();

                
                domicilio = arraycontacto[6];
                distrito = arraycontacto[5];

                if (carrito[6] == "EXP")
                {
                    top = "Vigente a Partir del Pago de la Cuarta Cuota";
                }
                if (carrito[6] == "LHT")
                {
                    top = "Vigente a Partir del Pago de la Segunda Cuota";
                }


                ReportParameter[] parametros = new ReportParameter[5];
                parametros[0] = new ReportParameter("nombre", nombre.ToUpper());
                parametros[1] = new ReportParameter("dni", dni);
                parametros[2] = new ReportParameter("rci", top);
                parametros[3] = new ReportParameter("username", username);
                parametros[4] = new ReportParameter("nameMembership", nameMembership);
              

                ReportViewer1.LocalReport.SetParameters(parametros);
                ReportViewer1.LocalReport.Refresh();


                byte[] bytes = ReportViewer1.LocalReport.Render("PDF");

                string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/") + "CER" + username + correlativo;
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
                using (FileStream fs = new FileStream(ruta + ".pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}