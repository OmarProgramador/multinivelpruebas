<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyShopping.aspx.cs" Inherits="MULTI_NIVEL.Views.MyShopping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Historial de mis compras | inResorts</title>
    <link href="myshopping_files/css.css" rel="stylesheet">
    <link href="myshopping_files/bootstrap.css" rel="stylesheet">
    <link href="myshopping_files/font-awesome.css" rel="stylesheet">
    <link href="myshopping_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="myshopping_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="myshopping_files/chosen.css" rel="stylesheet">
    <link href="myshopping_files/croppie.css" rel="stylesheet">
    <link href="myshopping_files/datepicker3.css" rel="stylesheet">
    <link href="myshopping_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="myshopping_files/ladda-themeless.css" rel="stylesheet">
    <link href="myshopping_files/sweetalert.css" rel="stylesheet">
    <link href="myshopping_files/animate.css" rel="stylesheet">
    <link href="myshopping_files/style.css" rel="stylesheet">
    <link rel="stylesheet" href="myshopping_files/all.css" integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp" crossorigin="anonymous">
        <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">

    <script src="myshopping_files/jquery-3.js"></script>
    <script src="myshopping_files/bootstrap.js"></script>
    <script src="myshopping_files/jquery_004.js"></script>
    <script src="myshopping_files/jquery_010.js"></script>
    <script src="myshopping_files/inspinia.js"></script>
    <script src="myshopping_files/pace.js"></script>
    <script src="myshopping_files/jquery.js"></script>
    <script src="myshopping_files/jquery_006.js"></script>
    <script src="myshopping_files/jquery_011.js"></script>
    <script src="myshopping_files/Chart.js"></script>
    <script src="myshopping_files/jasny-bootstrap.js"></script>
    <script src="myshopping_files/jquery_003.js"></script>
    <script src="myshopping_files/jquery_005.js"></script>
    <script src="myshopping_files/peity-demo.js"></script>
    <script src="myshopping_files/datatables.js"></script>
    <script src="myshopping_files/chosen.js"></script>
    <script src="myshopping_files/croppie.js"></script>
    <script src="myshopping_files/sweetalert.js"></script>
    <script src="myshopping_files/bootstrap3-typeahead.js"></script>
    <script src="myshopping_files/jquery_008.js"></script>
    <script src="myshopping_files/bootstrap-datepicker.js"></script>
    <script src="myshopping_files/jquery_002.js"></script>

    <script>
        var base_url = ' ';
        var idsocio = ;
        var idopera = ;
        var nombresocio = '';
        var direcsocio = '';
        var rango = '';
        var simbolo = ';
        var csrfsn = '356fc2188a3c86b823193761459a4da3';
        //document.addEventListener('contextmenu', event => event.preventDefault());
    </script>
    <script src="myshopping_files/jquery_009.js"></script>
    <script src="myshopping_files/jquery_007.js"></script>
