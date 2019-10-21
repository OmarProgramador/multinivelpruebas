<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tools.aspx.cs" Inherits="MULTI_NIVEL.Views.Tools" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Herramientas | inResorts</title>
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
    <script src="Script/Script.js"></script>

    <script>
        var base_url = ' ';
        var idsocio = 168;
        var idopera = 1;
        var nombresocio = '';
        var direcsocio = '2';
        var rango = '2';
        var simbolo = 'S/.';
        var csrfsn = '';
        //document.addEventListener('contextmenu', event => event.preventDefault());
    </script>
    <script src="tienda_files/jquery_010.js"></script>
    <script src="tienda_files/jquery_004.js"></script>
    <script type="text/javascript" charset="UTF-8" src="tienda_files/common.js"></script>
    <script type="text/javascript" charset="UTF-8" src="tienda_files/util.js"></script>
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
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Árbol de patrocinio</a>
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
                                <div class="col-md-6">
                                    <img src="img/universidad.png" class="logo-seccion" align="left">
                                    <h2 class="green"><b>Sistema Educativo</b></h2>
                                    <ol class="breadcrumb negro">
                                        <li class="breadcrumb-item active">
                                            <a href="Tools.aspx" class="subrayar">Herramientas</a>
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
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block height">Árbol de patrocinio</a>
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
                                    <div class="btn-group btn-group-justified m-b-md group-tienda" role="group" aria-label="...">
                                    </div>


                                    <div class="box_border m-b-md" id="prodnom" style="border: 1px solid #0000001c; background-color: #f3f4f9; padding: 15px;">
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 noproducto" data-id="80">
                                                <div style="height: 50px; width: 100%; background-color: #36a3f7; color: white; text-align: start; padding: 11px; box-shadow: 2px 0px 7px 2px rgba(69, 65, 78, 0.25);">
                                                    <h3><i class="far fa-file-image" style="margin-left: 15px; margin-right: 15px"></i>Imagenes</h3>
                                                </div>
                                                <div class="ibox-content text-center no-border" style="box-shadow: 2px 3px 7px 2px rgba(69, 65, 78, 0.25); min-height: 205px;">
                                                    <asp:Panel runat="server" ID="panel" Style="width: 100%"></asp:Panel>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 noproducto" data-id="80">

                                                <div style="height: 50px; width: 100%; background-color: #36a3f7; color: white; text-align: start; padding: 11px; box-shadow: 2px 0px 7px 2px rgba(69, 65, 78, 0.25);">
                                                    <h3><i class="far fa-file-video" style="margin-left: 15px; margin-right: 15px"></i>Videos</h3>
                                                </div>
                                                <div class="ibox-content text-center no-border" style="box-shadow: 2px 3px 7px 2px rgba(69, 65, 78, 0.25); min-height: 205px;">

                                                    <div class="m-b-sm text-center">
                                                        <div id="idvideos" style="">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <br />

                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 noproducto" data-id="80">
                                                <div style="height: 50px; width: 100%; background-color: #36a3f7; color: white; text-align: start; padding: 11px; box-shadow: 2px 0px 7px 2px rgba(69, 65, 78, 0.25);">
                                                    <h3><i class="far fa-file-video" style="margin-left: 15px; margin-right: 15px"></i>Presentaciones</h3>
                                                </div>
                                                <div class="ibox-content text-center no-border" style="box-shadow: 2px 3px 7px 2px rgba(69, 65, 78, 0.25); min-height: 205px;">
                                                    <div class="m-b-sm text-center">

                                                        <asp:Label runat="server" ID="panePdf"></asp:Label>

                                                    </div>
                                                </div>
                                            </div>
                                           <div class="col-md-6 col-sm-6 noproducto" data-id="80">
                                                <div style="height: 50px; width: 100%; background-color: #36a3f7; color: white; text-align: start; padding: 11px; box-shadow: 2px 0px 7px 2px rgba(69, 65, 78, 0.25);">
                                                    <h3><i class="far fa-file-alt" style="margin-left: 15px; margin-right: 15px"></i>Documentos</h3>
                                                </div>
                                                <div class="ibox-content text-center no-border" style="box-shadow: 2px 3px 7px 2px rgba(69, 65, 78, 0.25);min-height:  205px;">
                                                    <div class="m-b-sm text-center">
                                                        <asp:Label runat="server" ID="paneW"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />

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
    <script src="Script/ScriptTools.js"></script>

</body>
</html>
