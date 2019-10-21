<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consumo.aspx.cs" Inherits="MULTI_NIVEL.Views.Consumo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pagos | inResorts</title>
    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>
    <script src="Script/Script.js"></script>
</head>
<body class="top-navigation pace-done">
    <div id="divProgressBar">
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
                                            <p class="col-md-5">
                                                <a href="Edit.aspx" class="btn btn-primary btn-sm block">Editar perfil</a>
                                            </p>
                                            <p class="col-md-5">
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
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Árbol de patrocinio</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Commissions.aspx">
                                                        <img src="../Resources/Images/comisiones.png" class="img-responsive center-block" border="0" />Mis comisiones</a>
                                                </div>
                                                <div class="col-xs-3 separadorbarra" style="width: 20% !important">
                                                    <a href="Payments.aspx">
                                                        <img src="../Resources/Images/Payments.png" class="img-responsive center-block" border="0" />Mis Pagos</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 20px; position: relative">
                                <div class="col-md-6">
                                    <img src="../Resources/Images/Payments.png" class="logo-seccion" align="left" />
                                    <h2 class="green"><b>Pagos</b></h2>
                                    <ol class="breadcrumb negro">
                                        <li class="breadcrumb-item "><a href="Payments.aspx" >Membresias</a></li>
                                        <li class="breadcrumb-item active" ><a href="Consumo.aspx" class="subrayar">Consumo</a></li>
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
                                                        <img src="../Resources/Images/redes.png" class="img-responsive center-block" border="0" />Árbol de patrocinio</a>
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
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row box-hr">
                                <hr>
                            </div>
                            <div class="table-responsive m-t">
                                <div id="DataTables_Table_0_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
                                    <div class="html5buttons">
                                        <div class="dt-buttons btn-group">
                                            <a id="btnDownloadExcel" class="btn btn-default buttons-excel buttons-html5" tabindex="0" aria-controls="DataTables_Table_0" href="#">Excel</a><a class="btn btn-default buttons-pdf buttons-html5" tabindex="0" aria-controls="DataTables_Table_0" href="#"><span>PDF</span></a><a class="btn btn-default buttons-print" tabindex="0" aria-controls="DataTables_Table_0" href="#"><span>Print</span></a>
                                        </div>
                                    </div>
                                    <div class="dataTables_length" id="DataTables_Table_0_length">
                                        <label>
                                            Mostrar
								<select id="cboNumRows" name="DataTables_Table_0_length" aria-controls="DataTables_Table_0" class="form-control input-sm" onchange="cboNumRows_OnChange()">
                                    <option value="10" selected="selected">10</option>
                                    <option value="25">25</option>
                                    <option value="50">50</option>
                                    <option value="100">100</option>
                                </select>
                                            filas</label>
                                    </div>
                                    <div id="DataTables_Table_0_filter" class="dataTables_filter">
                                        <label>Buscar:<input class="form-control input-sm" placeholder="" aria-controls="DataTables_Table_0" type="search" /></label>
                                    </div>
                                    <div class="dataTables_info" id="DataTables_Table_0_info" role="status" aria-live="polite">
                                        Mostrando 1 de 13 filas
                                    </div>
                                    <table class="table table-bordered dataTables-example dataTable no-footer" id="DataTables_Table_0" aria-describedby="DataTables_Table_0_info" role="grid" style="width: 1814px;">
                                        <thead>
                                            <tr role="row">
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: %;" aria-label="Periodo: Activar para ordenar la columna ascendente">Descripcion</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 250px;" aria-label="Fecha de Publicación: Activar para ordenar la columna ascendente">Fecha</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 200px;" aria-label="Comisión: Activar para ordenar la columna ascendente">Capital</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 125px;" aria-label="Comisión: Activar para ordenar la columna ascendente">Amortización</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 125px;" aria-label="Comisión: Activar para ordenar la columna ascendente">Interes</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 125px;" aria-label=": Activar para ordenar la columna ascendente">Cuota</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 80px;" aria-label=": Activar para ordenar la columna ascendente">Estado</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 150px;" aria-label=": Activar para ordenar la columna ascendente">Pagar En Linea</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 150px;" aria-label=": Activar para ordenar la columna ascendente">Subir Recibo</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tblPayments">
                                        </tbody>
                                    </table>
                                    <div class="dataTables_paginate paging_simple_numbers" id="DataTables_Table_0_paginate">
                                        <ul class="pagination">
                                            <li class="paginate_button previous" id="DataTables_Table_0_previous">
                                                <a aria-controls="DataTables_Table_0" data-dt-idx="0" tabindex="0" onclick="buttonPages(0);">Anterior</a></li>
                                            <li class="paginate_button active">
                                                <a href="#" aria-controls="DataTables_Table_0" data-dt-idx="1" tabindex="0" id="lblNumPageCurrent">-1</a></li>
                                            <li class="paginate_button next" id="DataTables_Table_0_next"><a aria-controls="DataTables_Table_0" data-dt-idx="2" tabindex="0" onclick="buttonPages(1);">Siguiente</a></li>
                                        </ul>
                                    </div>
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

        <div class="modal inmodal" id="mdlImages" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content animated bounceInRight">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Recibo</h4>
                    </div>
                    <div class="modal-body" style="overflow: hidden">
                       
