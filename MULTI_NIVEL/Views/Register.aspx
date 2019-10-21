<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MULTI_NIVEL.Views.Register" EnableEventValidation="false" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registro de nuevo Socio | inResorts</title>
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <%-- <script type="text/javascript" src="jquery.js"></script>--%>
    <link href="registro_files/font-awesome.css" rel="stylesheet">
    <link href="registro_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="registro_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="registro_files/chosen.css" rel="stylesheet">
    <link href="registro_files/croppie.css" rel="stylesheet">
    <link href="registro_files/datepicker3.css" rel="stylesheet" />
    <link href="registro_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="registro_files/ladda-themeless.css" rel="stylesheet">
    <link href="registro_files/sweetalert.css" rel="stylesheet">
    <link href="registro_files/animate.css" rel="stylesheet">
    <link href="registro_files/style.css" rel="stylesheet">
    <link rel="stylesheet" href="registro_files/all.css">
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" />
    <!--script propio-->
    <script src="Script/Script.js"></script>

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <style>
        input[type=radio] {
            /* Double-sized Checkboxes */
            -ms-transform: scale(1.5); /* IE */
            -moz-transform: scale(1.5); /* FF */
            -webkit-transform: scale(1.5); /* Safari and Chrome */
            -o-transform: scale(1.5); /* Opera */
            padding: 10px;
        }
    </style>


    <style type="text/css">
        .auto-style1 {
            width: 710px;
        }
    </style>
    <script type="text/javascript">
        x = $(document);
        x.ready(inicializarControles);
        var a = 2;
        function inicializarControles() {
            //x = $("#txtEstado")
            y = $("#txtEstado2");
            z = $("#txtCountry");
            z.change(cargarCiudades);
            // y.change(cargarEstados);
            document.getElementById("p1").style.display = "none";
            document.getElementById("p2").style.display = "none";

        }

        function cargarCiudades() {

            y.children().remove();

            //    if (z.val() == "UY") {
            //        var aCiudades = new Array();
            //        aCiudades[0] = "Montevideo";
            //        aCiudades[1] = "Canelones";
            //        aCiudades[2] = "San Jose";
            //        for (var i = 0; i < aCiudades.length; i++) {
            //            y.append('<option value="' + aCiudades[i] + '">' + aCiudades[i] + '</option>');
            //        }
            //    }
            varw = z.val();
            if (z.val() == "Peru") {
                var aCiudades = new Array();
                aCiudades[0] = "Amazonas";
                aCiudades[1] = "Ancash";
                aCiudades[2] = "Apurímac";
                aCiudades[3] = "Arequipa";
                aCiudades[4] = "Ayacucho";
                aCiudades[5] = "Cajamarca";
                aCiudades[6] = "Cusco";
                aCiudades[7] = "Huancavelica";
                aCiudades[8] = "Huánuco";
                aCiudades[9] = "Ica";
                aCiudades[10] = "Junín";
                aCiudades[11] = "La Libertad";
                aCiudades[12] = "Lambayeque";
                aCiudades[13] = "Lima";
                aCiudades[14] = "Loreto";
                aCiudades[15] = "Madre de Dios";
                aCiudades[16] = "Moquegua";
                aCiudades[17] = "Pasco";
                aCiudades[18] = "Piura";
                aCiudades[19] = "Puno";
                aCiudades[20] = "San Martín";
                aCiudades[21] = "Tacna";
                aCiudades[22] = "Tumbes";
                aCiudades[23] = "Ucayali";


                //li.text = ('<option value=ppoo>opoo</option>');
                for (var i = 0; i < aCiudades.length; i++) {
                    y.append("<option value=" + aCiudades[i] + ">" + aCiudades[i] + "</option>");
                }

                //if (a == 1) {
                //    document.getElementById('txtest').id = "txtest3";
                //    document.getElementById('txtEstado2').id = "txtest";
                //    document.getElementById('txtest3').id = 'txtEstado2';
                //}
                document.getElementById("p1").style.display = "block";
                document.getElementById("p2").style.display = "none";
                //document.getElementById("p1").style.visibility = "visible";
                //document.getElementById("p2").style.visibility = "hidden";

            } else {
                //a = 1;
                //document.getElementById('txtEstado2').id = "txtest2"; //peru
                //document.getElementById('txtest').id = "txtEstado2"; //otro
                //document.getElementById('txtest2').id = "txtest";   //peru

                document.getElementById("p1").style.display = "none";
                document.getElementById("p2").style.display = "block";
                //document.getElementById("p1").style.visibility = "hidden";
                //document.getElementById("p2").style.visibility = "visible";

            }

        }


    </script>
