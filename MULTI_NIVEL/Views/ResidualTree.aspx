<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResidualTree.aspx.cs" Inherits="MULTI_NIVEL.Views.ResidualTree" %>


<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Arbol Residual | inResorts</title>
    <link href="red_files/css.css" rel="stylesheet">
    <link href="red_files/bootstrap.css" rel="stylesheet">
    <link href="red_files/font-awesome.css" rel="stylesheet">
    <link href="red_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="red_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />

    <link href="red_files/chosen.css" rel="stylesheet">
    <link href="red_files/croppie.css" rel="stylesheet">
    <link href="red_files/datepicker3.css" rel="stylesheet">
    <link href="red_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="red_files/ladda-themeless.css" rel="stylesheet">
    <link href="red_files/sweetalert.css" rel="stylesheet">
    <link href="red_files/animate.css" rel="stylesheet">
    <link href="red_files/style.css" rel="stylesheet">
    <link rel="stylesheet" href="red_files/all.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">
    <style>
        .bg-affiliate {
            background-color: #c7c7c757 !important;
        }
/*
        .bg-red span {
            color: red;
            font-size: 35px !important;
            vertical-align: sub;
        }

        .bg-ambar span {
            content:"";
            color: yellow;
            font-size: 35px !important;
            vertical-align: sub;
        }

        .bg-green span {
            color: green;
            font-size: 35px !important;
            vertical-align: sub;
        }*/
        .bg-red div {
            background-color: red !important;
            position: absolute;
            width: 5px;
            height: 100%;
            top: 0;
            right: 0;
            margin-left: auto;
        }

        .bg-ambar div {
            background-color: yellow !important;
            position: absolute;
            width: 5px;
            height: 100%;
            top: 0;
            right: 0;
            margin-left: auto;
        }

        .bg-green div {
            background-color: green !important;
            position: absolute;
            width: 5px;
           height: 100%;
            top: 0;
            right: 0;
            margin-left: auto;
        }

        /*    position: absolute;
    bottom: 0;
    right: 0;
    margin-left: auto;
    width: 0;
    height: 0;
    border-right: 10px solid yellow;
    border-top: 10px solid transparent;
    border-left: 10px solid transparent;
    border-bottom: 10px solid yellow;*/
    </style>
    <script>
        window.onload = function () {
            // document.getElementById("divProgressBar").style.display = "inline";
        }
    </script>

    <script src="red_files/jquery-3.js"></script>
    <script src="red_files/bootstrap.js"></script>


    <script src="Script/Script.js"></script>

    <script src="red_files/jquery_003.js"></script>
    <script src="red_files/jquery_008.js"></script>
    <script src="red_files/inspinia.js"></script>
    <script src="red_files/pace.js"></script>
    <script src="red_files/jquery.js"></script>
    <script src="red_files/jquery_010.js"></script>
    <script src="red_files/jquery_009.js"></script>
    <script src="red_files/Chart.js"></script>
    <script src="red_files/jasny-bootstrap.js"></script>
    <script src="red_files/jquery_002.js"></script>
    <script src="red_files/jquery_004.js"></script>
    <script src="red_files/peity-demo.js"></script>
    <script src="red_files/datatables.js"></script>
    <script src="red_files/chosen.js"></script>
    <script src="red_files/croppie.js"></script>
    <script src="red_files/sweetalert.js"></script>
    <script src="red_files/bootstrap3-typeahead.js"></script>
    <script src="red_files/jquery_006.js"></script>
    <script src="red_files/bootstrap-datepicker.js"></script>
    <script src="red_files/jquery_011.js"></script>

    <script src="red_files/jquery_007.js"></script>
    <script src="red_files/jquery_005.js"></script>

