<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayServices2.aspx.cs" Inherits="MULTI_NIVEL.Views.PayServices2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Deposito | Ribera del Rio</title>
    <!--START LayoutTopV4-->
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <link href="./pagos_files/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="./pagos_files/slick.min.css" rel="stylesheet" type="text/css">
    <link href="./pagos_files/fonts.css" rel="stylesheet" type="text/css">
    <link href="./pagos_files/common.min-4.24.6.0.css" rel="stylesheet" type="text/css">
    <script src="./pagos_files/jquery.min.js.descarga" type="text/javascript"></script>
    <link href="./pagos_files/styles_per.min-4.25.5.0.css" rel="stylesheet" type="text/css">
    <link href="./pagos_files/print_per.min.css" rel="stylesheet" media="print">
</head>
<body class="container" id="peru" style="">
    <form runat="server" style="margin: 0;">
        <input type="hidden" name="ChangedCountryID" value="">
        <div id="expressHeader">
            <div class="LogoComerciante">
                <div class="LogoComerciante-content">
                    <div id="MerchantBrandingImage" style="" class="logo">
                        <a href="Index.aspx" class="navbar-brand inicio-logo" style="float: none">
                            <img src="img/novologo.png" alt="Cuponidad Perú">
                        </a>
                    </div>
                </div>
            </div>
            <header class="Header" id="header">
                <div class="Header-content">
                    <div class="Header-tabs">
                        <div class="left" style="">
                            <a id="tabOnline" href="#" title="Banca por internet" class="button is-active">Deposito Bancario</a>
                            <%-- <a id="tabCash" href="#" title="Pagar en efectivo" class="button">Pagar en efectivo</a>
                            --%>
                            <div class="clearfix"></div>
                        </div>
                        <div class="right">
                            <div class="SelectBoxes">
                                <!--Select de paises-->
                                <div class="Select Select--paises" data-bind="visible: ShowCountryList">
                                    <div id="countries" class="dd-container" style="width: 97px;">
                                        <ul class="dd-options dd-click-off-close" style="width: 97px;">
                                            <li><a class="dd-option" title="Austria">
                                                <input class="dd-option-value" type="hidden" value="AUT">
                                                <img class="band aut dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">AUT</label></a></li>
                                            <li><a class="dd-option" title="Bélgica">
                                                <input class="dd-option-value" type="hidden" value="BEL">
                                                <img class="band bel dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">BEL</label></a></li>
                                            <li><a class="dd-option" title="Brasil">
                                                <input class="dd-option-value" type="hidden" value="BRA">
                                                <img class="band bra dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">BRA</label></a></li>
                                            <li><a class="dd-option" title="Chile">
                                                <input class="dd-option-value" type="hidden" value="CHL">
                                                <img class="band chl dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">CHL</label></a></li>
                                            <li><a class="dd-option" title="Colombia">
                                                <input class="dd-option-value" type="hidden" value="COL">
                                                <img class="band col dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">COL</label></a></li>
                                            <li><a class="dd-option" title="Costa Rica">
                                                <input class="dd-option-value" type="hidden" value="CRI">
                                                <img class="band cri dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">CRI</label></a></li>
                                            <li><a class="dd-option" title="Alemania">
                                                <input class="dd-option-value" type="hidden" value="DEU">
                                                <img class="band deu dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">DEU</label></a></li>
                                            <li><a class="dd-option" title="España">
                                                <input class="dd-option-value" type="hidden" value="ESP">
                                                <img class="band esp dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">ESP</label></a></li>
                                            <li><a class="dd-option" title="Italia">
                                                <input class="dd-option-value" type="hidden" value="ITA">
                                                <img class="band ita dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">ITA</label></a></li>
                                            <li><a class="dd-option" title="México">
                                                <input class="dd-option-value" type="hidden" value="MEX">
                                                <img class="band mex dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">MEX</label></a></li>
                                            <li><a class="dd-option" title="Países Bajos">
                                                <input class="dd-option-value" type="hidden" value="NLD">
                                                <img class="band nld dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">NLD</label></a></li>
                                            <li><a class="dd-option dd-option-selected" title="Perú">
                                                <input class="dd-option-value" type="hidden" value="PER">
                                                <img class="band per dd-option-image" src="./pagos_files/blank.gif">
                                                <label class="dd-option-text">PER</label></a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </header>
            <!-- /ko -->
            <!--END HeaderV4-->
        </div>
        <div id="DynamicRenderContent" class="col-sm-7">
            <!--START PaymentSelectionV4-->
            <div id="tab-1" class="tab-content banca-por-internet">
                <div class="paso-1">
                    <div class="tabs_internos">
                        <!-- ko if: expressApp.hasBanks(1) -->
                        <a href="javascript:void(1)" data-legal-type="1" class="tab_button is-active">Personas</a>
                        <%--<a href="javascript:void(2)" data-legal-type="2" style="margin-left: 7px;" class="tab_button">Empresas</a>
                        --%>
                    </div>
                    <div class="tabs_internos_content">
                        <div class="bancos_paso">
                            <!-- Slide Bancos-->
                            <!--SeleccionFinanciera-->
                            <div class="SeleccionFinanciera SeleccionFinanciera--bancaInternet">
                                <div class="SeleccionFinanciera-slideWrapper">
                                    <div class="SeleccionFinanciera-slideButtons">
                                        <div class="slideButton slideButton--prev slick-arrow slick-disabled" aria-disabled="true" style="display: block;"><i class="fa fa-chevron-left"></i></div>
                                        <div class="slideButton slideButton--next slick-arrow" aria-disabled="false" style="display: block;"><%--<i class="fa fa-chevron-right"></i>--%></div>
                                    </div>
                                    <div class="SeleccionFinanciera-slide slick-initialized slick-slider">
                                        <!-- ko foreach: availableBanks -->
                                        <div aria-live="polite" class="slick-list draggable">
                                            <div class="slick-track" role="listbox" style="opacity: 1; width: 1554px; left: 0px;">
                                                <div class="SeleccionFinanciera-item slick-slide slick-current slick-active" data-slick-index="0" aria-hidden="false" tabindex="-1" role="option" aria-describedby="slick-slide00" style="width: 43%;">
                                                    <!-- ko foreach: items -->
                                                    <center>
                                                        <div class="link-wrapper">
                                                            <a href="#" class="link seleccionado"  style="overflow: hidden;vertical-align:baseline ;height: 100%; width:160px" id="1005" data-payment-code="1005_ONLINE_B2C" tabindex="0">
                                                               <%-- <img  height="47" width="105" alt="Banco de Crédito" src="img/bcpagente123.jpg">--%>
                                                                <asp:Image runat="server" ID="imgfpd" />
                                                            </a>
                                                        </div>
                                                     </center>
                                                    <div class="link-wrapper">
                                                        <br />
                                                        <h1>
                                                            <asp:Label ID="txtCuentaBancaria" runat="server" /></h1>
                                                    </div>
                                                    <div class="link-wrapper">
                                                        <br />
                                                        <h1>
                                                            <asp:Label ID="txtCuentaInterBancaria" runat="server" /></h1>
                                                    </div>
                                                    <!-- /ko -->
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /ko -->
                                    </div>
                                </div>
                            </div>
                            <!--end:SeleccionFinanciera -->
                            <!-- Endof:Slide Bancos-->
                        </div>
                        <div class="ingresa" style="display: none;">
                            <h1>Ingresa tu celular</h1>
                            <div class="ingresa_tel">
                                <!-- Formulario Obtener código de pago-->
                                <div id="tel_number" class="dd-container" style="width: 95px;">
                                    <div class="dd-select" style="width: 95px; background: rgb(238, 238, 238);">
                                        <input class="dd-selected-value" type="hidden" value="+51"><a class="dd-selected"><label class="dd-selected-text">(+51)</label></a><span class="dd-pointer dd-pointer-down"></span>
                                    </div>
                                    <ul class="dd-options dd-click-off-close" style="width: 95px; height: 150px; overflow: auto;">
                                        <li><a class="dd-option dd-option-selected" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+51">
                                            <label class="dd-option-text">(+51)</label></a></li>
                                        <li><a class="dd-option" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+55">
                                            <label class="dd-option-text">(+55)</label></a></li>
                                        <li><a class="dd-option" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+56">
                                            <label class="dd-option-text">(+56)</label></a></li>
                                        <li><a class="dd-option" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+1-011">
                                            <label class="dd-option-text">(+1-011)</label></a></li>
                                        <li><a class="dd-option" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+57">
                                            <label class="dd-option-text">(+57)</label></a></li>
                                        <li><a class="dd-option" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+503">
                                            <label class="dd-option-text">(+503)</label></a></li>
                                        <li><a class="dd-option" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+1-011">
                                            <label class="dd-option-text">(+1-011)</label></a></li>
                                        <li><a class="dd-option" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+502">
                                            <label class="dd-option-text">(+502)</label></a></li>
                                        <li><a class="dd-option" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+504">
                                            <label class="dd-option-text">(+504)</label></a></li>
                                        <li><a class="dd-option" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+52">
                                            <label class="dd-option-text">(+52)</label></a></li>
                                        <li><a class="dd-option" title="undefined">
                                            <input class="dd-option-value" type="hidden" value="+507">
                                            <label class="dd-option-text">(+507)</label></a></li>
                                    </ul>
                                </div>
                                <div class="ipt_celular_codigo_pago_wrapper">
                                    <input type="tel" name="ipt_celular_codigo_pago" placeholder="Celular" maxlength="9" class="celular" aria-required="true">
                                </div>
                                <input id="cod1" type="submit" value="Obten tu código de pago" class="enviar">
                                <!-- Endof: Formulario Obtener código de pago-->
                            </div>
                        </div>
                        <!-- Contenedor de Pasos-->
                        <div class="pasos_wrapper" style="display: block">
                            <div class="ticket ticket-online" >
                                <div class="ticket_container" >
                                    <div class="barras">
                                        <%--<h2>Cuenta Bancaria<asp:Label ID="txtCuentaBancaria" runat="server" /></h2>
                                        <label>192-2459697-0-22</label>
                                      <h2>Cuenta InterbBancaria<asp:Label ID="txtCuentaInterBancaria" runat="server"/></h2>
                                         <label>00219200245969702238</label>--%>
                                       
                                       <h4 style="text-align:left;padding:2px 10px 2px 15px">Cuenta Bancaria</h4>
                                        <div class="montototal">
                                            <h4 style="color:white;text-align:center;padding: 0px 15px 0px 0px">192-2459697-0-22</h4>
                                       </div>
                                            
                                       <h4 style="text-align:left;padding:2px 10px 2px 15px">Cuenta InterBancaria</h4>
                                       <div class="montototal">
                                          <h4 style="color:white;text-align:right;padding: 0px 15px 0px 0px">00219200245969702238</h4>
                                      </div>
                                              
                                    </div>
                                    <div class="total">
                                        <strong>Moneda</strong>
                                        <div id="moneda" class="dd-container" style="width: 93px;">
                                            <div class="dd-select" style="width: 93px; background: rgb(238, 238, 238);">
                                                <input class="dd-selected-value" type="hidden" value="PEN"><a class="dd-selected">
                                                    <label class="dd-selected-text">Soles</label></a><span class="dd-pointer dd-pointer-down"></span>
                                            </div>
                                            <ul class="dd-options dd-click-off-close" style="width: 93px;">
                                                <li><a class="dd-option dd-option-selected" title="Soles">
                                                    <input class="dd-option-value" type="hidden" value="PEN">
                                                    <label class="dd-option-text">Soles</label></a></li>
                                                <li><a class="dd-option" title="Dólares">
                                                    <input class="dd-option-value" type="hidden" value="USD">
                                                    <label class="dd-option-text">Dólares</label></a></li>
                                            </ul>
                                        </div>
                                        <div class="total2">
                                            <!-- ko if: ShopperAmountHasFees() -->
                                            <!-- /ko -->
                                            <!-- ko ifnot: ShopperAmountHasFees()-->
                                            <div style="height: 21px;"></div>
                                            <!-- /ko -->
                                            <div class="montototal">
                                                <strong> </strong>
                                              <!--  <span data-bind="">S/ 28.90</span>-->
                                               <asp:Label ID="lblAmount" runat="server" style="font-size:20px"></asp:Label> <span style="font-size:20px">S/.</span><span class="caret"></span></a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tiempo"  >
                                        <div id="timer"  >
                                             <h1>Te quedan</h1><br>
                                              <span id="hours" style="font-size:22px"></span><span style="font-size:15px">h</span> 
                                              <span id="minutes" style="font-size:22px"></span><span style="font-size:15px">m</span> 
                                              <span id="seconds"style="font-size:22px"></span><span style="font-size:15px">s</span> 
                                            </div>
                                    </div>
                                </div>
                                <!-- ko if: ShowPersonasSection() && !(SelectedBankPaymentChannelCode() == "1024_ONLINE_B2C" || SelectedBankPaymentChannelCode() == "1025_ONLINE_B2C" || SelectedBankPaymentChannelCode() == "8250_ONLINE_B2C")-->
                                <div class="mensaje-agentes">
                                    <div class="mensaje-agentes-content">
                                        <strong></strong>
                                    </div>
                                </div>
                                <!-- /ko -->
                                <div class="terminos">
                                </div>
                            </div>
                            <div class="instrucciones">
                                <h1>Instrucciones de pago</h1>
                                
                                <div class="pasos">
                                    <ol id="lista2" data-bind="foreach: bankInstructions">
                                        <!-- ko if: $index() === 0 -->
                                        <div class="colizq" data-bind="foreach: items">
                                            <li>    
                                                <asp:Label runat="server" ID="lbpaso1"></asp:Label>
                                                <%--<div data-bind="html: Message">
                                                    <p id="step_1" >Acercarse a una oficina del BCP o Agente BCP</p>
                                                </div>--%>
                                            </li>

                                            <li>
                                                   <asp:Label runat="server" ID="lbpaso2"></asp:Label>
                                                <%--<div data-bind="html: Message">
                                                    <p id="step_2">Realizar el abono correspondiente en nuestra cuenta corriente</p>
                                                </div>--%>
                                            </li>
                                        </div>

                                        <div class="colder" data-bind="foreach: items">
                                            <li>
                                                <asp:Label runat="server" ID="lbpaso3"></asp:Label>
                                                <%--<p data-bind="html: Message">
                                                    <p id="step_3">Subir el comprobante de pago en la sección de validación</strong></p>
                                                </p>--%>
                                            </li>

                                            <li>   
                                                <asp:Label runat="server" ID="lbpaso4"></asp:Label>
                                                <%--<p data-bind="html: Message">
                                                    <p id="step_4">Su pago estara validado dentro de las proximas 24 horas</p>
                                                </p>--%>
                                            </li>
                                        </div>

                                    </ol>
                                </div>

                                <div class="WaitingState">
                                    <div class="WaitingState-content">
                                        <div data-bind="visible: step() == 1" style="text-align: center; display: none;">
                                            <div class="messages">Esperando confirmación de pago...</div>
                                            <div class="image">
                                                <img alt="" src="./pagos_files/loading30.gif">
                                            </div>
                                        </div>
                                        <div style="text-align: center; display: none;">
                                            <div class="messages">Su pago fue confirmado, está siendo redirigido al comercio para completar su orden...</div>
                                            <div class="image">
                                                <img alt="" src="./pagos_files/loading30.gif">
                                            </div>
                                        </div>
                                        <div style="text-align: center; display: none;">
                                            <div class="messages">Transacción expirada!</div>
                                            <div class="image">
                                                <img alt="" src="./pagos_files/loading30.gif">
                                            </div>
                                        </div>
                                        <div style="text-align: center; display: none;">
                                            <div class="messages">Transacción anulada!</div>
                                            <div class="image">
                                                <img alt="" src="./pagos_files/loading30.gif">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /ko -->
                                <center>
                        <%--            <div class="botones_instrucciones">
                                    <!-- ko if: ShowWaitingState -->
                                    <a  href="Payments.aspx" class="boton_azul" style="width:50%">
                                         Volver a Pagos</a>                               
                                </div>--%>
                                    </center>
                            </div>
                        </div>
                        <!-- Endof: Contenedor de Pasos-->
                        <center>
                         <h2 style="margin:30px 10px 10px 10px">Sección de Validación</h2>
                            <asp:label ID="lblMessagge" runat="server" ForeColor="Red"/>
                            </center>
                        <div class="ticket_container" style="margin: 30px 10px 10px 10px; box-shadow: 3px 3px 20px black; border-radius: 8px">
                            <div class="barras">


                                <span style="font-size: 18px; padding: 26px 15px;" data-bind="text: TransactionId.Value.Text">"Subir comprobante ahora"</span>
                                <%--<asp:radiobutton runat="server" GroupName="rdbtn10"/>--%>
                            </div>
                            <div class="total">
                                <div></div>
                                <div id="moneda3" class="dd-container" style="width: 93px; padding: 32px 15px">
                                    <div class="form-group col-sm-6">
                                        <div class="custom-file">

                                            <asp:FileUpload runat="server" class="custom-file-input" ID="fuRecibo" lang="es" />
                                            <label class="custom-file-label" for="customFileLang"></label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <center>
                                <div class="tiempo" style="width: 245px; background-color: #f6f6f6; text-align: right">
                                    <div>
                                        <br />

                                        <div class="botones_instrucciones">
                                            <%--<a  href="" class="boton_azul" style="width:180px;text-align:center">
                                                            Enviar Ahora</a>--%>
                                            <asp:Button ID="btnEnviarAhora" Text="Enviar" runat="server" CssClass="boton_azul" Style="width: 180px; text-align: center" OnClick="btnEnviarAhora_Click" />
                                        </div>
                                    </div>
                                </div>
                             </center>
                        </div>
                       <%-- <asp:Panel ID="pnEnviarDesp" runat="server" class="ticket_container" style="margin: 10px; box-shadow: 2px 2px 20px black; border-radius: 8px">
                            <div class="barras">
                                <span style="font-size: 18px; padding: 26px 15px;" data-bind="text: TransactionId.Value.Text">"Subir comprobante despues"</span>
                               
                            </div>
                            <div class="total" style="padding: 18px">
                                <label style="font-size: 15px">Se le enviará un correo con un enlace para que a travez de este pueda subir una imagen de su comprobante</label>
                                <div id="moneda4" class="dd-container" style="width: 93px;">
                                </div>
                                <div class="total2">
                                </div>
                            </div>
                            <center>
                                    <div class="tiempo" style="width:246px;background-color:#f6f6f6;text-align:right">
                                        <div>
                                             <br />
                                           
                                                <div class="botones_instrucciones">
                                              
                                                    <asp:button ID="btnEnviarDespues" text="Enviar Despues" runat="server" CssClass="boton_azul"  style="width:180px" OnClick="btnEnviarDespues_Click" />
                                                </div>                                                                                       
                                        </div>
                                    </div>
                               </center>
                        </asp:Panel>--%>
                    </div>
                </div>
            </div>
            <!--END PaymentSelectionV4-->
          <%--  <center>
                <asp:Label ID="lblMensajeT" Text="text" runat="server" ForeColor="Red"/>                  
                <br />
                <asp:Label ID="lblMensaje" Text="text" runat="server" ForeColor="Red"/>
                <br />            
            <asp:HyperLink ID="btnRedirect" NavigateUrl="~/Views/Index.aspx.cs" runat="server"  Text="Ir Al Inicio" style="visibility:hidden" CssClass="boton_azul" />
            </center>--%>
        </div>

        <!--START RenderBody-->
        <div style="display: none;" id="divErrorDetails">
            <div class="span12">
                <h1><strong><span data-bind="text: ErrorDescription"></span></strong></h1>
                <p><span></span><a href="#">support@riberario.com</a>.</p>
            </div>
        </div>
        <!--END RenderBody-->
        <!--START LayoutBottomV4-->
        <script src="./pagos_files/knockout-min.js.descarga" type="text/javascript"></script>
        <script src="./pagos_files/external.min.js.descarga" type="text/javascript"></script>
        <script src="./pagos_files/common.min-4.24.5.0.js.descarga" type="text/javascript"></script>
        <script src="./pagos_files/jquery.validate.min.js.descarga" type="text/javascript"></script>
        <script src="./pagos_files/jquery.signalR-2.2.2.min.js.descarga" type="text/javascript"></script>
        <!--Reference the autogenerated SignalR hub script. -->
        <script type="text/javascript" src="./pagos_files/Hubs"></script>

        <script src="./pagos_files/images_loaded.min.js.descarga" type="text/javascript"></script>
        <script src="./pagos_files/jQuery-FontSpy.js.descarga" type="text/javascript"></script>
        <script src="./pagos_files/express_per.min-4.25.5.0.js.descarga" type="text/javascript"></script>

        <!--END LayoutBottomV4-->
        <div class="modal">
            <p>Please wait...</p>
        </div>
        <div style="display: none" id="print_area">
            <title>SafetyPay</title>

            <meta name="viewport" content="width=device-width, initial-scale=1">
            <meta http-equiv="X-UA-Compatible" content="IE=edge">
            <style>
                #peru #DynamicRenderContent .total-border {
                    border-top: 3px solid #eeeeee;
                }
            </style>

            <style type="text/css">
                /*Fuentes para clientes que lo soporten*/
                @font-face {
                    font-family: 'Open Sans';
                    font-style: normal;
                    font-weight: 400;
                    src: local("Open Sans"), local("OpenSans"), url("//fonts.gstatic.com/s/opensans/v10/cJZKeOuBrn4kERxqtaUH3bO3LdcAZYWl9Si6vvxL-qU.woff") format("woff");
                }

                /* CLIENT-SPECIFIC STYLES */
                body, table, td, a {
                    -webkit-text-size-adjust: 100%;
                    -ms-text-size-adjust: 100%;
                }

                table, td {
                    mso-table-lspace: 0pt;
                    mso-table-rspace: 0pt;
                }

                img {
                    -ms-interpolation-mode: bicubic;
                }

                /* RESET STYLES */
                img {
                    border: 0;
                    height: auto;
                    line-height: 100%;
                    outline: none;
                    text-decoration: none;
                }

                table {
                    border-collapse: collapse !important;
                }

                body {
                    height: 100% !important;
                    margin: 0 !important;
                    padding: 0 !important;
                    width: 100% !important;
                }

                /* iOS BLUE LINKS */
                a[x-apple-data-detectors] {
                    color: inherit !important;
                    text-decoration: none !important;
                    font-size: inherit !important;
                    font-family: inherit !important;
                    font-weight: inherit !important;
                    line-height: inherit !important;
                }

                /* MEDIA QUERIES */
                @media screen and (max-width: 480px) {
                    .mobile-hide {
                        display: none !important;
                    }

                    .mobile-center {
                        text-align: center !important;
                    }
                }

                /* ANDROID CENTER FIX */
                div[style*="margin: 16px 0;"] {
                    margin: 0 !important;
                }
                body {
                       
                    }
                    #timer {
                      padding:10px;
                      font-family: Arial, sans-serif;
                      font-size: 10px;
                      color: #999;
                      letter-spacing: -1px;
                    }
                    #timer span {
                      font-size: 30px;
                      color: #333;
                      margin: 0 3px 0 15px;
                    }
                    #timer span:first-child {
                      margin-left: 0;
                    }
  
            </style>

            <!-- HIDDEN PREHEADER TEXT: Usarlo para poner la descripción del correo-->
            <div style="display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: Open Sans, Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;"></div>

        </div>
        <div class="modal inmodal" id="mdlMessaggeEndRegister" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content animated bounceInRight">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Terminar Registro</h4>
                    </div>
                    <div class="modal-body">
                        <h2 id="txtMessagge"></h2>
                        <br />
                        <br />

                        <br />
                        <br />
                        <br />
                        <br />
                        <center><a href="Index.aspx" class="btn btn-sm btn-primary m-t-n-xs">Ir al Inicio</a></center>
                    </div>

                </div>
            </div>
        </div>

        <iframe id="div_print" style="display: none;" scrolling="no" src="./pagos_files/saved_resource.html"></iframe>
        <%--     <asp:ScriptManager ID="ScriptInterno" runat="server">

        </asp:ScriptManager>--%>
    
    <script>
        
        var timer;
        var compareDate = new Date();
        compareDate.setDate(compareDate.getDate() + 3); //just for this demo today + 7 days

        timer = setInterval(function() {
          timeBetweenDates(compareDate);
        }, 1000);

        function timeBetweenDates(toDate) {
          var dateEntered = toDate;
          var now = new Date();
          var difference = dateEntered.getTime() - now.getTime();

          if (difference <= 0) {

            // Timer done
            clearInterval(timer);
  
          } else {
    
            var seconds = Math.floor(difference / 1000);
            var minutes = Math.floor(seconds / 60);
            var hours = Math.floor(minutes / 60);
            var days = Math.floor(hours / 72);
             
            hours = hours % 72;
            minutes = minutes % 60;
            seconds = seconds %  60;

             
            document.getElementById("hours").innerHTML = hours;
            document.getElementById("minutes").innerHTML = minutes;
            document.getElementById("seconds").innerHTML = seconds;

             
          }
        }
    </script>
        </form>
</body>
</html>