</head>
<body class="top-navigation pace-done">
    <form id="form1" runat="server">
    <div class="pace  pace-inactive">
        <div class="pace-progress" style="transform: translate3d(100%, 0px, 0px);" data-progress-text="100%" data-progress="99">
            <div class="pace-progress-inner"></div>
        </div>
        <div class="pace-activity"></div>
    </div>
    <!-- Loading -->


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
                                <%--<img src="myshopping_files/a2e080cf2241b0ba7c11145c094867c3.jpg" alt="..." class="img-circle img-responsive img-user">--%>
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
                                                <p><strong><asp:Label ID="lblUserName" runat="server"></asp:Label></strong></p>
                                                <p class="green"> <asp:Label ID="lblNumPartner" runat="server"></asp:Label></p>
                                            </div>

                                    </li>
                                    <li class="divider"></li>
                                    <li>
                                        <p class="col-md-5">
                                                <a href="Edit.aspx" class="btn btn-primary btn-sm">Editar perfil</a>
                                            </p>
                                            <p class="col-md-5">
                                                <a href="Edit.aspx" class="btn btn-primary btn-sm">Cambiar Clave</a>
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
                        <h2 class="green">Tienda</h2>
                        <ol class="breadcrumb green">
                            <li class="breadcrumb-item"><a href="Store.aspx">Tienda</a></li>
                            <li class="breadcrumb-item active"><a href="MyShopping.aspx" class="subrayar">Mis compras</a></li>
                        </ol>
                        <hr>
                        <div class="tabs-container">
                            <ul class="nav nav-tabs">
                                <li class="active"><a data-toggle="tab" href="#tab-1">Compras pagadas</a></li>
                                <li class=""><a data-toggle="tab" href="#tab-2">Compras pendientes</a></li> 
                                 
                            </ul>
                            <div class="tab-content">
                                <div id="tab-1" class="tab-pane active">
                                    <div class="panel-body">
                                        <form action=" " id="formBuscarTransaccion" class="form-inline" method="post" accept-charset="utf-8">
                                            <input name="csrfsn" value="356fc2188a3c86b823193761459a4da3" type="hidden">

                                            <div class="form-group">
                                                <label for="mescierre">Periodo de Empresa</label>
                                                <select class="form-control input-sm" name="periodoempresa" id="periodoempresa">
                                                    <option value="" selected="selected">Seleccione...</option>
                                                    <option value="22">16/10/2018 - 31/10/2018 
                                                    </option>
                                                    <option value="21">01/10/2018 - 15/10/2018                                                 
                                                    </option>
                                                    <option value="20">16/09/2018 - 30/09/2018                                                 
                                                    </option>
                                                    <option value="19">01/09/2018 - 15/09/2018                                                 
                                                    </option>
                                                    <option value="18">16/08/2018 - 31/08/2018                                                 
                                                    </option>
                                                    <option value="17">01/08/2018 - 15/08/2018                                                 
                                                    </option>
                                                    <option value="16">16/07/2018 - 31/07/2018                                                 
                                                    </option>
                                                    <option value="15">01/07/2018 - 15/07/2018                                                 
                                                    </option>
                                                    <option value="14">16/06/2018 - 30/06/2018                                                 
                                                    </option>
                                                    <option value="13">01/06/2018 - 15/06/2018                                                 
                                                    </option>
                                                    <option value="12">16/05/2018 - 31/05/2018                                                 
                                                    </option>
                                                    <option value="11">01/05/2018 - 15/05/2018                                                 
                                                    </option>
                                                    <option value="10">16/04/2018 - 30/04/2018                                                 
                                                    </option>
                                                    <option value="9">01/04/2018 - 15/04/2018                                                 
                                                    </option>
                                                    <option value="8">16/03/2018 - 31/03/2018                                                 
                                                    </option>
                                                    <option value="7">03/03/2018 - 15/03/2018                                                 
                                                    </option>
                                                    <option value="6">06/02/2018 - 02/03/2018                                                 
                                                    </option>
                                                    <option value="5">16/01/2018 - 05/02/2018                                                 
                                                    </option>
                                                </select>
                                            </div>


                                            <input name="csrfsn" value="356fc2188a3c86b823193761459a4da3" type="hidden">
                                            <div class="form-group">
                                                <label for="mescierre">Periodo del Socio</label>
                                                <select class="form-control input-sm" name="periodosocio" id="periodosocio">
                                                    <option value="" selected="selected">Seleccione...</option>
                                                    <option value="10864">18/11/2018 - 18/12/2018                                                 
                                                    </option>
                                                    <option value="10863">18/10/2018 - 18/11/2018                                                 
                                                    </option>
                                                    <option value="9008">16/09/2018 - 16/10/2018                                                 
                                                    </option>
                                                    <option value="8328">16/08/2018 - 16/09/2018                                                 
                                                    </option>
                                                    <option value="7713">16/07/2018 - 16/08/2018                                                 
                                                    </option>
                                                    <option value="7259">03/06/2018 - 16/07/2018                                                 
                                                    </option>
                                                    <option value="7007">03/05/2018 - 03/06/2018                                                 
                                                    </option>
                                                    <option value="7006">03/04/2018 - 03/05/2018                                                 
                                                    </option>
                                                    <option value="6280">03/03/2018 - 03/04/2018                                                 
                                                    </option>
                                                    <option value="4944">20/02/2018 - 20/03/2018                                                 
                                                    </option>
                                                    <option value="4943">20/01/2018 - 20/02/2018                                                 
                                                    </option>
                                                </select>
                                            </div>
                                            <button type="submit" class="btn btn-sm btn-default verde">Consultar</button>
                                            <a href="MyShopping.aspx" class="btn btn-sm btn-default verde">Restablecer</a>
                                        </form>
                                        <div class="table-responsive m-t">
                                            <div id="DataTables_Table_0_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
                                                
                                                 
                                                 
                                                <table class="table table-bordered dataTables-example dataTable no-footer" id="DataTables_Table_0" aria-describedby="DataTables_Table_0_info" role="grid">
                                                    <thead>
                                                        <tr role="row">
                                                            <th class="sorting_asc" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 109.383px;" aria-sort="ascending" aria-label="Fecha de pago: Activar para ordenar la columna descendente">Fecha de pago</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 162.717px;" aria-label="Ciclo: Activar para ordenar la columna ascendente">Ciclo</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 87.35px;" aria-label="Nro. Ticket: Activar para ordenar la columna ascendente">Nro. Ticket</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 286.767px;" aria-label="Tipo: Activar para ordenar la columna ascendente">Tipo</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 66.4833px;" aria-label="Monto: Activar para ordenar la columna ascendente">Monto</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 56.05px;" aria-label="Puntos: Activar para ordenar la columna ascendente">Puntos</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 52.5667px;" aria-label="Estado: Activar para ordenar la columna ascendente">Estado</th>
                                                            <%-- <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 140.683px;" aria-label="Opciones: Activar para ordenar la columna ascendente">Opciones</th>--%>
                                                        </tr>
                                                    </thead>
                                                    <tbody>

                                                        <tr role="row" class="odd">
                                                            <td class="sorting_1">01/06/2018</td>
                                                            <td>03/06/2018 - 16/07/2018</td>
                                                            <td>1527868953</td>
                                                            <td>Autoconsumo</td>
                                                            <td>S/. 292.80</td>
                                                            <td>246</td>
                                                            <td>Pagado</td>
                                                            <%--<td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1527868953/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1527868953/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="even">
                                                            <td class="sorting_1">02/07/2018</td>
                                                            <td>16/07/2018 - 16/08/2018</td>
                                                            <td>1530549128</td>
                                                            <td>Autoconsumo</td>
                                                            <td>S/. 196.80</td>
                                                            <td>163</td>
                                                            <td>Pagado</td>
                                                            <%--<td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1530549128/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1530549128/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="odd">
                                                            <td class="sorting_1">03/03/2018</td>
                                                            <td>03/03/2018 - 03/04/2018</td>
                                                            <td>1520091784</td>
                                                            <td>PACK PLUS - PAQUETE FUNDADOR 6 - KPRO</td>
                                                            <td>S/. 509.00</td>
                                                            <td>400</td>
                                                            <td>Pagado</td>
                                                            <%--<td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1520091784/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1520091784/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="even">
                                                            <td class="sorting_1">03/04/2018</td>
                                                            <td>03/03/2018 - 03/04/2018</td>
                                                            <td>1522777175</td>
                                                            <td>Adicionales</td>
                                                            <td>S/. 72.80</td>
                                                            <td>48</td>
                                                            <td>Pagado</td>
                                                            <%--<td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1522777175/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1522777175/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="odd">
                                                            <td class="sorting_1">03/04/2018</td>
                                                            <td>03/04/2018 - 03/05/2018</td>
                                                            <td>1523901113</td>
                                                            <td>Autoconsumo</td>
                                                            <td>S/. 220.80</td>
                                                            <td>166</td>
                                                            <td>Pagado</td>
                                                           <%-- <td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1523901113/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1523901113/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="even">
                                                            <td class="sorting_1">05/02/2018</td>
                                                            <td>20/02/2018 - 20/03/2018</td>
                                                            <td>1517798471</td>
                                                            <td>Autoconsumo</td>
                                                            <td>S/. 225.20</td>
                                                            <td>168</td>
                                                            <td>Pagado</td>
                                                            <%--<td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1517798471/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1517798471/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="odd">
                                                            <td class="sorting_1">10/05/2018</td>
                                                            <td>03/05/2018 - 03/06/2018</td>
                                                            <td>1525962924</td>
                                                            <td>Adicionales</td>
                                                            <td>S/. 154.70</td>
                                                            <td>172</td>
                                                            <td>Pagado</td>
                                                           <%-- <td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1525962924/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1525962924/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="even">
                                                            <td class="sorting_1">11/08/2018</td>
                                                            <td>16/08/2018 - 16/09/2018</td>
                                                            <td>1533352419</td>
                                                            <td>Autoconsumo</td>
                                                            <td>S/. 197.80</td>
                                                            <td>164</td>
                                                            <td>Pagado</td>
                                                            <%--<td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1533352419/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1533352419/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="odd">
                                                            <td class="sorting_1">12/09/2018</td>
                                                            <td>16/09/2018 - 16/10/2018</td>
                                                            <td>1536776568</td>
                                                            <td>Autoconsumo</td>
                                                            <td>S/. 263.40</td>
                                                            <td>181</td>
                                                            <td>Pagado</td>
                                                           <%-- <td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1536776568/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1536776568/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="even">
                                                            <td class="sorting_1">18/10/2018</td>
                                                            <td>18/10/2018 - 18/11/2018</td>
                                                            <td>1539881174</td>
                                                            <td>Autoconsumo</td>
                                                            <td>S/. 192.20</td>
                                                            <td>171</td>
                                                            <td>Pagado</td>
                                                            <%--<td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1539881174/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1539881174/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="odd">
                                                            <td class="sorting_1">20/03/2018</td>
                                                            <td>03/03/2018 - 03/04/2018</td>
                                                            <td>1521489848</td>
                                                            <td>Upgrade</td>
                                                            <td>S/. 226.40</td>
                                                            <td>166</td>
                                                            <td>Pagado</td>
                                                            <%--<td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1521489848/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1521489848/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                        <tr role="row" class="even">
                                                            <td class="sorting_1">27/04/2018</td>
                                                            <td>03/05/2018 - 03/06/2018</td>
                                                            <td>1524844846</td>
                                                            <td>Autoconsumo</td>
                                                            <td>S/. 270.40</td>
                                                            <td>166</td>
                                                            <td>Pagado</td>
                                                            <%--<td>

                                                                <a href="https://www.mioficinaknn.com/tienda/ticket/1524844846/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none">Ver detalle</a>
                                                                <a href="https://www.mioficinaknn.com/tienda/imprimir/1524844846/" target="_blank" class="btn btn-sm btn-outline btn-primary m-b-none" data-toggle="tooltip" data-placement="top" title="Imprimir"><i class="fa fa-print"></i></a>
                                                            </td>--%>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                               <%-- <div class="dataTables_paginate paging_simple_numbers" id="DataTables_Table_0_paginate">
                                                    <ul class="pagination">
                                                        <li class="paginate_button previous disabled" id="DataTables_Table_0_previous">
                                                            <a href="#" aria-controls="DataTables_Table_0" data-dt-idx="0" tabindex="0">Anterior</a></li>
                                                        <li class="paginate_button active">
                                                            <a href="#" aria-controls="DataTables_Table_0" data-dt-idx="1" tabindex="0">1</a></li>
                                                        <li class="paginate_button next disabled" id="DataTables_Table_0_next">
                                                            <a href="#" aria-controls="DataTables_Table_0" data-dt-idx="2" tabindex="0">Siguiente</a></li>
                                                    </ul>
                                                </div>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="tab-2" class="tab-pane">
                                    <div class="panel-body">
                                        <div class="table-responsive m-t">
                                            <div id="DataTables_Table_1_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
                                                <div class="html5buttons">
                                                    <div class="dt-buttons btn-group">
                                                        <a class="btn btn-default buttons-excel buttons-html5" tabindex="0" aria-controls="DataTables_Table_1" href="#">
                                                            <span>Excel</span></a>
                                                        <a class="btn btn-default buttons-pdf buttons-html5" tabindex="0" aria-controls="DataTables_Table_1" href="#">
                                                            <span>PDF</span></a>
                                                        <a class="btn btn-default buttons-print" tabindex="0" aria-controls="DataTables_Table_1" href="#">
                                                            <span>Print</span>
                                                        </a></div>
                                                </div>
                                                <div class="dataTables_length" id="DataTables_Table_1_length">
                                                    <label>Mostrar
                                                        <select name="DataTables_Table_1_length" aria-controls="DataTables_Table_1" class="form-control input-sm">
                                                            <option value="10">10</option>
                                                            <option value="25" selected="selected">25</option>
                                                            <option value="50">50</option>
                                                            <option value="100">100</option>
                                                        </select>
                                                        filas</label></div>
                                                <div id="DataTables_Table_1_filter" class="dataTables_filter">
                                                    <label>Buscar:
                                                        <input class="form-control input-sm" placeholder="" aria-controls="DataTables_Table_1" type="search"></label></div>
                                                <div class="dataTables_info" id="DataTables_Table_1_info" role="status" aria-live="polite">Mostrando 0 de 0 de 0 filas</div>
                                                <table class="table table-bordered dataTables-example1 dataTable no-footer" id="DataTables_Table_1" aria-describedby="DataTables_Table_1_info" role="grid">
                                                    <thead>
                                                        <tr role="row">
                                                            <th class="sorting_asc" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" style="width: 0px;" aria-sort="ascending" aria-label="Fecha de Registro: Activar para ordenar la columna descendente">Fecha de Registro</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" style="width: 0px;" aria-label="Fecha de Vigencia: Activar para ordenar la columna ascendente">Fecha de Vigencia</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" style="width: 0px;" aria-label="Nro. Ticket: Activar para ordenar la columna ascendente">Nro. Ticket</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" style="width: 0px;" aria-label="Tipo: Activar para ordenar la columna ascendente">Tipo</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" style="width: 0px;" aria-label="Monto: Activar para ordenar la columna ascendente">Monto</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" style="width: 0px;" aria-label="Puntos: Activar para ordenar la columna ascendente">Puntos</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" style="width: 0px;" aria-label="Estado: Activar para ordenar la columna ascendente">Estado</th>
                                                            <th class="sorting" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" style="width: 0px;" aria-label="Opciones: Activar para ordenar la columna ascendente">Opciones</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="odd">
                                                            <td colspan="8" class="dataTables_empty" valign="top">No hay registros en la base de datos</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <div class="dataTables_paginate paging_simple_numbers" id="DataTables_Table_1_paginate">
                                                    <ul class="pagination">
                                                        <li class="paginate_button previous disabled" id="DataTables_Table_1_previous">
                                                            <a href="#" aria-controls="DataTables_Table_1" data-dt-idx="0" tabindex="0">Anterior</a></li>
                                                        <li class="paginate_button next disabled" id="DataTables_Table_1_next">
                                                            <a href="#" aria-controls="DataTables_Table_1" data-dt-idx="1" tabindex="0">Siguiente</a></li>
                                                    </ul>
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

            <script type="text/javascript">
                $(document).ready(function () {
                    $('.btnConsultaStatus').click(function () {
                        $('.loading').show();
                        operacion = $(this).data('operacion');
                        params = { csrfsn: csrfsn, operacion: operacion }
                        $.post(base_url + 'ajax/getstatusorden', params, function (data) {
                            swal("Estado de la compra", data.status, "info");
                            console.log();
                            //alert(data.status);
                            $('.loading').hide();
                        })
                    });

                    $('.dataTables-example').DataTable({
                        pageLength: 25,
                        responsive: true,
                        dom: '<"html5buttons"B>lTfgitp',
                        buttons: [
                            { extend: 'excel', title: 'HistorialDeMisCompras' },
                            { extend: 'pdf', title: 'HistorialDeMisCompras' },
                            {
                                extend: 'print',
                                customize: function (win) {
                                    $(win.document.body).addClass('white-bg');
                                    $(win.document.body).css('font-size', '10px');
                                    $(win.document.body).find('table').addClass('compact').css('font-size', 'inherit');
                                }
                            }
                        ]

                    });
                    $('.dataTables-example1').DataTable({
                        pageLength: 25,
                        responsive: true,
                        dom: '<"html5buttons"B>lTfgitp',
                        buttons: [
                            { extend: 'excel', title: 'HistorialDeMisCompras' },
                            { extend: 'pdf', title: 'HistorialDeMisCompras' },
                            {
                                extend: 'print',
                                customize: function (win) {
                                    $(win.document.body).addClass('white-bg');
                                    $(win.document.body).css('font-size', '10px');
                                    $(win.document.body).find('table').addClass('compact').css('font-size', 'inherit');
                                }
                            }
                        ]

                    });
                });

                function validarAnulacion(idsocio, nroorden, eleccion) {
                    swal(
                        {
                            title: "¿Está seguro de anular la compra?",
                            text: "El pedido será " + eleccion,
                            type: "warning",
                            showCancelButton: true,
                            showLoaderOnConfirm: true,
                            confirmButtonColor: "#61862f",
                            confirmButtonText: "SI",
                            cancelButtonText: "NO",
                            closeOnConfirm: true,
                            closeOnCancel: false
                        },
                        function (isConfirm) {
                            if (isConfirm) {
                                $.get(base_url + "anular/" + idsocio + "/" + nroorden, function (data) {
                                    alert(data.msg);
                                    location.reload();
                                })
                            } else {
                                swal("Cancelado", "Se canceló la operación", "error");
                            }
                        }
                    );
                }
            </script>
            <!-- Favorito -->
            <div class="modal inmodal" id="mdlTerminosCondiciones" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content animated bounceInRight">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">TERMINOS Y CONDICIONES</h4>
                        </div>
                        <div class="modal-body">
                            <p><strong>Los Términos y Condiciones del Acuerdo con el Distribuidor Independiente de inResorts:</strong></p>

                            <p>1. Entiendo que como Ejecutivo Independiente de inResorts:</p>

                            <p>a. Tengo el derecho de ofrecer para la venta los productos y servicios de inResorts de acuerdo con estos Términos y Condiciones.</p>

                            <p>b. Tengo el derecho de afiliar a personas con inResorts.</p>

                            <p>c. Entrenaré y motivaré a los Ejecutivos Independientes de mi organización de mercadeo en línea descendente.</p>

                            <p>
                                d. Acataré todas las leyes, ordenanzas, 
