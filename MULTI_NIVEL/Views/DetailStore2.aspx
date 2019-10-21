<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailStore2.aspx.cs" Inherits="MULTI_NIVEL.Views.DetailStore2" %>

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

    <script src="Script/Script.js"></script>
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
                                                    <asp:LinkButton ID="lblSalir" runat="server" OnClick="lblSalir_Click" CssClass="btn btn-primary block" Text="Salir"></asp:LinkButton>
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
                                                        <img src="tienda_files/nuevo.png" class="img-responsive center-block" border="0">Nuevo Socio</a>
                                                </div>

                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Red.aspx">
                                                        <img src="tienda_files/redes.png" class="img-responsive center-block" border="0">Árbol de patrocinio</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Commissions.aspx">
                                                        <img src="tienda_files/comisiones.png" class="img-responsive center-block" border="0">Mis comisiones</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="payments.aspx">
                                                        <img src="../Resources/Images/Payments.png" class="img-responsive center-block" border="0">Mis Pagos</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Store.aspx">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0">Tienda</a>
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
                                        <li class="breadcrumb-item">Detalle</li>

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
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Register.aspx">
                                                        <img src="tienda_files/nuevo.png" class="img-responsive center-block" border="0">Nuevo Socio</a>
                                                </div>

                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Red.aspx">
                                                        <img src="tienda_files/redes.png" class="img-responsive center-block" border="0">Árbol de patrocinio</a>
                                                </div>
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Commissions.aspx">
                                                        <img src="tienda_files/comisiones.png" class="img-responsive center-block" border="0">Mis comisiones</a>
                                                </div>
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Payments.aspx">
                                                        <img src="../Resources/Images/Payments.png" class="img-responsive center-block" border="0">
                                                        Mis Pagos</a>
                                                </div>
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Store.aspx">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0">Tienda</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <ul class="list-group categoria-tienda">
                                        <%--<li class="list-group-item subrayar">MIS PAQUETES</li>
                                    <li class="list-group-item subrayar">CATEGORÍAS</li>
                                  <li class="list-group-item"><a href="">General</a></li>--%>
                                    </ul>
                                </div>



                                <div class="col-md-5">
                                    <div class="row sombra">

                                        <div class="col-md-12">
                                            <h4>Datos</h4>
                                            <hr>
                                        </div>

                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Fecha de Adquisicion </label>
                                                <asp:Label ID="fAdqui" runat="server" class="form-control input-sm capitalize"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Nombre del Beneficiario </label>
                                                <asp:TextBox ID="TextName" runat="server" class="form-control input-sm capitalize" required="" aria-required="true" type="text"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextName" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="col-md-5 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Número de Adultos</label>
                                                <asp:DropDownList ID="TextCant1" runat="server" onChange="cambiazo()" class="form-control input-sm capitalize" required="" aria-required="true">
                                                    <asp:ListItem Value="0" Selected="True">Seleccione...</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-5 ">
                                            <div class="form-group">
                                                <label>Numero de Niños</label>
                                                <asp:DropDownList ID="TextCant2" runat="server" onChange="cambiazo()" class="form-control input-sm capitalize" required="" aria-required="true" type="text">
                                                    <asp:ListItem Value="0" Selected="True">Seleccione...</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                        </div>

                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Vigencia</label>
                                                <asp:Label ID="TxtVig" runat="server" class="form-control input-sm capitalize" type="text"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 ">
                                            <center>
                                               <asp:Label ID="lblErrorSi" runat="server" ForeColor="Blue" />
                                          </center>
                                        </div>
                                        <div class="col-md-12 col-md-offset-1">
                                            <div class="form-group">
                                                <span id="isSpan" style="color: red"></span>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <p></p>
                                    <span></span>
                                    <p></p>
                                </div>
                                <div class="col-md-4">
                                    <div class="">

                                        <div class="box_border m-b-md" id="prodnom" style="box-shadow: 4px 4px 12px black;">
                                            <div class="col-md-12 col-sm-4 noproducto" data-id="80">
                                                <div class="ibox-content text-center no-border">
                                                    <div class="m-b-sm text-center">
                                                        <asp:Image ID="Image1" runat="server" Width="240px" ImageAlign="TextTop" />
                                                    </div>

                                                    <center>
                                                        <asp:Label ID="titulo1" runat="server" class="">
                                                        
                                                        </asp:Label>
                                                        <br><br>
                                                        <div class="contenedor col-md-12">   
                                                            <div class="cabeza row">   
                                                                <asp:Label class="col-md-4" text="" runat="server" />
                                                                <asp:Label class="col-md-4" text="Cantidad" runat="server" />
                                                                <asp:Label class="col-md-4" text="Precio" runat="server" />
                                                            </div>
                                                            <div class="primerrow row">   
                                                                <asp:Label ID="tipo1" runat="server" class="col-md-4" style="text-align: left;">
                                                                        Adulto
                                                                </asp:Label>
                                                                 <asp:Label ID="canti1" runat="server" class="col-md-4">
                                                        
                                                                </asp:Label>
                                                                <asp:Label ID="precio1" runat="server" class="col-md-4">
                                                        
                                                                </asp:Label>
                                                            </div>
                                                            <div class="primerrow row">   
                                                                <asp:Label ID="tipo2" runat="server" class="col-md-4" style="text-align: left;">
                                                                        Niño
                                                                </asp:Label>
                                                                <asp:Label ID="canti2" runat="server" class="col-md-4">
                                                        
                                                                </asp:Label>
                                                                <asp:Label ID="precio2" runat="server" class="col-md-4">
                                                        
                                                                </asp:Label>

                                                            </div>

                                                            <div class="primerrow row">   
                                                                <asp:Label ID="tipo3" runat="server" class="col-md-4" style="text-align: left;">
                                                                        Niño
                                                                </asp:Label>
                                                                <asp:Label ID="canti3" runat="server" class="col-md-4">
                                                        
                                                                </asp:Label>
                                                                <asp:Label ID="precio3" runat="server" class="col-md-4">
                                                        
                                                                </asp:Label>

                                                            </div>

                                                            <hr style="margin-top: 12px;margin-bottom: 12px;" />
                                                             <div class="ultimarow row">   
                                                                <asp:Label ID="Label1" runat="server" class="col-md-4" style="text-align: left;">
                                                                        Total
                                                                </asp:Label>
                                                                <asp:Label ID="sumaCanti" runat="server" class="col-md-4">
                                                                        
                                                                </asp:Label>
                                                                <asp:Label ID="sumatotal" runat="server" class="col-md-4">
                                                        
                                                                </asp:Label>

                                                            </div>
                                                            </div>
                                                       </center>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <asp:Label runat="server" Style="display: none;" ID="valorId"> 

                            </asp:Label>

                            <div class="ibox-content" style="margin-left: -18px; margin-right: -18px; margin-top: 30px;">
                                <div class="row sombra">
                                    <div class="col-md-6">

                                        <center>
                                            <button type="button" id="myBtn" onclick="ShowModal()"
                                                    style="width: 76%;font-weight: bold;height: 40px;"
                                                    class="btn btn-xl btn-primary m-t-n-xs plomo" >COMPRAR
                                            </button>
                                        </center>
                                    </div>
                                    <div class="col-md-6">

                                        <center>
                                                <a href="Store.aspx"  class="btn btn-sm btn-primary m-t-n-xs plomo" 
                                                style="padding: 8px 40px; width: 76%;font-weight: bold;height: 40px;" >
                                                <strong>CANCELAR</strong>
                                               </a>
                                        </center>
                                    </div>

                                </div>
                                <div id="myModal" class="modal">
                                    <div class="modal-content">
                                        <span class="close" data-dismiss="modal">&times;</span>
                                        <%--<div class="modal-header">InResorts</div>--%>
                                        <div class="modal-header">
                                            <img src="img/novologo.png" alt="Alternate Text" width="100" />
                                        </div>
                                        <div class="ps">
                                            <p>Confirmación de compra -
                                                <asp:Label runat="server" ID="tituPaq"></asp:Label>
                                            </p>
                                            <p>Su información estará siendo validada</p>
                                        </div>
                                        <div class="modal-header"></div>
                                        <center>
                                           <asp:LinkButton class="btn" runat="server" onclick="btnComprar_Click" Text="Confirmar">
                                           </asp:LinkButton> <%--onclick="myPay()"--%>
                                           <button type="button"id="idCancel"  class="btn" data-dismiss="modal" >
                                               Cancelar</button> <%--onclick="myCon()"--%>
                                                    </center>
                                    </div>
                                </div>
                            </div>
                            <br/>
                            <br/>

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

    <style type="text/css">
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
            width: 90%;
            border-radius: 8px;
            font-family: sand-serif;
            font-wight: bold;
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
            height: 50px;
            text-align: center;
            font-size: 18px;
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            margin: 10px;
            margin-top: 20px;
            padding: 10px;
            font-weight: 600;
            border-radius: 6px;
            line-height: 1.3333333;
            background-color: #337ab7;
            border-color: #337ab7;
            color: white;
            cursor: pointer;
        }

            .btn:hover {
                background-color: rgb(40,96,144);
                color: white;
            }

        .ps {
            text-align: center;
            margin: 25px;
            font-size: 24px;
            color: #337ab7;
        }
    </style>
    <script type="text/javascript">

        function cambiazo() {
            var t1 = 0;
            var t2 = 0;
            var padulto;
            var pniño;
            var valorId = getParameterByName("id");
            //var valorId = document.getElementById("valorId").value;
            if (valorId == 'c1') {
                //full day
                var padulto = 20;
                var pniño = 15;
            }
            if (valorId == 'c2') {
                //camping
                var padulto = 35;
                var pniño = 25;
            }
             if (valorId == 'c3') {
                //camping
                var padulto = 35;
                var pniño = 25;
            }

            //document.getElementById("isSpan").style.display = "none";

            t1 = parseInt(document.getElementById("TextCant1").value);
            t2 = parseInt(document.getElementById("TextCant2").value);
            var sumacant = t1 + t2;
            var sum1 = t1 * padulto;
            var sum2 = t2 * pniño;
            var sumt = sum1 + sum2;
            document.getElementById("precio1").innerHTML = "S/." + parseInt(sum1);
            document.getElementById("precio2").innerHTML = "S/." + parseInt(sum2);

            document.getElementById("canti1").innerHTML = "" + parseInt(t1);
            document.getElementById("canti2").innerHTML = "" + parseInt(t2);

            document.getElementById("sumaCanti").innerHTML = "" + parseInt(sumacant);
            document.getElementById("sumatotal").innerHTML = "S/." + parseInt(sumt);
        }
        var modal = document.getElementById('myModal');
        var btn = document.getElementById("myBtn");
        var span = document.getElementsByClassName("close")[0];

        document.getElementById("idCancel").onclick = function () {
            modal.style.display = "none";
        }
        btn.onclick = function () {

            let nameBef = document.getElementById('TextName').value;

            if (nameBef === "") {
                document.getElementById('TextName').focus();
                return;
            }

            let adulto = CboSelectedText('TextCant1');
            let nino = CboSelectedText('TextCant2');
            let nunAdul = parseInt(adulto.value);
            let nunNino = parseInt(nino.value);

            if (nunAdul > 0 || nunNino > 0) {
                modal.style.display = "block";

            }
            else {
                document.getElementById("isSpan").innerHTML = "Debe introducir un numero de mayor a 0";
            }

        }
        span.onclick = function () {
            modal.style.display = "none";
        }
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
    </script>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</body>
</html>
