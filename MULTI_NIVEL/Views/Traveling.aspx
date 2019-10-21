<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Traveling.aspx.cs" Inherits="MULTI_NIVEL.Traveling" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Viajando | inResorts</title>

    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/StyleLoader.css" rel="stylesheet" />

    <link href="Css/MyStyle.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous">
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">
   
       <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
       <script src="Script/jquery.js"></script>

    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>
    <script src="Script/Script.js"></script>
    <style>
        .bg-plomo{
            background-color:#e5e5e5;
            padding:5px 20px ;
        }
    </style>
</head>
<body class="top-navigation pace-done">
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
    <!--comiit-->
    <form id="form" runat="server">
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
                    <nav class="navbar navbar-static-top" role="navigation" style="height: 75px">
                        <div class="navbar-header header-inicio">
                            <button aria-controls="navbar" aria-expanded="false" data-target="#navbar" data-toggle="collapse" class="navbar-toggle collapsed" type="button">
                                <i class="fa fa-reorder"></i>
                            </button>
                            <a href="Index.aspx" class="navbar-brand inicio-logo">
                                <img src="img/novologo.png" class="img-responsive"></a>
                        </div>
                        <div class="navbar-collapse collapse" id="navbar">
                            <ul class="nav navbar-top-links navbar-right">
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
                                                <a href="Edit.aspx" style=" margin: 0px; border-radius:5px" class="btn btn-primary btn-sm block">Cuenta</a>
                                            </p>
                                            <p class="col-md-6">
                                                <a href="Edit.aspx" style=" margin: 0px; border-radius:5px" class="btn btn-primary btn-sm block">Cambiar Clave</a>
                                            </p>
                                            <center>
						                    <p class="col-md-12">							                                                                          
						                    <a href="SignOutC.aspx" class="btn btn-primary block" style=" margin: 0px; border-radius:5px">Salir</a>
                                            </p>
						                    </center>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
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
                                            <img class="center-block img-responsive" src="img/oficinavirtualsol.png" style="margin-top: 10px; max-height: 74px" border="0" />
                                        </div>
                                        <div class="col-xs-9 menu-lateral-opciones" style="display: block">
                                            <div class="col-xs-12">
                                               <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Register.aspx">
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block" border="0" />Nuevo Socio</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra " style=" width: 20% !important">
                                                   <a href="Tools.aspx">
                                                        <img src="img/avion.png" class="img-responsive center-block height">Sistema Educativo</a>
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
                                    <img src="../Resources/Images/shop3.svg" class="logo-seccion" align="left" />
                                    <h2 class="green"><b>Viajes</b></h2>
                                    <ol class="breadcrumb negro">
                                         <li class="breadcrumb-item"><a href="AddMembership.aspx">Paquetes</a></li>
                                        <li class="breadcrumb-item "><a href="Store.aspx">Servicios</a></li>
                                        <%--                                    <li class="breadcrumb-item"><a href="TravelBenefits.aspx">Beneficios de Viajes</a></li>--%>
                                        <li class="breadcrumb-item"><a href="Eagency.aspx">E-agencias</a></li>
                                        <li class="breadcrumb-item"><a href="HistorialCompras.aspx">Mis Compras</a></li>
                                        <li class="breadcrumb-item active"><a href="traveling.aspx">Viajes</a></li>
                                    </ol>

                                </div>
                                <div class="col-md-6">
                                    <div class="linkstienda visible-md visible-lg">
                                        <div class="col-md-3" style="width: 20% !important">
                                            <!-- <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1000)">
														<img class="center-block oficinaimg" src=""	border="0" />
													</a> -->
                                            <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1)">
                                                <img class="center-block oficinaimg" src="img/oficinavirtualsol.png" border="0">
                                            </a>
                                        </div>
                                        <div class="col-md-9 menu-lateral-opciones">
                                            <div class="row">
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
                                            <a href="commissions.aspx">
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

                            <br />
                            <br />

                            <div class="container">
                                <div class="row ">
                                    <div class="col-md-4">
                                        <a href="travelagency.aspx">
                                            <h4 style="text-align: center;margin: 15px;">Agencia de Viajes</h4>
                                        </a>
                                        <div class="textwidget">
                                            <a href="TravelBenefits.aspx">
                                                <img src="img/agencia.png" style="margin: 0 auto;text-align: center;display: block;width: 100%;">
                                            </a>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <a target="_blank" href="https://viveahoratravel.com">
                                        <h4 style="text-align: center;margin: 15px;">Vive Ahora Travel</h4>
                                    </a>
                                    <div class="textwidget">
                                        <a target="_blank"href="https://viveahoratravel.com">
                                            <img src="img/viveahora.jpg" style="margin: 0 auto;text-align: center;display: block;height: 210px;">
                                        </a>
                                    </div>
                                    </div>
                                    <div class="col-md-4">
                                        <a target="_blank" href="https://bookings.igo4less.com/">
                                        <h4 style="text-align: center;margin: 15px;">Travel Benefits</h4>
                                    </a>
                                    <div class="textwidget">
                                        <a href="https://bookings.igo4less.com/">
                                            <img src="img/logotravel.jpg" style="width:350px;margin: 0 auto;text-align: center;display: block;width: 100%;">
                                        </a>
                                    </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                
                <style>
                    @media (max-width:800px){
                        .a1{
                            font-size:15px;
                        }
                        .a2{
                           padding-left:0px;
                        }
                    }
                </style>





                <div class="footer footer-fondo">
                    <strong>inResorts - 2018</strong>
                </div>
            </div>
        </div>
        <a id="scrollUp" href="#top" title="Scroll to top" style="position: fixed; z-index: 2147483647; display: none;"></a>

    </form>
    <style>
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
            max-width: 500px;
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
            color: #000;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: red;
                text-decoration: none;
                cursor: pointer;
            }

        .btn {
                height: 35px;
                text-align: center;
                font-size: 15px;
                font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
                margin: 10px;
                margin-top: 0px;
                padding: 8px;
                font-weight: 600;
                border-radius: 5px;
                line-height: 1.3333333;
                background-color: black;
                cursor: pointer;
        }

         .btn:hover {
               opacity:0.7;
         }

        .ps {
            text-align: center;
            margin: 25px;
            font-size: 20px;
            color: #337ab7;
        }
    </style>
 
</body>
</html>