reglamentos y normativas municipales y del Estado Peruano; y haré todas
 las declaraciones y pagaré todas las retenciones u otras deducciones 
según lo requerido por cualquier ley, ordenanza, reglamento y normativa
 municipal y del Estado.
                            </p>

                            <p>e. Haré mis obligaciones como Ejecutivo Independiente con honestidad e integridad</p>

                            <p>
                                2. Yo me comprometo a presentar el plan 
de ganancias o mercadeo, y los productos y servicios de inResorts como están 
en la literatura oficial de inResorts.
                            </p>

                            <p>
                                3. Acepto que como Distribuidor 
Independiente de inResorts soy contratista independiente, y no soy empleado, 
agente, socio, representante legal o franquiciante de inResorts.
                            </p>

                            <p>
                                No estoy autorizado ni incurriré en 
deudas, gastos, obligaciones; ni abriré cuentas corrientes a favor, 
para o en nombre de inResorts.
                            </p>

                            <p>
                                Acepto que seré el único responsable de
 pagar todos los gastos en que yo incurra, incluyendo pero no limitando 
viáticos, alimentos, alojamiento, de secretaria, oficina, telefonía de
 larga distancia u otros gastos. ENTIENDO QUE NO ME TRATARÁN COMO 
EMPLEADO DE inResorts POR RAZONES TRIBUTARIAS ESTATALES O FEDERALES.
                            </p>

                            <p>
                                inResorts es de retener o deducir de mis 
