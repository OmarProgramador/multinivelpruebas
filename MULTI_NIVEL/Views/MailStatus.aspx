<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailStatus.aspx.cs" Inherits="MULTI_NIVEL.Views.MailStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/css.css" rel="stylesheet" />

    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <script src="Script/Script.js"></script>

    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>

</head>
<body>
   <form id="form1" runat="server">
        <nav class="navbar navbar-static-top" role="navigation" style="height: 75px">
            <div class="navbar-header header-inicio">
                <button aria-controls="navbar" aria-expanded="false" data-target="#navbar" data-toggle="collapse" class="navbar-toggle collapsed" type="button">
                    <i class="fa fa-reorder"></i>
                </button>
                <a href="Index.aspx" class="navbar-brand inicio-logo">
                    <img src="img/novologo.png" style="width:81px" class="img-responsive"></a>
            </div>
            <div class="navbar-collapse collapse" id="navbar">
                <ul class="nav navbar-top-links navbar-right header-inicior">
                    <li>
                        <asp:LinkButton ID="btnSalir" Text="Salir" runat="server" OnClick="btnSalir_Click" />
                    </li>
                </ul>
            </div>
        </nav>
        <div class="container" style="margin-top: 30px;">
            <div class="row">
                <div class="col-sm-12">
                    <h3>Menu</h3>
                </div>
                
            <div class="row">
               <div class="col-sm-6">
                   <asp:Button runat="server" Text="Correos Activos" ID="btnActive" class="btn btn-primary btn-block" style="margin:5px;"  OnClick="btnActive_Click"/>
                </div>
            </div>
           
              <div class="row">
               <div class="col-sm-6">
                   <asp:Button runat="server" Text="Correos Pendientes" ID="btnPending" class="btn btn-warning btn-block" style="margin:5px;"  OnClick="btnPending_Click"/>
                </div>
            </div>
        </div>
            </div>
    </form>
</body>
</html>
