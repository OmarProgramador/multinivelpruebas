<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailStore.aspx.cs" Inherits="MULTI_NIVEL.Views.DetailStore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tienda | inResorts</title>
    <link href="tienda_files/css.css" rel="stylesheet">
    <link href="tienda_files/bootstrap.css" rel="stylesheet">
    <link href="tienda_files/font-awesome.css" rel="stylesheet">
    <link href="tienda_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="tienda_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="tienda_files/chosen.css" rel="stylesheet">
    <link href="tienda_files/croppie.css" rel="stylesheet">
    <link href="tienda_files/datepicker3.css" rel="stylesheet">
    <link href="tienda_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="tienda_files/ladda-themeless.css" rel="stylesheet">
    <link href="tienda_files/sweetalert.css" rel="stylesheet">
    <link href="tienda_files/animate.css" rel="stylesheet">
    <link href="tienda_files/style.css" rel="stylesheet">
    <link rel="stylesheet" href="tienda_files/all.css" integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp" crossorigin="anonymous">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">
    
    <script src="tienda_files/bootstrap.js"></script>
    <script src="tienda_files/inspinia.js"></script>
    <script src="tienda_files/pace.js"></script>
    <script src="tienda_files/Chart.js"></script>
    <script src="tienda_files/jasny-bootstrap.js"></script>
    <script src="tienda_files/peity-demo.js"></script>
    <script src="tienda_files/datatables.js"></script>
    <script src="tienda_files/chosen.js"></script>
    <script src="tienda_files/croppie.js"></script>
    <script src="tienda_files/sweetalert.js"></script>
    <script src="tienda_files/bootstrap3-typeahead.js"></script>
    <script src="tienda_files/bootstrap-datepicker.js"></script>

