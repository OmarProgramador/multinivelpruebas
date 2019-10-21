
namespace MULTI_NIVEL.Views
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public partial class VysorPagare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                reportViewer1.LocalReport.Refresh();
            }
        }


        public string Pagares()
        {
            string[] datos = Session["datos"].ToString().Split('$');
            string[] carrito = Session["carrito"].ToString().Split('|');
            string[] cronograma = Session["cronogramaYa"].ToString().Split('|');

            string[] arrayperson = datos[0].Split('|');
            string[] arraycontacto = datos[3].Split('|');
            string totaldolares = cronograma[0];
            string primeracuota = carrito[3];
            string tipocambio = carrito[4];
            string numerodecuotas = carrito[2];
            string codemem = carrito[6];

            string fechaActual = DateTime.Now.ToLongDateString();
            Numalet numalet = new Numalet();
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
            Session["nQuotes"] = cuotas;
            decimal totalpagar = 0, interestotal = 0, importefinanciado = 0, porcefinanciado = 0, valorcuotas = 0;
            int ncuotas = 0, interruptor = 0;
            string fechacuotas = "";

            List<Pagare> listPagare = new List<Pagare>();
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
                        fechacuotas = DateTime.Parse(fila[1]).ToString("dd/MM/yyyy");
                        valorcuotas = decimal.Parse(fila[5].Replace("S/.", ""));

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
                            MontoSolesLetras = numalet.ToCustomCardinal(decimal.Parse(fila[5].Replace("S/.", ""))),
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
                MontoSolesLetras = numalet.ToCustomCardinal(importefinanciado),
                NCuotas = ncuotas,
                ValorCuotas = valorcuotas
            });


            string cadenfinal = string.Empty;

            for (int i = 0; i < listPagare.Count; i++)
            {
                cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 12pt;font-weight: bold;'>PAGARÉ CODIGO: " + userName.ToUpper() + "-" + (i + 1).ToString() + "</div>";
                cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 10pt;font-weight: bold;'>POR UN VALOR DE( " + listPagare[i].MontoSolesLetras + " Soles)</div>";
                cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 10pt;font-weight: bold;'>(S/." + listPagare[i].MontoSoles.ToString() + ")ESTE VALOR ES EL SALDO A FINANCIAR</div>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Yo <b>" + listPagare[i].NombreCompleto + "</b> identificado(a) con DNI Nº <b>" + listPagare[i].Dni + "</b> con domicilio y residencia en <b>" + listPagare[i].Domicilio + "</b>.</p>" +
                    "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Me comprometo a pagar incondicionalmente a VALLE ENCANTADO S.A.C " +
                    "la suma de <b>" + listPagare[i].MontoSolesLetras + " Soles (S/. " + listPagare[i].MontoSoles + ")</b> pagadero en <b>" + listPagare[i].NCuotas + "</b> cuotas mensuales y consecutivas con vencimiento la primera " +
                    "de ella el día <b>" + listPagare[i].FechaCuotas + "</b>, por valor de <b>(S/." + listPagare[i].ValorCuotas + ")</b>.El pago de dichas cuotas se realizará en Soles a razón del cambio oficial vigente" +
                    " a la fecha en que se efectúe éste. En caso de mora y mientras ella subsista pagaré intereses moratorios a la tasa máxima establecida para" +
                    " el periodo correspondiente. De igual manera me obligo a pagar todos los gastos y costos de la cobranza judicial. </p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>En el evento en que el deudor no pague en el plazo" +
                    " estipulado una o más cuotas, el tenedor de este título podrá declarar vencidos todos los plazos de esta obligación y pedir su inmediato" +
                    " pago total o el pago del saldo.</p>";

                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>También acepto que <b>VALLE ENCANTADO S.A.C</b>, declare de plazo vencido la obligación a la que se refiere este pagaré y exigir su pago total en el evento en que sea perseguido judicialmente. El recibo de abono de parciales no implica novación y cualquier pago que se efectúe se imputará primero a gastos, penalidades, y por último a capital. El suscriptor de este pagaré hace constatar que la obligación de pagarla indivisiblemente y solidariamente subsiste en caso de prórroga o prórrogas o de cualquier modificación a lo estipulado. El deudor declara que la suma que debe conforme a este pagaré, no estará sujeta ni a deducción ni a descuentos de cualquier naturaleza, incluyendo sin limitación cualquier impuesto que pueda gravar su pago, por lo tanto, en caso de existir alguna de estas deducciones o descuentos, el deudor deberá aumentar la suma a pagar de tal manera que el tenedor reciba siempre el valor estipulado del pagaré. El deudor acepta desde ahora el endoso, cesión o transferencia que de este pagaré a VALLE ENCANTADO S.A.C. todos los gastos e impuestos relacionados con la suscripción de este pagaré serán por cuenta del deudor.</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Todos los pagos que deban hacerse según este pagaré serán hechos exclusivamente en Soles, a la<b> Cuenta Recaudadora Soles BCP N°192-2459697-0-22</b>, en su oficina central ubicada en Av. Guardia Civil 1321 oficina 602 – Surquillo o en Ribera del Río Club Resort ubicada en Mz. B Lt. 72. Tercera Etapa - Cieneguilla.</p>";
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
            return cadenfinal;
        }
    }
}