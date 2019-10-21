<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sponsored.aspx.cs" Inherits="MULTI_NIVEL.Views.Sponsored" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lista de patrocinados | inResorts</title>
    <link href="Sponsored_files/css.css" rel="stylesheet">
    <link href="Sponsored_files/bootstrap.css" rel="stylesheet">
    <link href="Sponsored_files/font-awesome.css" rel="stylesheet">
    <link href="Sponsored_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="Sponsored_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="Sponsored_files/chosen.css" rel="stylesheet">
    <link href="Sponsored_files/croppie.css" rel="stylesheet">
    <link href="Sponsored_files/datepicker3.css" rel="stylesheet">
    <link href="Sponsored_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="Sponsored_files/ladda-themeless.css" rel="stylesheet">
    <link href="Sponsored_files/sweetalert.css" rel="stylesheet">
    <link href="Sponsored_files/animate.css" rel="stylesheet">
    <link href="Sponsored_files/style.css" rel="stylesheet">
    <link rel="stylesheet" href="Sponsored_files/all.css" integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">

    <script src="Sponsored_files/jquery-3.js"></script>
    <script src="Sponsored_files/bootstrap.js"></script>
    <script src="Sponsored_files/jquery_004.js"></script>
    <script src="Sponsored_files/jquery_010.js"></script>
    <script src="Sponsored_files/inspinia.js"></script>
    <script src="Sponsored_files/pace.js"></script>
    <script src="Sponsored_files/jquery.js"></script>
    <script src="Sponsored_files/jquery_006.js"></script>
    <script src="Sponsored_files/jquery_011.js"></script>
    <script src="Sponsored_files/Chart.js"></script>
    <script src="Sponsored_files/jasny-bootstrap.js"></script>
    <script src="Sponsored_files/jquery_003.js"></script>
    <script src="Sponsored_files/jquery_005.js"></script>
    <script src="Sponsored_files/peity-demo.js"></script>
    <script src="Sponsored_files/datatables.js"></script>
    <script src="Sponsored_files/chosen.js"></script>
    <script src="Sponsored_files/croppie.js"></script>
    <script src="Sponsored_files/sweetalert.js"></script>
    <script src="Sponsored_files/bootstrap3-typeahead.js"></script>
    <script src="Sponsored_files/jquery_008.js"></script>
    <script src="Sponsored_files/bootstrap-datepicker.js"></script>
    <script src="Sponsored_files/jquery_002.js"></script>

    <script>
        var base_url = '';
        var idsocio = 168;
        var idopera = 1;
        var nombresocio = 'Luis Alberto Ccayo';
        var direcsocio = 'Calle Hermilio Valdizan Block M Dpto 402';
        var rango = '3K';
        var simbolo = 'S/.';
        var csrfsn = '2a00bc56520a80ae85d6363a1dce5319';
        //document.addEventListener('contextmenu', event => event.preventDefault());
    </script>
    <script src="Sponsored_files/jquery_009.js"></script>
    <script src="Sponsored_files/jquery_007.js"></script>
