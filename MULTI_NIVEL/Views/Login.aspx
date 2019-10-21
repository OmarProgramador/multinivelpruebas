<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MULTI_NIVEL.Views.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login | inResorts</title>
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="Script/Script.js"></script>
    <style type="text/css">
        html {
            height: auto;
        }

        body {
            background-position: center center;
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-size: cover;
            font-family: 'Raleway', sans-serif !important;
            font-size: 13px;
        }

        input[type=text], input[type=password] {
            max-height: 30px;
            font-size: 12px;
        }

        h2 {
            font-size: 1.5rem;
            margin: 0;
        }

        h1 {
            font-size: 1.5rem;
        }

        label {
            font-weight: 600;
        }

        @media only screen and (min-width: 768px) {
            .banni {
                display: none;
            }
        }

        @media only screen and (max-width: 768px) {

            .hidden-xs {
                display: none;
            }
        }
    </style>
    <style type="text/css">
        @import url('https://fonts.googleapis.com/css?family=Rokkitt:300,700');

        body {
            font-size: 13px;
        }

        a {
            text-decoration: none;
        }

        .banner {
            display: flex;
            align-items: center;
            padding: 1.25em 0.5em;
            border-radius: 5px;
            color: #fff;
            font-family: "Rokkitt";
        }

        .banner--gradient-bg {
            background: linear-gradient(-30deg, #4b8ee5E5, #4b8ee5E5 45%, #4b8ee5 45%);
        }

        .banner__logo-wrapper {
            padding: 0 0.5em;
            margin-right: 20px;
        }

        .banner__title {
            text-transform: uppercase;
            font-size: 1.5em;
            font-weight: 700;
            letter-spacing: 3px;
            margin-bottom: 0.2em;
        }

        .banner__text {
            letter-spacing: 1px;
            font-weight: 300;
            line-height: 1.4;
            font-size: 2rem;
        }

        .banner__cta {
            display: inline-block;
            padding: 10px 14px;
            margin-left: 1em;
            border-radius: 2px;
            font-size: 1.25rem;
            color: #4b8ee5;
            white-space: nowrap;
            text-transform: uppercase;
            background: #fff;
            box-shadow: 0 6px 13px 0 rgba(0,0,0,.15);
        }

        .fi-codepen {
            font-size: 2rem;
        }

        .border-primary {
            border: 0.5px solid #2981c5;
        }
    </style>
</head>
<body>
    <form runat="server" id="loginForm" action="Login.aspx" method="post">
        <nav class="navbar navbar-dark bg-light" role="navigation">
            <div id="header" class="container text-center">
                <div class="row" style="margin: 10px">
                    <div class="col-md-12 text-center">
                        <img class="logo img-responsive center-block" src="img/novologo.png" style="height: 80px; margin: 0 auto;">
                    </div>
                </div>
            </div>
        </nav>
        <div id="main" style="">
            <div class="container">
                <%--//--%>
                <div class="color-scheme-01">
                    <section class="block">
                        <div class="row hidden-sm hidden-xs" style="margin-left: 20px;">
                            <h1 style="margin-top: 10px; text-align: center">In Resorts Login</h1>
                        </div>
                        <div class="row hidden-sm hidden-xs" style="margin-left: 20px; display: none;">
                            <p><mark style="display: inline;">Debes ser miembro de la red para poder iniciar sesión!</mark></p>
                        </div>
                        <div class="row banni" style="display: none">
                            <div class="col-md-12 " style="display: inline-block; width: 100%;">
                                <a href="#" class="banner banner--gradient-bg" style="text-decoration: none;">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-12" style="text-align: center">
                                                <div class="banner__logo-wrapper">
                                                    <i class="fi fi-codepen"></i>
                                                </div>
                                                <div>
                                                    <div class="banner__title">GRAN LANZAMIENTO FUNDADORES</div>
                                                    <div class="banner__text">
                                                        Ya solo quedan
                                                        <asp:Label ID="foundingPartners" Text="300" runat="server" />
                                                        cupos fundadores.
                                                    </div>
                                                </div>

                                            </div>
                                            <%--  <div class="col-md-3" style="text-align: center;">  
                                           <div class="banner__cta">
                                             Unirse
                                           </div>
                                       </div>--%>
                                        </div>

                                    </div>
                                </a>
                            </div>
                        </div>
                        <br />
                        <div class="row">

                            <div id="BannerImage" class="col-md-8 hidden-xs"
                                style="text-align: center; border-radius: 2px 2px 2px 80px; overflow: hidden; margin-left: 34px; padding: 0px; box-shadow: 5px 5px 8px #23557b; height: 523px; max-width: 60%;">
                                <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel" style="width: 100%; height: 100%">
                                    <div class="" style="background-color: black; border-radius: 0 0 0 82px; height: 100%;">
                                        <div class="carousel-inner" style="border-radius: 2px 2px 2px 80px; height: 100%">
                                            <div class="carousel-item active" style="height: 100%">
                                                <img src="img/imgclub.jpg"
                                                    id="jofficeLandingPage_wAndroid_q90" usemap="#m_jofficeLandingPage_wAndroid_q90"
                                                    alt="" class="" style="margin: auto;">
                                            </div>

                                        </div>
                                    </div>
                                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="panel panel-primary" style="border: 1px solid #2981c5; box-shadow: 4px 4px 10px #23557b; border-radius: 4px;">
                                    <div class="panel-heading" style="border-color: #2981c5; background-color: #2981c5; padding: 10px;">
                                        <h2 style="color: white;">Iniciar sesión</h2>
                                    </div>

                                    <div class="panel-body" style="padding: 10px;">
                                        <div class="details password-form">
                                            <fieldset>
                                                <div class="form-group">
                                                    <div class="label-area">
                                                        <label>Usuario:</label>
                                                    </div>
                                                    <div class="row-holder">
                                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control formlogin" name="usuario" placeholder="Usuario"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="label-area">
                                                        <label>Contraseña:</label>
                                                    </div>
                                                    <div class="">
                                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control formlogin" name="contrasena" placeholder="Clave"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="">
                                                    <asp:CheckBox ID="chkPersistCookie" runat="server" AutoPostBack="false" Checked="true" /><label>Recordar Contraseña</label>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6"><a href="#" data-toggle="modal" data-target="#mdlRecuperar">Olvidé mi clave</a></div>
                                                    <div class="col-md-6">
                                                        <div class="" style="text-align: right; padding-right: 18px;">
                                                            <asp:Button ID="btnLogin" runat="server" Style="background-color: yellowgreen" CssClass="btn btn-primary btn-sm" data-style="expand-right" Text="Ingresar" OnClick="btnLogin_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group" style="text-align: center; display: none;">
                                                    <p class="error">
                                                        <asp:Label ID="lblanswer" runat="server" ForeColor="Red" Style="font-weight: bold;"></asp:Label>
                                                    </p>
                                                </div>
                                            </fieldset>
                                        </div></div>
                                </div>
                                <br />

                                <div class="panel panel-primary" style="border: 1px solid #2981c5; box-shadow: 4px 4px 10px #23557b; border-radius: 4px;">
                                    <div class="panel-heading" style="border-color: #2981c5; background-color: #2981c5; padding: 10px;">
                                        <h2 style="color: white;">Nuevo en inResorts?</h2>
                                    </div>
                                    <div class="panel-body" style="padding: 10px;">
                                        <div class="details password-form">
                                            <fieldset>
                                                <div class="form-group">
                                                    <div class="label-area">
                                                        <label>Patrocinador:</label>
                                                    </div>
                                                    <div class="row-holder">
                                                        <%-- <input name="SiteURL" maxlength="50" class="form-control" value="SiteURL" onclick="this.value=''" type="text">--%>
                                                        <%--<textarea ID="TextBox1" runat="server"  name="usuario" placeholder="Usuario"></textarea>--%>
                                                        <asp:TextBox ID="txtReferido" runat="server" CssClass="form-control formlogin" name="usuario" placeholder="Usuario"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-6 recuperarpass"><a href="#" data-toggle="modal" data-target="#mdlSubirRecibo">Enviar Recibo</a></div>

                                                        <div class="col-md-6" style="text-align: right; padding-right: 18px;">
                                                            <%--<button type="submit" class="btn btn-primary" name="Submit" value="Login">Registrarse en Ribera del Rio <i class="fa fa-caret-right fa-lg"></i></button>--%>
                                                            <asp:Button ID="btnReferido" CssClass="btn btn-primary btn-sm" Text="Validar" Style="background-color: yellowgreen" runat="server" OnClick="btnReferido_Click" />
                                                        </div>
                                                        <div class="col-sm-12">
                                                            <asp:Label ID="lblErrorSi2" runat="server" ForeColor="Red" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <div class="modal inmodal" id="mdlRecuperar" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <h5 class="modal-title">Recuperar Contraseña</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body" style="overflow: hidden">
                                                    <div class="form-group col-lg-12">
                                                        <label class="control-label">Ingrese su usuario:</label>
                                                        <asp:TextBox ID="txtUserRec" runat="server" name="usuariorec" placeholder="Ingrese el usuario" class="input-sm form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="error-recuperar" style="width: 100%; display: inline-block; overflow: hidden;"></div>
                                                    <asp:Button ID="btnRecuperar" runat="server" CssClass="btn btn-sm btn-primary pull-right recuperar ladda-button" Text="RECUPERAR" OnClick="btnRecuperar_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal inmodal" id="mdlSubirRecibo" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <h5 class="modal-title">Enviar Recibo</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body" style="overflow: hidden; background-color: white;">
                                                    <label>Puedes enviar tu recibo si completaste el registro y te queda el ultimo paso.</label>
                                                    <br />
                                                    <br />
                                                    <div class="col-sm-12">
                                                        <label class="control-label">Ingrese su N° de Documento</label>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-6">
                                                            <asp:TextBox ID="txtNumeroDoc" runat="server" name="usuariorec" placeholder="numero de documento" class="input-sm form-control" Style="border: 0.5px solid #2981c5;"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <asp:Label ID="txtFName" runat="server" class="input-sm form-control" Style="border: 0.5px solid #2981c5; max-height: 30px; font-size: 12px;" Text="--"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-sm-12">
                                                        <label id="DescriptionQuote" class="input-sm "></label>
                                                        <asp:TextBox ID="LblIdMembership" runat="server" Style="display: none" />
                                                    </div>
                                                    <div class="form-group text-center">
                                                        <div id="file-preview-zone">
                                                            <img src="../Resources/Images/recibo.png" id="imgpreview" style="display: block; margin: 0 auto;" alt="Alternate Text" width="200" height="200" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-sm-12">
                                                        <div class="custom-file">
                                                            <asp:FileUpload runat="server" class="custom-file-input" ID="file_upload" lang="es" />
                                                            <label class="custom-file-label" for="file_upload">Seleccionar un archivo</label>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                ErrorMessage="Tipo de archivo no permitido" ControlToValidate="file_upload"
                                                                ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF|.png|.PNG|.jpeg|.JPEG)$">

                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <asp:Label ID="lblErrorSi" runat="server" ForeColor="Red" />
                                                <div class="form-group col-sm-12">
                                                    <asp:Button ID="btnEnviarImagen" runat="server" CssClass="btn   btn-primary pull-right recuperar ladda-button" Text="Enviar" OnClick="btnEnviarImagen_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="panel panel-primary" style="border: 1px solid #2981c5; box-shadow: 4px 4px 10px #23557b; border-radius: 4px; display: none;">
                                    <div class="panel-heading" style="border-color: #2981c5; background-color: #2981c5; padding: 10px;">
                                        <h2 style="color: white;">Pago Rapido</h2>
                                    </div>

                                    <div class="panel-body" style="padding: 10px;">
                                        <div class="details password-form">
                                            <div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Codigo</label>
                                                            <asp:TextBox ID="CodeUserName" runat="server" class="form-control" placeholder="Ejem: EE7441" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Pin</label>
                                                            <asp:TextBox ID="Pin" runat="server" class="form-control" placeholder="Ejem: 41" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <p>
                                                            <asp:Label ID="PayFastInfo" Text="" runat="server" />
                                                        </p>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <asp:Button ID="BtnPayFastVerif" Text="Verificar" runat="server" class="btn btn-primary btn-sm" OnClick="BtnPayFastVerif_Click" />
                                                    </div>
                                                    <asp:Panel ID="PayFastDiv" class="col-md-12" runat="server" Style="display: none;">
                                                        <input type="button" name="name" value="Pagar" class="btn btn-primary btn-sm" onclick="PayFast()" />
                                                    </asp:Panel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-10 align-content-end"></div>
                            <div class="col-md-2 align-content-end">
                                <br />
                                <asp:Label ID="lblAdmin" runat="server" ForeColor="Red" />
                                <asp:Button ID="btnBackend" runat="server" CssClass="btn btn-primary btn-sm" Style="background-color: yellowgreen; margin-right: 35px" Text="Proveedores" OnClick="Backend_Click" />

                            </div>
                        </div>
                </div>


                <div class="login icon-cookieInfo-section">
                    <div class="icon" style="position: initial; text-align: center;">
                        <a href="#" target="">
                            <img src="img/modos.png"></a>
                    </div>
                    <div class="cookie-message">
                        <p>Nuestro sitio web utiliza cookies para almacenar información de compras y envío. Puede encontrar más información sobre las cookies en la configuración de su navegador. Sin embargo, si continúa utilizando nuestro sitio sin cambiar la configuración, se utilizarán cookies.</p>
                    </div>
                </div>
            </div>
        </div>


        <div id="payFastModal" class="modal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Pago Rapido</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Agregar imagen del pago.</p>
                        <%--<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Descripción</label><input type="text" name="name" value="" class="form-control" placeholder="" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Monto</label><input type="text" name="name" value="" class="form-control" placeholder="" />
                                </div>
                            </div>
                        </div>--%>
                        <div>
                            <div class="form-group text-center">
                                <div id="file-preview-zone2">
                                    <img src="../Resources/Images/recibo.png" id="imgpreview2" style="display: block; margin: 0 auto;" alt="Alternate Text" width="200" height="200" />

                                </div>
                            </div>
                            <div class="form-group col-sm-12">
                                <div class="custom-file">
                                    <asp:FileUpload runat="server" class="custom-file-input" ID="file_upload2" lang="es" />
                                    <label id="lblfile_upload2" class="custom-file-label" for="file_upload2">Seleccionar un archivo</label>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                        ErrorMessage="Tipo de archivo no permitido" ControlToValidate="file_upload"
                                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF|.png|.PNG|.jpeg|.JPEG)$">

                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div>
                            <asp:Button ID="BtnPayFastSend" Text="Enviar" runat="server" class="btn btn-success btn-sm" OnClick="BtnPayFastSend_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <script src="Script/Login.js"></script>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

        <script type="text/javascript">
            function PayFast() {
                $("#payFastModal").modal("show");
            }
        </script>

    </form>
    <script>
        // Add the following code if you want the name of the file appear on select
        //$(".custom-file-input").on("change", function() {
        //    var fileName = $(this).val().split("\\").pop();
        //    var name = $(this);
        //    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);

        //    if (name.files && name.files[0]) {
        //            var reader = new FileReader();
        //            reader.onload = function(e) {
        //                $('#imgpreview').attr('src', e.target.result);
        //            }
        //            reader.readAsDataURL(input.files[0]);
        //        }

        //});
        function readURL(input) {
            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    var fileName = $(".custom-file-input").val().split("\\").pop();
                    $('#imgpreview').attr('src', e.target.result);
                    $(".custom-file-label").addClass("selected").html(fileName);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
        $(".custom-file-input").change(function () {
            readURL(this);
        });

        function readURL2(input) {
            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    var fileName = $("#file_upload2").val().split("\\").pop();
                    $('#imgpreview2').attr('src', e.target.result);
                    $("#lblfile_upload2").addClass("selected").html(fileName);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
        $("#file_upload2").change(function () {
            readURL2(this);
        });
    </script>
</body>
</html>
