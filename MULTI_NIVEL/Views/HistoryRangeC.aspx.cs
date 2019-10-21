using BussinesRules;
using Entities;
using System;

namespace MULTI_NIVEL.Views
{
    public partial class HistoryRangeC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BrHistoryRange brHistoryRange = new BrHistoryRange();
            MyFunctions mf = new MyFunctions();
            string cboUpli = string.Empty;

            var action = Request["action"];
            var answer = string.Empty;

            if (action == "get")
            {
                string data = brHistoryRange.GetListRange(User.Identity.Name.Split('¬')[1]);
                answer += "";
                var arrayData = data.Split('¬');
                answer = "<table class='table table-hover'>";
                answer += "<thead>";
                answer += "<tr>";
                answer += "<th></th>";
                answer += "<th>Ciclo</th>";
                answer += "<th>Rango</th>";
                answer += "<th>Estado</th>";
                answer += "<th>Puntos Rama 1</th>";
                answer += "<th>Puntos Rama 2</th>";
                answer += "<th>Puntos Rama 3</th>";
                answer += "<th>Puntos Rama 4</th>";
                answer += "<th>Rango</th>";
                answer += "</tr>";
                answer += "<tbody>";

                for (int i = 0; i < arrayData.Length; i++)
                {
                    var row = arrayData[i].Split('|');
                    if (row.Length > 2)
                    {
                        var item = (i + 1).ToString();
                        answer += "<tr>";
                        answer += $"<td>{item}</td>";
                        answer += $"<td>{mf.DateFormatClient(row[0])} - {mf.DateFormatClient(row[1])}</td>";
                        answer += $"<td>{row[8]}</td>";
                        answer += $"<td>{row[2]}</td>";
                        answer += $"<td>{row[4]}</td>";
                        answer += $"<td>{row[5]}</td>";
                        answer += $"<td>{row[6]}</td>";
                        answer += $"<td>{row[7]}</td>";
                        answer += $"<td><a href='#' class='btn btn-primaryVerde' onclick=ShowModal('{row[3]}') ><i class='fas fa-award'></i></a></td>";
                        answer += "</tr>";
                    }
                    else
                    {
                        answer += "<tr>";
                        answer += $"<td>No hay Datos</td>";
                        answer += "</tr>";
                    }
                }
                answer += "</tbody>";
                answer += "</table>";
            }

            if (action == "getresidual")
            {
                string data = brHistoryRange.GetListRangeResidual(User.Identity.Name.Split('¬')[1]);
                answer += "";
                var arrayData = data.Split('¬');
                answer = "<table class='table table-hover'>";
                answer += "<thead>";
                answer += "<tr>";
                answer += "<th></th>";
                answer += "<th>Ciclo</th>";
                answer += "<th>Rango</th>";
                answer += "<th>Estado</th>";
                answer += "<th>Puntos Rama 1</th>";
                answer += "<th>Puntos Rama 2</th>";
                answer += "<th>Puntos Rama 3</th>";
                answer += "<th>Puntos Rama 4</th>";
                answer += "<th>Rango</th>";
                answer += "</tr>";
                answer += "<tbody>";

                for (int i = 0; i < arrayData.Length; i++)
                {
                    var row = arrayData[i].Split('|');
                    if (row.Length > 2)
                    {
                        var item = (i + 1).ToString();
                        answer += "<tr>";
                        answer += $"<td>{item}</td>";
                        answer += $"<td>{mf.DateFormatClient(row[0])} - {mf.DateFormatClient(row[1])}</td>";
                        answer += $"<td>{row[8]}</td>";
                        answer += $"<td>{row[2]}</td>";
                        answer += $"<td>{row[4]}</td>";
                        answer += $"<td>{row[5]}</td>";
                        answer += $"<td>{row[6]}</td>";
                        answer += $"<td>{row[7]}</td>";
                        answer += $"<td><a href='#' class='btn btn-primaryVerde' onclick=ShowModal('{row[3]}') ><i class='fas fa-award'></i></a></td>";
                        answer += "</tr>";
                    }
                    else
                    {
                        answer += "<tr>";
                        answer += $"<td>No hay Datos</td>";
                        answer += "</tr>";
                    }
                }
                answer += "</tbody>";
                answer += "</table>";
            }

            Response.Write(answer);
        }
    }
}