<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayQuoteWallet.aspx.cs" Inherits="MULTI_NIVEL.Views.PayQuoteWallet" %>

<!DOCTYPE html>

<html
xmlns="http://www.w3.org/1999/xhtml"
xmlns:fb="//www.facebook.com/2008/fbml"
xmlns:og="http://ogp.me/ns#"
xmlns:v="urn:schemas-microsoft-com:vml">
<head id="ctl00_Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Pago de Cuotas - inResorts</title>
    <meta name="description" content="Todos los días increíbles descuentos hasta del 90% en ocio, restaurantes, belleza, salud, viajes, escapadas, conciertos, bares y mucho más.">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" href="" type="image/x-icon">
    <link href="./Proceso de Pago - Cuponidad_files/styles_menu.css" type="text/css" rel="stylesheet">
    <link href="./Proceso de Pago - Cuponidad_files/masterBootStyle.css" type="text/css" rel="stylesheet">
    <link href="./Proceso de Pago - Cuponidad_files/bootstrap.min.css" type="text/css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="./Proceso de Pago - Cuponidad_files/jquery-ui-1.10.3.custom.css">
    <link rel="stylesheet" href="./Proceso de Pago - Cuponidad_files/vainilla-js-carousel.css">
    <link rel="stylesheet" href="./Proceso de Pago - Cuponidad_files/stylesmenumobile.css">
    <link rel="stylesheet" href="./Proceso de Pago - Cuponidad_files/styleshome.css">
    <script src="./Proceso de Pago - Cuponidad_files/316153748717666" async=""></script>
    <script id="facebook-jssdk" src="./Proceso de Pago - Cuponidad_files/sdk.js.download"></script>
    <script async="" src="./Proceso de Pago - Cuponidad_files/fbevents.js.download"></script>
    <script async="" src="./Proceso de Pago - Cuponidad_files/analytics.js.download"></script>
    <script src="./Proceso de Pago - Cuponidad_files/jquery-1.10.2.min.js.download" type="text/javascript"></script>
    <script src="./Proceso de Pago - Cuponidad_files/jquery-ui-1.10.3.custom.min.js.download" type="text/javascript"></script>
    <script type="text/javascript" src="./Proceso de Pago - Cuponidad_files/frontpage.js.download"></script>
    <script src="./Proceso de Pago - Cuponidad_files/bootstrap.min.js.download" type="text/javascript"></script>
    <script src="./Proceso de Pago - Cuponidad_files/script_menu.js.download" type="text/javascript"></script>
    <link href="./Proceso de Pago - Cuponidad_files/CssProcesoCompra.css" rel="stylesheet" type="text/css">
    <link href="./Proceso de Pago - Cuponidad_files/jquery-confirm.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="./Proceso de Pago - Cuponidad_files/jquery-confirm.js.download"></script>
    <script src="./Proceso de Pago - Cuponidad_files/ProcesoCompra.js.download" type="text/javascript"></script>


    <script src="./Proceso de Pago - Cuponidad_files/ProcesoCompraCulqui.js.download" type="text/javascript"></script>



    <script src="./Proceso de Pago - Cuponidad_files/OneSignalSDKUpdaterWorker.js.download" type="text/javascript"></script>
    <script src="./Proceso de Pago - Cuponidad_files/OneSignalSDKWorker.js.download" type="text/javascript"></script>
    <script src="./Proceso de Pago - Cuponidad_files/f.txt"></script>
    <style type="text/css">
        .fb_hidden {
            position: absolute;
            top: -10000px;
            z-index: 10001
        }

        .fb_reposition {
            overflow: hidden;
            position: relative
        }

        .fb_invisible {
            display: none
        }

        .fb_reset {
            background: none;
            border: 0;
            border-spacing: 0;
            color: #000;
            cursor: auto;
            direction: ltr;
            font-family: "lucida grande", tahoma, verdana, arial, sans-serif;
            font-size: 11px;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            letter-spacing: normal;
            line-height: 1;
            margin: 0;
            overflow: visible;
            padding: 0;
            text-align: left;
            text-decoration: none;
            text-indent: 0;
            text-shadow: none;
            text-transform: none;
            visibility: visible;
            white-space: normal;
            word-spacing: normal
        }

            .fb_reset > div {
                overflow: hidden
            }

        @keyframes fb_transform {
            from {
                opacity: 0;
                transform: scale(.95)
            }

            to {
                opacity: 1;
                transform: scale(1)
            }
        }

        .fb_animate {
            animation: fb_transform .3s forwards
        }

        .fb_dialog {
            background: rgba(82, 82, 82, .7);
            position: absolute;
            top: -10000px;
            z-index: 10001
        }

        .fb_dialog_advanced {
            border-radius: 8px;
            padding: 10px
        }

        .fb_dialog_content {
            background: #fff;
            color: #373737
        }

        .fb_dialog_close_icon {
            background: url(https://static.xx.fbcdn.net/rsrc.php/v3/yq/r/IE9JII6Z1Ys.png) no-repeat scroll 0 0 transparent;
            cursor: pointer;
            display: block;
            height: 15px;
            position: absolute;
            right: 18px;
            top: 17px;
            width: 15px
        }

        .fb_dialog_mobile .fb_dialog_close_icon {
            left: 5px;
            right: auto;
            top: 5px
        }

        .fb_dialog_padding {
            background-color: transparent;
            position: absolute;
            width: 1px;
            z-index: -1
        }

        .fb_dialog_close_icon:hover {
            background: url(https://static.xx.fbcdn.net/rsrc.php/v3/yq/r/IE9JII6Z1Ys.png) no-repeat scroll 0 -15px transparent
        }

        .fb_dialog_close_icon:active {
            background: url(https://static.xx.fbcdn.net/rsrc.php/v3/yq/r/IE9JII6Z1Ys.png) no-repeat scroll 0 -30px transparent
        }

        .fb_dialog_iframe {
            line-height: 0
        }

        .fb_dialog_content .dialog_title {
            background: #6d84b4;
            border: 1px solid #365899;
            color: #fff;
            font-size: 14px;
            font-weight: bold;
            margin: 0
        }

            .fb_dialog_content .dialog_title > span {
                background: url(https://static.xx.fbcdn.net/rsrc.php/v3/yd/r/Cou7n-nqK52.gif) no-repeat 5px 50%;
                float: left;
                padding: 5px 0 7px 26px
            }

        body.fb_hidden {
            height: 100%;
            left: 0;
            margin: 0;
            overflow: visible;
            position: absolute;
            top: -10000px;
            transform: none;
            width: 100%
        }

        .fb_dialog.fb_dialog_mobile.loading {
            background: url(https://static.xx.fbcdn.net/rsrc.php/v3/ya/r/3rhSv5V8j3o.gif) white no-repeat 50% 50%;
            min-height: 100%;
            min-width: 100%;
            overflow: hidden;
            position: absolute;
            top: 0;
            z-index: 10001
        }

            .fb_dialog.fb_dialog_mobile.loading.centered {
                background: none;
                height: auto;
                min-height: initial;
                min-width: initial;
                width: auto
            }

                .fb_dialog.fb_dialog_mobile.loading.centered #fb_dialog_loader_spinner {
                    width: 100%
                }

                .fb_dialog.fb_dialog_mobile.loading.centered .fb_dialog_content {
                    background: none
                }

        .loading.centered #fb_dialog_loader_close {
            clear: both;
            color: #fff;
            display: block;
            font-size: 18px;
            padding-top: 20px
        }

        #fb-root #fb_dialog_ipad_overlay {
            background: rgba(0, 0, 0, .4);
            bottom: 0;
            left: 0;
            min-height: 100%;
            position: absolute;
            right: 0;
            top: 0;
            width: 100%;
            z-index: 10000
        }

            #fb-root #fb_dialog_ipad_overlay.hidden {
                display: none
            }

        .fb_dialog.fb_dialog_mobile.loading iframe {
            visibility: hidden
        }

        .fb_dialog_mobile .fb_dialog_iframe {
            position: sticky;
            top: 0
        }

        .fb_dialog_content .dialog_header {
            background: linear-gradient(from(#738aba), to(#2c4987));
            border-bottom: 1px solid;
            border-color: #1d3c78;
            box-shadow: white 0 1px 1px -1px inset;
            color: #fff;
            font: bold 14px Helvetica, sans-serif;
            text-overflow: ellipsis;
            text-shadow: rgba(0, 30, 84, .296875) 0 -1px 0;
            vertical-align: middle;
            white-space: nowrap
        }

            .fb_dialog_content .dialog_header table {
                height: 43px;
                width: 100%
            }

            .fb_dialog_content .dialog_header td.header_left {
                font-size: 12px;
                padding-left: 5px;
                vertical-align: middle;
                width: 60px
            }

            .fb_dialog_content .dialog_header td.header_right {
                font-size: 12px;
                padding-right: 5px;
                vertical-align: middle;
                width: 60px
            }

        .fb_dialog_content .touchable_button {
            background: linear-gradient(from(#4267B2), to(#2a4887));
            background-clip: padding-box;
            border: 1px solid #29487d;
            border-radius: 3px;
            display: inline-block;
            line-height: 18px;
            margin-top: 3px;
            max-width: 85px;
            padding: 4px 12px;
            position: relative
        }

        .fb_dialog_content .dialog_header .touchable_button input {
            background: none;
            border: none;
            color: #fff;
            font: bold 12px Helvetica, sans-serif;
            margin: 2px -12px;
            padding: 2px 6px 3px 6px;
            text-shadow: rgba(0, 30, 84, .296875) 0 -1px 0
        }

        .fb_dialog_content .dialog_header .header_center {
            color: #fff;
            font-size: 16px;
            font-weight: bold;
            line-height: 18px;
            text-align: center;
            vertical-align: middle
        }

        .fb_dialog_content .dialog_content {
            background: url(https://static.xx.fbcdn.net/rsrc.php/v3/y9/r/jKEcVPZFk-2.gif) no-repeat 50% 50%;
            border: 1px solid #4a4a4a;
            border-bottom: 0;
            border-top: 0;
            height: 150px
        }

        .fb_dialog_content .dialog_footer {
            background: #f5f6f7;
            border: 1px solid #4a4a4a;
            border-top-color: #ccc;
            height: 40px
        }

        #fb_dialog_loader_close {
            float: left
        }

        .fb_dialog.fb_dialog_mobile .fb_dialog_close_button {
            text-shadow: rgba(0, 30, 84, .296875) 0 -1px 0
        }

        .fb_dialog.fb_dialog_mobile .fb_dialog_close_icon {
            visibility: hidden
        }

        #fb_dialog_loader_spinner {
            animation: rotateSpinner 1.2s linear infinite;
            background-color: transparent;
            background-image: url(https://static.xx.fbcdn.net/rsrc.php/v3/yD/r/t-wz8gw1xG1.png);
            background-position: 50% 50%;
            background-repeat: no-repeat;
            height: 24px;
            width: 24px
        }

        @keyframes rotateSpinner {
            0% {
                transform: rotate(0deg)
            }

            100% {
                transform: rotate(360deg)
            }
        }

        .fb_iframe_widget {
            display: inline-block;
            position: relative
        }

            .fb_iframe_widget span {
                display: inline-block;
                position: relative;
                text-align: justify
            }

            .fb_iframe_widget iframe {
                position: absolute
            }

        .fb_iframe_widget_fluid_desktop, .fb_iframe_widget_fluid_desktop span, .fb_iframe_widget_fluid_desktop iframe {
            max-width: 100%
        }

            .fb_iframe_widget_fluid_desktop iframe {
                min-width: 220px;
                position: relative
            }

        .fb_iframe_widget_lift {
            z-index: 1
        }

        .fb_iframe_widget_fluid {
            display: inline
        }

            .fb_iframe_widget_fluid span {
                width: 100%
            }

        .fb_customer_chat_bounce_in_v2 {
            animation-duration: 300ms;
            animation-name: fb_bounce_in_v2;
            transition-timing-function: ease-in
        }

        .fb_customer_chat_bounce_out_v2 {
            animation-duration: 300ms;
            animation-name: fb_bounce_out_v2;
            transition-timing-function: ease-in
        }

        .fb_customer_chat_bounce_in_v2_mobile_chat_started {
            animation-duration: 300ms;
            animation-name: fb_bounce_in_v2_mobile_chat_started;
            transition-timing-function: ease-in
        }

        .fb_customer_chat_bounce_out_v2_mobile_chat_started {
            animation-duration: 300ms;
            animation-name: fb_bounce_out_v2_mobile_chat_started;
            transition-timing-function: ease-in
        }

        .fb_customer_chat_bubble_pop_in {
            animation-duration: 250ms;
            animation-name: fb_customer_chat_bubble_bounce_in_animation
        }

        .fb_customer_chat_bubble_animated_no_badge {
            box-shadow: 0 3px 12px rgba(0, 0, 0, .15);
            transition: box-shadow 150ms linear
        }

            .fb_customer_chat_bubble_animated_no_badge:hover {
                box-shadow: 0 5px 24px rgba(0, 0, 0, .3)
            }

        .fb_customer_chat_bubble_animated_with_badge {
            box-shadow: -5px 4px 14px rgba(0, 0, 0, .15);
            transition: box-shadow 150ms linear
        }

            .fb_customer_chat_bubble_animated_with_badge:hover {
                box-shadow: -5px 8px 24px rgba(0, 0, 0, .2)
            }

        .fb_invisible_flow {
            display: inherit;
            height: 0;
            overflow-x: hidden;
            width: 0
        }

        .fb_mobile_overlay_active {
            background-color: #fff;
            height: 100%;
            overflow: hidden;
            position: fixed;
            visibility: hidden;
            width: 100%
        }

        @keyframes fb_bounce_in_v2 {
            0% {
                opacity: 0;
                transform: scale(0, 0);
                transform-origin: bottom right
            }

            50% {
                transform: scale(1.03, 1.03);
                transform-origin: bottom right
            }

            100% {
                opacity: 1;
                transform: scale(1, 1);
                transform-origin: bottom right
            }
        }

        @keyframes fb_bounce_in_v2_mobile_chat_started {
            0% {
                opacity: 0;
                top: 20px
            }

            100% {
                opacity: 1;
                top: 0
            }
        }

        @keyframes fb_bounce_out_v2 {
            0% {
                opacity: 1;
                transform: scale(1, 1);
                transform-origin: bottom right
            }

            100% {
                opacity: 0;
                transform: scale(0, 0);
                transform-origin: bottom right
            }
        }

        @keyframes fb_bounce_out_v2_mobile_chat_started {
            0% {
                opacity: 1;
                top: 0
            }

            100% {
                opacity: 0;
                top: 20px
            }
        }

        @keyframes fb_customer_chat_bubble_bounce_in_animation {
            0% {
                bottom: 6pt;
                opacity: 0;
                transform: scale(0, 0);
                transform-origin: center
            }

            70% {
                bottom: 18pt;
                opacity: 1;
                transform: scale(1.2, 1.2)
            }

            100% {
                transform: scale(1, 1)
            }
        }
    </style>
    <style>
        input[type=radio] {
            /* Double-sized Checkboxes */
            -ms-transform: scale(1.3); /* IE */
            -moz-transform: scale(1.3); /* FF */
            -webkit-transform: scale(1.3); /* Safari and Chrome */
            -o-transform: scale(1.3); /* Opera */
            padding: 6px;
        }
    </style>
    <link rel="stylesheet" href="./Proceso de Pago - Cuponidad_files/OneSignalSDKStyles.css">
    <script type="text/javascript" charset="UTF-8" src="./Proceso de Pago - Cuponidad_files/common.js.download"></script>
    <script type="text/javascript" charset="UTF-8" src="./Proceso de Pago - Cuponidad_files/util.js.download"></script>
    <script type="text/javascript" charset="UTF-8" src="./Proceso de Pago - Cuponidad_files/stats.js.download"></script>
    <script type="text/javascript" charset="UTF-8" src="./Proceso de Pago - Cuponidad_files/AuthenticationService.Authenticate"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript">  
        $(function () {
            $(".btn").click(function () {
                $(this).button('loading').delay(5000).queue(function () {
                    $(this).button('reset');
                    $(this).dequeue();
                });
            });
        });
    </script>
</head>
<body id="ctl00_body" style="">
    <script type="text/javascript" src="./Proceso de Pago - Cuponidad_files/republica_init.js.download"></script>
    <div id="fb-root" class=" fb_reset">
        <div style="position: absolute; top: -10000px; height: 0px; width: 0px;">
            <div>
                <iframe name="fb_xdm_frame_https" frameborder="0" allowtransparency="true" allowfullscreen="true" scrolling="no" allow="encrypted-media" id="fb_xdm_frame_https" aria-hidden="true" title="Facebook Cross Domain Communication Frame" tabindex="-1" src="./Proceso de Pago - Cuponidad_files/trnHszv6jVd.html" style="border: none;"></iframe>
            </div>
        </div>
        <div style="position: absolute; top: -10000px; height: 0px; width: 0px;">
            <div></div>
        </div>
    </div>

    <script type="text/javascript" src="./Proceso de Pago - Cuponidad_files/js">
    </script>

    <div>
        <input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="">
        <input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="">
        <input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="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bGFjZUhvbGRlcjEkcmJWaXNhBSBjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiVmlzYQUeY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRyYk1DBR5jdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiTUMFImN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJEaW5lcnMFImN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJEaW5lcnMFIGN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJBbWV4BSBjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiQW1leAUmY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRyYlNhZmV0eVBheUUFJmN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJTYWZldHlQYXlFBSZjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiU2FmZXR5UGF5VAUmY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRyYlNhZmV0eVBheVQFJGN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJQYWdvRWZlYwUkY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRyYlBhZ29FZmVjBSVjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiUGFnb0VmZWNUBSVjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiUGFnb0VmZWNUBQ5jdGwwMCRMb2dpbkJUTgUVY3RsMDAkYnRuU3VzY3JpYmlybWUyBRRjdGwwMCRidG5TdXNjcmliaXJtZQUhY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRsdkxpc3RhDzwrAAoCBxQrAAFkCAIBZEGxpK0ewqk3qz8dfEbZNtKw4QLU">
    </div>


    <script src="./Proceso de Pago - Cuponidad_files/WebResource.axd" type="text/javascript"></script>


    <script src="./Proceso de Pago - Cuponidad_files/ScriptResource.axd" type="text/javascript"></script>
    <script src="./Proceso de Pago - Cuponidad_files/ScriptResource(1).axd" type="text/javascript"></script>
    <script src="./Proceso de Pago - Cuponidad_files/WebResource(1).axd" type="text/javascript"></script>
    <div>

        <input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="CBE15827">
        <input type="hidden" name="__EVENTVALIDATION" id="__EVENTVALIDATION" value="/wEWKQKEsdHtAwL9xPPmDAKj/fbNDgLQwK7BBwLi1qX+CQKX2r63DQKq1Z+JAwK84KyGDAL5x+uOBwLd8ZnVCwLc8ZnVCwLf8ZnVCwLe8ZnVCwLb8ZnVCwLK8ZnVCwLZ8ZnVCwLY8ZnVCwKkkfrRBgKh9pGpCwLQqPCDAgKCpfS0BAKXga3vBQKZgfnuBQKrnLGqAQKez53pDAK1qtqTBALItqSrCgKK2P7pDwLqrZ+rBwKpyL28DwL1l6HUBQLS6M3OBQL+kaqNDQK2to/5BgLmzcCnAQK+5OOuAgKDqdi4AQKc6uHWAgKX1+a8DgLCwcCtCQLPjrTuDSwsVzKkBFLvBuo8RX8RwlT0Jrl0">
    </div>





    <!-- Incluyendo .js de Culqi Checkout-->
    <script src="./Proceso de Pago - Cuponidad_files/v2"></script>
    <!-- Seteando valores de config-->
    <script type="text/javascript">
        //<![CDATA[
        Sys.WebForms.PageRequestManager._initialize('ctl00$ContentPlaceHolder1$ScriptManager1', document.getElementById('aspnetForm'));
        Sys.WebForms.PageRequestManager.getInstance()._updateControls(['tctl00$ContentPlaceHolder1$upnlUbigeo'], [], ['ctl00$ContentPlaceHolder1$btnPagarProcesar'], 90);
//]]>
    </script>


    <div id="wrapper">
        <center>
                    <div style="width:300px">
                        <a href="Index.aspx" class="navbar-brand inicio-logo" style="float:none">
                            <img src="img/novologo.png" class="" width="300">
                        </a>
                    </div>
                    
                </center>
        <div id="page-wrapper" class="gray-bg">
            <div id="ctl00_ContentPlaceHolder1_upnlUbigeo">

                <div id="contenedor" style="margin-top: 1px !important">
                    <div class="box_center">
                        <div class="comprar_contenido">
                            <form id="form1" runat="server">
                                <div class="box_proceso_compra" style="border-radius: 27px; box-shadow: 9px 8px 15px 0px black;">
                                    <div class="box_mediospago_lista">
                                        <div class="box_mediospago_lista_titulo" style="text-decoration-color: chartreuse">
                                            <span style="color: #2981c5">LISTA DE MEDIOS DE PAGO : seleccione un medio de pago y luego clic en boton "Pagar"</span>
                                        </div>
                                        <div class="box_mediospago_lista_titulo anchura" style="text-decoration-color: chartreuseM; width: 95%;">
                                            <div id="ctl00_ContentPlaceHolder1_DivMPSafetyPayT" class="box_mediospago_lista_item2 holi" style="font-size: 16px; width: 98%; color: black; font-weight: 100">
                                                <div class="box_mpli_check">
                                                    <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtWallet" value="1" Style="margin-left: 8px;"></asp:RadioButton>
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
                                        <div onclick="selectRBMP(&#39;ctl00_ContentPlaceHolder1_rbVisa&#39;);">
                                            <div id="ctl00_ContentPlaceHolder1_DivMPVisa " class="box_mediospago_lista_item holi">
                                                <div class="box_mpli_check">
                                                    <!--<input id="ctl00_ContentPlaceHolder1_rbVisa" type="radio" name="ctl00$ContentPlaceHolder1$gpcheck" value="1"> -->
                                                    <asp:RadioButton runat="server" GroupName="packafilia" ID="rdrCulqi" value="2"></asp:RadioButton>
                                                </div>
                                                <div class="box_mpli_img">
                                                    <img src="./Proceso de Pago - Cuponidad_files/logo_visa.png" id="ctl00_ContentPlaceHolder1_imgMPVisa" border="0">
                                                    <img src="./Proceso de Pago - Cuponidad_files/mastercardpayu2.png" id="ctl00_ContentPlaceHolder1_imgMPMC" border="0">
                                                    <img src="./Proceso de Pago - Cuponidad_files/dinersclubpayu2.png" border="0">
                                                    <img s src="./Proceso de Pago - Cuponidad_files/americanexpresspayu2.png" border="0">
                                                </div>
                                                <div class="box_mpli_texto">
                                                    <p>Tarjetas Visa</p>
                                                    <span>Paga con Tarjetas de Crédito o Débito</span>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <p>Tarjetas Master Card</p>
                                                    <span>Paga con Tarjetas de Crédito o Débito</span>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <p>Tarjetas Diners Club</p>
                                                    <span>Paga con Tarjetas de Crédito o Débito</span>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <p>Tarjetas American Express</p>
                                                    <span>Paga con Tarjetas de Crédito o Débito</span>
                                                </div>
                                            </div>
                                        </div>
                                        <style>
                                            @media only screen and (max-width: 1075px) {
                                                .anchura {
                                                    width: 410px !important;
                                                }
                                            }

                                            @media only screen and (max-width: 436px) {
                                                .anchura {
                                                    width: 100% !important;
                                                }
                                            }
                                        </style>
                                        <div onclick="selectRBMP(&#39;ctl00_ContentPlaceHolder1_rbVisa&#39;);">

                                            <div id="ctl00_ContentPlaceHolder1_DivMPVisa" class="box_mediospago_lista_item">

                                                <div id="ctl00_ContentPlaceHolder1_DivMPSafetyPayE" class="box_mediospago_lista_item2">
                                                    <div class="box_mpli_check">
                                                        <!--<input id="ctl00_ContentPlaceHolder1_rbSafetyPayE" type="radio" name="ctl00$ContentPlaceHolder1$gpcheck" value="7">-->
                                                        <asp:RadioButton runat="server" GroupName="packafilia" ID="rdrTransfer" value="3"></asp:RadioButton>
                                                    </div>
                                                    <div class="box_mpli_img3" style="width: 70px; height: 70px; display: flex">
                                                        <img src="img/bcpagente123.jpg" border="0" style="width: 80px;">

                                                        <ul>
                                                            <li style="width: 145px; text-decoration: none; list-style: none; font-size: 15px; padding-top: 20px"><b>Pago en Efectivo</b></li>
                                                            <li style="width: 145px; text-decoration: none; list-style: none">Oficinas y Agentes </li>
                                                        </ul>

                                                    </div>
                                                </div>
                                                <div id="ctl00_ContentPlaceHolder1_DivMPSafetyPayT" class="box_mediospago_lista_item2">
                                                    <div class="box_mpli_check">
                                                        <!--<input id="ctl00_ContentPlaceHolder1_rbSafetyPayT" type="radio" name="ctl00$ContentPlaceHolder1$gpcheck" value="8">-->
                                                        <asp:RadioButton runat="server" GroupName="packafilia" ID="rdrTransfer2" value="4"></asp:RadioButton>
                                                    </div>
                                                    <div class="box_mpli_img3" style="width: 70px; height: 70px; display: flex">

                                                        <img src="img/bcp123.png" border="0" style="width: 80px">
                                                    </div>
                                                    <ul>
                                                        <li style="font-size: 15px; padding-top: 20px"><b>Banca por Internet</b></li>
                                                        <li style="list-style: none"></li>
                                                    </ul>

                                                </div>
                                                <div id="ctl00_ContentPlaceHolder1_DivMPSafetyPayT" class="box_mediospago_lista_item2">
                                                    <div class="box_mpli_check">
                                                        <!--<input id="ctl00_ContentPlaceHolder1_rbSafetyPayT" type="radio" name="ctl00$ContentPlaceHolder1$gpcheck" value="8">-->
                                                        <asp:RadioButton runat="server" GroupName="packafilia" ID="rdrStor" value="5"></asp:RadioButton>
                                                    </div>
                                                    <div class="box_mpli_img3" style="width: 40px; height: 90px; display: flex">

                                                        <img src="img/logosf2.png" border="0" style="width: 100px">
                                                    </div>
                                                    <center>    
                                                       <ul>
                                                            <li style="font-size:15px;list-style:none;padding-top:20px;padding-left:64px"><b>Pago en Oficina o Club</b></li>
                                                            <li style="list-style:none;padding-left:64px">Tarjeta y/o Efectivo </li>
                                                        </ul>
                                                    </center>
                                                </div>

                                            </div>
                                        </div>

                                    </div>


                                    <div class="box_mediospago_bloquepago">
                                        <h3>Descuento por codigo</h3>
                                        <p>
                                            <span id="ctl00_ContentPlaceHolder1_lblTotal">
                                                <asp:Label ID="lblDiscount" runat="server" Text="S/ 0.00"></asp:Label>
                                        </p>
                                        <div class="box_mediospagob_titulo" style="padding: 4px 0 0 0;">
                                            Total a Pagar
                                        </div>
                                        <div class="box_mediospagob_valor">


                                            <asp:Label ID="lblCostQuote" runat="server"></asp:Label>
                                            &nbsp;
                            <asp:Label ID="ccc" Text="PEN" runat="server" />
                                        </div>

                                        <div class="box_mediospagob_valor_antes">
                                            <span id="ctl00_ContentPlaceHolder1_lblTotalAPagarAntes"></span>
                                        </div>
                                        <div class="box_mediospagob_comprar text-center" id="box_mediospagob_comprar">

                                            <asp:Button ID="btnContinue" data-loading-text=" Procesando Orden" runat="server" class="btn btn-primary" Text="Continuar" OnClick="btnContinue_Click" value="Continuar"></asp:Button>


                                        </div>
                                    </div>
                                    <div class="box_mediospago_bloquepago">
                                        <div class="box_mediospagob_titulo">
                                            Cambio En Soles
                                        </div>
                                        <div class="exchange">
                                            <!--<span id="ctl00_ContentPlaceHolder1_lblTotalAPagar">S/ 28.90</span>-->
                                            <asp:Label ID="lblExchange" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                        </div>

                        <div class="box_proceso_compra" style="margin-top: 30px; margin-bottom: 30px;">
                            <div class="box_detalle_cab">
                                <div class="bdc_texto_carrito">Detalle de tu Pago </div>
                            </div>
                            <!-- Lista de Oferta -->



                            <div class="box_detalle_oferta">
                                <div class="bd_imagen_oferta">
                                    <img src="img/novologo.png" alt=" ">
                                </div>
                                <div class="bd_texto_oferta">
                                    <!--<div class="bdto_comercio">Cineplanet</div> -->
                                    <!-- <div class="bdto_opcion">Sedes Lima: 2 entradas generales 2D + combo.</div>-->
                                    <br />
                                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDescriptionConsu" runat="server"></asp:Label>
                                </div>
                                <div class="box_detalle_pie">
                                    <div class="boxdp_precio">
                                        <div class="boxdpp_texto">Precio Unitario </div>
                                        <!-- <div class="boxdpp_valor"> S/ <span id="ctl00_ContentPlaceHolder1_lvLista_ctrl0_ctl00_lblListingPrice">28.90</span></div> -->
                                        <asp:Label ID="lblPriceUnit" runat="server"></asp:Label>
                                        </a>
                                    <br />
                                        <asp:Label ID="lblPriceUnitConsu" runat="server"></asp:Label>
                                    </div>
                                    <div class="boxdp_cantidad">
                                        <div class="boxdpc_texto">cantidad </div>
                                        <div class="boxdpc_select">
                                            <span id="ctl00_ContentPlaceHolder1_lvLista_ctrl0_ctl00_lblQuantity">1</span>
                                            <br />

                                        </div>
                                    </div>
                                    <div class="boxdp_precio">
                                        <div class="boxdpp_texto">subtotal </div>
                                        <!-- <div class="boxdpp_valor"> S/ <span id="ctl00_ContentPlaceHolder1_lvLista_ctrl0_ctl00_lblListingPriceTotal">28.90</span></div> -->
                                        <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                                        </a>
                                 <br />
                                        <asp:Label ID="lblSubTotalConsu" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <!--commitsdf-->
                            </div>
                            <asp:Panel ID="panel1" runat="server">
                                <div class="box_detalle_oferta">
                                    <div class="bd_imagen_oferta">
                                        <img src="img/novologo.png" alt=" ">
                                    </div>
                                    <div class="bd_texto_oferta">
                                        <!--<div class="bdto_comercio">Cineplanet</div> -->
                                        <!-- <div class="bdto_opcion">Sedes Lima: 2 entradas generales 2D + combo.</div>-->
                                        <asp:Label ID="Label1" runat="server"> </asp:Label>
                                        </a>
                                       <br />
                                        <span id="Label2" runat="server" style="font-style: none">Kit de Inicio</span>
                                    </div>

                                    <div class="box_detalle_pie">
                                        <div class="boxdp_precio">
                                            <div class="boxdpp_texto">Precio Unitario </div>
                                            <!-- <div class="boxdpp_valor"> S/ <span id="ctl00_ContentPlaceHolder1_lvLista_ctrl0_ctl00_lblListingPrice">28.90</span></div> -->
                                            <span id="Label30" runat="server"><strike> 10.00</strike></span></a>
                                <br />
                                            <asp:Label ID="Label4" runat="server"></asp:Label>
                                        </div>
                                        <div class="boxdp_cantidad">
                                            <div class="boxdpc_texto">cantidad </div>
                                            <div class="boxdpc_select">
                                                <span id="ctl00_ContentPlaceHolder1_lvLista_ctrl0_ctl00_lblQuantity">1</span>
                                                <br />

                                            </div>
                                        </div>
                                        <div class="boxdp_precio">
                                            <div class="boxdpp_texto">subtotal </div>
                                            <!-- <div class="boxdpp_valor"> S/ <span id="ctl00_ContentPlaceHolder1_lvLista_ctrl0_ctl00_lblListingPriceTotal">28.90</span></div> -->
                                            <span id="Label5" runat="server">0</span> </a>
                                         <br />

                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="box_total_oferta">
                                <div class="box_total_oferta_valor_total">
                                    <span id="ctl00_ContentPlaceHolder1_lblTotal">
                                        <asp:Label ID="lblTot" runat="server"></asp:Label>
                                </div>

                                <div class="box_total_oferta_texto">Total </div>
                            </div>

                        </div>
                        </form>
                <!---->
                    </div>
                </div>
            </div>

        </div>
    </div>


    <script type="text/javascript" src="./Proceso de Pago - Cuponidad_files/f(1).txt"></script>
    <script type="text/javascript" src="./Proceso de Pago - Cuponidad_files/republica_ar.js.download"></script>

    <ul id="ui-id-5" tabindex="0" class="ui-menu ui-widget ui-widget-content ui-autocomplete ui-front" style="display: none;"></ul>
    <div role="status" aria-live="assertive" aria-relevant="additions" class="ui-helper-hidden-accessible"></div>

    </span>
   <style>
       .holi {
           width: 397px;
           margin: 9px;
       }

       @media (max-width: 600px) {
           .holi {
               width: 98%;
           }
       }
   </style>
</body>
</html>
