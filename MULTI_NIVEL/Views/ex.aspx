<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ex.aspx.cs" Inherits="MULTI_NIVEL.Views.ex" %>


<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login | inResorts</title>
    <link href="Css/bootstrap.css" rel="stylesheet">
    <link href="ingresar_files/font-awesome.css" rel="stylesheet">
    <link href="Css/animate.css" rel="stylesheet">
    <link href="ingresar_files/ladda-themeless.css" rel="stylesheet">
    <link href="Css/css.css" rel="stylesheet">
    <link href="Css/style.css" rel="stylesheet">
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
        }
    </style>
    <style type="text/css"></style>
</head>
<body>
    <form runat="server" id="loginForm"  action="Login.aspx" method="post">
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div id="header" class="container">
            <div class="navbar-header" style="margin:10px">
                <div>
                    <img class="logo img-responsive center-block" src="img/novologo.png" style="height: 80px">
                </div>
            </div>
        </div>
    </nav>
    <div id="main" style="padding-top: 90px;">
        <div class="container">

        <div class="color-scheme-01">
        <section class="block">
        <div class="row hidden-sm hidden-xs" style="text-align: center;">
        <h1>In Resorts Login</h1>
        <p><mark style="display: inline;">Debes ser miembro de la red para poder iniciar sesión!</mark></p>
        </div>
        <div class="row">
        <div class="col-md-1 hidden-sm hidden-xs">
        &nbsp;
        </div>
        <div id="BannerImage" class="col-md-7 hidden-sm hidden-xs" style="text-align: center; overflow: hidden;">
            <img  src="img/imgclub.jpg" 
                id="jofficeLandingPage_wAndroid_q90" usemap="#m_jofficeLandingPage_wAndroid_q90" 
                alt="" class="" style="margin: auto;">
        <map name="m_jofficeLandingPage_wAndroid_q90" id="m_jofficeLandingPage_wAndroid_q90">
        
        </map>
        </div>
        <div class="col-md-4" >
        <div class="panel panel-primary" style=" border-color: #2981c5;">
        <div class="panel-heading"style=" border-color: #2981c5;background-color:  #2981c5"> 
        <h2>Iniciar sesión</h2>
        </div>
        
            <div class="panel-body">
                <div class="details password-form">
                <fieldset>
                    <div class="form-group">
                    <div class="label-area">
                    <label>Usuario:</label>
                    </div>
                        <div class="row-holder">
                            <%--<input name="Username" id="username" value="" onclick="this.value=''" class="form-control" type="text">--%>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control formlogin" name="usuario" placeholder="Usuario"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                    <div class="label-area">
                    <label>Contraseña:</label>
                    </div>
                    <div class="row-holder">
                       <%--<input name="pw" id="password" maxlength="50" class="form-control" type="password">--%>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control formlogin" name="contrasena" placeholder="Clave"></asp:TextBox>
                    </div>
                        <div class="form-group inputlogin">
                            <asp:CheckBox ID="chkPersistCookie" runat="server" AutoPostBack="false" Checked="true" /><label>Recordar Contraseña</label>
                        </div>
                    </div> 
                    <div class="form-group" style="text-align: right; padding-right: 18px;">
                        <%--<button type="button" class="btn btn-primary" name="Submit" value="Login" onclick="login()">Iniciar sesión <i class="fa fa-caret-right fa-lg"></i></button>--%>
                        <asp:Button ID="btnLogin"  runat="server" CssClass="btn btn-primary" data-style="expand-right" Text="INGRESAR" OnClick="btnLogin_Click" />
                    </div>

                    <div class="col-md-12 recuperarpass"><a href="#" data-toggle="modal" data-target="#mdlRecuperar">Olvidé mi clave</a></div>
                    <p class="error">
                    <asp:Label ID="lblanswer" runat="server" ForeColor="Red"></asp:Label></p>

                    <div class="form-group" style="text-align: center;">
                    <span style="color: red;"><i></i></span>
                    </div>
                </fieldset>
                </div>
           

            </div>
        
        </div>
            <br />
        <div class="panel panel-primary" style=" border-color: #2981c5">
        <div class="panel-heading" style=" border-color: #2981c5;background-color:  #2981c5">
        <h2>Nuevo en inResorts?</h2>
        </div>              
        <div class="panel-body" >
        <div class="details password-form">
        <fieldset>
        <div class="form-group">
        <div class="label-area">
        <label>Patrocinador:</label>
        </div>
        <div class="row-holder">
               <%-- <input name="SiteURL" maxlength="50" class="form-control" value="SiteURL" onclick="this.value=''" type="text">--%>
               <%--<textarea ID="TextBox1" runat="server"  name="usuario" placeholder="Usuario"></textarea>--%>
                <asp:TextBox  ID="txtReferido" runat="server" CssClass="form-control formlogin" name="usuario" placeholder="Usuario"></asp:TextBox> 
         </div>
        </div>
        <div class="form-group" style="text-align: right; padding-right: 18px;">
            <%--<button type="submit" class="btn btn-primary" name="Submit" value="Login">Registrarse en Ribera del Rio <i class="fa fa-caret-right fa-lg"></i></button>--%>
            <asp:Button ID="btnReferido" CssClass="btn btn-primary" Text="Validar" runat="server" OnClick="btnReferido_Click" />
        </div>
        </fieldset>
        </div>
        </div>
            <div class="modal inmodal" id="mdlRecuperar" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content animated bounceInRight">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Recuperar contraseña</h4>
                    </div>
                    <div class="modal-body" style="overflow: hidden">

                        <%-- <input type="hidden" name="csrfsn" value="364e9af7c2b85488bac03fbc9e35e917">--%>
                        <div class="form-group col-lg-12">
                            <label class="control-label">Ingrese su usuario:</label>
                            <asp:TextBox ID="txtUserRec" runat="server"  name="usuariorec" placeholder="Ingrese el usuario" class="input-sm form-control"></asp:TextBox>
                        </div>
                        <div class="error-recuperar" style="width: 100%; display: inline-block; overflow: hidden;"></div>
                        <%--<asp:Button ID="btnRecover" runat="server" class="btn btn-sm btn-primary pull-right recuperar ladda-button" data-style="expand-right" Text="" name="u"></asp:Button>--%>
                        <asp:Button ID="btnRecuperar" runat="server" CssClass="btn btn-sm btn-primary pull-right recuperar ladda-button" Text="RECUPERAR" OnClick="btnRecuperar_Click" />

                    </div>
                </div>
            </div>
        </div>
        
        </div>
        <%--<div class="row" style="text-align: center;">
        <p>Olvidaste tu contraseña?</p>
            <a href="#" data-toggle="modal" data-target="#mdlRecuperar">
                <img style="margin-left: 15px;width: 150px" src="img/clickhere.png" border="0">
            </a>
        </div>--%>
        
        </div>
        </div>
        </section>
        </div>
        <div class="login icon-cookieInfo-section">
        <div class="icon" style="position: initial; text-align: center;">
        <a href="http://uniteller.ru/" target="_blank">
            <img src="img/modos.png"></a>
        </div>
        <div class="cookie-message">
        <p>Nuestro sitio web utiliza cookies para almacenar información de compras y envío. Puede encontrar más información sobre las cookies en la configuración de su navegador. Sin embargo, si continúa utilizando nuestro sitio sin cambiar la configuración, se utilizarán cookies.</p>
        </div>
        </div>
        </div>
    </div>
    <script src="ingresar_files/jquery-3.js"></script>
    <script src="ingresar_files/bootstrap.js"></script>
    <script src="ingresar_files/spin.js"></script>
    <script src="ingresar_files/ladda.js"></script>
    <script src="ingresar_files/ladda_002.js"></script>


    </form>
</body>
</html>

