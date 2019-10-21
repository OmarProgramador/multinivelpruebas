
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using Entities;
    using System;

    public partial class BonusPeriodC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = string.Empty;
            string answer = "ocurrio un error";


            action = Request["action"];

            if (action == "list")
            {
                BrBonus brBonus = new BrBonus();
                MyFunctions mf = new MyFunctions();
                MyConstants mc = new MyConstants();

                var data = brBonus.GetFullPeriod();

                if (data != "")
                {
                    var arrayData = data.Split('¬');

                    var tableHtml = "";
                    tableHtml = "<table class='table table-hovered'>";
                    tableHtml += "<tr>";
                    tableHtml += "<th>#</th>";
                    tableHtml += "<th>Fecha de Inicio</th>";
                    tableHtml += "<th>Fecha de Fin</th>";
                    tableHtml += "<th>Fecha de Pago</th>";
                    tableHtml += "<th>Estado</th>";
                    tableHtml += "<th></th>";
                    tableHtml += "<th></th>";
                    tableHtml += "</tr>";

                    for (int i = 0; i < arrayData.Length; i++)
                    {
                        var row = arrayData[i].Split('|');

                        if (row.Length > 1)
                        {
                            var button = $"Activate({row[0]})";
                            var display = "Activar";
                            var classbutton = "primary";
                            if (int.Parse(row[3]) == 1)
                            {
                                button = $"Defuce({row[0]})";
                                display = "Desactivar";
                                classbutton = "danger";
                            }

                            tableHtml += "<tr>";
                            tableHtml += $"<td>{(i + 1).ToString()}</td>";
                            tableHtml += $"<td>{mf.DateFormatClient(row[1])}</td>";
                            tableHtml += $"<td>{mf.DateFormatClient(row[2])}</td>";
                            tableHtml += $"<td>{mf.DateFormatClient(row[4])}</td>";
                            tableHtml += $"<td>{mf.GeneralStatus(row[3])}</td>";
                            tableHtml += $"<td><input type='button' class='btn-{classbutton}'  onclick={button} value='{display}' /></td>";

                            if (DateTime.Parse(row[4]) >= DateTime.Now && row[3] == "1")
                            {
                                tableHtml += $"<td><input type='button' class='btn-info'  onclick=PayBonus({row[0]}) value='Pagar Bonus' /> | ";
                                tableHtml += $"<input type='button' class='btn-success'  onclick=HistoryRange({row[0]}) value='Calcular Rangos Compuestos' /> | ";
                                tableHtml += $"<input type='button' class='btn-warning'  onclick=HistoryRangeResidual({row[0]}) value='Calcular Rangos Residual' /></td>";
                            }
                            else
                            {
                                tableHtml += "<td></td>";
                            }
                            tableHtml += "</tr>";
                        }

                    }
                    tableHtml += "</table>";

                    answer = tableHtml;
                }
            }

            if (action == "status")
            {
                BrBonus brBonus = new BrBonus();
                var option = int.Parse(Request["option"]);
                var id = int.Parse(Request["id"]);
                var anwdata = false;
                if (option == 0)
                {
                    anwdata = brBonus.ChangeStatus(id, 0);
                }
                if (option == 1)
                {
                    anwdata = brBonus.ChangeStatus(id, 1);
                }
                if (anwdata)
                {
                    answer = "La operacion se realizo con exito.";
                }
                brBonus = null;
            }

            if (action == "new")
            {
                MyFunctions mf = new MyFunctions();
                var _from = Request["from"];
                var _until = Request["until"];
                var _payDate = Request["paydate"];

                _from = mf.DateFormatBd(_from);
                _until = mf.DateFormatBd(_until);
                _payDate = mf.DateFormatBd(_payDate);

                BrBonus brBonus = new BrBonus();

                var dataresp = brBonus.PutPeriod(_from, _until, _payDate);
                if (dataresp)
                {
                    answer = "La operacion se realizo con exito.";
                }
                brBonus = null;
            }

            if (action == "paybonus")
            {
                var id = int.Parse(Request["id"]);
                BrBonus brBonus = new BrBonus();
                var dataresp = brBonus.PayBonus(id);
                if (dataresp)
                {
                    var listEmail = brBonus.GetEmailPayWallet(id).Split('¬');

                    for (int i = 0; i < listEmail.Length; i++)
                    {
                        var row = listEmail[i].Split('|');

                        var amount = decimal.Parse(row[2]);
                        var transfid = new Random().Next(100000).ToString();
                        var walletId = int.Parse(row[4]).ToString("00000000");

                        var arrdescrip = row[3].Split(':');
                        var descripti = arrdescrip[0] + " : <span>" + arrdescrip[1] + "</span>";

                        MyConstants mc = new MyConstants();

                        var sendee = SendPayWallet(row[0], row[1], amount, descripti, transfid, walletId);
                        sendee = SendPayWallet(mc.EmailEmpresaBonus, row[1], amount, descripti, transfid, walletId);
                    }

                    answer = "La operacion se realizo con exito.";
                }
            }

            if (action == "historyrange")
            {
                var id = int.Parse(Request["id"]);
                BrHistoryRange brHistoryRange = new BrHistoryRange();
                var dataresp = brHistoryRange.PutHistoryRangePeriod(id);
                answer = "";
                if (dataresp)
                {
                    answer = "La operacion se realizo con exito.";
                }
            }

            if (action == "historyrangeresidual")
            {
                var id = int.Parse(Request["id"]);
                BrHistoryRange brHistoryRange = new BrHistoryRange();
                var dataresp = brHistoryRange.PutHistoryRangeResidualPeriod(id);
                answer = "";
                if (dataresp)
                {
                    answer = "La operacion se realizo con exito.";
                }
            }

            Response.Write(answer);
        }


        #region Methods

        public bool SendPayWallet(string emailUser, string name, decimal amount, string description, string transfId, string id)
        {
            string email = "<!DOCTYPEhtml><html><head><title></title></head>";
            email = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:700px;background-color:white;'>";
            email += "<div style=' justify-content:space-between;text-align:center;'>";
            email += "<div style='display:flex;'>";
            email += "<div style='width:50%;'>";
            email += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            email += "</div>";
            email += "<div style='width:50%;'>";
            email += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            email += "</div>";
            email += "</div>";
            email += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            email += "</div>";
            email += "";

            email += "<div style='padding:10px;'><h2 style='font-size:30px;'><b>Estimado " + name.ToUpper() + "</b></h2></div>";
            email += "<div style='padding:10px;font-size:20px;'>Su cuenta de billetera electrónica ha sido cargada con los siguientes detalles :";
            email += $"<br><br><b>Monto : </b> USD {amount.ToString("0.00")}";
            email += $"<br><br><b>Descripción : </b> Bonificación de Red";
            email += $"<br><br><b>Detalle : </b> {description}";
            email += $"<br><br><b>ID de la Transferencia : </b> {transfId}";
            //email += $"<br><br><b>Id : </b> {id}";
            email += "</div><div>";
            email += "<div style='width: 100%'>";
            email += "<p style='padding:10px;font-size:20px;'>Para ver su saldo Inicie sesion en su cuenta de <a href='www.inresorts.club'>Inresorts</a>";
            email += "<br><br>POR FAVOR NO RESPONDA ESTE CORREO ELECTRONICO<br></p></div>";
            email += "</div>";
            email += "<div>";
            email += "<p style='padding:10px;font-size:20px;'>Saludos Cordiales <br>Equipo inResorts</p></div>";
            email += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            email += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            email += "</div></body></html>";

            Email oemail = new Email();
            var send = oemail.SendEmail(emailUser, "[BONIFICACION - INRESORTS]", email, true);

            return send;
        }
        #endregion

    }
}