<%--                        <div class="form-group">
                            <label for="txtNumRecibo">Numero de Recibo</label>
                            <asp:TextBox ID="txtNumRecibo" runat="server" class="form-control input-sm" placeholder="Ejem: 9999-9999-9999"></asp:TextBox>
                        </div>--%>
                        <div class="form-group col-lg-12 text-center">
                            <div id="file-preview-zone">
                                <img src="../Resources/Images/recibo.png" alt="Alternate Text" width="200" height="200" />
                                <%--<asp:Image ID="file_preview" ImageUrl="~/Resources/Images/recibo.png" runat="server" width="200" height="200"/>--%>
                            </div>
                        </div>
                        <div class="form-group col-sm-4">
                            <div class="custom-file">
                                <%--<input type="file" class="custom-file-input" id="file_upload" lang="es" />--%>
                                <%--<asp:Image ImageUrl="imageurl"   />--%>
                                <asp:FileUpload runat="server"  class="custom-file-input" ID="file_upload" lang="es"/>                                 
                                <label class="custom-file-label" for="customFileLang">Seleccionar Archivo</label>
                            </div>
                        </div>
                        <div class="form-group col-lg-12 text-right">
                          <%--  <input name="btnRegister" value="Guadar Recibo" id="btnGuadarImagen" class="btn btn-sm btn-primary m-t-n-xs plomo" type="button" />--%>
                            <asp:TextBox runat="server" ID="lblIdMem" style="display:none"/> 
                            <asp:Button ID="btnSubirImagen" Text="Guadar Recibo" runat="server"  class="btn btn-sm btn-primary m-t-n-xs plomo" type="button"  />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal inmodal" id="mdlCulqi" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content animated bounceInRight">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Pago en Linea</h4><input  type="hidden" name="name" id="lblIdImagen" />
                    </div>
                    <div class="modal-body" style="overflow: hidden">
                        <div class="">
                            <div class="col-md-8 col-md-offset-1">
                                <label>
                                    <span>Número de tarjeta</span>
                                    <input type="text" size="20" data-culqi="card[number]" id="card[number]" class="form-control input-sm capitalize" />
                                </label>
                            </div>
                            <div class="col-md-8 col-md-offset-1">
                                <label>
                                    <span>CVV</span>
                                    <input type="text" size="4" data-culqi="card[cvv]" id="card[cvv]" class="form-control input-sm capitalize" maxlength="3" />
                                </label>
                            </div>
                            <div class="col-md-8 col-md-offset-1" style="display: flex">
                                <label>
                                    <span>Fecha expiración (MM/YYYY)</span>
                                    <input size="2" data-culqi="card[exp_month]" id="card[exp_month]" class="input-sm capitalize" maxlength="2" style="border-color: lawngreen" />
                                    <span>/</span>
                                    <input size="4" data-culqi="card[exp_year]" id="card[exp_year]" class="input-sm capitalize" maxlength="4" style="border-color: lawngreen" />
                                </label>
                            </div>
                            <div class="col-md-8 col-md-offset-1">
                                <label>
                                    <span>Correo Electrónico</span>
                                    <input type="text" size="50" data-culqi="card[email]" id="card[email]" class="form-control input-sm capitalize" />
                                </label>
                            </div>
                             <div class="col-md-6">
                                                <br>
                                                <%--<asp:Button ID="btnRegistePay" runat="server" class="btn btn-sm btn-primary m-t-n-xs plomo" Text="REGISTRAR SOCIO"></asp:Button>--%>
                                                <asp:Label ID="Label1" runat="server" Text="Cuotas"></asp:Label>
                                                <asp:DropDownList ID="ddlQuote" runat="server">
                                                    
                                                </asp:DropDownList>
                                                </div>
                            <div class="col-md-6">
                                <br>
                                <center>
                                             <button id="btnRegistePay" class="btn btn-sm btn-primary m-t-n-xs plomo" >Efectuar Pago</button>
                                        </center>
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

        <div class="modal inmodal" id="mdlMessagge" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content animated bounceInRight">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">Pago En Linea</h4>
                            </div>
                            <div class="modal-body">
                                <h2 id="txtMessagge"></h2>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <center><a href="Index.aspx" class="btn btn-sm btn-primary m-t-n-xs">Ir al Inicio</a></center>
                            </div>
                            
                        </div>
                    </div>
                </div>

        <a id="scrollUp" href="#top" title="Scroll to top" style="position: fixed; z-index: 2147483647; display: none;"></a>
    </form>
    <script src="https://checkout.culqi.com/v2"></script>
    <script src="Script/ScriptPayments.js"></script>
</body>
</html>
