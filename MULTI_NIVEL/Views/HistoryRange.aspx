<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryRange.aspx.cs" Inherits="MULTI_NIVEL.Views.HistoryRange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Historial  de Rangos | inResorts</title>
    <link href="tienda_files/css.css" rel="stylesheet">
    <link href="tienda_files/bootstrap.css" rel="stylesheet">
    <link href="tienda_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <link href="tienda_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="tienda_files/chosen.css" rel="stylesheet">
    <link href="tienda_files/croppie.css" rel="stylesheet">
    <link href="tienda_files/datepicker3.css" rel="stylesheet">
    <link href="tienda_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="tienda_files/ladda-themeless.css" rel="stylesheet">
    <link href="tienda_files/sweetalert.css" rel="stylesheet">
    <link href="tienda_files/animate.css" rel="stylesheet">
    <link href="tienda_files/style.css" rel="stylesheet">
    <link rel="stylesheet" href="tienda_files/all.css" integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp" crossorigin="anonymous">
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

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


    <script src="tienda_files/jquery_010.js"></script>
    <script src="tienda_files/jquery_004.js"></script>
    <script type="text/javascript" charset="UTF-8" src="tienda_files/common.js"></script>
    <script type="text/javascript" charset="UTF-8" src="tienda_files/util.js"></script>
    <script src="Script/Script.js"></script>
