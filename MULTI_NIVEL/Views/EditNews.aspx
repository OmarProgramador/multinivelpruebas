<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditNews.aspx.cs" Inherits="MULTI_NIVEL.Views.EditNews" %>

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
    <script src="Script/Script.js"></script>
    <script src="https://checkout.culqi.com/v2"></script>
    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>
</head>
<body class="top-navigation pace-done">
   
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
                                    </li>
                                    <li class="dropdown">
                                    
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

                                                          
                                <div class="row sombra">
                                    <div class="col-md-12">
                                        <h4>Editar Noticia <asp:Label ID="amountAPayCulqui" runat="server" ForeColor="Red" /></h4>
                                        <hr>
                                    </div>
                                    <div class="">
                                        <div class="">     
                                            <div class="col-md-8 col-md-offset-1">
                                               
                                                     <asp:Image ID="file_upload" runat="server" class="img-responsive"></asp:Image>
                                                      
                                            </div>
                                            <div class="col-md-8 col-md-offset-1">
                                               
                                                     <asp:FileUpload ID="FileUpload1" runat="server" style=" font-size: 10px;"></asp:FileUpload>
                                                      
                                            </div>

                                           <div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Titulo</span>
                                                     <asp:TextBox ID="txtTitu" runat="server" name="usuariorec"  class="input-sm form-control" Style="border: 0.5px solid #2981c5;" size="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtTitu" ForeColor="Red"> </asp:RequiredFieldValidator>
                                                    </label>
                                            </div>
                                            <%--<div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Subtitulo</span>
                                                     <asp:TextBox ID="txtSub" runat="server" name="usuariorec"  class="input-sm form-control" Style="border: 0.5px solid #2981c5;" size="100"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtSub" ForeColor="Red"> </asp:RequiredFieldValidator>

                                                    </label>
                                            </div>--%>
                                         
                                            <div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Contenido</span>
                                                    <asp:TextBox ID="txtCont" runat="server" name="usuariorec" placeholder="" class="input-sm form-control" Style="border: 0.5px solid #2981c5;height:100px " size="100;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtCont" ForeColor="Red"> </asp:RequiredFieldValidator>

                                                    </label>
                                            </div>
                                       
                                            </div>
                                            

                                         <div class="col-md-8 col-md-offset-1">
                                                <label>
                                                    <span>Fecha</span>
                                                     <asp:Label ID="txtFecha" runat="server"   class="input-sm form-control" Style="border: 0.5px solid #2981c5;" ></asp:Label>
                                                </label>
                                            </div>
                                        
                                          
                                           
                                            <div class="col-md-6 ">
                                                 <br>
                                                <center>
                                                 <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-md btn-primary recuperar ladda-button" Text="Guardar" OnClick="btnEditar_Click"  />
                                                
                                                </center>
                                            </div>
                                         <div class="col-md-6 ">
                                                 <br>
                                                <center>
                                                 <button ID="btnCancelar" class="btn btn-md btn-primary recuperar ladda-button" value="Cancelar" onclick="RegisterNews.aspx" ><%--onclick="history.Back();return 0;"--%>
                                                     Cancelar</button>
                                                
                                                </center>
                                            </div>
                                          <div class="col-md-12 ">
                                                 
                                                <center>
                                               <asp:Label ID="lblErrorSi" runat="server" ForeColor="Blue" />
                                                </center>
                                            </div>
                                      
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="footer-fondo">
                    <strong>inResorts - 2018</strong>
                </div>
            </div>
        
     
       <script src="Script/ScriptEditNews.js"></script>
    </form>
</body>
</html>
