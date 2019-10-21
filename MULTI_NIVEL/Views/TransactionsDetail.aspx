<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionsDetail.aspx.cs" Inherits="MULTI_NIVEL.Views.TransactionsDetail" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Mis Transacciones | inResorts</title>


    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/StyleLoader.css" rel="stylesheet" />

    <link href="Css/MyStyle.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://use.fontaEditarwesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <link href="tienda_files/font-awesome.css" rel="stylesheet">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous">
   
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
    <div id="divProgressBar">
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
    </div>
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
							 <asp:LinkButton ID="lblSalir" runat="server" OnClick="lblSalir_Click" CssClass="btn btn-primary block" Text="Salir"></asp:LinkButton>
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
                                            <img class="center-block img-responsive" src="img/oficinavirtualsol.png" style="margin-top: 10px; max-height: 74px" border="0">
                                        </div>
                                        <div class="col-xs-9 menu-lateral-opciones" style="display: block">
                                            <div class="col-xs-12">
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Register.aspx">
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block" border="0" />Nuevo Socio</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Red.aspx">
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Árbol de patrocinio</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Commissions.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block" border="0" />Mis comisiones</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Payments.aspx">

                                                        <img src="../Resources/Images/Payments.png" class="img-responsive center-block" border="0" />Mis Pagos</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <asp:HyperLink ID="hpStore" runat="server">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0" />Tienda
                                                    </asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 20px; position: relative">
                                <div class="col-md-6">
                                    <img src="../Resources/Images/comisiones.png" class="logo-seccion" align="left" />
                                    <h2 class="green"><b>Comisiones</b></h2>
                                    <ol class="breadcrumb negro">
                                        <li class="breadcrumb-item "><a href="Commissions.aspx" >Transacciones</a></li>
                                        <li class="breadcrumb-item active"><a href="TransactionsDetail.aspx" class="subrayar">Detalle de Transacciones</a></li>
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
                                                    <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                        <a href="Register.aspx">
                                                            <img src="../Resources/Images/nuevo.png" class="img-responsive center-block" border="0">Nuevo Socio</a>
                                                    </div>
                                                    <%-- <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                        <a href="#">
                                                            <img src="comisiones_files/tienda.png" class="img-responsive center-block" border="0">Tienda</a>
                                                    </div>--%>
                                                    <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                        <a href="Red.aspx">
                                                            <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Árbol de patrocinio</a>
                                                    </div>
                                                    <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                        <a href="Commissions.aspx">
                                                            <img src="../Resources/Images/comisiones.png" class="img-responsive center-block" border="0" />Mis comisiones</a>
                                                    </div>
                                                    <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                        <a href="Payments.aspx">
                                                            <img src="../Resources/Images/Payments.png" class="img-responsive center-block" border="0" />
                                                            Mis Pagos</a>
                                                    </div>
                                                    <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                        <asp:HyperLink ID="hpStore1" runat="server">
                                                            <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0" />
                                                            Tienda
                                                        </asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row box-hr">
                                <hr>
                            </div>
                            <div id="info_transacciones" class="table-responsive m-t">







                               

                            </div>
                        </div>
                    </div>
                </div>

                <div class="footer footer-fondo">
                    <strong>inResorts - 2018</strong>
                </div>
            </div>
        </div>
        <a id="scrollUp" href="#top" title="Scroll to top" style="position: fixed; z-index: 2147483647; display: none;"></a>
        <script src="Script/ScriptTransactionsDetail.js"></script>
    </form>
</body>
</html>
