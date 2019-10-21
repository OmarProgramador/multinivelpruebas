using BussinesRules;
using BussinesRules.User;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class BDataCorrectionC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = string.Empty;
            string answer = "";
            action = Request["action"];
            if (action == "verificar")
            {
                string userName = Request["userName"];
                BrUser brPerson = new BrUser();
                answer = brPerson.GetPersonalInformation(userName);
                if (answer == null)
                {
                    answer = "error";
                }
                brPerson = null;
            }

            if (action == "register")
            {
                BrUser brUser = new BrUser();
                var data = "";
                var _username = Request["username"];
                var _name = Request["name"];
                var _lastname = Request["lastname"];
                var _birthday = Request["birthday"];
                var _nrodoc = Request["nrodoc"];
                var _email = Request["email"];
                var _phone = Request["phone"];
                var _country = Request["country"];
                var _city = Request["city"];
                var _district = Request["district"];
                var _address = Request["address"];
                var _gender = Request["gender"];
                var _typedoc = Request["typedoc"];
                var _statuscivil = Request["statuscivil"];

                data = _username + "|" +
                    _name + "|" +
                    _lastname + "|" +
                    _birthday + "|" +
                    _gender + "|" +
                    _email + "|" +
                    _phone + "|" +
                    "" + "|" +
                    _country + "|" +
                    _district + "|" +
                    _city + "|" +
                    _address;
                var response = brUser.PutPersonalInformation(data);

                var membership = brUser.GetMembershipFirts(_username);
                if (response)
                {
                    Session["datos"] = _name + "|" +
                     _lastname + "|" +
                     _birthday + "|" +
                     _gender + "|" +
                     _typedoc + "|" +
                     _nrodoc + '$' +
                     "" + " |" +
                     "" + " |" +
                     "1" + "|" +
                     "" + "|" +
                     "" + "$" +
                     "EMPTY" + "|" +
                     "EMPTY" + "|" +
                     "" + "|" +
                     "EMPTY" + "|" +
                     "EMPTY" + "|" +
                     "EMPTY" + "|" +
                     "EMPTY" + "|" +
                     "" + "$" +
                     _email + "|" +
                      _phone + "|" +
                     "" + " |" +
                     _country + "|" +
                     _city + "|" +
                     _city + "|" +
                     _address + "|" +
                     membership + "|" + "0$0";


                    MyConstants mc = new MyConstants();
                    //cronograma
                    var dataCron = brUser.GetCronograma(membership, _username).Split('$');

                    var arrayData = dataCron[0].Split('¬');
                    var numCuotasU = dataCron[1];
                    var currencyCode = dataCron[2];
                    var descripcionDB = dataCron[3].ToUpper();

                    decimal cuotaInicialmontoS = 0;
                    decimal totalMembership = 0;
                    decimal quoteInicial = 0;
                    decimal typeChange = 0;
                    string fechaSale = "";

                    var cadenaInitial = "";
                    var item = arrayData.Length - 1;
                    var QuoteInitialquantity = arrayData.Length;
                    string fechaDentro = DateTime.Parse(arrayData[item].Split('|')[0]).AddMonths(1).ToString(mc.DateFormatBd);
                    for (int i = 0; i < arrayData.Length; i++)
                    {
                        var row = arrayData[i].Split('|');
                        cuotaInicialmontoS += decimal.Parse(row[4]);
                        fechaSale = arrayData[0].Split('|')[0];
                        totalMembership = decimal.Parse(arrayData[0].Split('|')[1]);
                        typeChange = decimal.Parse(arrayData[0].Split('|')[5]);

                        if (i == 0)
                        {
                            cadenaInitial += row[0] + "|" + row[4];
                        }
                        else
                        {
                            cadenaInitial += "|" + row[0] + "|" + row[4];
                        }
                    }

                    //el monto que viene es soles necesitamos convertirlo a dolares
                    totalMembership = totalMembership / typeChange;

                    Session["cronograma"] = totalMembership.ToString("0.00") + "|" + typeChange.ToString() + "|empty|empty|" + numCuotasU + "|" + fechaSale + "|" + cuotaInicialmontoS.ToString() + "|" +
                        mc.AmountInteresAnual.ToString() + "|" + QuoteInitialquantity.ToString() + "|empty^" + cadenaInitial + "~" + _name + "|" + _lastname + "|1" + _nrodoc + "|" +
                        _nrodoc + "$" + fechaDentro;



                    var respData = "^" + (string)Session["cronograma"];

                    string showReport = "";
                    BrPayments brPayments = new BrPayments();
                    showReport = brPayments.GetCalculatePaymentScheduleString(respData, _username, QuoteInitialquantity.ToString(), "0", false);


                    Session["cronogramaYa"] = showReport;

                    Session["TypeCurrency"] = currencyCode;

                    Session["CivilState"] = _statuscivil.ToUpper() + "(A)";


                    Session["carrito"] = totalMembership.ToString("0.00") + "|" + descripcionDB + "|" + numCuotasU + "|" + cuotaInicialmontoS.ToString("0.00") + "|" + typeChange.ToString("0.00") +
                       "|10|" + membership;

                    Session["corregirdatos"] = _username;

                    answer = "bien¬" + membership;
                }
            }

            Response.Write(answer);
        }
    }
}