bonificaciones y comisiones por efecto de detracciones, abonándola a 
las respectivas cuentas de detracciones del Distribuidor.
                            </p>

                            <p>Al recibirlas, he leído cuidadosamente y acepto acatar las Normas y Procedimientos y el Plan de Mercadeo de inResorts.</p>

                            <p>Entiendo que debo ser de buena reputación, y no infringir este Acuerdo, para tener derecho a bonos y comisiones de inResorts.</p>

                            <p>
                                Entiendo que estos Términos y 
Condiciones, las Normas y Procedimientos de inResorts o el Plan de Mercadeo y 
Compensación de inResorts pueden enmendarse a la sola discreción de inResorts, y 
acepto que cualquier enmienda de tal índole se aplicaría a mi persona.
                            </p>

                            <p>La notificación de enmiendas será publicada en los materiales oficiales de inResorts.</p>

                            <p>
                                La vigencia de este acuerdo es de un 
año. Si dejo de renovar anualmente mi negocio inResorts, o si es cancelado o 
cesante por cualquier motivo, entiendo que perderé mis derechos como 
Ejecutivo Independiente hasta renovar mi negocio inResorts en este caso la 
oficina Virtual.
                            </p>

                            <p>
                                No tendré derecho de vender productos y 
servicios inResorts, ni tendré derecho de recibir comisiones, bonos u otros 
ingresos que resultaran de las actividades de mi antigua organización 
de ventas en línea descendente. En caso de cancelación, terminación o
 no renovación, renuncio a todos mis derechos, incluyendo pero no 
