<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="travelagency.aspx.cs" Inherits="MULTI_NIVEL.Views.travelagency" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Agencia de Viajes | inResorts </title>

    <link href="Css/css.css" rel="stylesheet" />

    <link href="editar_files/font-awesome.css" rel="stylesheet">
    <link href="editar_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="editar_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="editar_files/chosen.css" rel="stylesheet">
    <link href="editar_files/croppie.css" rel="stylesheet">
    <link href="editar_files/datepicker3.css" rel="stylesheet">
    <link href="editar_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="editar_files/ladda-themeless.css" rel="stylesheet">
    <link href="editar_files/sweetalert.css" rel="stylesheet">
    <link href="editar_files/animate.css" rel="stylesheet">
    <link href="editar_files/style.css" rel="stylesheet">
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">

    <link href="Css/all.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/MyStyle.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"
        rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN"
        crossorigin="anonymous">
    <script src="editar_files/jquery-3.js"></script>
    <script src="editar_files/bootstrap.js"></script>
    <script src="editar_files/jquery_004.js"></script>
    <script src="editar_files/jquery_010.js"></script>
    <script src="editar_files/inspinia.js"></script>
    <script src="editar_files/pace.js"></script>
    <script src="editar_files/jquery.js"></script>
    <script src="editar_files/jquery_006.js"></script>
    <script src="editar_files/jquery_011.js"></script>
    <script src="editar_files/Chart.js"></script>
    <script src="editar_files/jasny-bootstrap.js"></script>
    <script src="editar_files/jquery_003.js"></script>
    <script src="editar_files/jquery_005.js"></script>
    <script src="editar_files/peity-demo.js"></script>
    <script src="editar_files/datatables.js"></script>
    <script src="editar_files/chosen.js"></script>
    <script src="editar_files/croppie.js"></script>
    <script src="editar_files/sweetalert.js"></script>
    <script src="editar_files/bootstrap3-typeahead.js"></script>
    <script src="editar_files/jquery_008.js"></script>
    <script src="editar_files/bootstrap-datepicker.js"></script>
    <script src="editar_files/jquery_002.js"></script>

    <script src="editar_files/jquery_009.js"></script>
    <script src="editar_files/jquery_007.js"></script>
    <script src="Script/Script.js"></script>

</head>
<body class="top-navigation  pace-done">
    <form id="form1" runat="server">
        <div class="pace  pace-inactive">
            <div class="pace-progress" style="transform: translate3d(100%, 0px, 0px);" data-progress-text="100%" data-progress="99">
                <div class="pace-progress-inner"></div>
            </div>
            <div class="pace-activity"></div>
            <div id="extwaiimpotscp" style="display: none" v="{5776" f="ZXpVM056WmlaRGt3TFROa01Ea3RORE5pTlMxaE56WTVMVGhrWVRNM00yVTVPREl3Wm4wPQ==" q="94d64129" c="11.08" i="15.08" u="0.334" s="67b82340" w="false" vn="0tres"></div>
        </div>
        <!-- Loading -->
        <div class="loading">
            <div class="load">
                <div class="sk-spinner sk-spinner-fading-circle">
                    <div class="sk-circle1 sk-circle"></div>
                    <div class="sk-circle2 sk-circle"></div>
                    <div class="sk-circle3 sk-circle"></div>
                    <div class="sk-circle4 sk-circle"></div>
                    <div class="sk-circle5 sk-circle"></div>
                    <div class="sk-circle6 sk-circle"></div>
                    <div class="sk-circle7 sk-circle"></div>
                    <div class="sk-circle8 sk-circle"></div>
                    <div class="sk-circle9 sk-circle"></div>
                    <div class="sk-circle10 sk-circle"></div>
                    <div class="sk-circle11 sk-circle"></div>
                    <div class="sk-circle12 sk-circle"></div>
                </div>
                <div>Espere por favor...</div>
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
                                                <a href="Edit.aspx" class="btn btn-primary btn-sm block" style="background-color:black;border-radius:5px">Cuenta</a>
                                            </p>
                                            <p class="col-md-6">

                                                <a href="#" class="btn btn-primary btn-sm block" style="background-color:black;border-radius:5px">Cambiar Clave</a>
                                            </p>
                                            <center>
                                        <p class="col-md-12">
                                            <asp:LinkButton ID="lblSalir" runat="server" OnClick="lblSalir_Click" CssClass="btn btn-primary block" Text="Salir"  style="background-color:black;border-radius:5px;padding-left: 0;"></asp:LinkButton>
                                        </p>
                                        </center>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </nav>
                </div>
                <div class="wrapper wrapper-content animated fadeInUp">
                    <div class="container">
                        <div class="ibox float-e-margins">
                            <div class="ibox-content">
                                <h2>Datos del Nuevo Cliente</h2>
                                <hr>
                                <div class="row">
                                    <div class="col-md-12"></div>
                                </div>
                                <div class="tabs-container">
                                    <ul class="nav nav-tabs">
