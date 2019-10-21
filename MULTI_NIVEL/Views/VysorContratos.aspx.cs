
namespace MULTI_NIVEL.Views
{
    using System;
    using System.IO;
    using System.Web;
    using BussinesRules;
    using BussinesRules.User;
    using Entities;
    using Microsoft.Reporting.WebForms;

    public partial class VysorContratos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string nombre = "", dni = "", domicilio = "", distrito = "", memexp = " ", memmvc = " ", memlight = " ", memsta = " ", memplus = " ", memtop = " ", memvit = " ";
                    string duracion = "", fechafin = "", montototaldolareletras = "", tipocambio = "", montototalsoles = "", numerodecuotas = "", opcontado = "", op6cuotas = "", op12cuotas = "";
                    string op24cuotas = "", op36cuotas = "", op48cuotas = "", op60cuotas = "", opotros = "", porcentajefinan = "", porprimcuo = "", soles6cuotas = "", soles12cuotas = "", soles24cuotas = "", soles36cuotas = "", soles48cuotas = "";
                    string soles60cuotas = "", solesotros = " Otros";
                    string code = "", username = "";
                    string coname = "",  civilState = "";
                    string memevolu = " ";
                    /*push*/
                    //Session["datos"] = "Nombre|Apellidos|birthDay|M|DocumentType|NroDoc$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$email|nroCell|nroCell2|country|State|City|Adress";
                    //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";
                    //Session["cronograma"] = "6000|222";

                    string currencyCode = Session["TypeCurrency"].ToString();

                    civilState = Session["CivilState"].ToString().ToUpper();

                    string[] datos = Session["datos"].ToString().Split('$');
                    string[] carrito = Session["carrito"].ToString().Trim().Split('|');
                    string[] cronograma;
                    string totaldolares = "";
                    int flag = 0;
                    string test = (string)Session["cronograma"];
                    if (!string.IsNullOrEmpty(test))
                    {
                        cronograma = Session["cronograma"].ToString().Split('|');
                        totaldolares = ((Double.Parse(cronograma[0])).ToString());
                        flag++;
                    }

                    string[] arrayperson = datos[0].Split('|');
                    string[] arraycoperson = datos[1].Split('|');
                    string[] arraycontacto = datos[3].Split('|');
                    //  string totaldolares = ((Double.Parse(cronograma[0])).ToString());
                    string primeracuota = carrito[3];

                    coname = arraycoperson[0].ToUpper() + " " + arraycoperson[1].ToUpper();
                    if (string.IsNullOrEmpty(coname.Trim()))
                    {
                    coname = "__________________________________________";
                    }


                    tipocambio = carrito[4];
                    double typeChange = double.Parse(tipocambio);
                    numerodecuotas = carrito[2];
                    nombre = arrayperson[0].ToUpper() + " " + arrayperson[1].ToUpper();
                    dni = arrayperson[5];

                    username = arrayperson[0].Substring(0, 1).ToUpper() + arrayperson[1].Substring(0, 1).ToUpper() + dni;
                    domicilio = arraycontacto[6].ToUpper();
                    distrito = arraycontacto[5].ToUpper();


                    //vamos al servidor por el tiempo de duracion
                    BrMembershipPayDetail brPayDetail = new BrMembershipPayDetail();
                    duracion = brPayDetail.GetDuration(carrito[6]);
                    /*resconpesa= wilii*/
                    if (carrito[6] == "EVO")
                    {
                        //duracion = "15";
                        memevolu = "X";
                        //fechafin = "______";
                    }
                    if (carrito[6] == "MVC")
                    {
                       memmvc = "X";
                         //duracion = "1";
                    }
                    if (carrito[6] == "EXP")
                    {
                        memexp = "X";
                        //duracion = "2";
                    }
                    if (carrito[6] == "LHT")
                    {
                        //duracion = "4";
                        memlight = "X";
                    }
                    if (carrito[6] == "STD")
                    {
                        //duracion = "7";
                        memsta = "X";
                    }
                    if (carrito[6] == "PLUS")
                    {
                        //duracion = "10";
                        memplus = "X";
                    }
                    if (carrito[6] == "TOP")
                    {
                        //duracion = "15";
                        memtop = "X";
                        //fechafin = "______";
                    }
                    if (carrito[6] == "VIT")
                    {
                        duracion = "VITALICIO";
                        memvit = "X";
                        fechafin = "--";
                    }
                    else
                    {
                        //para que la suma sea menos un dia 2021-08-22
                        DateTime fecha = DateTime.Parse("2022-08-21");

                        int duracion1 = int.Parse(duracion.Split('.')[0]);
                        int duracion2 = int.Parse(duracion.Split('.')[1]);

                        fecha = fecha.AddYears(duracion1);
                        if (duracion2 > 0)
                        {
                            fecha = fecha.AddMonths(duracion2);
                        }
                        
                        fechafin = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy");
                        duracion = " DE " + duracion1 + " AÑOS";
                    }
                    Numalet numalet = new Numalet();
                    double totaldolaresv = numalet.TwoDecimas(double.Parse(totaldolares));
                    montototaldolareletras = numalet.ToCustomCardinal(totaldolaresv).ToUpper();
                    montototaldolareletras += " Dolares ( " + totaldolaresv.ToString("###,###,##0.00") + " USD ).".ToUpper();
                    double totalsolesv = numalet.TwoDecimas(double.Parse(totaldolares) * double.Parse(tipocambio));
                    montototalsoles = numalet.ToCustomCardinal(totalsolesv).ToUpper();
                    montototalsoles += " Soles ( " + totalsolesv.ToString("###,###,##0.00") + " PEN).".ToUpper();


