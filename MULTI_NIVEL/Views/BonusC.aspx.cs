
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using Entities;
    using System;

    public partial class BonusC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = string.Empty;
            string answer = "ocurrio un error";

            action = Request["action"];

            if (action == "period")
            {
                BrBonus brBonus = new BrBonus();
                MyFunctions mf = new MyFunctions();
                MyConstants mc = new MyConstants();
                var data = brBonus.GetPeriod(User.Identity.Name.Split('¬')[1]);

                var pag = int.Parse(Request["pag"]);

                //var init = pag - 10;

                if (!string.IsNullOrEmpty(data))
                {
                    var stringHtml = "";
                    var arrayData = data.Split('¬');
                    pag = arrayData.Length > pag ? pag : arrayData.Length;
                    for (int i = 0; i < pag; i++)
                    {
                        var row = arrayData[i].Split('|');
                        if (row.Length > 1)
                        {
                            var dateUpdate = DateTime.Now;

                            dateUpdate = dateUpdate < DateTime.Parse(row[3]) ? dateUpdate : DateTime.Parse(row[3]);

                            var acordion = "";
                            acordion += $"<div class='accordion' id='accordionExample{i}'>";
                            acordion += "<div class='card'> <div class='card-header' id='headingOne'><h2 style='' class='mb-0'>";
                            acordion += "<div style='font-family: open sans, Helvetica Neue, Helvetica, Arial, sans-serif; color:black'>";
                            acordion += "<div class='card-body table-responsive'>";
                            acordion += "<table class='table thead-dark table-bordered'>";
                            acordion += "<thead style='font-size: 15px'>";
                            acordion += "<tr>";
                            acordion += "<th>Periodo</th>";
                            acordion += "<th>actualizado a </th>";
                            acordion += "<th>Comisión</th>";
                            acordion += "<th></th>";
                            acordion += "</tr>";
                            acordion += "</thead>";
                            acordion += "<tbody>";
                            acordion += "<tr>";
                            acordion += $"<td>{mf.DateFormatClient(row[1])} - {mf.DateFormatClient(row[2])}</td>";
                            acordion += $"<td>{mf.DateFormatClient(dateUpdate.ToString(mc.DateFormatBd))}</td>";
                            acordion += $"<td> {row[5]} {row[4]}</td>";

                            acordion += "<td> <button type='button' id='myBtn' data-toggle='modal' data-target='#myModal' style='color:white;' class='btn btn-xl m-t-n-xs ' >Resumen </button>";
                            acordion += "<button style='background-color:white' class='btn ' type='button' data-toggle='collapse' data-target='#collapse" + i + "' aria-expanded='true' ";
                            acordion += $"aria-controls='collapse{i}'  onclick=ShowBonus('divBonus{i}',{row[0]})>ver detalle</button></div></td>";

                            acordion += "</tr>";
                            acordion += "</tbody>";
                            acordion += "</table>";
                            acordion += "</div>";
                            acordion += " ";
                            acordion += $"</div> <div id='collapse{i}' class='collapse' aria-labelledby='headingOne'";
                            acordion += $"data-parent='#accordionExample{i}'>";
                            acordion += "<div class='card-body table-responsive'>";

                            acordion += $"<div id='divBonus{i}'>";
                            acordion += "";
                            acordion += "</div>";

                            acordion += "</div></div></div>";
                            acordion += "</div></div>";

                            stringHtml += acordion;
                        }
                    }

                    answer = stringHtml;
                }
                brBonus = null;
            }

            if (action == "bonus")
            {
                var id = int.Parse(Request["period"]);
                BrBonus brBonus = new BrBonus();
                MyFunctions mf = new MyFunctions();

                var tableHtml = "";
                var data = brBonus.GetListBonus(User.Identity.Name.Split('¬')[1],id);

                tableHtml += "<table class='table table-hover'>";
                //tableHtml += "<thead>";
                tableHtml += "<tr>";
                tableHtml += "<th>#</th>";
                tableHtml += "<th>Nombres</th>";
                tableHtml += "<th>Tipo de Comision</th>";
                tableHtml += "<th>Nivel</th>";
                tableHtml += "<th>Fecha</th>";
                tableHtml += "<th>Puntos</th>";
                tableHtml += "<th>Porcentaje</th>";
                tableHtml += "<th>Monto</th>";
                tableHtml += "<th>Por Estado</th>";
                tableHtml += "<th>Por Nivel</th>";
                tableHtml += "</tr>";
                //tableHtml += "</thead>";
                //tableHtml += "<tbody>";
                
                if (!string.IsNullOrEmpty(data))
                {
                    var arrayData = data.Split('¬');
                    var amountTotal = 0m;
                    var symbol = "";

                    for (int i = 0; i < arrayData.Length; i++)
                    {
                        var row = arrayData[i].Split('|');
                        var interrutor = 0;

                        if (row.Length > 5)
                        {
                            if (i > 0)
                            {
                                if (arrayData[i - 1].Split('|')[0] != row[0])
                                {
                                    tableHtml += "<tr>";
                                    tableHtml += "<td colspan='10'>.</td>";
                                    tableHtml += "</tr>";
                                }
                            }

                            var clasCss = "label-danger";
                            var clasCssn = "label-danger";
                            var status = "NO";
                            var nivel = "NO";
                            if (row[7] == "1" || row[7] == "6" || row[7] == "7")
                            {
                                clasCss = "label-success";
                                status = "SI";
                                interrutor++;
                            }

                            if (int.Parse(row[8]) == 1)
                            {
                                clasCssn = "label-success";
                                nivel = "SI";
                                interrutor++;
                            }
                            if (interrutor == 2)
                            {
                                amountTotal += decimal.Parse(row[6]);
                            }
                            symbol = row[9];

                            tableHtml += "<tr>";
                            tableHtml += $"<td>{(i + 1).ToString()}</td>";
                            tableHtml += $"<td>{row[0]}</td>";
                            tableHtml += $"<td>{row[1]}</td>";
                            tableHtml += $"<td>{row[2]}</td>";
                            tableHtml += $"<td>{mf.DateFormatClient(row[3])}</td>";
                            tableHtml += $"<td>{row[4]}</td>";
                            tableHtml += $"<td>{row[5]}</td>";
                            tableHtml += $"<td>{row[9]} {row[6]}</td>";
                            tableHtml += $"<td><span class='{clasCss}'>{status}</span></td>";
                            tableHtml += $"<td><span class='{clasCssn}'>{nivel}</span></td>";
                            tableHtml += "</tr>";
                        }
                        row = null;
                    }
                    tableHtml += $"<tr><td colspan='7'></td><td class='label-success'>{symbol} {amountTotal.ToString()}</td><td colspan='2'></td><tr>";

                }
                else
                {
                    tableHtml += "<tr><td>No hay Datos</td></tr>";
                }
                //tableHtml += "</tbody>";
                tableHtml += "</table>";

                answer = tableHtml;
            }


            Response.Write(answer);
        }
    }
}