<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MULTI_NIVEL.Views.Index" %>

<!DOCTYPE html>
<html>
<head runat="server">

    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Inicio | inResorts </title>
    <link href="../Views/Css/bootstrap.css" rel="stylesheet">
    <link href="../Views/home_files/font-awesome.css" rel="stylesheet">
    <link href="../Views/home_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="../Views/home_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="../Views/home_files/chosen.css" rel="stylesheet">
    <link href="../Views/home_files/datepicker3.css" rel="stylesheet">
    <link href="../Views/home_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="../Views/home_files/ladda-themeless.css" rel="stylesheet">
    <link href="../Views/home_files/animate.css" rel="stylesheet">
    <link href="../Views/home_files/style.css" rel="stylesheet">
    <link href="../Views/Css/StyleIndex.css" rel="stylesheet" />
    <link href="../Views/Css/globe.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">
    <link href="Css/MyStyle.css" rel="stylesheet" />
    <!-- Incluyendo .js de Culqi JS -->
    <script src="../Views/Script/Script.js"></script>
    <style>
        .content-notification {
            width: 480px;
            height: 100%;
            max-height: 350px;
            overflow: auto;
        }

        .item-notification {
            width: 479px;
            height: 100%;
            border-bottom: 1px solid grey;
            background-color: #edf2fa;
            cursor: pointer;
            text-align: left;
        }

            .item-notification:hover {
                background-color: rgb(227,232,241);
            }

        .data-notification {
            display: inline-block;
            text-align: left;
            cursor: pointer;
        }

        .imag {
            width: 60px;
            height: 50px;
            display: inline;
        }
    </style>

    <script src="../Views/home_files/jquery-3.js"></script>
    <script src="../Views/home_files/bootstrap.js"></script>
    <script src="../Views/home_files/jquery_003.js"></script>
    <script src="../Views/home_files/jquery_006.js"></script>
    <script src="../Views/home_files/inspinia.js"></script>
    <script src="../Views/home_files/pace.js"></script>
    <script src="../Views/home_files/jquery.js"></script>
    <script src="../Views/home_files/jquery_008.js"></script>
    <script src="../Views/home_files/jquery_007.js"></script>
    <script src="../Views/home_files/Chart.js"></script>
    <script src="../Views/home_files/jasny-bootstrap.js"></script>
    <script src="../Views/home_files/jquery_002.js"></script>
    <script src="../Views/home_files/jquery_004.js"></script>
    <script src="../Views/home_files/peity-demo.js"></script>
    <script src="../Views/home_files/datatables.js"></script>
    <script src="../Views/home_files/chosen.js"></script>
    <script src="../Views/home_files/bootstrap3-typeahead.js"></script>
    <script src="../Views/home_files/jquery_005.js"></script>
    <script src="../Views/home_files/bootstrap-datepicker.js"></script>
    <script src="../Views/Script/Notification.js"></script>
    <style>
        #contenedor_principal {
            width: 1224px;
            height: auto;
            position: relative;
            margin: auto;
        }

        .contenedor_imagen_texto {
            width: 435px;
            height: auto;
            position: relative;
            display: inline-block;
            vertical-align: top;
            overflow: hidden;
        }

        @keyframes DesapareceHollow {
            0% {
                opacity: 1;
                top: 0px;
                height: 90%;
            }

            40% {
                width: 100%;
                opacity: 0.6;
                top: 300px;
                height: 0;
            }

            100% {
                width: 0;
                top: 300px;
                height: 0;
            }
        }
    </style>
