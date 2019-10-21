<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comission.aspx.cs" Inherits="MULTI_NIVEL.Views.Comission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">

    <script src="Script/Script.js"></script>
    <script src="Script/Comission.js"></script>
</head>
<body>
    <form id="form1" runat="server">
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
        <div style="margin:auto;padding:20px;">
            <div class="container">
            <div class="row">
                <div class="col-sm-12 text-right">
                    <asp:Button CssClass="btn btn-success" Text="Salir" runat="server" OnClick="Unnamed_Click"/>
                </div>
            </div>
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
                                                 <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 10px;" aria-label="Periodo: Activar para ordenar la columna ascendente">Identificador</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 10px;" aria-label="Periodo: Activar para ordenar la columna ascendente">Usuario</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 10px;" aria-label="Periodo: Activar para ordenar la columna ascendente">Nombre</th>
                                                <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 10px;" aria-label="Periodo: Activar para ordenar la columna ascendente">Numero De Documento</th>
                                                 <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 10px;" aria-label="Periodo: Activar para ordenar la columna ascendente">Telefono</th>
                                                 <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 10px;" aria-label="Periodo: Activar para ordenar la columna ascendente">Correo</th>
                                                 <th class="sorting" tabindex="0" aria-controls="DataTables_Table_0" rowspan="1" colspan="1" style="width: 10px;" aria-label="Periodo: Activar para ordenar la columna ascendente">Accion</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tblPayments">
                                        </tbody>
                                    </table>
                                    <div class="dataTables_paginate paging_simple_numbers" id="DataTables_Table_0_paginate">
                                        <ul class="pagination">
                                            <li class="paginate_button previous" id="DataTables_Table_0_previous"><a aria-controls="DataTables_Table_0" data-dt-idx="0" tabindex="0" onclick="buttonPages(0);">Anterior</a></li>
                                            <li class="paginate_button active"><a href="#" aria-controls="DataTables_Table_0" data-dt-idx="1" tabindex="0" id="lblNumPageCurrent">-1</a></li>
                                            <li class="paginate_button next" id="DataTables_Table_0_next"><a aria-controls="DataTables_Table_0" data-dt-idx="2" tabindex="0" onclick="buttonPages(1);">Siguiente</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
        </div>
    </form>
     <script src="Script/Comission.js"></script>
</body>
</html>


