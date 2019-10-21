<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="MULTI_NIVEL.Views.News" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Noticias | inResorts</title>
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
   
    <form id="form" runat="server">
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
                            <ul class="nav navbar-top-links navbar-right">
                                <li>
                                    <asp:image id="imgProfile" runat="server" alt="..." cssclass="img-circle img-responsive img-user" />
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle userClass" data-toggle="dropdown" role="button" aria-expanded="false">
                                        <asp:label id="lblUser" runat="server"></asp:label>
                                        <span class="caret"></span></a>
                                    <ul class="dropdown-menu detalle-user" role="menu">
                                        <li>
                                            <div class="floatleft">
                                                <asp:image id="imgProfileFl" runat="server" alt="..." class="img-circle img-responsive img-user1" />
                                            </div>
                                            <div class="floatleft">
                                                <p>
                                                    <strong>
                                                        <asp:label id="lblUserName" runat="server"></asp:label>
                                                    </strong>
                                                </p>
                                                <p class="green">
                                                    <asp:label id="lblNumPartner" runat="server"></asp:label>
                                                </p>
                                            </div>
                                        </li>
                                        <li class="divider"></li>
                                        <li>
                                            <p class="col-md-6">
                                                <a href="Edit.aspx" class="btn btn-primary btn-sm block">Cuenta</a>
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
                        </div>
                    </nav>
                </div>


                <div class="wrapper-content animated fadeInUp">
                    <div class="ibox float-e-margins">
                        <div class="ibox-content">
                            <div class="row visible-xs visible-sm linkstienda-movil">
                                <div class="linkstienda">
                                    <div class="col-xs-12">
                                        <div class="col-xs-3" style="width: 20% !important">
                                            <img class="center-block img-responsive" src="img/oficinavirtualsol.png" style="margin-top: 10px; max-height: 74px" border="0" />
                                        </div>
                                        <div class="col-xs-9 menu-lateral-opciones" style="display: block">
                                            <div class="col-xs-12">
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Register.aspx">
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block" border="0" />Nuevo Socio</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Red.aspx">
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Mi red</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Commissions.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block" border="0" />Mis comisiones</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Payments.aspx">
                                                        <img src="../Resources/Images/Payments.png" class="img-responsive center-block" border="0" />Mis Pagos</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Store.aspx">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0" />
                                                        Tienda</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>








                            <div class="row" style="padding-bottom: 20px; position: relative">
                                <div class="col-md-6">
                                    <img id="pot" src="img/news.png" class="logo-seccion" align="left" />
                                    <h2 class="green"><b>Noticias</b><h2>
                                        <ol class="breadcrumb negro">
                                            <li class="breadcrumb-item active"><a href="News.aspx" class="subrayar">Noticias</a></li>
                                           <%-- <li class="breadcrumb-item"><a>Documentos</a></li>--%>
                                        </ol>
                                </div>
                                <div class="col-md-6">
                                    <div class="linkstienda visible-md visible-lg">
                                        <div class="col-md-3" style="width: 20% !important">
                                            <!-- <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1000)">
														<img class="center-block oficinaimg" src=""	border="0" />
													</a> -->
                                            <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1)">
                                                <img class="center-block oficinaimg" src="img/oficinavirtualsol.png" border="0">
                                            </a>
                                        </div>
                                        <div class="col-md-9 menu-lateral-opciones">
                                            <div class="row">
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Register.aspx">
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block" border="0">Nuevo Socio</a>
                                                </div>
                                                <%-- <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="#">
                                                        <img src="comisiones_files/tienda.png" class="img-responsive center-block" border="0">Tienda</a>
                                                </div>--%>
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Red.aspx">
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Mi red</a>
                                                </div>
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Commissions.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block" border="0" />Mis comisiones</a>
                                                </div>
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Payments.aspx">
                                                        <img src="../Resources/Images/Payments.png" class="img-responsive center-block" border="0" />
                                                        Mis Pagos</a>
                                                </div>
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Store.aspx">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0" />
                                                        Tienda</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row box-hr">
                                <hr>
                            </div>

                             <div id="dataList">

                             </div>

                             <div class="modal fade" id="enlargeImageModal" style="margin-top: 100px;" tabindex="-1" role="dialog" aria-labelledby="enlargeImageModal" aria-hidden="true">
                                <div class="modal-dialog modal-lg" role="document">
                                  <div class="modal-content">
                                    <div class="modal-header" style="padding: 12px;border-bottom: none">
                                      <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                          <span aria-hidden="true" style="font-size:27px" >×</span></button>
                                    </div>
                                    <div class="modal-body" style="padding: 9px 21px 30px 21px;">
                                      <img src="" class="enlargeImageModalSource" style="width: 100%;">
                                    </div>
                                  </div>
                                </div>
                            </div>
                            <%--<div class="panel-group" id="accordion">
                                <div class="panel panel-default">
                                    <div style="padding: 5px; margin: 5px auto">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
                                            <div style="display: flex">
                                                <img src="img/oferta.png" style="width: 250px; margin: 10px; padding: 10px" />
                                                <div class="panel-heading btn btn-block " style="text-align: start; color: white; width: 100%; font-size: 16px; margin: 10px; background-color: rgb(100,116,140)">
                                                    <h2><b>Descuento de Membresias por Navidad </b></h2><br/>
                                                    <span>Estamos de Fiesta y lo celebramos dando los mejores descuentos</span>
                                                </div>
                                            </div>
                                        </a>
                                        <div id="collapse1" class="panel-collapse collapse">
                                            <div class="panel-body" style="margin-right: 9px; margin-left: 9px;">
                                                <div class=" " id="cssbox">
                                                    <div class="row sombra">

                                                        <div id="divStarterKithh" class="row minimalSpacing">
                                                            <div class="col-md-12">
                                                                <div class="csspqts" style="">
                                                                    <div class="panel-heading">
                                                                        <h2><strong>
                                                                                <span style="color: black" id="lblStartedrKit">Detalles 1</span>
                                                                        </strong></h2>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                       
                        </div>
                    </div>
                </div>

                <div class="footer footer-fondo">
                    <strong>inResorts - 2018</strong>
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
                <script>

                    
               </script>


    </form>

    <script src="Script/ScriptNews.js"></script>
     <script>
        if (1 == 1) {
            document.getElementById('des').style.display = 'none';
        }

    </script>
</body>
</html>