<%--                                        <li class=""><a class="cabecera" data-toggle="tab" href="#tab-1">Datos de la cuenta</a></li>--%>
                                        <%--<li class=""><a class="cabecera" data-toggle="tab" href="#tab-2">Datos personales</a></li>
                                        <li class=""><a class="cabecera" data-toggle="tab" href="#tab-3">Datos bancarios</a></li>
                                        <li class=""><a class="cabecera" data-toggle="tab" href="#tab-4">Documentos</a></li>--%>
                                        <li class="active"><a class="cabecera" data-toggle="tab" href="#tab-2">Clientes</a></li>
                                    </ul>
                                    <div class="tab-content">
                                        
                                       
                                        <%--<div id="tab-1" class="tab-pane">
                                            <div class="panel-body">
                                                <div class="row">

                                                    <input type="hidden" name="csrfsn" value="f2d9cb208c6c33388205f6a63d0261a9">
                                                    <div class="col-sm-12">
                                                        <div class="form-group">
                                                            <label>
                                                                El pago de comisiones será transferido en Soles para el caso de Perú. 
                                                Para otros países será transferido en dólares USD.
                                                Es requerido que el número de cuenta suministrado por usted sea 
                                                una cuenta en función a la moneda a recibir.
                                                            </label>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <label>Nombre del Banco</label>
                                                            <asp:DropDownList ID="ddlBanck" runat="server" class="form-control input-sm" name="tipodoc">
                                                                <asp:ListItem Value="" Selected="True">Seleccione...</asp:ListItem>

                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <label>Nombre del titular de cuenta bancaria:</label>
                                                            <asp:TextBox ID="txtNameTitularCuentaBan" runat="server" placeholder="Nombres" class="form-control input-sm capitalize"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <label class="titulo">Tipo de Cuenta:</label>
                                                            <div class="radio radio-inline text-left">
                                                                <asp:RadioButton ID="rbCuentaCo" runat="server" GroupName="Cuenta" value="C" Checked></asp:RadioButton>
                                                                <label for="rbCor">Cuenta Corriente</label>
                                                            </div>
                                                            <div class="radio radio-inline text-left">
                                                                <asp:RadioButton ID="rbCuentaAH" runat="server" GroupName="Cuenta" value="A"></asp:RadioButton>
                                                                <label for="rbAho">Cuenta de Ahorros</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <label>Número de Cuenta:</label>
                                                            <asp:TextBox ID="txtNumCuenta" runat="server" placeholder="Número de Cuenta" class="form-control input-sm capitalize"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                           
                                                
                                                <%--<div class="row">
                                                    <div class="text-center">
                                                        <br />
                                                        <asp:Label ID="lblMessaggeBank" runat="server" ForeColor="Red" Style="font-weight: bold;" />
                                                        <br />
                                                        <br />
                                                        <button onclick="history.back();return;" class="btn btn-secondary">Cancelar</button>
                                                        <asp:Button ID="btnSaveDataBank" Text="Guardar" runat="server" CssClass="btn btn-primary" OnClick="btnSaveDataBank_Click" />
                                                    </div>
                                                </div>--%>
                                            </div>
                                        </div>
                                       <%--  <div id="tab-4" class="tab-pane">
                                            <div class="panel-body">
                                                <div class="row">

                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <label>Nombre del Documento</label>

                                                        </div>
                                                    </div>


                                                </div>
                                                <div class="row">
                                                    <div id="listDoc" class="col-sm-6">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div id="tab-2" class="tab-pane">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <input id="NuevoBeneficiario" type="button" name="name" value="Nuevo Cliente" 
                                                            data-toggle="modal" data-target="#beneficiarioModalCenter" class="btn btn-primary" />
                                                    </div>
                                                </div>
                                                <div class="row display-none" id="divMessagge">
                                                    <div class="col-sm-12">
                                                        <div class="alert alert-success" role="alert">
                                                            <span id="messagge"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <div id="listBeneficiarios"></div>
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
                <style type="text/css">
                    .btn-default, .btn-default:hover {
                        color: #000;
                    }
                </style>


                <div class="footer footer-fondo">
                    <strong>Ribera del Rio - 2018</strong>
                </div>
           

        <div class="modal fade" id="beneficiarioModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="exampleModalCenterTitle">Nuevo Cliente</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">                        
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Nombres</label>
                                    <input id="NameCli" type="text" name="name" value="" class="form-control" />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Apellidos</label>
                                    <input id="ApeCli" type="text" name="name" value="" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Telèfono</label>
                                    <input id="DocBenef" type="text" name="name" value="" class="form-control" />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Correo</label>
                                    <input id="ParentescoBenef" type="text" name="name" value="" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <%--<div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Tipo</label>
                                    <select id="TypeBenef" class="form-control">
                                        <option value="">--Seleccionar--</option>
                                        <option value="0">Directo</option>
                                        <option value="1">Adicional</option>
                                    </select>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button id="GuardarBenef" type="button" class="btn btn-primary">Guardar Cambios</button>
                    </div>
                </div>
            </div>
        </div>

        <a id="scrollUp" href="#top" title="Scroll to top" style="position: fixed; z-index: 2147483647;"></a>
        <script type="text/javascript">
            $(window).bind('scroll', function () {
                if ($(window).scrollTop() > 180) { $('#scrollUp').fadeIn('slow'); } else { $('#scrollUp').fadeOut('slow'); }
            });

            $("a[href='#top']").click(function () {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                return false;
            });
        </script>
        <script src="Script/ScriptEdit.js"></script>
    </form>
</body>
</html>