</head>
<body class="top-navigation  pace-done">
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
            <style type="text/css">
                div.box-hr hr {
                    margin-top: 0px !important;
                }
            </style>
            <div class="wrapper-content animated fadeInUp">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="row visible-xs visible-sm linkstienda-movil">
                            <div class="linkstienda">
                                <div class="col-xs-12">
                                    <div class="col-xs-3" style="width: 20% !important">
                                        <img class="center-block img-responsive" src="img/oficinavirtualsol33.png" style="margin-top: 10px; max-height: 74px" border="0">
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
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Mi red</a>
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
                            <div class="col-md-12 col-lg-12">
                                <img src="Sponsored_files/redes.png" class="logo-seccion" align="left">
                                <h2 class="green"><b>Mi red</b></h2>
                                <ol class="breadcrumb negro">
                                        <li class="breadcrumb-item ">
                                            <a href="Red.aspx" >Arbol de Patrocinio</a>
                                        </li>
                                        <li class="breadcrumb-item">
                                            <a href="ResidualTree.aspx">Arbol residual</a>
                                        </li>
                                        <li class="breadcrumb-item active">
                                            <a href="Sponsored.aspx" class="subrayar">Lista de Patrocinados</a>
                                        </li>
                                       
                                        <li class="breadcrumb-item">
                                            <a href="Placement.aspx">Placement</a>
                                        </li>
                                        <li class="breadcrumb-item">
                                            <a href="Promotores.aspx">Promotores</a>
                                        </li>
                                        <li class="breadcrumb-item ">
                                            <a href="HistoryRange.aspx">Historial de rangos</a>
                                        </li>
                                    </ol>
                            </div>
                            <div class="col-md-6">
                                <div class="linkstienda visible-md visible-lg" style="background-color: white;">
                                    <div class="col-md-3" style="width: 20% !important">
                                        <!-- <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1000)">
														<img class="center-block oficinaimg" src=" "	border="0" />
													</a> -->
                                        <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1)">
                                            <img class="center-block oficinaimg" src="img/oficinavirtualsol33.png" border="0">
                                        </a>
                                    </div>
                                    <div class="col-md-9 menu-lateral-opciones">
                                        <div class="row">
                                           <div class="col-md-2 separadorbarra" style="z-index: 100;">
                                            <a href="Register.aspx">
                                                <img src="../Resources/Images/nuevo.png" class="img-responsive center-block height">Nuevo Socio</a>
                                        </div>
                                         <div class=" col-md-2 separadorbarra " style="z-index: 100;">
                                            <a href="Tools.aspx">
                                                <img src="img/universidad.png" class="img-responsive center-block height">Sistema Educativo</a>
                                        </div>
                                        <div class="col-md-2  separadorbarra " style="z-index: 100;">
                                            <a href="Red.aspx">
                                                <img src="../Resources/Images/redes.png" class="img-responsive center-block height">Mi red</a>
                                        </div>
                                        <div class="  col-md-2 separadorbarra ">
                                            <a href="Bonus.aspx">
                                                <img src="../Resources/Images/comisiones.png" class="img-responsive center-block height">Comisiones y Pagos</a>
                                        </div>
                                        <div class="col-sm-1 col-md-2 separadorbarra ">
                                           <a href="Store.aspx">
                                                        <img src="../Resources/Images/shop3.svg" class="img-responsive center-block" border="0" />Tienda
                                                    </a>
                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row box-hr">
                            <hr>
                        </div>
                        <div class="m-b-md" style="overflow: hidden;">
                            <div class="pull-left">
                                Información actualizada al: <asp:Label ID="lblDate" style="font-weight:bold;" runat="server" />
                            </div>
                        </div>
                        <div class="table-responsive m-t">
                            <%--<table class="">
                                <thead>
                                    <tr>
                                        <th>Nombre y apellidos</th>
                                        <th>DNI</th>
                                        <th>Rango</th>
                                        <th>Estado</th>
                                        <th>Nivel</th>
                                        <th>Rama</th>
                                        <th>Patrocinador Personal</th>
                                        <th>Upline</th>
                                        <th>Prox. Vencimiento de Cuota</th>
                                        <th>Puntos Personales</th>
                                        <th>Activo hasta</th>
                                    </tr>
                                </thead>
                                <tbody>
                                   
                                    <tr class="">
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    
                                    
                                </tbody>
                            </table>--%>
                             <p class="blue">
                                    <b>Tu Rango Actual es: 
                                     <asp:Label ID="RangoSoc" runat="server"></asp:Label></b>
                                </p>
                            <asp:GridView ID="gvSponsor" runat="server" CssClass="table table-bordered tblListaPatrocinados" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Id" ControlStyle-CssClass="" Visible="false"/>
                                    <asp:BoundField DataField="NAsociate" HeaderText="N° Socio" />
                                    <asp:BoundField DataField="FAfiliacion" HeaderText="F. Afiliación" />
                                    <asp:BoundField DataField="name" HeaderText="Name" />
                                    <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                    <asp:BoundField DataField="Rango" HeaderText="Rango" />
                                    <asp:BoundField DataField="Rango" HeaderText="Premio" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="NivelP" HeaderText="Nivel Patrocinio" />
                                    <asp:BoundField DataField="Nivel" HeaderText="Nivel Residual" />
                                    <asp:BoundField DataField="Rama" HeaderText="Rama" />
                                    <asp:BoundField DataField="PatrocinadorP" HeaderText="PatrocinadorP" />
                                    <asp:BoundField DataField="Upline" HeaderText="Upline" />
                                    <asp:BoundField DataField="ProximaCuota" HeaderText="ProximaCuota" />
                                    <asp:BoundField DataField="Puntos" HeaderText="Puntos De Equipo" />
                                    <asp:BoundField DataField="ActivoHasta" HeaderText="ActivoHasta" />
                                    <asp:BoundField DataField="CalPuntos" HeaderText="Puntos Individuales" />
                                    <asp:BoundField DataField="TotalAmort" HeaderText="Total En Pago De  Amortizacion" />
                                    <asp:BoundField DataField="TotalQuote" HeaderText="Total En Pago De Cuota" />
                                    <asp:BoundField DataField="TotalAff" HeaderText="Total En Pago De Afiliacion" />
                                   
                                </Columns>

                            </asp:GridView>


                            <div class="floatleft">
                                <p class="blue">
                                    <%--Numero de afiliados en la Red:--%>
                                        <asp:Label ID="totalAfi" runat="server"></asp:Label>
                                </p>
                                <p class="blue">
                                    <%--La rama mas Fuerte :--%>
                                    <asp:Label ID="ramaFuerte" runat="server"></asp:Label>
                                   
                                    <asp:Label ID="totalAfiRamF" runat="server"></asp:Label>
                                    <%--afiliados)--%>
                                </p>
                               <div class="blue">
                                <p class="blue">
                                    <%--Puntos Totales de su Red--%>
                                     <asp:Label ID="PuntosRF" runat="server"></asp:Label>
                                </p>
                                   <p class="blue" style="display:none">
                                    <%--Puntos Rama Fuerte--%>
                                     <asp:Label ID="ptosRF" runat="server"></asp:Label>
                                </p>
                                   <p class="blue">
                                   <%-- Sus puntos :--%>
                                     <asp:Label ID="PuntosSocio" runat="server"></asp:Label>
                                </p>
                                  
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer footer-fondo">
                <strong>inResorts - 2018</strong>
            </div>
        </div>
    </div>
    <a id="scrollUp" href="#top" title="Scroll to top" style="position: fixed; z-index: 2147483647; display: none;"></a>
    <script type="text/javascript">
        $(window).bind('scroll', function () {
            if ($(window).scrollTop() > 180) { $('#scrollUp').fadeIn('slow'); } else { $('#scrollUp').fadeOut('slow'); }
        });

        $("a[href='#top']").click(function () {
            $("html, body").animate({ scrollTop: 0 }, "slow");
            return false;
        });
    </script>

</form>
</body>
</html>
