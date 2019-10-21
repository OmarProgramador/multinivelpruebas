<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_VitualOffice.aspx.cs" Inherits="MULTI_NIVEL.Views._VitualOffice" %>

<style>
    .display-none {
        display: none !important;
    }

    div .menu-lateral-opciones {
        display:block;
    }
</style>
<div class="linkstienda visible-md visible-lg" style="background-color:white;">
    <div class="col-md-3" style="width: 20% !important">
        <!-- <a href="javascript:void(0)" onclick="$('.menu-lateral-opciones').slideToggle(1)">
                                                            <img class="center-block oficinaimg" src=""  border="0" />
                                                        </a> -->
        <a href="javascript:void(0)" id="Oficce-Enlace">
            <img class="center-block oficinaimg" src="img/oficinavirtualsol.png" border="0">
        </a>
    </div>
    <div id="Oficce-Lateral" class="col-md-9 menu-lateral-opciones display-none">
        <div class="row">
            <div class="col-md-2 separadorbarra" style="z-index: 100;">
                <a href="Register.aspx">
                    <img src="../Resources/Images/nuevo.png" class="img-responsive center-block height">Nuevo Socio</a>
            </div>
            <div class=" col-md-2 separadorbarra " style="z-index: 100;">
                <a href="Tools.aspx">
                    <img src="img/universidad.png" class="img-responsive center-block height">Sistema Educativo</a>
            </div>
            <div class="col-md-2  separadorbarra " style="z-index: 100;">
                <a href="Red.aspx">
                    <img src="../Resources/Images/redes.png" class="img-responsive center-block height">Arbol Residual</a>
            </div>
            <div class="  col-md-2 separadorbarra ">
                <a href="Bonus.aspx">
                    <img src="../Resources/Images/comisiones.png" class="img-responsive center-block height">Comisiones y Pagos</a>
            </div>

            <div class="col-sm-1 col-md-2 separadorbarra ">
                <a href="Store.aspx">
                    <img src="../Resources/Images/shop3.svg" class="img-responsive center-block height" border="0">Tienda</a>
            </div>
        </div>
    </div>
</div>