                    //la primera cuota viene en soles y tenemos el total en soles
                    porprimcuo = numalet.TwoDecimas((((double.Parse(primeracuota) * Double.Parse(tipocambio)) * 100) / totalsolesv)).ToString();
                    porcentajefinan = numalet.TwoDecimas((100 - double.Parse(porprimcuo))).ToString();

                    BrPayments brPayments = new BrPayments();
                    double interesanual = brPayments.CalculateMonthlyRate(10);

                    double montofinanciar = totalsolesv - (double.Parse(primeracuota) * double.Parse(tipocambio));

                    /*asdasdasd*/
                    string[] array1 = Session["cronogramaYa"].ToString().Split('^');
                    string[] datosMem = array1[0].Split('|');
                    string[] array2 = array1[1].Split('~');
                    string[] cuotas = array2[0].Split('¬');

                    int interruptor = 0;
                    string cuotasMenSoles = "";
                    for (int i = 0; i < cuotas.Length - 1; i++)
                    {
                        var fila = cuotas[i].Split('|');
                        if (fila[0].Substring(0, 7) != "Inicial" && fila[0].Substring(0, 7) != "Upgrade")
                        {
                            if (interruptor != 1)
                            {
                                interruptor = 1;
                                cuotasMenSoles = fila[5].Replace("S/.", "");
                            }
                        }
                    }
                    string montoletrastercero = "";
                    montoletrastercero = " un valor de " + montototaldolareletras + " los cuales al tipo de cambio del día " + tipocambio +
                        " , serían " + montototalsoles;

                    double amountSoles = double.Parse(cuotasMenSoles);
                    if (currencyCode == "USD")
                    {
                        amountSoles = amountSoles / typeChange;
                        montoletrastercero = " un valor de " + montototaldolareletras;
                    }
                    /*asdasdasd*/

                    // double mothycuod = brPayments.CalculeMonthlyQuote(montofinanciar, int.Parse(numerodecuotas), interesanual);
                    string mothycuo = numalet.TwoDecimas(amountSoles).ToString();
                    //double sd =  brPayments.CalculateFinancingPercentage(1, 1);


                    switch (int.Parse(numerodecuotas))
                    {
                        case 1: opcontado = "X"; break;
                        case 6: op6cuotas = "X"; soles6cuotas = " ( " + mothycuo.ToString() + " " + currencyCode + ")"; break;
                        case 12: op12cuotas = "X"; soles12cuotas = " ( " + mothycuo.ToString() + " " + currencyCode + ")"; break;
                        case 24: op24cuotas = "X"; soles24cuotas = " ( " + mothycuo.ToString() + " " + currencyCode + ")"; break;
                        case 36: op36cuotas = "X"; soles36cuotas = " ( " + mothycuo.ToString() + " " + currencyCode + ")"; break;
                        case 48: op48cuotas = "X"; soles48cuotas = " ( " + mothycuo.ToString() + " " + currencyCode + ")"; break;
                        case 60: op60cuotas = "X"; soles60cuotas = " ( " + mothycuo.ToString() + " " + currencyCode + ")"; break;
                        default:
                            opotros = "X"; solesotros = numerodecuotas + " Cuotas – Cada cuota de (S/." + mothycuo.ToString() + " )";
                            break;
                    }

                    //un valor de [@montototaldolaresletras] los cuales al tipo de cambio del día [@tipocambio] , serían [@montototalsoles]

                    string fechahoy = DateTime.Now.ToString("dd/MM/yyyy");

