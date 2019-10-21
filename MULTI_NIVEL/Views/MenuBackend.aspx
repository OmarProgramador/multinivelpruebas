<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuBackend.aspx.cs" Inherits="MULTI_NIVEL.Views.MenuBackend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <link href="Css/css.css" rel="stylesheet" />

    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" />
    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>
    <style>
        .Header {
            position: fixed;
            z-index: 998;
            top: 0;
            padding: .5rem;
            padding-top: 10px;
            margin-left: -100vw;
            width: 200px;
            height: 100vh;
            overflow-y: auto;
            background-color: green;
            transition: margin-left .3s ease;
        }

            .Header.is-active {
                margin-left: 0;
            }

        .Header-btn .hamburger-inner,
        .Header-btn .hamburger-inner:after,
        .Header-btn .hamburger-inner:before {
            background-color: red;
            width: 100%;
        }
    </style>
</head>

<body class="top-navigation pace-done">
    <div id="divProgressBar" style="display: none;">
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
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="#">Inresorts</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="btnSalir" Text="Salir" runat="server" OnClick="btnSalir_Click" CssClass="nav-link" />
                    </li>
                </ul>
            </div>
        </nav>

       <%-- <div class="Header is-active mt-5">
            <h1>Menu</h1>
            <nav class="Menu">
                <div class="accordion" id="accordionExample">
                    <div class="card">
                        <div class="card-header" id="headingOne"  style="padding:0;margin:0;">
                            <h2 class="mb-0">
                                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                   Pagos
                                </button>
                            </h2>
                        </div>

                        <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                            <div class="card-body" style="padding:0;margin:0;">
                                <ul>
                                    <li><a id="home" href="#">Home</a></li>
                                    <li><a id="about" href="#">Acerca</a></li>
                                    <li><a id="contact" href="#">Contacto</a></li>
                                    <li><a id="admin" href="#">Admin</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <ul>
                </ul>
            </nav>
        </div>--%>
        <div class="container" style="margin-top: 30px;">

            <div class="row">
                <div class="col-sm-2">
                    <h3>Menu</h3>
                </div>
                <div class="col-sm-5 text-right">
                    <asp:Panel ID="pnMessageDanger" runat="server" class="alert alert-danger" role="alert" Style="display: none;">
                        <asp:Label ID="lblMessageError" Text="" runat="server" />
                    </asp:Panel>
                </div>
                <div class="col-sm-5">
                    <asp:Panel ID="pnMessageSucces" runat="server" class="alert alert-success" role="alert" Style="display: none;">
                        <asp:Label ID="lblMessage" Text="" runat="server" />
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <asp:Button ID="btnUsers" runat="server" CssClass="btn btn-primary btn-block" Text="Pagos Inciales De Usarios" OnClick="USERS_Click" Style="margin: 5px;" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <a href="UserNotConfirmed.aspx" class="btn btn-primary">Usuarios Registrados sin confirmar pago</a>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" Text="Codigos Promocionales" OnClick="CODE_Click" Style="margin: 5px;" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <asp:Button ID="btnComission" runat="server" CssClass="btn btn-primary btn-block" Text="Pagos De Comisiones" OnClick="COMISSION_Click" Style="margin: 5px;" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <asp:Button ID="btnSendAlertOfQuotes" Text="Enviar Notificacion de Pagos" CssClass="btn btn-primary btn-block" runat="server" OnClick="btnSendAlertOfQuotes_Click" Style="margin: 5px;" />
                </div>
                <div class="col-9">
                    <asp:Label ID="ListMessaggeWhatsapp" Text="" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <asp:Button ID="Button2" Text="Morosidad" CssClass="btn btn-primary btn-block" runat="server" OnClick="btnViewPaysDefault_Click" Style="margin: 5px;" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <asp:Button ID="btnNews" Text="Registrar Noticia" CssClass="btn btn-primary btn-block" runat="server" OnClick="btnNews_Click" Style="margin: 5px;" />
                </div>
            </div>
            <%--<div class="row">
               <div class="col-sm-3">
                    <asp:Button ID="btnAlertEmail" Text="Enviar Alerta a Email"  CssClass="btn btn-primary btn-block"  runat="server" OnClick="btnAlertEmail_Click" style="margin:5px;" />
                </div>
            </div>--%>
            <div class="row">
                <div class="col-sm-3">
                    <a href="BPayServices.aspx" class="btn btn-primary btn-block" style="margin: 5px;">Pagos de Servicios</a>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <a href="CodeTravelB.aspx" class="btn btn-primary btn-block" style="margin: 5px;">Codigos Vacacionales</a>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <a href="BListPartner.aspx" class="btn btn-primary btn-block" style="margin: 5px;">Filtro de Socios</a>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <asp:Button runat="server" Text="Herramientas" ID="btnTools" class="btn btn-primary btn-block" Style="margin: 5px;" OnClick="btnTools_Click" />
                </div>
            </div>

            <div class="row">
                <div class="col-sm-3">
                    <asp:Button runat="server" Text="Cuentas de Correo" ID="btnCorreos" class="btn btn-primary btn-block" Style="margin: 5px;" OnClick="btnCorreos_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <a href="SendEmailMissing.aspx" class="btn btn-primary btn-block" style="margin: 5px;">Enviar email faltantes</a>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <a href="BDepositRequest.aspx" class="btn btn-primary btn-block" style="margin: 5px;">Solicitudes de tranferencia</a>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <a href="PaymentsMake.aspx" class="btn btn-primary btn-block" style="margin: 5px;">Pagos a realizar</a>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <a href="BonusPeriod.aspx" class="btn btn-primary btn-block" style="margin: 5px;">Periodos</a>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <a href="BDataCorrection.aspx" class="btn btn-primary btn-block" style="margin: 5px;">Corregir Datos</a>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <a href="BlistExtorno.aspx" class="btn btn-primary btn-block" style="margin: 5px;">Extorno</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

