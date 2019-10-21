<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailAccountActive.aspx.cs" Inherits="MULTI_NIVEL.Views.MailAccountActive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Listado de Socios</title>
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <script src="Script/Script.js"></script>
</head>
<body onload="ListPartner();">
    <div id="divProgressBar" style="display: block">
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
    <div class="container-fluid" style="margin-top: 50px;">
        <div class="row col-lg-12">
            <div class="form-group">
                <a href="MenuBackend.aspx" class="btn btn-primary">Menu</a>
            </div>
        </div>
        <div class="row">
           <%-- <div class="col-lg-6">
                <div class="form-group">
                    <input type="text" id="TextValue" class="form-control" name="name" value="" style="max-width: 3000px"/>
                </div>
            </div>--%>
            <%--<div class="col-lg-6">
                <div class="form-group">
                    <input type="button" id="" class="btn btn-success" name="name" value="Buscar" style="max-width: 300px" onclick="FilterPartner('TextValue')"/>
                </div>
            </div>--%>
        </div>
         
        <div>
   
        </div>
        <div class="row mt-4">
            <div class="col-lg-12">
                <div id="data"></div>
            </div>
        </div>
    </div>
    <script src="Script/MailAccountActive.js"></script>
</body>
</html>
