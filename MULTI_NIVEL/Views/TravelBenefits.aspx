<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TravelBenefits.aspx.cs" Inherits="MULTI_NIVEL.Views.TravelBenefits" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tienda | inResorts</title>
    <link href="tienda_files/css.css" rel="stylesheet">
    <link href="tienda_files/style.css" rel="stylesheet">
    <link href="tienda_files/bootstrap.css" rel="stylesheet">
    <link href="tienda_files/font-awesome.css" rel="stylesheet">
    <link href="tienda_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="tienda_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="tienda_files/chosen.css" rel="stylesheet">
    <link href="tienda_files/croppie.css" rel="stylesheet">
    <link href="tienda_files/datepicker3.css" rel="stylesheet">
    <link href="tienda_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="tienda_files/ladda-themeless.css" rel="stylesheet">
    <link href="tienda_files/sweetalert.css" rel="stylesheet">
    <link href="tienda_files/animate.css" rel="stylesheet">
    
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">

    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link href="Css/MyStyle.css" rel="stylesheet" />

  
    <script src="tienda_files/jquery-3.js"></script>
    <script src="tienda_files/bootstrap.js"></script>
    <script src="tienda_files/jquery_005.js"></script>
    <script src="tienda_files/jquery_011.js"></script>
    <script src="tienda_files/inspinia.js"></script>
    <script src="tienda_files/pace.js"></script>
    <script src="tienda_files/jquery_002.js"></script>
    <script src="tienda_files/jquery_006.js"></script>
    <script src="tienda_files/jquery_009.js"></script>
    <script src="tienda_files/Chart.js"></script>
    <script src="tienda_files/jasny-bootstrap.js"></script>
    <script src="tienda_files/jquery_003.js"></script>
    <script src="tienda_files/jquery_007.js"></script>
    <script src="tienda_files/peity-demo.js"></script>
    <script src="tienda_files/datatables.js"></script>
    <script src="tienda_files/chosen.js"></script>
    <script src="tienda_files/croppie.js"></script>
    <script src="tienda_files/sweetalert.js"></script>
    <script src="tienda_files/bootstrap3-typeahead.js"></script>
    <script src="tienda_files/jquery_008.js"></script>
    <script src="tienda_files/bootstrap-datepicker.js"></script>
    <script src="tienda_files/jquery.js"></script>
    <script src="Script/Script.js"></script>
    <script>
        var base_url = ' ';
        var idsocio = 168;
        var idopera = 1;
        var nombresocio = '';
        var direcsocio = '';
        var rango = '2';
        var simbolo = 'S/.';
        var csrfsn = '';
        //document.addEventListener('contextmenu', event => event.preventDefault());
    </script>

