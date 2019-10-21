<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterRef.aspx.cs" Inherits="MULTI_NIVEL.Views.RegisterRef" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body class="top-navigation pace-done">
     <div id="divProgressBar" style="display:none;">
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
                            <ul class="nav navbar-top-links navbar-right header-inicior">
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
                                                <a href="editar.htm" class="btn btn-primary btn-sm block">Cambiar Clave</a>
                                            </p>
                                            <center>
						                        <p class="col-md-12">							                            
                                                    <asp:LinkButton ID="lblSalir" runat="server" OnClick="lbkBtnSalir_Click" CssClass="btn btn-primary block" Text="Salir"></asp:LinkButton>
						                        </p>
						                    </center>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </nav>
                </div>
                <div class="slider_home">
                    <div class="carousel slide" id="slideHome">
                        <div class="carousel-inner">
                            <div class="item active">
                                <img alt="image" class="img-responsive" src="registro_files/banner-nuevo.png">
                            </div>
                        </div>

                    </div>
                </div>
                <div class="wrapper wrapper-content animated fadeInUp nuevosocio">
                    <div class="contenedor container">
                        <div class="ibox float-e-margins">
                            <div class="ibox-content">

                                <input name="csrfsn" value="1ac27188a5684853ecf92749e6edac71" type="hidden">
                                <div class="col-md-12">
                                </div>
                                <div class="row">
                                    <div class="col-md-7 paisopera">
                                        <div class="col-md-12">
                                            <div class="col-md-3">
                                                <img src="registro_files/nuevo_socio.png" class="img-responsive" border="0">
                                            </div>
                                            <div class="col-md-9">
                                                <h2>Nuevo Socio</h2>
                                                <div class="form-group row">
                                                    <label class="col-md-5">País de Operaciones</label>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList runat="server" class="form-control input-sm" name="pais" ID="pais" required="" aria-required="true">
                                                            <asp:ListItem Value="">Seleccione...</asp:ListItem>
                                                            <asp:ListItem Value="1" Selected="True">Perú</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-md-5">Upline</label>
                                                    <div class="col-md-7">
                                                        <select class="form-control input-sm chosen-select" id="id_upline" name="id_upline" required="" style="display: none;" aria-required="true">
                                                            <option value="168" selected="selected">Luis Alberto Ccayo</option>
                                                            <option value="2516">Aaron Montañez</option>
                                                            <!--delete data-->
                                                        </select>
                                                        <div class="chosen-container chosen-container-single" style="width: 100%;" title="" id="id_upline_chosen">
                                                            <a class="chosen-single" tabindex="-1"><span>Luis Alberto Ccayo</span>
                                                                <div>
                                                                    <b></b>
                                                                </div>
                                                            </a>
                                                            <div class="chosen-drop">
                                                                <div class="chosen-search">
                                                                    <input autocomplete="off" type="text">
                                                                </div>
                                                                <ul class="chosen-results">
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                    </div>
                                </div>
                                <div class="row paquetes">
                                    <div class="col-md-4 text-center packafi_1">
                                        <div class="widget p-lg text-center" style="background-color: rgb(112,48,160)">
                                            <div class="m-b-md">
                                                <h1 class="m-xs">Experience</h1>
                                                <h4 class="font-bold no-margins">Inicial $50 -
                                                    6 Cuotas<br>
                                                    Monto cuota $77
                                                </h4>
                                                <br>
                                                <ul>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_1">Programa Vacacional 1</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_2">Club Resort 1</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_5"># Acciones 1</label>
                                                        </div>
                                                    </li>
                                                </ul>
                                                <h2 class="txt_precio">$ 500.00 <small>55 ptos.</small></h2>
                                                <div class="radio text-center">
                                                    <asp:RadioButton runat="server"  GroupName="packafilia" ID="packafiliaEx" value="1" Checked="true"></asp:RadioButton>
                                                    <label for="packafiliaEx">Seleccionar</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 text-center packafi_2">
                                        <div class="widget p-lg text-center"  style="background-color: rgb(146,208,80)" >
                                            <div class="m-b-md">
                                                <h1 class="m-xs">LIGHT</h1>
                                                <h4 class="font-bold no-margins">Inicial $100 -
                                                    12 Cuotas<br>
                                                    Monto cuota $79
                                                </h4>
                                                <br>
                                                <ul>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_1">Programa Vacacional 2</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_2">Club Resort 2</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_5"># Acciones 2</label>
                                                        </div>
                                                    </li>
                                                </ul>
                                                <h2>$ 1000.00<small>114 ptos.</small></h2>
                                                <div class="radio text-center">
                                                    <asp:RadioButton runat="server"  GroupName="packafilia" ID="packafiliaLt" value="2" ></asp:RadioButton>
                                                    <label for="packafiliaLt">Seleccionar</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 text-center packafi_3">
                                        <div class="widget p-lg text-center"   style="background-color: rgb(0,103,180)">
                                            <div class="m-b-md">
                                                <h1 class="m-xs">STANDAR</h1>
                                                <h4 class="font-bold no-margins">Inicial $150 -
                                                    18 Cuotas<br>
                                                    Monto cuota $81
                                                </h4>
                                                <br>
                                                <ul>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_1">Programa Vacacional 4</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_2">Club Resort 4</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_5"># Acciones 3</label>
                                                        </div>
                                                    </li>
                                                </ul>
                                                <h2>$ 1500.00<small>177 ptos.</small></h2>
                                                <div class="radio text-center">
                                                    <asp:RadioButton runat="server"  GroupName="packafilia" ID="packafiliaSt" value="3"></asp:RadioButton>
                                                    <label for="packafiliaSt">Seleccionar</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 text-center packafi_2">
                                        <div class="widget p-lg text-center" style="background-color: rgb(0,176,80)">
                                            <div class="m-b-md">
                                                <h1 class="m-xs">MASTER</h1>
                                                <h4 class="font-bold no-margins">Inicial $250 -
                                                    30 Cuotas<br>
                                                    Monto cuota $85
                                                </h4>
                                                <br>
                                                <ul>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_1">Programa Vacacional 7</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_2">Club Resort 7</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_5"># Acciones 5</label>
                                                        </div>
                                                    </li>
                                                </ul>


                                                <h2>$ 2500.00<small>306 ptos.</small></h2>
                                                <div class="radio text-center">
                                                    <asp:RadioButton runat="server"  GroupName="packafilia" ID="packafiliaMs" value="4" ></asp:RadioButton>
                                                    <label for="packafiliaMs">Seleccionar</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 text-center packafi_2">
                                        <div class="widget p-lg text-center" style="background-color: rgb(255,192,0)">
                                            <div class="m-b-md">
                                                <h1 class="m-xs">PLUS</h1>
                                                <h4 class="font-bold no-margins">Inicial $350 -
                                                    42 Cuotas<br>
                                                    Monto cuota $89
                                                </h4>
                                                <br>
                                                <ul>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_1">Programa Vacacional 10</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_2">Club Resort 10</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_5"># Acciones 7</label>
                                                        </div>
                                                    </li>
                                                </ul>


                                                <h2>$ 3500.00<small>444 ptos.</small></h2>
                                                <div class="radio text-center">
                                                    <asp:RadioButton runat="server"  GroupName="packafilia" ID="packafiliaPl" value="5" ></asp:RadioButton>
                                                    <label for="packafiliaPl">Seleccionar</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-4 text-center packafi_2">
                                        <div class="widget p-lg text-center" style="background-color: rgb(255,0,0)">
                                            <div class="m-b-md">
                                                <h1 class="m-xs">TOP</h1>
                                                <h4 class="font-bold no-margins">Inicial $550 -
                                                    60 Cuotas<br>
                                                    Monto cuota $104
                                                </h4>
                                                <br>
                                                <ul>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_1">Programa Vacacional Vitalicio</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_2">Club Resort Vitalicio</label>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="" style="display: flex;">
                                                            <label for="subpack_5"># Acciones 7</label>
                                                        </div>
                                                    </li>
                                                </ul>

                                                <h2>$ 5500.00<small>726 ptos.</small></h2>
                                                <div class="radio text-center">
                                                    <asp:RadioButton runat="server"  GroupName="packafilia" ID="packafiliaTp" value="6" ></asp:RadioButton>
                                                    <label for="packafiliaTp">Seleccionar</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="hidden">
                                        <input name="porcentaje_1" id="porcentaje_1" value="25" type="hidden">
                                        <input name="precio_1" id="precio_1" value="199.00" type="hidden">
                                        <input name="puntos_1" id="puntos_1" value="140.00" type="hidden">
                                        <input name="porcentaje_2" id="porcentaje_2" value="25" type="hidden">
                                        <input name="precio_2" id="precio_2" value="199.00" type="hidden">
                                        <input name="puntos_2" id="puntos_2" value="140.00" type="hidden">
                                        <input name="porcentaje_5" id="porcentaje_5" value="25" type="hidden">
                                        <input name="precio_5" id="precio_5" value="199.00" type="hidden">
                                        <input name="puntos_5" id="puntos_5" value="140.00" type="hidden">
                                        <input name="porcentaje_3" id="porcentaje_3" value="25" type="hidden">
                                        <input name="precio_3" id="precio_3" value="499.00" type="hidden">
                                        <input name="puntos_3" id="puntos_3" value="400.00" type="hidden">
                                        <input name="porcentaje_4" id="porcentaje_4" value="25" type="hidden">
                                        <input name="precio_4" id="precio_4" value="799.00" type="hidden">
                                        <input name="puntos_4" id="puntos_4" value="680.00" type="hidden">
                                    </div>
                                </div>
                                <p>
                                </p>
                                
                                <div class="row sombra">
                                    <div class="col-md-12">
                                        <h4>Datos Personales</h4>
                                        <hr>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Nombres</label>
                                            <asp:TextBox ID="txtName" runat="server" placeholder="Nombres" class="form-control input-sm capitalize" required="" aria-required="true" type="text"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Ap Paterno</label>
                                            <asp:TextBox ID="txtLastNameFather" runat="server" placeholder="Ap Paterno" class="form-control input-sm capitalize" required="" aria-required="true" type="text"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Ap Materno</label>
                                            <asp:TextBox ID="txtLastNameMother" runat="server" placeholder="Ap Materno" class="form-control input-sm capitalize" required="" aria-required="true" type="text"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group" id="data_1">
                                            <label class="font-normal">Fecha de nacimiento</label>
                                            <div class="input-group date">
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                <asp:TextBox ID="txtDateNac" runat="server" name="fecnac" class="form-control input-sm" placeholder="dd-mm-yyyy" required="" MaxLength="10" aria-required="true"></asp:TextBox>
                                            </div>
                                            <label id="fecnac-error" class="error" for="fecnac" style=""></label>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label class="titulo">Sexo</label>
                                            <div class="radio radio-inline text-left">
                                                <asp:RadioButton ID="rbMan" runat="server" GroupName="sexo" value="M" Checked></asp:RadioButton>
                                                <label for="rbMan">Masculino</label>
                                            </div>
                                            <div class="radio radio-inline text-left">
                                                <asp:RadioButton ID="rbWoman" runat="server" GroupName="sexo" value="F"></asp:RadioButton>
                                                <label for="rbWoman">Femenino</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Tipo documento</label>
                                            <asp:DropDownList ID="ddlTypeDoc" runat="server" class="form-control input-sm" name="tipodoc" required="" aria-required="true">
                                                <asp:ListItem Value="" Selected="True">Seleccione...</asp:ListItem>
                                                <asp:ListItem Value="1">DNI</asp:ListItem>
                                                <asp:ListItem Value="2">LE</asp:ListItem>
                                                <asp:ListItem Value="3">Pasaporte</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Tipo De Usuario</label>
                                            <asp:DropDownList ID="ddlTypeAccount" runat="server" class="form-control input-sm" name="tipodoc" required="" aria-required="true">
                                                <asp:ListItem Value="" Selected="True">Seleccione...</asp:ListItem>
                                                <asp:ListItem Value="1">Multi Nivel</asp:ListItem>
                                                <asp:ListItem Value="2">Directo</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Nro. documento</label>
                                            <asp:TextBox ID="txtNumDoc" name="nrodoc" placeholder="Nro. documento" class="form-control input-sm" required="" aria-required="true" type="text" runat="server"></asp:TextBox>
                                            <p class="m-t msg_doc">
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Razón Social</label>
                                            <asp:TextBox ID="txtBusinessName" runat="server" name="razonsocial" placeholder="Razón Social" class="form-control input-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Dirección Fiscal</label>
                                            <asp:TextBox ID="txtFiscalAddress" runat="server" name="direccionfiscal" placeholder="Dirección Fiscal" class="form-control input-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <h4>Datos de Contacto</h4>
                                        <hr>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Correo electrónico</label>
                                            <asp:TextBox ID="txtEmail" runat="server" name="correo" placeholder="Correo electrónico" class="form-control input-sm" required="" aria-required="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Nro. Teléfono móvil</label>
                                            <asp:TextBox ID="txtPhone" runat="server" name="celular" placeholder="Nro. Teléfono móvil" class="form-control input-sm" required="" onkeypress="return FormatoNumero(event);" aria-required="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <h4>Domicilio</h4>
                                        <hr>
                                    </div>
                                    <%--<div class="col-md-8 col-md-offset-1">
                                    <div class="form-group">
                                        <label>Dirección</label>
                                        <asp:TextBox ID="txtAddress" runat="server" name="direccion" placeholder="Dirección" class="form-control input-sm" required="" aria-required="true" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-8 col-md-offset-1">
                                    <div class="form-group">
                                        <label>Referencia</label>
                                        <asp:TextBox ID="txtReference" runat="server" name="referencia" placeholder="Referencia" class="form-control input-sm" type="text"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-8 col-md-offset-1">
                                    <div class="form-group">
                                        <label>Departamento</label>
                                        <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control input-sm" name="departamento"  required="" aria-required="true">
                                            <asp:ListItem value="" selected="True"> Seleccione... </asp:ListItem>
                                            <asp:ListItem value="1">AMAZONAS</asp:ListItem>
                                            <asp:ListItem value="2">ANCASH</asp:ListItem>
                                            <asp:ListItem value="3">APURIMAC</asp:ListItem>
                                            <asp:ListItem value="4">AREQUIPA</asp:ListItem>
                                            <asp:ListItem value="5">AYACUCHO</asp:ListItem>
                                            <asp:ListItem value="6">CAJAMARCA</asp:ListItem>
                                            <asp:ListItem value="7">CALLAO</asp:ListItem>
                                            <asp:ListItem value="8">CUSCO</asp:ListItem>
                                            <asp:ListItem value="9">HUANCAVELICA</asp:ListItem>
                                            <asp:ListItem value="10">HUANUCO</asp:ListItem>
                                            <asp:ListItem value="11">ICA</asp:ListItem>
                                            <asp:ListItem value="12">JUNIN</asp:ListItem>
                                            <asp:ListItem value="13">LA LIBERTAD</asp:ListItem>
                                            <asp:ListItem value="14">LAMBAYEQUE</asp:ListItem>
                                            <asp:ListItem value="15">LIMA</asp:ListItem>
                                            <asp:ListItem value="16">LORETO</asp:ListItem>
                                            <asp:ListItem value="17">MADRE DE DIOS</asp:ListItem>
                                            <asp:ListItem value="18">MOQUEGUA</asp:ListItem>
                                            <asp:ListItem value="19">PASCO</asp:ListItem>
                                            <asp:ListItem value="20">PIURA</asp:ListItem>
                                            <asp:ListItem value="21">PUNO</asp:ListItem>
                                            <asp:ListItem value="22">SAN MARTIN</asp:ListItem>
                                            <asp:ListItem value="23">TACNA</asp:ListItem>
                                            <asp:ListItem value="24">TUMBES</asp:ListItem>
                                            <asp:ListItem value="25">UCAYALI</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-8 col-md-offset-1">
                                    <div class="form-group">
                                        <label>Provincia</label>
                                        <asp:DropDownList ID="ddlProvince" runat="server" class="form-control input-sm" name="provincia"  required="" aria-required="true">
                                            <asp:ListItem value="" selected="True">Seleccione...</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-8 col-md-offset-1">
                                    <div class="form-group">
                                        <label>Distrito</label>
                                        <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control input-sm" name="distrito" required="" aria-required="true">
                                            <asp:ListItem value="" selected="True">Seleccione...</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>--%>
                                    <div class="col-md-6">
                                        <br>
                                        <center><asp:Button ID="btnRegister" runat="server" class="btn btn-sm btn-primary m-t-n-xs plomo" Text="REGISTRAR SOCIO" OnClick="btnRegister_Click" OnClientClick="validation();"></asp:Button></center>
                                    </div>
                                    <div class="col-md-6">
                                        <br>
                                        <center><button  class="btn btn-sm btn-primary m-t-n-xs plomo" style="padding: 8px 50px" onclick="histoy.back();return 0;"><strong>CANCELAR</strong></button><center>
                                    </center></center>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <script src="registro_files/socio.js"></script>
                <!-- Favorito -->
                <div class="modal inmodal" id="mdlTerminosCondiciones" tabindex="-1" role="dialog" aria-hidden="true">
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
                <div class="footer footer-fondo">
                    <strong>Ribera del rio - 2018</strong>
                </div>
            </div>
        </div>
        
        <script type="text/javascript">
            function validation() {

                var nombre = document.getElementById('txtName').innerText;
                if (nombre !== "") {
                    var app = document.getElementById('txtLastNameFather').innerText;
                    if (app !== "") {
                        var apm = document.getElementById('txtLastNameMother').innerText;
                        if (apm !== "") {
                            var birth = document.getElementById('txtDateNac').innerText;
                            if (birth !== "") {
                                var typedoc = document.getElementById('ddlTypeAccount').innerText;
                                if (typedoc !== 'Seleccione...') {
                                    var numdoc = document.getElementById('txtNumDoc').innerText;
                                    if (numdoc !== "") {
                                        var email = document.getElementById('txtEmail').innerText;
                                        if (email !== "") {
                                            var telf = document.getElementById('txtPhone').innerText;
                                            if (telf !== "") {
                                                alert('entre')
                                                document.getElementById("divProgressBar").style.display = "inline";
                                                /*bloquear el scroll*/
                                                $('body').addClass('stop-scrolling');
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
            
        </script>
    </form>
</html>
