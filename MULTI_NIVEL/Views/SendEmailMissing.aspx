<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmailMissing.aspx.cs" Inherits="MULTI_NIVEL.Views.SendEmailMissing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <style>
        .negrita {
            font-weight: 700;
        }

            .negrita span {
                font-weight: normal;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-2">
            <h1>Envio de Email</h1>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-inline">
                        <label>UserName: </label>
                        <asp:TextBox ID="txtUserName" runat="server" class="form-control ml-sm-2 mr-sm-2" />
                        <asp:Button ID="Confirmar" Text="Confirmar" runat="server" OnClick="Confirmar_Click" CssClass="btn btn-outline-success" />
                    </div>
                </div>

                <div class="col-lg-12">
                    <hr />
                    <h2>Datos</h2>
                    <p class="negrita">
                        Nombre Completo: 
                    <asp:Label ID="NameUser" Text="" runat="server" />
                    </p>

                    <p class="negrita">
                        Correo Electronico: 
                    <asp:Label ID="EmailUser" Text="" runat="server" />
                    </p>
                </div>
                <div class="col-lg-12">
                    <div class="form-check">
                        <asp:RadioButton ID="rbDoc" Text="Documentos" runat="server" GroupName="elegir" />
                    </div>
                    <div class="form-check">
                        <asp:RadioButton ID="rbRece" Text="Para Subir Recibo" runat="server" GroupName="elegir" />
                    </div>
                    <div class="form-check">
                        <asp:RadioButton ID="rbQuote" Text="Cuota Faltante" runat="server" GroupName="elegir" />
                    </div>
                </div>
                <div class="col-lg-12">
                    <asp:Button ID="SendEmail" Text="Enviar" CssClass="btn btn-primary" OnClick="SendEmail_Click" runat="server" />
                </div>

                <div class="col-lg-12">
                    <asp:Label ID="MessageSucces" Text="" runat="server" ForeColor="Green" />
                    <asp:Label ID="MessageError" Text="" runat="server" ForeColor="Red" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>