limitados a mi antigua organización en línea descendente, y cualquier 
bonificación, comisión u otra remuneración derivada de las ventas y 
otras actividades de mi antigua organización en línea descendente.
                            </p>

                            <p>
                                inResorts se reserva el derecho de terminar, 
con preaviso de 30 días, todos los Acuerdos de Ejecutivo Independiente 
si la Empresa decidiera: (1) suspender operaciones comerciales, o, (2) 
liquidarse como entidad comercial.
                            </p>

                            <p>
                                6. No puedo traspasar ningún derecho ni 
delegar mis deberes bajo este Acuerdo sin el consentimiento previo por 
escrito de inResorts. Cualquier intento de transferir o traspasar este Acuerdo
 sin el expreso consentimiento por escrito de inResorts, hace que el Acuerdo 
pueda ser rescindido a opción de inResorts y pueda resultar en la 
terminación de mi negocio.
                            </p>

                            <p>
                                7. Entiendo que si dejo de cumplir con 
los términos de este Acuerdo, inResorts puede, a su discreción, aplicarme 
sanciones según se describe en las Normas y Procedimientos. Si 
transgrediera, quebrantara o no cumpliera con el Acuerdo, a su 
conclusión no tendré derecho de recibir más bonificaciones o 
comisiones, sin importar que las ventas que generaron tales 
bonificaciones y comisiones han sido completadas.
                            </p>

                            <p>
                                8.inResorts, sus directores, funcionarios, 
