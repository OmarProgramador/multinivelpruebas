<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackEnd.aspx.cs" Inherits="MULTI_NIVEL.Views.BackEnd" %>


<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <meta charset="utf-8" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row">
                <div class="col-12">
                    <div id="login" style="max-width: 500px;" class="m-auto p-5 border border-primary shadow-lg">                       
                        <div class="text-center"> 
                            <h1>Iniciar Sesion</h1>
                            <img src="img/novologo.png" class="img-responsive" width="100px">
                        </div>
                        <div class="form-Group">
                            <label for="textBoxUsername">Username:</label>
                            <asp:TextBox ID="txtUserBackend" runat="server" CssClass="form-control" name="usuario" placeholder="Usuario"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserBackend" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-Group">
                            <label for="textBoxPassword">Password:</label>
                            <asp:TextBox ID="txtUserPassword" runat="server" CssClass="form-control" name="usuario" placeholder="Password" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtUserPassword" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-Group">
                            <br />
                            <asp:Button ID="btnLoginBackend" runat="server" CssClass="btn btn-primary btn-block" data-style="expand-right" Text="INGRESAR" OnClick="btnLogin_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>


