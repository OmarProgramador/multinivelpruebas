<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="MULTI_NIVEL.Views.Store" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tienda | inResorts</title>
    <link href="tienda_files/css.css" rel="stylesheet">
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
    <link href="tienda_files/style.css" rel="stylesheet">
    <link rel="stylesheet" href="tienda_files/all.css" integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp" crossorigin="anonymous">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
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

    <script>
        var base_url = ' ';
        var idsocio = 168;
        var idopera = 1;
        var nombresocio = 'Luis Alberto Ccayo';
        var direcsocio = 'Calle Hermilio Valdizan Block M Dpto 402';
        var rango = '2K';
        var simbolo = 'S/.';
        var csrfsn = '356fc2188a3c86b823193761459a4da3';
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
                                                <div class="col-xs-3 separadorbarra " style=" width: 20% !important">
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
                                    <img src="../Resources/Images/shop3.svg" class="logo-seccion" align="left">
                                    <h2 class="green"><b>Tienda</b></h2>
                                    <ol class="breadcrumb negro">
                                        <li class="breadcrumb-item"><a href="AddMembership.aspx">Paquetes</a></li>
                                        <li class="breadcrumb-item active"><a href="Store.aspx">Servicios</a></li>
                                        <%--<li class="breadcrumb-item "><a href="TravelBenefits.aspx">Beneficios de Viajes</a></li>--%>
                                        <li class="breadcrumb-item "><a href="Eagency.aspx">E-agencias</a></li>
                                        <li class="breadcrumb-item "><a href="HistorialCompras.aspx">Mis Compras</a></li>
                                        <li class="breadcrumb-item "><a href="traveling.aspx">Viajes</a></li>
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
                                <div class="col-md-1">
                                    <ul class="list-group categoria-tienda">
                                 
                                    </ul>
                                </div>
                                <div class="col-md-8">
                                    <div class="btn-group btn-group-justified m-b-md group-tienda" role="group" aria-label="...">
                                    </div>

                                   <%--<%-- <h3>Vacacionales
                                    </h3>
                                    <div class="box_border m-b-md" id="prodnom">
                                        <div class="col-md-4 col-sm-4 noproducto" data-id="80" data-name="">
                                            <div class="ibox-content text-center no-border">
                                                <p class="font-bold contprod">
                                                    <span class=""><b>Paquete vacacional</b></span><br>
                                                   
                                                </p>
                                                <div class="m-b-sm text-center">
                                                    <img class="img-responsive fotoprod" src="img/collage5.png">
                                                </div>
                                                
                                                
                                                 <a href="DetailStore.aspx?id=v1">
                                                <button name="btnAgregar" data-id="80" data-tipo="2" 
                                                    class="btn btn-sm btn-primary btn-block pull-center m-t-n-xs" 
                                                    data-style="expand-right" type="button">AGREGAR</button>
                                                      </a>
                                            </div>
                                        </div>


                                        <div class="col-md-4 col-sm-4 noproducto" data-id="81" data-name="">
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
                                        </div>

                                    </div>--%>

                                    <h3>Club</h3>
                                    <div class="box_border m-b-md" id="prodnom">
                                         <div class="col-md-4 col-sm-4 noproducto" data-id="80" ">
                                            <div class="ibox-content text-center no-border">
                                                 <p class="font-bold contprod">
                                                    <span class=""><b>FullDay Todo incluido</b></span><br>
                                                    S/. xx.xx / x.xx pts.
                                                </p>
                                                <div class="m-b-sm text-center">
                                                    <img class="img-responsive fotoprod altura" src="img/fulldayTodoIncluido.png" height="auto">
                                                </div>
                                               
                                               <%-- <div class="input-group bootstrap-touchspin input-group-sm">
                                                    <input class="cantidad input-sm text-center form-control" name="cant_prod_80" style="display: block;" value="0" type="text">
                                                </div>--%>
                                                   <a href="DetailStore2.aspx?id=c3">
                                                <button name="btnAgregar" data-id="80" data-tipo="3" class="btn btn-sm btn-primary btn-block pull-center m-t-n-xs" data-style="expand-right" type="button">AGREGAR</button>
                                                       </a>
                                            </div>
                                        </div>

                                        <div class="col-md-4 col-sm-4 noproducto" data-id="80" ">
                                            <div class="ibox-content text-center no-border">
                                                 <p class="font-bold contprod">
                                                    <span class=""><b>FullDay</b></span><br>
                                                    S/. xx.xx / x.xx pts.
                                                </p>
                                                <div class="m-b-sm text-center">
                                                    <img class="img-responsive fotoprod altura" src="img/full1.jpg" height="150px">
                                                </div>
                                               
                                               <%-- <div class="input-group bootstrap-touchspin input-group-sm">
                                                    <input class="cantidad input-sm text-center form-control" name="cant_prod_80" style="display: block;" value="0" type="text">
                                                </div>--%>
                                                   <a href="DetailStore2.aspx?id=c1">
                                                <button name="btnAgregar" data-id="80" data-tipo="2" class="btn btn-sm btn-primary btn-block pull-center m-t-n-xs" data-style="expand-right" type="button">AGREGAR</button>
                                                       </a>
                                            </div>
                                        </div>


                                        <div class="col-md-4 col-sm-4 noproducto" data-id="81" data-name="">
                                            <div class="ibox-content text-center no-border">
                                                <p class="font-bold contprod">
                                                    <span class=""><b>Camping</b></span><br>
                                                    S/. xx.xx / x.xx pts.
                                                </p>
                                                <div class="m-b-sm text-center">
                                                    <img class="img-responsive fotoprod altura" src="img/camping.jpg">
                                                </div>
                                                
                                                <%--<div class="input-group bootstrap-touchspin input-group-sm">

                                                    <input class="cantidad input-sm text-center form-control" name="cant_prod_81" style="display: block;" value="0" type="text">
                                                </div>--%>
                                                <a href="DetailStore2.aspx?id=c2">
                                                <button name="btnAgregar" data-id="81" data-tipo="2"
                                                    class="btn btn-sm btn-primary btn-block pull-center m-t-n-xs" 
                                                    data-style="expand-right" type="button">AGREGAR</button> </a>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                                <style>
                                    .altura{
                                        height:150px;
                                    }
                                </style>
                                <%--</div>

                            <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label ID="lblMessagge" Text="" runat="server" ForeColor="Red" />
                                        </div>
                                    </div>

                            <div id="collapse2" class="panel-collapse  ">

                                                    <div class="panel-body" style="margin-right: 20px; margin-left: -25px;">
                                                        <asp:Panel runat="server" ID="pnlExonerar" Style="display: none">
                                                            <asp:CheckBox ID="isExonerar" Text="Codigo para Exonerar" runat="server" />

                                                            <asp:TextBox ID="txtContaExonerar" runat="server" />

                                                        </asp:Panel>
                                                        <div id="iboxcon" class="ibox-content">
                                                            <div class="row sombra">

                                                                <div class="col-md-12">
                                                                    <h4>PAQUETES DE INSCRIPCIÓN</h4>
                                                                    <hr>
                                                                </div>

                                                                <div id="divStarterKithh" class="row minimalSpacing">
                                                                    <div class="col-md-12">
                                                                        <div class="" style="background-color: rgba(159, 176, 202, 1)">
                                                                           <%-- <div class="panel-heading">
                                                                                <h2><strong><span style="color: white" id="lblStartedrKit">PAQUETES DE INSCRIPCIÓN</span></strong></h2>
                                                                            </div>
                                                                            <table class="table GridView" cellspacing="0" cellpadding="4" align="Center" rules="all" border="1" id="dgStarterKit" style="background-color: #EEEEEE; border-style: None; font-family: Verdana; font-size: 10pt; width: 100%; border-collapse: collapse;">
                                                                                <tbody>
                                                                                    <tr class="GridViewHeaderRow">
                                                                                        <td>
                                                                                            <input type="checkbox" name="name" id="cbNada" onclick="salgamos()" style="display:none"/> </td>
                                                                                        <td>Nombre del producto</td>

                                                                                        <td>Descripción</td>
                                                                                        <td>Precio</td>
                                                                                        <td>Inicial</td>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td style="width: 45px;">
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtExp" onchange="veamos()" value="2"></asp:RadioButton>


                                                                                            <label for="packafiliaEx"></label>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <div  class="td mov">Experience</div> 

                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 1</li>
                                                                                                <li>Club Resort 1</li>
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
                                                                                        </td>
                                                                                        <td style="width: 50px;">
                                                                                            <asp:Label runat="server" ID="montoinicialexp"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtLight" onchange="veamos()" value="3"></asp:RadioButton>
                                                                                            <label for="packafiliaLt"></label>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                             <div  class="td mov">LIGHT</div>
                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 3</li>
                                                                                                <li>Club Resort 3</li>
                                                                                                <li># Acciones 2</li>
                                                                                                <li># Cuotas Maximas  
                                                           <asp:TextBox ID="txtNumCuLigh" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                           <asp:TextBox ID="txtInitialLigh" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    <div style="display: none">
                                                                                                        en 
                                                                        <asp:TextBox ID="textPag2" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                        pagos(s)
                                                                                                    </div>
                                                                                                </li>
                                                                                                <li>Puntos Ganados 277</li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="montototallig"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">

                                                                                            <asp:Label runat="server" ID="montoiniciallig"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtStd" onchange="veamos()" value="4"></asp:RadioButton>
                                                                                            <label for="packafiliaSt"></label>

                                                                                        </td>

                                                                                        <td style="width: 125px;">
                                                                                           <div  class="td mov">STANDARD</div>

                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 6</li>
                                                                                                <li>Club Resort 6</li>
                                                                                                <li># Acciones 3</li>
                                                                                                <li># Cuotas Maximas 
                                                              <asp:TextBox ID="txtNumCuSTA" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialSTA" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    <div style="display: none">
                                                                                                        en 
                                                                        <asp:TextBox ID="textPag3" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                        pagos(s)
                                                                                                    </div>

                                                                                                </li>
                                                                                                <li>Puntos Ganados 416</li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="montototalsta"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">
                                                                                            <asp:Label runat="server" ID="montoinicialsta"></asp:Label>

                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtPlus" onchange="veamos()" value="5"></asp:RadioButton>
                                                                                            <label for="packafiliaPl"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">
                                                                                           <div  class="td mov">PLUS</div>

                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 10</li>
                                                                                                <li>Club Resort 10</li>
                                                                                                <li># Acciones 4</li>
                                                                                                <li># Cuotas Maximas 
                                                                            <asp:TextBox ID="txtNumCuPLU" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                                </li>
                                                                                                                <li>Inicial $
                                                                             <asp:TextBox ID="txtInitialPLU" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    en 
                                                                            <asp:TextBox ID="textPlusQuoteInitial" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    pagos(s)
                                                                                                </li>
                                                                                                <li>Puntos Ganados 554</li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="montototalplu"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">

                                                                                            <asp:Label runat="server" ID="montoinicialplu"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtTop" onchange="veamos()" value="6"></asp:RadioButton>
                                                                                            <label for="packafiliaTp"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">TOP </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional vitalicio</li>
                                                                                                <li>Club Resort vitalicio</li>
                                                                                                <li># Acciones 4</li>
                                                                                                <li># Cuotas Maximas 
                                                           <asp:TextBox ID="txtNumCuTOP" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialTOP" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    en 
                                                                        <asp:TextBox ID="txtTopCuotaInicial" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    pagos(s)
                                                                                                </li>
                                                                                                <li>Puntos Ganados 832 </li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="montototaltop"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">

                                                                                            <asp:Label runat="server" ID="montoinicialtop"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <asp:RadioButtonList ID="rdrEx" runat="server">
                                                    <asp:ListItem Text="Exonerar" Value="Exonerar"></asp:ListItem>
                                                    <asp:ListItem Text="No Exonerar" Value="NoExonerar"></asp:ListItem>
                                                </asp:RadioButtonList>      
                                --%>

                                <%-- <div class="ibox-content">
                                                <div class="row sombra">
                                                    <div class="col-md-6">
                                                        <br>
                                                        <center>
                                                                 <a href="Register.aspx"></a>
                                                                    <asp:Button ID="btnRegister" runat="server" class="btn btn-xl btn-primary m-t-n-xs plomo" Text="REGISTRAR" OnClick="btnRegister_Click">
                                                                </asp:Button>
                                                            </center>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <br>
                                                        <center>
                                                                <button  class="btn btn-sm btn-primary m-t-n-xs plomo" style="padding: 8px 40px" onclick="histoy.back();return 0;"><strong>CANCELAR</strong></button>
                                                            </center>
                                                    </div>
                                                </div>
                                            </div>

                            <div class="col-md-3">
                                <h3 class="m-xs text-center green" style="font-weight: bold; margin-bottom: 30px">RESUMEN DE LA COMPRA</h3>
                                <div class="widget navy-bg p-sm text-center m-t-none">
                                    <div class="m-b-md">
                                        <!-- Producto Carrito Compra Anterior -->
                                        <div class="items_cart_compraanterior" style="font-size: 11px"></div>
                                        <!-- Producto Carrito -->
                                        <div class="items_cart"></div>
                                        <!-- Fin de los productos seleccionados -->
                                    </div>
                                    <div class="m-b-md text-center" style="overflow: hidden;">
                                        <form action=" " class="formCart" method="post" accept-charset="utf-8">
                                            <input name="csrfsn" value="356fc2188a3c86b823193761459a4da3" type="hidden">
                                            <input name="is_favorito" id="is_favorito" value="0" type="hidden">
                                            <input name="nofavorito" id="nofavorito" value="" type="hidden">
                                            <input name="idcxs" id="idcxs" value="10864" type="hidden">
                                            <input name="entrega" id="entrega" value="" type="hidden">
                                            <input name="direcdelivery" id="direcdelivery" value="" type="hidden">
                                            <input name="tipocompra" id="tipocompra" value="2" type="hidden">
                                            <input name="nextcompra" id="nextcompra" value="0" type="hidden">
                                            <input name="comp_direcciondelivery" id="comp_direcciondelivery" value="" type="hidden">
                                            <input name="comp_referenciadelivery" id="comp_referenciadelivery" value="" type="hidden">
                                            <input name="comp_departamentodelivery" id="comp_departamentodelivery" value="" type="hidden">
                                            <input name="comp_provinciadelivery" id="comp_provinciadelivery" value="" type="hidden">
                                            <input name="comp_distritodelivery" id="comp_distritodelivery" value="" type="hidden">
                                            <hr style="margin-top: 0px;margin-bottom: 10px;">
                                            <div class="text-center totales">
                                                <div class="">
                                                    <div class="text_totalpunto"><div class="text1">TOTAL DE</div><div class="text2">PUNTOS</div></div>
                                                    <div class="monto_totalpunto"><strong><span class="total_puntos">0</span> pts</strong></div>
                                                </div>
                                            </div>
                                            <hr style="margin-top: 10px;margin-bottom: 20px;">
                                            <!-- 0: delivery / 1: tienda -->
                                            <div id="div_metodoentrega" name="div_metodoentrega" style="display:none;">
                                                <h4>Método de entrega</h4>
                                                <div class="btn-group btn-group-justified m-b-md" role="group" aria-label="...">
                                                    <div class="btn-group" role="group">
                                                        <a href="#" class="btn btn-sm btn-ControlEntrega btn-boxTienda" id="btnDelivery">Delivery</a>
                                                    </div>
                                                </div>    
                                            </div>                                            
                                            
                                            <div id="div_metodopago" name="div_metodopago" style="display:none;">
                                                <div class="text-left">
                                                    <h4>Método de pago</h4>
                                                </div>
                                                <div class="form-group text-center">
                                                    <div class="radio radio-inline">
                                                        <input name="mediopago" id="visanet" value="1" checked="checked" type="radio">
                                                        <label for="visanet">VISA</label>
                                                    </div>
                                                    <div class="radio radio-inline">
                                                        <input name="mediopago" id="transferencia" value="2" type="radio">
                                                        <label for="transferencia">Transferencia</label>
                                                    </div>
                                                    <div class="radio radio-inline">
                                                        <input name="mediopago" id="deposito" value="5" type="radio">
                                                        <label for="deposito">Depósito</label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-check text-left">
                                                <label class="form-check-label" for="inpTerminos">
                                                    <input class="form-check-input" id="inpTerminos" type="checkbox"> 
                                                    Acepto los 
                                                    <a href="#" data-toggle="modal" data-target="#mdlTerminosCondiciones">
                                                        términos y condiciones</a> de la compra.</label>
                                            </div>
                                            <button class="btn btn-sm btn-w-m btn-default pull-center btnComprar" type="button" data-toggle="modal" data-target="#mdlVerificaPago" id="btnPayCart">COMPRAR</button>
                                           <button class="btn btn-sm btn-w-m btn-warning pull-center btnComprar" type="button" data-toggle="modal" data-target="#mdlVerificaPago" id="btnSeguirComprando">SEGUIR COMPRANDO</button>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Delivery -->
            

            <!-- Locales -->
            

            <!-- Favorito -->
            <div class="modal inmodal" id="mdlFavorito" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content animated bounceInRight">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">Paquete Favorito</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form_fav">
                                <div class="">
                                    <label>Nombre del paquete favorito</label>
                                    <input name="tmpnofavorito" id="tmpnofavorito" placeholder="Ingrese el nombre del paquete favorito" class="form-control input-sm" type="text">
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-sm btn-white" data-dismiss="modal">CANCELAR</button>
                            <button type="button" class="btn btn-sm btn-primary" id="btnContinuarCompra"><strong>CONTINUAR</strong></button>
                        </div>
                    </div>
                </div>
            </div>
            <a id="scrollDown" href="#down" title="Scroll to down" style="position: fixed; z-index: 2147483647;"></a>
            <script async="" defer="defer" src="tienda_files/js" type="text/javascript"></script>
           
                                
            
            
        </div>
    </div>
    <a id="scrollUp" href="#top" title="Scroll to top" style="position: fixed; z-index: 2147483647; display: none;">
        <img src="img/top.png"/>
    </a>--%>

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
</body>
</html>
