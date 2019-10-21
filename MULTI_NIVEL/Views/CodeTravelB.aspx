<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodeTravelB.aspx.cs" Inherits="MULTI_NIVEL.Views.CodeTravelB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <script src="Script/Script.js"></script>
</head>
<body onload="GetNotConfirmed();">
    <div id="divProgressBar" style="display:none">
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
    <div class="container" style="margin-top:50px;">
        <div class="row col-lg-12"><a href="MenuBackend.aspx" class="btn btn-primary">Menu</a></div>
        <div class="row">
            <div class="col-lg-12">
                <div id="data"></div>
            </div>
        </div>
    </div>
    <script src="Script/ScriptTravelB.js"></script>
</body>
</html>
