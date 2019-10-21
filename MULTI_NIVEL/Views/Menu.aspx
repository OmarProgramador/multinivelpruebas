<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="MULTI_NIVEL.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
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
                                                <p class="col-md-5">
                                                    <a href="Edit.aspx" class="btn btn-primary btn-sm">Editar perfil</a>
                                                </p>
                                                <p class="col-md-5">
                                                    <a href="editar.htm" class="btn btn-primary btn-sm">Cambiar Clave</a>
                                                </p>
                                                <center>
						                        
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
                <center>
                <div class="wrapper wrapper-content animated fadeInUp nuevosocio">
                    <div class="contenedor container">
                        <div class="ibox float-e-margins" style="width:400px;">
                            <div class="ibox-content">
                                <br />
                                <!--div sombra-->

                                <div class="row">
                                    <div class="col-sm-12">
                                        <h2><asp:Label ID="titlePAY" runat="server" CssClass=""/></h2>
                                        <br />
                                        <asp:Label ID="typeMembreship" runat="server" />
                                        <br />
                                        <asp:Label ID="amountTotal" runat="server" />
                                        <br />
                                        <asp:Label ID="amountInitialQuote" runat="server" />
                                        <br />
                                        <asp:Label ID="numQuotes" runat="server" />
                                    </div>
                                </div>
                                
                                 <div class="row sombra">
                                    <div class="col-md-12">
                                        <h4>Area Administrativa<asp:Label ID="amountAPay" runat="server" ForeColor="Red" /></h4>
                                        <hr>
                                    </div>
                                    <div class="">
                                        <div class="">
                                           <div class="col-md-6">
                                            <center>
                                            <button id="btnRegistePay" class="btn btn-sm btn-primary m-t-n-xs plomo" style="margin-left:100px;" >
                                                <div class="text-center">
                                                    Administrasion</div>
                                                </button>
                                                </center>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="row sombra">
                                    <div class="col-md-12">
                                        <h4>Area De Usuario<asp:Label ID="Label1" runat="server" ForeColor="Red" /></h4>
                                        <hr>
                                    </div>
                                    <div class="">
                                        <div class="">
                                           <div class="col-md-6">
                                            <button id="btnRegistePay" class="btn btn-sm btn-primary m-t-n-xs plomo" style="margin-left:100px;">
                                                <div class="text-center">
                                                    Entrar Al Sistema</div>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 <br />
                                <br />
                                <div class="row sombra">
                                    <div class="col-md-12">
                                        <h4>Area De Usuario<asp:Label ID="Label2" runat="server" ForeColor="Red" /></h4>
                                        <hr>
                                    </div>
                                    <div class="">
                                        <div class="">
                                           <div class="col-md-6">
                                            <button id="btnRegistePay" class="btn btn-sm btn-primary m-t-n-xs plomo" style="margin-left:100px;">
                                                <div class="text-center">
                                                    Entrar Al Sistema</div>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                           </div>
                        </div>
                    </div>
                </div>
              </center>
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
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">Pago En Linea</h4>
                            </div>
                            <div class="modal-body">
                                <h2 id="txtMessagge"></h2>
                                <center><a href="PostRegister.aspx" class="btn btn-sm btn-primary m-t-n-xs">Aceptar</a></center>
                            </div>
                            
                        </div>
                    </div>
                </div>
                <div class="footer footer-fondo">
                    <strong>Ribera del rio - 2018</strong>
                </div>
            </div>
        </div>
        <script type="text/javascript"> 
            //var prodId = getParameterByName('id');
            var numcuotes = "";
            Culqi.publicKey = 'pk_test_8lmFNlrqh9MZp7VG';
            Culqi.init();
            $('#btnRegistePay').on('click', function (e) {
                
                var ddlQuotes = document.getElementById("ddlQuote");
                numcuotes = ddlQuotes.options[ddlQuotes.selectedIndex].value;
                document.getElementById('divProgressBar').style.display = "inline";
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
                            document.getElementById('txtMessagge').innerText = "Ha Ocurrido un Error";
                            $("#mdlMessagge").modal("show");
                        }                       
                    }
                }
            }
            function culqi() {
                if (Culqi.token) { // ¡Objeto Token creado exitosamente!
                    var token = Culqi.token.id;
                    
                    var params = "token=" + token + "&numcuotes=" + numcuotes;
                    Get("IndexData", params, returnsGet);

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