</head>
<body class="top-navigation  pace-done">
    <div class="pace  pace-inactive">

        <div class="pace-progress" style="transform: translate3d(100%, 0px, 0px);" data-progress-text="100%" data-progress="99">
            <div class="pace-progress-inner"></div>
        </div>

        <div class="pace-activity"></div>
    </div>
    <!-- Loading -->
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
                                                   
                                                    <a class="btn btn-primary block" href="SignOutC.aspx">Salir</a>
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
                                                    <a href="Tools.aspx">
                                                        <img src="img/universidad.png" class="img-responsive center-block height">Sistema Educativo</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Red.aspx">
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Mi red</a>
                                                </div>
                                                <div class=" col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Bonus.aspx">
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
                                <div class="col-md-12 col-lg-12">
                                    <img src="red_files/redes.png" class="logo-seccion" align="left">
                                    <h2 class="green"><b>Mi Red</b></h2>
                                    <ol class="breadcrumb negro">
                                        <li class="breadcrumb-item ">
                                            <a href="Red.aspx">Arbol de Patrocinio</a>
                                        </li>
                                        <li class="breadcrumb-item">
                                            <a href="ResidualTree.aspx">Arbol residual</a>
                                        </li>
                                        <li class="breadcrumb-item">
                                            <a href="Sponsored.aspx">Lista de Patrocinados</a>
                                        </li>

                                        <li class="breadcrumb-item">
                                            <a href="Placement.aspx">Placement</a>
                                        </li>
                                        <li class="breadcrumb-item">
                                            <a href="Promotores.aspx">Promotores</a>
                                        </li>
                                        <li class="breadcrumb-item active">
                                            <a href="HistoryRange.aspx" class="subrayar">Historial de rangos</a>
                                        </li>
                                    </ol>
                                </div>
                                <div class="col-md-6" >
                                    <div class="linkstienda visible-md visible-lg" style="background-color:white;">
                                        <div class="col-md-3" style="width: 20% !important">
                                            <!-- <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1)">
                                                            <img class="center-block oficinaimg" src=""  border="0" />
                                                        </a> -->
                                            <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1)">
                                                <img class="center-block oficinaimg" src="img/oficinavirtualsol.png" border="0">
                                            </a>
                                        </div>
                                        <div class="col-md-9 menu-lateral-opciones">
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
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block height" />Mi red</a>
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
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block height" border="0" />Tienda</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <ul class="list-group categoria-tienda">
                                    </ul>
                                </div>
                                <div class="col-md-12">
                                    <h2 class="text-center">Historial de Rangos Adquiridos </h2>

                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <asp:TextBox ID="LblUserNamev" runat="server" Style="display: none" />
                                            <div id="datapro">
                                            </div>
                                            <br />
                                        </div>
                                    </div>
                                    <%--<div class="col-md-12">
                                    <div class="table-responsive">
                                        <h2>Promotores no activos</h2>
                                        <div id="datapro-des">
                                        </div>
                                    </div>
                                </div>--%>
                                </div>
                                <div class="col-md-12">
                                    <h2 class="text-center">Historial de Rangos Residuales</h2>
                                    <div class="table-responsive">
                                        <div id="datarangeresid">

                                        </div>
                                        <br />
                                    </div>
                                </div>

                                <div id="modal1" class="modal" style="display: none; padding-right: 17px;">
                                    <div class="modal-content">
                                        <span class="close" data-dismiss="modal">×</span>

                                        <div class="modal-header">
                                            <img src="img/novologo.png" alt="Alternate Text" width="100">
                                        </div>

                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group" style="text-align: center; font-size: 30px;">
                                                        <label>¿Esta seguro de posicionar a <span id="children_mdl" class="resaltar">Pepito</span> debajo de <span id="father_mdl" class="resaltar">Jaimito</span> ?</label>

                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <center>                                       
                                       <input type="button" name="name" value="Si" style="box-shadow: 1px 2px 0px black;background: white; color: #000000; border: 1px solid #000000;width:90px" onclick="AsignarUpliner()"/>
                                        <button type="button" class="btn" style="box-shadow: 1px 2px 0px black;background: white; color: #000000; border: 1px solid #000000;width:90px" data-dismiss="modal" > No</button> 
                                    </center>

                                        <%--<center>                                       
                                       
                        <input id="btnPutTrave" type="button" name="name" value="Aceptar" class="btn btn-primary" onclick="btnPutTravel();"/>
                        <button type="button" class="btn" data-dismiss="modal"> Cancelar</button> 
                    </center>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <script type="text/javascript">
                $(window).bind('scroll', function () {
                    if ($(window).scrollTop() > 180) { $('#scrollUp').fadeIn('slow'); } else { $('#scrollUp').fadeOut('slow'); }
                });

                $("a[href='#top']").click(function () {
                    $("html, body").animate({ scrollTop: 0 }, "slow");
                    return false;
                });
            </script>
            <%-- modal Alex--%>

            <div class="modal" id="fm-modal-grid" tabindex="-1" role="dialog" aria-labelledby="fm-modal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-titleRango text-center">¡Felicidades! Tu rango es:</h5>
                            <button class="close" data-dismiss="modal" aria-label="Cerrar">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="">
                                <div class="row">
                                    <div class="col-12 fotitoRango img-fluid img-responsive center-block">
                                        <img id="modalcara" class="img-fluid img-responsive " src="#" alt="" />

                                    </div>
                                   
                                    <br />
                                    <div class=" col-12 col-md-12 col-lg-12" style="display: none;">

                                        <asp:Label Text="Compartir en: " runat="server" />
                                        <a class="btn btn-danger">Instagram <i class="fab fa-instagram"></i></a>
                                        <a href="#" class="btn btn-azul" data-dismiss="modal">Facebook <i class="fab fa-facebook"></i></a>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer col-12 col-md-12">
                            <a id="btnDownload" class="btn btn-success" href="#" download="MiRangoInresorts.png">Descargar <i class="fas fa-cloud-download-alt"></i></a>
                            <button class="btn btn-default cierraBoton" data-dismiss="modal">Cerrar</button>

                        </div>
                    </div>
                </div>
            </div>
    </form>
    <style>
        .resaltar {
            font-weight: bold;
            color: lightseagreen;
            font-size: 13px;
        }

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
        }
    </style>
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
            background: rgba(0,0,0,0.4;
        }

        .modal-content {
            width: 70%;
            border-radius: 8px;
            border: 1px 4px 25px black;
        }

        .modal-header {
            text-align: center;
            -webkit-justify-content: center;
            padding: 1rem;
            font-size: 32px;
            font-size: 24px;
            color: #337ab7;
        }
    </style>
    <%--estilo icono del modal historia de rangos--%>
    <style>
        .btn-primaryVerde {
            background: #28A745 !important;
            color: white;
            font-size: 24px;
        }

        .modal-titleRango {
            margin: 4;
            font-size: 22px;
        }

        .btn-azul {
            background: #3b5998;
            color: white;
        }

        .cierraBoton {
            background: #333333;
        }
    </style>
    <script type="text/javascript">

        const d = document


        function ShowModal(_range) {


            let user_ = document.getElementById('LblUserNamev').value;

            if (_range == "SOC") {
                d.getElementById('modalcara').src = '/resources/imgHistoryRange/' + user_ + 'soc.png'
                d.getElementById('btnDownload').href = '/resources/imgHistoryRange/' + user_ + 'soc.png'
                d.getElementById('btnDownload').download = user_ + 'Rango_SOCIO.png'
            }
            if (_range == "PLT") {
                d.getElementById('modalcara').src = '/resources/imgHistoryRange/' + user_ + 'plt.png'
                d.getElementById('btnDownload').href = '/resources/imgHistoryRange/' + user_ + 'plt.png'
                d.getElementById('btnDownload').download = user_ + 'Rango_PLATA.png'
            }
            if (_range == "ZAF") {
                d.getElementById('modalcara').src = '/resources/imgHistoryRange/' + user_ + 'zaf.png'
                d.getElementById('btnDownload').href = '/resources/imgHistoryRange/' + user_ + 'zaf.png'
                d.getElementById('btnDownload').download = user_ + 'Rango_ZAFIRO.png'
            }
            if (_range == "RUB") {
                d.getElementById('modalcara').src = '/resources/imgHistoryRange/' + user_ + 'rub.png'
                d.getElementById('btnDownload').href = '/resources/imgHistoryRange/' + user_ + 'rub.png'
                d.getElementById('btnDownload').download = user_ + 'Rango_RUBI.png'
            }
            if (_range == "ESM") {
                d.getElementById('modalcara').src = '/resources/imgHistoryRange/' + user_ + 'esm.png'
                d.getElementById('btnDownload').href = '/resources/imgHistoryRange/' + user_ + 'esm.png'
                d.getElementById('btnDownload').download = user_ + 'Rango_ESMERALDA.png'
            }
            if (_range == "DIA") {
                d.getElementById('modalcara').src = '/resources/imgHistoryRange/' + user_ + 'dia.png'
                d.getElementById('btnDownload').href = '/resources/imgHistoryRange/' + user_ + 'dia.png'
                d.getElementById('btnDownload').download = user_ + 'Rango_DIAMANTE.png'
            }
            if (_range == "DNE") {
                d.getElementById('modalcara').src = '/resources/imgHistoryRange/' + user_ + 'dne.png'
                d.getElementById('btnDownload').href = '/resources/imgHistoryRange/' + user_ + 'dne.png'
                d.getElementById('btnDownload').download = user_ + 'Rango_DIAMANTE_NEGRO.png'
            }
            if (_range == "DAZ") {
                d.getElementById('modalcara').src = '/resources/imgHistoryRange/' + user_ + 'daz.png'
                d.getElementById('btnDownload').href = '/resources/imgHistoryRange/' + user_ + 'daz.png'
                d.getElementById('btnDownload').download = user_ + 'Rango_DIAMANTE_AZUL.png'
            }


            $("#fm-modal-grid").modal("show");
        }


        window.onload = function () {

            $.get("HistoryRangeC.aspx", { action: "get" }, (_data) => {

                d.getElementById('datapro').innerHTML = _data
                //d.getElementById('datahistory-des').innerHTML = _data

                $.get("HistoryRangeC.aspx", { action: "getresidual" }, (_data) => {

                    d.getElementById('datarangeresid').innerHTML = _data


                });
            })



        }

        d.addEventListener("click", e => {
            if (e.target.matches('#Code-Save')) {
                let _code = d.getElementById('Code-value').value

                $.post("HistoryRangeC.aspx", { action: "save", code: _code }, (_data) => {
                    if (_data === "La operacion se realizo con exito") {
                        d.getElementById('Code-label').innerHTML = _code
                        d.getElementById('Code-value').value = ""
                    }
                    alert(_data)
                })

            }
        })

    </script>
</body>
</html>
