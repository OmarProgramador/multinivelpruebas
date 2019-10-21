<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Promotores.aspx.cs" Inherits="MULTI_NIVEL.Views.Promotores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Promotores | inResorts</title>
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
                                            <a href="Red.aspx" >Arbol de Patrocinio</a>
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
                                        <li class="breadcrumb-item active">
                                            <a href="Promotores.aspx" class="subrayar">Promotores</a>
                                        </li>
                                        <li class="breadcrumb-item ">
                                            <a href="HistoryRange.aspx">Historial de rangos</a>
                                        </li>
                                    </ol>
                                </div>
                                <div class="col-md-6">
                                    <div class="linkstienda visible-md visible-lg">
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
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block height">Nuevo Socio</a>
                                                </div>
                                                <div class=" col-md-2 separadorbarra " style="z-index: 100;">
                                                    <a href="Tools.aspx">
                                                        <img src="img/universidad.png" class="img-responsive center-block height">Sistema Educativo</a>
                                                </div>
                                                <div class="col-md-2  separadorbarra " style="z-index: 100;">
                                                    <a href="Red.aspx">
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block height">Mi red</a>
                                                </div>
                                                <div class="  col-md-2 separadorbarra ">
                                                    <a href="Bonus.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block height">Comisiones y Pagos</a>
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
                                    <h2>Codigo Promocional</h2>
                                    <div style="margin-bottom: 40px;">
                                        <label>Nuevo Codigo</label>
                                        <input type="text" name="name" value="" class="form-control" style="max-width: 300px; display: inline !important;" id="Code-value" />
                                        <input type="button" name="name" value="Guardar" class="btn btn-primary" id="Code-Save" />
                                        <label style="margin-left:50px">Codigo Valido</label><label id="Code-label" class="form-control" style="max-width: 300px; display: inline !important;"></label>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <h2>Promotores Activos</h2>
                                        <div id="datapro">
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <h2>Promotores no activos</h2>
                                        <div id="datapro-des">
                                        </div>
                                    </div>
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
    <script type="text/javascript">


        const d = document


        window.onload = function () {

            $.get("PromotoresC.aspx", { action: "get" }, (_data) => {
                let _array = _data.split('$')
                d.getElementById('datapro').innerHTML = _array[0]
                d.getElementById('datapro-des').innerHTML = _array[1]
            })

            $.get("PromotoresC.aspx", { action: "getCode" }, (_data) => {
                d.getElementById('Code-label').innerHTML = _data
            })

        }

        d.addEventListener("click", e => {
            if (e.target.matches('#Code-Save')) {
                let _code = d.getElementById('Code-value').value

                $.post("PromotoresC.aspx", { action: "save", code: _code }, (_data) => {
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
