<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMembPagos.aspx.cs" Inherits="MULTI_NIVEL.Views.AddMembPagos" %>

<!DOCTYPE html>
<html>
<head>
    <title>Forma de Pago | Inresorts</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link href="Css/MyStyle.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">
    
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <style>
        input[type=radio] {
            /* Double-sized Checkboxes */
            -ms-transform: scale(1.8); /* IE */
            -moz-transform: scale(1.8); /* FF */
            -webkit-transform: scale(1.8); /* Safari and Chrome */
            -o-transform: scale(1.8); /* Opera */
            padding: 10px;
        }
    </style>
</head>
<body>
    <form runat="server" id="form1">
        <div class="container">
            <section class="pagos">

                <section class="encabezado">
                    <div class="row">
                        <div class="col-12">
                            <div class="text-center">
                                <img class="logo" src="img/novologo.png" alt="Inresorts" />
                            </div>
                        </div>
                    </div>
                </section>
                <section class="formas-pago" style="border-radius:27px;box-shadow: 1px 3px 9px 0px black;padding: 16px;">
                    <div class="row">
                        <div class="col-12">
                            <span style="color: #2981c5">LISTA DE MEDIOS DE PAGO : seleccione un medio de pago y luego clic en boton "Pagar"</span>                        
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">   
                            
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-9">
                            <div class="row">
                                <div class="box_mediospago_lista_titulo anchura" style="text-decoration-color: chartreuseM;width: 95%;">
                                <div id="ctl00_ContentPlaceHolder1_DivMPSafetyPayT" class="box_mediospago_lista_item2 holi" style="    box-shadow: 0px 0px 3px 1px #6f6d6d;margin: 14px;font-size:16px;width:100%;color:black;font-weight:100;display:flex">
                                        <div class="box_mpli_check" style="margin:16px">
                                            <asp:RadioButton runat="server" GroupName="option" ID="rbWallet" value="5"></asp:RadioButton>
                                        </div>
                                        <div class="box_mpli_img3" style="width: 40px; height: 90px; display: flex">
                                            <img src="img/wallete.png" border="0" style="width: 100px">
                                        </div>
                                        <center>    
                                            <ul>
                                                <li style="font-size:15px;list-style:none;padding-top:20px;padding-left:64px"><b>Paga con tu Wallet</b></li>
                                                <li style="list-style:none;padding-left:64px">Paga Tus cuotas con tu billetera virtual </li>
                                            </ul>
                                        </center>
                                    </div> 
                            </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-md-6" style="padding-left: 0;padding-right:0">
                                    <section class="forma-pago" style="box-shadow: 0px 0px 3px 0px #999;margin: 14px;height: 320px;">
                                        <div class="row">
                                            <div class="col-12  ">
                                                <div class="pago-item" style="height:64px">
                                                    <div class="row">
                                                        <div class="col-12">

                                                            <div class="controles">
                                                                <input type="radio" style="padding:5px" id="rbOnLine" name="option" value="1" class="boton" />
                                                                <img src="img/logo_visa.png" alt="Alternate Text" class="logo" />
                                                            </div>
                                                            <div class="informacion">
                                                                <h3 class="titulo">Visa</h3>
                                                                <p class="parrafo">Tarjetas de credito o debito</p>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12  ">
                                                <div class="pago-item" style="height:64px">
                                                    <div class="row ">
                                                        <div class="col-12">
                                                            <div class="controles">
                                                                <input type="radio" style="padding:5px" name="rbEfectivoe" value="" class="boton boton-h" />
                                                                <img src="img/mastercardpayu2.png" alt="Alternate Text" class="logo" />
                                                            </div>
                                                            <div class="informacion">
                                                                <h3 class="titulo">Master Card</h3>
                                                                <p class="parrafo">Tarjetas de credito o debito</p>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12  ">
                                                <div class="pago-item" style="height:64px">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="controles">
                                                                <input type="radio" style="padding:5px" name="rbEfectivoe" value="" class="boton boton-h" />
                                                                <img src="img/dinersclubpayu2.png" alt="Alternate Text" class="logo" />
                                                            </div>
                                                            <div class="informacion">
                                                                <h3 class="titulo">Diners Club</h3>
                                                                <p class="parrafo">Tarjetas de credito o debito</p>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12  ">
                                                <div class="pago-item" style="height:64px">
                                                    <div class="row ">
                                                        <div class="col-12">
                                                            <div class="controles">
                                                                <input type="radio" style="padding:5px" name="rbEfectivoe" value="" class="boton boton-h" />
                                                                <img src="img/americanexpresspayu2.png" alt="Alternate Text" class="logo" />
                                                            </div>
                                                            <div class="informacion">
                                                                <h3 class="titulo">American Express</h3>
                                                                <p class="parrafo">Tarjetas de credito o debito</p>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </div>
                                <div class="col-sm-12 col-md-6" style="padding-left: 0;padding-right:0"">
                                    <section class=" forma-pago" style="margin: 15px;height: 320px;">
                                        <div class="row" style="height: 100px;">
                                            <div class="col-12 mt-2">
                                                <div class="pago-item contenedor" style="height: 90px;" >
                                                    <div class="row ">
                                                        <div class="col-12">
                                                            <div class="controles">
                                                                <!--<input type="radio" id="rbAgentes" name="option" value="2" class="boton" />-->
                                                                <asp:RadioButton style="padding:5px" ID="rbAgentes" GroupName="option" value="2" class="boton" runat="server" />
                                                                <img src="img/bcpagente123.jpg" alt="Alternate Text" class="logo" />
                                                            </div>
                                                            <div class="informacion">
                                                                <h3 class="titulo">Pago en Efectivo</h3>
                                                                <p class="parrafo">Oficinas y Agentes</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="height: 100px;">
                                            <div class="col-12 mt-2">
                                                <div class="pago-item contenedor"  style="height: 90px;" >
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="controles">
                                                                <!-- <input type="radio" id="rbBanca" name="option" value="3" class="boton" />-->
                                                                <asp:RadioButton style="padding:5px" ID="rbBanca" GroupName="option" value="3" class="boton" runat="server" />
                                                                <img src="img/bcp123.png" alt="Alternate Text" class="logo" />
                                                            </div>
                                                            <div class="informacion">
                                                                <h3 class="titulo" style="padding-top:15px">Banca por Internet</h3>
                                                               <%-- <p class="parrafo">--</p>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="height: 100px;">
                                            <div class="col-12 mt-2 mb-4">
                                                <div class="pago-item contenedor"  style="height: 90px;" >
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <div class="controles">
                                                                <!--<input type="radio" id="rbOficina" name="option" value="4" class="boton" />-->
                                                                <asp:RadioButton ID="rbOficina" style="padding:5px" GroupName="option" value="4" class="boton" runat="server" />
                                                                <img src="img/logosf2.png" alt="Alternate Text" class="logo" />
                                                            </div>
                                                            <div class="informacion">
                                                                <h3 class="titulo">Pago en Oficina o Club</h3>
                                                                <p class="parrafo">Tarjeta y/o Efectivo</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>

                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">

                            <div class="row">
                                <div class="col-12 mt-2">
                                    <section class="procesos">
                                        <div class="informacion">
                                            <h3 class="titulo text-dark">Descuento Por Codigo</h3>
                                            <p>
                                                <asp:Label ID="lblDescuento" Text="0.00" runat="server" CssClass="text-dark" />
                                            </p>
                                            <p>
                                                <label class="titulo text-dark">Total a Pagar</label>
                                            </p>
                                            <p>
                                                
                                                <asp:Label ID="CC" Text="PEN" runat="server" class="total-pagar text-dark"/>
                                                &nbsp;&nbsp;
                                                <asp:Label ID="lblTotalPagar" Text="0.00" runat="server" CssClass="total-pagar text-dark" />
                                            </p>
                                            <!--<input id="btnProcesar" class="btn btn-primary mt-2" type="button" name="Procesar" value="Procesar" />-->
                                            <asp:Button ID="btnProcesar" class="btn btn-primary mt-2" name="Procesar" Text="Procesar" runat="server" OnClick="btnProcesar_Click" />
                                            <div class="pie-pagina mt-5">
                                                <p>
                                                    <label class="text-dark">Tipo de Cambio</label>
                                                </p>
                                                <p>
                                                    <label></label>
                                                    <asp:Label ID="lblTipoCambio" runat="server" CssClass="text-dark" />
                                                </p>
                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>

                        </div>
                    </div>
                </section>
                <section class="detalle">
                    <div class="row mt-5">
                        <div class="col-12 text-center">
                            <h4>Detalle de tu Compra</h4>
                        </div>
                    </div>
                    <div class="row ">
                        <div class="col-12 table-responsive">
                            <table id="tbDetalle" class="table">
                                <thead>
                                    <tr>
                                       
                                        <th class="text-center">Descripcion</th>
                                        <th class="text-center">Precio U.</th>
                                        <th class="text-center">Cantidad</th>
                                        <th class="text-center">Sub Total</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        
                                        <td class="text-center">
                                            <asp:Label ID="lblDescripcion" Text="Descripction" runat="server" /></td>
                                        <td class="text-center">
                                            <asp:Label ID="lblPrecio" Text="15000.00" runat="server" />
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblCantidad" Text="1" runat="server" />
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblSubTotal" Text="1500.00" runat="server" />
                                        </td>

                                    </tr>
                                    <tr>
                                       
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                        <td class="text-right font-weight-bold">Total Membresia:</td>
                                        <td class="text-center font-weight-bold">
                                            <asp:Label ID="lblTotal" Text=" 1500.00" runat="server" />
                                        </td>

                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </section>
            </section>
        </div>
    </form>
    <footer class="bg-dark mt-5">
        <div class="container">
            <div class="row">
                <div class="col-12 text-center text-light">
                    <p class="m-2">
                        <label>&copy;Inresorts 2018</label>
                    </p>
                </div>
            </div>
        </div>
    </footer>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="Script/ScriptAddMembPagos.js"></script>
</body>
</html>
