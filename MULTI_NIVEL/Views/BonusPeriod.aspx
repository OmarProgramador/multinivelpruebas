<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusPeriod.aspx.cs" Inherits="MULTI_NIVEL.Views.BonusPeriod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title></title>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link href="Css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <script src="Script/Script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-9">
                    <h1>Periodos</h1>
                </div>
                <div class="row col-sm-3">
                    <div class="form-group">
                        <a href="MenuBackend.aspx" class="btn btn-secondary" style="margin-top: 20px;">Menu</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <input type="button" name="name" value="Nuevo Periodo" class="btn btn-outline-success" onclick="DisplayModal()" />
                </div>
            </div>
            <div class="row mt-5">
                <div class="col-lg-12">
                    <div id="infoPeriod" class="table-responsive">
                        <div class="spinner-border" role="status">
                            <span class="sr-only">Loading...</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="CreateModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Nuevo Periodo</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group">
                                    <label>Fecha de Inicio</label>
                                    <div class="input-group date">
                                        <input id="Period-From" type="text" class="form-control" /><span class="input-group-addon"><i class="glyphicon glyphicon-th far fa-calendar-alt"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-group">
                                    <label>Fecha de Fin</label>
                                    <div class="input-group date">
                                        <input id="Period-Until" type="text" class="form-control" /><span class="input-group-addon"><i class="glyphicon glyphicon-th far fa-calendar-alt"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-group">
                                    <label>Fecha de Pago</label>
                                    <div class="input-group date">
                                        <input id="Period-PayDate" type="text" class="form-control" /><span class="input-group-addon"><i class="glyphicon glyphicon-th far fa-calendar-alt"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-primary" onclick="SaveChanges()">Guardar Cambios</button>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="Script/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript">
        const d = document
        function DisplayModal() {
            $("#CreateModal").modal("show");
        }

        function SaveChanges() {
            let _from = d.getElementById('Period-From').value;
            let _until = d.getElementById('Period-Until').value;
            let _payDate = d.getElementById('Period-PayDate').value;
            let param = "action=new&from=" + _from + "&until=" + _until + "&paydate=" + _payDate;
            GetDos("BonusPeriodC", param, (data) => {
                alert(data)
                location.reload();
            })
        }

        function PayBonus(_id) {
            let param = "action=paybonus&id=" + _id;
            GetDos("BonusPeriodC", param, (_data) => {
                alert(_data);
            });
        }

        function AnswerStatus(data) {
            alert(data)
            location.reload();
        }

        function Activate(_id) {
            let param = "action=status&option=1&id=" + _id;
            GetDos("BonusPeriodC", param, AnswerStatus);
        }

        function Defuce(_id) {
            let param = "action=status&option=0&id=" + _id;
            GetDos("BonusPeriodC", param, AnswerStatus);
        }

        window.onload = function () {
            let param = "action=list";
            GetDos("BonusPeriodC", param, (data) => {
                document.getElementById('infoPeriod').innerHTML = data;
            });
        }



        $('.input-group.date').datepicker({
            format: "dd/mm/yyyy",
            keyboardNavigation: false,
            forceParse: false
        });

        function HistoryRange(_id) {
            let param = "action=historyrange&id=" + _id;
            GetDos("BonusPeriodC", param, (_data) => {
                alert(_data)
            })
        }

        function HistoryRangeResidual(_id) {
            let param = "action=historyrangeresidual&id=" + _id;
            GetDos("BonusPeriodC", param, (_data) => {
                alert(_data)
            })
        }

    </script>
</body>
</html>
