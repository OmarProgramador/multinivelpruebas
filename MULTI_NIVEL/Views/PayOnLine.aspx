<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayOnLine.aspx.cs" Inherits="MULTI_NIVEL.Views.PayOnLine" %>

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
    <link href="tienda_files/font-awesome.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196" />
    <link href="Css/MyStyle.css" rel="stylesheet" />
    <script src="Script/Script.js"></script>
    <script>

        function isNumeric(char) {
            return ('0123456789'.indexOf(char) !== -1);
        }

        function formatCreditCard() {
            var cardField = document.getElementById("card[number]");
            //remove all non-numeric characters
            var realNumber = cardField.value.replace(/\D/g, '');
            var newNumber = "";
            for (var x = 1; x <= realNumber.length; x++) {
                //make sure input is a digit
                if (isNumeric(realNumber.charAt(x - 1)))
                    newNumber += realNumber.charAt(x - 1);
                //add space every 4 numeric digits
                if (x % 4 == 0 && x > 0 && x < 15)
                    newNumber += " ";
            }
            cardField.value = newNumber;
        }

        function formatCreditCardOnKey(event) {
            //on keyup, check for backspace to skip processing
            var code = (event.which) ? event.which : event.keyCode;
            if (code != 8)
                formatCreditCard();
            else {
                //trim whitespace from end; trimEnd() doesn't work in IE
                document.getElementById("card[number]").value = document.getElementById("card[number]").value.replace(/\s+$/, '');
            }

        }
    </script>
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
                                                    <a href="SignOutC.aspx"class="btn btn-primary block">Salir</a>
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
                                                    <h4>Detalle de mi compra
                                                    </h4>
                                                    <hr>
                                                </div>
                                                <div class="col-md-8 col-md-offset-1">
                                                    <br />
                                                    <p>
                                                        Tipo de membresía:
                                                        <asp:Label ID="typeMembreship" runat="server" />
                                                    </p>
                                                    <p>
                                                        Costo total de membresía:
                                                        <asp:Label ID="AmountTotal" runat="server" />
                                                        <asp:Label ID="CurrencyCode" Text="" runat="server" />
                                                    </p>
                                                    <p>
                                                        Costo De Inicial: 
                                                        <asp:Label ID="AmountInitialQuote" runat="server" />
                                                        <asp:Label ID="CurrencyCode2" Text="" runat="server" />
                                                    </p>
                                                    <p>
                                                        La Membresia esta Dividida en:
                                                        <asp:Label ID="NumQuotes" runat="server" />
                                                        Cuotas de
                                                        <asp:Label ID="AmountQuotes" Text="" runat="server" />
                                                        <asp:Label ID="CurrencyCode3" Text="" runat="server" />
                                                    </p>
                                                    <p>
                                                        Tipo de Cambio : 
                                                        <asp:Label ID="TypeChange" Text="" runat="server" />
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                                <div class="row sombra">
                                    <div>
                                        <h4>Datos de mi pago</h4>
                                        <hr />
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <p style="display: initial; font-weight: 700;">
                                            Monto a pagar por concepto de mi Inicial: 
                                            <asp:Label ID="AmountAPayCulqui" runat="server" ForeColor="Blue" />
                                            <asp:Label ID="CurrencyCode4" Text="USD" runat="server" />
                                        </p>
                                        <asp:DropDownList ID="ddlcurrencyCode" Style="padding: 3px; border-radius: 3px; float: right;" runat="server">
                                            <asp:ListItem Value="USD" Text="Dolares" />
                                            <asp:ListItem Value="PEN" Text="Soles" />
                                        </asp:DropDownList>


                                    </div>
                                    <div class="">
                                        <div class="">
                                            <div class="col-md-8 col-md-offset-1">
                                                <br />
                                                <label>
                                                    <span>Correo Electrónico</span>
                                                    <input type="text" size="50" data-culqi="card[email]" id="card[email]" class="form-control input-sm" />
                                                </label>
                                            </div>
                                            <div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Número de tarjeta</span><%--onkeyup="formatCreditCardOnKey(event)"--%>
                                                    <input type="text" size="50" data-culqi="card[number]" id="card[number]" class="form-control input-sm capitalize card-number"  data-mask="#### #### #### ####" />
                                                </label>
                                            </div>

                                            <div class="col-md-8 col-md-offset-1" style="display: flex">
                                                <label>
                                                    <span>Fecha expiración (MM/YYYY)</span>
                                                    <input size="2" data-culqi="card[exp_month]" id="card[exp_month]" class="input-sm capitalize" maxlength="2" style="border-color: #A6CE39" placeholder="MM" />
                                                    <span>/</span>
                                                    <input size="4" data-culqi="card[exp_year]" id="card[exp_year]" class="input-sm capitalize" maxlength="4" style="border-color: #A6CE39" placeholder="YYYY" />
                                                </label>
                                            </div>
                                            <div class="col-md-4 col-md-offset-1">
                                                <label>
                                                    <span>CVV</span>
                                                    <input type="text" size="4" data-culqi="card[cvv]" id="card[cvv]" class="form-control input-sm capitalize" maxlength="3" />
                                                </label>
                                            </div>
                                            <div class="col-md-8 col-md-offset-1">
                                                <span>Cuotas</span>
                                                <asp:DropDownList ID="ddlQuote" runat="server" class="form-control input-sm" Style="max-width: 390px;">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="display-none">
                                                <asp:TextBox ID="TokenId" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mt-4">                                       
                                        <p id="MessageError" style="color: red;"></p>                                      
                                        <div class="row">
                                            <div class="col-md-12 text-center">
                                                <input type="button" name="btnRegistePay" value="Efectuar Pago" id="btnRegistePay" style="" class="btn btn-primary" />
                                                <button
                                                    class="btn btn-success"
                                                    style=""
                                                    onclick="histoy.back();return 0;">
                                                    Cancelar
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Favorito -->
                <div class="modal inmodal" id="mdlMessagge" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content animated bounceInRight">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">Pago En Linea</h4>
                            </div>
                            <div class="modal-body text-center">
                                <span id="txtMessagge"></span>
                                <a href="Index.aspx" class="btn btn-sm btn-primary m-t-n-xs" id="btnEnlace">Aceptar</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="footer footer-fondo">
                    <strong>inResorts - 2018</strong>
                </div>
            </div>
        </div>
        <%-- <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>--%>
        <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
        <!-- Incluyendo .js de Culqi JS -->
        <script src="https://checkout.culqi.com/v2"></script>

        <script type="text/javascript"> 


            var amountDolar = parseFloat(document.getElementById('AmountAPayCulqui').innerText);

            document.getElementById('ddlcurrencyCode').onchange = function () {
                let cc = this.options[this.selectedIndex].value;

                document.getElementById('CurrencyCode4').innerText = "USD";
                document.getElementById('AmountAPayCulqui').innerText = amountDolar.toString();

                if (cc == "PEN") {
                    document.getElementById('CurrencyCode4').innerText = "PEN";

                    let typeChange = parseFloat(document.getElementById('TypeChange').innerText);
                    document.getElementById('AmountAPayCulqui').innerText = (amountDolar * typeChange).toFixed(2);
                }
            }

            //Culqi.publicKey = 'pk_live_0VvfZdSKhqDXHPvn';
            Culqi.publicKey = 'pk_test_8lmFNlrqh9MZp7VG';


            Culqi.init();

            document.getElementById('btnRegistePay').onclick = function (e) {
                document.getElementById('divProgressBar').className = "";
                document.getElementById('MessageError').innerText = "";

                let ddlQuotes = document.getElementById("ddlQuote");
                let numcuotes = ddlQuotes.options[ddlQuotes.selectedIndex].value;


                let numbercard = ReplaceAll(document.getElementById('card[number]').value.trim(), " ", "");
                let cvvcard = document.getElementById('card[cvv]').value.trim();
                let monthcard = document.getElementById('card[exp_month]').value.trim();
                let yearcard = document.getElementById('card[exp_year]').value.trim();
                let emailcard = document.getElementById('card[email]').value.trim();


                if (numbercard === "") {
                    document.getElementById('card[number]').focus();
                    document.getElementById('MessageError').innerText = "El numero de tarjeta es un campo obligatorio.";
                    document.getElementById('divProgressBar').className = "display-none";
                    return false;
                }
                if (cvvcard === "") {
                    document.getElementById('card[cvv]').focus();
                    document.getElementById('MessageError').innerText = "El cvv es un campo obligatorio.";
                    document.getElementById('divProgressBar').className = "display-none";
                    return false;
                }
                if (monthcard.length !== 2) {
                    document.getElementById('card[exp_month]').focus();
                    document.getElementById('MessageError').innerText = "El Mes de expiracion de tu tarjeta debe tener 2 caracteres.";
                    document.getElementById('divProgressBar').className = "display-none";
                    return false;
                }
                if (yearcard.length !== 4) {
                    document.getElementById('card[exp_year]').focus();
                    document.getElementById('MessageError').innerText = "El Año de expiracion de tu tarjeta debe tener 4 caracteres.";
                    document.getElementById('divProgressBar').className = "display-none";
                    return false;
                }
                if (emailcard === "") {
                    document.getElementById('card[email]').focus();
                    document.getElementById('MessageError').innerText = "El email es un campo obligatorio.";
                    document.getElementById('divProgressBar').className = "display-none";
                    return false;
                }

                // Crea el objeto Token con Culqi JS
                Culqi.createToken();
                e.preventDefault();

            }

            function culqi() {

                if (Culqi.token.id) { // ¡Objeto Token creado exitosamente!
                    document.getElementById('TokenId').value = Culqi.token.id;

                    $.post("PayOnLineC.aspx", $("#form1").serialize()).done(function (_data) {
                        alert(_data);
                    });

                } else { // ¡Hubo algún problema!                                     
                    //alert(Culqi.error.user_message);
                    document.getElementById('divProgressBar').className = "display-none";
                    if (Culqi.token.user_message !== undefined) {
                        alert(Culqi.token.user_message);
                    }

                    if (Culqi.error !== undefined) {
                        alert(Culqi.error.user_message);
                    }
                    return 0;
                }
            }
        </script>
    </form>
</body>
</html>
