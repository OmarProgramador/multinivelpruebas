
namespace MULTI_NIVEL.Views
{
    using System;
    using BussinesRules;
    using Entities;

    public partial class PromotoresC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];
            string answer = "ha ocurrido un error";
            if (action == "get")
            {
                BrPromoter brPromoter = new BrPromoter();
                MyFunctions mf = new MyFunctions();
                string cboUpli = string.Empty;


                string data = brPromoter.GetListByUserName(User.Identity.Name.Split('¬')[1]);

                if (data != "")
                {

                    var activos = data.Split('$')[0];
                    var noactivos = data.Split('$')[1];

                    var arrayData = activos.Split('¬');
                    answer = "<table class='table table-hover'>";
                    answer += "<thead>";
                    answer += "<tr>";
                    answer += "<th></th>";
                    answer += "<th>Nombres</th>";
                    answer += "<th>Fecha de afiliacion</th>";
                    answer += "<th>Estado</th>";
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
                            answer += $"<td>{row[0]}</td>";
                            answer += $"<td>{mf.DateFormatClient(row[1])}</td>";
                            answer += $"<td>{row[2]}</td>";
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


                    var arrayDatano = noactivos.Split('¬');
                    answer += "$<table class='table table-hover'>";
                    answer += "<thead>";
                    answer += "<tr>";
                    answer += "<th></th>";
                    answer += "<th>Nombres</th>";
                    answer += "<th>Fecha de afiliacion</th>";
                    answer += "<th>Estado</th>";
                    answer += "</tr>";
                    answer += "<tbody>";

                    for (int i = 0; i < arrayDatano.Length; i++)
                    {
                        var row = arrayDatano[i].Split('|');
                        if (row.Length > 2)
                        {
                            var item = (i + 1).ToString();
                            answer += "<tr>";
                            answer += $"<td>{item}</td>";
                            answer += $"<td>{row[0]}</td>";
                            answer += $"<td>{mf.DateFormatClient(row[1])}</td>";
                            answer += $"<td>{row[2]}</td>";
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
            }

            if (action == "getCode")
            {
                BrPromoter brPromoter = new BrPromoter();

                var code = Request["code"];
                answer = brPromoter.GetCodeByUserName(User.Identity.Name.Split('¬')[1]);
            }

            if (action == "save")
            {
                BrPromoter brPromoter = new BrPromoter();

                var code = Request["code"];
                var data = brPromoter.SaveCode(User.Identity.Name.Split('¬')[1], code);

                if (data)
                {
                    answer = "La operacion se realizo con exito";
                }
            }

            Response.Write(answer);
        }
    }
}