</head>
<body class="top-navigation  pace-done">
    <div class="pace  pace-inactive">

        <div class="pace-progress" style="transform: translate3d(100%, 0px, 0px);" data-progress-text="100%" data-progress="99">
            <div class="pace-progress-inner"></div>
        </div>

        <div class="pace-activity"></div>
    </div>
    <form runat="server">

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
                                            <asp:Label ID="lblUser" runat="server"></asp:Label>
                                            <span class="caret"></span></a>
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
                            </asp:Panel>
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
                                            <img class="center-block img-responsive" src="img/oficinavirtualsol.png" style="margin-top: 10px; max-height: 74px" border="0">
                                        </div>
                                        <div class="col-xs-9 menu-lateral-opciones" style="display: block">
                                            <div class="col-xs-12">
                                                 <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Register.aspx">
                                                        <img src="../Resources/Images/nuevo.png" class="img-responsive center-block" border="0" />Nuevo Socio</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra " style=" width: 20% !important">
                                                    <a href="Tools.aspx">
                                                        <img src="img/universidad.png" class="img-responsive center-block height">Sistema Educativo</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Red.aspx">
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Árbol de patrocinio</a>
                                                </div>
                                                <div class=" col-xs-3 separadorbarra" style="width: 20% !important">
                                                        <a href="Bonus.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block height">Comisiones y Pagos</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                     <a href="Store.aspx">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0" />Tienda
                                                    </a>
                                                </div>


                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 20px; position: relative">
                                <div class="col-md-6">
                                    <img src="../Resources/Images/shop3.svg" class="logo-seccion" align="left">
                                    <h2 class="green"><b>Tienda</b></h2>
                                    <ol class="breadcrumb negro">
                                        <li class="breadcrumb-item">Detalle</li>

                                    </ol>
                                </div>
                                <div class="col-md-6">
                                    <div class="linkstienda visible-md visible-lg">
                                        <div class="col-md-3" style="width: 20% !important">
                                            <!-- <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1000)">
                                            <img class="center-block oficinaimg" src=" "  border="0" />
                                        </a> -->
                                            <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1)">
                                                <img class="center-block oficinaimg" src="img/oficinavirtualsol33.png" border="0">
                                            </a>
                                        </div>
                                        <div class="col-md-9 menu-lateral-opciones">
                                            <div class="row">
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Register.aspx">
                                                        <img src="tienda_files/nuevo.png" class="img-responsive center-block" border="0">Nuevo Socio</a>
                                                </div>

                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Red.aspx">
                                                        <img src="tienda_files/redes.png" class="img-responsive center-block" border="0">Árbol de patrocinio</a>
                                                </div>
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Commissions.aspx">
                                                        <img src="tienda_files/comisiones.png" class="img-responsive center-block" border="0">Mis comisiones</a>
                                                </div>
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Payments.aspx">
                                                        <img src="../Resources/Images/Payments.png" class="img-responsive center-block" border="0">
                                                        Mis Pagos</a>
                                                </div>
                                                <div class="col-md-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Store.aspx">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0">Tienda</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <ul class="list-group categoria-tienda">
                                        <%--<li class="list-group-item subrayar">MIS PAQUETES</li>
                                    <li class="list-group-item subrayar">CATEGORÍAS</li>
                                  <li class="list-group-item"><a href="">General</a></li>--%>
                                    </ul>
                                </div>



                                <div class="col-md-5">
                                    <div class="row sombra">

                                        <div class="col-md-12">
                                            <h4>Datos</h4>
                                            <hr>
                                        </div>

                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Fecha de Vigencia </label>
                                                <asp:Label ID="TxtVig" runat="server" class="form-control input-sm capitalize" type="text"/>
                                             </div>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Nombre del Pasajero </label>
                                                <asp:TextBox ID="TextName" runat="server" class="form-control input-sm capitalize"  type="text"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextName" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Codigo de Reserva </label>
                                                <asp:TextBox ID="TextCod" runat="server" class="form-control input-sm capitalize"  type="text"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TextCod" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <p></p>
                                    <span></span>
                                    <p></p>
                                </div>
                                <div class="col-md-4">
                                    <div class="">
                                        <div class="box_border m-b-md" id="prodnom" style="box-shadow: 4px 4px 12px black;">
                                            <div class="col-md-12 col-sm-4 noproducto" data-id="80">
                                                <div class="ibox-content text-center no-border">
                                                    <div class="m-b-sm text-center">
                                                        <asp:Image ID="Image1" runat="server" Width="240px" ImageAlign="TextTop" />
                                                    </div>

                                                    <center>
                                                        <asp:Label ID="titulo1" runat="server" class="">
                                                        
                                                        </asp:Label>
                                                        <br>
                                                       <%-- <asp:Label ID="precio1" runat="server" class="">
                                                        
                                                        </asp:Label>--%>
                                                       </center>


                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="ibox-content" style="margin-left: -18px; margin-right: -18px; margin-top: 30px;">
                                <div class="row sombra">
                                    <div class="col-md-6">
                                        
                                        <center>
                                            <button type="button" id="myBtn" data-toggle="modal" data-target="#myModal"
                                                    style="width: 76%;font-weight: bold;height: 40px;"
                                                    class="btn btn-xl btn-primary m-t-n-xs plomo" >REPORTAR
                                            </button>
                                        </center>
                                    </div>
                                    <div class="col-md-6">
                                        
                                        <center>
                                                <a href="Store.aspx"  class="btn btn-sm btn-primary m-t-n-xs plomo" 
                                                style="padding: 8px 40px; width: 76%;font-weight: bold;height: 40px;" >
                                                <strong>CANCELAR</strong>
                                               </a>
                                        </center>
                                    </div>
                                </div>
                                
                             
                                            <div id="myModal" class="modal">
                                                <div class="modal-content">
                                                    <span class="close" data-dismiss="modal">&times;</span>
                                                    <%--<div class="modal-header">InResorts</div>--%>
                                                    <div class="modal-header">
                                                        <img src="img/novologo.png" alt="Alternate Text" width="100" />
                                                    </div>
                                                    <div class="ps">
                                                        <p>Confirmación de compra - <asp:Label runat="server" ID="tituPaq"></asp:Label></p>
                                                        <p>Su información estará siendo validada</p>
                                                    </div>
                                                    <div class="modal-header"></div>
                                                    <center>
                                                        <asp:LinkButton class="btn" runat="server" onclick="btnComprar_Click" Text="Confirmar"> </asp:LinkButton> <%--onclick="myPay()"--%>
                                                        <button type="button" class="btn" data-dismiss="modal" > Cancelar</button> <%--onclick="myCon()"--%>
                                                    </center>
                                                </div>
                                            </div>
                                        
                            </div>
                            <br>
                            <br>
    </form>
    <style type="text/css">
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
            font-wight: bold;
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

        .close {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }

        .btn {
            height: 50px;
            text-align: center;
            font-size: 18px;
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            margin: 10px;
            margin-top: 20px;
            padding: 10px;
            font-weight: 600;
            border-radius: 6px;
            line-height: 1.3333333;
            background-color: #337ab7;
            border-color: #337ab7;
            color: white;
            cursor: pointer;
        }

            .btn:hover {
                background-color: rgb(40,96,144);
                color: white;
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
</body >
</html>
