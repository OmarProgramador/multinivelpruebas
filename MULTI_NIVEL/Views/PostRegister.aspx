<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostRegister.aspx.cs" Inherits="MULTI_NIVEL.Views.PostRegister" %>


<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registro de nuevo Socio | Ribera del Rio</title>
    <link href="postRegistro_files/css.css" rel="stylesheet">
    <link href="postRegistro_files/bootstrap.css" rel="stylesheet">
    <link href="postRegistro_files/font-awesome.css" rel="stylesheet">
    <link href="postRegistro_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="postRegistro_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="postRegistro_files/chosen.css" rel="stylesheet">
    <link href="postRegistro_files/croppie.css" rel="stylesheet">
    <link href="postRegistro_files/datepicker3.css" rel="stylesheet">
    <link href="postRegistro_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="postRegistro_files/ladda-themeless.css" rel="stylesheet">
    <link href="postRegistro_files/sweetalert.css" rel="stylesheet">
    <link href="postRegistro_files/animate.css" rel="stylesheet">
    <link href="postRegistro_files/style.css" rel="stylesheet">
    <link rel="stylesheet" href="postRegistro_files/all.css" integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp" crossorigin="anonymous">
    <script src="postRegistro_files/jquery-3.js"></script>
    <script src="postRegistro_files/bootstrap.js"></script>
    <script src="postRegistro_files/jquery_004.js"></script>
    <script src="postRegistro_files/jquery_009.js"></script>
    <script src="postRegistro_files/inspinia.js"></script>
    <script src="postRegistro_files/pace.js"></script>
    <script src="postRegistro_files/jquery_002.js"></script>
    <script src="postRegistro_files/jquery_006.js"></script>
    <script src="postRegistro_files/jquery_010.js"></script>
    <script src="postRegistro_files/Chart.js"></script>
    <script src="postRegistro_files/jasny-bootstrap.js"></script>
    <script src="postRegistro_files/jquery.js"></script>
    <script src="postRegistro_files/jquery_005.js"></script>
    <script src="postRegistro_files/peity-demo.js"></script>
    <script src="postRegistro_files/datatables.js"></script>
    <script src="postRegistro_files/chosen.js"></script>
    <script src="postRegistro_files/croppie.js"></script>
    <script src="postRegistro_files/sweetalert.js"></script>
    <script src="postRegistro_files/bootstrap3-typeahead.js"></script>
    <script src="postRegistro_files/jquery_007.js"></script>
    <script src="postRegistro_files/bootstrap-datepicker.js"></script>
    <script src="postRegistro_files/jquery_003.js"></script>

    <script>
        var base_url = '';
        var idsocio = 2495;
        var idopera = 1;
        var nombresocio = 'Omar Urteaga';
        var direcsocio = 'Avenida Guardia Civil 1321 Oficina 602';
        var rango = 'Inicio';
        var simbolo = 'S/.';
        var csrfsn = '995fd00004569a49a8e09b79eaef65fb';
        //document.addEventListener('contextmenu', event => event.preventDefault());
    </script>
    <script src="postRegistro_files/jquery_011.js"></script>
    <script src="postRegistro_files/jquery_008.js"></script>