accionistas, empleados, cesionarios y agentes (colectivamente llamados 
“subsidiarios”), no serán responsables, y yo libero a inResorts y sus 
subsidiarios de todas las demandas por daños resultantes y 
compensación punitiva. Acepto además liberar a inResorts y sus subsidiarios 
de cualquier obligación que resulte o esté relacionada con la 
promoción u operación de mi negocio inResorts y cualquier actividad 
relacionada (ej. la presentación de productos o el Plan de Mercadeo y 
Prosperidad de inResorts, la operación de un vehículo automotor, el alquiler
 de instalaciones para reuniones y entrenamiento, etc.) y acepto 
indemnizar a inResorts por cualquier obligación, daño, multas u otras 
indemnizaciones que resulten de la conducta no autorizada en que me 
involucro al realizar mi negocio.
                            </p>

                            <p>
                                9. El Acuerdo, en su forma actual o 
enmendado por inResorts a su discreción, constituye todo el contrato entre 
Knn y yo. Cualquier promesa, representación, oferta u otra 
comunicación que no está estipulada explícitamente en este Acuerdo, 
no tendrá vigencia ni validez.
                            </p>

                            <p>
                                10. Cualquier exoneración por inResorts de 
cualquier infracción del Acuerdo debe estar por escrito y firmada por 
un funcionario de inResorts autorizado para tal fin. La exoneración por inResorts 
de cualquier infracción de mi parte no opera ni será interpretada como
 exoneración de infracciones subsiguientes.
                            </p>

                            <p>
                                11. En caso que alguna estipulación de 