</head>
<body class="top-navigation pace-done">
    <form id="form1" runat="server">
        <div class="pace pace-inactive">
            <div class="pace-progress" style="transform: translate3d(100%, 0px, 0px);" data-progress-text="100%" data-progress="99">
                <div class="pace-progress-inner">
                </div>
            </div>
            <div class="pace-activity">
            </div>
        </div>
        <div id="wrapper">
            <div id="page-wrapper" class="gray-bg">
                <div class="row border-bottom white-bg iniciowp">
                    <nav class="navbar navbar-static-top" role="navigation">
                        <div class="navbar-header header-inicio">
                            <button aria-controls="navbar" aria-expanded="false" data-target="#navbar" data-toggle="collapse" class="navbar-toggle collapsed" type="button">
                                <i class="fa fa-reorder"></i>
                            </button>
                            <a href="Index.aspx" class="navbar-brand inicio-logo">
                                <img src="img/novologo.png" class="img-responsive"></a>
                        </div>
                        <div class="navbar-collapse collapse" id="navbar">
                            <ul class="nav navbar-top-links navbar-right header-inicior">
                                <!-- <li>-->

                                <!--</li>-->
                                <li>
                                    <div class="globo" id="globo" style="display: none;">
                                        <span id="quantity" class="notif"><b></b></span>
                                    </div>
                                    <div class="btn-group" style="border-radius: 20px; width: 40px; margin-top: 5px; margin-right: 1px; height: 40px;">
                                        <button class="btn btn-secondary btn-sm dropdown-toggle" onclick="n();" style="background-color: #0a304e; border-radius: 30px; height: 31px; width: 32px; padding: 0;" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            <i class="fa fa-bell fa-lg white" style="color: #fff" aria-hidden="true"></i>
                                        </button>
                                        <div class="dropdown-menu">
                                            <div class="__tw _4xi1 uiToggleFlyout" role="dialog" id="fbNotificationsFlyout" aria-labelledby="fbNotificationsJewelHeader">
                                                <div class="beeperNub"></div>
                                                <div class="uiHeader uiHeaderBottomBorder jewelHeader">
                                                    <div class="clearfix uiHeaderTop">
                                                        <div>
                                                            <h3 class="uiHeaderTitle" aria-hidden="true">Notificaciones</h3>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="_33p">
                                                    <div id="u_0_h">
                                                        <div class="_50-t" style="height: 600px;">
                                                            <div width="430" class="uiScrollableArea fade uiScrollableAreaWithShadow contentAfter">
                                                                <div class="uiScrollableAreaWrap scrollable" id="js_7s" style="overscroll-behavior: contain contain;">
                                                                    <div class="uiScrollableAreaBody" style="width: 430px;">
                                                                        <div class="uiScrollableAreaContent">
                                                                            <ul data-ft="{&quot;tn&quot;:&quot;-d&quot;}" data-gt="{&quot;ref&quot;:&quot;notif_jewel&quot;,&quot;jewel&quot;:&quot;notifications&quot;}" data-testid="react_notif_list" class="">
                                                                                <li>
                                                                                    <div class="_32hm">
                                                                                        <div class="_fyy">NUEVAS</div>
                                                                                        <ul>
                                                                                            <li class="_33c jewelItemNew" data-ft="{&quot;tn&quot;:&quot;-e&quot;}" data-gt="{&quot;alert_id&quot;:1543955616959451,&quot;notif_type&quot;:&quot;live_video_explicit&quot;,&quot;from_uids&quot;:{&quot;1807109579515449&quot;:1807109579515449},&quot;unread&quot;:1,&quot;time_sent&quot;:1543962612,&quot;content_id&quot;:1972697313030599,&quot;context_id&quot;:1807109579515449,&quot;row&quot;:0}" data-alert-id="100000820055314:1543955616959451" data-testid="notif_list_item">
                                                                                                <div class="_dre anchorContainer">
                                                                                                    <div class="">
                                                                                                        <a data-testid="notif_list_item_link" href="" role="button" tabindex="0" class="_33e _1_0e">
                                                                                                            <div direction="left" class="clearfix">
                                                                                                                <div class="_ohe lfloat">
                                                                                                                    <img alt="" class="_62bh img _8o _8r _2qgu img" src="">
                                                                                                                </div>
                                                                                                                <div class="">
                                                                                                                    <div class="_42ef _8u">
                                                                                                                        <div direction="right" class="clearfix">
                                                                                                                            <div class="_ohf rfloat">
                                                                                                                                <img src="" class="_42td img" aria-hidden="true" alt="">
                                                                                                                            </div>
                                                                                                                            <div class="">
                                                                                                                                <div class="_42ef">
                                                                                                                                    <div class="_4l_v">
                                                                                                                                        <span><span class="fwb _6btd"><span>Psicology Dota</span></span><span> está transmitiendo en vivo: "DOTA 2: INFAMOUS GAMING VS PLAYMAKERS BO3 BUCHAREST MINOR".</span></span>
                                                                                                                                        <div class="_33f clearfix" direction="left">
                                                                                                                                            <div class="_ohe lfloat">
                                                                                                                                               
                                                                                                                                            </div>
                                                                                                                                            <div class="">
                                                                                                                                                <div class="_42ef _8u">
                                                                                                                                                    <span class="_6t8b">
                                                                                                                                                        <abbr class="_33g livetimestamp" title="Martes, 4 de diciembre de 2018 a las 17:30" data-utime="1543962612" data-minimize="true">14 min</abbr><span></span></span>
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
                                                                                                        </a>
                                                                                                    </div>
                                                                                                    <ul class="_55mc">
                                                                                                        <li class="_h_c">
                                                                                                            <div aria-label="Marcar como leída" class="_55m9 _55ma _5c9q" data-hover="tooltip" data-testid="notif_read_toggle_button" data-tooltip-alignh="center" data-tooltip-content="Marcar como leída" role="button" tabindex="0"></div>
                                                                                                        </li>
                                                                                                        <li class="_h_d">
                                                                                                            <div data-testid="chevron" class="_55m9 _1_0c uiPopover _6a _6b"><a href="#" aria-label="Notification options" class="_1_0d _2agf _4o_4 _p" data-testid="notif_chevron_button" aria-haspopup="true" role="button"></a></div>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </li>
                                                                                            <li class="_33c jewelItemNew" data-ft="{&quot;tn&quot;:&quot;-e0&quot;}" data-gt="{&quot;alert_id&quot;:1543792102892022,&quot;notif_type&quot;:&quot;group_highlights&quot;,&quot;subtype&quot;:&quot;highlights_friend_liker_commenter&quot;,&quot;from_uids&quot;:{&quot;1274851613&quot;:1274851613,&quot;1645487335&quot;:1645487335,&quot;100000887698878&quot;:100000887698878,&quot;100001743787526&quot;:100001743787526,&quot;100003185837548&quot;:100003185837548,&quot;100001025042226&quot;:100001025042226,&quot;100014029539696&quot;:100014029539696,&quot;100007231366711&quot;:100007231366711},&quot;unread&quot;:1,&quot;time_sent&quot;:1543962533,&quot;content_id&quot;:2221731414754512,&quot;context_id&quot;:1488436764750651,&quot;row&quot;:1}" data-alert-id="100000820055314:1543792102892022" data-testid="notif_list_item">
                                                                                                <div class="_dre anchorContainer">
                                                                                                    <div class="">
                                                                                                        <a data-testid="notif_list_item_link" href="" role="button" tabindex="0" class="_33e _1_0e">
                                                                                                            <div direction="left" class="clearfix">
                                                                                                                <div class="_ohe lfloat">
                                                                                                                    <img alt="" class="_62bh img _8o _8r _2qgu img" src="">
                                                                                                                </div>
                                                                                                                <div class="">
                                                                                                                    <div class="_42ef _8u">
                                                                                                                        <div direction="right" class="clearfix">
                                                                                                                            <div class="_ohf rfloat">
                                                                                                                                <img src="" aria-hidden="true" alt="">
                                                                                                                            </div>
                                                                                                                            <div class="">
                                                                                                                                <div class="_42ef">
                                                                                                                                    <div class="_4l_v">
                                                                                                                                        <span><span class="fwb _6btd"><span>Gardiel MP</span></span><span> comentó una publicación en </span>
                                                                                                                                            <span class="fwb _6btd">
                                                                                                                                                <span>ONE PIECE REYES <span class="_5mfr">
                                                                                                                                                    <span class="_6qdm" style="height: 16px; width: 16px; font-size: 16px; background-image: url(&quot;https://static.xx.fbcdn.net/images/emoji.php/v9/t44/1/16/1f480.png&quot;);">💀</span></span></span></span><span>.</span></span><div class="_33f clearfix" direction="left">
                                                                                                                                                        <div class="_ohe lfloat">
                                                                                                                                                            <img class="_10cu img _8o _8r img" src="" alt="">
                                                                                                                                                        </div>
                                                                                                                                                        <div class="">
                                                                                                                                                            <div class="_42ef _8u">
                                                                                                                                                                <span class="_6t8b">
                                                                                                                                                                    <abbr class="_33g livetimestamp" title="Martes, 4 de diciembre de 2018 a las 17:28" data-utime="1543962533" data-minimize="true">20 min</abbr><span></span></span>
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
                                                                                                        </a>
                                                                                                    </div>
                                                                                                    <ul class="_55mc">
                                                                                                        <li class="_h_c">
                                                                                                            <div aria-label="Marcar como leída" class="_55m9 _55ma _5c9q" data-hover="tooltip" data-testid="notif_read_toggle_button" data-tooltip-alignh="center" data-tooltip-content="Marcar como leída" role="button" tabindex="0" id="js_u6"></div>
                                                                                                        </li>
                                                                                                        <li class="_h_d">
                                                                                                            <div data-testid="chevron" class="_55m9 _1_0c uiPopover _6a _6b">
                                                                                                                <a href="#" aria-label="Notification options" class="_1_0d _2agf _4o_4 _p" data-testid="notif_chevron_button" aria-haspopup="true" role="button"></a>
                                                                                                            </div>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </li>
                                                                                        </ul>
                                                                                    </div>
                                                                                </li>
                                                                            </ul>
                                                                            <span class="jewelLoading img _55ym _55yn _55yo _2y32" role="progressbar" aria-valuetext="Cargando..." aria-busy="true" aria-valuemin="0" aria-valuemax="100"></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="uiScrollableAreaTrack hidden_elem" style="opacity: 0;">
                                                                    <div class="uiScrollableAreaGripper" style="height: 358.317px; top: 0px;"></div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="jewelFooter">
                                                    <a class="seeMore" href="" accesskey="5">
                                                        <span>Ver todas</span></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <asp:Panel runat="server" class="globo" ID="globo2" Style="display: none;">
                                        <asp:Label runat="server" ID="quantity2" class="notif"><b></b></asp:Label>
                                    </asp:Panel>
                                    <div class="btn-group" style="margin-left: 5px; border-radius: 20px; width: 40px; margin-top: 12px; margin-right: 4px; height: 40px;">
                                        <%--<a href="News.aspx">--%>
                                        <asp:LinkButton runat="server" ID="NewsView" OnClick="NewsView_Click" class=""
                                            Style="background-color: #0a304e; border-radius: 30px; height: 31px; width: 32px; padding: 7px; border-radius: 20px; width: 40px; margin-top: -1px; margin-right: 7px; height: 31px;">
                                                <i class="fas fa-newspaper fa-lg white" style="color: #fff" aria-hidden="true"></i>
                                        </asp:LinkButton>
                                    </div>
                                </li>
                                <li>
                                    <asp:Image ID="imgProfile" Style="width: 40px; height: 40px; margin: auto;" runat="server" alt="..." CssClass="img-circle img-responsive img-user" />
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle userClass" data-toggle="dropdown" role="button" aria-expanded="false">
                                        <asp:Label ID="lblUser" runat="server"></asp:Label>
                                        <span class="caret"></span></a>
                                    <ul class="dropdown-menu detalle-user" role="menu">
                                        <li>
                                            <div class="floatleft">
                                                <asp:Image ID="imgProfileFl" Style="width: 77px; height: 77px;  margin: auto;" runat="server" alt="..." class="img-circle img-responsive img-user1" />
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
                        </div>
                    </nav>
                </div>
                <div class="slider_home">
                    <center>
                        <div class="item active">
                            <img alt="image" class="img-responsive" src="img/lienzofinal100.png" width="100%"  >
                        </div>  
                      </center>
                </div>
                <div class=" imgofivir">
                    <img class="img-responsive center-block" src="img/oficinavirtualsol33.png">
                </div>
                <div class="container-fluid ">
                    <div class="row">

                        <div class="col-md-4">
                            <div class="row">
                            </div>
                        </div>
                        <div class="col-md-13">
                            <div class="links" style="border-color: #000; box-shadow: 10px 10px 20px -10px rgba(0,0,0,0.8);">
                                <div class="row">
                                    <div class="col-md-12" id="btnflex">
                                        <div class="col-md-3 separadorbarra" style="z-index: 100;">
                                            <a href="Register.aspx">
                                                <img src="../Resources/Images/nuevo.png" class="img-responsive center-block height">Nuevo Socio</a>
                                        </div>
                                        <div class=" col-md-2 separadorbarra " style="z-index: 100;">
                                            <%--<a href="http://reservas.inresorts.club/riberatravel">--%>
                                            <a href="Tools.aspx">
                                                <img src="img/universidad.png" class="img-responsive center-block height">Sistemas Educativo</a>
                                        </div>
                                        <div class="col-md-2  separadorbarra " style="z-index: 100;">
                                            <a href="Red.aspx">
                                                <img src="../Resources/Images/redes.png" class="img-responsive center-block height">Mi Red</a>
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
                                                <img src="../Resources/Images/shop3.svg" class="img-responsive center-block height" border="0" />Tienda
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br>



                <asp:Panel runat="server" ID="banni" class="row banni" Style="display: none">
                    <div class="col-md-12 " style="display: inline-block; width: 100%;">
                        <a class="banner banner--gradient-bg" style="text-decoration: none;">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-12" style="text-align: center">
                                        <div class="banner__logo-wrapper">
                                            <i class="fi fi-codepen"></i>
                                        </div>
                                        <div>
                                            <div class="banner__title">
                                                Felicitaciones
                                                <asp:Label runat="server" ID="lblUserban"></asp:Label>
                                            </div>
                                            <div class="banner__text">
                                                Ya eres
                                                <asp:Label runat="server" ID="namerange"></asp:Label>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                            </div>
                        </a>
                    </div>
                </asp:Panel>

                <br />




                <div class="container">
                    <div class="col-md-3">
                        <div class="cuadromuestra" style="border-color: #2981c5">
                            <div class="cabeceramuestra" style="border-color: #2981c5; background-color: #2981c5">
                                In Resorts
                            </div>
                            <div class="cuerpomuestra">
                                <table class="tablemuestra">
                                    <tbody>
                                        <tr>
                                            <td>Socios inResorts:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="lblnsocios" Text="text" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 4px"></td>
                                        </tr>
                                        <tr>
                                            <td>Ciclo Facturación:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">

                                                <asp:Label ID="lblCicloFacIni" runat="server"></asp:Label><br />
                                                <asp:Label ID="lblCicloFacTo" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 4px"></td>
                                        </tr>

                                        <tr>
                                            <td>Ciclo Calificación:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">

                                                <asp:Label ID="lblCicloCalIni" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblCicloCalTo" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="cabeceramuestra " style="border-radius: 0px; border-color: #2981c5; background-color: #2981c5">
                                Mi Estado
                            </div>
                            <div class="cuerpomuestra">
                                <table class="tablemuestra">
                                    <tbody>
                                        <tr>
                                            <td>Estado
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label runat="server" ID="StatusAcount"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 4px"></td>
                                        </tr>
                                        <tr>
                                            <td>Activo hasta
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label runat="server" ID="ActivoHasta"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 6px"></td>
                                        </tr>
                                        <tr>
                                            <td>Puntaje de Cuota Pagada
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label runat="server" ID="Points"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 4px"></td>
                                        </tr>
                                        <tr>
                                            <td>Proxima fecha de cuota
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label runat="server" ID="NextDate"></asp:Label>
                                            </td>
                                        </tr>

                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="cuadromuestra" style="border-color: #2981c5">

                            <div class="cuadromuestra" id="front" style="border-radius: 0px; border: 0px; margin: 0 0 8px 0px;">
                                <div class="cabeceramuestra" style="background-color: #2981c5; border-color: #2981c5">
                                    Frontalidad y Estructura
                                </div>
                                <style>
                                    #front {
                                        width: 100%;
                                        margin-left: 0px;
                                        text-align: center;
                                    }
                                </style>
                                <div class="cuerpomuestra" style="text-align: left">
                                    <table class="tablemuestra" style="margin: 0px;">
                                        <tbody>
                                            <tr>
                                                <td width="70%" style="text-align: center;">Líneas activas 
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblActivas" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="70%" style="text-align: center;">Niveles Activos 
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDepthLevels" Text="0" runat="server" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="">
                                        <table class="tablemuestra" cellspacing="4">
                                            <tbody>
                                                <tr align="center" style="display: none">

                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <asp:Label ID="RamaTo1" Text="0" runat="server" /></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <asp:Label ID="RamaTo2" Text="0" runat="server" /></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <asp:Label ID="RamaTo3" Text="0" runat="server" /></td>
                                                     
                                                </tr>
                                                <tr align="center">
                                                    <th colspan="4" style="text-align: center; height: 15px;"></th>
                                                </tr>
                                                <tr align="center">
                                                    <th colspan="4" style="text-align: center; height: 30px; color: white; background-image: linear-gradient(#1874a0f2, #1e91ca, #0b84bee8);">Puntaje Total por Rama -
                                                        <asp:Label Style="color: white" ID="lblRankVolume" Text="0.00" runat="server" /></th>
                                                </tr>
                                                <tr align="center" style="">

                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaTo1a">1</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaTo2a">2</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaTo3a">3</span></td>
                                                    
                                                </tr>
                                                <tr align="center" style="">

                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="FirtsLine" Text="0.00" runat="server" /></td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="SecondLine" Text="0.00" runat="server" /></td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="ThirdLine" Text="0.00" runat="server" /></td>
                                                    
                                                </tr>
                                                <tr align="center">
                                                    <th colspan="4" style="text-align: center; height: 15px;"></th>
                                                </tr>
                                                <tr align="center" id="currenttr">
                                                    <th colspan="4" style="text-align: center; height: 30px; color: white; background-image: linear-gradient(#1874a0f2, #1e91ca, #0b84bee8);">
                                                        <asp:Label ID="TituloRActual" Text="" runat="server" />
                                                        -
                                                        <asp:Label ID="TotalRangeCurrent" Text="text" runat="server" /></asp:Panel>
                                                    </th>
                                                </tr>
                                                <tr align="center" style="" id="currenttr2">

                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaTo1">1</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaTo2">2</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaTo3">3</span></td>
                                                     
                                                </tr>

                                                <tr align="center" style="" id="currenttr3">

                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="DivRange1" runat="server">
                                                            <asp:Label ID="FirtsLineP" Text="text" runat="server" style="vertical-align: top;"/>
                                                            <div style="display: block" class="range-good"></div>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="DivRange2" runat="server">
                                                            <asp:Label ID="SecondLineP" Text="text" runat="server"  style="vertical-align: top;"/>
                                                            <div style="display: block" class="range-good"></div>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="DivRange3" runat="server">
                                                            <asp:Label ID="ThirdLineP" Text="text" runat="server"  style="vertical-align: top;" />
                                                            <div style="display: block" class="range-good"></div>
                                                        </asp:Panel>
                                                    </td> 
                                                </tr>

                                                <tr align="center">
                                                    <th colspan="4" style="text-align: center; height: 15px;"></th>
                                                </tr>
                                                <tr align="center">
                                                    <th colspan="4" style="text-align: center; height: 30px; color: white; background-image: linear-gradient(#1874a0f2, #1e91ca, #0b84bee8);">Proximo Rango - 
                                                        <asp:Label ID="SumProxRange" Text="0" runat="server" /></th>
                                                </tr>
                                                <tr align="center" style="">

                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaTo1">1</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaTo2">2</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaTo3">3</span></td>
                                                    
                                                </tr>
                                                <tr align="center">
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="ValueIdeal" Text="" runat="server" /></td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                         <asp:Label ID="ValueIdeal2" Text="" runat="server" /></td>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                         <asp:Label ID="ValueIdeal3" Text="" runat="server" /></td>
                                                    </td>
                                                </tr>    
                                                <tr align="center" style="">

                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="FirtsLineP2" Text="0" runat="server"  style="vertical-align: top;" />
                                                        <asp:Panel ID="FirtsLineP2Icon" Style="" runat="server"></asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="SecondLineP2" Text="0" runat="server"  style="vertical-align: top;" />
                                                        <asp:Panel ID="SecondLineP2Icon" Style="" runat="server"></asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="ThirdLineP2" Text="0" runat="server"  style="vertical-align: top;" />
                                                        <asp:Panel ID="ThirdLineP2Icon" Style="" runat="server"></asp:Panel>
                                                    </td>
                                                  
                                                </tr>

                                                <tr style="display: none">
                                                    <td colspan="4" style="text-align: center; background-color: #e0edf4;">
                                                </tr>
                                                <tr align="center">
                                                    <th colspan="4" style="text-align: center; height: 15px;"></th>
                                                </tr>
                                                <tr align="center" style="display: none">
                                                    <th colspan="4" style="text-align: center; height: 30px; background-image: linear-gradient(#1874a0f2, #1e91ca, #0b84bee8);">Rango Puntaje</th>
                                                </tr>

                                                <tr align="center" style="display: none">

                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="Rpuntaje1" Text="0" runat="server" /></td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="Rpuntaje2" Text="0" runat="server" /></td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="Rpuntaje3" Text="0" runat="server" /></td>
                                                    
                                                </tr>
                                                <tr align="center" style="height: 30px; display: none">
                                                    <td colspan="5" style="background-color: #e0edf4; height: 30px;">
                                                        <asp:Label ID="Rpuntajtotal" Text="0" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr align="center" style="height: 30px; background-image: linear-gradient(#e2e2e2ad, #feffff, #90909070);">
                                                    <td colspan="2">Puntos Faltantes</td>
                                                    <td colspan="2">
                                                        <asp:Label ID="PtsFaltan" Text="0" runat="server" /></td>
                                                </tr>
                                                <tr align="center" style="height: 30px; background-image: linear-gradient(#e2e2e2ad, #feffff, #90909070);">
                                                    <td align="center" colspan="2"># Personas faltantes</td>
                                                    <td colspan="2">
                                                        <asp:Label ID="PersFaltan" Text="0" runat="server" /></td>
                                                </tr>




                                                <tr align="center">
                                                    <th colspan="4" style="text-align: center; height: 15px;"></th>
                                                </tr>

                                                 
                                                <tr align="center" id="Residttr">
                                                    <th colspan="4" style="text-align: center; height: 30px; color: white; background-image: linear-gradient(#1874a0f2, #1e91ca, #0b84bee8);">
                                                        <asp:Label ID="TitleResidual" Text="Puntos Actuales Residual" runat="server" />
                                                        -
                                                        <asp:Label ID="TitleResidualPts" Text="00" runat="server" />
                                                    </th>
                                                </tr>
                                                <tr align="center" style="">

                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaRe1">1</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaRe2">2</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span id="RamaRe3">3</span></td>
                                                   
                                                </tr>
                                                <tr align="center" style="" id="redislttr3">

                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="Panel1" runat="server">
                                                            <asp:Label ID="ResidRama1" Text="0" runat="server" />
                                                            <div style="display: block" class=""></div>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="Panel2" runat="server">
                                                            <asp:Label ID="ResidRama2" Text="0" runat="server" />
                                                            <div style="display: block" class=""></div>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="Panel3" runat="server">
                                                            <asp:Label ID="ResidRama3" Text="0" runat="server" />
                                                            <div style="display: block" class=""></div>
                                                        </asp:Panel>
                                                    </td>
                                                    
                                                </tr>
                                                  <tr align="center">
                                                    <th colspan="4" style="text-align: center; height: 15px;"></th>
                                                </tr>
                                                <tr align="center" id="currenttrr">
                                                    <th colspan="4" style="text-align: center; height: 30px; color: white; background-image: linear-gradient(#1874a0f2, #1e91ca, #0b84bee8);">
                                                        Rango Residual Actual
                                                        -
                                                        <asp:Label ID="TotalResidualc" Text="text" runat="server" /> 
                                                    </th>
                                                </tr>
                                                <tr align="center" style="" id="currenttr2r">

                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span  >1</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span  >2</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span  >3</span></td>
                                                     
                                                </tr>

                                                <tr align="center" style="" id="currenttr3r">

                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="Panel4" runat="server">
                                                            <asp:Label ID="Residualpa1" Text="text" runat="server" style="vertical-align: top;"/>
                                                            <div style="display: block" class="range-good"></div>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="Panel5" runat="server">
                                                            <asp:Label ID="Residualpa2" Text="text" runat="server"  style="vertical-align: top;"/>
                                                            <div style="display: block" class="range-good"></div>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="Panel6" runat="server">
                                                            <asp:Label ID="Residualpa3" Text="text" runat="server"  style="vertical-align: top;" />
                                                            <div style="display: block" class="range-good"></div>
                                                        </asp:Panel>
                                                    </td> 
                                                </tr>
                                                  <tr align="center">
                                                    <th colspan="4" style="text-align: center; height: 15px;"></th>
                                                </tr>
                                                 <tr align="center" id="currenttr">
                                                    <th colspan="4" style="text-align: center; height: 30px; color: white; background-image: linear-gradient(#1874a0f2, #1e91ca, #0b84bee8);">
                                                        Rango Proximo Residual 
                                                        -
                                                        <asp:Label ID="TotalResidualActual" Text="text" runat="server" /> 
                                                    </th>
                                                </tr>
                                                <tr align="center" style="" id="currenttr2">

                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span  >1</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span  >2</span></td>
                                                    <td style="color: white; background-image: linear-gradient(#2b80ab, #0b84bee8); height: 24px; border-right: 1px solid #ffffff9c;" width="20%">Rama 
                                                    <span  >3</span></td>
                                                     
                                                </tr>
                                                <tr align="center" style="" id="redislttr3">

                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="Panel7" runat="server">
                                                            <asp:Label ID="ResidualIdeal1" Text="0" runat="server" />
                                                            <div style="display: block" class=""></div>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="Panel8" runat="server">
                                                            <asp:Label ID="ResidualIdeal2" Text="0" runat="server" />
                                                            <div style="display: block" class=""></div>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Panel ID="Panel9" runat="server">
                                                            <asp:Label ID="ResidualIdeal3" Text="0" runat="server" />
                                                            <div style="display: block" class=""></div>
                                                        </asp:Panel>
                                                    </td>
                                                    
                                                </tr>
                                                <tr align="center">
                                                      <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="FirtsLineR2" Text="0" runat="server"  style="vertical-align: top;" />
                                                        <asp:Panel ID="FirtsLineR2Icon" Style="" runat="server"></asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="SecondLineR2" Text="0" runat="server"  style="vertical-align: top;" />
                                                        <asp:Panel ID="SecondLineR2Icon" Style="" runat="server"></asp:Panel>
                                                    </td>
                                                    <td style="background-color: #e0edf4; height: 30px; border-right: 1px solid #ffffff9c" width="20%">
                                                        <asp:Label ID="ThirdLineR2" Text="0" runat="server"  style="vertical-align: top;" />
                                                        <asp:Panel ID="ThirdLineR2Icon" Style="" runat="server"></asp:Panel>
                                                    </td>
                                                  
                                                </tr> 
                                            </tbody>
                                        </table>
                                    </div>

                                    <table class="tablemuestra" style="display: none">
                                        <tbody>
                                            <tr style="height: 30px">
                                                <td width="50%">Volumen de rango
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="cuadromuestra" style="border-color: #2981c5">
                            <div class="cabeceramuestra" style="border-color: #2981c5; background-color: #2981c5">
                                Avance de Rango
                            </div>
                            <div class="cuerpomuestra ajuste">
                                <table class="tablemuestra text-center">
                                    <tbody>
                                        <tr>
                                            <td width="90%">
                                                <img src="img/shieldir.png" style="max-width: 110px" class="img-responsive center-block">
                                                <h5><b>Máximo
                                                    <br>
                                                    Logro(ML)</b></h5>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <div class="timeline-centered">
                                                    <article class="timeline-entry">
                                                        <asp:Label ID="RangoSoc" runat="server"></asp:Label>
                                                        <br>

                                                        <div class="timeline-entry-inner left-aligned" >
                                                            <time class="timeline-time" style="right: 108% !important"><span>Diamante Imperial</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul11" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>                                
                                                        <br>
                                                        <div class="timeline-entry-inner left-aligned">
                                                            <time class="timeline-time" style="right: 108% !important"><span>Diamante Corona</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul10" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>
                                                        <br>
                                                        <div class="timeline-entry-inner left-aligned">
                                                            <time class="timeline-time" style="right: 108% !important"><span>Diamante Azul</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul9" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>
                                                        <br>
                                                        <div class="timeline-entry-inner left-aligned">
                                                            <time class="timeline-time" style="right: 108% !important"><span>Diamante Negro</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul8" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>
                                                        <br>
                                                        <div class="timeline-entry-inner left-aligned">
                                                            <time class="timeline-time" style="right: 108% !important"><span>Diamante</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul7" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>
                                                        <br>
                                                        <div class="timeline-entry-inner left-aligned">
                                                            <time class="timeline-time" style="right: 108% !important"><span>Esmeralda</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul6" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>
                                                        <br>
                                                        <div class="timeline-entry-inner left-aligned">
                                                            <time class="timeline-time" style="right: 108% !important"><span>Rubi</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul5" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>
                                                        <br>
                                                        <div class="timeline-entry-inner left-aligned">
                                                            <time class="timeline-time" style="right: 108% !important"><span>Zafiro</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul4" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>
                                                        <br>
                                                        <div class="timeline-entry-inner left-aligned">
                                                            <time class="timeline-time" style="right: 108% !important"><span>Oro</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul3" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>
                                                        <br>
                                                        <div class="timeline-entry-inner left-aligned">
                                                            <time class="timeline-time" style="right: 108% !important"><span>Plata</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul2" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>
                                                        <br>
                                                        <div class="timeline-entry-inner left-aligned">
                                                            <time class="timeline-time" style="right: 108% !important"><span>Socio</span></time>
                                                            <time class="timeline-time" style="left: 12px !important"><span></span></time>
                                                            <asp:Panel runat="server" ID="PtoAzul1" class="timeline-icon bg-secondary">
                                                                <i class="entypo-suitcase"></i>
                                                            </asp:Panel>
                                                        </div>
                                                        <br>
                                                       
                                                    </article>
                                                   
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <br>
                    <br>
                    <hr>
                   <%-- Vista maximo logro --%>
                    <br>
  <%--                     <div class="col-md-3 espacio ">
                                <div class="cuadromuestra altura" style="border-color: #2981c5">
                                     <div class="cabeceramuestra " style="border-color: #2981c5; background-color: #0e7ecd">
                                         Máximo logro
                                 </div>
                            <div class="cuerpomuestra ajuste">
                                <table class="tablemuestra text-center">
                                    <tbody>
                                        <tr>
                                            <td width="90%">
                                                <img src="img/PinDiamanteFinal.png" style="max-width: 110px" class="img-responsive center-block">
                                                <h5><b>Diamante
                                                    <br>
                                                    (ML)</b></h5>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                       <div class="cuadromuestra altura redondeado" style="border-color: #2981c5 ">
                           <div class="cabeceramuestra altura redondeado" style="border-color: #2981c5; background-color: #83c6f6">
                              Periodo Anterior 
                                 </div>
                            <div class="cuerpomuestra ajuste" >
                                <table class="tablemuestra text-center">
                                    <tbody>
                                        <tr>
                                            <td width="90%">
                                                <img src="img/PinEsmeraldaFinal.png" style="max-width: 110px" class="img-responsive center-block">
                                                <h5><b>Esmeralda
                                                    <br>
                                                    (PA)</b></h5>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                          <%-- Inicio de periodo Actual--%>
                    <%--    <div class="cuadromuestra altura redondeado" style="border-color: #1c9dd4">
                             <div class="cabeceramuestra altura redondeado" style="border-color: #2981c5; background-color: #0e7ecd">
                                Periodo Actual 
                            </div>
                            <div class="cuerpomuestra ajuste">
                                <table class="tablemuestra text-center">
                                    <tbody>
                                        <tr>
                                            <td width="90%">
                                                <img src="img/PinDiamanteFinal.png" style="max-width: 110px" class="img-responsive center-block">
                                                <h5><b>Diamante
                                                    <br>
                                                    (PA)</b></h5>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>--%>
                       <%--    Fin de periodo Actual--%>

                         <%--  Calificaciones--%>
                

                         <%--  Fin de calificaciones--%>

