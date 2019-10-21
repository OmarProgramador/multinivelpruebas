<%@ Page Language="C#" AutoEventWireup="true" AspCompat="true" CodeBehind="Politics.aspx.cs" Inherits="MULTI_NIVEL.Views.Politics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>inResorts</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link href="css/jquery.jqplot.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/all_Jworld.css?v=2.2" media="all" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">

    <script type="text/javascript"></script>
    <style>
        input[type=checkbox] {
            /* Double-sized Checkboxes */
            -ms-transform: scale(1.5); /* IE */
            -moz-transform: scale(1.5); /* FF */
            -webkit-transform: scale(1.5); /* Safari and Chrome */
            -o-transform: scale(1.5); /* Opera */
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <nav class="navbar navbar-default navbar-fixed-top" role="navigation" style="background-color: #f3f3f4">
                <div id="header" class="container">
                    <div class="navbar-header" style="margin: 10px">
                        <div>
                            <img class="logo img-responsive center-block" src="img/novologo.png" style="height: 80px" />
                        </div>
                    </div>
                </div>
            </nav>
            <div id="main" style="padding-top: 50px; padding: 50px">
                <div class="container">
                    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                    <style type="text/css">
                        .submenu div p {
                            width: 60%;
                            margin: 0;
                            padding: 0;
                            position: relative;
                            word-break: break-all;
                            text-align: left;
                        }
                    </style>
                    <script type="text/javascript">
                        function checkForm() {
                            var form = document.theForm;
                            if (form.checkAlert.value == "1") {
                                if (form.agreeIT.checked == "0" || form.agreeCompPlan.checked == "0" || form.agreeEngageLetter.checked == "0" || form.agreePP.checked == "0" || form.agreePrivacy1.checked == "0" || form.agreeExpAcceptance.checked == "0") {

                                    alert(form.alert.value);
                                    return false;
                                }
                            }
                            else {
                                if (form.agree.checked == false) {
                                    alert(form.alert.value);
                                    return false;
                                }
                            }

                            return true;
                        }
                        function checkDisagree(checkbox) {
                            if (checkbox.checked == true) {
                                $("#FacebookInfoPopUp").modal('show');
                                document.getElementById("agree").checked = false;
                            }
                        };
                        function closeButton() {
                            $("#FacebookInfoPopUp").modal('hide');
                        };
                        function clickAgree() {
                            if (document.getElementById("disagree") != null)
                                document.getElementById("disagree").checked = false;
                        }
                    </script>
                    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
                    <div>

                        <input type="hidden" name="SignupCountry" value="PE" />
                        <input type="hidden" name="alert" value="Debe marcar 'ACEPTO' para continuar" />
                        <div align='center' style="color: teal; font-size: 20px">
                            <h1>SOLICITUD PARA SER MIEMBRO DE INRESORTS</h1>
                             
                                <p align='center' class="HebRight" style="color: teal; font-size: 20px">
                                    <strong>&nbsp;Excelente estas a un paso de ser un nuevo socio de inResorts
                                        <br>
                                    </strong>
                                </p>
                                <p>Verifica por favor los siguientes documentos que constituyen tu afilicación a nuestro primer desarrollo Ribera del Río </p>
                             
                            <p align="center">
                                <asp:CheckBox ID="cbagree2" name="agree" value="1" Text="" runat="server" />
                                <a style="text-decoration: none; color: steelblue; cursor: pointer" id="btnContato" href="VysorContratos.aspx" target="_blank">Haz clic aquí para leer: &nbsp; Contrato de Membresia </a>

                                <br>
                                <br>
                                <asp:CheckBox ID="cbagree6" name="agree" value="1" Text="" runat="server" />
                                <a style="text-decoration: none; color: steelblue; cursor: pointer" id="btnContatoRci" href="VysorRCI.aspx" target="_blank">Haz clic aquí para leer: &nbsp; Contrato RCI </a>

                                <br>
                                <br>
                                <asp:CheckBox ID="cbagree3" name="agree" value="1" Text="" runat="server" />
                                <%--<a style="text-decoration: none; color: steelblue; cursor: pointer" class="link" href="VysorRCI.aspx" target="_blank">Haz clic aquí para leer: &nbsp; Cronograma Pagos </a>--%>
                               
                                <asp:HyperLink ID="hlCronograma" runat="server" Text="Haz clic aquí para leer: Cronograma Pagos" Style="text-decoration: none; color: steelblue; cursor: pointer" class="link" target="_blank" />
                                <br>  
                                <br>
                                <asp:CheckBox ID="cbagree4" name="agree" value="1" Text="" runat="server" />
                                <a style="text-decoration: none; color: steelblue; cursor: pointer" href="../Resources/PoliticsPdf/PLAN_DE_BENEFICIOS_INRESORTS.pdf" target="_blank" class="link">Haz clic aquí para leer: &nbsp;Plan de Beneficios </a>
                                <br>
                                <br>
                                <asp:CheckBox ID="CheckBox6" name="agree" value="6" Text="" runat="server" />                         
                                <asp:HyperLink ID="hlPagares" runat="server" Target="_blank" Style="text-decoration: none; color: steelblue; cursor: pointer" Text="Click aqui para leer informe de Pagares" />
                                <!-- <a style="text-decoration: none; color: steelblue; cursor: pointer" id="lbtnPagares" href="VysorPagare.aspx" target="_blank">Haz clic aquí para leer: &nbsp; Informe De Pagares </a>-->
                                <br>
                              
                                <br>
                                <asp:CheckBox ID="cbagree5" name="agree" value="1" Text="" runat="server" />
                                <a style="text-decoration: none; color: steelblue; cursor: pointer" href="VysorCertificado.aspx" target="_blank">Haz clic aquí para leer: &nbsp;Certificado Afilición</a><br>
                                <br>
                                <p align='center' class="HebRight" style="color: teal; font-size: 20px">
                                    Así mismo revisa los documentos que constituyen el Acuerdo de Referenciador.
                                </p>

                                <asp:CheckBox ID="CheckBox1" name="agree" value="1" Text="" runat="server" />
                                <a style="text-decoration: none; color: steelblue; cursor: pointer" href="../Doc/PLAN_COMPENSACION_INRESORTS.pdf" target="_blank" class="link">Haz clic aquí para leer: &nbsp;Plan de Pagos y Recompensas - Programa de Recomendación</a><br>
                                <br>
                                <asp:CheckBox ID="CheckBox2" name="agree" value="1" Text="" runat="server" />
                                <a style="text-decoration: none; color: steelblue; cursor: pointer" href="../Doc/Reglamento_de_Ética_inResorts.pdf" target="_blank" class="link">Haz clic aquí para leer: &nbsp;Código Etica - Programa de Recomendación </a>
                                
                                <br>
                              <%--  <br>
                                <asp:CheckBox ID="CheckBox3" name="agree" value="1" Text="" runat="server" />
                                <a style="text-decoration: none; color: steelblue; cursor: pointer" href="../Doc/Reglamento_de_Ética_inResorts.pdf" target="_blank" class="link">Haz clic aquí para leer: &nbsp; Presentacion de Beneficios </a>
                                <br>--%>
                                <br>
                            </p>
                            </p>
                        <p align="center" style="margin-left: 8%; margin-right: 8%">
                            <font face="Verdana, Arial, Helvetica, sans-serif" />
                            <font size="2" color="teal" />
                            El único requisito económico para convertirse en miembro de inResorts es la compra del alguno de nuestros planes de recompensas.
                                <br>
                            <br>
                            Al hacer clic en esta casilla, autorizo a inResorts al tratamiento de mis datos personales para los propósitos, y con arreglo a las condiciones, que se exponen en la Política de Privacidad, 
                                <a style="cursor: pointer" onclick="window.open('https://www.google.com','popUpWindow','height=800,width=800,left=400,top=100,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=no,directories=no, status=yes');">
                                    <font color="#1292aa">disponible en este enlace</font>
                                </a>.
                                <br>
                            </font>
                        </font>
                        </p>
                            <p align="center">
                                <%--<input id="agree" name="agree" type="checkbox"  onclick="javascript: clickAgree()">--%>
                                <asp:CheckBox ID="cbagree" name="agree" value="1" Text="" runat="server" />
                                <input type="hidden" name="checkAlert" value="0" />
                                <strong>
                                    <font size="4" color="#000000">
                                Acepto
                                </font>
                                </strong>
                            </p>
                            <p align="center">
                                <font face="Verdana, Arial, Helvetica, sans-serif"> 
                        <font size="3" style="font-weight:normal; color: teal">
                            Al hacer clic en Continuar, certifico que tengo al menos 18 años y que he leído y acepto cumplir con este Acuerdo.
                        </font>
                        </font>
                            </p>
                            <p align="center" style="padding-top: 30px;">
                                <asp:Button ID="btnPolitics" runat="server" OnClick="btnPolitics_Click" type="submit" Text="Continuar" class="btn btn-primary" Style="background-color: #4cb13e; border-color: #4cb13e; padding: 10px; border-radius: 6px; color: white; font-size: 18px; margin: 8px"></asp:Button>
                                &nbsp;&nbsp;
                            <input type="button" value="No acepto" class="btn btn-primary" style="background-color: #4cb13e; border-color: #4cb13e; padding: 10px; border-radius: 6px; color: white; font-size: 17px; margin: 8px" onclick="window.location = '    ';">
                                <br />
                                <a href="/join1.asp?siteurl=juancarlosuc&fn="></a><font face="Verdana, Arial, Helvetica, sans-serif"></font>
                                <p align='left' class="HebRight">&nbsp;</p>
                                <asp:Label ID="lblmarca" runat="server" Style="color: red; font-size: 16px; display: none">Marque todas las casillas para indicar conformidad con todos los documentos</asp:Label>
                        </div>
                    </div>
                    <footer id="footer" class="container" style="text-align: center; color: teal">
                        <p>&copy; 2018&nbsp;&nbsp;inResorts. All rights reserved.</p>

                        <span id="siteseal" style="text-decoration: none; color: teal"></span>
                    </footer>
                    <script src="Script/jquery-3.js"></script>
                    <script src="Script/jquery.js"></script>
                    <script src="Script/bootstrap.js"></script>
                </div>       
            </div>
        </div>
       

        <script type="text/javascript"> 
            document.getElementById('cbagree2').onchange = function () {
                if (this.checked) {                    
                    window.open("/Views/VysorContratos.aspx", '_blank')
                    this.focus();
                }
            }
            document.getElementById('cbagree6').onchange = function () {
                if (this.checked) {               
                    window.open("/Views/VysorRCI.aspx", '_blank')
                }
            }
           
            document.getElementById('cbagree5').onchange = function () {
                if (this.checked) {                   
                    window.open("/Views/VysorCertificado.aspx", '_blank')
                }
            }
        </script>
    </form>

</body>
</html>