este Acuerdo sea considerada inválida, o que no se pueda hacer cumplir,
 tal estipulación, deberá reformarse sólo hasta el punto necesario en
 que se pueda hacer cumplir y el resto del Acuerdo seguirá válido y 
vigente.
                            </p>

                            <p>
                                12. Este Acuerdo se regirá e 
interpretará conforme a las leyes Peruanas, sin importar los principios
 de conflicto de leyes. Todas las disputas y reclamos en cuanto a inResorts, 
el Acuerdo de Distribuidor Independiente, el Plan de Mercadeo de inResorts o 
sus productos y servicios, los derechos y deberes de un Ejecutivo 
Independiente y inResorts o cualquier otro reclamo o fundamento de causa 
relacionado con la actuación de un Distribuidor Independiente o de inResorts 
bajo este Acuerdo o las Normas y Procedimientos de inResorts, deben resolverse
 mediante arbitraje en Perú.
                            </p>

                            <p>
                                13. Si un Ejecutivo Independiente desea 
emprender un pleito contra inResorts por cualquier hecho u omisión en 
relación o como resultado de este Acuerdo, tal pleito debe emprenderse 
dentro de un lapso de un año a partir de la fecha que ocasionó la 
causa del pleito. La falta de emprender tal pleito dentro de este lapso 
prohibirá todo reclamo contra inResorts para tal hecho u omisión. Los 
Ejecutivos Independientes renuncian a todos los reclamos aplicables bajo
 otros estatutos de limitación.
                            </p>

                            <p>
                                14. Autorizo a inResorts a usar mi nombre, 
