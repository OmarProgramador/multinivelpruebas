<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadTools.aspx.cs" Inherits="MULTI_NIVEL.Views.UploadTools" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <link href="tienda_files/css.css" rel="stylesheet">
    <link href="tienda_files/bootstrap.css" rel="stylesheet">
    <link href="tienda_files/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <link href="tienda_files/daterangepicker-bs3.css" rel="stylesheet">
    <link href="tienda_files/chosen.css" rel="stylesheet">
    <link href="tienda_files/croppie.css" rel="stylesheet">
    <link href="tienda_files/datepicker3.css" rel="stylesheet">
    <link href="tienda_files/jasny-bootstrap.css" rel="stylesheet">
    <link href="tienda_files/ladda-themeless.css" rel="stylesheet">
    <link href="tienda_files/sweetalert.css" rel="stylesheet">
    <link href="tienda_files/animate.css" rel="stylesheet">
    <link href="tienda_files/style.css" rel="stylesheet">
    <link rel="icon" type="image/png" href="../Resources/Images/novologo.PNG" sizes="196x196">

    <script src="tienda_files/jquery-3.js"></script>
    <script src="tienda_files/bootstrap.js"></script>
    <script src="tienda_files/jquery_005.js"></script>
    <script src="tienda_files/jquery_011.js"></script>
    <script src="tienda_files/inspinia.js"></script>
    <script src="tienda_files/pace.js"></script>
    <script src="tienda_files/jquery_002.js"></script>
    <script src="tienda_files/jquery_006.js"></script>
    <script src="tienda_files/jquery_009.js"></script>
    <script src="tienda_files/Chart.js"></script>
    <script src="tienda_files/jasny-bootstrap.js"></script>
    <script src="tienda_files/jquery_003.js"></script>
    <script src="tienda_files/jquery_007.js"></script>
    <script src="tienda_files/peity-demo.js"></script>
    <script src="tienda_files/datatables.js"></script>
    <script src="tienda_files/chosen.js"></script>
    <script src="tienda_files/croppie.js"></script>
    <script src="tienda_files/sweetalert.js"></script>
    <script src="tienda_files/bootstrap3-typeahead.js"></script>
    <script src="tienda_files/jquery_008.js"></script>
    <script src="tienda_files/bootstrap-datepicker.js"></script>
    <script src="tienda_files/jquery.js"></script>
    <link href="Css/css.css" rel="stylesheet" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/Style.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/styleLoaderOn.css" rel="stylesheet" />
    <script src="Script/Script.js"></script>
    
