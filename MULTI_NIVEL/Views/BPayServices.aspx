<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BPayServices.aspx.cs" Inherits="MULTI_NIVEL.Views.BPayServices" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Listado de pagos de servicios pendientes - InResorts</title>
    <link href="Css/BStyle.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
    <script src="Script/Script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
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
        <div class="container">
            <header>
                <div class="row">
                    <div class="col-lg-12 text-right mt-10">
                        <a href="MenuBackend.aspx">Atras</a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <h1>Listado de pagos de servicios pendientes</h1>
                    </div>
                </div>
            </header>
            <section>
                <div class="row">
                    <div id="listAccount" class="col-lg-12">
                    </div>
                </div>
            </section>
            
                <div class="modal fade" id="confirmModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Confirmacion</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                               <p id="TitleModal">¿Esta seguro de aceptar el recibo?</p>    
                               <div class="form-group" id="DivAmount">
                                <label for="Obs">Monto S/</label>  
                                 <input type="text" id="Amount" name="Obs" value="" class="form-control"/>
                                  </div>  
                                <div class="form-group">
                                <label for="Obs">Escriba Una Observacion </label>  
                                 <input type="text" id="Obs" name="Obs" value="" class="form-control"/>
                                  </div>                   

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-primary" id="Aceptar">Confirmar</button>
                            </div>
                        </div>
                    </div>
                </div>
            
        </div>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
        <script src="Script/ScriptBPayServices.js"></script>

    </form>
</body>
</html>
