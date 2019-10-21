
namespace MULTI_NIVEL.Views
{
    using Entities;
    using Microsoft.Reporting.WebForms;
    using System;
    using System.IO;
    using System.Web;

    public partial class VysorRCI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nombre = "", fecnac = "", direccion = "", pais = "", provincia = "", ciudad = "", correo = "", dni = "", username = "";
                string conombre = "", coBirthDay = "__________", celular = "__________";

                //Session["datos"] = "Nombre|Apellidos|birthDay|M|DocumentType|NroDoc$NombreC|ApellidoC|1|313231c|birthDay$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$email|nroCell|nroCell2|country|State|City|Adress";
                //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";
                //Session["cronograma"] = "6000|222";

                string[] datos = Session["datos"].ToString().Split('$');
                string[] carrito = Session["carrito"].ToString().Split('|');
                string[] cronograma = Session["cronograma"].ToString().Split('|');

                string[] arrayperson = datos[0].Split('|');
                string[] arraycoperson = datos[1].Split('|');
                string[] arraycontacto = datos[3].Split('|');

                nombre = arrayperson[0] + " " + arrayperson[1];
                dni = arrayperson[5];
                username = (arrayperson[0].Substring(0, 1).ToUpper() + arrayperson[1].Substring(0, 1).ToUpper() + dni).ToUpper();
                fecnac = arrayperson[2];
                direccion = arraycontacto[6];
                pais = arraycontacto[3];
                provincia = arraycontacto[4];
                ciudad = arraycontacto[5];
                correo = arraycontacto[0];

                if (!string.IsNullOrEmpty(arraycontacto[1]))
                {
                    celular = arraycontacto[1];
                }

                conombre = arraycoperson[0].ToUpper() + " " + arraycoperson[1].ToUpper();

                if (!string.IsNullOrEmpty(arraycoperson[4]))
                {
                    coBirthDay = arraycoperson[4];
                }

                ReportParameter[] parametros = new ReportParameter[10];
                parametros[0] = new ReportParameter("nombre", nombre.ToUpper());
                parametros[1] = new ReportParameter("fecnac", fecnac);
                parametros[2] = new ReportParameter("direccion", direccion.ToUpper());
                parametros[3] = new ReportParameter("pais", pais.ToUpper());
                parametros[4] = new ReportParameter("provincia", provincia.ToUpper());
                parametros[5] = new ReportParameter("ciudad", ciudad.ToUpper());
                parametros[6] = new ReportParameter("correo", correo);
                parametros[7] = new ReportParameter("conombre", conombre);
                parametros[8] = new ReportParameter("birthdaydateCa", coBirthDay);
                parametros[9] = new ReportParameter("celular", celular);
                

                reportViewer1.LocalReport.SetParameters(parametros);
                reportViewer1.LocalReport.Refresh();

                //PrintDialog printDialog = new PrintDialog(reportViewer1.LocalReport);
                //printDialog.DocumentName = "CONTRATO_RCI.pdf";
                //printDialog.Print();

                byte[] bytes = reportViewer1.LocalReport.Render("PDF");
                string correlativo = "";
                correlativo = Session["correlativoDoc"].ToString();
                string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/" + "RCI" + username + correlativo);
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