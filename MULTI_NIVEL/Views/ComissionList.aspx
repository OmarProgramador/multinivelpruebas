<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComissionList.aspx.cs" Inherits="MULTI_NIVEL.Views.ComissionList" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Mis Comisiones | inResorts</title>


    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/StyleLoader.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontaEditarwesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <link href="tienda_files/font-awesome.css" rel="stylesheet">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous">

    <script src="Script/jquery.js"></script>
    <script src="Script/jquery-3.js"></script>
    <script src="Script/bootstrap.js"></script>
    <script src="Script/Script.js"></script>
    <script src="Script/ComissionList.js"></script>
    <style>
        .bg-plomo {
            background-color: #e5e5e5;
            padding: 5px 20px;
        }
    </style>
</head>
<body class="top-navigation pace-done">
    <div id="divProgressBar">
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
    <!--comiit-->
    <form id="form" runat="server">
        <div class="container-fluid">
            <h2>Detalle de Bonus
            </h2>
            <div id="info_commission" class="table-responsive m-t">
            </div>

            <!-- Favorito -->
            <div class="modal inmodal" id="mdlSeeDetail" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content animated bounceInRight">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">Detalles</h4>
                        </div>
                        <div class="modal-body" id="seeDetail">
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer footer-fondo">
                <strong>inResorts - 2018</strong>
            </div>
        </div>
    </form>
</body>
</html>

