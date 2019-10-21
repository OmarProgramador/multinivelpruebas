<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wallet.aspx.cs" Inherits="MULTI_NIVEL.Views.Wallet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Wallet | inResorts</title>
    <link href="Css/css.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <link href="tienda_files/font-awesome.css" rel="stylesheet">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>
    <style>
        .custom-file {
            position: relative;
            display: inline-block;
            width: 100%;
            height: calc(1.5em + .75rem + 2px);
            margin-bottom: 0;
        }

        .custom-file-input {
            position: relative;
            z-index: 2;
            width: 100%;
            height: calc(1.5em + .75rem + 2px);
            margin: 0;
            opacity: 0;
        }

        .custom-file-label {
            position: absolute;
            top: 0;
            right: 0;
            left: 0;
            z-index: 1;
            height: calc(1.5em + .75rem + 2px);
            padding: .375rem .75rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            border: 1px solid #ced4da;
            border-radius: .25rem;
            transition: background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
        }

        input[type="file" i] {
            -webkit-appearance: initial;
            background-color: initial;
            cursor: default;
            padding: initial;
            border: initial;
        }

        input[type="file" i] {
            align-items: baseline;
            color: inherit;
            text-align: start !important;
        }

        .circle {
            border-radius: 50%;
            background-color: #d3d4d3;
            color: #fff;
            font-family: 'TelefonicaWeb-Bold';
            font-size: 25px;
            width: 48px;
            height: 48px;
            line-height: 44px;
            text-align: center;
            display: inline-block;
            border: 1px solid #d3d4d3;
            text-decoration: none;
            cursor: default;
        }

        .raya {
            content: "";
            width: 35px;
            height: 3px;
            display: inline-block;
            background-color: #d3d4d3;
            top: 31px;
            left: 109px;
        }

        .circle-active {
            background-color: #fff;
            border: 5px solid #2981c5;
            color: #2981c5;
            height: 62px;
            width: 62px;
            line-height: 48px;
        }

        .box-wallet {
            border: 5px solid #2981c5;
            margin: auto;
            width: auto;
            height: auto;
        }

        .table-wallet {
            padding: 5px;
            min-width: 200px;
            margin: auto;
        }

            .table-wallet th {
                color: #2981c5;
                padding: 5px;
            }

            .table-wallet td {
                padding: 5px;
                text-align: end;
            }
    </style>


