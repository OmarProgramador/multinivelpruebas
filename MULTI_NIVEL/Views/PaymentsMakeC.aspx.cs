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
    public partial class PaymentsMakeC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];
            string answer = "ocurrio un error";
            BrWallet brWallet;

            if (action == "get")
            {
                brWallet = new BrWallet();
                MyFunctions mf = new MyFunctions();

                var tableHtml = string.Empty;

                var data = brWallet.GetAdminMake();

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
                tableHtml += "<th>Titular de la cuenta</th>";
                tableHtml += "<th>Nro de la cuenta</th>";
                tableHtml += "<th>Banco</th>";
                tableHtml += "<th>Interbancario</th>";
                tableHtml += "<th>Voucher</th>";
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
                        tableHtml += $"<td>{row[8]}</td>";
                        tableHtml += $"<td>{row[9]}</td>";
                        tableHtml += $"<td>{row[10]}</td>";
                        tableHtml += $"<td>{row[11]}</td>";
                        if (row[12] != "")
                        {
                            tableHtml += $"<td><a href='/Resources/Make/{row[12]}' target='_blank'><img src='/Resources/RecibosRegister/pdf.png' width='50' alt='recibo'/></a></td>";
                            tableHtml += "<td></td>";
                        }
                        else
                        {                          
                            tableHtml += "<td></td>";
                            tableHtml += $"<td><input type='button' value='Comprobante' class='btn btn-success' onclick='DisplayModalPay({row[0]})' /></td>";
                        }
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

            if (action == "voucher")
            {

               
            }

            Response.Write(answer);
        }
    }
}