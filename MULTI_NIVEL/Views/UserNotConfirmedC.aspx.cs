using BussinesRules;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class UserNotConfirmedC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string answer = "ocurrio un error";
            BrAccount brAccount = new BrAccount();
            MyFunctions mf = new MyFunctions();

            var respdata = brAccount.GetUserNotConfirmedPayInitial().Split('¬');


            if (respdata.Length > 1)
            {
                answer = "<table class='table table-hover'>";
                answer += "<tr>";
                answer += "<th>#</th>";
                answer += "<th>Fecha</th>";
                answer += "<th>Fecha Pago</th>";
                answer += "<th>UserName</th>";
                answer += "<th>Nombre del nuevo Socio</th>";
                answer += "<th>Telefono</th>";
                answer += "<th>Tipo de Membresia</th>";
                answer += "<th>Inicial</th>";
                answer += "<th>Patrocinador</th>";
                answer += "<th>Telefono Patrocinador</th>";
                answer += "</tr>";

                for (int i = 0; i < respdata.Length; i++)
                {
                    var row = respdata[i].Split('|');
                    answer += "<tr>";
                    answer += $"<td>{(i + 1).ToString()}</td>";
                    answer += $"<td>{mf.DateFormatClient(row[0])}</td>";
                    answer += $"<td>{mf.DateFormatClient(row[1])}</td>";
                    answer += $"<td>{row[2]}</td>";
                    answer += $"<td>{row[3]}</td>";
                    answer += $"<td>{row[4]}</td>";
                    answer += $"<td>{row[5]}</td>";
                    answer += $"<td>S/.{row[6]}</td>";
                    answer += $"<td>{row[7]}</td>";
                    answer += $"<td>{row[8]}</td>";
                    answer += "</tr>";
                }
                answer += "</table>";

            }
            else
            {
                answer = "No Hay Datos";
            }

            Response.Write(answer);
        }
    }
}