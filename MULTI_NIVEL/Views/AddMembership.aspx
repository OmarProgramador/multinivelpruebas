<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMembership.aspx.cs" Inherits="MULTI_NIVEL.Views.AddMembership" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tienda | inResorts</title>
    <link href="tienda_files/css.css" rel="stylesheet">

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
    <link href="tienda_files/style.css" rel="stylesheet">
    <link rel="stylesheet" href="tienda_files/all.css" integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp" crossorigin="anonymous">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/MyStyle.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">


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
                    <nav class="navbar navbar-static-top fixed-top" role="navigation" style="height: 75px">
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
                                                    <a href="Edit.aspx" class="btn btn-primary btn-sm block" style="background-color: black; border-radius: 8px">Cuenta</a>
                                                </p>
                                                <p class="col-md-6">
                                                    <a href="Edit.aspx" class="btn btn-primary btn-sm block" style="background-color: black; border-radius: 8px">Cambiar Clave</a>
                                                </p>
                                                <center>
						                    <p class="col-md-12">							                                                                          
						                    <a href="SignOutC.aspx" class="btn btn-primary block" style="background-color:black;border-radius:8px">Salir</a>
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
                            <div class="row" style="padding-top: 20px; position: relative">
                                <div class="col-md-6">
                                    <img src="../Resources/Images/shop3.svg" class="logo-seccion" align="left">
                                    <h2 class="green"><b>Tienda</b></h2>
                                    <ol class="breadcrumb">
                                        <li class="breadcrumb-item active"><a href="AddMembership.aspx">Paquetes</a></li>
                                        <li class="breadcrumb-item "><a href="Store.aspx">Servicios</a></li>
                                        <%--                                    <li class="breadcrumb-item"><a href="TravelBenefits.aspx">Beneficios de Viajes</a></li>--%>
                                        <li class="breadcrumb-item"><a href="Eagency.aspx">E-agencias</a></li>
                                        <li class="breadcrumb-item"><a href="HistorialCompras.aspx">Mis Compras</a></li>
                                        <li class="breadcrumb-item"><a href="traveling.aspx">Viajes</a></li>
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
                                                    <a href="Tools.aspx">
                                                        <img src="img/avion.png" class="img-responsive center-block height">Sistema Educativo</a>
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
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0" />Tienda
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">

                                <div id="collapse2" class="panel-collapse  ">

                                    <div class="panel-body" style="margin-right: 20px; margin-left: -25px;">
                                        <asp:Panel runat="server" ID="pnlExonerar" Style="display: none">
                                            <asp:CheckBox ID="isExonerar" Text="Codigo para Exonerar" runat="server" />

                                            <asp:TextBox ID="txtContaExonerar" runat="server" />

                                        </asp:Panel>
                                        <div class="ibox-content">
                                            <div class="row sombra">
                                                <div class="col-sm-12">
                                                    <h2>¿Que Deseas Hacer?</h2>

                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="sale-option">
                                                        <div class="radio-item">
                                                            <asp:RadioButton ID="rbnNewPackage" Text="Comprar Nuevo Paquete" GroupName="option" runat="server" Checked />

                                                        </div>
                                                        <div class="radio-item">
                                                            <asp:RadioButton ID="rbUpgrade" Text="Upgrade mi Membresia" GroupName="option" runat="server" />
                                                            <asp:DropDownList ID="ddlMysMembership" CssClass="ddl" runat="server"></asp:DropDownList>
                                                            <span id="lblAmountUpgrade"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="text-center">
                                                        <asp:Label ID="lblMessagge" Text="" runat="server" class="mensaje-error" />
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <h3>LISTADO DE PAQUETES</h3>
                                                    <hr>
                                                </div>

                                                <div id="divStarterKithh" class="row minimalSpacing">
                                                    <div class="col-md-12">
                                                        <div class="table-responsive" style="background-color: rgba(159, 176, 202, 1)">

                                                            <table class="table GridView " cellspacing="0" cellpadding="4" align="Center" rules="all" border="1" id="dgStarterKit" style="background-color: #EEEEEE; border-style: None; font-family: Verdana; font-size: 10pt; width: 100%; border-collapse: collapse;">
                                                                <tbody>
                                                                    <tr class="GridViewHeaderRow">
                                                                        <td></td>
                                                                        <td>Nombre del producto</td>

                                                                        <td>Descripción</td>
                                                                        <td>Precio</td>
                                                                        <td>Inicial</td>
                                                                    </tr>
                                                                    <tr id="">
                                                                        <td>
                                                                            <center> 
                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtSby" onchange="veamos()" value="1" Checked></asp:RadioButton>
                                                                            </center>
                                                                            <label for="packafiliaTp"></label>
                                                                        </td>

                                                                        <td style="width: 125px;">

                                                                            <div class="td mov">Stand By</div>
                                                                        </td>

                                                                        <td align="left" style="width: 550px;">
                                                                            <ul>
                                                                                <li># Cuotas Maximas 
                                                           <asp:TextBox ID="txtNumCuSby" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                </li>
                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialSby" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                    en 
                                                                        <asp:TextBox ID="txtQuotesInitialSby" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    pagos(s)
                                                                                                   
                                                                                </li>
                                                                                <li>Puntos Ganados 832 </li>
                                                                            </ul>
                                                                        </td>
                                                                        <td style="width: 100px;">

                                                                            <asp:Label runat="server" ID="lblMontoTotalSby"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 50px;">

                                                                            <asp:Label runat="server" ID="lblMontoInicialSby"></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                    <tr id="memVacacional">
                                                                        <td>
                                                                            <center> 
                                                                                <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtMd" onchange="veamos()" value="2"></asp:RadioButton>
                                                                             </center>
                                                                            <label for="packafiliaTp"></label>
                                                                        </td>

                                                                        <td style="width: 125px;">

                                                                            <div class="td mov">Expedition</div>
                                                                        </td>

                                                                        <td align="left" style="width: 550px;">
                                                                            <ul>
                                                                                <li>Programa Vacacional 5</li>
                                                                                <li># Cuotas Maximas 
                                                                     <asp:TextBox ID="txtNumCuMd" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                </li>
                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialMd" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                    en 
                                                                        <asp:TextBox ID="txtQuotesInitialMd" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    pagos(s)
                                                                                                   
                                                                                </li>
                                                                                <li>Puntos Ganados 832 </li>
                                                                            </ul>
                                                                        </td>
                                                                        <td style="width: 100px;">

                                                                            <asp:Label runat="server" ID="lblMontoTotalMd"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 50px;">

                                                                            <asp:Label runat="server" ID="lblMontoInicialMd"></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                    <tr id="fds">
                                                                        <td>
                                                                            <center> 
                                                                                <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtEvol" onchange="veamos()" value="3"></asp:RadioButton>
                                                                                </center>
                                                                            <label for="packafiliaTp"></label>
                                                                        </td>

                                                                        <td style="width: 125px;">

                                                                            <div class="td mov">Evolution</div>
                                                                        </td>

                                                                        <td align="left" style="width: 550px;">
                                                                            <ul>
                                                                                <li>Programa Vacacional 10</li>
                                                                                <li>Club 3</li>
                                                                                <li># Cuotas Maximas 
                                                           <asp:TextBox ID="txtNumCuEvol" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                </li>
                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialEvol" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                    en 
                                                                        <asp:TextBox ID="txtQuotesInitialEvol" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    pagos(s)
                                                                                                   
                                                                                </li>
                                                                                <li>Puntos Ganados 832 </li>
                                                                            </ul>
                                                                        </td>
                                                                        <td style="width: 100px;">

                                                                            <asp:Label runat="server" ID="lblMontoTotalEvol"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 50px;">

                                                                            <asp:Label runat="server" ID="lblMontoInicialEvol"></asp:Label>
                                                                        </td>
                                                                    </tr>


                                                                    <tr style="">
                                                                        <td style="width: 45px;">
                                                                            <center> 
                                                                                <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtExp" value="4"></asp:RadioButton>
                                                                           </center> 
                                                                            <label for="packafiliaEx"></label>
                                                                        </td>
                                                                        <td style="width: 125px;">
                                                                            <div class="td mov">Experience</div>
                                                                        </td>

                                                                        <td align="left" style="width: 550px;">
                                                                            <ul>
                                                                                <li>Programa Vacacional 2 años</li>
                                                                                <li>Club Resort 2</li>
                                                                                <li># Acciones 1</li>
                                                                                <li># Cuotas Maximas 
                                                                                   <asp:TextBox ID="txtNumCuEXP" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                </li>
                                                                                <li>Inicial $
                                                                                                    <asp:TextBox ID="txtInitialEXP" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    <div style="display: none">
                                                                                        en 
                                                                                                        <asp:TextBox ID="textPag1" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                        pagos(s)
                                                                                    </div>

                                                                                </li>
                                                                                <li>Puntos Ganados 111</li>
                                                                            </ul>
                                                                        </td>
                                                                        <td style="width: 100px;">
                                                                            <asp:Label runat="server" ID="montototalexp"></asp:Label>
                                                                            <label for="rbUpgrade">Upgrade: +$100</label>
                                                                        </td>
                                                                        <td style="width: 50px;">
                                                                            <asp:Label runat="server" ID="montoinicialexp"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="">
                                                                        <td>
                                                                            <center> 
                                                                             <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtLight" value="5"></asp:RadioButton>
                                                                            </center> 
                                                                            <label for="packafiliaLt"></label>
                                                                        </td>
                                                                        <td style="width: 125px;">LIGHT </td>

                                                                        <td align="left" style="width: 550px;">
                                                                            <ul>
                                                                                <li>Programa Vacacional 4 años</li>
                                                                                <li>Club Resort 4</li>
                                                                                <li># Acciones 2</li>
                                                                                <li># Cuotas Maximas  
                                                                           <asp:TextBox ID="txtNumCuLigh" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                </li>
                                                                                <li>Inicial $
                                                                            <asp:TextBox ID="txtInitialLigh" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                    en 
                                                                        <asp:TextBox ID="txtLghQuantityInicial" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    pagos(s)
                                                                                   
                                                                                </li>
                                                                                <li>Puntos Ganados 277</li>
                                                                            </ul>
                                                                        </td>
                                                                        <td style="width: 100px;">

                                                                            <asp:Label runat="server" ID="montototallig"></asp:Label>
                                                                            <label for="rbUpgrade">Upgrade: +$100</label>
                                                                        </td>
                                                                        <td style="width: 50px;">

                                                                            <asp:Label runat="server" ID="montoiniciallig"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="">
                                                                        <td>
                                                                            <center> 
                                                                                <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtStd" value="6"></asp:RadioButton>
                                                                            </center> 
                                                                            <label for="packafiliaSt"></label>

                                                                        </td>

                                                                        <td style="width: 125px;">STANDARD </td>

                                                                        <td align="left" style="width: 550px;">
                                                                            <ul>
                                                                                <li>Programa Vacacional 7 años</li>
                                                                                <li>Club Resort 7</li>
                                                                                <li># Acciones 3</li>
                                                                                <li># Cuotas Maximas 
                                                              <asp:TextBox ID="txtNumCuSTA" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                </li>
                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialSTA" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                    en 
                                                                        <asp:TextBox ID="txtStaQuantityInicial" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    pagos(s)
                                                                                    

                                                                                </li>
                                                                                <li>Puntos Ganados 416</li>
                                                                            </ul>
                                                                        </td>
                                                                        <td style="width: 100px;">

                                                                            <asp:Label runat="server" ID="montototalsta"></asp:Label>
                                                                            <label for="rbUpgrade">Upgrade: +$100</label>
                                                                        </td>
                                                                        <td style="width: 50px;">
                                                                            <asp:Label runat="server" ID="montoinicialsta"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display:none">
                                                                        <td>
                                                                            <center> 
                                                                             <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtPlus" value="7"></asp:RadioButton>
                                                                            </center> 
                                                                            <label for="packafiliaPl"></label>
                                                                        </td>
                                                                        <td style="width: 125px;">PLUS </td>

                                                                        <td align="left" style="width: 550px;">
                                                                            <ul>
                                                                                <li>Programa Vacacional 10 años</li>
                                                                                <li>Club Resort 10</li>
                                                                                <li># Acciones 4</li>
                                                                                <li># Cuotas Maximas 
                                                                            <asp:TextBox ID="txtNumCuPLU" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                </li>
                                                                                <li>Inicial $
                                                                             <asp:TextBox ID="txtInitialPLU" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    en 
                                                                            <asp:TextBox ID="txtPlusQuantityInicial" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    pagos(s)
                                                                                </li>
                                                                                <li>Puntos Ganados 554</li>
                                                                            </ul>
                                                                        </td>
                                                                        <td style="width: 100px;">
                                                                            <asp:Label runat="server" ID="montototalplu"></asp:Label>
                                                                            <label for="rbUpgrade">Upgrade: +$100</label>
                                                                        </td>
                                                                        <td style="width: 50px;">

                                                                            <asp:Label runat="server" ID="montoinicialplu"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="">
                                                                        <td>
                                                                            <center> 
                                                                             <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtTop" value="8"></asp:RadioButton>
                                                                             </center> 
                                                                            <label for="packafiliaTp"></label>
                                                                        </td>

                                                                        <td style="width: 125px;">TOP </td>

                                                                        <td align="left" style="width: 550px;">
                                                                            <ul>
                                                                                <li>Programa Vacacional 10 años</li>
                                                                                <li>Club Resort 10</li>
                                                                                <li># Acciones 6</li>
                                                                                <li># Cuotas Maximas 
                                                           <asp:TextBox ID="txtNumCuTOP" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                </li>
                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialTOP" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    en 
                                                                        <asp:TextBox ID="txtTopQuantityInicial" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    pagos(s)
                                                                                </li>
                                                                                <li>Puntos Ganados 832 </li>
                                                                            </ul>
                                                                        </td>
                                                                        <td style="width: 100px;">

                                                                            <asp:Label runat="server" ID="montototaltop"></asp:Label>
                                                                            <label for="rbUpgrade">Upgrade: +$100</label>
                                                                        </td>
                                                                        <td style="width: 50px;">

                                                                            <asp:Label runat="server" ID="montoinicialtop"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="">
                                                                        <td>
                                                                            <center> 
                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtVit" value="9"></asp:RadioButton>
                                                                                </center> 
                                                                            <label for="packafiliaTp"></label>
                                                                        </td>

                                                                        <td style="width: 125px;">VITALICIA </td>

                                                                        <td align="left" style="width: 550px;">
                                                                            <ul>
                                                                                <li>Programa Vacacional 10 años</li>
                                                                                <li>Club Resort vitalicio</li>
                                                                                <li># Acciones 6</li>
                                                                                <li># Cuotas Maximas 
                                                           <asp:TextBox ID="txtNumCuVit" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                </li>
                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialVit" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    en 
                                                                        <asp:TextBox ID="txtVitQuantityInicial" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                    pagos(s)
                                                                                </li>
                                                                                <li>Puntos Ganados 832 </li>
                                                                            </ul>
                                                                        </td>
                                                                        <td style="width: 100px;">

                                                                            <asp:Label runat="server" ID="montototalVit"></asp:Label>
                                                                            <label for="rbUpgrade">Upgrade: +$100</label>
                                                                        </td>
                                                                        <td style="width: 50px;">

                                                                            <asp:Label runat="server" ID="montoinicialVit"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-left: 5px;">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <asp:CheckBox ID="cbCodPromocional" Text="¿Tienes Codigo promocional?" runat="server" />
                                                                <asp:TextBox ID="txtCodPromocional" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="display: none">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <asp:CheckBox ID="cbxPred" Text="¿Quieres que esta membresia sea tu membresia predeterminada?" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row" style="margin-left: 5px;">
                                                        <div class="col-sm-12">
                                                            <input type="button" id="btnVerificar" value="Verificar" class="btn btn-primary" />
                                                            <label id="lblMessaggeVerif" class="mensaje-error"></label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                            <div class="accordion" id="accordionExample">
                                                                <div class="card">
                                                                    <div class="card-header" id="headingOne">
                                                                        <h5 class="mb-0">
                                                                            <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                                                                Configuracion Avanzada
                                                                            </button>
                                                                        </h5>
                                                                    </div>
                                                                    <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordionExample" style="margin-left: 20px;">
                                                                        <div class="card-body">                                                                            
                                                                            <div class="row">
                                                                                <div class="col-sm-12">
                                                                                    <asp:CheckBox ID="cbConfig" Text="Editar" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-sm-12">
                                                                                    <label>Dia de Pago de las cuotas :</label>
                                                                                    <asp:DropDownList ID="ddlDateCuotas" runat="server">
                                                                                        <asp:ListItem Value="" Text="--Seleccionar--" />
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-lg-12">
                                                                                    <hr />
                                                                                    <div class="col-sm-6">
                                                                                        <label>
                                                                                            Codigo:                                                                                                     
                                                                                                <asp:TextBox name="txtCodSecreto" ID="txtCodSecreto" class="form-control m-b" value="" runat="server" />
                                                                                        </label>
                                                                                        <input type="button" id="btnCodSecreto" class="btn btn-outline-primary" value="VALIDAR" />
                                                                                    </div>
                                                                                    <div class="col-sm-6">
                                                                                        <!--<label>Codigo Secreto</label>-->
                                                                                        <label id="lblResponseCod" style="color: red;"></label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="display-none" id="DivFrac">
                                                                                <div class="row">
                                                                                    <div class="col-lg-12">
                                                                                        <h2>Fraccionar en Cuotas </h2>
                                                                                        <hr />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-lg-12">
                                                                                        <label>
                                                                                            Valor de Cuota Inicial
                                                                                            <input id="ValueTotal" type="text" name="name" value="" />
                                                                                        </label>
                                                                                        <label>
                                                                                            en
                                                                                                <input id="NumQuotes" type="text" name="name" value="" />Cuotas</label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-lg-4">
                                                                                        <div class="form-group">
                                                                                            <label>Cuota N° 1</label>
                                                                                            <!-- <input type="text" name="name" value="" onkeyup />-->
                                                                                            <asp:TextBox ID="QuoteFirts" runat="server" CssClass="form-control" placeholder="0.00" Text="0" onkeyup="CalculateQuotes();" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-lg-4">
                                                                                        <div class="form-group">
                                                                                            <label>Cuota N° 2</label>
                                                                                            <asp:TextBox ID="QuoteSecond" runat="server" CssClass="form-control" placeholder="0.00" Text="0" onkeyup="CalculateQuotes();" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-lg-4">
                                                                                        <div class="form-group">
                                                                                            <label>Cuota N° 3</label>
                                                                                            <asp:TextBox ID="QuoteThird" runat="server" CssClass="form-control" Text="0.00" placeholder="0.00" />
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-lg-4">
                                                                                        <div class="form-group">
                                                                                            <div class="input-group date" data-provide="datepicker">
                                                                                                <span class="input-group-addon" style=""><i class="fa fa-calendar-alt" style=""></i></span>
                                                                                                <asp:TextBox ID="DateFirts" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" MaxLength="10" />
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-lg-4">
                                                                                        <div class="form-group">
                                                                                            <div class="input-group date" data-provide="datepicker">
                                                                                                <span class="input-group-addon" style=""><i class="fa fa-calendar-alt" style=""></i></span>
                                                                                                <asp:TextBox ID="DateSecond" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" />
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-lg-4">
                                                                                        <div class="form-group">
                                                                                            <div class="input-group date" data-provide="datepicker">
                                                                                                <span class="input-group-addon" style=""><i class="fa fa-calendar-alt" style=""></i></span>
                                                                                                <asp:TextBox ID="DateThird" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" />
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
                                                    <div class="col-sm-12">
                                                        <br />
                                                        <center>                                           
                                                            <asp:Button ID="btnBuy" runat="server" class="btn btn-primary" Text="Comprar" OnClick="btnBuy_Click">
                                                            </asp:Button>
                                            
                                                            <button  class="btn btn-secondary" onclick="histoy.back();return 0;">Cancelar</button>
                                                        </center>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <a id="scrollDown" href="#down" title="Scroll to down" style="position: fixed; z-index: 2147483647;"></a>
                    <script async="" defer="defer" src="tienda_files/js" type="text/javascript"></script>
                </div>
            </div>
            <a id="scrollUp" href="#top" title="Scroll to top" style="position: fixed; z-index: 2147483647; display: none;">
                <img src="img/top.png" />
            </a>
            <style>
                @media (max-width: 450px) {
                    #cssbox {
                        width: 120%;
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

                    .csspqts {
                        width: 107%;
                        margin-left: -9px;
                    }
                }
            </style>
            <script src="Script/ScriptAddMembership.js"></script>
            <script type="text/javascript">
                var groups = {};
                $("select option[data-category]").each(function () {
                    groups[$.trim($(this).attr("data-category"))] = true;
                });
                $.each(groups, function (c) {
                    $("select option[data-category='" + c + "']").wrapAll('<optgroup label="' + c + '">');
                });
            </script>
    </form>
</body>
</html>