<%--                    </div>--%>
                   <%-- --%>
                   <%-- fin vista maximo logros --%>
                    <style>
                        .espacio{
                                padding-top: 10px;
                        }
                        .altura{
                            min-height: 5px;
                        }
                        .redondeado{
                            border-radius: 0px
                        }
                        .ajuste{
                            padding:0px;
                        }
                    </style>
                  

                </div>
                <br>
                <br>
                <div class=" container-fluid footer-fondo">
                    <center>
			<h3>inResorts - 2018</h3>
			</center>
                </div>
                <link rel="stylesheet" type="text/css" href="home_files/slick.css">
                <script type="text/javascript" src="home_files/slick.js"></script>
            </div>
        </div>
        <!--MODAL-->
        <%--<div class="modal inmodal" id="mdlPasarelaPagos" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content animated bounceInRight">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Efectuar Mi Pago</h4>
                    </div>
                    <div class="modal-body" style="overflow: hidden">

                        <div class="col-sm-12">
                            <div class="form-group">
                                <label>Monto Total:</label>
                                <asp:Label Text="$1000" runat="server" />
                            </div>
                            <div class="">
                                <div>
                                    <label>
                                        <span>Correo Electrónico</span>
                                        <input type="text" size="50" data-culqi="card[email]" id="card[email]">
                                    </label>
                                </div>
                                <div>
                                    <label>
                                        <span>Número de tarjeta</span>
                                        <input type="text" size="20" data-culqi="card[number]" id="card[number]">
                                    </label>
                                </div>
                                <div>
                                    <label>
                                        <span>CVV</span>
                                        <input type="text" size="4" data-culqi="card[cvv]" id="card[cvv]">
                                    </label>
                                </div>
                                <div>
                                    <label>
                                        <span>Fecha expiración (MM/YYYY)</span>
                                        <input size="2" data-culqi="card[exp_month]" id="card[exp_month]">
                                        <span>/</span>
                                        <input size="4" data-culqi="card[exp_year]" id="card[exp_year]">
                                    </label>
                                </div>

                            </div>
                        </div>
                        <asp:Button ID="btnPagar" runat="server" CssClass="btn btn-sm btn-primary pull-right recuperar ladda-button" Text="Realizar Pago" />
                    </div>
                </div>
            </div>
        </div>--%>
    </form>
    <style>
        @media (max-width: 1000px) {
            div .links {
                width: 100%;
                height: 106px;
                font-size: 10px;
            }

            #btnflex {
                display: flex;
                min-height: 0px;
            }

            div .links div .separadorbarra {
                margin: 0px auto;
                width: 90px;
                font-size: 11px;
                padding-left: 5px;
                padding-right: 5px;
            }

            .img-responsive {
            }

            .test {
                padding-left: 14px;
                padding-right: 0px;
            }

            .test3 {
                padding-left: 2px !important;
                padding-right: 2px !important;
            }

            div .test2 {
                padding-left: 6px !important;
                padding-right: 6px !important;
                width: 50px !important;
            }

            .imgofivir {
                width: 80px;
                margin: 0px;
                padding: 0px;
            }

            .height {
                height: 30px !important;
            }

            .csspay {
                width: 37px !important;
            }

            .row div div .css1 {
                padding: 0px !important;
                width: 40px;
            }

            .footer-fondo {
                width: 110%;
            }
        }
    </style>

    <div class="cont">
        <div class="balloon">
            <div class="datos">
                <span></span>
                <span></span>
            </div>
        </div>
        <div class="string left"></div>
        <div class="string right"></div>
        <div class="basket"></div>
        <div class="sun"></div>
        <div class="cloud bottom-right"></div>
        <div class="cloud top-right"></div>
        <div class="cloud bottom-left"></div>
    </div>







    <asp:Panel runat="server" ID="modalCara"
        class="modal responsive"
        Style="padding-top: 45px; display: block; background-color: rgba(0, 0, 0, 0.46); margin: auto; height: 100%; width: 100%; display: block !important"
        aria-hidden="true">

        <div id="mcontent" class="modal-content" style="height: 82%; margin: 0 auto; padding: 0 !important; width: 100%; max-width: 558px; padding-right: 0px !important;box-shadow: none;
    border: none;
    background-color: #00000040;">
            <span
                class="close" data-dismiss="modal" style="font-size: 38px;margin-right: 17px;">×</span>
            <asp:Panel runat="server" ID="costadosvacios" class="modal-header responsive" style="border-bottom: 0px solid #e5e5e5;">
            </asp:Panel>
            <div class="modal-body">
                <asp:Image ID="BannerHistoryRange" ImageUrl="#" runat="server" Style="width: 100%; height: 100%;" />
            </div>
        </div>
    </asp:Panel>



    <script>
        var modal2 = document.getElementById('modalCara');
        var costados = document.getElementById('costadosvacios');
        window.onload = function () {

            var btn = document.getElementById("myBtn");
            var span = document.getElementsByClassName("close")[0];
            var cont = document.getElementById("mcontent");

            //modal2.onclick = function () {
            //    modal2.style.display = "none";
            //}
            span.onclick = function () {
                 modal2.style.display = "none";
            }

        }
    </script>


    <div class="cont" style="clear: both; float: left;">
        <div class="balloon">
            <div class="datos" id="glob">
            </div>
        </div>
        <div class="string left"></div>
        <div class="string right"></div>
        <div class="basket"></div>
        <div class="sun"></div>
        <div class="cloud bottom-right"></div>
        <div class="cloud top-right"></div>
        <div class="cloud bottom-left"></div>
    </div>
    <script type="text/javascript">
        let curentRangej = parseFloat(document.getElementById('TotalRangeCurrent').innerHTML);
        if (curentRangej == 0) {
            document.getElementById('currenttr').style.display = "none";
            document.getElementById('currenttr2').style.display = "none";
            document.getElementById('currenttr3').style.display = "none";
        }

        
        let curentRangeja = parseFloat(document.getElementById('TotalResidualc').innerHTML);
        if (curentRangeja == 0) {
            document.getElementById('currenttrr').style.display = "none";
            document.getElementById('currenttr2r').style.display = "none";
            document.getElementById('currenttr3r').style.display = "none";
        }
    </script>


    <script>
        //$('#mcontent').modal("show");
        //var remove = document.getElementsByClassName("modal-backdrop in");
        //remove[0].style.display = "none";
        //document.getElementsByTagName("html")[0].style.overflow = "show";
        //document.getElementsByTagName("html")[0].style.overflow = " ";


        //let bo = document.getElementsByTagName("body");
        //bo[0].className = "top-navigation pace-done";


        //remove[0].addEventListener("click", function () {
        //    remove[0].style.display = "none";
        //})

    </script>
    <script>
        //$("#fm-modal-grid").modal("show");
    </script>
    
</body>
</html>