</head>
<body class="top-navigation  pace-done">
    <form id="form1" runat="server">
        <div class="pace  pace-inactive">
            <div class="pace-progress" style="transform: translate3d(100%, 0px, 0px);" data-progress-text="100%" data-progress="99">

                <div class="pace-progress-inner"></div>
            </div>
            <div class="pace-activity"></div>
        </div>
        <!-- Loading -->
        <div class="loading">
            <div class="load">
                <div class="sk-spinner sk-spinner-fading-circle">
                    <div class="sk-circle1 sk-circle"></div>
                    <div class="sk-circle2 sk-circle"></div>
                    <div class="sk-circle3 sk-circle"></div>
                    <div class="sk-circle4 sk-circle"></div>
                    <div class="sk-circle5 sk-circle"></div>
                    <div class="sk-circle6 sk-circle"></div>
                    <div class="sk-circle7 sk-circle"></div>
                    <div class="sk-circle8 sk-circle"></div>
                    <div class="sk-circle9 sk-circle"></div>
                    <div class="sk-circle10 sk-circle"></div>
                    <div class="sk-circle11 sk-circle"></div>
                    <div class="sk-circle12 sk-circle"></div>
                </div>
                <div>Espere por favor...</div>
            </div>
        </div>

        <div id="wrapper">
            <div id="page-wrapper" class="gray-bg">
                <div class="row border-bottom white-bg iniciowp">
                    <nav class="navbar navbar-static-top" role="navigation" style="height: 75px">
                        <div class="navbar-header header-inicio">
                            <button aria-controls="navbar" aria-expanded="false" data-target="#navbar" data-toggle="collapse" class="navbar-toggle collapsed" type="button">
                                <i class="fa fa-reorder"></i>
                            </button>
                            <a href="Index.aspx" class="navbar-brand inicio-logo">
                                <img src="img/novologo.png" class="img-responsive"></a>
                        </div>
                        <div class="navbar-collapse collapse" id="navbar">
                            <ul class="nav navbar-top-links navbar-right header-inicior">
                                <li>
                                    <asp:Image ID="imgProfile" runat="server" alt="..." CssClass="img-circle img-responsive img-user"  />
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle userClass" data-toggle="dropdown" role="button" aria-expanded="false">
                                        <asp:Label ID="lblUser" runat="server"></asp:Label><span class="caret"></span></a>
                                    <ul class="dropdown-menu detalle-user" role="menu">
                                        <li>
                                            <div class="floatleft">
                                                <asp:Image ID="imgProfileFl" runat="server" alt="..." class="img-circle img-responsive img-user1" />
                                            </div>
                                            <div class="floatleft">
                                                <p>
                                                    <strong>
                                                        <%--<asp:Label ID="lblUserName" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lblUserName" runat="server" ></asp:Label>
                                                    </strong>
                                                </p>
                                                <p class="green">
                                                    <asp:Label ID="lblNumPartner" runat="server" ></asp:Label>
                                                </p>
                                            </div>
                                        </li>
                                        <li class="divider"></li>
                                        <li>
                                            <p class="col-md-6">
                                                <a href="Edit.aspx" class="btn btn-primary btn-sm block">Editar perfil</a>
                                            </p>
                                            <p class="col-md-6">
                                                <a href="editar.htm" class="btn btn-primary btn-sm block">Cambiar Clave</a>
                                            </p>
                                            <center>
						<p class="col-md-12">							                            
                            <asp:LinkButton ID="lblSalir" runat="server" OnClick="lblSalir_Click" CssClass="btn btn-primary block" Text="Salir"></asp:LinkButton>
						</p>
						</center>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </nav>
                </div>
                <div class="wrapper wrapper-content animated fadeInUp">
                    <div class="container">
                        <div class="ibox float-e-margins">
                            <div class="ibox-content">
                                <h2 class="green">Registro de nuevo socio.</h2>
                                <h4>El Socio de registró con éxito.</h4>
                                <hr>
                                <p>Se ha enviado un correo electrónico al nuevo socio con las indicaciones necesarias para que continúe con el proceso de registro.</p>
                                <p>En cuanto el nuevo socio confirme su afiliación se actualizarán sus indicadores de red.</p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Favorito -->
                <div class="modal inmodal" id="mdlTerminosCondiciones" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content animated bounceInRight">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">TERMINOS Y CONDICIONES</h4>
                            </div>
                            <div class="modal-body">
                                <p><strong>Los Términos y Condiciones del Acuerdo con el Distribuidor Independiente de kaita Natural Network Knn:</strong></p>

                                <p>1. Entiendo que como Ejecutivo Independiente de knn:</p>

                                <p>a. Tengo el derecho de ofrecer para la venta los productos y servicios de knn de acuerdo con estos Términos y Condiciones.</p>

                                <p>b. Tengo el derecho de afiliar a personas con Knn.</p>

                                <p>c. Entrenaré y motivaré a los Ejecutivos Independientes de mi organización de mercadeo en línea descendente.</p>

                                <p>
                                    d. Acataré todas las leyes, ordenanzas, 
reglamentos y normativas municipales y del Estado Peruano; y haré todas
 las declaraciones y pagaré todas las retenciones u otras deducciones 
según lo requerido por cualquier ley, ordenanza, reglamento y normativa
 municipal y del Estado.
                                </p>

                                <p>e. Haré mis obligaciones como Ejecutivo Independiente con honestidad e integridad</p>

                                <p>
                                    2. Yo me comprometo a presentar el plan 
de ganancias o mercadeo, y los productos y servicios de Knn como están 
en la literatura oficial de Knn.
                                </p>

                                <p>
                                    3. Acepto que como Distribuidor 
