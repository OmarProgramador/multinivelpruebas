<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EndPayments3.aspx.cs" Inherits="MULTI_NIVEL.Views.EndPayments3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196" />
    <style type="text/css">
        .btn-sendEmail {
            color: White;
            font-size: 18px;
            background-color: #0e69b7;
            box-shadow: 3px 3px 8px black;
            cursor: pointer;
            width: 50%;
            height: 50px;
            border-radius: 8px;
            border: none;
            padding: 10px;
            text-decoration: none;
        }
        .btn-sendEmail:hover{
             background-color:#0c497d;
        }
    </style>
</head>
<body style="background-color: #3692e2; background-repeat: no-repeat; object-fit: cover;">
    <%--background-color:#4192d8"--%>
    <form id="form1" runat="server">
        <div id="contenedor" style="">
            <div style="text-align: center; margin: 10%; background-color: #fff; height: 575px; border-radius: 8px; box-shadow: 5px 5px 18px Black">
                <img src="img/novologo.png" alt="Alternate Text" style="width: 250px; text-align: center" />
                <br />
                <br />
                <img src="img/lupa2.png" alt="Alternate Text" style="width: 90px; text-align: center" />
                <br />
                <br />
                <%--<h1 style="display:inline;color:#f2931d;">Feli</h1><h1 style="display:inline;color:#1570c3">cidades</h1>--%>
                <h1 style="display: inline; color: #3f7cd8; margin-left: 2%; margin-right: 2%">¡APRESURATE!, Te esperamos!!!!</h1>
                <p style="color: #3f7cd8; padding: 20px; font-size: 20px; padding-left: 50px; padding-right: 50px">Muy pronto seras parte de la familia inResorts</p>
                <a href="Index.aspx" class="btn-sendEmail">Volver al Inicio
                </a>
            </div>
            <div>
            </div>
        </div>
    </form>
</body>
</html>
