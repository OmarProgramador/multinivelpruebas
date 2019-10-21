<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptsUser.aspx.cs" Inherits="MULTI_NIVEL.Views.ReceiptsUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="Script/Script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divProgressBar" style="display: none;">
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
        <br />
        <div class="container">
            <div class="row">
                <div class="col-sm-12 text-right">
                    <asp:Button ID="btnSalir" Text="Salir" runat="server" OnClick="btnSalir_Click" CssClass="btn btn-success" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <h1>Listado de Cronogramas</h1>
                </div>
            </div>
            <div class="zona-collapse" id="zona-collapse">
            </div>
            <div class="row">
            </div>
        </div>
    </form>

    <script src="Script/ScriptReceiptsUser.js"></script>
</body>
</html>
