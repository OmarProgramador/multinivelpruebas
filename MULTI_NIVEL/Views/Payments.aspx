<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="MULTI_NIVEL.Views.Payments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pagos | inResorts</title>
    <link href="Css/css.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" />
    <link href="tienda_files/font-awesome.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196" />
    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>
    <script src="Script/Script.js"></script>
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
						                            <a href="SignOutC.aspx" class="btn btn-primary block" style=" margin: 0px; border-radius:5px">Salir</a>
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
                                            <img class="center-block img-responsive" src="img/oficinavirtualsol.png" style="margin-top: 10px; max-height: 74px" border="0" />
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
                                    <img src="../Resources/Images/Payments.png" class="logo-seccion" align="left" />
                                    <h2 class="green"><b>Comisiones y Pagos</b></h2>
                                    <ol class="breadcrumb negro" style="background-color: #ffffff;">
                                        <li class="breadcrumb-item "><a href="Bonus.aspx">Mis comisiones</a></li>
                                        <li class="breadcrumb-item active"><a href="Payments.aspx" class="subrayar">Mis Pagos</a></li>
                                        <li class="breadcrumb-item"><a href="Activation.aspx">Mis Activaciones</a></li>
                                        <li class="breadcrumb-item"><a href="Wallet.aspx">Wallet</a></li>
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
                                                <div class="col-md-2 separadorbarra" style="z-index: 100;">
                                                    <a href="Register.aspx">
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block height"/>Nuevo Socio</a>
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
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0" />Tienda
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row box-hr">
                                <hr>
                            </div>
                            <div class="row text-center col-lg-12" id="mensajes" style="padding: 20px;">
                            </div>
                            <br />
                            <div class="row col-lg-12">
                                <div class="zona-collapse" id="zona-collapse">
                                </div>
                            </div>
                            <div class="row col-lg-12">
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="footer footer-fondo">
                    <strong>inResorts - 2018</strong>
                </div>
            </div>
        </div>
        <div class="modal inmodal" id="mdlImages" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content animated bounceInRight">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Amortizacion</h4>
                    </div>
                    <div class="modal-body" style="overflow: hidden" id="myModal">
                        <div class="form-group">
                            <label for="">Saldo Capital Hasta El Momento:</label>
                            <label for="" id="lblCapital">S/ 7500</label>
                        </div>
                        <div class="form-group" style="display: none">
                            <asp:TextBox runat="server" for="" ID="lblIdMembership" Style="display: none;"></asp:TextBox>
                            <asp:TextBox ID="txtMemb" runat="server" class="form-control input-sm" Style="display: none;"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" for="txtAnt" ID="lblAnt">Amortizacion:</asp:Label>
                            <asp:TextBox ID="txtTest" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                            <asp:TextBox ID="txtAct" runat="server" class="form-control input-sm"></asp:TextBox>
                            <asp:TextBox ID="txtAmortMin" runat="server" class="form-control input-sm" Style="display: none">100</asp:TextBox>
                            <asp:CompareValidator ErrorMessage="Monto vacio o por debajo de S/ 100" ControlToValidate="txtAct" runat="server" ControlToCompare="txtAmortMin" Operator="GreaterThanEqual" Type="Double" ForeColor="Red" />
                            <asp:RequiredFieldValidator ErrorMessage="Monto vacio o menor a la Amortizacion Actual" ControlToValidate="txtAct" runat="server" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <label for="ddlSons">Cuotas restantes:</label>
                            <asp:Label runat="server" ID="lblQuotes">00</asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="ddlSons">Numero para Reducir mis cuotas restantes:</label>
                            <asp:DropDownList Style="width: 30%; display: none; background-color: white;" ID="ddlSons" runat="server" BackColor="Black">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtCount" runat="server" class="form-control input-sm" TextMode="number" min="0" Text="0"></asp:TextBox>

                            <asp:CompareValidator ErrorMessage="Cuotas por debado del minimo o por encima del maximo" ControlToValidate="txtCount" runat="server" ControlToCompare="txtTest" Operator="LessThan" Type="Double" ForeColor="Red" />
                            <asp:RequiredFieldValidator ErrorMessage="Campo vacio" ControlToValidate="txtCount" runat="server" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <label style="font-weight: bold; font-size: 16px;">Cuotas para el nuevo Cronograma: </label>
                            <span id="quotesResult" style="font-weight: bold; font-size: 18px;"></span>
                        </div>
                        <div class="form-group" style="display: none">
                            <label for="txtInterest">Nuevo Porcentaje De Interes</label>
                            <asp:DropDownList Style="width: 30%; display: none; background-color: white;" ID="ddlInterest" runat="server" BackColor="Black" Visible="true">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblErrorMessage"
                                Text="Username:"
                                AssociatedControlID="UsernameTextBox"
                                runat="server" Visible="false"></asp:Label>
                        </div>
                        <div class="form-group col-lg-12 text-right">
                            <button type="button" class="btn btn-sm btn-primary m-t-n-xs plomo" data-dismiss="modal" onclick="preview();" style="display: none">Procesar</button>
                        </div>
                        <div class="form-group col-lg-12 text-right">
                            <%--  <input name="btnRegister" value="Guadar Recibo" id="btnGuadarImagen" class="btn btn-sm btn-primary m-t-n-xs plomo" type="button" />--%>
                            <asp:TextBox runat="server" ID="lblIdMem" Style="display: none" />
                            <asp:Button ID="btnSubirImagen" Text="Actualizar" runat="server" class="btn btn-sm btn-primary m-t-n-xs plomo" type="button" OnClick="btnSubirImagen_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal inmodal" id="mdlCulqi" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content animated bounceInRight">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Pago en Linea</h4>
                        <input type="hidden" name="name" id="lblIdImagen" />
                    </div>
                    <div class="modal-body" style="overflow: hidden">
                        <div class="">
                            <div class="col-md-8 col-md-offset-1">
                                <label>
                                    <span>Número de tarjeta</span>
                                    <input type="text" size="20" data-culqi="card[number]" id="card[number]" class="form-control input-sm capitalize" />
                                </label>
                            </div>
                            <div class="col-md-8 col-md-offset-1">
                                <label>
                                    <span>CVV</span>
                                    <input type="text" size="4" data-culqi="card[cvv]" id="card[cvv]" class="form-control input-sm capitalize" maxlength="3" />
                                </label>
                            </div>
                            <div class="col-md-8 col-md-offset-1" style="display: flex">
                                <label>
                                    <span>Fecha expiración (MM/YYYY)</span>
                                    <input size="2" data-culqi="card[exp_month]" id="card[exp_month]" class="input-sm capitalize" maxlength="2" style="border-color: lawngreen" />
                                    <span>/</span>
                                    <input size="4" data-culqi="card[exp_year]" id="card[exp_year]" class="input-sm capitalize" maxlength="4" style="border-color: lawngreen" />
                                </label>
                            </div>
                            <div class="col-md-8 col-md-offset-1">
                                <label>
                                    <span>Correo Electrónico</span>
                                    <input type="text" size="50" data-culqi="card[email]" id="card[email]" class="form-control input-sm capitalize" />
                                </label>
                            </div>
                            <div class="col-md-6">
                                <br>
                                <%--<asp:Button ID="btnRegistePay" runat="server" class="btn btn-sm btn-primary m-t-n-xs plomo" Text="REGISTRAR SOCIO"></asp:Button>--%>
                                <asp:Label ID="Label1" runat="server" Text="Cuotas"></asp:Label>
                                <asp:DropDownList ID="ddlQuote" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-6">
                                <br>
                                <center>
                                             <button id="btnRegistePay" class="btn btn-sm btn-primary m-t-n-xs plomo" >Efectuar Pago</button>
                                        </center>
                            </div>
                            <div class="col-md-6">
                                <br>
                                <center><button  class="btn btn-sm btn-primary m-t-n-xs plomo" style="padding: 8px 50px" onclick="histoy.back();return 0;"><strong>CANCELAR</strong></button><center>
                                    </center></center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal inmodal" id="mdlAdelanto" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content animated bounceInRight">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" style="color: #2981c5">Adelanto de pago de cuotas</h4>
                    </div>
                    <div class="modal-body">
                        <div style="padding: 0px 20px 20px 20px;">
                            <div class="row">
                                <div class="col-sm-12">
                                    <input type="hidden" name="name" value="" id="idMembers" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label for="">Numero de Cuotas</label>
                                        <select id="numQuotesAdvanc" class="form-control">
                                            <option value="1">1</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label>Valor de cada cuota</label>
                                        <label class="form-control" id="valueQuote"><span style="font-weight: bold;">S/</span>85</label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label>Total a pagar</label>
                                        <label class="form-control" id="valueTotal"><span style="font-weight: bold;">S/</span>85</label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <input type="button" name="btnAdvance" id="btnAdvance" value="Pagar" class="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal inmodal" id="mdlRefuse" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content animated bounceInRight">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" style="color: #2981c5">Rehacer Pago</h4>
                    </div>
                    <div class="modal-body">
                        <div style="padding: 0px 20px 20px 20px;">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label>¿esta segurO de rehacer su pago?</label>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <input type="button" onclick="rejectNow()" name="btnAdvance" id="" value="Rehacer" class="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <a id="scrollUp" href="#top" title="Scroll to top" style="position: fixed; z-index: 2147483647; display: none;"></a>
    </form>
    <script src="Script/ScriptPayments.js"></script>
</body>
</html>
