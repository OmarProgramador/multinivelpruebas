<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodeTravelBData.aspx.cs" Inherits="MULTI_NIVEL.Views.CodeTravelBData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <script src="Script/Script.js"></script>
</head>
<body >
    <div class="container" style="margin-top:50px;">
        <div class="row col-lg-12"><a href="CodeTravelB.aspx" class="btn btn-primary">Listado</a></div>
         <div class="row">
            <div class="col-lg-6">
                <h1>Datos de confirmacion</h1>
            </div>         
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                   <label> Id User</label>
                    <label id="id" style="padding:10px;background-color:yellow;border-radius:40px;"></label>                 
                </div>
            </div>         
        </div>
        <div class="row">
            
            <div class="col-lg-6">
                <div class="form-group">
                   <label>Contraseña</label>
                    <input type="text" name="passTravel" id="passTravel" value="" class="form-control"/>
                </div>
            </div>
      
            <div class="col-lg-6">
                <div class="form-group">
                   <label>Codigo</label>
                    <input type="text" name="code" id="code" value="" class="form-control"/>
                </div>
            </div>
           
        </div>
        <div class="row">
            <div class="col-lg-12">
                <small id="error-confir" style="color:red;"></small>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <input type="button" name="btnConf" value="Aceptar" onclick="btnConfirm();" class="btn btn-primary"/>
            </div>
        </div>
    </div>
    <script src="Script/ScriptTravelB.js"></script>
    <script type="text/javascript">
        let _id = getParameterByName("id");
        document.getElementById('id').innerText = _id;
    </script>
</body>
</html>
