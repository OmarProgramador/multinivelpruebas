using BussinesRules;
using BussinesRules.User;
using Entities;
using System;

namespace MULTI_NIVEL.Views
{
    public partial class PlacementCc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];
            string answer = "ha ocurrido un error";
            if (action == "get")
            {
                BrPlacement brPlacement = new BrPlacement();
                MyFunctions mf = new MyFunctions();
                string cboUpli = string.Empty;
                var upliners = brPlacement.GetUpliners(User.Identity.Name.Split('¬')[1]).Split('¬');

                cboUpli = "<select>";
                cboUpli += $"<option value='0'>--Seleccionar--</option>";

                for (int i = 0; i < upliners.Length; i++)
                {
                    var row = upliners[i].Split('|');
                    if (row.Length > 1)
                    {
                        cboUpli += $"<option value='{row[0]}'>{row[1]}</option>";
                    }
                }
                cboUpli += "/<select>";

                string data = brPlacement.GetSponsored(User.Identity.Name.Split('¬')[1]);

                var arrayData = data.Split('¬');
                answer = "<table class='table table-hover'>";
                answer += "<thead>";
                answer += "<tr>";
                answer += "<th></th>";
                answer += "<th>Nombres</th>";
                answer += "<th>Fecha</th>";
                answer += "<th>Tipo de Membresia</th>";
                answer += "<th>Estado</th>";
                answer += "<th>Upliner</th>";
                answer += "<th></th>";
                answer += "</tr>";
                answer += "<tbody>";

                for (int i = 0; i < arrayData.Length; i++)
                {
                    var row = arrayData[i].Split('|');
                    if (row.Length > 2)
                    {
                        var item = (i + 1).ToString();
                        var id = $"{item}_{row[2]}";
                        answer += "<tr>";
                        answer += $"<td>{item}</td>";
                        answer += $"<td>{row[1]}</td>";
                        answer += $"<td>{mf.DateFormatClient(row[3])}</td>";
                        answer += $"<td>{row[5]}</td>";

                        if (row[4] == "0")
                        {
                            row[6] = "Pendiente";
                        }
                        answer += $"<td>{row[6]}</td>";

                        answer += $"<td id='{id}'>{cboUpli}</td>";
                        if (row[4] == "1" || row[4] == "2")
                        {
                            answer += $"<td><input type='button' onclick=ShowModalAsignar('{id}','{row[1].Replace(' ', '_')}') name='name' value='Posicionar' class='btn btn-primary' style='box-shadow: 1px 2px 0px black;background: white; color: #000000; border: 1px solid #000000;'></td>";
                        }
                        else
                        {
                            answer += $"<td></td>";
                        }
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

            if (action == "posi")
            {
                var userNamechildren = Request["children"];
                var fatherId = int.Parse(Request["father"]);

                BrAccount brAccount = new BrAccount();

                var existFather = brAccount.Exist(fatherId);
                var existChildren = brAccount.Exist(userNamechildren);

                if (existFather && existChildren)
                {

                    //validar si tiene ya sus tres
                    //verdadero por que pasa el limite
                    var brUser = new BrUser();
                    var isCompleted = brUser.IsTeamCompleted(fatherId);

                    if (isCompleted)
                    {

                        answer = "El usuario ya tiene su equipo completo.";
                    }
                    else
                    {
                        //validar si al affliate ya no se le pueden establecer mas hijos
                        var help = brUser.IsHelpTeam(fatherId);

                        var idCurrent = int.Parse(User.Identity.Name.Split('¬')[2]);

                        if (idCurrent == 1)
                        {
                            help = false;
                        }

                        if (help)
                        {
                            answer = "El usuario ya no puede recibir mas ayuda.";
                        }
                        else
                        {
                            var data = $"{userNamechildren}|{fatherId}";
                            BrPartner brPartner = new BrPartner();
                            var IsAssign = brPartner.Assign(data);

                            if (IsAssign)
                            {
                                answer = "La operacion se realizo con exito.";
                            }
                        }
                    }
                }

            }
            Response.Write(answer);
        }


        public string ConvertStatus(string _status)
        {
            string statusstr = "Inactivo";
            int status = int.Parse(_status);
            if (status == 0)
            {
                statusstr = "Inactivo";
            }
            if (status == 1)
            {
                statusstr = "Activo";
            }
            if (status == 2)
            {
                statusstr = "Deuda 1";
            }
            if (status == 3)
            {
                statusstr = "Deuda 2";
            }
            if (status == 4)
            {
                statusstr = "Deuda 3";
            }
            if (status == 5)
            {
                statusstr = "Comprimido";
            }
            if (status == 6)
            {
                statusstr = "Stand Bye";
            }
            if (status == 7)
            {
                statusstr = "Pendiente";
            }
            if (status == 8)
            {
                statusstr = "Deuda 7";
            }
            if (status > 8)
            {
                statusstr = "Deuda 8";
            }
            return statusstr;
        }
    }
}