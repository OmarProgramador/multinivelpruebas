
namespace MULTI_NIVEL.Views
{
    using System;
    using BussinesRules;
    using Entities;

    public partial class BlistExtornoC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];
            string answer = string.Empty;

            if (action == "list")
            {
                BrExtorno brExtorno = new BrExtorno();
                MyFunctions mf = new MyFunctions();
                var dataAnswer = brExtorno.GetListAdmin().Split('¬');

                answer += "<table class='table table-hover'>";
                answer += "<tr>";
                answer += "<th>#</th>";
                answer += "<th>Nombres</th>";
                answer += "<th>Date</th>";
                answer += "<th>Monto Abonado por la Persona</th>";
                answer += "<th>Monto en commissiones</th>";
                answer += "</tr>";
                for (int i = 0; i < dataAnswer.Length; i++)
                {
                    var row = dataAnswer[i].Split('|');
                    answer += "<tr>";
                    answer += $"<td>{(i + 1).ToString()}</td>";
                    answer += $"<td>{row[1]}</td>";
                    answer += $"<td>{mf.DateFormatClient(row[2])}</td>";
                    answer += $"<td>{row[3]}</td>";
                    answer += $"<td>{row[4]}</td>";
                    answer += "</tr>";
                }
                answer += "</table>";
            }
            Response.Write(answer);
        }
    }
}