<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MULTI_NIVEL.Views.Edit" %>

<!DOCTYPE html>
<html>
<head>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <link href="home_files/croppie.css" rel="stylesheet" />
    <script src="home_files/croppie.min.js"></script>
    <%--<script src="home_files/subir.php"></script>--%>

    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="Expires" content="-1">
    <meta http-equiv="Last-Modified" content="0">
    <meta http-equiv="Cache-Control" content="no-cache, mustrevalidate">
    <meta http-equiv="Pragma" content="no-cache">
    <title>Editar Socio | inResorts </title>

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

    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
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
    <style>
        .text-bold {
            font-weight: 700;
        }
    </style>
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
        <div id="divProgressBar" >
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
                                    <asp:Image ID="imgProfile" Style="width: 40px; height: 40px; margin: auto;" runat="server" alt="..." CssClass="img-circle img-responsive img-user" />
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle userClass" data-toggle="dropdown" role="button" aria-expanded="false">
                                        <asp:Label ID="lblUser" runat="server"></asp:Label><span class="caret"></span></a>
                                    <ul class="dropdown-menu detalle-user" role="menu">
                                        <li>
                                            <div class="floatleft">
                                                <asp:Image ID="imgProfileFl" Style="width: 77px; height: 77px; margin: auto;" runat="server" alt="..." class="img-circle img-responsive img-user1" />
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
                                                <a href="Edit.aspx" class="btn btn-primary btn-sm block" style="background-color: black; border-radius: 5px">Cuenta</a>
                                            </p>
                                            <p class="col-md-6">

                                                <a href="#" class="btn btn-primary btn-sm block" style="background-color: black; border-radius: 5px">Cambiar Clave</a>
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
                                <h3>Datos del Socio</h3>
                                <hr>
                                <div class="row">
                                    <div class="col-md-12"></div>
                                </div>
                                <div class="tabs-container">
                                    <ul class="nav nav-tabs">
                                        <li class="active"><a class="cabecera" data-toggle="tab" href="#tab-1">Datos de la cuenta</a></li>
                                        <li class=""><a class="cabecera" data-toggle="tab" href="#tab-2">Datos personales</a></li>
                                        <li class=""><a class="cabecera" data-toggle="tab" href="#tab-3">Datos bancarios</a></li>
                                        <li class=""><a class="cabecera" data-toggle="tab" href="#tab-4">Documentos</a></li>
                                        <li class=""><a class="cabecera" data-toggle="tab" href="#tab-5">Beneficiarios</a></li>
                                        <li class=""><a class="cabecera" data-toggle="tab" href="#tab-6">Informacion de la Empresa</a></li>
                                    </ul>
                                    <div class="tab-content">
                                        <div id="tab-1" class="tab-pane active">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Usuario</label>
                                                            <%-- <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control read-only" MaxLength="15"></asp:TextBox>--%>
                                                            <asp:Label ID="txtUserName" runat="server" CssClass="form-control read-only" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Patrocinador</label>
                                                            <%--<asp:TextBox ID="txtSponsor" runat="server" CssClass="form-control read-only"></asp:TextBox>--%>
                                                            <asp:Label ID="txtSponsor" CssClass="form-control read-only" Text="" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group display-none">
                                                            <label>Upline</label>
                                                            <%--<asp:TextBox ID="txtUpline" runat="server"  CssClass="form-control read-only"></asp:TextBox>--%>
                                                            <asp:Label ID="txtUpline" CssClass="form-control read-only" Text="" runat="server" />
                                                        </div>
                                                    </div>



                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Nueva clave</label>
                                                            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="form-control input-sm" requerid></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPass" runat="server" ErrorMessage="Campo Obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Repetir clave</label>
                                                            <asp:TextBox ID="txtPass2" runat="server" TextMode="Password" placeholder="Rep. Contraseña" class="form-control input-sm" requerid></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPass2" runat="server" ErrorMessage="Campo Obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPass2" ControlToCompare="txtPass" Operator="Equal" ErrorMessage="Las Contraseñas no coinciden" ForeColor="Red"></asp:CompareValidator>
                                                            --%>
                                                        </div>
                                                    </div>

                                                    <br />
                                                    <br />
                                                    <div class="col-md-12 text-center">
                                                        <br>
                                                        <a href="Index.aspx" class="btn btn-secondary pull-center m-t-n-xs plomo">Cancelar</a>
                                                        <asp:Button ID="btnSaveDataAccount" runat="server" CssClass="btn  btn-primary pull-center m-t-n-xs plomo" Text="Guardar" OnClick="btnSaveDataAccount_Click"></asp:Button>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group ">
                                                            <h3>Foto de Perfil</h3>
                                                            <hr>
                                                        </div>

                                                        <%--Aqui coloco el modal para subir imagen y darle ajuste a uso de usuario - Alex--%>

                                                        <asp:Panel runat="server" ID="panel" class="row col-sm-12">
                                                            <br />
                                                            <%--<h3 align="center">Subir nueva foto de perfil</h3>--%>
                                                            <%--<br />
                                                          <br />--%>
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading">Seleccionar nueva imagen </div>
                                                                <div class="panel-body" align="center">

                                                                    <asp:FileUpload runat="server" name="upload_image" ID="upload_image" accept="image/*" />
                                                                    <br />
                                                                    <div id="uploaded_image"></div>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>

                                                        <div id="uploadimageModal" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
                                                            <div class="modal-dialog">
                                                                <div class="modal-content">
                                                                    <div class="modal-header">
                                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                        <h4 class="modal-title">Ajuste la imagen a su gusto </h4>
                                                                    </div>
                                                                    <div class="modal-body">
                                                                        <div class="row">
                                                                            <div class="col-12 text-center">
                                                                                <div id="image_demo" class="img-fluid img-responsive " style="width: 100%; /*margin-top: 30px*/"></div>
                                                                            </div>
                                                                            <br />
                                                                            <input id="imagen4" type="button" name="name" value="Cambiar Imagen" data-target="#modalprofile" class="btn btn-primary crop_image" />
                                                                            <div class="col-lg-12">
                                                                                <div id="loader" class="display-none" >
                                                                                    <img src="../Resources/Images/loader-gif.gif" style="max-width:50px;" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                                <div class="modal-footer">
                                                                    <button type="button" class="btn btn-default crop_image" data-dismiss="modal">Cancelar</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <style>
                                                        .cr-boundary {
                                                            width: 100% !important;
                                                        }

                                                        .modal-content {
                                                            width: auto !important;
                                                        }
                                                    </style>



                                                    <%--<div class="demo"></div>--%>

                                                    <%-- <div class="col-md-12 mx-auto d-block">
                                                            <asp:Panel runat="server" ID="panel"></asp:Panel>
                                                            <input id="imagen4" type="button" name="name" value="Cambiar Imagen"
                                                                data-toggle="modal" data-target="#modalprofile" class="btn btn-primary crop_image"
                                                                style="background: white; color: #2981c5; display: block; border: 1px solid #2981c5; margin: 0 auto" />
                                                        </div>--%>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12" style="text-align: center">
                                                        <asp:Label ID="lblinformacion" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                        <div id="tab-2" class="tab-pane">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <h1>Titular</h1>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>País de Operaciones</label>
                                                            <%-- <asp:TextBox ID="txtCountryO" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>--%>
                                                            <asp:Label ID="txtCountry" CssClass="form-control read-only" Text="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Nombres</label>
                                                            <asp:TextBox ID="txtName" runat="server" placeholder="Nombres" CssClass="form-control input-sm capitalize" MaxLength="100" aria-required="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Apellidos</label>
                                                            <asp:TextBox ID="txtLastName" runat="server" placeholder="Ap Paterno" CssClass="form-control input-sm capitalize" MaxLength="150" aria-required="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="titulo">Sexo</label>
                                                            <div class="radio radio-inline text-left">
                                                                <asp:RadioButton ID="rbMen" runat="server" GroupName="gender" value="M" Checked="true"></asp:RadioButton>
                                                                <label for="sexo_m">Masculino</label>
                                                            </div>
                                                            <div class="radio radio-inline text-left">
                                                                <asp:RadioButton ID="rbWoman" runat="server" GroupName="gender" value="F"></asp:RadioButton>
                                                                <label for="sexo_f">Femenino</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Nro. Teléfono móvil</label>
                                                            <asp:TextBox ID="txtPhone" runat="server" placeholder="Ap Materno" CssClass="form-control input-sm capitalize" MaxLength="150" aria-required="true"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group" id="data_1">
                                                            <label class="font-normal">Fecha de nacimiento</label>
                                                            <div class="input-group date" data-provide="datepicker">
                                                                <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i></span>
                                                                <asp:TextBox ID="txtBirthday" data-date-format="mm-dd-yyyy" runat="server" class="form-control input-sm" placeholder="dd-mm-yyyy" required="" MaxLength="10" aria-required="true"></asp:TextBox>
                                                            </div>
                                                            <label id="fecnac-error" class="error" for="fecnac"></label>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label>Tipo documento</label>
                                                            <asp:Label ID="txtTipoDoc" CssClass="form-control read-only" Text="text" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label>Nro. documento</label>
                                                            <%--<asp:TextBox ID="txtNumDoc" runat="server" placeholder="Nro. documento" CssClass="form-control input-sm" ReadOnly="true" MaxLength="15"></asp:TextBox>--%>
                                                            <asp:Label ID="txtNumDoc" Text="text" CssClass="form-control read-only" runat="server" />
                                                            <p class="m-t msg_doc"></p>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label>Correo electrónico</label>
                                                            <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" name="correo" placeholder="Correo electrónico" CssClass="form-control input-sm" MaxLength="150"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label>Nro. Teléfono móvil adicional</label>
                                                            <asp:TextBox ID="txtPhone2" runat="server" name="celular" placeholder="Nro. Teléfono móvil" CssClass="form-control input-sm" MaxLength="20"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Dirección</label>
                                                            <asp:TextBox ID="txtAddress" runat="server" name="direccion" placeholder="Dirección" CssClass="form-control input-sm" MaxLength="255"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Estado</label>
                                                            <asp:TextBox ID="Estadop" runat="server" placeholder="Estado" CssClass="form-control input-sm" MaxLength="255" /> 
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Ciudad</label>
                                                            <asp:TextBox ID="txtCiudad" runat="server" name="razonsocial" placeholder="Razón Social" CssClass="form-control input-sm" MaxLength="255"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <%--<div class="form-group">
                                                            <label></label>
                                                            <asp:TextBox ID="txtFiscalAddress" runat="server" name="direccionfiscal" placeholder="Dirección Fiscal" CssClass="form-control input-sm" MaxLength="255"></asp:TextBox>
                                                        </div>--%>
                                                    </div>
                                                </div>
                                                <%-- <div class="row">
                                                    <div class="col-md-6">
                                                        <label>* Los Cambios de </label>
                                                        </div>
                                                    </div>--%>

                                                <div class="row">

                                                    <div class="col-md-12">

                                                        <button onclick="history.back();return;" class="btn btn-secondary pull-center m-t-n-xs plomo">Cancelar</button>
                                                        <asp:Button ID="btnSaveDataPerson" runat="server" CssClass="btn btn-primary pull-center m-t-n-xs plomo" Text="Guardar cambios" OnClick="btnSaveDataPerson_Click"></asp:Button>
                                                        &nbsp;
                                                        <asp:Label ID="lblMesaggePer" runat="server" ForeColor="Red" Style="font-weight: bold;" />

                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <h1>Co-Titular</h1>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Nombre</label>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNameCoAfi" />

                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Apellidos</label>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtLastNameCoAfi" />

                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="font-normal">Fecha de nacimiento</label>
                                                            <div class="input-group date" data-provide="datepicker">
                                                                <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i></span>
                                                                <asp:TextBox runat="server" name="txtBirthday" type="text" MaxLength="10" ID="txtBirthDayCoAfi" data-date-format="mm-dd-yyyy" class="form-control input-sm" placeholder="dd-mm-yyyy" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Tipo documento</label>
                                                            <asp:DropDownList runat="server" ID="ddlTypeDocCoAfi" CssClass="form-control">
                                                                <asp:ListItem Value="0" Text="Seleccione..." />
                                                                <asp:ListItem Value="1" Text="DNI" />
                                                                <asp:ListItem Value="2" Text="CE" />
                                                                <asp:ListItem Value="3" Text="Pasaporte" />
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label>Nro. documento</label>

                                                            <asp:TextBox runat="server" value="" ID="txtNumberDocCoAfi" CssClass="form-control" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <button onclick="history.back();return;" class="btn btn-secondary pull-center m-t-n-xs plomo">Cancelar</button>

                                                        <asp:Button Text="Guardar cambios" ID="btnSaveChangesCoAfi" runat="server" class="btn btn-primary pull-center m-t-n-xs plomo" OnClick="btnSaveChangesCoAfi_Click" />
                                                        <br />
                                                        <asp:Label ID="lblMessageErrorCo" Text="" runat="server" ForeColor="Red" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="tab-3" class="tab-pane">
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
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlBanck" runat="server" ErrorMessage="Campo Obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>--%>
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
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <label>Numero de Contribuyente </label>
                                                            <asp:TextBox ID="txtNumContr" runat="server" name="razonsocial" placeholder="# RUC" class="form-control input-sm"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <label>Razón Social</label>
                                                            <asp:TextBox ID="txtBusinessName" runat="server" name="razonsocial" placeholder="Razón Social" class="form-control input-sm"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <label>Dirección Fiscal</label>
                                                            <asp:TextBox ID="txtFiscalAddress" runat="server" name="direccionfiscal" placeholder="Dirección Fiscal" class="form-control input-sm"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="text-center">
                                                        <br />
                                                        <asp:Label ID="lblMessaggeBank" runat="server" ForeColor="Red" Style="font-weight: bold;" />
                                                        <br />
                                                        <br />
                                                        <button onclick="history.back();return;" class="btn btn-secondary">Cancelar</button>
                                                        <asp:Button ID="btnSaveDataBank" Text="Guardar" runat="server" CssClass="btn btn-primary" OnClick="btnSaveDataBank_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="tab-4" class="tab-pane">
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
                                        </div>
                                        <div id="tab-5" class="tab-pane">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <input id="NuevoBeneficiario" type="button" name="name" value="Nuevo Beneficiario"
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
                                        <div id="tab-6" class="tab-pane">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <p class="text-bold">Razon Social : <small>VALLE ENCANTADO SAC</small></p>
                                                        <p class="text-bold">Ruc : <small>20601460271</small> </p>
                                                        <p class="text-bold">Cuenta Bancaria BCP: <small>191-2606708-0-82</small></p>
                                                        <p class="text-bold">Cuenta InterBancaria BCP: <small>002 191 002606708082 55</small></p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
            <style type="text/css">
                .btn-default, .btn-default:hover {
                    color: #000;
                }
            </style>

            <br />
            <br />
            <div class="footer footer-fondo" style="position: fixed;">
                <strong>Ribera del Rio - 2018</strong>
            </div>
        </div>

        <div class="modal fade" id="beneficiarioModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header text-center">
                        <h5 class="modal-title" id="exampleModalCenterTitle">Nuevo Beneficiario</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label>Nombre Completo</label>
                                    <input id="NameBenef" type="text" name="name" value="" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Numero de Documento</label>
                                    <input id="DocBenef" type="text" name="name" value="" class="form-control" />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Parentesco</label>
                                    <input id="ParentescoBenef" type="text" name="name" value="" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
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
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button id="GuardarBenef" type="button" class="btn btn-primary">Guardar Cambios</button>
                    </div>
                </div>
            </div>
        </div>

        <div id="modalprofile" class="modal" style="display: none; padding-right: 17px;">
            <div class="modal-content">
                <span class="close" data-dismiss="modal">×</span>

                <div class="modal-header">
                    <img src="img/novologo.png" alt="Alternate Text" width="100">
                </div>

                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Subir Imagen</label>
                                <asp:FileUpload ID="Fluplo" runat="server" />
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                            </div>
                        </div>

                    </div>
                </div>
                <br />

                <center>
                   <%-- <asp:Button ID="Button4" runat="server" OnClick="Btn_imagprofile" Text="Subir"  class="btn"  />--%>
                    <button type="button" class="btn" data-dismiss="modal" > Cerrar</button> 
                </center>

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

        <style>
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
                width: 70%;
                border-radius: 8px;
                font-family: sand-serif;
                box-shadow: 4px 4px 25px black;
            }

            .ps {
                text-align: center;
                margin: 25px;
                font-size: 24px;
                color: #337ab7;
            }
        </style>

        <script src="Script/ScriptEdit.js"></script>
    </form>

    <%-- script del codigo para subir imagen --%>
    <script>  
        $(document).ready(function () {

            $image_crop = $('#image_demo').croppie({
                enableExif: true,
                viewport: {
                    width: 300,
                    height: 300,
                    type: 'square' //circle
                },
                boundary: {
                    width: 400,
                    height: 400
                }
            });

            $('#upload_image').on('change', function () {
                var reader = new FileReader();
                reader.onload = function (event) {
                    $image_crop.croppie('bind', {
                        url: event.target.result
                    }).then(function () {
                        console.log('jQuery bind complete');
                    });
                }
                reader.readAsDataURL(this.files[0]);
                $('#uploadimageModal').modal('show');
            });

            $('.crop_image').click(function (event) {
                document.getElementById('loader').classList.toggle('display-none');
                $image_crop.croppie('result', {
                    type: 'canvas',
                    size: 'viewport'
                }).then(function (response) {
                    $.ajax({
                        url: "EditPthotoC.aspx",
                        type: "POST",
                        data: { "image": response },
                        success: function (data) {
                            $('#uploadimageModal').modal('hide');
                            $('#uploaded_image').html(data);
                            location.reload();
                        }
                    });
                })
            });

        });
    </script>


</body>
</html>