Independiente de Knn soy contratista independiente, y no soy empleado, 
agente, socio, representante legal o franquiciante de Knn.
                                </p>

                                <p>
                                    No estoy autorizado ni incurriré en 
deudas, gastos, obligaciones; ni abriré cuentas corrientes a favor, 
para o en nombre de Knn.
                                </p>

                                <p>
                                    Acepto que seré el único responsable de
 pagar todos los gastos en que yo incurra, incluyendo pero no limitando 
viáticos, alimentos, alojamiento, de secretaria, oficina, telefonía de
 larga distancia u otros gastos. ENTIENDO QUE NO ME TRATARÁN COMO 
EMPLEADO DE KNN POR RAZONES TRIBUTARIAS ESTATALES O FEDERALES.
                                </p>

                                <p>
                                    Knn es de retener o deducir de mis 
bonificaciones y comisiones por efecto de detracciones, abonándola a 
las respectivas cuentas de detracciones del Distribuidor.
                                </p>

                                <p>Al recibirlas, he leído cuidadosamente y acepto acatar las Normas y Procedimientos y el Plan de Mercadeo de Knn.</p>

                                <p>Entiendo que debo ser de buena reputación, y no infringir este Acuerdo, para tener derecho a bonos y comisiones de Knn.</p>

                                <p>
                                    Entiendo que estos Términos y 
Condiciones, las Normas y Procedimientos de Knn o el Plan de Mercadeo y 
Compensación de Knn pueden enmendarse a la sola discreción de Knn, y 
acepto que cualquier enmienda de tal índole se aplicaría a mi persona.
                                </p>

                                <p>La notificación de enmiendas será publicada en los materiales oficiales de Knn.</p>

                                <p>
                                    La vigencia de este acuerdo es de un 
año. Si dejo de renovar anualmente mi negocio Knn, o si es cancelado o 
cesante por cualquier motivo, entiendo que perderé mis derechos como 
Ejecutivo Independiente hasta renovar mi negocio Knn en este caso la 
oficina Virtual.
                                </p>

                                <p>
                                    No tendré derecho de vender productos y 
servicios Knn, ni tendré derecho de recibir comisiones, bonos u otros 
ingresos que resultaran de las actividades de mi antigua organización 
de ventas en línea descendente. En caso de cancelación, terminación o
 no renovación, renuncio a todos mis derechos, incluyendo pero no 
limitados a mi antigua organización en línea descendente, y cualquier 
bonificación, comisión u otra remuneración derivada de las ventas y 
otras actividades de mi antigua organización en línea descendente.
                                </p>

                                <p>
                                    Knn se reserva el derecho de terminar, 
con preaviso de 30 días, todos los Acuerdos de Ejecutivo Independiente 
si la Empresa decidiera: (1) suspender operaciones comerciales, o, (2) 
liquidarse como entidad comercial.
                                </p>

                                <p>
                                    6. No puedo traspasar ningún derecho ni 
delegar mis deberes bajo este Acuerdo sin el consentimiento previo por 
escrito de Knn. Cualquier intento de transferir o traspasar este Acuerdo
 sin el expreso consentimiento por escrito de Knn, hace que el Acuerdo 
pueda ser rescindido a opción de Knn y pueda resultar en la 
terminación de mi negocio.
                                </p>

                                <p>
                                    7. Entiendo que si dejo de cumplir con 
los términos de este Acuerdo, Knn puede, a su discreción, aplicarme 
sanciones según se describe en las Normas y Procedimientos. Si 
transgrediera, quebrantara o no cumpliera con el Acuerdo, a su 
conclusión no tendré derecho de recibir más bonificaciones o 
comisiones, sin importar que las ventas que generaron tales 
bonificaciones y comisiones han sido completadas.
                                </p>

                                <p>
                                    8.Knn, sus directores, funcionarios, 
accionistas, empleados, cesionarios y agentes (colectivamente llamados 
“subsidiarios”), no serán responsables, y yo libero aKnn y sus 
subsidiarios de todas las demandas por daños resultantes y 
compensación punitiva. Acepto además liberar a Knn y sus subsidiarios 
de cualquier obligación que resulte o esté relacionada con la 
promoción u operación de mi negocio Knn y cualquier actividad 
relacionada (ej. la presentación de productos o el Plan de Mercadeo y 
Prosperidad de Knn, la operación de un vehículo automotor, el alquiler
 de instalaciones para reuniones y entrenamiento, etc.) y acepto 
