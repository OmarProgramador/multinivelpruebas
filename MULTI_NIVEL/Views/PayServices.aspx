<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayServices.aspx.cs" Inherits="MULTI_NIVEL.Views.PayServices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
     <link href="tienda_files/font-awesome.css" rel="stylesheet">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    
    <script src="Script/Script.js"></script>
    <script src="https://checkout.culqi.com/v2"></script>
    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>

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
                                            <div class="col-md-12">
                                                <div class="">
                                                    <h4>
                                                        <asp:Label ID="titlePAY" runat="server" CssClass="" />
                                                    </h4>
                                                    <hr>
                                                </div>
                                                <div class="col-md-8 col-md-offset-1">
                                                 
                                                    <asp:Label ID="nameBenef" runat="server" Font-Size="Medium" />

                                                </div>
                                                <div class="col-md-8 col-md-offset-1">
                                                    <br />
                                                    <asp:Label ID="typeMembreship" runat="server" Font-Size="Medium" />

                                                </div>
                                               
                                                <%--<div class="col-md-8 col-md-offset-1">
                                                    <br />
                                                    <asp:Label ID="amountInitialQuote" runat="server" Font-Size="Medium" />

                                                </div>
                                                <div class="col-md-8 col-md-offset-1">

                                                    <br />
                                                    <asp:Label ID="numQuotes" runat="server" Font-Size="Medium" />

                                                </div>--%>
                                                <%--<div class="col-md-8 col-md-offset-1">
                                                    <br />
                                                    <asp:Label ID="costeAdulto" runat="server" Font-Size="Medium" />

                                                </div>
                                                 <div class="col-md-8 col-md-offset-1">

                                                    <br />
                                                    <asp:Label ID="costeNino" runat="server" Font-Size="Medium" />

                                                </div>--%>
                                                 <div class="col-md-8 col-md-offset-1">
                                                    <br />
                                                    <asp:Label ID="amountTotal" runat="server" Font-Size="Medium" />

                                                </div>
                                                <div class="col-md-8 col-md-offset-1">
                                                    <br />
                                                    <asp:Label ID="fVig" runat="server" Font-Size="Medium" />

                                                </div>
                                            </div>
                                            
                                        </div>
                                        <br />
                                        <br />
                                    </div>
        </div>                             
                                <div class="row sombra">
                                    <div class="col-md-12">
                                        <h4>Pago en Linea <asp:Label ID="amountAPayCulqui" runat="server" ForeColor="Red" /></h4>
                                        <hr>
                                    </div>
                                    <div class="">
                                        <div class="">
                                            <div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Número de tarjeta</span>
                                                    <input type="text" size="50" data-culqi="card[number]" id="card[number]" class="form-control input-sm capitalize" />
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
                                                    <input size="2" data-culqi="card[exp_month]" id="card[exp_month]" class="input-sm capitalize" maxlength="2" style="border-color: #A6CE39" />
                                                    <span>/</span>
                                                    <input size="4" data-culqi="card[exp_year]" id="card[exp_year]" class="input-sm capitalize" maxlength="4" style="border-color: #A6CE39" />
                                                </label>
                                            </div>
                                            <div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Correo Electrónico</span>
                                                    <input type="text" size="50" data-culqi="card[email]" id="card[email]" class="form-control input-sm capitalize" />
                                                </label>
                                            </div>
                                            <div class="col-md-6 col-md-offset-1">
                                                
                                                <%--<asp:Button ID="btnRegistePay" runat="server" class="btn btn-sm btn-primary m-t-n-xs plomo" Text="REGISTRAR SOCIO"></asp:Button>--%>
                                               
                                                    <asp:Label ID="Label1" runat="server" ><b>Cuotas</b></asp:Label>
                                                    <asp:DropDownList ID="ddlQuote" runat="server" class="form-control input-sm">
                                               
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-6 ">
                                                 <br>
                                                <center>
                                                <button 
                                                    id="btnRegistePay" 
                                                    style="padding: 8px 50px" 
                                                     
                                                    class="btn btn-sm btn-primary m-t-n-xs plomo" >
                                                    <div class="text-center">
                                                       <b> EFECTUAR PAGO</b>
                                                    </div>
                                                </button>
                                                </center>
                                            </div>
                                            <div class="col-md-6 " >
                                                <br>
                                                <center>
                                                    <a  href="Store.aspx"
                                                        class="btn btn-sm btn-primary m-t-n-xs plomo" 
                                                        style="padding: 8px 50px" 
                                                        onclick="histoy.back();return 0;">
                                                        <strong>CANCELAR</strong>

                                                    </a>
                                                    <center>
                                                        </center>
                                                </center>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Favorito -->
                <div class="modal inmodal" id="mdlValidation" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content animated bounceInRight">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">TERMINOS Y CONDICIONES</h4>
                            </div>
                            <div class="modal-body">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal inmodal" id="mdlMessagge" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content animated bounceInRight">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    <span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">Pago En Linea</h4>
                            </div>
                            <div class="modal-body">
                                <span id="txtMessagge"></span>
                                <center><a href="HistorialCompras.aspx" class="btn btn-sm btn-primary m-t-n-xs" id="btnEnlace">
                                    Aceptar</a></center>
                            </div>
                            
                        </div>
                    </div>
                </div>
                <div class="footer footer-fondo">
                    <strong>inResorts - 2018</strong>
                </div>
            </div>
        </div>
        <script type="text/javascript"> 
            //var prodId = getParameterByName('id');
            var numcuotes = "";
          /* Culqi.publicKey = 'pk_live_0VvfZdSKhqDXHPvn';*/
             Culqi.publicKey = 'pk_test_8lmFNlrqh9MZp7VG';
            Culqi.init();
            $('#btnRegistePay').on('click', function (e) {
                 document.getElementById('divProgressBar').style.display = "inline";
                var ddlQuotes = document.getElementById("ddlQuote");
                numcuotes = ddlQuotes.options[ddlQuotes.selectedIndex].value;
                
                // Crea el objeto Token con Culqi JS
                Culqi.createToken();
                e.preventDefault();
                culqi();
            });


            function returnsGet() {
                if (httpRequest.readyState === 4) {
                    if (httpRequest.status === 200) {
                        var anwser = '' + httpRequest.responseText;
                        document.getElementById('divProgressBar').style.display = "none";
                        var data = anwser.split('¬');
                        if (data[0] === "true") {
                            document.getElementById('txtMessagge').innerText = "Su Pago se Realizó con Exito";
                            $("#mdlMessagge").modal("show");
                        }
                        else {
                            document.getElementById('txtMessagge').innerText = data[1];
                            document.getElementById('btnEnlace').href = "";
                            $("#mdlMessagge").modal("show");
                        }
                    }
                }
            }
            function culqi() {
                if (Culqi.token) { // ¡Objeto Token creado exitosamente!
                    var token = Culqi.token.id;
                   
                    var params = "token=" + token + "&numcuotes=" + numcuotes;
                    Get("PayServicesController", params, returnsGet);
                    

                } else { // ¡Hubo algún problema!                                     
                    //alert(Culqi.error.user_message);
                    if (Culqi.error !== undefined) {
                        alert(Culqi.error.user_message);
                    }
                }

            };
        </script>
    </form>
</body>

</html>
