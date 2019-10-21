<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMembPayWallet.aspx.cs" Inherits="MULTI_NIVEL.Views.AddMembPayWallet" %>

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

                                                    <asp:Label ID="Wallet" Text="Wallet: 0.00" runat="server" CssClass="" Style="font-size: 18px; font-weight: bold;" />
                                                    <span style="font-size: 18px; font-weight: bold;">USD</span>
                                                </h4>

                                            </div>
                                            <div class="col-lg-12">
                                                <label>Descripción:</label>
                                                <asp:Label ID="Description" Text="Compra de Membresia" runat="server" />
                                            </div>
                                            <div class="col-lg-12">
                                                <label></label>
                                                <br />
                                                <asp:Label ID="TypeMembreship" Text="" runat="server" />
                                            </div>
                                            <div class="col-lg-12">
                                                <br />
                                                <asp:Label ID="AmountTotal" Text="" runat="server" />
                                            </div>
                                            <div class="col-lg-12">
                                                <br />
                                                <asp:Label ID="NumQuotes" Text="" runat="server" />
                                            </div>
                                            <div class="col-lg-12">
                                                <br />
                                                <asp:Label ID="AmountInitialQuote" Text="" runat="server" />
                                            </div>
                                            <div class="col-lg-12">
                                                <br />
                                                <label>Monto y codigo de moneda:</label>
                                                <asp:Label ID="Monto" Text="text" runat="server" />
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
                                            <asp:Panel ID="PnOthers" runat="server">
                                                <div class="col-lg-12">
                                                    <hr />
                                                    <h2>
                                                    <asp:Label ID="LblAmountWallet" Text="" runat="server" /></h2>
                                                </div>
                                                <div class="col-lg-12" style="text-align: center;">
                                                    <label>Completar el pago con</label>
                                                    <asp:RadioButton Text="Tarjeta" ID="tab1" runat="server" GroupName="options" Checked="true" />
                                                    <asp:RadioButton Text="Deposito" ID="tab2" runat="server" GroupName="options" />
                                                </div>
                                                <br />
                                                <div class="col-lg-12">
                                                    <div class="" id="primer-tab">
                                                        <div class="row sombra" style="box-shadow: 0 0 1px 1px rgba(26,24,26,0.24);">
                                                            <div class="col-md-12">
                                                                <label>
                                                                    <span>Número de tarjeta</span>
                                                                    <input type="text" size="50" data-culqi="card[number]" id="card[number]" class="form-control" />
                                                                </label>
                                                            </div>
                                                            <div class="col-md-12">
                                                                <label>
                                                                    <span>Cvv</span>
                                                                    <input type="text" size="4" data-culqi="card[cvv]" id="card[cvv]" class="form-control" maxlength="3" />
                                                                </label>
                                                            </div>
                                                            <div class="col-md-12" style="display: flex">
                                                                <label>
                                                                    <span>Fecha expiración (MM/YYYY)</span>
                                                                    <input size="2" data-culqi="card[exp_month]" id="card[exp_month]" class="input-sm" maxlength="2" style="border-color: #A6CE39" />
                                                                    <span>/</span>
                                                                    <input size="4" data-culqi="card[exp_year]" id="card[exp_year]" class="input-sm" maxlength="4" style="border-color: #A6CE39" />
                                                                </label>
                                                            </div>
                                                            <div class="col-md-12">
                                                                <label>
                                                                    <span>Correo electrónico</span>
                                                                    <input type="text" size="50" data-culqi="card[email]" id="card[email]" class="form-control" />
                                                                </label>
                                                            </div>
                                                            <div class="col-md-12">
                                                                <label>
                                                                    Numero de cuotas
                                                                    <asp:DropDownList ID="DdlQuote" runat="server" class="form-control input-sm">
                                                                    </asp:DropDownList>
                                                                </label>
                                                            </div>
                                                            <div class="col-md-12">
                                                                <label>Moneda
                                                                    <asp:DropDownList ID="Mo" runat="server">
                                                                        <asp:ListItem Value="USD" Text="Dolares" />
                                                                        <asp:ListItem Value="PEN" Text="Soles" />
                                                                    </asp:DropDownList>
                                                                </label>
                                                            </div>
                                                            <div class="col-md-12">
                                                                <h2>
                                                                <asp:Label ID="LblAmountCulqi" Text="" runat="server" /></h2>
                                                            </div>
                                                            <div class="col-md-12">
                                                                <input id="btnRegistePay" type="button" name="name" value="Procesar" class="btn btn-primary" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-12">
                                                    <div class="" id="segundo-tab" style="display: none">
                                                        <div class="ticket_container" style="margin: 30px 10px 10px 10px; box-shadow: 1px 2px 6px #d6c6c6; border-radius: 8px">

                                                            <div class="barras">

                                                                <span style="font-size: 18px; padding: 26px 15px;">"Subir comprobante ahora"</span>
                                                            </div>
                                                            <div class="total">
                                                                <div id="moneda3" class="dd-container" style="width: 93px; padding: 32px 15px">
                                                                    <div class="form-group col-sm-6">
                                                                        <div class="custom-file">

                                                                            <asp:FileUpload runat="server" class="custom-file-input" ID="Recibo" lang="es" />
                                                                            <label class="custom-file-label" for="customFileLang"></label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <center>
                                                    <div class="tiempo" style="padding-top:40px;background-color:#f6f6f6;text-align:center">
                                                        <asp:RadioButton ID="NowReceipt" Text="" runat="server" GroupName="optionsRe"  Checked="true"/>
                                                    </div>
                                                    </center>
                                                        </div>
                                                        <asp:Panel ID="pnEnviarDesp" runat="server" class="ticket_container" Style="margin: 10px; box-shadow: 1px 2px 6px #d6c6c6; border-radius: 8px">
                                                            <div class="barras">
                                                                <span style="font-size: 18px; padding: 26px 15px;">"Subir comprobante Despues"</span>
                                                            </div>
                                                            <div class="total" style="padding: 18px">
                                                                <label style="font-size: 15px">Se le enviará un correo con un enlace para que a travez de este pueda subir una imagen de su comprobante</label>
                                                                <div id="moneda4" class="dd-container" style="width: 93px;">
                                                                </div>
                                                                <div class="total2">
                                                                </div>
                                                            </div>
                                                            <center>
                                                                <div class="tiempo" style="padding-top:40px;background-color:#f6f6f6;text-align:center">
                                                                    <asp:RadioButton ID="AfterReceipt" Text="" runat="server" GroupName="optionsRe" />
                                                                </div>
                                                            </center>
                                                                                        </asp:Panel>

                                                                                        <asp:Panel ID="qwe" runat="server" class="ticket_container" Style="margin: 10px; box-shadow: 1px 2px 6px #d6c6c6; border-radius: 8px">
                                                                                            <center>
                                                                <div class="tiempo" style="height:80px;width:100%;background-color:#f6f6f6;text-align:center">
                                                                    <div>
                                                                        <br />
                                                                        <div class="botones_instrucciones">
                                                                            <h2>
                                                                            <asp:label ID="LblAmountDeposit" text="" runat="server" /></h2>
                                                                        </div>                                                                                       
                                                                    </div>
                                                                </div>
                                                                </center>
                                                        </asp:Panel>

                                                        <div style="text-align: center">
                                                            <asp:Button ID="ProcesarPay" Text="Procesar" runat="server" class="btn btn-primary" OnClick="ProcesarPay_Click" />
                                                        </div>
                                                    </div>
                                                </div>
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
            let clicR1 = document.getElementById("tab1");
            let clicR2 = document.getElementById("tab2");
            let contentap1 = document.getElementById("primer-tab");
            let contentap2 = document.getElementById("segundo-tab");
            clicR1.onclick = function () {

                contentap1.style.display = "block";
                contentap2.style.display = "none";
            }
            clicR2.onclick = function () {

                contentap1.style.display = "none";
                contentap2.style.display = "block";
            }
        </script>
    </form>
</body>
</html>
