<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bextorno.aspx.cs" Inherits="MULTI_NIVEL.Views.Bextorno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Extorno</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <style>
        .display-none {
            display: none;
        }

        .error {
            color: red;
        }

        .negrita {
            font-weight: 700;
        }

        .negrita small {
            font-weight: normal;
        }

        .table td {
              padding: 0 !important;  
        }

    </style>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off" onsubmit="return FormSubmit();">
        <div class="container">
            <div class="row">
                <div class="col-sm-9">
                    <h1>Extorno</h1>
                </div>
                <div class="row col-sm-3">
                    <div class="form-group">
                        <a href="MenuBackend.aspx" class="btn btn-secondary" style="margin-top: 20px;">Menu</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="form-inline">
                        <label>UserName:</label>
                        <input id="UserName" type="text" name="name" value="" class="form-control ml-sm-2" />
                        <input id="Btn-Verificar" type="button" name="name" value="Verificar" class="btn btn-outline-info  ml-sm-2 mr-sm-2" />
                        <div id="Spinner" class="spinner-border display-none" role="status">
                          <span class="sr-only">Loading...</span>
                        </div>
                    </div>
                </div>
                <div class="col-12">
                    <hr />
                    <p class="negrita">Nombre Completo: <small id="Person-FullName"></small></p>
                </div>
                <div class="col-12">
                    <button type="button" class="btn btn-danger" onclick="ShowDialg()">
                     Extornar Ahora
                    </button>

                    <!-- Modal -->
                    <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                      <div class="modal-dialog" role="document">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">Extornar</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                              <span aria-hidden="true">&times;</span>
                            </button>
                          </div>
                          <div class="modal-body">
                              <p>¿Quieres Extorar al Socio?</p>
                              <p id="Extorno-UserName"></p>
                          </div>
                          <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                            <button type="button" class="btn btn-primary" onclick="Extornar();">Aceptar</button>
                          </div>
                        </div>
                      </div>
                    </div>
                </div>
                <div class="col-12">
                    <br />
                    <div id="Tbl-Crono">
                        
                    </div>
                </div>
            </div>
        </div>

    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="Script/Script.js"></script>
    <script type="text/javascript">
        const d = document
        var userName = "";

        function ShowDialg() {
            if (userName === "") {
                return;
            }
            d.getElementById('Extorno-UserName').innerHTML = userName;
            $("#exampleModalLong").modal("show");

        }

        function Extornar() {

            if (userName === "") {
                return;
            }

            $("#exampleModalLong").modal("hide");

            let param = "action=extornar&username=" + userName;
            GetDos("BextornoC", param, (_data) => {

            })
        }
        function ConvertStatus(_data) {
            let answer = ""
            if (_data == "1") {
                answer = "Pagado"
            }
            else if (_data == "2") {
                answer = "Por Verif."
            }
            else{
                answer = "No Pagado"
            }
            return answer
        }
        function convertReceipt(_data) {
            let answer = ""
            if (_data != "") {
                let arrayData = _data.split('~');

                for (var i = 0; i < arrayData.length; i++) {
                    answer += "<a target='_blank' href='../Resources/RecibosRegister/" + arrayData[i] + "'><img src='../Resources/RecibosRegister/pdf.png' width='20px' /></a>"
                }
            }
            return answer
        }

        d.addEventListener("click", e => {
            if (e.target.matches("#Btn-Verificar")) {
                userName = "";
                d.getElementById('Btn-Verificar').disabled = true
                d.getElementById('Btn-Verificar').classList.toggle("disabled")
                d.getElementById('Spinner').classList.toggle("display-none")
                let _username = d.getElementById('UserName').value
                if (_username === "") {
                    d.getElementById('Spinner').classList.toggle("display-none")
                    d.getElementById('Btn-Verificar').disabled = false
                    d.getElementById('Btn-Verificar').classList.toggle("disabled")
                    d.getElementById('UserName').focus()
                    return;
                }
                let param = "action=verif&username=" + _username
                GetDos("BextornoC", param, (data) => {
                   
                    d.getElementById('Spinner').classList.toggle("display-none")
                    d.getElementById('Btn-Verificar').disabled = false
                    d.getElementById('Btn-Verificar').classList.toggle("disabled")
                    if (data === "") {
                        userName = "";
                        d.getElementById('Person-FullName').innerHTML = ""
                        d.getElementById('UserName').focus()
                        alert("ocurrio un error")
                    } else {
                        userName = _username;
                        let arrayData = data.split('$')
                        let dataperson = arrayData[0].split('|');
                        let crono = arrayData[1].split('¬');
                        d.getElementById('Person-FullName').innerHTML = dataperson[0]
                        let tblHtml = ""

                        tblHtml += "<table class='table table-hover'>";
                        tblHtml += "<tr>";
                        tblHtml += "<th>#</th>";
                        tblHtml += "<th>Descripcion</th>";
                        tblHtml += "<th>Proxima Exiracion</th>";
                        tblHtml += "<th>Capital Balance</th>";
                        tblHtml += "<th>Amortizacion</th>";
                        tblHtml += "<th>Interes</th>";
                        tblHtml += "<th>Cuota</th>";
                        tblHtml += "<th>Recibo</th>";
                        tblHtml += "<th>Estado</th>";
                        tblHtml += "<th>fecha de Pago</th>";
                        tblHtml += "</tr>";

                        for (var i = 0; i < crono.length; i++) {
                            let row = crono[i].split('|');
                            tblHtml += "<tr>";
                            tblHtml += "<td>" + (i + 1).toString() + "</td>";
                            tblHtml += "<td>" + row[1] + "</td>";
                            tblHtml += "<td>" + DateFormat(row[2]) + "</td>";
                            tblHtml += "<td>" + row[3] + "</td>";
                            tblHtml += "<td>" + row[4] + "</td>";
                            tblHtml += "<td>" + row[5] + "</td>";
                            tblHtml += "<td>" + row[6] + "</td>";
                            tblHtml += "<td>" + convertReceipt(row[7]) + "</td>";
                            tblHtml += "<td>" + ConvertStatus(row[8]) + "</td>";
                            tblHtml += "<td>" + DateFormat(row[9]) + "</td>";
                            tblHtml += "</tr>";
                        }
                        tblHtml += "<table>";

                        d.getElementById('Tbl-Crono').innerHTML = tblHtml
                    }
                   
                })
            }

            if (e.target.matches("#Btn-Extornar")) {

            }
        })

    </script>
</body>
</html>