                    //reportViewer1.LocalReport.ReportPath = @"http://localhost:50447/Views/FilesContratos/Contrato.rdlc";
                    //ReportViewer1.LocalReport.DataSources.Clear();
                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _midetalle_venta))TRY MERGE;
                    //reportViewer1.
                    tipocambio = "( " + tipocambio + " )";
                    ReportParameter[] parametros = new ReportParameter[37];
                    parametros[0] = new ReportParameter("name", nombre);
                    parametros[1] = new ReportParameter("dni", dni);
                    parametros[2] = new ReportParameter("estadocivil", civilState);
                    parametros[3] = new ReportParameter("domicilio", domicilio);
                    parametros[4] = new ReportParameter("distrito", distrito);
                    parametros[5] = new ReportParameter("memexp", memexp);
                    parametros[6] = new ReportParameter("memlight", memlight);
                    parametros[7] = new ReportParameter("memsta", memsta);
                    parametros[8] = new ReportParameter("memplus", memplus);
                    parametros[9] = new ReportParameter("memtop", memtop);
                    parametros[10] = new ReportParameter("duracion", duracion);
                    parametros[11] = new ReportParameter("fechafin", fechafin);
                    parametros[12] = new ReportParameter("montototaldolaresletras", montototaldolareletras);
                    parametros[13] = new ReportParameter("tipocambio", tipocambio);
                    parametros[14] = new ReportParameter("montototalsoles", montototalsoles);
                    parametros[15] = new ReportParameter("numerodecuotas", numerodecuotas);
                    parametros[16] = new ReportParameter("opcontado", opcontado);
                    parametros[17] = new ReportParameter("op6cuotas", op6cuotas);
                    parametros[18] = new ReportParameter("op12cuotas", op12cuotas);
                    parametros[19] = new ReportParameter("op24cuotas", op24cuotas);
                    parametros[20] = new ReportParameter("op36cuotas", op36cuotas);
                    parametros[21] = new ReportParameter("op48cuotas", op48cuotas);
                    parametros[22] = new ReportParameter("op60cuotas", op60cuotas);
                    parametros[23] = new ReportParameter("opotros", opotros);
                    // parametros[24] = new ReportParameter("porcentajefinan", porcentajefinan);
                    // parametros[25] = new ReportParameter("porprimcuo", porprimcuo);
                    parametros[24] = new ReportParameter("soles6cuotas", soles6cuotas);
                    parametros[25] = new ReportParameter("soles12cuotas", soles12cuotas);
                    parametros[26] = new ReportParameter("soles24cuotas", soles24cuotas);
                    parametros[27] = new ReportParameter("soles36cuotas", soles36cuotas);
                    parametros[28] = new ReportParameter("soles48cuotas", soles48cuotas);
                    parametros[29] = new ReportParameter("soles60cuotas", soles60cuotas);
                    parametros[30] = new ReportParameter("solesotros", solesotros);
                    parametros[31] = new ReportParameter("coname", coname);
                    parametros[32] = new ReportParameter("memmvc", memmvc);
                    parametros[33] = new ReportParameter("fechahoy", fechahoy);
                    parametros[34] = new ReportParameter("memvit", memvit);
                    parametros[35] = new ReportParameter("montoletrastercero", montoletrastercero);
                    parametros[36] = new ReportParameter("memevolu", memevolu);
                    
                    reportViewer1.LocalReport.SetParameters(parametros);
                    reportViewer1.LocalReport.Refresh();


                    //reportViewer1.Enabled = false;


                    ////Le indicamos al Control que la invocación del reporte será de modo remoto
                    //reportViewer1.ProcessingMode = ProcessingMode.Remote;
                    ////Le indicamos la URL donde se encuentra hospedado Reporting Services
                    //reportViewer1.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer");
                    ////Le indicamos la carpeta y el Reporte que deseamos Ver
                    //reportViewer1.ServerReport.ReportPath = "/DemoRS/Contacto";
                    ////Definimos los parámetros
                    //ReportParameter parametro = new ReportParameter();
                    //parametro.Name = "name";
                    //parametro.Values.Add("2");//txtContactID.Text
                    //                          //Aqui le indicaremos si queremos que el parámetro 
                    //                          //sea visible para el usuario o no
                    //parametro.Visible = false;

                    ////Crearemos un arreglo de parámetros
                    //ReportParameter[] rp = { parametro };
                    ////Ahora agregamos el parámetro en al reporte
                    //reportViewer1.ServerReport.SetParameters(rp);
                    //reportViewer1.ServerReport.Refresh();


                    byte[] bytes = reportViewer1.LocalReport.Render("PDF");
                    string correlativo = "";
                    correlativo = Session["correlativoDoc"].ToString();
                    string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/" + "CON" + username + correlativo);
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
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?error=" + ex.Message, true);
            }
}
    }
}