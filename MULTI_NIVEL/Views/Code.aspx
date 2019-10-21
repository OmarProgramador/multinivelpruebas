<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Code.aspx.cs" Inherits="MULTI_NIVEL.Views.Code" %>

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

                                                          
                                <div class="row sombra">
                                    <div class="col-md-12">
                                        <h4>Generacion De Codigo <asp:Label ID="amountAPayCulqui" runat="server" ForeColor="Red" /></h4>
                                        <hr>
                                    </div>
                                    <div class="">
                                        <div class="">                              
                                           <div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Digite 6 numeros al azar</span>
                                                     <asp:TextBox ID="txtDni" runat="server" name="usuariorec"  class="input-sm form-control" Style="border: 0.5px solid #2981c5;" size="100"></asp:TextBox>
                                                </label>
                                            </div>
                                            
                                            <div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Codigo Generado</span>
                                                     <asp:TextBox ID="txtCodeView" runat="server" name="usuariorec" placeholder="" class="input-sm form-control" Style="border: 0.5px solid #2981c5;" size="100" ReadOnly="true"></asp:TextBox>
                                                </label>
                                            </div>
                                            <div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Correo</span>
                                                    <asp:TextBox ID="txtCorreo" runat="server" name="usuariorec" placeholder="" class="input-sm form-control" Style="border: 0.5px solid #2981c5;" size="30"></asp:TextBox>
                                                </label>
                                            </div>
                                            <div class="col-md-6 col-md-offset-1">
                                                
                                                <%--<asp:Button ID="btnRegistePay" runat="server" class="btn btn-sm btn-primary m-t-n-xs plomo" Text="REGISTRAR SOCIO"></asp:Button>--%>
                                               
                                                    <asp:Label ID="Label2" runat="server" ><b>Personas Registradas</b></asp:Label>
                                                    <asp:DropDownList ID="ddlPersons" runat="server" class="form-control input-sm">
                                               
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-6 col-md-offset-1">
                                                <asp:Label ID="Label3" runat="server" ><b>Descuento Orientado A :</b></asp:Label>
                                            <asp:DropDownList ID="ddlPromotion" runat="server" class="form-control input-sm">
                                            </asp:DropDownList>
                                            </div>
                                            
                                            <div class="col-md-6 col-md-offset-1">
                                                
                                                <%--<asp:Button ID="btnRegistePay" runat="server" class="btn btn-sm btn-primary m-t-n-xs plomo" Text="REGISTRAR SOCIO"></asp:Button>--%>
                                               
                                                    <asp:Label ID="Label1" runat="server" ><b>Descuento</b></asp:Label>
                                                    <asp:DropDownList ID="ddlDiscount" runat="server" class="form-control input-sm">
                                               
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Veces de usabilidad </span>
                                                     <asp:TextBox ID="txtUsability" runat="server" name="usuariorec" placeholder="" class="input-sm form-control" Style="border: 0.5px solid #2981c5;" size="30"></asp:TextBox>
                                                </label>
                                            </div>
                                            <div class="col-md-6 ">
                                                 <br>
                                                <center>
                                                 <asp:Button ID="btnCodeGenerator" runat="server" CssClass="btn btn-sm btn-primary pull-right recuperar ladda-button" Text="Generar Codigo" OnClick="CodeGenerator_Click" />
                                                
                                                </center>
                                            </div>
                                            <div class="col-md-6 ">
                                                 <br>
                                                <center>
                                                 <asp:Button ID="btnProcess" runat="server" CssClass="btn btn-sm btn-primary pull-right recuperar ladda-button" Text="Procesar" OnClick="btnProcess_Click" />
                                                
                                                </center>
                                            </div>
                                            <div class="col-md-6 " >
                                                <br>
                                                <center>
                                                   
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
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">Pago En Linea</h4>
                            </div>
                            <div class="modal-body">
                                <span id="txtMessagge"></span>
                                <center><a href="Index.aspx" class="btn btn-sm btn-primary m-t-n-xs" id="btnEnlace">Aceptar</a></center>
                            </div>
                            
                        </div>
                    </div>
                </div>
                <div class="footer footer-fondo">
                    <strong>inResorts - 2018</strong>
                </div>
            </div>
        </div>
       
    </form>
</body>
</html>

