<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EndPayments.aspx.cs" Inherits="MULTI_NIVEL.Views.EndPayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196" />
    <title>Fin de mi Afiliacion - Inresorts</title>

    <style type="text/css">
        .btn-SendEmail {
            color: White;
            font-size: 18px;
            background-color: #0e69b7;
            box-shadow: 3px 3px 8px black;
            cursor: pointer;
            width: 300px;
            height: 50px;
            border-radius: 8px;
            border: none;
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
                <img src="img/checkfin.png" alt="Alternate Text" style="width: 90px; text-align: center" />
                <br />
                <br />
                <h1 style="display: inline; color: #3f7cd8; margin-left: 2%; margin-right: 2%">Registro Exitoso</h1>
                <p style="color: #3f7cd8; padding: 20px; font-size: 20px; padding-left: 50px; padding-right: 50px">Ya eres parte de la familia inResorts, aprovechalo al maximo y empeza a disfrutar de todos tus beneficios.</p>
                <a href="Index.aspx" class="btn-SendEmail">Volver al Inicio</a>
            </div>
            <div>
            </div>
        </div>
    </form>
</body>
</html>
