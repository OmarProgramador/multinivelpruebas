
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using Entities;
    using System;

    public partial class BDepositRequestC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var action = string.Empty;
            var answer = string.Empty;

            action = Request["action"];
            answer = "ocurrio un error";
            BrWallet brWallet;

            if (action == "get")
            {
                brWallet = new BrWallet();
                MyFunctions mf = new MyFunctions();

                var tableHtml = string.Empty;

                var data = brWallet.GetAdmin();

                var arrayData = data.Split('¬');

                tableHtml = "<table class='table table-hover'>";
                tableHtml += "<thead>";
                tableHtml += "<tr>";
                tableHtml += "<th>#</th>";
                tableHtml += "<th>Doc</th>";
                tableHtml += "<th>Fecha</th>";
                tableHtml += "<th>Monto</th>";
                tableHtml += "<th>Nombres</th>";
                tableHtml += "<th>Email</th>";
                tableHtml += "<th>Telefono</th>";
                tableHtml += "<th>Genero</th>";
                tableHtml += "<th></th>";
                tableHtml += "<th></th>";
                tableHtml += "</tr>";
                tableHtml += "</thead>";
                tableHtml += "<tbody>";

                for (int i = 0; i < arrayData.Length; i++)
                {
                    var row = arrayData[i].Split('|');
                    var item = (i + 1).ToString();
                    if (row.Length > 2)
                    {
                        tableHtml += "<tr>";
                        tableHtml += $"<td>{item}</td>";
                        tableHtml += $"<td><a href='/Resources/wallet/{row[1]}' target='_blank'><img src='/Resources/RecibosRegister/pdf.png' width='50' alt='recibo'/></a></td>";
                        tableHtml += $"<td>{mf.DateFormatClient(row[2])}</td>";
                        tableHtml += $"<td>{row[3]}</td>";
                        tableHtml += $"<td>{row[4]}</td>";
                        tableHtml += $"<td>{row[5]}</td>";
                        tableHtml += $"<td>{row[6]}</td>";
                        tableHtml += $"<td>{row[7]}</td>";
                        tableHtml += $"<td><input type='button' value='Aceptar' class='btn btn-primary' onclick='ShowModal({row[0]})' /></td>";
                        tableHtml += $"<td><input type='button' value='Rechazar' class='btn btn-success' onclick='DisplayModalRefuse({row[0]})' /></td>";
                        tableHtml += "</tr>";
                    }
                    else
                    {
                        tableHtml += "<tr>";
                        tableHtml += $"<td>no hay datos</td>";
                        tableHtml += "</tr>";
                    }
                }
                tableHtml += "</tbody>";
                tableHtml += "</table>";
                brWallet = null;
                answer = tableHtml;
            }

            if (action == "acept")
            {
                var id = 0;

                id = int.Parse(Request["id"]);
                var obs = Request["obs"];
                brWallet = new BrWallet();

                var data = brWallet.ChangeStatus(id, obs, 1);

                if (data)
                {
                    answer = "La operacion se realizo con exito.";
                }

                brWallet = null;
            }

            if (action == "refuse")
            {
                var id = 0;

                id = int.Parse(Request["id"]);
                var obs = Request["obs"];
                brWallet = new BrWallet();

                var data = brWallet.ChangeStatus(id, obs, 2);

                if (data)
                {
                    answer = "La operacion se realizo con exito.";
                }

                brWallet = null;
            }

            Response.Write(answer);
        }
    }
}