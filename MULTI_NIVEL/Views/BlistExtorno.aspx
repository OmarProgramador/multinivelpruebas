<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlistExtorno.aspx.cs" Inherits="MULTI_NIVEL.Views.BlistExtorno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Extorno</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <style>
        .display-none {
            display: none;
        }

        .error {
            color: red;
        }

        .negrita {
            font-weight: 700;
        }

        .table td {
            padding: 0 !important;
        }

        .negrita small {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off" onsubmit="return FormSubmit();">
        <div class="container mt-3">
            <div class="row">
                <div class="col-sm-9">
                    <h1>Listado de socios Extornados</h1>
                </div>
                <div class="row col-sm-3">
                    <div class="form-group">
                        <a href="MenuBackend.aspx" class="btn btn-secondary" style="margin-top: 20px;">Menu</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <a href="Bextorno.aspx" class="btn btn-success">Extornar a un Socio</a>
                </div>
                <div class="col-12">
                    <br />
                    <div id="List-Extorno">
                        <div class="spinner-border" role="status">
                            <span class="sr-only">Loading...</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>       
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="Script/Script.js"></script>
    <script type="text/javascript">
        const d = document

        window.onload = function () {
            let param = "action=list"
            GetDos("BlistExtornoC", param, (_data) => {
                d.getElementById('List-Extorno').innerHTML = _data
            });
        };
    </script>
</body>
</html>