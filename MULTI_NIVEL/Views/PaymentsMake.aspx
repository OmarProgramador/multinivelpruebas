<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentsMake.aspx.cs" Inherits="MULTI_NIVEL.Views.PaymentsMake" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />

    <style>
        .error-file{
            border: 2px solid red;
        }

            .error-file::after {
                content: "Campo Obligatorio";
                background-color: red;
                color: white;
                position: absolute;
                top: 150px;
                right:20px;
                z-index:100;
            }


    </style>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return validar();">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-9">
                    <h1>Listado de pagos pendientes.</h1>
                </div>
                <div class="row col-sm-3">
                    <div class="form-group">
                        <a href="MenuBackend.aspx" class="btn btn-secondary" style="margin-top: 20px;">Menu</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div id="dataHtml">
                        <img src="../Resources/Images/Loading.gif" />
                    </div>
                </div>
            </div>

            <div class="modal fade" id="aceptModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Aceptar Solicitud</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <h5>¿Esta seguro de confirmar el deposito?</h5>

                            <asp:TextBox runat="server" ID="DepositId" Style="display: none" />
                            <div class="form-group">
                                <label for="Deposit-Obs">Observacion adicional </label>

                                <asp:TextBox runat="server" ID="DepositObs" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="Deposit-Obs">Voucher de deposito (<small style="color: red">Obligatorio</small>)</label>
                                <asp:FileUpload ID="DepositVoucher" runat="server" class="form-control" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                            <asp:Button ID="SendVoucher" Text="Si acepto" runat="server" class="btn btn-primary" OnClick="SendVoucher_Click" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="Script/Script.js"></script>
    <script type="text/javascript">

        const d = document
        var idwallet = 0
        var _binary = ""

        function validar() {
            let _file = d.getElementById('DepositVoucher').value
            d.getElementById('DepositVoucher').className = "";

            if (_file === "") {
                d.getElementById('DepositVoucher').className = "error-file";
                return false;
            }
        }

        d.addEventListener("change", e => {

            if (e.target.matches("#DepositVoucher")) {
                d.getElementById('DepositVoucher').className = "";
                if (e.target.value === "") {
                    d.getElementById('DepositVoucher').className = "error-file";
                }
            }

        })

        window.onload = function () {

            GetDos("PaymentsMakeC", "action=get", (_data) => {
                d.getElementById('dataHtml').innerHTML = _data
            })

        }

        function DisplayModalPay(_id) {
            idwallet = _id
            d.getElementById('DepositVoucher').className = "";

            d.getElementById('DepositId').value = _id
            $("#aceptModal").modal("show")
        }




    </script>
</body>
</html>
