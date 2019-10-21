using Microsoft.Reporting.WebForms;
using System;
using System.IO;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class VisorStandBy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    string titular = "", dnititular = "", cotitular = "", dnicotitular = "", celular = "", correo = "";
                    string direccion = "", distrito = "", estadocivil = "", ocupacion = "", tipocambio = "", soles = "", patrocinador = "" ;
                    string dolares = "", efectivo = "", tarjeta = "", tranferencia = "";
                    string userName = "", fecha = "";

                    var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-'); ;

                    fecha = dateCurrent[2] + " " + dateCurrent[1] + " " + dateCurrent[0];

                    string currencyCode = Session["TypeCurrency"].ToString();

                    estadocivil = Session["CivilState"].ToString().ToUpper().Trim();

                    string[] datos = Session["datos"].ToString().Split('$');
                    string[] carrito = Session["carrito"].ToString().Split('|');
                    string[] cronograma;

                    int flag = 0;
                    string test = (string)Session["cronograma"];
                    if (!string.IsNullOrEmpty(test))
                    {
                        cronograma = Session["cronograma"].ToString().Split('|');
                        dolares = ((Double.Parse(cronograma[0])).ToString());
                        flag++;
                    }

                    string[] arrayperson = datos[0].Split('|');
                    string[] arraycoperson = datos[1].Split('|');
                    string[] arraycontacto = datos[3].Split('|');

                    tipocambio = carrito[4];
                    double typeChange = double.Parse(tipocambio);
                    //numerodecuotas = carrito[2];
                    titular = arrayperson[0].ToUpper() + " " + arrayperson[1].ToUpper();
                    dnititular = arrayperson[5];

                    userName = arrayperson[0].Substring(0, 1).ToUpper() + arrayperson[1].Substring(0, 1).ToUpper() + dnititular;
                    direccion = arraycontacto[6].ToUpper();
                    distrito = arraycontacto[5].ToUpper();
                    correo = arraycontacto[0];
                    celular = arraycontacto[1];

                    cotitular = arraycoperson[0].ToUpper().Trim() + " " + arraycoperson[1].ToUpper().Trim();
                    dnicotitular = arraycoperson[3].Trim();
                    patrocinador = Session["patrocinador"].ToString();


                    soles = (double.Parse(dolares) * double.Parse(tipocambio)).ToString("0.00");

                    efectivo = "";
                    tarjeta = "";
                    tranferencia = "";

                    ReportParameter[] parametros = new ReportParameter[17];
                    parametros[0] = new ReportParameter("titular", titular);
                    parametros[1] = new ReportParameter("dnititular", dnititular);
                    parametros[2] = new ReportParameter("cotitular", cotitular);
                    parametros[3] = new ReportParameter("dnicotitular", dnicotitular);
                    parametros[4] = new ReportParameter("celular", celular);
                    parametros[5] = new ReportParameter("correo", correo);
                    parametros[6] = new ReportParameter("direccion", direccion);
                    parametros[7] = new ReportParameter("distrito", distrito);
                    parametros[8] = new ReportParameter("estadocivil", estadocivil);
                    //parametros[9] = new ReportParameter("ocupacion", ocupacion);
                    parametros[9] = new ReportParameter("tipocambio", tipocambio);
                    parametros[10] = new ReportParameter("soles", soles);
                    parametros[11] = new ReportParameter("dolares", dolares);
                    parametros[12] = new ReportParameter("efectivo", efectivo);
                    parametros[13] = new ReportParameter("tarjeta", tarjeta);
                    parametros[14] = new ReportParameter("transferencia", tranferencia);
                    parametros[15] = new ReportParameter("fecha", fecha);
                    parametros[16] = new ReportParameter("patrocinador", patrocinador);
                    
                    reportViewer1.LocalReport.SetParameters(parametros);
                    reportViewer1.LocalReport.Refresh();


                byte[] bytes = reportViewer1.LocalReport.Render("PDF");
                string correlativo = "";
                correlativo = "0";
                string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/" + "CON" + userName + correlativo);
                string datecur = DateTime.Now.ToString("yyyy;MM;dd;hh;mm;ss;fff");
                string destin = HttpContext.Current.Server.MapPath("~/Resources/trash/") + "PAG" + userName + correlativo + datecur + ".pdf";
                if (File.Exists(ruta))
                {
                    File.Move(ruta, destin);
                }
                using (FileStream fs = new FileStream(ruta + ".pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    string error = ex.Message;
            //}
        }
    }
}