</head>
<body >
    <form id="form1" runat="server">
        <%--<div id="divProgressBar">
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
        </div>--%>
        <div style="margin: auto; padding: 20px;">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12 text-right">
                        <asp:Button CssClass="btn btn-success" Text="Salir" runat="server" OnClick="Unnamed_Click" />
                    </div>
                </div>
                <div class="container">
                    <h1 style="text-align: center; font-weight: bold; margin: 20px;">Herramientas</h1>
                    <br />
                    <br />
                    <span style="text-align: center; margin: 5px">Subir imagenes o documentos a la seccion herramientas</span>
                    <br />
                    <br />

                    <%--<div class="col-sm-12">
                    <input id="NuevoBeneficiario" type="button" name="name" value="Nuevo Cliente"
                        data-toggle="modal" data-target="#modal1" class="btn btn-primary" />
                </div>--%>
                    <div class="row">
                        <div class="col-sm-3">
                            <img src="img/img.png" style="width: 100px" alt="Alternate Text" />
                            <input id="imagen1" type="button" name="name" value="Subir Imagen"
                                data-toggle="modal" data-target="#modal1" class="btn btn-primary"
                                style="background: white; color: #e8c225; border: 1px solid #f1c40f;" />

                        </div>
                        <div class="col-sm-3">
                            <img src="img/pdf.png" style="width: 110px" alt="Alternate Text" />
                            <input id="imagen2" type="button" name="name" value="Subir Presentaciones"
                                data-toggle="modal" data-target="#modal2" class="btn btn-primary"
                                style="background: white; color: #e74c3c; border: 1px solid #e74c3c;" />

                        </div>
                        <div class="col-sm-3">
                            <img src="img/word.png" style="width: 100px" alt="Alternate Text" />
                            <input id="imagen3" type="button" name="name" value="Subir Documentos"
                                data-toggle="modal" data-target="#modal3" class="btn btn-primary"
                                style="background: white; color: #419ae2; border: 1px solid #90caf9;" />
                        </div>
                        <div class="col-sm-3">
                            <img src="img/video.png" style="width: 100px" alt="Alternate Text" />
                            <input id="imagen4" type="button" name="name" value="Subir Video"
                                data-toggle="modal" data-target="#modal4" class="btn btn-primary"
                                style="background: white; color: #a111dc; border: 1px solid #a111dc;" />
                               
                        </div>
                    </div>
                    <br />
                        <br />
                        <div class="row">
                            <div class="col-sm-12" style="text-align: center">
                                <asp:Label ID="lblinformacion" runat="server" Text="."></asp:Label>
                            </div>
                        </div>
                </div>
            </div>

            <div class="box_border m-b-md" id="prodnom" style="border: 1px solid #0000001c; background-color: #f3f4f9; padding: 15px;">
                <div class="row">
                    <div class="col-md-6 col-sm-6 noproducto" data-id="80">
                        <div class="row">
                            <div class="col-md-12 col-sm-12" data-id="80">
                                <div style="height: 50px; width: 100%; background-color: #36a3f7; color: white; text-align: start; padding: 11px; box-shadow: 2px 0px 7px 2px rgba(69, 65, 78, 0.25);">
                                    <h3><i class="far fa-file-image" style="margin-left: 15px; margin-right: 15px"></i>Imagenes</h3>
                                </div>
                                <div class="ibox-content text-center no-border" style="box-shadow: 2px 3px 7px 2px rgba(69, 65, 78, 0.25);min-height: 205px;">


                                   <%-- <div class="m-b-sm text-center">
                                        <asp:HyperLink runat="server" ID="hplink2" Target="_blank">
                                            <asp:Image runat="server" ID="imgTools" />
                                        </asp:HyperLink>
                                    </div>--%>
                                    <asp:Panel runat="server" ID="panel"></asp:Panel>
                                </div>
                            </div>
                         
                          
                        </div>
                        <br />
                         <%--<asp:Content ID='BodyContent' runat='server' ContentPlaceHolderID='MainContent'>
                                        <video src='windowsmedia.ogg' controls='controls'>
                                            <object id='mediaPlayer' width='320' height='285' 
                                                classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95'
                                                codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701'
                                                standby='Loading Microsoft Windows Media Player components...'
                                                type='application/x-oleobject'>
                                                <param name='fileName' value='windowsmedia.wmv'>
                                                <param name='animationatStart' value='true'>
                                                <param name='transparentatStart' value='true'>
                                                <param name='autoStart' value='true'>
                                                <param name='showControls' value='true'>
                                                <param name='loop' value='true'>
                                            </object>
                                        </video>
                                            </asp:Content>--%>
                        <div class="row">
                               <div class="col-md-12 col-sm-12 noproducto" data-id="80">
                                <div style="height: 50px; width: 100%; background-color: #36a3f7; color: white; text-align: start; padding: 11px; box-shadow: 2px 0px 7px 2px rgba(69, 65, 78, 0.25);">
                                    <h3><i class="far fa-file-video" style="margin-left: 15px; margin-right: 15px"></i>Videos</h3>
                                </div>
                                <div class="ibox-content text-center no-border" style="box-shadow: 2px 3px 7px 2px rgba(69, 65, 78, 0.25);min-height: 205px;">

                                    <div class="m-b-sm text-center">
                                        <%-- <asp:HyperLink runat="server" id="hplink1" Target="_blank">--%>
                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                        <asp:Panel runat="server" ID="paneVideo"></asp:Panel>
                                        <%--  </asp:HyperLink>--%>
                                       
                                    </div>
                                    <%--<video controls="controls"> 
                                        <source src="../Archivos/videos/club resort.mp4" type="video/mp4" />
                                       
                                    </video>--%>
                                     
                                     
                                    <div id="idvideos" style="">

                                    </div>

                                   
                                </div>
                            </div>
                        </div>
                    
               
                    </div>


                    
                
            







                    <div class="col-md-6 col-sm-6 noproducto" data-id="80">
                        <div class="row">
                            <div class="col-md-10 col-sm-10 noproducto" data-id="80">
                                <div style="height: 50px; width: 100%; background-color: #36a3f7; color: white; text-align: start; padding: 11px; box-shadow: 2px 0px 7px 2px rgba(69, 65, 78, 0.25);">
                                    <h3><i class="far fa-file-alt" style="margin-left: 15px; margin-right: 15px"></i>Documentos</h3>
                                </div>
                                <div class="ibox-content text-center no-border" style="box-shadow: 2px 3px 7px 2px rgba(69, 65, 78, 0.25);min-height: 205px;">

                                    <div class="m-b-sm text-center">
                                        <%--<asp:HyperLink runat="server" id="hplink3" Target="_blank">--%>
                                        <asp:Label runat="server" ID="paneW"></asp:Label>
                                        <%--</asp:HyperLink>--%>
                                    </div>

                                </div>
                            </div>
                           <%-- <div class="col-md-2 col-sm-2" data-id="80">
                                
                                <asp:Image runat="server" ID="eliminar2" />
                            </div>--%>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-10 col-sm-10 noproducto" data-id="80">
                                <div style="height: 50px; width: 100%; background-color: #36a3f7; color: white; text-align: start; padding: 11px; box-shadow: 2px 0px 7px 2px rgba(69, 65, 78, 0.25);">
                                    <h3><i class="far fa-file-video" style="margin-left: 15px; margin-right: 15px"></i>Presentaciones</h3>
                                </div>
                                <div class="ibox-content text-center no-border" style="box-shadow: 2px 3px 7px 2px rgba(69, 65, 78, 0.25);min-height: 205px;">

                                    <div class="m-b-sm text-center">
                                        <%-- <asp:HyperLink runat="server" id="hplink1" Target="_blank">--%>

                                        <asp:Label runat="server" ID="panePdf"></asp:Label>
                                        <%--  </asp:HyperLink>--%>
                                    </div>
                                </div>
                            </div>
                           <%-- <div class="col-md-2 col-sm-2" data-id="80">
                                
                                 <asp:Image runat="server" ID="eliminar3" />
                            </div>--%>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    
                </div>
            </div>

        </div>


        <div id="modal1" class="modal" style="display: none; padding-right: 17px;">
            <div class="modal-content">
                <span class="close" data-dismiss="modal">×</span>

                <div class="modal-header">
                    <img src="img/novologo.png" alt="Alternate Text" width="100">
                </div>

                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Subir Imagen</label>
                                <asp:FileUpload ID="FlpArchivo1" runat="server" />
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                            </div>
                        </div>

                    </div>
                </div>
                <center>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Subir"  class="btn"  />
                        <button type="button" class="btn" data-dismiss="modal" > Cerrar</button> 
                        </center>

                <%--<center>                                       
                                       
                        <input id="btnPutTrave" type="button" name="name" value="Aceptar" class="btn btn-primary" onclick="btnPutTravel();"/>
                        <button type="button" class="btn" data-dismiss="modal"> Cancelar</button> 
                    </center>--%>
            </div>
        </div>

        <div id="modal2" class="modal" style="display: none; padding-right: 17px;">
            <div class="modal-content">
                <span class="close" data-dismiss="modal">×</span>

                <div class="modal-header">
                    <img src="img/novologo.png" alt="Alternate Text" width="100">
                </div>

                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Subir Documento</label>
                                <asp:FileUpload ID="FlpArchivo2" runat="server" />
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                            </div>
                        </div>

                    </div>
                </div>
                <center>
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Subir"  class="btn"/>
                        <button type="button" class="btn" data-dismiss="modal" > Cerrar</button> 
                        </center>

                <%--<center>                                       
                                       
                        <input id="btnPutTrave" type="button" name="name" value="Aceptar" class="btn btn-primary" onclick="btnPutTravel();"/>
                        <button type="button" class="btn" data-dismiss="modal"> Cancelar</button> 
                    </center>--%>
            </div>
        </div>

        <div id="modal3" class="modal" style="display: none; padding-right: 17px;">
            <div class="modal-content">
                <span class="close" data-dismiss="modal">×</span>

                <div class="modal-header">
                    <img src="img/novologo.png" alt="Alternate Text" width="100">
                </div>

                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Subir Documento</label>
                                <asp:FileUpload ID="FlpArchivo3" runat="server" />
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                            </div>
                        </div>

                    </div>
                </div>
                <center>
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Subir"  class="btn"/>
                        <button type="button" class="btn" data-dismiss="modal" > Cerrar</button> 
                        </center>

                <%--<center>                                       
                                       
                        <input id="btnPutTrave" type="button" name="name" value="Aceptar" class="btn btn-primary" onclick="btnPutTravel();"/>
                        <button type="button" class="btn" data-dismiss="modal"> Cancelar</button> 
                    </center>--%>
            </div>
        </div>

        <div id="modal4" class="modal" style="display: none; padding-right: 17px;">
            <div class="modal-content">
                <span class="close" data-dismiss="modal">×</span>

                <div class="modal-header">
                    <img src="img/novologo.png" alt="Alternate Text" width="100">
                </div>

                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Subir Video</label>
                                <asp:FileUpload ID="FlpArchivo4" runat="server" />
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                            </div>
                        </div>

                    </div>
                </div>
                <center>
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Subir"  class="btn"  />
                        <button type="button" class="btn" data-dismiss="modal" > Cerrar</button> 
                        </center>

                <%--<center>                                       
                                       
                        <input id="btnPutTrave" type="button" name="name" value="Aceptar" class="btn btn-primary" onclick="btnPutTravel();"/>
                        <button type="button" class="btn" data-dismiss="modal"> Cancelar</button> 
                    </center>--%>
            </div>
        </div>
    </form>

    <style>
        @media(max-width: 600px){
            #cssbox{
                width:125%;
            }

            #btnVal{
                margin: 14px;
                margin-left:80px;
                width: 50%;
            }

            #txtContaExonerar{
                width:122%;
            }

            .ul{
                margin-left:5px;
                padding-left:6px;
            }

            .td{
                text-transform:uppercase;
                width:10px;
                word-wrap:break-word;
                line-height:13px;
            }

            .mov{
                padding-top: 11px;
                padding-left: 21px;
            }

            #iboxcon{
                width:113%;
            }

            .myBtnc{
                font-size:15px !important;
            }
        }

        .modal{
            display:none;
            position:fixed;
            z-index: 1;
            padding-top:130px;
            left:0;
            top:0;
            width:100%;
            height: 100%;
            overflow: auto;
            background-color: rgb(0,0,0);
            background-color: rgba(0,0,0,0.4);
        }

        .modal-content{
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 70%;
            border-radius: 8px;
            font-family: sand-serif;
            box-shadow: 4px 4px 25px black;
        }

        .ps{
            text-align: center;
            margin: 25px;
            font-size: 24px;
            color: #337ab7;
        }
        
    </style>


    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    <script src="Script/UploadTools.js"></script>
</body>
</html>
