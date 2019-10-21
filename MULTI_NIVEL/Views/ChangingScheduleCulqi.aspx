<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangingScheduleCulqi.aspx.cs" Inherits="MULTI_NIVEL.Views.ChangingScheduleCulqi" %>

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
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">
    <link href="Css/MyStyle.css" rel="stylesheet" />
    <script src="Script/Script.js"></script>
    <script src="https://checkout.culqi.com/v2"></script>
    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>

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
                                        <br />
                                        <div class="row sombra">
                                            <div class="col-md-12">
                                                <div class="">
                                                    <h4>Pago de Adelanto de Cuota
                                                    </h4>
                                                    <hr>
                                                </div>
                                                <div class="col-md-8 col-md-offset-1">
                                                    <p>
                                                        Total A pagar:
                                                    <asp:Label ID="amountTotal" runat="server" />
                                                    </p>
                                                </div>
                                                <div class="col-md-8 col-md-offset-1">
                                                    <p>
                                                        Numero de Cuotas a pagar:
                                                    <asp:Label ID="numQuotes" runat="server" />
                                                    </p>
                                                </div>
                                                <div class="col-md-8 col-md-offset-1">
                                                    <p>
                                                        Valor de cada cuota:
                                                    <asp:Label ID="amountQuote" runat="server" />
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                                <div class="row sombra">

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
                                                <asp:Label ID="Label1" runat="server"><b>Cuotas</b></asp:Label>
                                                <asp:DropDownList ID="ddlQuote" runat="server" class="form-control input-sm">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-6 col-md-offset-1">
                                                <label>Tipo Moneda</label>
                                                <select id="correncyCode" class="form-control">
                                                    <option value="PEN">Soles</option>
                                                    <option value="USD">Dolares</option>
                                                </select>
                                            </div>
                                            <div class="col-md-6 ">
                                                <br>
                                                <center>
                                                <button 
                                                    id="btnRegistePay" 
                                                    style="padding: 8px 50px" 
                                                     
                                                    class="btn btn-sm btn-primary m-t-n-xs plomo" >
                                                        EFECTUAR PAGO
                                                </button>
                                                </center>
                                            </div>
                                            <div class="col-md-6 ">
                                                <br>
                                                <center>
                                                    <button  
                                                        class="btn btn-sm btn-primary m-t-n-xs plomo" 
                                                        style="padding: 8px 50px" 
                                                        onclick="histoy.back();return 0;">
                                                        CANCELAR
                                                    </button>                                                  
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
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">Pago En Linea</h4>
                            </div>
                            <div class="modal-body">
                                <span id="txtMessagge"></span>
                                <center><a href="Payments.aspx" class="btn btn-sm btn-primary m-t-n-xs" id="btnEnlace">Aceptar</a></center>
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
            /*  Culqi.publicKey = 'pk_live_0VvfZdSKhqDXHPvn';*/
            Culqi.publicKey = 'pk_test_8lmFNlrqh9MZp7VG';
            Culqi.init();
            $('#btnRegistePay').on('click', function (e) {
                document.getElementById('divProgressBar').className = "";
                var ddlQuotes = document.getElementById("ddlQuote");
                numcuotes = ddlQuotes.options[ddlQuotes.selectedIndex].value;

                // Crea el objeto Token con Culqi JS
                Culqi.createToken();
                e.preventDefault();
                culqi();
            });
            function returnsGet(_response) {
                let data = _response;
                if (data != "") {
                    let response = eval('' + data + '');
                    document.getElementById('divProgressBar').className = "display-none";
                    if (response[0].data.success) {
                        
                        location.href = "Payments.aspx?msg=" + response[0].data.message;
                    }
                    else {
                        document.getElementById('txtMessagge').innerText = response[0].data.message;
                        document.getElementById('btnEnlace').href = "";
                        $("#mdlMessagge").modal("show");
                    }
                }
            }
            function culqi() {
                if (Culqi.token) { // ¡Objeto Token creado exitosamente!
                    var token = Culqi.token.id;
                    var params = "token=" + token + "&numcuotes=" + numcuotes;
                    GetDos("ChangingScheduleCulqiC", params, returnsGet);

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