fotografía, historia personal o parecido en materiales publicitarios o 
de promoción y renuncio a cualquier pretensión de remuneración para 
tal uso 
                            </p>

                            <p>
                                15. Al rellenar y entregar esta 
Solicitud, autorizo específicamente a inResorts a comunicarse conmigo por 
correo electrónico en la dirección que registré en la oficina 
virtual. Entiendo que tales correos electrónicos pueden incluir ofertas
 y solicitación para la venta de productos inResorts, ayudas de venta y 
servicios.
                            </p>

                            <p>
                                16. Entiendo que cualquier 
representación engañosa de los datos que suministro en esta Solicitud y
 mi Oficina Virtual personal de Acuerdo de Distribuidor Independiente 
puede resultar en sanciones de inResorts, e incluso terminación de este 
Acuerdo.
                            </p>

                            <p>
                                He examinado el contrato y entiendo que 
deberé sujetarme a los términos y condiciones y a la política y 
procedimientos. Al firmar, confirmo que he examinado el contrato y 
entiendo que deberé sujetarme a los términos y condiciones de inResorts . 
Además entiendo que puedo cancelar mi cuenta con inResorts en cualquier 
momento, si envío una solicitud por escrito.
                            </p>
                            <p><strong>TÉRMINOS Y CONDICIONES</strong></p>
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
