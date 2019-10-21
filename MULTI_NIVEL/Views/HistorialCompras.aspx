<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialCompras.aspx.cs" Inherits="MULTI_NIVEL.Views.HistorialCompras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Historial de mis compras |InResorts</title>
    <link href="./HistorialCompras_files/css" rel="stylesheet">
    <link href="./HistorialCompras_files/bootstrap.min.css" rel="stylesheet">
    <link href="./HistorialCompras_files/font-awesome.css" rel="stylesheet">
    <link href="./HistorialCompras_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="./HistorialCompras_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="./HistorialCompras_files/chosen.css" rel="stylesheet">
    <link href="./HistorialCompras_files/croppie.min.css" rel="stylesheet">
    <link href="./HistorialCompras_files/datepicker3.css" rel="stylesheet">
    <link href="./HistorialCompras_files/jasny-bootstrap.min.css" rel="stylesheet">
    <link href="./HistorialCompras_files/ladda-themeless.min.css" rel="stylesheet">
    <link href="./HistorialCompras_files/sweetalert.css" rel="stylesheet">
    <link href="./HistorialCompras_files/animate.css" rel="stylesheet">
    <link href="./HistorialCompras_files/style.css" rel="stylesheet">
    <link rel="stylesheet" href="./HistorialCompras_files/all.css" integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="./HistorialCompras_files/slick.min.css">
    <link rel="stylesheet" type="text/css" href="./HistorialCompras_files/slick.min.css.map">
    <link rel="stylesheet" type="text/css" href="./HistorialCompras_files/slick-theme.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="path/to/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="path/to/font-awesome/css/font-awesome.min.css">

    <link href="Css/Style.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">

    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/css.css" rel="stylesheet" />

    <script src="./HistorialCompras_files/jquery-3.1.1.min.js.descarga"></script>
    <script src="./HistorialCompras_files/bootstrap.min.js.descarga"></script>
    <script src="./HistorialCompras_files/jquery.metisMenu.js.descarga"></script>
    <script src="./HistorialCompras_files/jquery.slimscroll.min.js.descarga"></script>
    <script src="./HistorialCompras_files/inspinia.js.descarga"></script>
    <script src="./HistorialCompras_files/pace.min.js.descarga"></script>
    <script src="./HistorialCompras_files/jquery.flot.js.descarga"></script>
    <script src="./HistorialCompras_files/jquery.flot.tooltip.min.js.descarga"></script>
    <script src="./HistorialCompras_files/jquery.flot.resize.js.descarga"></script>
    <script src="./HistorialCompras_files/Chart.min.js.descarga"></script>
    <script src="./HistorialCompras_files/jasny-bootstrap.min.js.descarga"></script>
    <script src="./HistorialCompras_files/jquery.peity.min.js.descarga"></script>
    <script src="./HistorialCompras_files/jquery.bootstrap-touchspin.min.js.descarga"></script>
    <script src="./HistorialCompras_files/peity-demo.js.descarga"></script>
    <script src="./HistorialCompras_files/datatables.min.js.descarga"></script>
    <script src="./HistorialCompras_files/chosen.jquery.js.descarga"></script>
    <script src="./HistorialCompras_files/croppie.min.js.descarga"></script>
    <script src="./HistorialCompras_files/sweetalert.min.js.descarga"></script>
    <script src="./HistorialCompras_files/bootstrap3-typeahead.min.js.descarga"></script>
    <script src="./HistorialCompras_files/jquery.validate.min.js.descarga"></script>
    <script src="./HistorialCompras_files/bootstrap-datepicker.js.descarga"></script>
    <script src="./HistorialCompras_files/jquery.mask.min.js.descarga"></script>
    <script src="./HistorialCompras_files/slick.min.js.descarga"></script>

    <script src="Script/Script.js"></script>

    <script>
        var base_url = '';
        var idsocio = 2495;
        var idopera = 1;
        var nombresocio = 'Omar Urteaga';
        var direcsocio = 'Avenida Guardia Civil 1321 Oficina 602';
        var rango = 'Inicio';
        var simbolo = 'S/.';
        var csrfsn = '9b48897a2543e182bc84178e12cbb9e4';
        //document.addEventListener('contextmenu', event => event.preventDefault());
    </script>
    <script src="./HistorialCompras_files/jquery.panzoom.js.descarga"></script>
    <script src="./HistorialCompras_files/jquery.mousewheel.js.descarga"></script>
    <style type="text/css">
        @font-face {
            font-weight: 400;
            font-style: normal;
            font-family: 'Inter-Loom';
            src: url('https://cdn.useloom.com/assets/fonts/inter/Inter-UI-Regular.woff2') format('woff2');
        }

        @font-face {
            font-weight: 400;
            font-style: italic;
            font-family: 'Inter-Loom';
            src: url('https://cdn.useloom.com/assets/fonts/inter/Inter-UI-Italic.woff2') format('woff2');
        }

        @font-face {
            font-weight: 500;
            font-style: normal;
            font-family: 'Inter-Loom';
            src: url('https://cdn.useloom.com/assets/fonts/inter/Inter-UI-Medium.woff2') format('woff2');
        }

        @font-face {
            font-weight: 500;
            font-style: italic;
            font-family: 'Inter-Loom';
            src: url('https://cdn.useloom.com/assets/fonts/inter/Inter-UI-MediumItalic.woff2') format('woff2');
        }

        @font-face {
            font-weight: 700;
            font-style: normal;
            font-family: 'Inter-Loom';
            src: url('https://cdn.useloom.com/assets/fonts/inter/Inter-UI-Bold.woff2') format('woff2');
        }

        @font-face {
            font-weight: 700;
            font-style: italic;
            font-family: 'Inter-Loom';
            src: url('https://cdn.useloom.com/assets/fonts/inter/Inter-UI-BoldItalic.woff2') format('woff2');
        }

        @font-face {
            font-weight: 900;
            font-style: normal;
            font-family: 'Inter-Loom';
            src: url('https://cdn.useloom.com/assets/fonts/inter/Inter-UI-Black.woff2') format('woff2');
        }

        @font-face {
            font-weight: 900;
            font-style: italic;
            font-family: 'Inter-Loom';
            src: url('https://cdn.useloom.com/assets/fonts/inter/Inter-UI-BlackItalic.woff2') format('woff2');
        }
    </style>
    <script type="text/javascript" src="chrome-extension://aggiiclaiamajehmlfpkjmlbadmkledi/popup.js" async=""></script>
    <script type="text/javascript" src="chrome-extension://aggiiclaiamajehmlfpkjmlbadmkledi/tat_popup.js" async=""></script>
    <style type="text/css">
        /*
 * contextMenu.js v 1.4.0
 * Author: Sudhanshu Yadav
 * s-yadav.github.com
 * Copyright (c) 2013 Sudhanshu Yadav.
 * Dual licensed under the MIT and GPL licenses
**/

        .iw-contextMenu {
            box-shadow: 0px 2px 3px rgba(0, 0, 0, 0.10);
            border: 1px solid #c8c7cc;
            border-radius: 11px;
            display: none;
            z-index: 1000000132;
            max-width: 300px;
        }

        .iw-cm-menu {
            background: #fff;
            color: #000;
            margin: 0px;
            padding: 0px;
        }

        .iw-curMenu {
        }

        .iw-cm-menu li {
            font-family: -apple-system, BlinkMacSystemFont, "Helvetica Neue", Helvetica, Arial, Ubuntu, sans-serif;
            list-style: none;
            padding: 10px;
            padding-right: 20px;
            border-bottom: 1px solid #c8c7cc;
            cursor: pointer;
            position: relative;
            font-size: 14px;
            margin: 0;
            line-height: inherit;
        }

            .iw-cm-menu li:first-child {
                border-top-left-radius: 11px;
                border-top-right-radius: 11px;
            }

            .iw-cm-menu li:last-child {
                border-bottom-left-radius: 11px;
                border-bottom-right-radius: 11px;
                border-bottom: none;
            }

        .iw-mOverlay {
            position: absolute;
            width: 100%;
            height: 100%;
            top: 0px;
            left: 0px;
            background: #FFF;
            opacity: .5;
        }

        .iw-contextMenu li.iw-mDisable {
            opacity: 0.3;
            cursor: default;
        }

        .iw-mSelected {
            background-color: #F6F6F6;
        }

        .iw-cm-arrow-right {
            width: 0;
            height: 0;
            border-top: 5px solid transparent;
            border-bottom: 5px solid transparent;
            border-left: 5px solid #000;
            position: absolute;
            right: 5px;
            top: 50%;
            margin-top: -5px;
        }

        .iw-mSelected > .iw-cm-arrow-right {
        }

        /*context menu css end */
    </style>
    <style type="text/css">
        @-webkit-keyframes load4 {
            0%, 100% {
                box-shadow: 0 -3em 0 0.2em, 2em -2em 0 0em, 3em 0 0 -1em, 2em 2em 0 -1em, 0 3em 0 -1em, -2em 2em 0 -1em, -3em 0 0 -1em, -2em -2em 0 0;
            }

            12.5% {
                box-shadow: 0 -3em 0 0, 2em -2em 0 0.2em, 3em 0 0 0, 2em 2em 0 -1em, 0 3em 0 -1em, -2em 2em 0 -1em, -3em 0 0 -1em, -2em -2em 0 -1em;
            }

            25% {
                box-shadow: 0 -3em 0 -0.5em, 2em -2em 0 0, 3em 0 0 0.2em, 2em 2em 0 0, 0 3em 0 -1em, -2em 2em 0 -1em, -3em 0 0 -1em, -2em -2em 0 -1em;
            }

            37.5% {
                box-shadow: 0 -3em 0 -1em, 2em -2em 0 -1em, 3em 0em 0 0, 2em 2em 0 0.2em, 0 3em 0 0em, -2em 2em 0 -1em, -3em 0em 0 -1em, -2em -2em 0 -1em;
            }

            50% {
                box-shadow: 0 -3em 0 -1em, 2em -2em 0 -1em, 3em 0 0 -1em, 2em 2em 0 0em, 0 3em 0 0.2em, -2em 2em 0 0, -3em 0em 0 -1em, -2em -2em 0 -1em;
            }

            62.5% {
                box-shadow: 0 -3em 0 -1em, 2em -2em 0 -1em, 3em 0 0 -1em, 2em 2em 0 -1em, 0 3em 0 0, -2em 2em 0 0.2em, -3em 0 0 0, -2em -2em 0 -1em;
            }

            75% {
                box-shadow: 0em -3em 0 -1em, 2em -2em 0 -1em, 3em 0em 0 -1em, 2em 2em 0 -1em, 0 3em 0 -1em, -2em 2em 0 0, -3em 0em 0 0.2em, -2em -2em 0 0;
            }

            87.5% {
                box-shadow: 0em -3em 0 0, 2em -2em 0 -1em, 3em 0 0 -1em, 2em 2em 0 -1em, 0 3em 0 -1em, -2em 2em 0 0, -3em 0em 0 0, -2em -2em 0 0.2em;
            }
        }

        @keyframes load4 {
            0%, 100% {
                box-shadow: 0 -3em 0 0.2em, 2em -2em 0 0em, 3em 0 0 -1em, 2em 2em 0 -1em, 0 3em 0 -1em, -2em 2em 0 -1em, -3em 0 0 -1em, -2em -2em 0 0;
            }

            12.5% {
                box-shadow: 0 -3em 0 0, 2em -2em 0 0.2em, 3em 0 0 0, 2em 2em 0 -1em, 0 3em 0 -1em, -2em 2em 0 -1em, -3em 0 0 -1em, -2em -2em 0 -1em;
            }

            25% {
                box-shadow: 0 -3em 0 -0.5em, 2em -2em 0 0, 3em 0 0 0.2em, 2em 2em 0 0, 0 3em 0 -1em, -2em 2em 0 -1em, -3em 0 0 -1em, -2em -2em 0 -1em;
            }

            37.5% {
                box-shadow: 0 -3em 0 -1em, 2em -2em 0 -1em, 3em 0em 0 0, 2em 2em 0 0.2em, 0 3em 0 0em, -2em 2em 0 -1em, -3em 0em 0 -1em, -2em -2em 0 -1em;
            }

            50% {
                box-shadow: 0 -3em 0 -1em, 2em -2em 0 -1em, 3em 0 0 -1em, 2em 2em 0 0em, 0 3em 0 0.2em, -2em 2em 0 0, -3em 0em 0 -1em, -2em -2em 0 -1em;
            }

            62.5% {
                box-shadow: 0 -3em 0 -1em, 2em -2em 0 -1em, 3em 0 0 -1em, 2em 2em 0 -1em, 0 3em 0 0, -2em 2em 0 0.2em, -3em 0 0 0, -2em -2em 0 -1em;
            }

            75% {
                box-shadow: 0em -3em 0 -1em, 2em -2em 0 -1em, 3em 0em 0 -1em, 2em 2em 0 -1em, 0 3em 0 -1em, -2em 2em 0 0, -3em 0em 0 0.2em, -2em -2em 0 0;
            }

            87.5% {
                box-shadow: 0em -3em 0 0, 2em -2em 0 -1em, 3em 0 0 -1em, 2em 2em 0 -1em, 0 3em 0 -1em, -2em 2em 0 0, -3em 0em 0 0, -2em -2em 0 0.2em;
            }
        }
    </style>
    <style type="text/css">
        /* This is not a zero-length file! */
    </style>