</head>
<body class="top-navigation  pace-done" onload="OnloadBody();">




    <form runat="server">

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
                            <asp:Panel runat="server" ID="menu">
                                <ul class="nav navbar-top-links navbar-right header-inicior">
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
                                                    <a href="Edit.aspx" class="btn btn-primary btn-sm block">Cuenta</a>
                                                </p>
                                                <p class="col-md-6">
                                                    <a href="Edit.aspx" class="btn btn-primary btn-sm block">Cambiar Clave</a>
                                                </p>
                                                <center>
						                        <p class="col-md-12">							                            
                                                    <asp:LinkButton ID="lblSalir" runat="server" OnClick="lbkBtnSalir_Click" CssClass="btn btn-primary block" Text="Salir"></asp:LinkButton>
						                        </p>
						                    </center>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </asp:Panel>
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
                                            <img class="center-block img-responsive" src="img/oficinavirtualsol.png" style="margin-top: 10px; max-height: 74px" border="0">
                                        </div>
                                        <div class="col-xs-9 menu-lateral-opciones" style="display: block">
                                            <div class="col-xs-12">
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Register.aspx">
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block" border="0" />Nuevo Socio</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra " style="width: 20% !important">
                                                    <a href="http://reservas.inresorts.club/riberatravel">
                                                        <img src="img/avion.png" class="img-responsive center-block height">Viajes</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Red.aspx">
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Árbol de patrocinio</a>
                                                </div>
                                                <div class=" col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="commissions.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block height">Comisiones y Pagos</a>
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
                                    <img src="img/avion.png" class="logo-seccion" align="left">
                                    <h2 class="green"><b>Viajes</b></h2>
                                    <ol class="breadcrumb negro">
                                        <%--  <li class="breadcrumb-item"><a href="AddMembership.aspx">Paquetes</a></li>
                                        <li class="breadcrumb-item "><a href="Store.aspx">Servicios</a></li>--%>
                                        <li class="breadcrumb-item active"><a href="TravelBenefits.aspx">Beneficios de Viajes</a></li>
                                        <%-- <li class="breadcrumb-item "><a href="Eagency.aspx">E-agencias</a></li>
                                        <li class="breadcrumb-item "><a href="HistorialCompras.aspx">Mis Compras</a></li>--%>
                                    </ol>
                                </div>
                                <div class="col-md-6">
                                    <div class="linkstienda visible-md visible-lg">

                                        <div class="col-md-3" style="width: 20% !important">
                                            <!-- <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1000)">
                                            <img class="center-block oficinaimg" src=" "  border="0" />
                                        </a> -->
                                            <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1)">
                                                <img class="center-block oficinaimg" src="img/oficinavirtualsol33.png" border="0">
                                            </a>
                                        </div>

                                        <div class="col-md-9 menu-lateral-opciones">
                                            <div class="row">
                                                <div class="col-md-2 separadorbarra" style="z-index: 100;">
                                                    <a href="Register.aspx">
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block height">Nuevo Socio</a>
                                                </div>
                                                <div class=" col-md-2 separadorbarra " style="z-index: 100;">
                                                    <a href="http://reservas.inresorts.club/riberatravel">
                                                        <img src="img/avion.png" class="img-responsive center-block height">Viajes</a>
                                                </div>
                                                <div class="col-md-2  separadorbarra " style="z-index: 100;">
                                                    <a href="Red.aspx">
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block height">Árbol de patrocinio</a>
                                                </div>
                                                <div class="  col-md-2 separadorbarra ">
                                                    <a href="commissions.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block height">Comisiones y Pagos</a>
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
                            <%--                            <h3 style="font-family: 'open sans', 'Helvetica Neue'; font-size: 30px; font-weight: bold; font-weight: 600; height: auto; margin: 25px auto; display: block; width: 300px;">Solicitud de Código</h3>--%>


                            <h4 style="font-family: 'open sans', 'Helvetica Neue'; font-size: 29px; font-weight: 600; height: auto; padding: 0px; border-width: 0px; transform: rotate(0deg) scale(1, 1); opacity: 1; visibility: visible; margin: 0px;">Cliente

                            </h4>
                            <hr style="margin-top: 0px; border: 0.5px solid #23232359;" />



                            <div class="tabs-container">
                                <ul class="nav nav-tabs">
                                    <%--<li class=""><a class="cabecera" data-toggle="tab" href="#tab-1">Datos de la cuenta</a></li>--%>
                                    <%--<li class=""><a class="cabecera" data-toggle="tab" href="#tab-2">Datos personales</a></li>
                                        <li class=""><a class="cabecera" data-toggle="tab" href="#tab-3">Datos bancarios</a></li>
                                        <li class=""><a class="cabecera" data-toggle="tab" href="#tab-4">Documentos</a></li>--%>
                                    <li class="active"><a class="cabecera" data-toggle="tab" href="#tab1-2">Clientes</a></li>
                                </ul>
                            </div>

                            <div id="tab1-2" class="tab-pane">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <input id="NuevoBeneficiario" type="button" name="name" value="Nuevo Cliente"
                                                data-toggle="modal" data-target="#beneficiarioModalCenter" class="btn btn-primary" />
                                        </div>
                                    </div>
                                    <div class="row display-none" id="divMessagge">
                                        <div class="col-sm-12">
                                            <div class="alert alert-success" role="alert">
                                                <span id="messagge"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div id="listBeneficiarios"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <br />

                            <h4 style="font-family: 'open sans', 'Helvetica Neue'; font-size: 29px; font-weight: 600; height: auto; padding: 0px; border-width: 0px; transform: rotate(0deg) scale(1, 1); opacity: 1; visibility: visible; margin: 0px;">Códigos

                            </h4>
                            <hr style="margin-top: 0px; border: 0.5px solid #23232359;" />
                            <div class="tabs-container">
                                <ul class="nav nav-tabs">
                                    <li class="active">
                                        <a class="cabecera" data-toggle="tab" href="#tab-1" aria-expanded="true">Activo</a></li>
                                    <%--<li class=""><a class="cabecera" data-toggle="tab" href="#tab-2" aria-expanded="false">Historial</a></li>--%>
                                </ul>
                                <div class="tab-content">
                                    <div id="tab-1" class="tab-pane active">
                                        <div class="panel-body">
                                            <div id="listTravel">
                                            </div>

                                        </div>
                                    </div>
                                    <%--<div id="tab-2" class="tab-pane">
                                        <div class="panel-body">
                                            <div class="table-responsive m-t">

                                                <p class="blue">
                                                    <b>Historico de codigos usados: 
                                                 <span id="RangoSoc"></span></b>
                                                </p>
                                                <div>
                                                    <table class="table table-bordered tblListaPatrocinados" cellspacing="0" rules="all" border="1"
                                                        id="tablecita brrr2" style="border-collapse: collapse;">
                                                        <tbody>
                                                            <tr>
                                                                <th scope="col">#Codigo</th>
                                                                <th scope="col">Status</th>
                                                                <th scope="col">Usuario</th>
                                                                <th scope="col">Pasword</th>
                                                                <th scope="col">Codigo</th>
                                                            </tr>
                                                            <tr>
                                                                <td>Codigo1</td>
                                                                <td>Pendiente</td>
                                                                <td>Correo@hot.com</td>
                                                                <td>pass</td>
                                                                <td>k71132</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Codigo2</td>
                                                                <td>Pendiente</td>
                                                                <td>Correo@hot.com</td>
                                                                <td>pass</td>
                                                                <td>k71132</td>
                                                            </tr>
                                                        </tbody>

                                                    </table>
                                                </div>


                                                <div class="floatleft">
                                                    <p class="blue">

                                                        <span id="totalAfi"></span>
                                                    </p>
                                                    <p class="blue">

                                                        <span id="ramaFuerte"></span>

                                                        <span id="totalAfiRamF"></span>

                                                    </p>
                                                    <div class="blue">
                                                        <p class="blue">

                                                            <span id="PuntosRF"></span>
                                                        </p>
                                                        <p class="blue" style="display: none">

                                                            <span id="ptosRF"></span>
                                                        </p>
                                                        <p class="blue">

                                                            <span id="PuntosSocio"></span>
                                                        </p>

                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>--%>
                                </div>
                            </div>


                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-12 col-md-12" style="z-index: 10; padding: 30px; margin: auto; text-align: center">

                                        <div style="" class="">
                                            <asp:Label Text="Acceso" runat="server" />
                                            <a href="#" style="font-size: 16px">link de acceso </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-12 col-md-12" style="z-index: 10; padding: 10px; margin: auto">

                                        <div class="col-md-12 col-sm-12 " data-id="80" data-name="" style="text-align: center;">
                                            <div class=" ">
                                                <button id="myBtn" class="myBtnc" data-toggle="modal" data-target="#myModal" type="button" runat="server" style="width: 50%; height: 45px; border-radius: 8px; background-color: #ffffff00; color: #2a77c1; font-size: 18px; font-weight: bold; font-family: sans-serif; border: 1px solid #4987c3; margin: 0 auto;">
                                                    Generar Código
                                                </button>

                                            </div>


                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 col-md-12" style="z-index: 10; padding: 10px; margin: auto">

                                        <div class="col-md-12 col-sm-12 " data-id="80" data-name="" style="text-align: center;">
                                            <div class=" ">
                                                <button id="Button1" class="myBtnc" data-toggle="modal" data-target="#myModal" type="button" runat="server" style="width: 50%; height: 45px; border-radius: 8px; background-color: #ffffff00; color: #2a77c1; font-size: 18px; font-weight: bold; font-family: sans-serif; border: 1px solid #4987c3; margin: 0 auto;">
                                                    Comprar Código
                                                </button>

                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>


                            <h4 style="font-family: 'open sans', 'Helvetica Neue'; font-size: 29px; font-weight: 600; height: auto; padding: 0px; border-width: 0px; transform: rotate(0deg) scale(1, 1); opacity: 1; visibility: visible; margin-left: 0px; margin-top: 0px;">Ganacias de los Beneficios de Viajes

                            </h4>

                            <hr style="margin-top: 0px; border: 0.5px solid #23232359;" />
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-12 col-md-12" style="z-index: 10; padding: 30px; margin: auto">
                                        <h2 style="font-family: 'open sans', 'Helvetica Neue'; font-weight: bold; text-align: justify; text-shadow: 0 0 12px #fffffffa; font-size: 22px; font-weight: 400; height: auto; padding: 0px; border-width: 0px; transform: rotate(0deg) scale(1, 1); opacity: 1; visibility: visible; margin: 15px;">Declatorias
                                        </h2>

                                        <div class="col-md-12">
                                            <div class="btn-group btn-group-justified m-b-md group-tienda" role="group" aria-label="...">
                                            </div>

                                            <h3></h3>
                                            <div class="box m-b-md" id="prodnom">
                                                <div class="col-md-4 col-sm-4 noproducto" data-id="80" data-name=""
                                                    style="border: 1px solid; border-radius: 10px;">
                                                    <div class="ibox-content text-center no-border">
                                                        <p class="font-bold contprod">
                                                            <span class=""><b>Paquete vacacional</b></span><br>
                                                        </p>
                                                        <div class="m-b-sm text-center">
                                                            <img class="img-responsive fotoprod" src="img/collage5.png">
                                                        </div>


                                                        <a href="DetailStore.aspx?id=s6">
                                                            <button name="btnAgregar" data-id="80" data-tipo="2"
                                                                class="btn btn-sm btn-primary btn-block pull-center m-t-n-xs"
                                                                data-style="expand-right" type="button">
                                                                AGREGAR</button>
                                                        </a>
                                                    </div>
                                                </div>
                                                <%--<div class="col-md-4 col-sm-4 noproducto" data-id="81" data-name="">
                                            <div class="ibox-content text-center no-border">
                                                <p class="font-bold contprod">
                                                    <span class=""><b>Ticket Aereo</b></span><br>
                                                    
                                                </p>
                                                <div class="m-b-sm text-center">
                                                    <img class="img-responsive fotoprod" src="img/ticketaereo.png">
                                                </div>
                                                
                                              
                                                 <a href="DetailStore.aspx?id=v2">
                                                <button name="btnAgregar" data-id="81" data-tipo="2" class="btn btn-sm btn-primary btn-block pull-center m-t-n-xs" data-style="expand-right" type="button">AGREGAR</button>
                                                      </a>
                                            </div>
                                        </div>


                                        <div class="col-md-4 col-sm-4 noproducto" data-id="82" data-name="">
                                            <div class="ibox-content text-center no-border">
                                                <p class="font-bold contprod">
                                                    <span class=""><b>Hotel</b></span><br>
                                                    
                                                </p>
                                                <div class="m-b-sm text-center">
                                                    <img alt="image Peso:159/Unidad:0" class="img-responsive fotoprod" src="img/hotel10.jpg">
                                                </div>
                                               
                                               
                                                <a href="DetailStore.aspx?id=v3">
                                                <button name="btnAgregar" data-id="82" data-tipo="2" class="btn btn-sm btn-primary btn-block pull-center m-t-n-xs" data-style="expand-right" type="button">AGREGAR</button>
                                                    </a>
                                            </div>
                                        </div>--%>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 col-md-12" style="z-index: 10; padding: 30px; margin: auto">
                                        <h2 style="font-family: 'open sans', 'Helvetica Neue'; font-weight: bold; text-align: justify; text-shadow: 0 0 12px #fffffffa; font-size: 22px; font-weight: 400; height: auto; padding: 0px; border-width: 0px; transform: rotate(0deg) scale(1, 1); opacity: 1; visibility: visible; margin: 15px;">Comisiones
                                        </h2>

                                        <div class="container">
                                            <div class="panel-group" id="accordion2">
                                                <div>
                                                    <a class="panel-default" data-toggle="collapse" data-parent="#accordion2" href="#collapse14" aria-expanded="true">
                                                        <div class="panel-heading " style="background-color: rgb(102, 134, 181); color: white">
                                                            <h4 class="panel-title"><span class="caret"></span>Hotel</h4>
                                                        </div>
                                                    </a>
                                                    <div id="collapse14" class="panel-collapse collapse" aria-expanded="true" style="">
                                                        <div class="panel-body">
                                                            <div id="listHotel2"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>



                        </div>
                        <br />

                        <div id="myModal" class="modal" style="display: none; padding-right: 17px;">
                            <div class="modal-content">
                                <span class="close" data-dismiss="modal">×</span>

                                <div class="modal-header">
                                    <img src="img/novologo.png" alt="Alternate Text" width="100">
                                </div>

                                <div class="modal-header">
                                    <h1>Informacion</h1>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Nombres</label>
                                                <input type="text" name="name" id="nameUser" value="" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Apellidos</label>
                                                <input type="text" name="name" id="lastNameUser" value="" class="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Correo</label>
                                                <input type="text" name="name" id="emailUser" value="" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Telefono</label>
                                                <input type="text" name="name" id="phoneUser" value="" class="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>La fecha de expiracion</label>
                                                <select id="duration" class="form-control">
                                                    <option value="">--Seleccionar--</option>
                                                    <option value="1">1 Dia</option>
                                                    <option value="3">3 Dias</option>
                                                    <option value="7">7 Dias</option>
                                                    <option value="15">15 Dias</option>
                                                    <option value="30">30 Dias</option>
                                                    <option value="45">45 Dias</option>
                                                    <option value="90">90 Dias</option>
                                                </select>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <center>                                       
                                        <small id="error-travel" style="color:red;"></small>
                                        <input id="btnPutTrave" type="button" name="name" value="Aceptar" class="btn btn-primary" onclick="btnPutTravel();"/>
                                        <button type="button" class="btn" data-dismiss="modal"> Cancelar</button> 
                                    </center>
                            </div>
                        </div>




                        <div id="beneficiarioModalCenter" class="modal" style="display: none; padding-right: 17px;">
                            <div class="modal-content">
                                <span class="close" data-dismiss="modal">×</span>

                                <div class="modal-header">
                                    <img src="img/novologo.png" alt="Alternate Text" width="100">
                                </div>

                                <div class="modal-header">
                                    <h1>Nuevo Cliente</h1>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Nombres</label>
                                                <%--<input type="text" name="name" id="nameTraveler" value="" class="form-control" />--%>
                                                <asp:TextBox ID="nameTraveler" runat="server" class="form-control input-sm capitalize" type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Apellidos</label>
                                                <%--<input type="text" name="name" id="lastNameTraveler" value="" class="form-control" />--%>
                                                <asp:TextBox ID="lastNameTraveler" runat="server" class="form-control input-sm capitalize" type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Correo</label>
                                                <%--<input type="text" name="name" id="emailTraveler" value="" class="form-control" />--%>
                                                <asp:TextBox ID="emailTraveler" runat="server" class="form-control input-sm capitalize" type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Telefono</label>
                                                <div style="display: flex;">   
                                                    <asp:TextBox ID="codePhone" runat="server" style="max-width:10%" CssClass="form-control" placeholder="+51"/>
                                                    <asp:TextBox ID="phoneTraveler" runat="server" class="form-control" type="text" style="max-width:90%" placeholder="999 999 999"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <center>
                                        <asp:LinkButton class="btn" runat="server" onclick="btnComprar_Click" Text="Confirmar"> </asp:LinkButton>
                                        <button type="button" class="btn" data-dismiss="modal" > Cancelar</button> 
                                      </center>

                                <%--<center>                                       
                                       
                                        <input id="btnPutTrave" type="button" name="name" value="Aceptar" class="btn btn-primary" onclick="btnPutTravel();"/>
                                        <button type="button" class="btn" data-dismiss="modal"> Cancelar</button> 
                                    </center>--%>
                            </div>
                        </div>




                        <div id="mdlEditBenef" class="modal" style="display: none; padding-right: 17px;">
                            <div class="modal-content">
                                <span class="close" data-dismiss="modal">×</span>

                                <div class="modal-header">
                                    <img src="img/novologo.png" alt="Alternate Text" width="100">
                                </div>

                                <div class="modal-header">
                                    <h1>Edit Cliente</h1>
                                </div>
                                <div class="modal-body">
                                    <div class="row col-lg-12">
                                        <input type="hidden" id="operacion" name="name" value="" />
                                        <input type="hidden" id="idEdit" name="name" value="" />
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Nombres</label>
                                                <input type="text" name="" id="nameEdit" value="" class="form-control"/>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Apellidos</label>
                                                <input type="text" name="" id="lastNameEdit" value="" class="form-control"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Correo</label>
                                                <input type="text" name="" id="emailEdit" value="" class="form-control"/>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <%--<div class="form-group">
                                                <label>Codido Pais</label>
                                                <input type="text" name="" id="codCountryfEdit" value="" />
                                            </div>--%>
                                            <div class="form-group">
                                                <label>Telefono</label>
                                                <div style="display:flex;">
                                                    <input type="text" name="" id="codeEdit" value="" style="max-width: 10%; text-align: center;" class="form-control" placeholder="+51" />
                                                    <input type="text" name="" id="telefEdit" value="" placeholder="999 999 999" class="form-control"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <button onclick='SaveChange()' class="btn btn-primary">Guardar Cambios</button>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        
                        <div id="mdlDelete" class="modal" style="display: none;">
                            <div class="modal-content" style="padding: 0px;">
                                <span class="close" data-dismiss="modal">×</span>                              
                                <div class="modal-header">
                                    <h1 style="font-size: 22px;">¿Desea eliminar el beneficiario?</h1>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-12"> 
                                            <div class="text-right">
                                                <input type="hidden" name="" id="idDispose" value="" />                                  
                                                <input type="button" name="" class="btn btn-default" value="Cancelar" />
                                                <input type="button" onclick="DisposeBenef()" name="name" value="Aceptar" class="btn btn-primary"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
    </form>
    <style>
        @media (max-width: 600px) {
            #cssbox {
                width: 125%;
            }

            #btnVal {
                margin: 14px;
                margin-left: 80px;
                width: 50%;
            }

            #txtContaExonerar {
                width: 122%;
            }

            ul {
                margin-left: 5px;
                padding-left: 6px;
            }

            .td {
                text-transform: uppercase;
                width: 10px;
                word-wrap: break-word;
                line-height: 13px;
            }

            .mov {
                padding-top: 11px;
                padding-left: 21px;
            }

            #iboxcon {
                width: 113%;
            }

            .myBtnc {
                font-size: 15px !important;
            }
        }

        .modal {
            display: none;
            position: fixed;
            z-index: 1;
            padding-top: 130px;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto;
            background-color: rgb(0,0,0);
            background-color: rgba(0,0,0,0.4);
        }

        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 70%;
            border-radius: 8px;
            font-family: sand-serif;
            box-shadow: 4px 4px 25px black;
        }

        .modal-header {
            text-align: center;
            justify-content: center;
            padding: 1rem;
            font-size: 32px;
            border-bottom: 1px solid #d9ecef;
            border-top-left-radius: .3rem;
            border-top-right-radius: .3rem;
            color: #337ab7;
        }

        .close {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }

        .btn {
            height: 40px;
            text-align: center;
            font-size: 16px;
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            margin: 0 auto;
            
            padding: 10px;
            font-weight: 600;
            border-radius: 6px;
            line-height: 1.3333333;
            /*background-color: #337ab7;
            border-color: #337ab7;
            color: white;*/
            cursor: pointer;
        }

            /*.btn:hover {
                background-color: rgb(40,96,144);
                color: white;
            }*/

        .ps {
            text-align: center;
            margin: 25px;
            font-size: 24px;
            color: #337ab7;
        }
        /*.btn-default, .btn-default:hover {
           color: #e7eaec;
        }*/
    </style>
    <script>


        var modal = document.getElementById('myModal');
        var btn = document.getElementById("myBtn");
        var span = document.getElementsByClassName("close")[0];
        btn.onclick = function () {
            modal.style.display = "block";
        }
        span.onclick = function () {
            modal.style.display = "none";
        }
            //window.onclick = function (event) {
            //    if (event.target == modal) {
            //        modal.style.display = "none";
            //    }
            //}
    </script>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="Script/ScriptTravelBenefits.js"></script>
    <script src="Script/ScriptHistoryTravelers.js"></script>

</body>
</html>