</head>
<body class="top-navigation pace-done">
    <form id="form1" runat="server">
        <asp:Label ID="lblInt" runat="server" Style="display: none;" />
        <div class="pace pace-inactive">
            <div class="pace-progress" style="transform: translate3d(100%, 0px, 0px);" data-progress-text="100%" data-progress="99">
                <div class="pace-progress-inner">
                </div>
            </div>
            <div class="pace-activity">
            </div>
        </div>

        <div id="wrapper">
            <div id="page-wrapper" class="gray-bg">
                <div class="row border-bottom white-bg iniciowp">
                    <nav class="navbar navbar-static-top" role="navigation" style="height: 75px;">
                        <div class="navbar-header header-inicio">
                            <button aria-controls="navbar" aria-expanded="false" data-target="#navbar" data-toggle="collapse" class="navbar-toggle collapsed" type="button">
                                <i class="fa fa-reorder"></i>
                            </button>
                            <a href="Index.aspx" class="navbar-brand inicio-logo">
                                <img src="img/novologo.png" class="img-responsive"></a>
                        </div>
                        <div class="navbar-collapse collapse" id="navbar">
                            <asp:Panel runat="server" ID="menu">
                                <ul class="nav navbar-top-links navbar-right header-inicior">
                                    <li>
                                        <asp:Image ID="imgProfile" runat="server" alt="..." CssClass="img-circle img-responsive img-user" />
                                    </li>
                                    <li class="dropdown">
                                        <a href="#" class="dropdown-toggle userClass" data-toggle="dropdown" role="button" aria-expanded="false">
                                            <asp:Label ID="lblUser" runat="server"></asp:Label>
                                            <span class="caret"></span></a>
                                        <ul class="dropdown-menu detalle-user" role="menu">
                                            <li>
                                                <div class="floatleft">
                                                    <asp:Image ID="imgProfileFl" runat="server" alt="..." class="img-circle img-responsive img-user1" />
                                                </div>
                                                <div class="floatleft">
                                                    <p>
                                                        <strong>
                                                            <asp:Label ID="lblUserName" runat="server"></asp:Label></strong>
                                                    </p>
                                                    <p class="green">
                                                        <asp:Label ID="lblNumPartner" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </li>
                                            <li class="divider"></li>
                                            <li>
                                                <p class="col-md-6">
                                                    <a href="Edit.aspx" class="btn btn-primary btn-sm block">Editar perfil</a>
                                                </p>
                                                <p class="col-md-6">
                                                    <a href="Edit.aspx" class="btn btn-primary btn-sm block">Cambiar Clave</a>
                                                </p>
                                                <center>
						                        <p class="col-md-12">							                                                                          
                                                    <a href="SignOutC.aspx" class="btn btn-primary block">Salir</a>
						                        </p>
						                    </center>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </asp:Panel>
                        </div>
                    </nav>
                </div>
                <div class="slider_home">
                    <div class="carousel slide" id="slideHome">
                        <div class="carousel-inner">
                            <div class="item active" style="background-color: rgba(255,255,255,.5)">
                                <img alt="image" class="img-responsive" src="registro_files/banner-nuevo.png">
                                <%--<img alt="image" class="img-responsive" src="../Resources/Images/bannersa.jpg">--%>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="wrapper wrapper-content animated fadeInUp nuevosocio">
                    <div class="contenedor container">
                        <div class="ibox float-e-margins">
                            <div class="ibox-content">

                                <input name="csrfsn" value="1ac27188a5684853ecf92749e6edac71" type="hidden">
                                <div class="col-md-12" style="margin-top: 20px;">
                                </div>
                                <div class="row">
                                    <div class="col-md-9 paisopera">
                                        <div class="col-md-12">
                                            <div class="col-md-3">
                                                <img src="registro_files/nuevo_socio.png" class="img-responsive" border="0">
                                            </div>
                                            <div class="col-md-9">
                                                <h2 class="text-left"><%--<asp:DropDownList ID="ddlSons" runat="server">
                                                </asp:DropDownList>--%>
                                                </h2>
                                                <div class="form-group row">
                                                    <h2 class="text-left"></h2>
                                                    <div class="col-md-7">
                                                    </div>
                                                </div>

                                                <div class="form-group row">
                                                    <label class="col-md-5">Nombre del Patrocinador:</label>
                                                    <div class="col-md-7">

                                                        <asp:Label ID="lblName" runat="server"></asp:Label></strong> /  
                                                        <asp:Label ID="lblU" runat="server" Text="Label"></asp:Label>

                                                    </div>
                                                </div>

                                                <asp:Panel ID="divUpliner" runat="server" class="form-group row" Style="display: none">
                                                    <label class="col-md-5">Nombre del UpLine:</label>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList Style="width: 100%; background-color: black;" ID="ddlSons" runat="server" BackColor="Black">
                                                        </asp:DropDownList>
                                                    </div>
                                                </asp:Panel>

                                                <div class="form-group" style="display: none">
                                                    <label>Mi Enlace : </label>
                                                    <div id="miEnlaces"></div>
                                                    <a class="btn btn-xs btn-primary" onclick="ButonnCopiar('miEnlaces')">Copiar</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row sombra">
                                    <div class="col-md-12">
                                        <h4>Datos Personales</h4>
                                        <hr>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label ID="lblMessagge" Text="" runat="server" ForeColor="Red" Style="font-weight: bold;" />
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Nombres *</label>
                                            <asp:TextBox ID="txtName" runat="server" placeholder="Nombres" class="form-control input-sm capitalize" required="" aria-required="true" type="text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Apellidos *</label>
                                            <asp:TextBox ID="txtLastName" runat="server" placeholder="Apellidos" class="form-control input-sm capitalize" required="" aria-required="true" type="text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtLastName" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group" id="data_1">
                                            <label class="titulo">Fecha de nacimiento *</label>
                                            <div class="input-group date" data-provide="datepicker">
                                                <span class="input-group-addon" style=""><i class="fa fa-calendar-alt" style=""></i></span>
                                                <asp:TextBox ID="txtDateNac" runat="server" name="fecnac" class="form-control input-sm" required="" MaxLength="10" aria-required="true" placeholder="dd/MM/yyyy"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtDateNac" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="">
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label class="titulo">Sexo *</label>
                                                <div class="radio radio-inline text-left">
                                                    <asp:RadioButton ID="rbMan" runat="server" GroupName="sexo" value="M"></asp:RadioButton>
                                                    <label for="rbMan">Masculino</label>
                                                </div>
                                                <div class="radio radio-inline text-left">
                                                    <asp:RadioButton ID="rbWoman" runat="server" GroupName="sexo" value="F"></asp:RadioButton>
                                                    <label for="rbWoman">Femenino</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Nacionalidad *</label>
                                            <asp:DropDownList ID="ddlNationality" runat="server" class="form-control input-sm" required="" aria-required="true">
                                                <asp:ListItem Value="" Text="--Seleccionado--" />
                                                <asp:ListItem Value="Burkines" Text="Burkinés" />
                                                <asp:ListItem Value="Angoleno" Text="Angoleño, -ña" />
                                                <asp:ListItem Value="Argelino" Text="Argelino, -na" />
                                                <asp:ListItem Value="Benines" Text="Beninés, -sa" />
                                                <asp:ListItem Value="Botsuano" Text="Botsuano, -na" />
                                                <asp:ListItem Value="Burundes" Text="Burundés, -sa" />
                                                <asp:ListItem Value="Caboverdiano" Text="Caboverdiano, -na" />
                                                <asp:ListItem Value="Camerunes" Text="Camerunés, -sa" />
                                                <asp:ListItem Value="Chadiano" Text="Chadiano, -na" />
                                                <asp:ListItem Value="Comorense" Text="Comorense" />
                                                <asp:ListItem Value="Congoleno" Text="Congoleño, -ña" />
                                                <asp:ListItem Value="Marfileno" Text="Marfileño, -ña" />
                                                <asp:ListItem Value="Egipcio" Text="Egipcio, -cia" />
                                                <asp:ListItem Value="Eritreo" Text="Eritreo, -a" />
                                                <asp:ListItem Value="Etíope" Text="Etíope" />
                                                <asp:ListItem Value="Gabones" Text="Gabonés, -sa" />
                                                <asp:ListItem Value="Gambiano" Text="Gambiano, -na" />
                                                <asp:ListItem Value="Ghanes" Text="Ghanés, -sa" />
                                                <asp:ListItem Value="Guineano" Text="Guineano, -na" />
                                                <asp:ListItem Value="Ecuatoguineano" Text="Ecuatoguineano, -na" />
                                                <asp:ListItem Value="Keniano" Text="Keniano, -na o keniata" />
                                                <asp:ListItem Value="Lesotense" Text="Lesotense" />
                                                <asp:ListItem Value="Liberiano" Text="Liberiano, -na" />
                                                <asp:ListItem Value="Libio" Text="Libio, -bia" />
                                                <asp:ListItem Value="Malgache" Text="Malgache" />
                                                <asp:ListItem Value="Malaui" Text="Malauí" />
                                                <asp:ListItem Value="Maliense" Text="Maliense o malí" />
                                                <asp:ListItem Value="Marroqui" Text="Marroquí" />
                                                <asp:ListItem Value="Mauriciano" Text="Mauriciano, -na" />
                                                <asp:ListItem Value="Mauritano" Text="Mauritano, -na" />
                                                <asp:ListItem Value="Mozambiqueno" Text="Mozambiqueño, -ña" />
                                                <asp:ListItem Value="Namibio" Text="Namibio, -bia" />
                                                <asp:ListItem Value="Nigerino" Text="Nigerino, -na" />
                                                <asp:ListItem Value="Nigeriano" Text="Nigeriano, -na" />
                                                <asp:ListItem Value="Centroafricano" Text="Centroafricano, -na" />
                                                <asp:ListItem Value="Ruandes" Text="Ruandés, -sa" />
                                                <asp:ListItem Value="Santotomense" Text="Santotomense" />
                                                <asp:ListItem Value="Senegales" Text="Senegalés, -sa" />
                                                <asp:ListItem Value="Seychellense" Text="Seychellense" />
                                                <asp:ListItem Value="Sierraleones" Text="Sierraleonés, -sa" />
                                                <asp:ListItem Value="Somali" Text="Somalí" />
                                                <asp:ListItem Value="Suazi" Text="Suazi" />
                                                <asp:ListItem Value="Sudafricano" Text="Sudafricano, -na" />
                                                <asp:ListItem Value="Sudanes" Text="Sudanés, -sa" />
                                                <asp:ListItem Value="Tanzano" Text="Tanzano, -na" />
                                                <asp:ListItem Value="Togoles" Text="Togolés, -sa" />
                                                <asp:ListItem Value="Tunecino" Text="Tunecino, -na" />
                                                <asp:ListItem Value="Ugandes" Text="Ugandés, -sa" />
                                                <asp:ListItem Value="Yibutiano" Text="Yibutiano, -na" />
                                                <asp:ListItem Value="Zaireno" Text="Zaireño, -ña" />
                                                <asp:ListItem Value="Zambiano" Text="Zambiano, -na" />
                                                <asp:ListItem Value="Zimbabuense" Text="Zimbabuense" />
                                                <asp:ListItem Value="Antiguano" Text="Antiguano, -na" />
                                                <asp:ListItem Value="Argentino" Text="Argentino, -na" />
                                                <asp:ListItem Value="Bahameno" Text="Bahameño, -ña" />
                                                <asp:ListItem Value="Barbadense" Text="Barbadense" />
                                                <asp:ListItem Value="Beliceno" Text="Beliceño, -ña" />
                                                <asp:ListItem Value="Boliviano" Text="Boliviano, -na" />
                                                <asp:ListItem Value="Brasileno" Text="Brasileño, -ña o brasilero, -ra" />
                                                <asp:ListItem Value="Canadiense" Text="Canadiense" />
                                                <asp:ListItem Value="Chileno" Text="Chileno, -na" />
                                                <asp:ListItem Value="Colombiano" Text="Colombiano, -na" />
                                                <asp:ListItem Value="Costarricense" Text="Costarricense" />
                                                <asp:ListItem Value="Cubano" Text="Cubano, -na" />
                                                <asp:ListItem Value="Dominiques" Text="Dominiqués, -sa" />
                                                <asp:ListItem Value="Ecuatoriano" Text="Ecuatoriano, -na" />
                                                <asp:ListItem Value="Salvadoreno" Text="Salvadoreño, -ña" />
                                                <asp:ListItem Value="Estadounidense" Text="Estadounidense" />
                                                <asp:ListItem Value="Granadino" Text="Granadino, -na" />
                                                <asp:ListItem Value="Guatemalteco" Text="Guatemalteco, -ca" />
                                                <asp:ListItem Value="Guyanes" Text="Guyanés, -sa" />
                                                <asp:ListItem Value="Haitiano" Text="Haitiano, -na" />
                                                <asp:ListItem Value="Hondureno" Text="Hondureño, -ña" />
                                                <asp:ListItem Value="Jamaicano" Text="Jamaicano, -na o jamaiquino, -na" />
                                                <asp:ListItem Value="Mexicano" Text="Mexicano, -na" />
                                                <asp:ListItem Value="Nicaraguense" Text="Nicaragüense" />
                                                <asp:ListItem Value="Panameno" Text="Panameño, -ña" />
                                                <asp:ListItem Value="Paraguayo" Text="Paraguayo, -ya" />
                                                <asp:ListItem Value="Peruano" Text="Peruano, -na" />
                                                <asp:ListItem Value="Puertorriqueno" Text="Puertorriqueño," />
                                                <asp:ListItem Value="Dominicano" Text="Dominicano, -na" />
                                                <asp:ListItem Value="Sancristobaleno" Text="Sancristobaleño, -ña" />
                                                <asp:ListItem Value="Sanvicentino" Text="Sanvicentino, -na" />
                                                <asp:ListItem Value="Santalucense" Text="Santalucense" />
                                                <asp:ListItem Value="Surinames" Text="Surinamés, -sa" />
                                                <asp:ListItem Value="Trinitense" Text="Trinitense" />
                                                <asp:ListItem Value="Uruguayo" Text="Uruguayo, -ya" />
                                                <asp:ListItem Value="Venezolano" Text="Venezolano, -na" />
                                                <asp:ListItem Value="Afgano" Text="Afgano, -na" />
                                                <asp:ListItem Value="Saudi" Text="Saudí o saudita" />
                                                <asp:ListItem Value="Armenio" Text="Armenio, -nia" />
                                                <asp:ListItem Value="Azerbaiyano" Text="Azerbaiyano, -na" />
                                                <asp:ListItem Value="Bahreini" Text="Bahreiní" />
                                                <asp:ListItem Value="Bangladesi" Text="Bangladesí" />
                                                <asp:ListItem Value="Birmano" Text="Birmano, -na" />
                                                <asp:ListItem Value="Bruneano" Text="Bruneano, -na" />
                                                <asp:ListItem Value="Butanes" Text="Butanés, -sa" />
                                                <asp:ListItem Value="Camboyano" Text="Camboyano, -na" />
                                                <asp:ListItem Value="Chino" Text="Chino, -na" />
                                                <asp:ListItem Value="Chipriota" Text="Chipriota" />
                                                <asp:ListItem Value="Norcoreano" Text="Norcoreano, -na" />
                                                <asp:ListItem Value="Surcoreano" Text="Surcoreano, -na" />
                                                <asp:ListItem Value="Filipino" Text="Filipino, -na" />
                                                <asp:ListItem Value="Georgiano" Text="Georgiano, -na" />
                                                <asp:ListItem Value="Indio" Text="Indio, -dia" />
                                                <asp:ListItem Value="Indonesio" Text="Indonesio, -sia" />
                                                <asp:ListItem Value="Irani" Text="Iraní" />
                                                <asp:ListItem Value="Iraqui" Text="Iraquí" />
                                                <asp:ListItem Value="Israeli" Text="Israelí" />
                                                <asp:ListItem Value="Japones" Text="Japonés, -sa" />
                                                <asp:ListItem Value="Jordano" Text="Jordano, -na" />
                                                <asp:ListItem Value="Kazajo" Text="Kazajo, -ja" />
                                                <asp:ListItem Value="Kirguis" Text="Kirguís o kirguiso, -sa" />
                                                <asp:ListItem Value="Kuwaiti" Text="Kuwaití" />
                                                <asp:ListItem Value="Laosiano" Text="Laosiano, -na" />
                                                <asp:ListItem Value="Libanes" Text="Libanés, -sa" />
                                                <asp:ListItem Value="Malasio" Text="Malasio, -sia" />
                                                <asp:ListItem Value="Maldivo" Text="Maldivo, -va" />
                                                <asp:ListItem Value="Mongol" Text="Mongol, -la" />
                                                <asp:ListItem Value="Nepales" Text="Nepalés, -sa o nepalí" />
                                                <asp:ListItem Value="Omani" Text="Omaní" />
                                                <asp:ListItem Value="Pakistani" Text="Pakistaní" />
                                                <asp:ListItem Value="Catari" Text="Catarí o qatarí" />
                                                <asp:ListItem Value="Singapurense" Text="Singapurense" />
                                                <asp:ListItem Value="Sirio" Text="Sirio, -ria" />
                                                <asp:ListItem Value="Ceilanes" Text="Ceilanés, -sa, ceilandés, -sa o esrilanqués, -sa" />
                                                <asp:ListItem Value="Tailandes" Text="Tailandés, -sa" />
                                                <asp:ListItem Value="Tayiko" Text="Tayiko, -ka" />
                                                <asp:ListItem Value="Timorense" Text="Timorense" />
                                                <asp:ListItem Value="Turcomano" Text="Turcomano, -na o turkmeno, -na" />
                                                <asp:ListItem Value="Uzbeko" Text="Uzbeko, -ka" />
                                                <asp:ListItem Value="Vietnamita" Text="Vietnamita" />
                                                <asp:ListItem Value="Yemeni" Text="Yemení" />
                                                <asp:ListItem Value="Albanes" Text="Albanés, -sa" />
                                                <asp:ListItem Value="Aleman" Text="Alemán, -na" />
                                                <asp:ListItem Value="Andorrano" Text="Andorrano, -na" />
                                                <asp:ListItem Value="Austriaco" Text="Austriaco, -ca o austríaco, -ca" />
                                                <asp:ListItem Value="Belga" Text="Belga" />
                                                <asp:ListItem Value="Bielorruso" Text="Bielorruso, -sa" />
                                                <asp:ListItem Value="Bosnio" Text="Bosnio, -nia o bosnioherzegovino, -na" />
                                                <asp:ListItem Value="Bulgaro" Text="Búlgaro, -ra" />
                                                <asp:ListItem Value="Vaticano" Text="Vaticano, -na" />
                                                <asp:ListItem Value="Croata" Text="Croata" />
                                                <asp:ListItem Value="Danes" Text="Danés, -sa" />
                                                <asp:ListItem Value="Eslovaco" Text="Eslovaco, -ca" />
                                                <asp:ListItem Value="Esloveno" Text="Esloveno, -na" />
                                                <asp:ListItem Value="Espanol" Text="Español, -la" />
                                                <asp:ListItem Value="Estonio" Text="Estonio, -nia" />
                                                <asp:ListItem Value="Finlandes" Text="Finlandés, -sa" />
                                                <asp:ListItem Value="Frances" Text="Francés, -sa" />
                                                <asp:ListItem Value="Griego" Text="Griego, -ga" />
                                                <asp:ListItem Value="Hungaro" Text="Húngaro, -ra" />
                                                <asp:ListItem Value="Irlandes" Text="Irlandés, -sa" />
                                                <asp:ListItem Value="Italiano" Text="Italiano, -na" />
                                                <asp:ListItem Value="Leton" Text="Letón, -na" />
                                                <asp:ListItem Value="Liechtensteiniano" Text="Liechtensteiniano, -na" />
                                                <asp:ListItem Value="Lituano" Text="Lituano, -na" />
                                                <asp:ListItem Value="Luxemburgues" Text="Luxemburgués, -sa" />
                                                <asp:ListItem Value="Macedonio" Text="Macedonio, -nia" />
                                                <asp:ListItem Value="Maltes" Text="Maltés, -sa" />
                                                <asp:ListItem Value="Moldavo" Text="Moldavo, -va" />
                                                <asp:ListItem Value="Monegasco" Text="Monegasco, -ca" />
                                                <asp:ListItem Value="Noruego" Text="Noruego, -ga" />
                                                <asp:ListItem Value="Neerlandes" Text="Neerlandés, -sa" />
                                                <asp:ListItem Value="Polaco" Text="Polaco, -ca" />
                                                <asp:ListItem Value="Portugues" Text="Portugués, -sa" />
                                                <asp:ListItem Value="Britanico" Text="Británico, -ca" />
                                                <asp:ListItem Value="Checo" Text="Checo, -ca" />
                                                <asp:ListItem Value="Rumano" Text="Rumano, -na" />
                                                <asp:ListItem Value="Ruso" Text="Ruso, -sa" />
                                                <asp:ListItem Value="Sanmarinense" Text="Sanmarinense" />
                                                <asp:ListItem Value="Erbio" Text="Erbio, -a" />
                                                <asp:ListItem Value="Sueco" Text="Sueco, -ca" />
                                                <asp:ListItem Value="Suizo" Text="Suizo, -za" />
                                                <asp:ListItem Value="Turco" Text="Turco, -ca" />
                                                <asp:ListItem Value="Ucraniano" Text="Ucraniano, -na" />
                                                <asp:ListItem Value="Australiano" Text="Australiano, -na" />
                                                <asp:ListItem Value="Fiyiano" Text="Fiyiano, -na" />
                                                <asp:ListItem Value="Marshales" Text="Marshalés, -sa" />
                                                <asp:ListItem Value="Salomonense" Text="Salomonense" />
                                                <asp:ListItem Value="Kiribatiano" Text="Kiribatiano, -na" />
                                                <asp:ListItem Value="Micronesio" Text="Micronesio, -sia" />
                                                <asp:ListItem Value="Nauruano" Text="Nauruano, -na" />
                                                <asp:ListItem Value="Neozelandes" Text="Neozelandés, -sa" />
                                                <asp:ListItem Value="Palauano" Text="Palauano, -na" />
                                                <asp:ListItem Value="Papu" Text="Papú" />
                                                <asp:ListItem Value="Samoano" Text="Samoano, -na" />
                                                <asp:ListItem Value="Tongano" Text="Tongano, -na" />
                                                <asp:ListItem Value="Tuvaluano" Text="Tuvaluano, -na" />
                                                <asp:ListItem Value="Vanuatuense" Text="Vanuatuense" />
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddlNationality" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label class="titulo">Tipo documento *</label>
                                            <asp:DropDownList ID="ddlTypeDoc" runat="server" class="form-control input-sm" name="tipodoc" required="" aria-required="true">
                                                <asp:ListItem Value="" Selected="True">Seleccione...</asp:ListItem>
                                                <asp:ListItem Value="1">Documento de Identidad</asp:ListItem>
                                                <asp:ListItem Value="2">Carnet o cedula de Extrangeria</asp:ListItem>
                                                <asp:ListItem Value="3">Pasaporte</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlTypeDoc" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Nro. documento<span style="color: red;">* Asegurese de colocar Correctamente su N° de Documento</span></label>
                                            <asp:TextBox ID="txtNumDoc" name="nrodoc" placeholder="Nro. documento" class="form-control input-sm" required="" aria-required="true" type="text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtNumDoc" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label class="titulo">Estado Civil *</label>
                                            <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="" Text="--Seleccionar--"> </asp:ListItem>
                                                <asp:ListItem Value="1" Text="Soltero(a)"> </asp:ListItem>
                                                <asp:ListItem Value="2" Text="Casado(a)"> </asp:ListItem>
                                                <asp:ListItem Value="3" Text="Viudo(a)"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Divorciado(a)"> </asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddlEstadoCivil" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <br>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <div class="">
                                                <a data-toggle="collapse" href="#collapse4">
                                                    <div style="display: flex; right: 0; color: black">
                                                        <h4 class="panel-title">Co-Solicitante <span>(opcional)</span></h4>
                                                        <br />
                                                        <%-- <i class="fas fa-angle-down" style="position: absolute;      padding-top: 5px; right: 23px;"></i>--%>
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="collapse4" class="panel-collapse collapse" style="margin-bottom: 5px;">
                                        <div class="panel-body">
                                            <div class="col-md-8 col-md-offset-1" style="margin-bottom: 10px;">
                                                <label>Nombres</label>
                                                <asp:TextBox ID="txtNameC" runat="server" placeholder="Nombres" class="form-control input-sm capitalize"></asp:TextBox>
                                            </div>
                                            <div class="col-md-8 col-md-offset-1" style="margin-bottom: 10px;">
                                                <label>Apellidos</label>
                                                <asp:TextBox ID="txtLastNameC" runat="server" placeholder="Apellidos" class="form-control input-sm capitalize"></asp:TextBox>
                                            </div>
                                            <div class="col-md-8 col-md-offset-1" style="margin-bottom: 10px;">
                                                <label>Tipo documento</label>
                                                <asp:DropDownList ID="ddlTypeDocC" runat="server" class="form-control input-sm" name="tipodoc">
                                                    <asp:ListItem Value="" Selected="True">Seleccione...</asp:ListItem>
                                                    <asp:ListItem Value="1">DNI</asp:ListItem>
                                                    <asp:ListItem Value="2">CE</asp:ListItem>
                                                    <asp:ListItem Value="3">Pasaporte</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-8 col-md-offset-1" style="margin-bottom: 10px;">
                                                <div class="form-group">
                                                    <label>Nro. documento </label>
                                                    <asp:TextBox ID="txtnumDocC" name="nrodoc" placeholder="Nro. documento" class="form-control input-sm" aria-required="true" type="text" runat="server"></asp:TextBox>
                                                    <p class="m-t msg_doc">
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="col-md-8 col-md-offset-1">
                                                <div class="form-group">
                                                    <label class="titulo">Fecha de nacimiento del Co-Solicitante *</label>
                                                    <div class="input-group date" data-provide="datepicker">
                                                        <span class="input-group-addon" style=""><i class="fa fa-calendar-alt" style=""></i></span>
                                                        <asp:TextBox ID="BirthdayDateCa" runat="server" name="fecnac" class="form-control input-sm" MaxLength="10" placeholder="dd/MM/yyyy"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="display: none">

                                        <div class="col-md-12">
                                            <h4>Datos Financieros <span>(opcinal)</span></h4>
                                            <hr>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>
                                                    El pago de comisiones será transferido en Soles para el caso de Perú. 
                                                Para otros países será transferido en dólares USD.
                                                Es requerido que el número de cuenta suministrado por usted sea 
                                                una cuenta en función a la moneda a recibir.
                                                </label>
                                            </div>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Nombre del Banco</label>
                                                <asp:DropDownList ID="ddlBanck" runat="server" class="form-control input-sm" name="tipodoc">
                                                    <asp:ListItem Value="" Selected="True">Seleccione...</asp:ListItem>
                                                    <asp:ListItem Value="1">Interbank</asp:ListItem>
                                                    <asp:ListItem Value="2">Scotiabank</asp:ListItem>
                                                    <asp:ListItem Value="3">BCP</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Nombre del titular de cuenta bancaria:</label>
                                                <asp:TextBox ID="txtNameTitularCuentaBan" runat="server" placeholder="Nombres" class="form-control input-sm capitalize"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label class="titulo">Tipo de Cuenta:</label>
                                                <div class="radio radio-inline text-left">
                                                    <asp:RadioButton ID="rbCuentaCo" runat="server" GroupName="Cuenta" value="C" Checked></asp:RadioButton>
                                                    <label for="rbCor">Cuenta Corriente</label>
                                                </div>
                                                <div class="radio radio-inline text-left">
                                                    <asp:RadioButton ID="rbCuentaAH" runat="server" GroupName="Cuenta" value="A"></asp:RadioButton>
                                                    <label for="rbAho">Cuenta de Ahorros</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Número de Cuenta:</label>
                                                <asp:TextBox ID="txtNumCuenta" runat="server" placeholder="Número de Cuenta" class="form-control input-sm capitalize"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Numero de Contribuyente </label>
                                                <asp:TextBox ID="txtNumContr" runat="server" name="razonsocial" placeholder="# Razón Social" class="form-control input-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Razón Social</label>
                                                <asp:TextBox ID="txtBusinessName" runat="server" name="razonsocial" placeholder="Razón Social" class="form-control input-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Dirección Fiscal</label>
                                                <asp:TextBox ID="txtFiscalAddress" runat="server" name="direccionfiscal" placeholder="Dirección Fiscal" class="form-control input-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <h4>Datos de Contacto</h4>
                                        <hr>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Correo electrónico *</label>
                                            <asp:TextBox ID="txtEmail" runat="server" name="correo" placeholder="Correo electrónico" class="form-control input-sm" required="" aria-required="true" TextMode="Email"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtEmail" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="regexEmailValid" ControlToValidate="txtEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="No es un correo valido." ForeColor="Red" CssClass="text-right"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <%--<div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Nro. Celular 2 <span>(opcional)</span></label>
                                            <asp:TextBox ID="txtPhone2" runat="server" name="celular" placeholder="Nro. Teléfono móvil" class="form-control input-sm" onkeypress="return FormatoNumero(event);" aria-required="true"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>País de Recidencia*</label>

                                            <%--                                            <asp:TextBox ID="txtCountry2" runat="server" name="pais" Text="Peru" placeholder="País" class="form-control input-sm capitalize" required="" aria-required="true"></asp:TextBox>--%>
                                            <asp:DropDownList runat="server" ID="ddlCountry" class="form-control input-sm capitalize" required="" aria-required="true">
                                                <asp:ListItem Value="0">Selecione país...</asp:ListItem>
                                                <asp:ListItem Value='Afganistan'>Afganistán  </asp:ListItem>
                                                <asp:ListItem Value='Albania'>Albania  </asp:ListItem>
                                                <asp:ListItem Value='Alemania'>Alemania  </asp:ListItem>
                                                <asp:ListItem Value='Andorra'>Andorra  </asp:ListItem>
                                                <asp:ListItem Value='Angola'>Angola  </asp:ListItem>
                                                <asp:ListItem Value='Antigua y Barbuda'>Antigua y Barbuda  </asp:ListItem>
                                                <asp:ListItem Value='Arabia Saudita '>Arabia Saudita  </asp:ListItem>
                                                <asp:ListItem Value='Argelia'>Argelia  </asp:ListItem>
                                                <asp:ListItem Value='Argentina'>Argentina  </asp:ListItem>
                                                <asp:ListItem Value='Armenia'>Armenia  </asp:ListItem>
                                                <asp:ListItem Value='Australia'>Australia  </asp:ListItem>
                                                <asp:ListItem Value='Austria'>Austria  </asp:ListItem>
                                                <asp:ListItem Value='Azerbaiyán'>Azerbaiyán  </asp:ListItem>
                                                <asp:ListItem Value='Bahamas'>Bahamas  </asp:ListItem>
                                                <asp:ListItem Value='Bangladés'>Bangladés  </asp:ListItem>
                                                <asp:ListItem Value='Barbados'>Barbados  </asp:ListItem>
                                                <asp:ListItem Value='Baréin'>Baréin  </asp:ListItem>
                                                <asp:ListItem Value='Bélgica'>Bélgica  </asp:ListItem>
                                                <asp:ListItem Value='Belice '>Belice  </asp:ListItem>
                                                <asp:ListItem Value='Benin '>Benin  </asp:ListItem>
                                                <asp:ListItem Value='Bielorrusia '>Bielorrusia  </asp:ListItem>
                                                <asp:ListItem Value='Bolivia '>Bolivia  </asp:ListItem>
                                                <asp:ListItem Value='Bosnia y Herzegovina '>Bosnia y Herzegovina  </asp:ListItem>
                                                <asp:ListItem Value='Botsuana '>Botsuana  </asp:ListItem>
                                                <asp:ListItem Value='Brasil '>Brasil  </asp:ListItem>
                                                <asp:ListItem Value='Brunéi '>Brunéi  </asp:ListItem>
                                                <asp:ListItem Value='Bulgaria '>Bulgaria  </asp:ListItem>
                                                <asp:ListItem Value='Burkina Faso '>Burkina Faso  </asp:ListItem>
                                                <asp:ListItem Value='Burundi '>Burundi  </asp:ListItem>
                                                <asp:ListItem Value='Bután '>Bután  </asp:ListItem>
                                                <asp:ListItem Value='Cabo Verde '>Cabo Verde  </asp:ListItem>
                                                <asp:ListItem Value='Camboya '>Camboya  </asp:ListItem>
                                                <asp:ListItem Value='Camerún '>Camerún  </asp:ListItem>
                                                <asp:ListItem Value='Canadá '>Canadá  </asp:ListItem>
                                                <asp:ListItem Value='Catar '>Catar  </asp:ListItem>
                                                <asp:ListItem Value='Chad '>Chad  </asp:ListItem>
                                                <asp:ListItem Value='Chile '>Chile  </asp:ListItem>
                                                <asp:ListItem Value='China '>China  </asp:ListItem>
                                                <asp:ListItem Value='Chipre '>Chipre  </asp:ListItem>
                                                <asp:ListItem Value='Colombia '>Colombia  </asp:ListItem>
                                                <asp:ListItem Value='Comoras '>Comoras  </asp:ListItem>
                                                <asp:ListItem Value='Corea del Norte '>Corea del Norte  </asp:ListItem>
                                                <asp:ListItem Value='Corea del Sur '>Corea del Sur  </asp:ListItem>
                                                <asp:ListItem Value='Costa de Marfil '>Costa de Marfil  </asp:ListItem>
                                                <asp:ListItem Value='Costa Rica '>Costa Rica  </asp:ListItem>
                                                <asp:ListItem Value='Croacia '>Croacia  </asp:ListItem>
                                                <asp:ListItem Value='Cuba '>Cuba  </asp:ListItem>
                                                <asp:ListItem Value='Dinamarca '>Dinamarca  </asp:ListItem>
                                                <asp:ListItem Value='Dominica '>Dominica  </asp:ListItem>
                                                <asp:ListItem Value='Ecuador '>Ecuador  </asp:ListItem>
                                                <asp:ListItem Value='Egipto '>Egipto  </asp:ListItem>
                                                <asp:ListItem Value='El Salvador '>El Salvador  </asp:ListItem>
                                                <asp:ListItem Value='Emiratos Árabes Unidos '>Emiratos Árabes Unidos  </asp:ListItem>
                                                <asp:ListItem Value='Eritrea '>Eritrea  </asp:ListItem>
                                                <asp:ListItem Value='Eslovaquia '>Eslovaquia  </asp:ListItem>
                                                <asp:ListItem Value='Eslovenia '>Eslovenia  </asp:ListItem>
                                                <asp:ListItem Value='España '>España  </asp:ListItem>
                                                <asp:ListItem Value='Estados Unidos '>Estados Unidos  </asp:ListItem>
                                                <asp:ListItem Value='Estonia '>Estonia  </asp:ListItem>
                                                <asp:ListItem Value='Etiopía '>Etiopía  </asp:ListItem>
                                                <asp:ListItem Value='Fiji '>Fiji  </asp:ListItem>
                                                <asp:ListItem Value='Filipinas '>Filipinas  </asp:ListItem>
                                                <asp:ListItem Value='Finlandia '>Finlandia  </asp:ListItem>
                                                <asp:ListItem Value='Francia '>Francia  </asp:ListItem>
                                                <asp:ListItem Value='Gabón '>Gabón  </asp:ListItem>
                                                <asp:ListItem Value='Gambia '>Gambia  </asp:ListItem>
                                                <asp:ListItem Value='Georgia '>Georgia  </asp:ListItem>
                                                <asp:ListItem Value='Ghana '>Ghana  </asp:ListItem>
                                                <asp:ListItem Value='Granada '>Granada  </asp:ListItem>
                                                <asp:ListItem Value='Grecia '>Grecia  </asp:ListItem>
                                                <asp:ListItem Value='Guatemala '>Guatemala  </asp:ListItem>
                                                <asp:ListItem Value='Guinea '>Guinea  </asp:ListItem>
                                                <asp:ListItem Value='Guinea Ecuatorial '>Guinea Ecuatorial  </asp:ListItem>
                                                <asp:ListItem Value='Guinea-Bisáu '>Guinea-Bisáu  </asp:ListItem>
                                                <asp:ListItem Value='Guyana '>Guyana  </asp:ListItem>
                                                <asp:ListItem Value='Haití '>Haití  </asp:ListItem>
                                                <asp:ListItem Value='Honduras '>Honduras  </asp:ListItem>
                                                <asp:ListItem Value='Hungría '>Hungría  </asp:ListItem>
                                                <asp:ListItem Value='India '>India  </asp:ListItem>
                                                <asp:ListItem Value='Indonesia '>Indonesia  </asp:ListItem>
                                                <asp:ListItem Value='Irak '>Irak  </asp:ListItem>
                                                <asp:ListItem Value='Irán '>Irán  </asp:ListItem>
                                                <asp:ListItem Value='Irlanda '>Irlanda  </asp:ListItem>
                                                <asp:ListItem Value='Islandia '>Islandia  </asp:ListItem>
                                                <asp:ListItem Value='Islas Marshall '>Islas Marshall  </asp:ListItem>
                                                <asp:ListItem Value='Islas Salomón '>Islas Salomón  </asp:ListItem>
                                                <asp:ListItem Value='Israel '>Israel  </asp:ListItem>
                                                <asp:ListItem Value='Italia '>Italia  </asp:ListItem>
                                                <asp:ListItem Value='Jamaica '>Jamaica  </asp:ListItem>
                                                <asp:ListItem Value='Japón '>Japón  </asp:ListItem>
                                                <asp:ListItem Value='Jordania '>Jordania  </asp:ListItem>
                                                <asp:ListItem Value='Kazajistán '>Kazajistán  </asp:ListItem>
                                                <asp:ListItem Value='Kenia '>Kenia  </asp:ListItem>
                                                <asp:ListItem Value='Kirguistán '>Kirguistán  </asp:ListItem>
                                                <asp:ListItem Value='Kiribati '>Kiribati  </asp:ListItem>
                                                <asp:ListItem Value='Kuwait '>Kuwait  </asp:ListItem>
                                                <asp:ListItem Value='Laos '>Laos  </asp:ListItem>
                                                <asp:ListItem Value='Lesoto '>Lesoto  </asp:ListItem>
                                                <asp:ListItem Value='Letonia '>Letonia  </asp:ListItem>
                                                <asp:ListItem Value='Líbano '>Líbano  </asp:ListItem>
                                                <asp:ListItem Value='Liberia '>Liberia  </asp:ListItem>
                                                <asp:ListItem Value='Libia '>Libia  </asp:ListItem>
                                                <asp:ListItem Value='Liechtenstein '>Liechtenstein  </asp:ListItem>
                                                <asp:ListItem Value='Lituania '>Lituania  </asp:ListItem>
                                                <asp:ListItem Value='Luxemburgo '>Luxemburgo  </asp:ListItem>
                                                <asp:ListItem Value='Macedonia '>Macedonia  </asp:ListItem>
                                                <asp:ListItem Value='Madagascar '>Madagascar  </asp:ListItem>
                                                <asp:ListItem Value='Malasia '>Malasia  </asp:ListItem>
                                                <asp:ListItem Value='Malaui '>Malaui  </asp:ListItem>
                                                <asp:ListItem Value='Maldivas '>Maldivas  </asp:ListItem>
                                                <asp:ListItem Value='Malí '>Malí  </asp:ListItem>
                                                <asp:ListItem Value='Malta '>Malta  </asp:ListItem>
                                                <asp:ListItem Value='Marruecos '>Marruecos  </asp:ListItem>
                                                <asp:ListItem Value='Mauricio '>Mauricio  </asp:ListItem>
                                                <asp:ListItem Value='Mauritania '>Mauritania  </asp:ListItem>
                                                <asp:ListItem Value='México '>México  </asp:ListItem>
                                                <asp:ListItem Value='Micronesia '>Micronesia  </asp:ListItem>
                                                <asp:ListItem Value='Moldavia '>Moldavia  </asp:ListItem>
                                                <asp:ListItem Value='Mónaco '>Mónaco  </asp:ListItem>
                                                <asp:ListItem Value='Mongolia '>Mongolia  </asp:ListItem>
                                                <asp:ListItem Value='Montenegro '>Montenegro  </asp:ListItem>
                                                <asp:ListItem Value='Mozambique '>Mozambique  </asp:ListItem>
                                                <asp:ListItem Value='Myanmar '>Myanmar  </asp:ListItem>
                                                <asp:ListItem Value='Namibia '>Namibia  </asp:ListItem>
                                                <asp:ListItem Value='Nauru '>Nauru  </asp:ListItem>
                                                <asp:ListItem Value='Nepal '>Nepal  </asp:ListItem>
                                                <asp:ListItem Value='Nicaragua '>Nicaragua  </asp:ListItem>
                                                <asp:ListItem Value='Niger '>Niger  </asp:ListItem>
                                                <asp:ListItem Value='Nigeria '>Nigeria  </asp:ListItem>
                                                <asp:ListItem Value='Noruega '>Noruega  </asp:ListItem>
                                                <asp:ListItem Value='Nueva Zelanda '>Nueva Zelanda  </asp:ListItem>
                                                <asp:ListItem Value='Omán '>Omán  </asp:ListItem>
                                                <asp:ListItem Value='Países Bajos '>Países Bajos  </asp:ListItem>
                                                <asp:ListItem Value='Pakistán '>Pakistán  </asp:ListItem>
                                                <asp:ListItem Value='Palaos '>Palaos  </asp:ListItem>
                                                <asp:ListItem Value='Panamá '>Panamá  </asp:ListItem>
                                                <asp:ListItem Value='Papúa Nueva Guinea '>Papúa Nueva Guinea  </asp:ListItem>
                                                <asp:ListItem Value='Paraguay '>Paraguay  </asp:ListItem>
                                                <asp:ListItem Value='Peru'>Perú  </asp:ListItem>
                                                <asp:ListItem Value='Polonia '>Polonia  </asp:ListItem>
                                                <asp:ListItem Value='Portugal '>Portugal  </asp:ListItem>
                                                <asp:ListItem Value='Reino Unido '>Reino Unido  </asp:ListItem>
                                                <asp:ListItem Value='República Centroafricana '>República Centroafricana  </asp:ListItem>
                                                <asp:ListItem Value='República Checa '>República Checa  </asp:ListItem>
                                                <asp:ListItem Value='República del Congo '>República del Congo  </asp:ListItem>
                                                <asp:ListItem Value='República Democratica del Congo '>República Democratica del Congo  </asp:ListItem>
                                                <asp:ListItem Value='República Dominicana '>República Dominicana  </asp:ListItem>
                                                <asp:ListItem Value='Ruanda '>Ruanda  </asp:ListItem>
                                                <asp:ListItem Value='Rumania '>Rumania  </asp:ListItem>
                                                <asp:ListItem Value='Rusia '>Rusia  </asp:ListItem>
                                                <asp:ListItem Value='Samoa '>Samoa  </asp:ListItem>
                                                <asp:ListItem Value='San Cristóbal y Nieves '>San Cristóbal y Nieves  </asp:ListItem>
                                                <asp:ListItem Value='San Marino '>San Marino  </asp:ListItem>
                                                <asp:ListItem Value='San Vicente y las Granadinas '>San Vicente y las Granadinas  </asp:ListItem>
                                                <asp:ListItem Value='Santa Lucía '>Santa Lucía  </asp:ListItem>
                                                <asp:ListItem Value='Santo Tomé y Príncipe '>Santo Tomé y Príncipe  </asp:ListItem>
                                                <asp:ListItem Value='Senegal '>Senegal  </asp:ListItem>
                                                <asp:ListItem Value='Serbia '>Serbia  </asp:ListItem>
                                                <asp:ListItem Value='Seychelles '>Seychelles  </asp:ListItem>
                                                <asp:ListItem Value='Sierra Leona '>Sierra Leona  </asp:ListItem>
                                                <asp:ListItem Value='Singapur '>Singapur  </asp:ListItem>
                                                <asp:ListItem Value='Siria '>Siria  </asp:ListItem>
                                                <asp:ListItem Value='Somalia '>Somalia  </asp:ListItem>
                                                <asp:ListItem Value='Sri Lanka '>Sri Lanka  </asp:ListItem>
                                                <asp:ListItem Value='Suazilandia '>Suazilandia  </asp:ListItem>
                                                <asp:ListItem Value='Sudáfrica '>Sudáfrica  </asp:ListItem>
                                                <asp:ListItem Value='Sudán '>Sudán  </asp:ListItem>
                                                <asp:ListItem Value='Sudán del Sur '>Sudán del Sur  </asp:ListItem>
                                                <asp:ListItem Value='Suecia '>Suecia  </asp:ListItem>
                                                <asp:ListItem Value='Suiza '>Suiza  </asp:ListItem>
                                                <asp:ListItem Value='Surinam '>Surinam  </asp:ListItem>
                                                <asp:ListItem Value='Tailandia '>Tailandia  </asp:ListItem>
                                                <asp:ListItem Value='Tanzania '>Tanzania  </asp:ListItem>
                                                <asp:ListItem Value='Tayikistán '>Tayikistán  </asp:ListItem>
                                                <asp:ListItem Value='Timor Oriental '>Timor Oriental  </asp:ListItem>
                                                <asp:ListItem Value='Togo '>Togo  </asp:ListItem>
                                                <asp:ListItem Value='Tonga '>Tonga  </asp:ListItem>
                                                <asp:ListItem Value='Trinidad y Tobago '>Trinidad y Tobago  </asp:ListItem>
                                                <asp:ListItem Value='Túnez '>Túnez  </asp:ListItem>
                                                <asp:ListItem Value='Turkmenistán '>Turkmenistán  </asp:ListItem>
                                                <asp:ListItem Value='Turquía '>Turquía  </asp:ListItem>
                                                <asp:ListItem Value='Tuvalu '>Tuvalu  </asp:ListItem>
                                                <asp:ListItem Value='Ucrania '>Ucrania  </asp:ListItem>
                                                <asp:ListItem Value='Uganda '>Uganda  </asp:ListItem>
                                                <asp:ListItem Value='Uruguay '>Uruguay  </asp:ListItem>
                                                <asp:ListItem Value='Uzbekistán '>Uzbekistán  </asp:ListItem>
                                                <asp:ListItem Value='Vanuatu '>Vanuatu  </asp:ListItem>
                                                <asp:ListItem Value='Venezuela '>Venezuela  </asp:ListItem>
                                                <asp:ListItem Value='Vietnam '>Vietnam  </asp:ListItem>
                                                <asp:ListItem Value='Yemen '>Yemen  </asp:ListItem>
                                                <asp:ListItem Value='Yibuti '>Yibuti  </asp:ListItem>
                                                <asp:ListItem Value='Zambia '>Zambia  </asp:ListItem>
                                                <asp:ListItem Value='Zimbabue '>Zimbabue  </asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlCountry" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div id="p1" class="" style="display: none">
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Provincia / Ciudad 2*</label>
                                                <asp:DropDownList runat="server" name="ciudades" ID="EstadoPeru" class="form-control input-sm capitalize">
                                                    <asp:ListItem Value="Amazonas">Amazonas</asp:ListItem>
                                                    <asp:ListItem Value="Ancash">Ancash</asp:ListItem>
                                                    <asp:ListItem Value="Apurímac">Apurímac</asp:ListItem>
                                                    <asp:ListItem Value="Arequipa">Arequipa</asp:ListItem>
                                                    <asp:ListItem Value="Ayacucho">Ayacucho</asp:ListItem>
                                                    <asp:ListItem Value="Cajamarca">Cajamarca</asp:ListItem>
                                                    <asp:ListItem Value="Cusco">Cusco</asp:ListItem>
                                                    <asp:ListItem Value="Huancavelica">Huancavelica</asp:ListItem>
                                                    <asp:ListItem Value="Huánuco">Huánuco</asp:ListItem>
                                                    <asp:ListItem Value="Ica">Ica</asp:ListItem>
                                                    <asp:ListItem Value="Junín">Junín</asp:ListItem>
                                                    <asp:ListItem Value="La libertad ">La Libertad</asp:ListItem>
                                                    <asp:ListItem Value="Lambayeque">Lambayeque</asp:ListItem>
                                                    <asp:ListItem Value="Lima">Lima</asp:ListItem>
                                                    <asp:ListItem Value="Loreto">Loreto</asp:ListItem>
                                                    <asp:ListItem Value="Madre de dios">Madre de Dios</asp:ListItem>
                                                    <asp:ListItem Value="Moquegua">Moquegua</asp:ListItem>
                                                    <asp:ListItem Value="Pasco">Pasco</asp:ListItem>
                                                    <asp:ListItem Value="Piura">Piura</asp:ListItem>
                                                    <asp:ListItem Value="Puno">Puno</asp:ListItem>
                                                    <asp:ListItem Value="San martín">San Martín</asp:ListItem>
                                                    <asp:ListItem Value="Tacna">Tacna</asp:ListItem>
                                                    <asp:ListItem Value="Tumbes">Tumbes</asp:ListItem>
                                                    <asp:ListItem Value="Ucayali">Ucayali</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <%--listaDesordenada--%>

                                    <div id="p2" class="" style="display: none">
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <label>Provincia / Ciudad *</label>
                                                <asp:TextBox ID="EstadoOthers" runat="server" name="estado" placeholder="Provincia" class="form-control input-sm capitalize"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Distrito / Estado *</label>
                                            <asp:TextBox ID="txtCiudad2" runat="server" name="cuidad" placeholder="Distrito" class="form-control input-sm capitalize" required="" aria-required="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtCiudad2" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-8 col-md-offset-1">
                                        <div class="form-group">
                                            <label>Dirección </label>
                                            <asp:TextBox ID="txtDireccion" runat="server" name="direccion" placeholder="Dirección" class="form-control input-sm capitalize"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-8 col-md-offset-1">
                                        <label for="txtPhone">Nro. Celular *</label>
                                        <div class="input-group" style="display: flex;">
                                            <div class="input-group-prepend" style="display: inline-block;">
                                                <div class="input-group-text">
                                                    <asp:TextBox ID="codPais" runat="server" Style="display: inline-block; width: 35px; height: 34px; border: 1px solid #a5ce39; border-radius: 4px 0 0 4px;" />
                                                </div>
                                            </div>
                                            <asp:TextBox ID="txtPhone" Style="display: inline-block;" runat="server" name="celular" placeholder="Nro. Teléfono móvil" class="form-control" required="" onkeypress="return FormatoNumero(event);" MaxLength="10" aria-required="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Style="position: absolute; left: 180px; top: 7px; z-index: 10;" ControlToValidate="txtPhone" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <span style="color: red; margin-top: 10px">Obligatorio *</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=" ">
                            <div class="row sombra">
                                <div class="col-md-12">
                                    <h4>PAQUETES DE INSCRIPCIÓN</h4>
                                    <hr>
                                </div>
                                <div id="divStarterKit" class="row minimalSpacing">
                                    <div class="col-md-12">
                                        <div id="costokitini" style="display: none; border-radius: 8px; background-color: red; color: white; height: 30px; font-size: 20px; text-align: center; font-weight: bold; transform: translate(0px,100px) rotate(-8deg)">
                                            <p>Exonerado costo del Kit de Inicio</p>
                                        </div>
                                        <div class="" style="background-color: rgb(100,116,140);">
                                            <div class="panel-heading">
                                                <h2><strong><span style="color: white; width: 125px;" id="lblStarterKit">Kit de Inicio</span></strong></h2>
                                            </div>
                                            <table class="table GridView" cellspacing="0" cellpadding="4" align="Center" rules="all" border="1" id="dgStarterKit" style="background-color: #EEEEEE; border-style: None; font-family: Verdana; font-size: 10pt; width: 100%; border-collapse: collapse;">
                                                <tbody id="tbo">
                                                    <tr class="GridViewHeaderRow">
                                                        <td style="width: 85px;"></td>
                                                        <td>Nombre del producto</td>

                                                        <td>Descripción</td>
                                                        <td>Precio</td>
                                                        <%--<td>Inicial</td>--%>
                                                    </tr>
                                                    <tr style="">
                                                        <td>
                                                            <center>  
                                                            <asp:RadioButton runat="server" GroupName="elegido" ID="packafiliaKit" value="1" Checked></asp:RadioButton>
                                                            </center>
                                                            <label for="packafiliaKit"></label>
                                                        </td>
                                                        <td style="width: 30px;">Kit de Inicio</td>

                                                        <td align="left" style="width: 550px;">
                                                            <ul>
                                                                <li>Programa Vacacional 1</li>
                                                                <li>Club Resort 1</li>
                                                                <li># Acciones 1</li>
                                                            </ul>
                                                        </td>
                                                        <td style="width: 100px;">$10</td>
                                                        <%--<td style="width:50px;">$10</td>--%>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="container">
                                        <div class="panel-group" id="accordion">
                                            <div class=" " style="padding: 20px 25px 5px 20px; display: none">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
                                                    <div class="panel-heading btn btn-info" style="width: 100%; font-size: 20px; margin-left: -15px; background-color: rgb(100,116,140)">
                                                        Consumo - EaseMarket
                                                    </div>
                                                </a>
                                                <div id="collapse1" class="panel-collapse collapse in">
                                                    <div class="panel-body" style="margin-right: 8px;">
                                                        <div class="ibox-content">
                                                            <div class="row sombra">
                                                                <div class="col-md-12">
                                                                    <h4>PAQUETES DE INSCRIPCIÓN</h4>
                                                                    <hr>
                                                                </div>
                                                                <div id="divStarterKithh" class="row minimalSpacing">
                                                                    <div class="col-md-12">
                                                                        <div class="" style="background-color: rgba(159, 176, 202, 1)">
                                                                            <div class="panel-heading">
                                                                                <h2><strong><span style="color: white" id="lblStartedrKit">PAQUETES DE INSCRIPCIÓN</span></strong></h2>
                                                                            </div>
                                                                            <table class="table GridView" cellspacing="0" cellpadding="4" align="Center" rules="all" border="1" id="dgStarterKit" style="background-color: #EEEEEE; border-style: None; font-family: Verdana; font-size: 10pt; width: 100%; border-collapse: collapse;">
                                                                                <tbody>
                                                                                    <tr class="GridViewHeaderRow">
                                                                                        <td>
                                                                                            <input type="checkbox" name="name" id="cbNada300" />N.A</td>
                                                                                        <td>Nombre del producto</td>
                                                                                        <td>Rango</td>
                                                                                        <td>Descripción</td>
                                                                                        <td>Precio</td>
                                                                                        <%--<td>Inicial</td>--%>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td style="width: 45px;">
                                                                                            <asp:RadioButton runat="server" GroupName="consume" ID="consumePack1" value="2"></asp:RadioButton>
                                                                                            <label for="packafiliaEx"></label>
                                                                                        </td>
                                                                                        <td style="width: 125px;">Paquete basico 1 </td>
                                                                                        <td style="width: 30px;">Inicio</td>
                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 1</li>
                                                                                                <li>Club Resort 1</li>
                                                                                                <li># Acciones 2</li>
                                                                                                <li># Cuotas Maximas 
                                                        <asp:TextBox ID="H" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                             <asp:TextBox ID="H2" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Puntos Ganados 99</li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">
                                                                                            <%-- <asp:Label runat="server" ID="montototalexp">200</asp:Label>--%>
                                                                                        </td>
                                                                                        <%-- <td style="width:50px;">
                                                        <asp:Label runat="server" ID="montoinicialexp"></asp:Label>
                                                    </td>--%>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <asp:RadioButton runat="server" GroupName="consume" ID="ConsumePack2" value="3"></asp:RadioButton>
                                                                                            <label for="packafiliaLt"></label>
                                                                                        </td>
                                                                                        <td style="width: 125px;">Paquete basico 2 </td>
                                                                                        <td style="width: 30px;">Oro</td>
                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 3</li>
                                                                                                <li>Club Resort 3</li>
                                                                                                <li># Acciones 4</li>
                                                                                                <li># Cuotas Maximas  
                                                           <asp:TextBox ID="H3" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                           <asp:TextBox ID="H4" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Puntos Ganados 264</li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <%--<asp:Label runat="server" ID="montototallig">200  </asp:Label>--%>
                                                                                        </td>
                                                                                        <%--<td style="width:50px;">
                                                
                                                       <asp:Label runat="server" ID="montoiniciallig"></asp:Label>
                                                     </td>--%>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <asp:RadioButton runat="server" GroupName="consume" ID="ConsumePack3" value="4"></asp:RadioButton>
                                                                                            <label for="packafiliaSt"></label>

                                                                                        </td>

                                                                                        <td style="width: 125px;">Paquete familiar 1</td>
                                                                                        <td style="width: 30px;">Zafiro</td>
                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 6</li>
                                                                                                <li>Club Resort 6</li>
                                                                                                <li># Acciones 6</li>
                                                                                                <li># Cuotas Maximas 
                                                              <asp:TextBox ID="H5" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                            <asp:TextBox ID="H6" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Puntos Ganados 396</li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <%--   <asp:Label runat="server" ID="montototalsta">300 </asp:Label>--%>
                                                                                        </td>
                                                                                        <%--<td style="width: 50px;">
                                                                    <asp:Label runat="server" ID="montoinicialsta"></asp:Label>
                                                                </td>--%>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <asp:RadioButton runat="server" GroupName="consume" ID="ConsumePack4" value="5"></asp:RadioButton>
                                                                                            <label for="packafiliaPl"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">Paquete familiar 2</td>
                                                                                        <td style="width: 30px;">Ruby</td>
                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 10</li>
                                                                                                <li>Club Resort 10</li>
                                                                                                <li># Acciones 8</li>
                                                                                                <li># Cuotas Maximas 
                                                            <asp:TextBox ID="HH" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                             <asp:TextBox ID="HHHG" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Puntos Ganados 528</li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <%--<asp:Label runat="server" ID="montototalplu">400 </asp:Label>--%>
                                                                                        </td>
                                                                                        <%--<td style="width:50px;">
                                                            <asp:Label runat="server" ID="montoinicialplu"></asp:Label>
                                                        </td>--%>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td style="text-align: center;">
                                                                                            <asp:RadioButton runat="server" GroupName="consume" ID="ConsumePack5" value="6"></asp:RadioButton>
                                                                                            <label for="packafiliaTp"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">Paquete familiar 3</td>
                                                                                        <td style="width: 30px;">Esmeralda</td>
                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional vitalicio</li>
                                                                                                <li>Club Resort vitalicio</li>
                                                                                                <li># Acciones vitalicio</li>
                                                                                                <li># Cuotas Maximas 
                                                           <asp:TextBox ID="HFFF" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                            <asp:TextBox ID="HFFFFF" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                </li>
                                                                                                <li>Puntos Ganados 792 </li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <%-- <asp:Label runat="server" ID="montototaltop">500 </asp:Label>--%>
                                                                                        </td>
                                                                                        <%--<td style="width: 50px;">

                                                                    <asp:Label runat="server" ID="montoinicialtop"></asp:Label>
                                                                </td>--%>
                                                                                    </tr>



                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <asp:RadioButton runat="server" GroupName="consume" ID="RadioButton1" value="6"></asp:RadioButton>
                                                                                            <label for="packafiliaMd"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">Paquete familiar 3</td>
                                                                                        <td style="width: 30px;">Esmeralda</td>
                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional vitalicio</li>
                                                                                                <li>Club Resort vitalicio</li>
                                                                                                <li># Acciones vitalicio</li>
                                                                                                <li># Cuotas Maximas 
                                                                                            <asp:TextBox ID="TextBox2" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                                                        <asp:TextBox ID="TextBox3" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                </li>
                                                                                                <li>Puntos Ganados 792 </li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;"></td>

                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="hidden">
                                                                    <input name="porcentaje_1" id="porcentaje_1" value="25" type="hidden">
                                                                    <input name="precio_1" id="precio_1" value="199.00" type="hidden">
                                                                    <input name="puntos_1" id="puntos_1" value="140.00" type="hidden">
                                                                    <input name="porcentaje_2" id="porcentaje_2" value="25" type="hidden">
                                                                    <input name="precio_2" id="precio_2" value="199.00" type="hidden">
                                                                    <input name="puntos_2" id="puntos_2" value="140.00" type="hidden">
                                                                    <input name="porcentaje_5" id="porcentaje_5" value="25" type="hidden">
                                                                    <input name="precio_5" id="precio_5" value="199.00" type="hidden">
                                                                    <input name="puntos_5" id="puntos_5" value="140.00" type="hidden">
                                                                    <input name="porcentaje_3" id="porcentaje_3" value="25" type="hidden">
                                                                    <input name="precio_3" id="precio_3" value="499.00" type="hidden">
                                                                    <input name="puntos_3" id="puntos_3" value="400.00" type="hidden">
                                                                    <input name="porcentaje_4" id="porcentaje_4" value="25" type="hidden">
                                                                    <input name="precio_4" id="precio_4" value="799.00" type="hidden">
                                                                    <input name="puntos_4" id="puntos_4" value="680.00" type="hidden">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="padding: 5px 25px 10px 20px">
                                                <div id="collapse2" class="panel-collapse  ">

                                                    <div class="panel-body col-12 col-md-12" style="margin-right: 20px; margin-left: -25px;">
                                                        <asp:Panel runat="server" ID="pnlExonerar" Style="display: block">
                                                            <asp:CheckBox ID="isExonerar" Text="Codigo para Exonerar" runat="server" Visible="false" />
                                                            <asp:Label ID="lblCode" Text="" runat="server">Codigo Promocional</asp:Label>
                                                            <asp:TextBox CssClass="cuadro" ID="txtContaExonerar" runat="server" Style="width: 80%; margin-bottom: 6px" />
                                                            <asp:Button ID="btnVal" runat="server" class="btn btn-xl btn-primary m-t-n-xs plomo botoncitoValidar" Text="VALIDAR" OnClick="btnVal_Click" autopostback="false"></asp:Button>
                                                            <asp:Label ID="lblAlert" Text="" runat="server"></asp:Label>

                                                        </asp:Panel>
                                                        <div class=" " id="cssbox">
                                                            <div class="row sombra">

                                                                <div class="col-md-12">
                                                                    <%--<h4>PAQUETES DE INSCRIPCIÓN</h4>
                                                                    <hr>--%>
                                                                </div>

                                                                <div id="divStarterKithh" class="row minimalSpacing">
                                                                    <div class="col-md-12">
                                                                        <div class="csspqts" style="background-color: rgb(100,116,140);">
                                                                            <div class="panel-heading">
                                                                                <h2><strong><span style="color: white" id="lblStartedrKit">PAQUETES DE INSCRIPCIÓN</span></strong></h2>
                                                                            </div>
                                                                            <table class="table GridView" cellspacing="0" cellpadding="4" align="Center" rules="all" border="1" id="dgStarterKit" style="background-color: #EEEEEE; border-style: None; font-family: Verdana; font-size: 10pt; width: 100%; border-collapse: collapse;">
                                                                                <tbody>
                                                                                    <tr class="GridViewHeaderRow">
                                                                                        <td>
                                                                                            <center> 
                                                                                            <input type="checkbox" name="name" id="cbNada" onclick="salgamos()" checked="true" />
                                                                                            N.A</td>
                                                                                        </center> 
                                                                                        <td>Nombre del producto</td>

                                                                                        <td>Descripción</td>
                                                                                        <td>Precio</td>
                                                                                        <td>Inicial</td>
                                                                                    </tr>
                                                                                    <%--class="display-none"--%>

                                                                                    <tr id="memVstandBye">
                                                                                        <td>
                                                                                            <center> 
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtSby" onchange="veamos()" value="1"></asp:RadioButton>
                                                                                            </center>
                                                                                            <label for="packafiliaTp"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">

                                                                                            <div class="td mov">Stand By</div>
                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>



                                                                                                <li># Cuotas Maximas 
                                                           <asp:TextBox ID="txtNumCuSby" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialSby" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                    en 
                                                                        <asp:TextBox ID="txtQuotesInitialSby" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    pagos(s)
                                                                                                   
                                                                                                </li>
                                                                                                <li>Puntos Ganados 832 </li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="lblMontoTotalSby"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">

                                                                                            <asp:Label runat="server" ID="lblMontoInicialSby"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%--class="display-none"--%>

                                                                                    <tr id="memVacacional">
                                                                                        <td>
                                                                                            <center> 
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtMd" onchange="veamos()" value="2"></asp:RadioButton>
                                                                                            </center>
                                                                                            <label for="packafiliaTp"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">

                                                                                            <div class="td mov">Expedition</div>
                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 5</li>

                                                                                                <li># Cuotas Maximas 
                                                           <asp:TextBox ID="txtNumCuMd" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialMd" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                    en 
                                                                        <asp:TextBox ID="txtQuotesInitialMd" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    pagos(s)
                                                                                                   
                                                                                                </li>
                                                                                                <li>Puntos Ganados 832 </li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="lblMontoTotalMd"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">

                                                                                            <asp:Label runat="server" ID="lblMontoInicialMd"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%--class="display-none"--%>
                                                                                    <tr id="memEVOLUTIO">
                                                                                        <td>
                                                                                            <center> 
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtEvol" onchange="veamos()" value="3"></asp:RadioButton>
                                                                                            </center>
                                                                                            <label for="packafiliaTp"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">

                                                                                            <div class="td mov">Evolution</div>
                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 10</li>
                                                                                                <li>Club 3</li>

                                                                                                <li># Cuotas Maximas 
                                                                        <asp:TextBox ID="txtNumCuEvol" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialEvol" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                    en 
                                                                        <asp:TextBox ID="txtQuotesInitialEvol" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    pagos(s)
                                                                                                   
                                                                                                </li>
                                                                                                <li>Puntos Ganados 832 </li>
                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="lblMontoTotalEvol"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">

                                                                                            <asp:Label runat="server" ID="lblMontoInicialEvol"></asp:Label>
                                                                                        </td>
                                                                                    </tr>



                                                                                    <tr style="">
                                                                                        <td style="width: 45px;">
                                                                                            <center>  
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtExp" onchange="veamos()" value="4"></asp:RadioButton>
                                                                                            </center>

                                                                                            <label for="packafiliaEx"></label>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <div class="td mov">Experience</div>

                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 2 años</li>
                                                                                                <li>Club Resort 2</li>
                                                                                                <li># Acciones 1</li>
                                                                                                <li># Cuotas Maximas 
                                                        <asp:TextBox ID="txtNumCuEXP" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                             <asp:TextBox ID="txtInitialEXP" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    <span class="display-none" id="spnQuotesExp">en 
                                                             <asp:TextBox ID="ExpInitialQuote" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                        pagos(s)
                                                                                                    </span>

                                                                                                </li>

                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">
                                                                                            <asp:Label runat="server" ID="montototalexp"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">
                                                                                            <asp:Label runat="server" ID="montoinicialexp"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <center> 
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtLight" onchange="veamos()" value="5"></asp:RadioButton>
                                                                                            </center>
                                                                                            <label for="packafiliaLt"></label>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <div class="td mov">LIGHT</div>
                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 4 años</li>
                                                                                                <li>Club Resort 4</li>
                                                                                                <li># Acciones 2</li>
                                                                                                <li># Cuotas Maximas  
                                                           <asp:TextBox ID="txtNumCuLigh" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                           <asp:TextBox ID="txtInitialLigh" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                    en 
                                                                        <asp:TextBox ID="txtLgtInitialQuote" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    pagos(s)
                                                                                                   
                                                                                                </li>

                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="montototallig"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">

                                                                                            <asp:Label runat="server" ID="montoiniciallig"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <center> 
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtStd" onchange="veamos()" value="6"></asp:RadioButton>
                                                                                            </center>
                                                                                            <label for="packafiliaSt"></label>

                                                                                        </td>

                                                                                        <td style="width: 125px;">

                                                                                            <div class="td mov">STANDARD</div>
                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 7 años</li>
                                                                                                <li>Club Resort 7</li>
                                                                                                <li># Acciones 3</li>
                                                                                                <li># Cuotas Maximas 
                                                              <asp:TextBox ID="txtNumCuSTA" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialSTA" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                    en 
                                                                        <asp:TextBox ID="txtStainitialQuote" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    pagos(s)
                                                                                                   

                                                                                                </li>

                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="montototalsta"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">
                                                                                            <asp:Label runat="server" ID="montoinicialsta"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="display: none">
                                                                                        <td>
                                                                                            <center> 
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtPlus" onchange="veamos()" value="7"></asp:RadioButton>
                                                                                            </center>
                                                                                            <label for="packafiliaPl"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">

                                                                                            <div class="td mov">PLUS</div>
                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 10 años</li>
                                                                                                <li>Club Resort 10</li>
                                                                                                <li># Acciones 4</li>
                                                                                                <li># Cuotas Maximas 
                                                            <asp:TextBox ID="txtNumCuPLU" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                             <asp:TextBox ID="txtInitialPLU" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    en 
                                                                        <asp:TextBox ID="textPlusQuoteInitial" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    pagos(s)
                                                                                                </li>

                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="montototalplu"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">

                                                                                            <asp:Label runat="server" ID="montoinicialplu"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <center> 
                                                                                            <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtTop" onchange="veamos()" value="8"></asp:RadioButton>
                                                                                            </center>
                                                                                            <label for="packafiliaTp"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">

                                                                                            <div class="td mov">TOP</div>
                                                                                        </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 10 años</li>
                                                                                                <li>Club Resort 10</li>
                                                                                                <li># Acciones 4</li>
                                                                                                <li># Cuotas Maximas 
                                                           <asp:TextBox ID="txtNumCuTOP" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialTOP" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    en 
                                                                        <asp:TextBox ID="txtTopCuotaInicial" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    pagos(s)
                                                                                                </li>

                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="montototaltop"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">

                                                                                            <asp:Label runat="server" ID="montoinicialtop"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="">
                                                                                        <td>
                                                                                            <center> 
                                                                                             <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtVit" value="9"></asp:RadioButton>
                                                                                            </center>
                                                                                            <label for="packafiliaTp"></label>
                                                                                        </td>

                                                                                        <td style="width: 125px;">VITALICIA </td>

                                                                                        <td align="left" style="width: 550px;">
                                                                                            <ul>
                                                                                                <li>Programa Vacacional 10 años</li>
                                                                                                <li>Club Resort vitalicio</li>
                                                                                                <li># Acciones 6</li>
                                                                                                <li># Cuotas Maximas 
                                                           <asp:TextBox ID="txtNumCuVit" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />

                                                                                                </li>
                                                                                                <li>Inicial $
                                                                        <asp:TextBox ID="txtInitialVit" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    en 
                                                                        <asp:TextBox ID="txtVitQuantityInicial" value="1" Style="width: 30px; height: 20px; background-color: #EEEEEE" type="text" runat="server" />
                                                                                                    pagos(s)
                                                                                                </li>

                                                                                            </ul>
                                                                                        </td>
                                                                                        <td style="width: 100px;">

                                                                                            <asp:Label runat="server" ID="montototalVit"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 50px;">

                                                                                            <asp:Label runat="server" ID="montoinicialVit"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div class="accordion" id="accordionExample">
                                                                            <div class="card">
                                                                                <div class="card-header" id="headingOne">
                                                                                    <h5 class="mb-0">
                                                                                        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                                                                            Configuracion Avanzada
                                                                                        </button>
                                                                                    </h5>
                                                                                </div>

                                                                                <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordionExample">
                                                                                    <div class="row">
                                                                                        <div class="col-md-6">
                                                                                            <div class="form-group">
                                                                                                <label>Tipo De Usuario *</label>
                                                                                                <asp:DropDownList ID="ddlTypeAccount" runat="server" class="form-control input-sm" name="tipodoc" required="" aria-required="true">
                                                                                                    <%-- <asp:ListItem Value="" Selected="True">Seleccione...</asp:ListItem>--%>
                                                                                                    <asp:ListItem Value="1">Multi Nivel</asp:ListItem>
                                                                                                    <asp:ListItem Value="2">Directo</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlTypeAccount" runat="server" ErrorMessage="Campo Obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row" style="display: none">
                                                                                        <div class="col-md-6">
                                                                                            <label>Tipo de moneda</label>
                                                                                            <asp:DropDownList ID="ddlTypeCurrency" runat="server" CssClass="form-control input-sm">
                                                                                                <asp:ListItem Value="USD" Text="Dolares" />
                                                                                                <asp:ListItem Value="PEN" Text="Soles" />
                                                                                            </asp:DropDownList>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-md-12">
                                                                                            <div class="row">
                                                                                                <div class="col-sm-12">
                                                                                                    <asp:CheckBox ID="cbConfig" Text="Editar" runat="server" />
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div class="col-sm-6">
                                                                                                    <label>Dia de Pago de las cuotas : a partir de </label>
                                                                                                    <asp:DropDownList ID="ddlDateCuotas" runat="server">
                                                                                                        <asp:ListItem Value="" Text="--Seleccionar--" />
                                                                                                    </asp:DropDownList>
                                                                                                    &nbsp;&nbsp;
                                                                                                <asp:CheckBox ID="IsValidInitial" Text="Valido para Inicial?" runat="server" />
                                                                                                    <div style="display: none;">
                                                                                                        <asp:TextBox ID="DateCbo" Text="text" runat="server" />
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-md-12">
                                                                                            <div class="form-group">
                                                                                                <div class="row">

                                                                                                    <div class="col-sm-4">
                                                                                                        <label>Generar Link</label>
                                                                                                        <input type="button" id="btnGenerarlink" class="btn btn-primary" value="Generar" />
                                                                                                    </div>
                                                                                                    <div class="col-sm-8">
                                                                                                        <!--<label>Codigo Secreto</label>-->
                                                                                                        <div style="display: none">
                                                                                                            <div id="lblGenerarLink" style="color: cornflowerblue;" contenteditable="true"></div>
                                                                                                            <input type="button" onclick="ButonnCopiar('lblGenerarLink')" value="Copiar" />

                                                                                                        </div>
                                                                                                        <div id="lblGenerarLink2" style="color: cornflowerblue;" contenteditable="true"></div>
                                                                                                        <input type="button" onclick="ButonnCopiar('lblGenerarLink2')" value="Copiar" />
                                                                                                        <br />
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <hr />
                                                                                        <div class="col-sm-6">
                                                                                            <label>
                                                                                                Codigo:                                                                                                      
                                                                                                <asp:TextBox name="txtCodSecreto" ID="txtCodSecreto" class="form-control m-b" value="" runat="server" />
                                                                                            </label>
                                                                                            <input type="button" id="btnCodSecreto" class="btn btn-outline-primary" value="VALIDAR" />
                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <!--<label>Codigo Secreto</label>-->
                                                                                            <label id="lblResponseCod" style="color: red;"></label>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="display-none" id="DivFrac">
                                                                                        <div class="row">
                                                                                            <div class="col-lg-12">
                                                                                                <h4>Fraccionar en Cuotas </h4>
                                                                                                <hr />
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="col-lg-12">
                                                                                                <label>
                                                                                                    Valor de Cuota Inicial
                                                                                            <input id="ValueTotal" type="text" name="name" value="" />
                                                                                                </label>
                                                                                                <label>
                                                                                                    en
                                                                                                <input id="NumQuotes" type="text" name="name" value="" />Cuotas</label>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="col-lg-4">
                                                                                                <div class="form-group">
                                                                                                    <label>Cuota N° 1</label>
                                                                                                    <!-- <input type="text" name="name" value="" onkeyup />-->
                                                                                                    <asp:TextBox ID="QuoteFirts" runat="server" CssClass="form-control" placeholder="0.00" Text="0" onkeyup="CalculateQuotes();" />
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-lg-4">
                                                                                                <div class="form-group">
                                                                                                    <label>Cuota N° 2</label>
                                                                                                    <asp:TextBox ID="QuoteSecond" runat="server" CssClass="form-control" placeholder="0.00" Text="0" onkeyup="CalculateQuotes();" />
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-lg-4">
                                                                                                <div class="form-group">
                                                                                                    <label>Cuota N° 3</label>
                                                                                                    <asp:TextBox ID="QuoteThird" runat="server" CssClass="form-control" Text="0.00" placeholder="0.00" />
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="col-lg-4">
                                                                                                <div class="form-group">
                                                                                                    <div class="input-group date" data-provide="datepicker">
                                                                                                        <span class="input-group-addon" style=""><i class="fa fa-calendar-alt" style=""></i></span>
                                                                                                        <asp:TextBox ID="DateFirts" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" MaxLength="10" />
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-lg-4">
                                                                                                <div class="form-group">
                                                                                                    <div class="input-group date" data-provide="datepicker">
                                                                                                        <span class="input-group-addon" style=""><i class="fa fa-calendar-alt" style=""></i></span>
                                                                                                        <asp:TextBox ID="DateSecond" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" />
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-lg-4">
                                                                                                <div class="form-group">
                                                                                                    <div class="input-group date" data-provide="datepicker">
                                                                                                        <span class="input-group-addon" style=""><i class="fa fa-calendar-alt" style=""></i></span>
                                                                                                        <asp:TextBox ID="DateThird" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" />
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="col-lg-12">
                                                                                                <h4>Valor Total de la Membresia</h4>
                                                                                                <hr />
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="col-lg-12">
                                                                                                <label>Total:<asp:TextBox ID="ValueMembresiaUpdate" runat="server" value="0" /></label>
                                                                                            </div>
                                                                                        </div>

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div style="display: none;">
                                                    <asp:RadioButtonList ID="rdrEx" runat="server">
                                                        <asp:ListItem Text="Exonerar" Value="Exonerar"></asp:ListItem>
                                                        <asp:ListItem Text="No Exonerar" Value="NoExonerar"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="ibox-content" style="margin-left: -18px; margin-right: -18px;">
                            <div class="row sombra">
                                <div class="col-md-6">
                                    <br>
                                    <center>
                                             <%--<a href="Register.aspx"></a>--%>
                                                <asp:Button ID="btnRegister" runat="server" style="width: 76%;font-weight: bold;height: 40px;"
                                                    class="btn btn-xl btn-primary m-t-n-xs plomo" Text="REGISTRAR SOCIO" OnClick="btnRegister_Click">
                                            </asp:Button>
                                        </center>
                                </div>
                                <div class="col-md-6">
                                    <br>
                                    <center>
                                            <button  class="btn btn-sm btn-primary m-t-n-xs plomo" 
                                                style="padding: 8px 40px; width: 76%;font-weight: bold;height: 40px;"
                                                onclick="histoy.back();return 0;"><strong>CANCELAR</strong></button>
                                        </center>
                                </div>
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
                            </div>
                        </div>
                    </div>
                </div>
                <div class="footer footer-fondo">
                    <strong>inResorts - 2018</strong>
                </div>
            </div>
        </div>
        <asp:Panel ID="divProgressBar" Style="display: none;" runat="server">
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
        </asp:Panel>
        <script type="text/javascript">

            document.getElementById('cbNada').onchange = function () {
                var ische = document.getElementById('cbNada').checked;
                if (ische) {
                    document.getElementById('rbtExp').checked = false;
                    document.getElementById('rbtLight').checked = false;
                    document.getElementById('rbtStd').checked = false;
                    document.getElementById('rbtPlus').checked = false;
                    document.getElementById('rbtTop').checked = false;
                }
            }


            function modi1() {

                var inputNombre1 = document.getElementById("doce");
                inputNombre1.disabled = false;

                inputNombre1.value = " ";
                inputNombre1.focus();
            }
            function modi2() {

                var inputNombre2 = document.getElementById("vcuatro");
                inputNombre2.disabled = false;

                inputNombre2.value = " ";
                inputNombre2.focus();
            }
            function modi3() {

                var inputNombre3 = document.getElementById("tseis");
                inputNombre3.disabled = false;

                inputNombre3.value = " ";
                inputNombre3.focus();
            }
            function modi4() {

                var inputNombre4 = document.getElementById("cocho");
                inputNombre4.disabled = false;

                inputNombre4.value = " ";
                inputNombre4.focus();
            }
            function modi5() {

                var inputNombre5 = document.getElementById("sesenta");
                inputNombre5.disabled = false;

                inputNombre5.value = " ";
                inputNombre5.focus();
            }


            function veamos() {

                document.getElementById("costokitini").style.display = "block";
                document.getElementById('cbNada').checked = false;
            };
            function salgamos() {

                if (document.getElementById('cbNada').checked) {
                    document.getElementById("costokitini").style.display = "none";
                }
                else {
                    document.getElementById("costokitini").style.display = "block";
                }

            };

            function typechange() {
                if (httpRequest.readyState === 4) {
                    if (httpRequest.status === 200) {
                        var texto = '' + httpRequest.responseText;
                        let array = texto.split('¬');
                        if (array[0] === "true") {
                            veamos();
                        }

                    }
                }
            }
            function api_tipo_cambio() {

                const url = 'https://www.deperu.com/api/rest/cotizaciondolar.json'
                fetch(url)
                    .then(response => response.json())
                    .then(response => {
                        var resp = response.Cotizacion[0].Venta;
                        var compra = response.Cotizacion[0].Compra;

                        var param = "value=" + resp + "&compra=" + compra;
                        Send("TypeChangeController", param, typechange);
                    });
            }
            api_tipo_cambio();


            //Detectamos el cambio de paquete de afiliación
            $('input[name=packafilia]').change(function () {
                packafilia = $(this).val();
                $('.pack_radio').prop('checked', false);
                $("div.pack_id_" + packafilia).find("input[name=subpack]").prop('checked', true);
            });

            //Cargamos las provincias del Ubigeo
            //$('#departamento').change(function () {
            //    $('.loading').show();
            //    pais = $('#pais').val();
            //    cmb = "<option value=''> Seleccione... </option>";
            //    $('#distrito').html(cmb);
            //    params = { csrfsn: csrfsn, pais: pais, depa: $(this).val() }
            //    $.post(base_url + 'ajax/ubigeo/', params, function (data) {
            //        if (data.length > 0) {
            //            for (var i = 0; i < data.length; i++) {
            //                cmb += "<option value='" + data[i].codprov + "'>" + data[i].nombre + "</option>";
            //            }
            //            //llenamos el combo on
            //            $('#provincia').html(cmb);
            //            $('.loading').hide();
            //        } else {
            //            alert('Por el momento no tenemos información para su petición.');
            //            $('.loading').hide();
            //        }
            //    });
            //});

            ////Cargamos los distritos del Ubigeo
            //$('#provincia').change(function () {
            //    $('.loading').show();
            //    pais = $('#pais').val();
            //    depa = $('#departamento').val();
            //    cmb = "<option value=''> Seleccione... </option>";
            //    params = { csrfsn: csrfsn, pais: pais, depa: depa, prov: $(this).val() }
            //    $.post(base_url + 'ajax/ubigeo/', params, function (data) {
            //        if (data.length > 0) {
            //            for (var i = 0; i < data.length; i++) {
            //                cmb += "<option value='" + data[i].codist + "'>" + data[i].nombre + "</option>";
            //            }
            //            //llenamos el combo
            //            $('#distrito').html(cmb);
            //            $('.loading').hide();
            //        } else {
            //            alert('Por el momento no tenemos información para su petición.');
            //            $('.loading').hide();
            //        }
            //    });
            //});
        </script>
        <style>
            #cssbox {
                margin-right: -40px;
                min-width: 249px;
            }

            #btnVal {
                margin: 10px;
            }

            #txtContaExonerar {
                width: 40%;
            }

            @media (min-width: 884px) {
                #cssbox {
                    width: 104% !important;
                }
            }

            @media (min-width:700px) and (max-width: 780px) {
                #cssbox {
                    width: 108% !important;
                }
            }

            @media (min-width:570px) and (max-width: 700px) {
                #cssbox {
                    width: 110% !important;
                }
            }

            @media (min-width:450px) and (max-width: 570px) {
                #cssbox {
                    width: 115% !important;
                }
            }

            @media (max-width: 450px) {
                #cssbox {
                    width: 120%;
                }

                #btnVal {
                    margin: 14px;
                    margin-left: 80px;
                    width: 50%;
                }

                #txtContaExonerar {
                    width: 122%;
                }

                ul {
                    margin-left: 5px;
                    padding-left: 6px;
                }

                .td {
                    text-transform: uppercase;
                    width: 10px;
                    word-wrap: break-word;
                    line-height: 13px;
                }

                .mov {
                    padding-top: 11px;
                    padding-left: 21px;
                }

                .csspqts {
                    width: 107%;
                    margin-left: -9px;
                }
            }
        </style>
        <style>
            @media screen and (min-width: 483px) {
                .cuadro {
                    width: 118% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }

            @media screen and (min-width: 533px) {
                .cuadro {
                    width: 116% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }

            @media screen and (min-width: 576px) {
                .cuadro {
                    width: 114% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }

            @media screen and (min-width: 590px) {
                .cuadro {
                    width: 112% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }

            @media screen and (min-width: 626px) {
                .cuadro {
                    width: 110% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }

            @media screen and (min-width: 768px) {
                .cuadro {
                    width: 100% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }

            @media screen and (min-width: 774px) {
                .cuadro {
                    width: 105% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }

            @media screen and (min-width: 804px) {
                .cuadro {
                    width: 106% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }

            @media screen and (min-width: 818px) {
                .cuadro {
                    width: 107% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }

            @media screen and (min-width: 830px) {
                .cuadro {
                    width: 107% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }

                .botoncitoValidar {
                    margin: 4px auto !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }

            @media screen and (min-width: 995px) {
                .cuadro {
                    width: 105% !important;
                }

                #btnVal {
                    margin: 0px auto 15px !important;
                }
            }
        </style>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

        <script src="registro_files/bootstrap-datepicker.js"></script>
        <script src="Script/ScriptRegister.js"></script>
        <script type="text/javascript">
            var groups = {};
            $("select option[data-category]").each(function () {
                groups[$.trim($(this).attr("data-category"))] = true;
            });
            $.each(groups, function (c) {
                $("select option[data-category='" + c + "']").wrapAll('<optgroup label="' + c + '">');
            });

            document.getElementById('ddlNationality').addEventListener("change", e => {

                let _text = document.getElementById('ddlNationality').options[document.getElementById('ddlNationality').selectedIndex].value;

                document.getElementById('ddlTypeDoc').options[1].text = "Documento de Identidad";

                 if (_text == "Peruano") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Documento Nacional de Identidad";
                }

                if (_text == "Boliviano" || _text == "Chileno" || _text == "Costarricense" || _text == "Ecuatoriano" || _text == "Nicaraguense" || _text == "Uruguayo" || _text == "Venezolano") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Cédula de identidad";
                }

                if (_text == "Brasileno") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Carteira de Identidade o Registro Geral";
                }

                if (_text == "Colombiano") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Cédula de ciudadanía";
                }

                if (_text == "Salvadoreno") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Documento único de identidad";
                }

                if (_text == "Guatemalteco") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Documento personal de identificación";
                }

                if (_text == "Hondureno") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Tarjeta de identidad";
                }

                if (_text == "Mexicano") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Clave única de registro de población";
                }

                if (_text == "Panameno") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Cédula de identidad personal";
                }

                if (_text == "Paraguayo") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Cédula de identidad civil";
                }

                if (_text == "Portugues") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Cartão de Cidadão";
                }

                if (_text == "Dominiques") {
                    document.getElementById('ddlTypeDoc').options[1].text = "Cédula de identidad y electoral";
                }

              
            })

        </script>
    </form>
</body>
</html>
