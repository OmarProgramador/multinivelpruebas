using BussinesRules;
using BussinesRules.User;
using Entities;
using System;

namespace MULTI_NIVEL.Views
{
    public partial class WalletC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var answer = "ocurrio un error";
            var action = Request["action"];

            if (action == "get")
            {

                BrWallet brWallet = new BrWallet();
                MyFunctions mf = new MyFunctions();
                string tableHtml = "";
                var arrayData = brWallet.Get(User.Identity.Name.Split('¬')[1]);

                if (!string.IsNullOrEmpty(arrayData))
                {
                     
                    string[] arrayRows = arrayData.Split('¬');
                    tableHtml = "<table class='table table-hover'><thead>";
                    tableHtml += "<tr>";
                    tableHtml += "<th>#</th>";
                    tableHtml += "<th>Fecha</th>";
                    tableHtml += "<th>Operacion</th>";
                    tableHtml += "<th>Monto</th>";
                    tableHtml += "</tr></thead><tbody>";
                    for (int i = 0; i < arrayRows.Length; i++)
                    {
                        string[] row = arrayRows[i].Split('|');
                        if (row.Length > 2)
                        {
                            var classtr = "";
                            var restan = "";
                            if (row[3] == "1")
                            {
                                classtr = "text-red";
                                restan = "-";
                            }
                            tableHtml += $"<tr >";
                            tableHtml += $"<td>{(i + 1).ToString()}</td>";
                            tableHtml += $"<td>{mf.DateFormatClient(row[0])}</td>";
                            tableHtml += $"<td>{row[2]}</td>";
                            tableHtml += $"<td class='{classtr}'>{restan}{row[1]}</td>";
                            tableHtml += "</tr>";
                        }
                    }
                    tableHtml += "</tbody></table>";
                    answer = tableHtml;
                }
                else
                {
                    answer = "No hay Datos";
                }
            }

            if (action == "getDoc")
            {
                BrWallet brWallet = new BrWallet();
                MyFunctions mf = new MyFunctions();
                var data = brWallet.GetDocsByUser(User.Identity.Name.Split('¬')[1]);

                answer = "no hay datos";

                if (!string.IsNullOrEmpty(data))
                {
                    var tableHtml = "<table class='table table-hover'>";
                    tableHtml += "<tr>";
                    tableHtml += $"<th>#</th>";
                    tableHtml += $"<th>Archivo</th>";
                    tableHtml += $"<th>Fecha</th>";
                    tableHtml += $"<th>Monto</th>";
                    tableHtml += $"<th>Estado</th>";
                    tableHtml += $"<th>Obs</th>";
                    tableHtml += $"<th>Voucher</th>";
                    tableHtml += "</tr>";
                    var arrayData = data.Split('¬');

                    for (int i = 0; i < arrayData.Length; i++)
                    {
                        var row = arrayData[i].Split('|');
                        tableHtml += "<tr>";
                        tableHtml += $"<td>{(i + 1).ToString()}</td>";
                        tableHtml += $"<td><a target='_blank' href='/Resources/wallet/{row[1]}' ><img src='../Resources/RecibosRegister/pdf.png' width='30px' /></a></td>";
                        tableHtml += $"<td>{mf.DateFormatClient(row[2])}</td>";
                        tableHtml += $"<td>{row[3]}</td>";
                        tableHtml += $"<td>{row[4]}</td>";
                        tableHtml += $"<td>{row[5]}</td>";

                        if (row[6] != "")
                        {
                            tableHtml += $"<td><a target='_blank' href='/Resources/Make/{row[6]}' ><img src='../Resources/RecibosRegister/pdf.png' width='30px' /></a></td>";
                        }
                        else
                        {
                            tableHtml += "<td></td>";
                        }
                        tableHtml += "</tr>";
                    }
                    tableHtml += "</table>";

                    answer = tableHtml;
                }
            }

