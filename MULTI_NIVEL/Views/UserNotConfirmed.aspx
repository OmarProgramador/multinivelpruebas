<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserNotConfirmed.aspx.cs" Inherits="MULTI_NIVEL.Views.UserNotConfirmed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Usuarios no confirmados</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid mt-3">
            <div class="row">
                <div class="col-sm-9">
                    <h1>Listado de Usuarios Sin Confirmar</h1>
                </div>
                <div class="row col-sm-3">
                    <div class="form-group">
                        <a href="MenuBackend.aspx" class="btn btn-secondary" style="margin-top: 20px;">Menu</a>
                    </div>
                </div>
            </div>
            <div class="row">               
                <div class="col-12">
                    <br />
                    <div id="List-User">
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
            GetDos("UserNotConfirmedC", null, (_data) => {
                d.getElementById('List-User').innerHTML = _data
            })
        }
    </script>
</body>
</html>