indemnizar a Knn por cualquier obligación, daño, multas u otras 
indemnizaciones que resulten de la conducta no autorizada en que me 
involucro al realizar mi negocio.
                                </p>

                                <p>
                                    9. El Acuerdo, en su forma actual o 
enmendado por Knn a su discreción, constituye todo el contrato entre 
Knn y yo. Cualquier promesa, representación, oferta u otra 
comunicación que no está estipulada explícitamente en este Acuerdo, 
no tendrá vigencia ni validez.
                                </p>

                                <p>
                                    10. Cualquier exoneración por Knn de 
cualquier infracción del Acuerdo debe estar por escrito y firmada por 
un funcionario de Knn autorizado para tal fin. La exoneración por Knn 
de cualquier infracción de mi parte no opera ni será interpretada como
 exoneración de infracciones subsiguientes.
                                </p>

                                <p>
                                    11. En caso que alguna estipulación de 
este Acuerdo sea considerada inválida, o que no se pueda hacer cumplir,
 tal estipulación, deberá reformarse sólo hasta el punto necesario en
 que se pueda hacer cumplir y el resto del Acuerdo seguirá válido y 
vigente.
                                </p>

                                <p>
                                    12. Este Acuerdo se regirá e 
interpretará conforme a las leyes Peruanas, sin importar los principios
 de conflicto de leyes. Todas las disputas y reclamos en cuanto a Knn, 
el Acuerdo de Distribuidor Independiente, el Plan de Mercadeo de Knn o 
sus productos y servicios, los derechos y deberes de un Ejecutivo 
Independiente y Knn o cualquier otro reclamo o fundamento de causa 
relacionado con la actuación de un Distribuidor Independiente o de Knn 
bajo este Acuerdo o las Normas y Procedimientos de Knn, deben resolverse
 mediante arbitraje en Perú.
                                </p>

                                <p>
                                    13. Si un Ejecutivo Independiente desea 
emprender un pleito contra Knn por cualquier hecho u omisión en 
relación o como resultado de este Acuerdo, tal pleito debe emprenderse 
dentro de un lapso de un año a partir de la fecha que ocasionó la 
causa del pleito. La falta de emprender tal pleito dentro de este lapso 
prohibirá todo reclamo contra Knn para tal hecho u omisión. Los 
Ejecutivos Independientes renuncian a todos los reclamos aplicables bajo
 otros estatutos de limitación.
                                </p>

                                <p>
                                    14. Autorizo a Knn a usar mi nombre, 
fotografía, historia personal o parecido en materiales publicitarios o 
de promoción y renuncio a cualquier pretensión de remuneración para 
tal uso 
                                </p>

                                <p>
                                    15. Al rellenar y entregar esta 
Solicitud, autorizo específicamente a Knn a comunicarse conmigo por 
correo electrónico en la dirección que registré en la oficina 
virtual. Entiendo que tales correos electrónicos pueden incluir ofertas
 y solicitación para la venta de productos Knn, ayudas de venta y 
servicios.
                                </p>

                                <p>
                                    16. Entiendo que cualquier 
representación engañosa de los datos que suministro en esta Solicitud y
 mi Oficina Virtual personal de Acuerdo de Distribuidor Independiente 
puede resultar en sanciones de Knn, e incluso terminación de este 
Acuerdo.
                                </p>

                                <p>
                                    He examinado el contrato y entiendo que 
deberé sujetarme a los términos y condiciones y a la política y 
procedimientos. Al firmar, confirmo que he examinado el contrato y 
entiendo que deberé sujetarme a los términos y condiciones de Knn . 
Además entiendo que puedo cancelar mi cuenta con Knn en cualquier 
momento, si envío una solicitud por escrito.
                                </p>
                                <p><strong>TÉRMINOS Y CONDICIONES</strong></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="footer footer-fondo">
                    <strong>Ribera del Rio - 2018</strong>
                </div>
            </div>
        </div>
        <a id="scrollUp" href="#top" title="Scroll to top" style="position: fixed; z-index: 2147483647;"></a>
        <script type="text/javascript">
            $(window).bind('scroll', function () {
                if ($(window).scrollTop() > 180) { $('#scrollUp').fadeIn('slow'); } else { $('#scrollUp').fadeOut('slow'); }
            });

            $("a[href='#top']").click(function () {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                return false;
            });
        </script>

    </form>
</body>
</html>