            if (action == "infoper")
            {
                var usernameBen = Request["userNameBen"];
                var amountleter = Request["amount"];

                answer = "false";
                Validation val = new Validation();
                if (val.IsDecimal(amountleter))
                {

                    var amount = decimal.Parse(amountleter);

                    BrUser brUser = new BrUser();
                    var dataPersonBen = brUser.GetPersonalInformation(usernameBen).Split('|');
                    var dataPerson = brUser.GetPersonalInformation(User.Identity.Name.Split('¬')[1]).Split('|');

                    if (dataPersonBen.Length > 1)
                    {

                        BrWallet brWallet = new BrWallet();
                        var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));
                        if (amountWallet >= amount)
                        {
                            var emailfull = dataPerson[5].Split('@')[0];
                            var emailfront = emailfull.Substring(0, (emailfull.Length / 2) + 2);

                            MyMessages mm = new MyMessages();
                            MyFunctions mf = new MyFunctions();
                            Email email = new Email();

                            var numberOne = (new Random().Next(89) + 10).ToString("00");
                            var numberTwo = ((new Random().Next(32) + 1) * 3).ToString("00");
                            var numberThree = ((new Random().Next(18) + 1) * 5).ToString("00");


                            var token = $"{numberOne}{numberTwo}{numberThree}";

                            var body = mm.EmailClaveDigital(token, mf.ToCapitalize(dataPersonBen[1]));
                            //
                            if (email.SendEmail(dataPerson[5], "Clave Digital - Inresorts", body, true))
                            {
                                BrWalletToken brWalletToken = new BrWalletToken();

                                var dateEnd = DateTime.UtcNow.AddMinutes(5);

                                var isSuccess = brWalletToken.PutToken(User.Identity.Name.Split('¬')[1], token, dateEnd, DateTime.Now.ToString(), 1, amount, usernameBen);

                                if (isSuccess)
                                {
                                    answer = $"true|{dataPersonBen[1]} {dataPersonBen[2]}|{emailfront}|{amountleter}";
                                }
                            }
                        }
                    }
                }
            }


            if (action == "validtoken")
            {
                answer = "false";
                var token = Request["clave"];
                var amount = decimal.Parse(Request["amount"]);

                BrWalletToken brWalletToken = new BrWalletToken();
                var data = brWalletToken.GetInfoToken(User.Identity.Name.Split('¬')[1], token, amount).Split('|');

                if (data.Length > 1)
                {
                    var dateend = DateTime.Parse(data[0]);
                    if (DateTime.UtcNow <= dateend)
                    {
                        BrWallet brWallet = new BrWallet();
                        var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));
                        if (amountWallet >= amount)
                        {
                            var isSuccess = brWallet.PutTransferenciaBetwenWallet(data[1], User.Identity.Name.Split('¬')[1], amount);
                            if (isSuccess)
                            {
                                MyMessages mm = new MyMessages();
                                MyFunctions mf = new MyFunctions();
                                Email email = new Email();
                                var name = User.Identity.Name.Split('¬')[0].Split()[0];
                                var body = mm.EmailTranferSuccess(mf.ToCapitalize(name), mf.ToCapitalize(data[3]), amount.ToString());

                                //
                                var send = email.SendEmail(data[2], "Transferencia Exitosa - Inresorts", body, true);
                                answer = "true";
                            }
                        }
                    }
                }
            }

            if (action == "sendreport")
            {
                var subjet = Request["subjet"].Trim().ToUpper();
                var messagge = Request["messagge"].Trim();

                Email email = new Email();
                MyMessages mm = new MyMessages();
                MyConstants mc = new MyConstants();
                var body = mm.ReportProblemWallet(User.Identity.Name.Split('¬')[1], subjet, messagge);

                var send = email.SendEmail(mc.EmailEmpresa, "Problemas del Wallet - Inresorts", body, true);
                answer = "false";
                if (send)
                {
                    answer = "true";
                }
            }

            Response.Write(answer);
        }
    }
}