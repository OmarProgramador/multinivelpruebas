<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WalletAmortization.aspx.cs" Inherits="MULTI_NIVEL.Views.WalletAmortization" %>

 
<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="./pagos_files/styles_per.min-4.25.5.0.css" rel="stylesheet" type="text/css">
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link href="tienda_files/font-awesome.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196" />
    <link href="Css/MyStyle.css" rel="stylesheet" />
    <script src="Script/Script.js"></script>
    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>
    <script src="https://checkout.culqi.com/v2"></script>
</head>
<body class="top-navigation pace-done">
    <div id="divProgressBar" class="display-none">
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
                                                    <a href="SignOutC.aspx">Salir</a>
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
                <div class="slider_home">
                    <div class="carousel slide" id="slideHome">
                        <div class="carousel-inner">
                            <div class="item active">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="wrapper wrapper-content animated fadeInUp nuevosocio">
                    <div class="contenedor container">
                        <div class="ibox float-e-margins">
                            <div class="ibox-content">
                                <br />
                                <!--div sombra-->
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="row sombra">
                                            <div class="col-lg-9">
                                                <h1>Pago con mi Wallet</h1>
                                            </div>
                                            <div class="col-lg-3 text-center">
                                                <h4 style="background: #009652; color: white; padding: 12px; text-align: center; border-radius: 6px;">
                                                    <asp:Label ID="AmountWallet" Text="Wallet: 0.00" runat="server" CssClass="" Style="font-size: 18px; font-weight: bold;" />
                                                    <span style="font-size: 18px; font-weight: bold;">USD</span>
                                                </h4>
                                            </div>
                                            <div class="col-lg-12">
                                                <p>Descripción: 
                                                <asp:Label ID="Description" Text="Compra de Membresia" runat="server" /></p>                                            
                                                <p>Monto y codigo de moneda: <asp:Label ID="Amount" Text="text" runat="server" /></p>                                               
                                            </div>
                                            <div class="col-lg-12">
                                                <br />
                                                <asp:Label ID="MessageSucces" Text="" ForeColor="Green" runat="server" />
                                                <asp:Label ID="MessageWarning" Text="" ForeColor="Orange" runat="server" />
                                                <asp:Label ID="MessageError" Text="" ForeColor="Red" runat="server" />
                                                <br />
                                            </div>
                                            <asp:Panel ID="PnWallet" runat="server" class="col-lg-12">
                                                <asp:Button ID="PayByWallet" Text="Procesar" OnClick="PayByWallet_Click" CssClass="btn btn-primary" runat="server" />
                                            </asp:Panel>                                          
                                        </div>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="footer footer-fondo">
                    <strong>inResorts - 2018</strong>
                </div>
            </div>
        </div>
        <script src="Script/AddMemberCulqi.js"></script>
        <script>
              
        </script>
    </form>
</body>
</html>
