<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BDataCorrection.aspx.cs" Inherits="MULTI_NIVEL.Views.BDataCorrection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <style>
        .display-none {
            display: none;
        }

        .error {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off" onsubmit="return FormSubmit();">
        <div class="container">
            <div class="row">
                <div class="col-sm-9">
                    <h1>Corregir datos y documentos.</h1>
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
                        <label>UserName Registrado: </label>
                        <input type="text" name="name" value="" class="form-control mr-sm-2 ml-sm-2" id="UserName" />
                        <input type="button" name="name" value="Verificar" class="btn btn-outline-success my-2 my-sm-0 mr-sm-2" id="BtnVerificar" />
                        <div id="loading" class="spinner-border display-none" role="status">
                            <span class="sr-only">Loading...</span>
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Nombres</label>
                        <input type="text" name="name" value="" class="form-control" id="Person-Name" required />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Apellidos</label>
                        <input type="text" name="name" value="" class="form-control" id="Person-LastName" required />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Fecha Nacimiento</label>
                        <input type="text" name="name" value="" class="form-control" id="Person-BirthDay" required />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Genero</label>
                        <select class="form-control" id="Person-Gender" required>
                            <option value="">--Selecionar--</option>
                            <option value="M">Masculino</option>
                            <option value="F">Femenino</option>
                        </select>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Tipo de documento</label>
                        <select class="form-control" id="Person-TypeDoc" required>
                            <option value="">--Selecionar--</option>
                            <option value="1">DNI</option>
                            <option value="2">CE</option>
                            <option value="3">Pasaporte</option>
                        </select>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Nro de documento</label>
                        <input type="text" name="name" value="" class="form-control" id="Person-NroDoc" required />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Estado civil</label>
                        <select class="form-control" id="Person-StatusCivil" required>
                            <option value="">--Selecionar--</option>
                            <option value="Soltero">Soltero</option>
                            <option value="Casado">Casado</option>
                            <option value="Viudo">Viudo</option>
                            <option value="Divorciado">Divorciado</option>
                        </select>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Correo Electronico</label>
                        <input type="email" name="name" value="" class="form-control" id="Person-Email" required />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Celular</label>
                        <input type="text" name="name" value="" class="form-control" id="Person-Phone" required />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Pais</label>
                        <input type="text" name="name" value="" class="form-control" id="Person-Country" required />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Provincia / Ciudad</label>
                        <input type="text" name="name" value="" class="form-control" id="Person-City" required />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Distrito</label>
                        <input type="text" name="name" value="" class="form-control" id="Person-District" required />
                    </div>
                </div>
                <div class="col-12">
                    <div class="form-group">
                        <label>Direccion</label>
                        <input type="text" name="name" value="" class="form-control" id="Person-Address" required />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <input type="submit" name="name" value="Enviar" class="btn btn-primary" />
                </div>
            </div>
            <div class="row">
                <div class="col-12 display-none" id="List-Doc">
                    <ul>
                        <li><a target="_blank" id="Politicas" href="Politics.aspx">Abrir Documentos<img src="../Resources/RecibosRegister/pdf.png" width="25px" /></a></li>
                     
                    </ul>
                </div>
            </div>
        </div>
    </form>
    <script src="Script/Script.js"></script>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="Script/jquery.validate.min.js"></script>
    <script type="text/javascript">
        //$("#form1").validate();
        var idPerson = 0;
        var usernamecurrent = "";
        const d = document
        d.addEventListener("click", e => {
            if (e.target.matches("#BtnVerificar")) {

                d.getElementById('BtnVerificar').disabled = true;
                d.getElementById('loading').classList.toggle('display-none');

                let userNamei = d.getElementById('UserName').value.trim();
                d.getElementById('UserName').className = "form-control";

                if (userNamei == "") {
                    d.getElementById('UserName').className += " is-invalid";
                    d.getElementById('loading').classList.toggle('display-none');
                    d.getElementById('BtnVerificar').disabled = false;
                    return;
                }
                usernamecurrent = userNamei;
                let _data = "action=verificar&userName=" + userNamei;

                GetDos("BDataCorrectionC", _data, (data) => {

                    if (data === "error") {
                        idPerson = 0;
                        d.getElementById('Person-Name').value = "";
                        d.getElementById('Person-LastName').value = "";
                        d.getElementById('Person-BirthDay').value = "";
                        d.getElementById('Person-NroDoc').value = "";
                        d.getElementById('Person-Email').value = "";
                        d.getElementById('Person-Phone').value = "";
                        d.getElementById('Person-Country').value = "";
                        d.getElementById('Person-City').value = "";
                        d.getElementById('Person-District').value = "";
                        d.getElementById('Person-Address').value = "";
                        d.getElementById('BtnVerificar').disabled = false;
                        d.getElementById('loading').classList.toggle('display-none');
                        return;
                    }
                    let arrayData = data.split('|');


                    idPerson = parseInt(arrayData[0]);
                    d.getElementById('Person-Name').value = arrayData[1];
                    d.getElementById('Person-LastName').value = arrayData[2];
                    d.getElementById('Person-BirthDay').value = arrayData[3];
                    let cbog = d.getElementById('Person-Gender');
                    for (var i = 0; i < cbog.length; i++) {
                        if (cbog[i].value == arrayData[4]) {
                            let item = cbog[i];
                            item.setAttribute("selected", "");
                        }
                    }
                    d.getElementById('Person-Email').value = arrayData[5];
                    d.getElementById('Person-Phone').value = arrayData[6];
                    d.getElementById('Person-Country').value = arrayData[8];
                    d.getElementById('Person-City').value = arrayData[9];
                    d.getElementById('Person-District').value = arrayData[10];
                    d.getElementById('Person-Address').value = arrayData[11];
                    let cbo = d.getElementById('Person-TypeDoc');
                    for (var i = 0; i < cbo.length; i++) {
                        if (cbo[i].innerText == arrayData[12]) {
                            let item = cbo[i];
                            item.setAttribute("selected", "");
                        }
                    }
                    d.getElementById('Person-NroDoc').value = arrayData[13];
                    let cbos = d.getElementById('Person-StatusCivil');
                    for (var i = 0; i < cbos.length; i++) {
                        let cboval = cbos[i].value.substring(0, 3);
                        let dataval = arrayData[16].substring(0, 3);
                        if (cboval == dataval) {
                            let item = cbos[i];
                            item.setAttribute("selected", "");
                        }
                    }

                    d.getElementById('BtnVerificar').disabled = false;
                    d.getElementById('loading').classList.toggle('display-none');
                });
            }
        });

        d.addEventListener("keyup", (e) => {
            if (e.target.matches("#UserName")) {
                let userNamei = d.getElementById('UserName').value;
                d.getElementById('UserName').className = "form-control"
                if (userNamei == "") {
                    d.getElementById('UserName').className += " is-invalid";
                }
            }
        });

        function FormSubmit() {
            let validar = "";

            if (idPerson == 0) {

            }

            if (usernamecurrent == "") {
                return;
            }

            let _name = d.getElementById('Person-Name').value;
            let _LastName = d.getElementById('Person-LastName').value;
            let _BirthDay = d.getElementById('Person-BirthDay').value;
            let _NroDoc = d.getElementById('Person-NroDoc').value;
            let _Email = d.getElementById('Person-Email').value;
            let _Phone = d.getElementById('Person-Phone').value;
            let _Country = d.getElementById('Person-Country').value;
            let _City = d.getElementById('Person-City').value;
            let _District = d.getElementById('Person-District').value;
            let _Address = d.getElementById('Person-Address').value;

            let cboGen = d.getElementById('Person-Gender');
            let _gender = cboGen.options[cboGen.selectedIndex].value;

            let cbotyd = d.getElementById('Person-TypeDoc');
            let _typeDoc = cbotyd.options[cbotyd.selectedIndex].value;

            let cbocs = d.getElementById('Person-StatusCivil');
            let _civilStatus = cbocs.options[cbocs.selectedIndex].value;

            let _data = "action=register&name=" + _name + "&lastname=" + _LastName + "&birthday=" + _BirthDay + "&nrodoc=" + _NroDoc + "&email=" + _Email + "&phone=" + _Phone
                + "&country=" + _Country + "&city=" + _City + "&district=" + _District + "&address=" + _Address + "&username=" + usernamecurrent + "&gender=" + _gender + "&typedoc=" +
                _typeDoc + "&statuscivil=" + _civilStatus;

            GetDos("BDataCorrectionC", _data, (data) => {
                let _response = data.split('¬');
                if (_response[0] === "bien") {
                    alert(data)

                    let membership = _response[1].trim();
                    if (membership === "KIT") {
                        d.getElementById('Politicas').href = "PoliticsKit.aspx";
                    }
                    else if (membership === "SBY") {
                        d.getElementById('Politicas').href = "PoliticsStaBye.aspx";
                    }
                    else {
                        d.getElementById('Politicas').href = "Politics.aspx";
                    }

                    d.getElementById('List-Doc').className = "";
                }
            });


            return false;
        }
    </script>
</body>
</html>
