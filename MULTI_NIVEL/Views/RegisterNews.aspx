<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterNews.aspx.cs" Inherits="MULTI_NIVEL.Views.RegisterNews" %>

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
    
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <link href="tienda_files/font-awesome.css" rel="stylesheet">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
        
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>  

    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>
    <script src="Script/Script.js"></script>

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
                            
                            <a href="Index.aspx" class="navbar-brand inicio-logo">
                                <img src="img/novologo.png" class="img-responsive"></a>
                        </div>
                         
                    </nav>
                </div>
                 
                 
                <div class="wrapper wrapper-content animated fadeInUp nuevosocio">
                    <div class="contenedor container">
                        <div class="ibox float-e-margins">
                            <div class="ibox-content">
                                <br />          
                                <div class="row sombra">
                                    <div class="col-md-12">
                                        <h3>Generar Noticia <asp:Label ID="amountAPayCulqui" runat="server" ForeColor="Red" /></h3>
                                        <hr>
                                    </div>
                                    <div class="">
                                        <div class="">                              
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
                                                    <span>Imagen</span>
                                                     <asp:FileUpload ID="file_upload" runat="server" style=" font-size: 10px;"></asp:FileUpload>
                                                </label>
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
                                                 <asp:Button ID="btnProcess" runat="server" CssClass="btn btn-md btn-primary recuperar ladda-button" Text="Generar" OnClick="btnProcess_Click"  />
                                                
                                                </center>
                                            </div>
                                         <div id="desapa" class="col-md-6 ">
                                                 <br>
                                                <center>
                                                 <a ID="btnCancelar" class="btn btn-md btn-primary recuperar ladda-button" href="MenuBackend.aspx" ><%--onclick="history.Back();return 0;"--%>
                                                     Cancelar</a>
                                                
                                                </center>
                                            </div>
                                        <%-- <div id="desapa" class="col-md-6 ">
                                                 <br>
                                                <center>
                                                 <asp:Button ID="btnEliminar" class="btn btn-md btn-primary recuperar ladda-button" onClick="btnEliminar_Click" >
                                                     Eliminar</asp:Button>
                                                
                                                </center>
                                            </div>--%>
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

                <div id="dataList">

                </div>

                        <div id="myModal" class="modal">
                            <div class="modal-content">
                                <span class="close" data-dismiss="modal">&times;</span>
                                <%--<div class="modal-header">InResorts</div>--%>
                                <div class="modal-header">
                                    <img src="img/novologo.png" alt="Alternate Text" width="100" />
                                </div>
                                <div class="ps">
                                    <p>¿Seguro que desea eliminar la noticia?</p>
                            <%--  <asp:Label ID="lbltitulo" runat="server"  class="input-sm form-control" Style="border: 0.5px solid #2981c5;" size="100"></asp:Label>--%>

                                    <p>Numero de Codigo: </p>
                                    <span id="idNewsDelete"></span>
                                </div>
                                <div class="modal-header"></div>
                                <center>
                                    
                                    <input type="button"  value="Aceptar" id="btnAceptar" onclick="DeleteNews()"/>
                                    <button type="button" class="btn" data-dismiss="modal" > Cancelar</button> <%--onclick="myCon()"--%>
                                </center>
                            </div>
                        </div>

            </div>
       
         <style>
                    @media (min-width: 750px) {
                        #costado{
                            display: flex;
                        }
                        #img{
                            width:220px;
                            height:150px;
                            margin: 0px auto;
                            border-radius: 8px;
                            box-shadow: -4px 5px 10px grey;
                        }
                    }
                    @media (max-width: 750px) {
                        #costado{
                            display: block;
                            white-space: normal;
                            
                        }
                        h2{
                            font-size:18px;
                        }
                        #img{
                             box-shadow: -4px 5px 10px grey;
                             width: 95%;
                            margin: 2px 10px;
                            border-radius: 8px;
                            
                        }
                        .sombra{
                                padding: 5px;
                        }
                        .t1{
                            margin: 10px 10px;
                        }
                    }
                </style>


        
    </form>
    <div class=" footer-fondo">
          <strong>inResorts - 2018</strong>
    </div>
    <script src="Script/ScriptNews.js"></script>


    <style>
        @media only screen and (min-width:800px){
            .bontoncito{
                width: 60%;
            }
            .bot{
                    border-radius: 23px;
                    margin-top: 21px;
                    background-color: #fffefe;
                    border: 1px solid black;
                    font-weight: bold;
                    color: black;
                    width: 204px;
                    height: 32px;
                    box-shadow: 3px 4px 4px 0px #a2a7b3;
            }
        }
         @media only screen and (max-width:800px){
            .bontoncito{
                width: 60%;
            }
            .bot{
                    border-radius: 23px;
                    margin-top: 21px;
                    background-color: #fffefe;
                    border: 1px solid black;
                    font-weight: bold;
                    color: black;
                        width: 120px;
                    height: 32px;
                    box-shadow: 3px 4px 4px 0px #a2a7b3;
            }
        }
        .modal {
            display: none;
            position: fixed;
            z-index: 1;
            padding-top: 130px;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto;
            background-color: rgb(0,0,0);
            background-color: rgba(0,0,0,0.4);
        }
           .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 90%;
            border-radius: 8px;
            font-family: sand-serif;
            box-shadow: 4px 4px 25px black;
        }
            .modal-header {
            text-align: center;
            justify-content: center;
            padding: 1rem;
            font-size: 32px;
            border-bottom: 1px solid #d9ecef;
            border-top-left-radius: .3rem;
            border-top-right-radius: .3rem;
            color: #337ab7;
        }
              .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }
               .ps {
            text-align: center;
            margin: 25px;
            font-size: 24px;
            color: #337ab7;
        }
    </style>
     <script type="text/javascript">
         
            var modal = document.getElementById('myModal');
            var btn = document.getElementById("myBtn");
            var span = document.getElementsByClassName("close")[0];
            btn.onclick = function () {
                modal.style.display = "block";
            }
            span.onclick = function () {
                modal.style.display = "none";
            }
            window.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                }
            }
    </script>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</html>