</head>
<body class="top-navigation pace-done" style="background-color: #FFFFFF">
    <%--<div id="divProgressBar">
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

    <form id="form1" runat="server" style="width: 100%">
        <div class="pace pace-inactive">
            <div class="pace-progress" style="transform: translate3d(100%, 0px, 0px);" data-progress-text="100%" data-progress="99">
                <div class="pace-progress-inner">
                </div>
            </div>
            <div class="pace-activity">
            </div>
        </div>
        <!-- Loading -->


        <div id="wrapper">
            <div id="page-wrapper" class="gray-bg">
                <div class="row border-bottom white-bg iniciowp">
                    <nav class="navbar navbar-static-top" role="navigation" style="height: 75px">
                        <div class="navbar-header header-inicio">
                            <button aria-controls="navbar" aria-expanded="false" data-target="#navbar" data-toggle="collapse" class="navbar-toggle collapsed" type="button">
                                <i class="fa fa-reorder"></i>
                            </button>
                            <a href="Index.aspx" class="navbar-brand inicio-logo">
                                <img src="img/novologo.png" class="img-responsive">
                            </a>
                        </div>
                        <div class="navbar-collapse collapse" id="navbar">
                            <ul class="nav navbar-top-links navbar-right header-inicior">
                                <li>
                                    <asp:Image ID="imgProfile" runat="server" alt="..." CssClass="img-circle img-responsive img-user" />
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle userClass" data-toggle="dropdown" role="button" aria-expanded="false">
                                        <asp:Label ID="lblUser" runat="server"></asp:Label><span class="caret"></span></a>
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
                                                <a href="Edit.aspx" class="btn btn-primary btn-sm block">Editar perfil</a>
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
                        </div>
                    </nav>
                </div>
                <link rel="stylesheet" href="red_files/jquery.css">
                <style type="text/css">
                    html {
                        height: auto !important;
                        min-height: unset !important;
                    }

                    body {
                        height: auto !important;
                        overflow: unset !important;
                    }

                    div#wrapper, div#page-wrapper {
                        overflow: unset !important;
                        min-height: unset !important;
                    }

                    div.orgchart.l2r {
                        padding-right: 60px !important;
                        position: relative !important;
                    }

                    div.footer {
                        position: fixed !important;
                        bottom: 0px !important;
                    }

                    div.ibox.float-e-margins, div.ibox-content, div.box-chart {
                        height: auto !important;
                        min-height: unset !important;
                        overflow: unset !important;
                        position: relative !important;
                    }

                    div.ibox-content {
                        padding-bottom: 190px !important;
                    }

                    div.buttons {
                        float: right !important;
                        margin-top: 0px !important;
                        margin-right: 10px !important
                    }

                    div.ibox.float-e-margins {
                        margin-bottom: 0px !important;
                    }

                    div.box-chart {
                        clear: both !important;
                        width: 100% !important;
                        background-color: #FFFFFF !important
                    }

                    div.ibox-content ol.breadcrumb.green, div.ibox-content div.buttons, h2.green, div.box-hr {
                        z-index: 999999 !important;
                        position: relative !important;
                        background-color: #FFFFFF !important;
                    }

                    div#chart-container {
                        z-index: 9 !important;
                    }

                    h2.green {
                        margin: 0px !important;
                        padding: 5px 0px 10px 0px !important;
                        background: none !important;
                    }

                    div.ibox-content div.buttons {
                        z-index: 9999999 !important;
                    }

                    div#wrapper div#page-wrapper.gray-bg div.wrapper.wrapper-content.animated.fadeInUp {
                        position: relative;
                    }

                    div.box-hr hr {
                        margin-top: 0px !important;
                    }
                </style>
                <div class="wrapper-content animated fadeInUp">
                    <div class="ibox float-e-margins">
                        <div class="ibox-content" style="overflow: unset !important; height: auto !important; position: relative; min-height: unset !important;">
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
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Mi red</a>
                                                </div>
                                                <div class=" col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Bonus.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block height">Comisiones y Pagos</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Store.aspx">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block height" border="0" />Tienda
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
                                    <h2 class="green"><b>Mi red</b></h2>
                                    <ol class="breadcrumb negro">
                                        <li class="breadcrumb-item ">
                                            <a href="Red.aspx" >Arbol de Patrocinio</a>
                                        </li>
                                        <li class="breadcrumb-item active">
                                            <a href="ResidualTree.aspx" class="subrayar">Arbol residual</a>
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
                                        <li class="breadcrumb-item ">
                                            <a href="HistoryRange.aspx">Historial de rangos</a>
                                        </li>
                                    </ol>
                                </div>
                                <div class="col-md-6" id="Partial-VirtualOffice">
                                </div>
                            </div>
                            <div class="row box-hr">
                                <hr>
                            </div>
                            <div class="row">
                                <div style="width: 15px; height: 15px;display: inline-block; solid black" class="bg-affiliate"></div>
                                <span>Patrocinados Directos</span>
                            </div>
                             <div class="row">
                                <div style="width: 15px; height: 15px; background-color: #36FF33 !important; display: inline-block;    solid black"></div>
                                <span>Socios activos</span>
                            </div>
                             <div class="row">
                                <div style="width: 15px; height: 15px; background-color: #ffcd00 !important; display: inline-block;  solid black"></div>
                                <span>Socios nuevos</span>
                            </div>
                             <div class="row">
                                <div style="width: 15px; height: 15px; background-color: #E84714 !important; display: inline-block; solid black"></div>
                                <span>Socios con deuda</span>
                            </div>
                            <%--<div class="row" style="padding-bottom: 20px; position: relative">
                                <div class="buttons hidden-xs">
                                    <button class="zoom-in btn btn-default negro_btn">Acercar +</button>
                                    <button class="zoom-out btn btn-default negro_btn">Alejar -</button>
                                </div>
                            </div>--%>
                            <div class="row box-chart hidden-xs" style="display: inline">
                                <%--overflow: hidden;--%>
                                <div id="chart-container" style="overflow: unset !important; height: auto !important; position: relative; min-height: unset !important; transform: matrix(1, 0, 0, 1, 1, 0); transition: none 0s ease 0s;">
                                    <div class="orgchart l2r" id="treeBody">
                                        <!--Go the Tree-->

                                    </div>
                                </div>
                            </div>
                            <%--<div class="row visible-xs">
                                <div class="alert alert-warning">
                                    La red solo se puede visualizar desde una desktop o Tablet/Ipad
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </div>
                <div class="modal inmodal" id="datosSocio" tabindex="-1" role="dialog" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog">
                        <div class="modal-content animated bounceInRight">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">Datos del socio</h4>
                            </div>
                            <div class="modal-body">
                                <ul>
                                    <li><strong>DNI:</strong><span class="mdl_data socio_dni">08873258</span></li>
                                    <li><strong>Nombres:</strong><span class="mdl_data socio_nombre">Fidel</span></li>
                                    <li><strong>Apellidos:</strong><span class="mdl_data socio_apellidos">Barreto Villacorta</span></li>
                                    <li><strong>Correo:</strong><span class="mdl_data socio_correo">fidelbarretovilla@gmail.com</span></li>
                                    <li><strong>Celular:</strong><span class="mdl_data socio_celular"><a href="tel:997618875">997618875</a></span></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Label runat="server" ID="Status" Style="display: none"></asp:Label>
                <asp:Label runat="server" ID="Ranguito" Style="display: none"></asp:Label>
                <style type="text/css">
                    /* Color distinto en el arbol */
                    .orgchart .val-Cons-May .title {
                        background-color: #006699 !important;
                    }

                    .orgchart .val-Cons-May .content {
                        border-color: #006699 !important;
                    }
                </style>
                <script type="text/javascript" src="red_files/jquery_012.js"></script>

                <script type="text/javascript">

                    var base_url = '';
                    var idsocio = 168;
                    var idopera = 1;
                    var nombresocio = '';
                    var direcsocio = '';
                    var rango = document.getElementById("Ranguito").innerText;
                    var simbolo = 'S/.';
                    var csrfsn = '';


                </script>
                <script type="text/javascript">


                    $(function () {
                        GetDos("ResidualTreeC", null, (_data) => {
                            var anwser = _data;

                            anwser = anwser.replace('"Children":[],', '');

                            var jsonaa = eval('' + anwser + '');

                            nombresocio = document.getElementById('lblUserName').innerText;
                            var qwe = jsonaa[0];

                            var datasource = {
                                'name': nombresocio,
                                'title': "<span>• </span> " + document.getElementById("Status").innerText + "  <br>  " + rango + "",
                                'children': jsonaa
                            }

                            console.log(datasource);

                            var oc = $('#chart-container').orgchart({
                                'data': datasource,
                                'depth': 2,
                                'nodeContent': 'title',
                                'direction': 'l2r',
                                'nodeID': 'id',
                                'createNode': function ($node, data) {

                                }
                            });


                            //document.getElementById("divProgressBar").style.display = "none";className += " bg-affiliate";

                            let list = document.getElementsByClassName('affiliate');

                            for (var i = 0; i < list.length; i++) {
                                list[i].id = "cuad" + i.toString();
                                //let parent = document.getElementById("cuad" + i.toString()).parentElement();
                                let parent = $("#cuad" + i.toString()).parent()
                                parent[0].className += " bg-affiliate";

                                let gola = 0;
                            }

                            let listred = document.getElementsByClassName('statusred');
                            for (var i = 0; i < listred.length; i++) {
                                listred[i].id = "cuadred" + i.toString();
                                //let parent = document.getElementById("cuad" + i.toString()).parentElement();
                                let parent = $("#cuadred" + i.toString()).parent()
                                parent[0].className += " bg-red";

                                let gola = 0;
                            }

                            let listambar = document.getElementsByClassName('statusambar');
                            for (var i = 0; i < listambar.length; i++) {
                                listambar[i].id = "cuadrambar" + i.toString();
                                //let parent = document.getElementById("cuad" + i.toString()).parentElement();
                                let parent = $("#cuadrambar" + i.toString()).parent()
                                parent[0].className += " bg-ambar";

                                let gola = 0;
                            }

                            let listgreen = document.getElementsByClassName('statusgreen');
                            for (var i = 0; i < listgreen.length; i++) {
                                listgreen[i].id = "cuadrgreen" + i.toString();
                                //let parent = document.getElementById("cuad" + i.toString()).parentElement();
                                let parent = $("#cuadrgreen" + i.toString()).parent()
                                parent[0].className += " bg-green";

                                let gola = 0;
                            }

                        });

                    });

                </script>
                <script>
                    //(function () {
                    //    $('div#chart-container').panzoom({
                    //        $zoomIn: $(".zoom-in"),
                    //        $zoomOut: $(".zoom-out"),
                    //        startTransform: 'scale(1.1)',
                    //        increment: 0.1,
                    //        minScale: 0.4,
                    //        maxScale: 1.0,
                    //        contain: 'automatic'
                    //    }).panzoom('zoom');
                    //})();
                    $(function () {
                        $('div#wrapper div#page-wrapper.gray-bg div.wrapper.wrapper-content div.container').css("cssText", "height: auto !important;");
                        $('.ibox-content').removeAttr('style');
                        $('#chart-container, .ibox-content').css("cssText", "overflow: unset !important; height: auto !important; position: relative; min-height: unset !important;");
                    });
                </script>
                <!-- Favorito -->
                <div class="modal inmodal" id="mdlTerminosCondiciones" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content animated bounceInRight">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">TERMINOS Y CONDICIONES</h4>
                            </div>
                            <div class="modal-body">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="footer footer-fondo">
                    <strong>Ribera del Rio - 2018</strong>
                </div>
            </div>
        </div>
        <a id="scrollUp" href="#top" title="Scroll to top" style="position: fixed; z-index: 2147483647;"></a>
        <script type="text/javascript">
            $(window).bind('scroll', function () {
                if ($(window).scrollTop() > 180) { $('#scrollUp').fadeIn('slow'); } else { $('#scrollUp').fadeOut('slow'); }
            });
            $("a[href='#top']").click(function () {
                $("html, body").animate({ scrollTop: 0, scrollLeft: 0 }, "slow");
                return false;
            });
        </script>
        <script type="text/javascript">


        </script>
        <script src="Script/_virtualOffice.js"></script>
    </form>
</body>
</html>