</head>
<body class="top-navigation pace-done">
    <%-- <div id="divProgressBar">
        <div class="holder">
            <div class="preloader">
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
            </div>
        </div>
    </div>--%>
    <form id="form" runat="server">

        <div id="wrapper">
            <div id="page-wrapper" class="gray-bg">

                <div class="row border-bottom white-bg iniciowp">
                    <nav class="navbar navbar-static-top" role="navigation" style="height: 75px">
                        <div class="navbar-header header-inicio">
                            <button aria-controls="navbar" aria-expanded="false" data-target="#navbar" data-toggle="collapse" class="navbar-toggle collapsed" type="button">
                                <i class="fa fa-reorder"></i>
                            </button>
                            <a href="Index.aspx" class="navbar-brand inicio-logo">
                                <img src="img/novologo.png" class="img-responsive"></a>
                        </div>
                        <div class="navbar-collapse collapse" id="navbar">
                            <ul class="nav navbar-top-links navbar-right">
                                <li>
                                    <asp:Image ID="imgProfile" runat="server" alt="..." CssClass="img-circle img-responsive img-user" />
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle userClass" data-toggle="dropdown" role="button" aria-expanded="false">
                                        <asp:Label ID="lblUser" runat="server"></asp:Label>
                                        <span class="caret"></span></a>
                                    <ul class="dropdown-menu detalle-user" role="menu">
                                        <li>
                                            <div class="floatleft">
                                                <asp:Image ID="imgProfileFl" runat="server" alt="..." class="img-circle img-responsive img-user1" />
                                            </div>
                                            <div class="floatleft">
                                                <p>
                                                    <strong>
                                                        <asp:Label ID="lblUserName" runat="server"></asp:Label></strong>
                                                </p>
                                                <p class="green">
                                                    <asp:Label ID="lblNumPartner" runat="server"></asp:Label>
                                                </p>
                                            </div>
                                        </li>
                                        <li class="divider"></li>
                                        <li>
                                            <p class="col-md-6">
                                                <a href="Edit.aspx" style="margin: 0px; border-radius: 5px" class="btn btn-primary btn-sm block">Cuenta</a>
                                            </p>
                                            <p class="col-md-6">
                                                <a href="Edit.aspx" style="margin: 0px; border-radius: 5px" class="btn btn-primary btn-sm block">Cambiar Clave</a>
                                            </p>
                                            <center>
						                    <p class="col-md-12">							                                                                          
						                    <a href="SignOutC.aspx" class="btn btn-primary block" style=" margin: 0px; border-radius:5px">Salir</a>
                                            </p>
						                    </center>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </nav>
                </div>
                <div class="wrapper-content animated fadeInUp">
                    <div class="ibox float-e-margins">
                        <div class="ibox-content">
                            <div class="row visible-xs visible-sm linkstienda-movil">
                                <div class="linkstienda">
                                    <div class="col-xs-12">
                                        <div class="col-xs-3" style="width: 20% !important">
                                            <img class="center-block img-responsive" src="img/oficinavirtualsol.png" style="margin-top: 10px; max-height: 74px" border="0" />
                                        </div>
                                        <div class="col-xs-9 menu-lateral-opciones" style="display: block">
                                            <div class="col-xs-12">
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Register.aspx">
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block" border="0" />Nuevo Socio</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra " style="width: 20% !important">
                                                    <a href="Tools.aspx">
                                                        <img src="img/universidad.png" class="img-responsive center-block height" />Sistema Educativo</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Red.aspx">
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Árbol de patrocinio</a>
                                                </div>
                                                <div class=" col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Bonus.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block height" />Comisiones y Pagos</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Store.aspx">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0" />Tienda
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 20px; position: relative">
                                <div class="col-md-6">
                                    <img src="../Resources/Images/Payments.png" class="logo-seccion" align="left" />
                                    <h2 class="green"><b>Comisiones y Pagos</b></h2>
                                    <ol class="breadcrumb negro" style="background-color: #ffffff;">
                                        <li class="breadcrumb-item "><a href="Bonus.aspx">Mis comisiones</a></li>
                                        <li class="breadcrumb-item "><a href="Payments.aspx">Mis Pagos</a></li>
                                        <li class="breadcrumb-item"><a href="Activation.aspx">Mis Activaciones</a></li>
                                        <li class="breadcrumb-item active"><a class="subrayar" href="Wallet.aspx">Wallet</a></li>
                                    </ol>
                                </div>
                                <div class="col-md-6">
                                    <div class="linkstienda visible-md visible-lg">
                                        <div class="col-md-3" style="width: 20% !important">
                                            <!-- <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1000)">
														<img class="center-block oficinaimg" src=""	border="0" />
													</a> -->
                                            <a href="javascript:void(0)" onclick="abrete()">
                                                <img class="center-block oficinaimg" src="img/oficinavirtualsol.png" border="0">
                                            </a>
                                        </div>
                                        <div id="abierto" class="col-md-9 menu-lateral-opciones" style="display: none">
                                            <div class="row">
                                                <div class="col-md-2 separadorbarra" style="z-index: 100;">
                                                    <a href="Register.aspx">
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block height" />Nuevo Socio</a>
                                                </div>
                                                <div class=" col-md-2 separadorbarra " style="z-index: 100;">
                                                    <a href="Tools.aspx">
                                                        <img src="img/universidad.png" class="img-responsive center-block height" />Sistema Educativo</a>
                                                </div>
                                                <div class="col-md-2  separadorbarra " style="z-index: 100;">
                                                    <a href="Red.aspx">
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block height" />Árbol de patrocinio</a>
                                                </div>
                                                <div class="  col-md-2 separadorbarra ">
                                                    <a href="Bonus.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block height" />Comisiones y Pagos</a>
                                                </div>
                                                <%--  <div class="  col-md-2 separadorbarra css1">
                                            <a href="payments.aspx" class="csspay">
                                                <img src="../Resources/Images/Payments.png" class="img-responsive center-block height">Mis Pagos</a>
                                        </div>--%>
                                                <div class="col-sm-1 col-md-2 separadorbarra ">
                                                    <a href="Store.aspx">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0" />Tienda
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="ibox float-e-margins">
                            <div class="ibox-content">
                                <h2>Saldo Disponible: $ 
                                    <asp:Label ID="Savailable" Text="00.00" runat="server" /></h2>
                                <h2>Saldo Contable: $ 
                                    <asp:Label ID="Scontaible" Text="00.00" runat="server" /></h2>
                                <asp:Label ID="OpcionDisplay" Text="1" runat="server" Style="display: none" />
                                <p style="color:green;">Nota: Los montos estan en dolares</p>
                                <hr>

                                <div class="tabs-container">
                                    <ul class="nav nav-tabs">
                                        <li class="nav-item ">
                                            <asp:HyperLink NavigateUrl="#tab-1" class="nav-link cabecera active show" data-toggle="tab" runat="server" ID="Movimi">Movimientos</asp:HyperLink>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#tab-2" id="Transf" class="nav-link cabecera" data-toggle="tab">Tranferencia a Cuenta</a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#tab-3" class="nav-link cabecera" data-toggle="tab">Transferencia entre Wallet</a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#tab-4" class="nav-link cabecera" data-toggle="tab">Reportar Problemas de Wallet</a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#tab-5" class="nav-link cabecera" data-toggle="tab">Tranferencia a MI Pay Pal</a>
                                        </li>
                                    </ul>
                                    <div class="tab-content">
                                        <div id="tab-1" class="tab-pane active">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
                                                    </div>
                                                </div>
                                                <div class="row">

                                                    <div class="col-md-12">
                                                        <div class="row box-hr">
                                                            <hr />
                                                        </div>
                                                        <div class="row col-lg-12" id="mensajes" style="padding: 20px;">

                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    <div id="dataHtml">
                                                                        <img src="../Resources/Images/Loading.gif" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="tab-2" class="tab-pane">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <h2>Solicitar Transferencia</h2>
                                                        <br />
                                                    </div>
                                                    <div class="col-sm-4">
                                                        Monto
                                                        <asp:TextBox ID="MontoSolitud" runat="server" class="form-control" Style="max-width: 400px" />
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <br />
                                                        <asp:FileUpload ID="Document" runat="server" />
                                                        <label style="color: red">Obligatorio a partir del 10/06/2019</label>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <asp:Button ID="SendDocument" Text="Solicitar" runat="server" class="btn btn-success" OnClick="SendDocument_Click" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <asp:Label ID="LblMessage" Text="" runat="server" ForeColor="Red" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <h3>Historial de solicitudes</h3>
                                                        <div id="List-Doc">
                                                            <img src="../Resources/Images/Loading.gif" width="100px" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="tab-3" class="tab-pane">
                                            <div class="panel-body text-center">
                                                <div class="row">
                                                    <div class="col-lg-12">

                                                        <div id="circle1" class="circle circle-active">1</div>
                                                        <div class="raya"></div>
                                                        <div id="circle2" class="circle">2</div>
                                                        <div class="raya"></div>
                                                        <div id="circle3" class="circle">3</div>
                                                    </div>
                                                </div>
                                                <div id="modulo1" class="row">
                                                    <div class="col-sm-12">
                                                        <br />
                                                        <p>Datos de la transferencia</p>
                                                        <div class="form-inline">
                                                            <label>UserName:</label>
                                                            <input type="text" id="Trans-UserName" name="Trans-UserName" value="" class="form-control" />
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12 mt-4">
                                                        <br />
                                                        <div class="form-inline">
                                                            <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Monto: $</label>
                                                            <input type="text" id="Trans-Amount" name="Trans-Amount" value="" class="form-control" style="max-width: 200px;" />
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <p id="messaggeErrorTra" style="color: red;"></p>
                                                        <br />
                                                        <input id="BtnStepTwo" type="button" name="name" value="Siguiente" class="btn btn-success" onclick="StepTwo()" />
                                                    </div>
                                                </div>
                                                <div id="modulo2" class="row display-none">
                                                    <div class="row col-lg-12">
                                                        <br />
                                                        <p>Datos de la transferencia</p>
                                                        <table class="table-wallet">
                                                            <tbody>
                                                                <tr>
                                                                    <th>Usuario</th>
                                                                    <td id="Info-FullName"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>

                                                        <table class="table-wallet">
                                                            <tbody>
                                                                <tr>
                                                                    <th>Monto</th>
                                                                    <td id="Info-Amount"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <hr style="max-width: 250px" />
                                                        <p># Se ha enviado tu clave digital al correo: <span id="Info-Email"></span></p>
                                                    </div>
                                                    <div class="row col-lg-12">
                                                        <div class="form-inline">
                                                            <label>Clave Digital: </label>
                                                            <input id="ClaveDigital" type="text" name="name" value="" class="form-control" />
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <p id="messaggeErrorTra2" style="color: red;"></p>
                                                        <br />
                                                        <input id="BtnShowConfirm" type="button" name="name" value="Siguiente" class="btn btn-success" onclick="ShowConfirm()" />
                                                    </div>
                                                </div>
                                                <div id="modulo3" class="row display-none">
                                                    <div class="row col-lg-12">
                                                        <br />
                                                        <img src="../Resources/Images/check.png" style="width: 100px;" />
                                                        <p>Tu transferencia se ha realizado con exito</p>

                                                        <table class="table-wallet">
                                                            <tbody>
                                                                <tr>
                                                                    <th>Usuario</th>
                                                                    <td id="Info-FullName2"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table class="table-wallet">
                                                            <tbody>
                                                                <tr>
                                                                    <th>Monto</th>
                                                                    <td id="Info-Amount2"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div id="modulo4" class="row display-none">
                                                    <div class="row col-lg-12">
                                                        <br />
                                                        <img src="../Resources/Images/x.svg" alt="Alternate Text" style="width: 100px;" />
                                                        <p>Ocurrio un Error al realizar Tu transferencia</p>
                                                        <input type="button" name="name" value="Intentarlo Nuevamente" class="btn btn-success" onclick="javascript: location.reload()" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="tab-4" class="tab-pane">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <div style="max-width: 450px; margin: auto;">
                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    <h2 class="text-center">Reportar Problemas</h2>
                                                                </div>
                                                                <div class="col-lg-12">
                                                                    <div class="form-group">
                                                                        <label>Asunto</label>
                                                                        <input id="Report-Subjet" type="text" name="name" value="" class="form-control" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-12">
                                                                    <div class="form-group">
                                                                        <label>Mensaje</label>
                                                                        <textarea id="Report-Message" class="form-control" style="max-width: 450px; min-height: 100px; max-height: 200px;">
                                                                        </textarea>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-12">
                                                                    <p id="messaggeErrorrep" style="color: red"></p>
                                                                    <p id="messaggeErrorrep2" style="color: green"></p>
                                                                    <input id="BtnReport" type="button" name="name" value="Enviar Mensaje" class="btn btn-success btn-block" onclick="Report()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="tab-5" class="tab-pane">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <p>Puede retirar sus comisiones atravez de su cuenta de pay pal.</p>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <div class="form-inline">
                                                            <label>Cuenta Paypal: </label>
                                                            <input type="text" name="name" value="" class="form-control" />
                                                            <input type="button" name="name" value="Transferir" class="btn btn-success" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="footer footer-fondo">
                    <strong>inResorts - 2018</strong>
                </div>
            </div>
        </div>
        <div class="modal" id="confirmModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Confirmar</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        ¿Desea Confirmar Su Transferencia?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <button id="BtnTranferMoney" type="button" class="btn btn-primary" onclick="TranferMoney()">Confirmar</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <style>    
    </style>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="Script/Script.js"></script>
    <script>

        var d = document

        window.onload = function () {


            var param = "action=get"

            function DisplayWallet(data) {
                d.getElementById('dataHtml').innerHTML = data
            }

            GetDos("WalletC", param, DisplayWallet)


            var opcion = d.getElementById('OpcionDisplay').innerHTML

            if (opcion == 2) {
                d.getElementById('Transf').className = "nav-link cabecera active show"
                d.getElementById('Movimi').className = "nav-link cabecera"

                d.getElementById('tab-2').className = "tab-pane active"
                d.getElementById('tab-1').className = "tab-pane"

                function DisplayDoc(data) {
                    d.getElementById('List-Doc').innerHTML = data;
                }

                GetDos("WalletC", "action=getDoc", DisplayDoc)
            }

            console.log(opcion);

        }

        d.getElementById('Transf').addEventListener("click", () => {

            function DisplayDoc(data) {
                d.getElementById('List-Doc').innerHTML = data;
            }

            GetDos("WalletC", "action=getDoc", DisplayDoc)
        })

        function abrete() {
            let menu = document.getElementById('abierto')

            if (menu.style.display == 'none') {
                menu.style.display = 'block';
            } else {
                menu.style.display = 'none';
            }

        }

        function StepTwo() {

            d.getElementById('BtnStepTwo').disabled = true;

            var _userNameBen = d.getElementById('Trans-UserName').value;
            var _amount = d.getElementById('Trans-Amount').value;

            if (_userNameBen.trim() == "") {
                d.getElementById('messaggeErrorTra').innerText = "UserName es un campo Obligatorio";
                d.getElementById('Trans-UserName').focus();
                d.getElementById('BtnStepTwo').disabled = false;
                return;
            }
            if (_userNameBen.trim().length < 8) {
                d.getElementById('messaggeErrorTra').innerText = "UserName minimo 8 caracteres";
                d.getElementById('Trans-UserName').focus();
                d.getElementById('BtnStepTwo').disabled = false;
                return;
            }
            if (_amount.trim() == "") {
                d.getElementById('messaggeErrorTra').innerText = "Monto es un campo Obligatorio";
                d.getElementById('Trans-Amount').focus();
                d.getElementById('BtnStepTwo').disabled = false;
                return;
            }

            let validarNumber = parseFloat(_amount);

            if (isNaN(validarNumber)) {

                d.getElementById('messaggeErrorTra').innerText = "El Monto no es un numero valido";
                d.getElementById('Trans-Amount').focus();
                d.getElementById('BtnStepTwo').disabled = false;
                return;
            }

            let param = "action=infoper&userNameBen=" + _userNameBen + "&amount=" + _amount;
            GetDos("WalletC", param, (_data) => {
                let arrayRes = _data.split('|');
                if (arrayRes[0] == "false") {
                    d.getElementById('messaggeErrorTra').innerText = "No es un UserName Valido";
                    d.getElementById('BtnStepTwo').disabled = false;
                } else {

                    d.getElementById('Info-Email').innerText = arrayRes[2];

                    d.getElementById('Info-FullName').innerText = arrayRes[1];
                    d.getElementById('Info-FullName2').innerText = arrayRes[1];
                    d.getElementById('Info-Amount').innerText = "S/ " + arrayRes[3];
                    d.getElementById('Info-Amount2').innerText = "S/ " + arrayRes[3];

                    d.getElementById('modulo1').classList.toggle('display-none');
                    d.getElementById('modulo2').classList.toggle('display-none');
                    d.getElementById('circle1').classList.toggle('circle-active');
                    d.getElementById('circle2').classList.toggle('circle-active');
                }
            });
        }

        function ShowConfirm() {
            d.getElementById('BtnShowConfirm').disabled = true;

            let digital = d.getElementById('ClaveDigital').value;

            if (digital.trim().length != 6) {
                d.getElementById('messaggeErrorTra2').innerText = "Clave Digital minimo 6 caracteres";
                d.getElementById('ClaveDigital').focus();
                d.getElementById('BtnShowConfirm').disabled = false;
                return;
            }
            $('#confirmModal').modal("show");
            d.getElementById('BtnShowConfirm').disabled = false;
        }

        function TranferMoney() {

            d.getElementById('BtnTranferMoney').disabled = true;

            let digital = d.getElementById('ClaveDigital').value;

            if (digital.trim().length != 6) {
                d.getElementById('messaggeErrorTra2').innerText = "Clave Digital minimo 6 caracteres";
                d.getElementById('ClaveDigital').focus();
                d.getElementById('BtnTranferMoney').disabled = false;
                return;
            }

            let _amount = d.getElementById('Info-Amount').innerText.substring(2);

            let validarNumber = parseFloat(_amount);

            if (isNaN(validarNumber)) {

                d.getElementById('messaggeErrorTra').innerText = "El Monto no es un numero valido";
                d.getElementById('Trans-Amount').focus();
                d.getElementById('BtnStepTwo').disabled = false;
                return;
            }

            let param = "action=validtoken&clave=" + digital + "&amount=" + _amount;
            GetDos("WalletC", param, (_data) => {

                if (_data == "true") {
                    d.getElementById('modulo2').classList.toggle('display-none');
                    d.getElementById('modulo3').classList.toggle('display-none');
                    d.getElementById('circle2').classList.toggle('circle-active');
                    d.getElementById('circle3').classList.toggle('circle-active');
                } else {
                    d.getElementById('modulo2').classList.toggle('display-none');
                    d.getElementById('modulo4').classList.toggle('display-none');
                    d.getElementById('circle2').classList.toggle('circle-active');
                    d.getElementById('circle3').classList.toggle('circle-active');
                }

                $('#confirmModal').modal("hide");
            });
        }

        function Report() {
            d.getElementById('BtnReport').disabled = true;

            let subjet = d.getElementById('Report-Subjet').value.trim();
            let messagge = d.getElementById('Report-Message').value.trim();

            if (subjet.trim().length < 6) {
                d.getElementById('messaggeErrorrep').innerText = "El Asunto minimo 6 caracteres";
                d.getElementById('Report-Subjet').focus();
                d.getElementById('BtnReport').disabled = false;
                return;
            }

            if (messagge.trim().length < 10) {
                d.getElementById('messaggeErrorrep').innerText = "El Mensaje minimo 10 caracteres";
                d.getElementById('Report-Message').focus();
                d.getElementById('BtnReport').disabled = false;
                return;
            }
            let param = "action=sendreport&subjet=" + subjet + "&messagge=" + messagge;
            GetDos("WalletC", param, (_data) => {
                if (_data == "true") {
                    d.getElementById('messaggeErrorrep').innerText = "";
                    d.getElementById('messaggeErrorrep2').innerText = "Tu Mensaje se envio correctamente";
                    d.getElementById('Report-Subjet').value = "";
                    d.getElementById('Report-Message').value = "";
                } else {
                    d.getElementById('messaggeErrorrep').innerText = "Ocurrio un Error";
                    d.getElementById('messaggeErrorrep2').innerText = "";
                }
                d.getElementById('BtnReport').disabled = false;
            });
        }
    </script>
</body>
</html>