</head>
<body class="top-navigation pace-done">
    <div class="pace  pace-inactive">
        <div class="pace-progress" data-progress-text="100%" data-progress="99" style="transform: translate3d(100%, 0px, 0px);">
            <div class="pace-progress-inner"></div>
        </div>
        <div class="pace-activity"></div>
    </div>
    <!-- Loading -->
    <div class="loading">
        <div class="load">
            <div class="sk-spinner sk-spinner-fading-circle">
                <div class="sk-circle1 sk-circle"></div>
                <div class="sk-circle2 sk-circle"></div>
                <div class="sk-circle3 sk-circle"></div>
                <div class="sk-circle4 sk-circle"></div>
                <div class="sk-circle5 sk-circle"></div>
                <div class="sk-circle6 sk-circle"></div>
                <div class="sk-circle7 sk-circle"></div>
                <div class="sk-circle8 sk-circle"></div>
                <div class="sk-circle9 sk-circle"></div>
                <div class="sk-circle10 sk-circle"></div>
                <div class="sk-circle11 sk-circle"></div>
                <div class="sk-circle12 sk-circle"></div>
            </div>
            <div>Espere por favor...</div>
        </div>
    </div>

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
						                    <a href="SignOutC.aspx" class="btn btn-primary block" >Salir</a>
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
                            <img src="../Resources/Images/shop3.svg" width="80" style="margin: 5px" class="logo-seccion" align="left">
                            <h2 class="green"><b>Tienda</b></h2>
                            <ol class="breadcrumb green">
                                <li class="breadcrumb-item"><a href="AddMembership.aspx">Paquetes</a></li>
                                        <li class="breadcrumb-item "><a href="Store.aspx">Servicios</a></li>
                                        <%--<li class="breadcrumb-item "><a href="TravelBenefits.aspx">Beneficios de Viajes</a></li>--%>
                                        <li class="breadcrumb-item "><a href="Eagency.aspx">E-agencias</a></li>
                                        <li class="breadcrumb-item active"><a href="HistorialCompras.aspx">Mis Compras</a></li>
                                        <li class="breadcrumb-item "><a href="traveling.aspx">Viajes</a></li>
                            </ol>
                            <hr>
                            <div class="tabs-container">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a data-toggle="tab" href="" aria-expanded="true">Compras pagadas</a></li>
                                    <%-- <li class=""><a data-toggle="tab" href="" aria-expanded="false">Compras pendientes</a></li>--%>
                                </ul>
                                <div class="tab-content">
                                    <div id="tab-1" class="tab-pane active">
                                        <div class="panel-body">
                                            <%--  <form action="https://www.mioficinaknn.com/tienda/historialfiltro" id="formBuscarTransaccion" class="form-inline" method="post" accept-charset="utf-8">
                                            <input type="hidden" name="csrfsn" value="9b48897a2543e182bc84178e12cbb9e4">

                                            <div class="form-group">
                                                <label for="mescierre">Periodo de Empresa</label>
                                                <select class="form-control input-sm" name="periodoempresa" id="periodoempresa">
                                                    <option value="">Seleccione...</option>
                                                    <option value="26">16/12/2018 - 31/12/2018     </option>
                                                    <option value="25">01/12/2018 - 15/12/2018     </option>
                                                    <option value="24">16/11/2018 - 30/11/2018     </option>
                                                    <option value="23">01/11/2018 - 15/11/2018     </option>
                                                   
                                                </select>
                                            </div>


                                            <input type="hidden" name="csrfsn" value="9b48897a2543e182bc84178e12cbb9e4">
                                            <div class="form-group">
                                                <label for="mescierre">Periodo del Socio</label>
                                                <select class="form-control input-sm" name="periodosocio" id="periodosocio">
                                                    <option value="">Seleccione...</option>
                                                    <option value="9997">17/09/2018 - 17/10/2018  </option>
                                                </select>
                                            </div>
                                            <button type="submit" class="btn btn-sm btn-default verde">Consultar</button>
                                            <a href="https://www.mioficinaknn.com/tienda/historial" class="btn btn-sm btn-default verde">Restablecer</a>
                                        </form>--%>
                                            <div class="table-responsive m-t">
                                                <div id="DataTables_Table_0_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">

                                                    <%--  <div class="dataTables_length" id="DataTables_Table_0_length">
                                                    <label>Mostrar
                                                        <select name="DataTables_Table_0_length" aria-controls="DataTables_Table_0" class="form-control input-sm">
                                                            <option value="10">10</option>
                                                            <option value="25">25</option>
                                                            <option value="50">50</option>
                                                            <option value="100">100</option>
                                                        </select>
                                                        filas</label>

                                                </div>
                                                <div id="DataTables_Table_0_filter" class="dataTables_filter">
                                                   </div>--%>


                                                    <%--  <table class="table table-bordered dataTables-example dataTable no-footer" id="DataTables_Table_0" aria-describedby="DataTables_Table_0_info" role="grid">
                                                    <thead>
                                                        <tr role="row">
                                                            <th class="sorting_asc" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Fecha de pago: Activar para ordenar la columna descendente" style="width: 213px;">Fecha de pago</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" aria-label="Ciclo: Activar para ordenar la columna ascendente" style="width: 311px;">Ciclo</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" aria-label="Nro. Ticket: Activar para ordenar la columna ascendente" style="width: 173px;">Nro. Ticket</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" aria-label="Tipo: Activar para ordenar la columna ascendente" style="width: 235px;">Tipo</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" aria-label="Monto: Activar para ordenar la columna ascendente" style="width: 135px;">Monto</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" aria-label="Puntos: Activar para ordenar la columna ascendente" style="width: 116px;">Puntos</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" aria-label="Estado: Activar para ordenar la columna ascendente" style="width: 110px;">Estado</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" aria-label="Opciones: Activar para ordenar la columna ascendente" style="width: 273px;">Opciones</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>

                                                        <tr role="row" class="odd">
                                                            <td class="sorting_1">17/09/2018</td>
                                                            <td>17/09/2018 - 17/10/2018</td>
                                                            <td>1537189867</td>
                                                            <td>Paquetes K - KTOX</td>
                                                            <td>S/. 215.00</td>
                                                            <td>140</td>
                                                            <td>Pagado</td>
                                                            <td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1537189867/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1537189867/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>--%>
                                                    <div id="dataList">
                                                    </div>

                                                    <div class="dataTables_paginate paging_simple_numbers" id="DataTables_Table_0_paginate">
                                                        <ul class="pagination">
                                                            <li class="paginate_button previous disabled"
                                                                id="DataTables_Table_0_previous">
                                                                <a href=""
                                                                    aria-controls="DataTables_Table_0" data-dt-idx="0" tabindex="0">Anterior</a></li>
                                                            <li class="paginate_button active">
                                                                <a href=""
                                                                    aria-controls="DataTables_Table_0" data-dt-idx="1" tabindex="0">1</a></li>
                                                            <li class="paginate_button next disabled" id="DataTables_Table_0_next">
                                                                <a href=""
                                                                    aria-controls="DataTables_Table_0" data-dt-idx="2" tabindex="0">Siguiente</a></li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tab-2" class="tab-pane">
                                        <div class="panel-body">
                                            <div class="table-responsive m-t">
                                                <div id="DataTables_Table_1_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
                                                    <div class="html5buttons">
                                                        <div class="dt-buttons btn-group"><a class="btn btn-default buttons-excel buttons-html5" tabindex="0" aria-controls="DataTables_Table_1" href="https://www.mioficinaknn.com/tienda/historial/#"><span>Excel</span></a><a class="btn btn-default buttons-pdf buttons-html5" tabindex="0" aria-controls="DataTables_Table_1" href="https://www.mioficinaknn.com/tienda/historial/#"><span>PDF</span></a><a class="btn btn-default buttons-print" tabindex="0" aria-controls="DataTables_Table_1" href="https://www.mioficinaknn.com/tienda/historial/#"><span>Print</span></a></div>
                                                    </div>
                                                    <div class="dataTables_length" id="DataTables_Table_1_length">
                                                        <label>
                                                            Mostrar
                                                        <select name="DataTables_Table_1_length" aria-controls="DataTables_Table_1" class="form-control input-sm">
                                                            <option value="10">10</option>
                                                            <option value="25">25</option>
                                                            <option value="50">50</option>
                                                            <option value="100">100</option>
                                                        </select>
                                                            filas</label>
                                                    </div>
                                                    <div id="DataTables_Table_1_filter" class="dataTables_filter">
                                                        <label>Buscar:<input type="search" class="form-control input-sm" placeholder="" aria-controls="DataTables_Table_1"></label>
                                                    </div>
                                                    <div class="dataTables_info" id="DataTables_Table_1_info" role="status" aria-live="polite">Mostrando 0 de 0 de 0 filas</div>
                                                    <table class="table table-bordered dataTables-example1 dataTable no-footer" id="DataTables_Table_1" aria-describedby="DataTables_Table_1_info" role="grid">
                                                        <thead>
                                                            <tr role="row">
                                                                <th class="sorting_asc" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Fecha de Registro: Activar para ordenar la columna descendente" style="width: 0px;">Fecha de Registro</th>
                                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Fecha de Vigencia: Activar para ordenar la columna ascendente" style="width: 0px;">Fecha de Vigencia</th>
                                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Nro. Ticket: Activar para ordenar la columna ascendente" style="width: 0px;">Nro. Ticket</th>
                                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Tipo: Activar para ordenar la columna ascendente" style="width: 0px;">Tipo</th>
                                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Monto: Activar para ordenar la columna ascendente" style="width: 0px;">Monto</th>
                                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Puntos: Activar para ordenar la columna ascendente" style="width: 0px;">Puntos</th>
                                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Estado: Activar para ordenar la columna ascendente" style="width: 0px;">Estado</th>
                                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Opciones: Activar para ordenar la columna ascendente" style="width: 0px;">Opciones</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr class="odd">
                                                                <td valign="top" colspan="8" class="dataTables_empty">No hay registros en la base de datos</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <div class="dataTables_paginate paging_simple_numbers" id="DataTables_Table_1_paginate">
                                                        <ul class="pagination">
                                                            <li class="paginate_button previous disabled" id="DataTables_Table_1_previous">
                                                                <a href="" aria-controls="DataTables_Table_1" data-dt-idx="0" tabindex="0">Anterior</a></li>
                                                            <li class="paginate_button next disabled" id="DataTables_Table_1_next">
                                                                <a href="" aria-controls="DataTables_Table_1"
                                                                    data-dt-idx="1" tabindex="0">Siguiente</a></li>
                                                        </ul>
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

                <script type="text/javascript">
                    $(document).ready(function () {
                        $('.btnConsultaStatus').click(function () {
                            $('.loading').show();
                            operacion = $(this).data('operacion');
                            params = { csrfsn: csrfsn, operacion: operacion }
                            $.post(base_url + 'ajax/getstatusorden', params, function (data) {
                                swal("Estado de la compra", data.status, "info");
                                console.log();
                                //alert(data.status);
                                $('.loading').hide();
                            })
                        });

                        $('.dataTables-example').DataTable({
                            pageLength: 25,
                            responsive: true,
                            dom: '<"html5buttons"B>lTfgitp',
                            buttons: [
                                { extend: 'excel', title: 'HistorialDeMisCompras' },
                                { extend: 'pdf', title: 'HistorialDeMisCompras' },
                                {
                                    extend: 'print',
                                    customize: function (win) {
                                        $(win.document.body).addClass('white-bg');
                                        $(win.document.body).css('font-size', '10px');
                                        $(win.document.body).find('table').addClass('compact').css('font-size', 'inherit');
                                    }
                                }
                            ]

                        });
                        $('.dataTables-example1').DataTable({
                            pageLength: 25,
                            responsive: true,
                            dom: '<"html5buttons"B>lTfgitp',
                            buttons: [
                                { extend: 'excel', title: 'HistorialDeMisCompras' },
                                { extend: 'pdf', title: 'HistorialDeMisCompras' },
                                {
                                    extend: 'print',
                                    customize: function (win) {
                                        $(win.document.body).addClass('white-bg');
                                        $(win.document.body).css('font-size', '10px');
                                        $(win.document.body).find('table').addClass('compact').css('font-size', 'inherit');
                                    }
                                }
                            ]

                        });
                    });

                    function validarAnulacion(idsocio, nroorden, eleccion) {
                        swal(
                            {
                                title: "¿Está seguro de anular la compra?",
                                text: "El pedido será " + eleccion,
                                type: "warning",
                                showCancelButton: true,
                                showLoaderOnConfirm: true,
                                confirmButtonColor: "#61862f",
                                confirmButtonText: "SI",
                                cancelButtonText: "NO",
                                closeOnConfirm: true,
                                closeOnCancel: false
                            },
                            function (isConfirm) {
                                if (isConfirm) {
                                    $.get(base_url + "anular/" + idsocio + "/" + nroorden, function (data) {
                                        alert(data.msg);
                                        location.reload();
                                    })
                                } else {
                                    swal("Cancelado", "Se canceló la operación", "error");
                                }
                            }
                        );
                    }
                </script>
              
                <div class="footer footer-fondo">
                    <strong>InResorts - 2018</strong>
                </div>
            </div>
        </div>



        <script type="text/javascript">
            function alerta(aqui) {
                alert(aqui);
            };

            $(window).bind('scroll', function () {
                if ($(window).scrollTop() > 180) { $('#scrollUp').fadeIn('slow'); } else { $('#scrollUp').fadeOut('slow'); }
            });

            $("a[href='#top']").click(function () {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                return false;
            });
        </script>


        <input type="hidden" id="hippowiz-ass-injected" value="true">
        <input type="hidden" id="hvmessage-toextension-listener" value="none">
    </form>

    <script src="Script/ScriptHistorySales.js"></script>

</body>


</html>
