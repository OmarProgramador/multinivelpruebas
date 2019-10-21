<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayQuote.aspx.cs" Inherits="MULTI_NIVEL.Views.PayQuote" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- saved from url=(0039)https://cuponidad.pe/ProcesoCompra.aspx -->
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="//www.facebook.com/2008/fbml" xmlns:og="http://ogp.me/ns#" 
    xmlns:v="urn:schemas-microsoft-com:vml">
    <head id="ctl00_Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"><title>
	Proceso de Pago - inResorts
</title><meta name="description" content="Todos los días increíbles descuentos hasta del 90% en ocio, restaurantes, belleza, salud, viajes, escapadas, conciertos, bares y mucho más."><meta http-equiv="X-UA-Compatible" content="IE=edge"><meta name="viewport" content="width=device-width, initial-scale=1"><link rel="shortcut icon" href="https://cuponidad.pe/images/favicon2.ico" type="image/x-icon"><link href="./Proceso de Pago - Cuponidad_files/styles_menu.css" type="text/css" rel="stylesheet"><link href="./Proceso de Pago - Cuponidad_files/masterBootStyle.css" type="text/css" rel="stylesheet"><link href="./Proceso de Pago - Cuponidad_files/bootstrap.min.css" type="text/css" rel="stylesheet"><link rel="stylesheet" type="text/css" href="./Proceso de Pago - Cuponidad_files/jquery-ui-1.10.3.custom.css"><link rel="stylesheet" href="./Proceso de Pago - Cuponidad_files/vainilla-js-carousel.css"><link rel="stylesheet" href="./Proceso de Pago - Cuponidad_files/stylesmenumobile.css"><link rel="stylesheet" href="./Proceso de Pago - Cuponidad_files/styleshome.css">
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
    
<script type="text/javascript">
    function onKeyDecimal(e, thix) {
        var keynum = window.event ? window.event.keyCode : e.which;
        if (document.getElementById(thix.id).value.indexOf('.') != -1 && keynum == 46 && document.getElementById(thix.id).value.indexOf('-') != -1)
            return false;
        if ((keynum == 8 || keynum == 48 || keynum == 46 || keynum == 45))
            return true;
        if (keynum <= 47 || keynum >= 58) return false;
        return /\d/.test(String.fromCharCode(keynum));
    }
    function justNumbers(e) {
        var keynum = window.event ? window.event.keyCode : e.which;
        if ((keynum == 8 || keynum == 48))
            return true;
        if (keynum <= 47 || keynum >= 58) return false;
        return /\d/.test(String.fromCharCode(keynum));
    }
</script> 
<script src="./Proceso de Pago - Cuponidad_files/ProcesoCompraCulqui.js.download" type="text/javascript"></script>


    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-17499385-5', 'auto');
        ga('require', 'displayfeatures');
        ga('send', 'pageview');
    </script>
    <script>
        !function (f, b, e, v, n, t, s) {
            if (f.fbq) return; n = f.fbq = function () {
                n.callMethod ?
                    n.callMethod.apply(n, arguments) : n.queue.push(arguments)
            };
            if (!f._fbq) f._fbq = n; n.push = n; n.loaded = !0; n.version = '2.0';
            n.queue = []; t = b.createElement(e); t.async = !0;
            t.src = v; s = b.getElementsByTagName(e)[0];
            s.parentNode.insertBefore(t, s)
        }(window, document, 'script',
            'https://connect.facebook.net/en_US/fbevents.js');
        fbq('init', '316153748717666');
        fbq('track', 'PageView');
    </script>
    <noscript>
     <img height="1" width="1" 
    src="https://www.facebook.com/tr?id=316153748717666&ev=PageView
    &noscript=1"/>
    </noscript>
    <!-- End Facebook Pixel Code -->
    <link rel="manifest" href="https://cuponidad.pe/manifest.json">
    <script src="./Proceso de Pago - Cuponidad_files/OneSignalSDK.js.download"></script>
    <script>
        var OneSignal = window.OneSignal || [];
        OneSignal.push(["init", {
            appId: "e416f3b8-7731-450a-afe7-c79fced17c23",
            autoRegister: true,
            httpPermissionRequest: {
                enable: false
            },
            notifyButton: {
                enable: true,
                prenotify: true,
                showCredit: false,
                text: {
                    'tip.state.unsubscribed': 'Suscríbete para recibir notificaciones',
                    'tip.state.subscribed': "Estás suscrito a las notificaciones",
                    'tip.state.blocked': "You've blocked notifications",
                    'message.prenotify': 'Haga clic para suscribirse a las notificaciones',
                    'message.action.subscribed': "¡Gracias por suscribirte!",
                    'message.action.resubscribed': "Ya estás suscrito a las notificaciones",
                    'message.action.unsubscribed': "No volverá a recibir notificaciones",
                    'dialog.main.title': 'Cuponidad',
                    'dialog.main.button.subscribe': 'SUSCRÍBETE',
                    'dialog.main.button.unsubscribe': 'DESUSCRÍBETE',
                    'dialog.blocked.title': 'Bloquear Notificación',
                    'dialog.blocked.message': "Follow these instructions to allow notifications:"
                },
                position: 'bottom-right',
                offset: {
                    bottom: '75px',
                    left: '0px',
                    right: '5px'
                }
            },
            welcomeNotification: {
                "title": "Cuponidad",
                "message": "¡Gracias por suscribirte!, te esperamos con los mejores descuentos en CUPONIDAD.PE"
            },
            promptOptions: {
                siteName: 'Cuponidad',
                actionMessage: "Nos gustaría mostrarle las notificaciones de las últimas ofertas.",
                autoAcceptTitle: 'Hacer clic en "Permitir"',
                exampleNotificationTitle: 'Notificación de ejemplo',
                exampleNotificationMessage: 'Esta es una notificación de ejemplo',
                exampleNotificationCaption: 'Puede anular su suscripción en cualquier momento',
                acceptButtonText: "PERMITIR",
                cancelButtonText: "NO GRACIAS"
            },
            prenotify: true,
            showCredit: false,
            text: {
                'tip.state.unsubscribed': 'Suscríbete para recibir notificaciones',
                'tip.state.subscribed': "Estás suscrito a las notificaciones",
                'tip.state.blocked': "You've blocked notifications",
                'message.prenotify': 'Haga clic para suscribirse a las notificaciones',
                'message.action.subscribed': "¡Gracias por suscribirte!",
                'message.action.resubscribed': "Ya estás suscrito a las notificaciones",
                'message.action.unsubscribed': "No volverá a recibir notificaciones",
                'dialog.main.title': 'Cuponidad.pe',
                'dialog.main.button.subscribe': 'SUSCRÍBETE',
                'dialog.main.button.unsubscribe': 'DESUSCRÍBETE',
                'dialog.blocked.title': 'Bloquear Notificación',
                'dialog.blocked.message': "Follow these instructions to allow notifications:"
            }
        }]);
    </script>
    <script src="./Proceso de Pago - Cuponidad_files/OneSignalSDKUpdaterWorker.js.download" type="text/javascript"></script>
    <script src="./Proceso de Pago - Cuponidad_files/OneSignalSDKWorker.js.download" type="text/javascript"></script>
<script src="./Proceso de Pago - Cuponidad_files/f.txt"></script><style type="text/css">
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
                                                                 </style><link rel="stylesheet" href="./Proceso de Pago - Cuponidad_files/OneSignalSDKStyles.css"><script type="text/javascript" charset="UTF-8" src="./Proceso de Pago - Cuponidad_files/common.js.download"></script><script type="text/javascript" charset="UTF-8" src="./Proceso de Pago - Cuponidad_files/util.js.download"></script><script type="text/javascript" charset="UTF-8" src="./Proceso de Pago - Cuponidad_files/stats.js.download"></script><script type="text/javascript" charset="UTF-8" src="./Proceso de Pago - Cuponidad_files/AuthenticationService.Authenticate"></script></head>
<body id="ctl00_body" style="">
    <script type="text/javascript" src="./Proceso de Pago - Cuponidad_files/republica_init.js.download"></script> 
    <div id="fb-root" class=" fb_reset">
    <div style="position: absolute; top: -10000px; height: 0px; width: 0px;"><div><iframe name="fb_xdm_frame_https" frameborder="0" allowtransparency="true" allowfullscreen="true" scrolling="no" allow="encrypted-media" id="fb_xdm_frame_https" aria-hidden="true" title="Facebook Cross Domain Communication Frame" tabindex="-1" src="./Proceso de Pago - Cuponidad_files/trnHszv6jVd.html" style="border: none;"></iframe></div></div><div style="position: absolute; top: -10000px; height: 0px; width: 0px;"><div></div></div></div>
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                appId: '368516143221995',
                version: 'v2.5',
                status: true, cookie: true, xfbml: true, oauth: true
            });
        };

        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
    </script>   
    
    <script type="text/javascript" src="./Proceso de Pago - Cuponidad_files/js">
    </script>
   
<div>
<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="">
<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="">
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUJNzEyMzMxNzExD2QWAmYPZBYCAgMPZBYCAgEPZBYIAgcPZBYCAgEPFgIeCWlubmVyaHRtbAUBMWQCCQ8PFgIeB1Zpc2libGVoZGQCEQ8WAh8BaGQCEw9kFgICAw9kFgJmD2QWEGYPDxYCHwFoZBYCAgEPZBYGAgEPEA8WBh4ORGF0YVZhbHVlRmllbGQFCUNvZFViaWdlbx4NRGF0YVRleHRGaWVsZAUMRGVwYXJ0YW1lbnRvHgtfIURhdGFCb3VuZGdkEBUCBkNhbGxhbwRMaW1hFQIGMDcwMDAwBjE1MDAwMBQrAwJnZxYBAgFkAgMPEA8WBh8CBQlDb2RVYmlnZW8fAwUJUHJvdmluY2lhHwRnZBAVCglCYXJyYW5jYSAKQ2FqYXRhbWJvIAhDYcOxZXRlIAZDYW50YSAHSHVhcmFsIAxIdWFyb2NoaXLDrSAHSHVhdXJhIAVMaW1hIAZPecOzbiAHWWF1eW9zIBUKBjE1MDIwMAYxNTAzMDAGMTUwNTAwBjE1MDQwMAYxNTA2MDAGMTUwNzAwBjE1MDgwMAYxNTAxMDAGMTUwOTAwBjE1MTAwMBQrAwpnZ2dnZ2dnZ2dnFgECB2QCBQ8QDxYGHwIFCUNvZFViaWdlbx8DBQhEaXN0cml0bx8EZ2QQFSsGQW5jw7NuA0F0ZQhCYXJyYW5jbwZCcmXDsWEKQ2FyYWJheWxsbwpDaGFjbGFjYXlvCkNob3JyaWxsb3MLQ2llbmVndWlsbGEFQ29tYXMLRWwgQWd1c3Rpbm8NSW5kZXBlbmRlbmNpYQ1KZXPDunMgTWFyw61hCUxhIE1vbGluYQtMYSBWaWN0b3JpYQRMaW1hBUxpbmNlCkxvcyBPbGl2b3MKTHVyaWdhbmNobwVMdXJpbhFNYWdkYWxlbmEgZGVsIE1hcgpNaXJhZmxvcmVzClBhY2hhY2FtYWMIUHVjdXNhbmEMUHVlYmxvIExpYnJlDVB1ZW50ZSBQaWVkcmENUHVudGEgSGVybW9zYQtQdW50YSBOZWdyYQZSw61tYWMLU2FuIEJhcnRvbG8JU2FuIEJvcmphClNhbiBJc2lkcm8WU2FuIEp1YW4gZGUgTHVyaWdhbmNobxZTYW4gSnVhbiBkZSBNaXJhZmxvcmVzCFNhbiBMdWlzFVNhbiBNYXJ0w61uIGRlIFBvcnJlcwpTYW4gTWlndWVsC1NhbnRhIEFuaXRhFFNhbnRhIE1hcsOtYSBkZWwgTWFyClNhbnRhIFJvc2ERU2FudGlhZ28gZGUgU3VyY28JU3VycXVpbGxvEVZpbGxhIEVsIFNhbHZhZG9yGFZpbGxhIE1hcsOtYSBkZWwgVHJpdW5mbxUrBjE1MDEwMgYxNTAxMDMGMTUwMTA0BjE1MDEwNQYxNTAxMDYGMTUwMTA3BjE1MDEwOAYxNTAxMDkGMTUwMTEwBjE1MDExMQYxNTAxMTIGMTUwMTEzBjE1MDExNAYxNTAxMTUGMTUwMTAxBjE1MDExNgYxNTAxMTcGMTUwMTE4BjE1MDExOQYxNTAxMjAGMTUwMTIyBjE1MDEyMwYxNTAxMjQGMTUwMTIxBjE1MDEyNQYxNTAxMjYGMTUwMTI3BjE1MDEyOAYxNTAxMjkGMTUwMTMwBjE1MDEzMQYxNTAxMzIGMTUwMTMzBjE1MDEzNAYxNTAxMzUGMTUwMTM2BjE1MDEzNwYxNTAxMzgGMTUwMTM5BjE1MDE0MAYxNTAxNDEGMTUwMTQyBjE1MDE0MxQrAytnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnFgECDmQCAQ8PFgIfAWhkFgICBQ8PFgIeBFRleHQFBDAuMDBkZAIEDw8WAh8FZWRkAgUPDxYCHwVlZGQCDg8PFgIfBQUIUy8gMjguOTBkZAIPDw8WAh8FZWRkAhIPFCsAAg8WBB8EZx4LXyFJdGVtQ291bnQCAWRkFgJmD2QWAgIBD2QWAgIBD2QWCGYPFQQUb2ZlcnRhY2luZXBsYW5ldC5qcGcsU2VkZXMgTGltYTogMiBlbnRyYWRhcyBnZW5lcmFsZXMgMkQgKyBjb21iby4KQ2luZXBsYW5ldCxTZWRlcyBMaW1hOiAyIGVudHJhZGFzIGdlbmVyYWxlcyAyRCArIGNvbWJvLmQCAQ8PFgIfBQUFMjguOTBkZAIDDw8WAh8FBQExZGQCBQ8PFgIfBQUFMjguOTBkZAITDw8WAh8FBQUyOC45MGRkGAIFHl9fQ29udHJvbHNSZXF1aXJlUG9zdEJhY2tLZXlfXxYVBRdjdGwwMCRibnRCdXNjYWRvck1vYmlsZQURY3RsMDAkYnRuQnVzY2Fkb3IFIGN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJWaXNhBSBjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiVmlzYQUeY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRyYk1DBR5jdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiTUMFImN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJEaW5lcnMFImN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJEaW5lcnMFIGN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJBbWV4BSBjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiQW1leAUmY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRyYlNhZmV0eVBheUUFJmN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJTYWZldHlQYXlFBSZjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiU2FmZXR5UGF5VAUmY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRyYlNhZmV0eVBheVQFJGN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkcmJQYWdvRWZlYwUkY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRyYlBhZ29FZmVjBSVjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiUGFnb0VmZWNUBSVjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJHJiUGFnb0VmZWNUBQ5jdGwwMCRMb2dpbkJUTgUVY3RsMDAkYnRuU3VzY3JpYmlybWUyBRRjdGwwMCRidG5TdXNjcmliaXJtZQUhY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRsdkxpc3RhDzwrAAoCBxQrAAFkCAIBZEGxpK0ewqk3qz8dfEbZNtKw4QLU">
</div>

<script type="text/javascript">
    //<![CDATA[
    var theForm = document.forms['aspnetForm'];
    if (!theForm) {
        theForm = document.aspnetForm;
    }
    function __doPostBack(eventTarget, eventArgument) {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
            theForm.__EVENTTARGET.value = eventTarget;
            theForm.__EVENTARGUMENT.value = eventArgument;
            theForm.submit();
        }
    }
//]]>
</script>


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
                    <a href="Index.aspx" class="navbar-brand inicio-logo" style="float:none">
                        <img src="img/novologo.png" class="" width="300">
                    </a>
                </center>
            <div id="page-wrapper" class="gray-bg">
                <%--<div class="row border-bottom white-bg iniciowp">
                    <nav class="navbar navbar-static-top" role="navigation" style="height: 75px">
                        <div class="navbar-header header-inicio">
                            <button aria-controls="navbar" aria-expanded="false" data-target="#navbar" data-toggle="collapse" class="navbar-toggle collapsed" type="button">
                                <i class="fa fa-reorder"></i>
                            </button>
                            
                        </div>
                        <div class="navbar-collapse collapse" id="navbar">
                            <asp:Panel runat="server" ID="menu">
                                <ul class="nav navbar-top-links navbar-right header-inicior">
                                    <li>
                                        <asp:Image ID="imgProfile" runat="server" alt="..." CssClass="img-circle img-responsive img-user" />
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
                                                            <asp:Label ID="lblUserName" runat="server"></asp:Label></strong>
                                                    </p>
                                                    <p class="green">
                                                        <asp:Label ID="lblNumPartner" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </li>
                                            <li class="divider"></li>
                                            <li>
                                                <p class="col-md-5">
                                                    <a href="Edit.aspx" class="btn btn-primary btn-sm">Editar perfil</a>
                                                </p>
                                                <p class="col-md-5">
                                                    <a href="editar.htm" class="btn btn-primary btn-sm">Cambiar Clave</a>
                                                </p>
                                                <center>
						                        <p class="col-md-12">							                            
                                                    <%--<asp:LinkButton ID="lblSalir" runat="server" OnClick="lbkBtnSalir_Click" CssClass="btn btn-primary block" Text="Salir"></asp:LinkButton>
						                        </p>
						                    </center>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </asp:Panel>
                        </div>
                    </nav>
                </div>--%>
            
        




    <div id="ctl00_ContentPlaceHolder1_upnlUbigeo">
	
    <div id="contenedor" style="margin-top:1px !important">
        <div class="box_center"> 
            <div class="comprar_contenido"> 
                <form id="form1" runat="server">
                 <div class="box_proceso_compra" style="border-radius:27px;"">
                    <div class="box_mediospago_lista">
                        <div class="box_mediospago_lista_titulo" style="text-decoration-color:chartreuse">
                            <span style="color: #2981c5">LISTA DE MEDIOS DE PAGO : seleccione un medio de pago y luego clic en boton "Pagar"</span>
                        </div>
                         <div class="box_mediospago_lista_titulo anchura" style="text-decoration-color: chartreuseM;width: 95%;">
                                           <div id="ctl00_ContentPlaceHolder1_DivMPSafetyPayT" class="box_mediospago_lista_item2 holi" style="font-size:16px;width:98%;color:black;font-weight:100">
                                                    <div class="box_mpli_check">
                                                        <asp:RadioButton runat="server" GroupName="packafilia" ID="rbtWallet" value="6" style="margin-left: 8px;" ></asp:RadioButton>
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
                            <div id="ctl00_ContentPlaceHolder1_DivMPVisa " class="box_mediospago_lista_item holi" >
                                <div class="box_mpli_check"> <!--<input id="ctl00_ContentPlaceHolder1_rbVisa" type="radio" name="ctl00$ContentPlaceHolder1$gpcheck" value="1"> -->
                                    <asp:RadioButton runat="server" GroupName="packafilia" ID="rdrCulqi" value="1"></asp:RadioButton></div>
                                <div class="box_mpli_img"> 
                                    <img  src="./Proceso de Pago - Cuponidad_files/logo_visa.png" id="ctl00_ContentPlaceHolder1_imgMPVisa" border="0"> 
                                    <img  src="./Proceso de Pago - Cuponidad_files/mastercardpayu2.png" id="ctl00_ContentPlaceHolder1_imgMPMC" border="0">
                                    <img  src="./Proceso de Pago - Cuponidad_files/dinersclubpayu2.png" border="0">
                                    <img s src="./Proceso de Pago - Cuponidad_files/americanexpresspayu2.png" border="0">
                                </div>                            
                                <div class="box_mpli_texto">
                                    <p>Tarjetas Visa</p> <span>Paga con Tarjetas de Crédito o Débito</span>
                                    <br />
                                     <br />
                                    <br />
                                    <p>Tarjetas Master Card</p> <span>Paga con Tarjetas de Crédito o Débito</span>
                                    <br />
                                    <br />
                                    <br />
                                    <p>Tarjetas Diners Club</p> <span>Paga con Tarjetas de Crédito o Débito</span>
                                    <br />
                                     <br />
                                    <br />
                                    <p>Tarjetas American Express</p> <span>Paga con Tarjetas de Crédito o Débito</span>
                                </div>
                            </div>
                        </div>
                        <div onclick="selectRBMP(&#39;ctl00_ContentPlaceHolder1_rbVisa&#39;);">
                            <div id="ctl00_ContentPlaceHolder1_DivMPVisa" class="box_mediospago_lista_item">
                                
                             <div id="ctl00_ContentPlaceHolder1_DivMPSafetyPayE" class="box_mediospago_lista_item2">
                                <div class="box_mpli_check"> <!--<input id="ctl00_ContentPlaceHolder1_rbSafetyPayE" type="radio" name="ctl00$ContentPlaceHolder1$gpcheck" value="7">--> 
                                    <asp:RadioButton runat="server" GroupName="packafilia" ID="rdrTransfer" value="2"></asp:RadioButton> </div>
                                <div class="box_mpli_img3" style="width: 70px;height:70px;display:flex"> 
                                     <img src="img/bcpagente123.jpg" border="0" style="width: 80px;">
                                     
                                    <ul >
                                        <li style="width: 145px;text-decoration:none;list-style:none;font-size:15px;padding-top:20px"><b>Pago en Efectivo</b></li>
                                        <li style="width: 145px;text-decoration:none;list-style:none"> Oficinas y Agentes </li>
                                    </ul>
                                    
                                </div>
                             </div> 
                           <div id="ctl00_ContentPlaceHolder1_DivMPSafetyPayT" class="box_mediospago_lista_item2">
                                <div class="box_mpli_check"> <!--<input id="ctl00_ContentPlaceHolder1_rbSafetyPayT" type="radio" name="ctl00$ContentPlaceHolder1$gpcheck" value="8">-->
                                    <asp:RadioButton runat="server" GroupName="packafilia" ID="rdrTransfer2" value="3" ></asp:RadioButton> </div>
                                <div class="box_mpli_img3" style="width: 70px;height:70px;display:flex"> 
                                    
                                    <img src="img/bcp123.png" border="0" style="width: 80px"> </div> 
                                    <ul >
                                        <li style="font-size:15px;padding-top:20px"><b>Banca por Internet</b></li>
                                        <li style="list-style:none">  </li>
                                    </ul>
                                    
                            </div>    
                               <div id="ctl00_ContentPlaceHolder1_DivMPSafetyPayT" class="box_mediospago_lista_item2">
                                <div class="box_mpli_check"> <!--<input id="ctl00_ContentPlaceHolder1_rbSafetyPayT" type="radio" name="ctl00$ContentPlaceHolder1$gpcheck" value="8">-->
                                    <asp:RadioButton runat="server" GroupName="packafilia" ID="rdrStor" value="4"></asp:RadioButton> </div>
                                <div class="box_mpli_img3" style="width: 40px;height:90px;display:flex"> 
                                   
                                    <img src="img/logosf2.png" border="0" style="width: 100px"> </div>    
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
       
        <asp:Label ID="lblDiscount" runat="server" Text="S/ 0.00"></asp:Label>
    </p>
                        <div class="box_mediospagob_titulo">
                            Total a Pagar
                        </div>
                        <div class="box_mediospagob_valor">
                            <!--<span id="ctl00_ContentPlaceHolder1_lblTotalAPagar">S/ 28.90</span>-->
                               <asp:Label ID="lblCostQuote" runat="server"></asp:Label> 
                        </div>

                        <div class="box_mediospagob_valor_antes">
                            <span id="ctl00_ContentPlaceHolder1_lblTotalAPagarAntes"></span>
                        </div>
                        <div class="box_mediospagob_comprar" id="box_mediospagob_comprar"> 
                          <!--  <input type="submit" name="ctl00$ContentPlaceHolder1$btnPagar" value="Pagar" id="ctl00_ContentPlaceHolder1_btnPagar" class="boton botonProcesarPrevious" style="background-color:chartreuse" >-->
                           <!-- <input type="submit" name="ctl00$ContentPlaceHolder1$btnPagarProcesar" value="Pagar Procesar" id="ctl00_ContentPlaceHolder1_btnPagarProcesar" class="boton" style="display:none; background-color:chartreuse" >-->                                                  
                            <!--boton--->
                           <center>
                               <asp:Button ID="btnProcessPay" runat="server" Text="Continuar" OnClick="btnProcessPay_Click" CssClass="btn btn-primary" /></center>    

                        </div>
                    </div>
                     <div class="box_mediospago_bloquepago">
                         <div class="box_mediospagob_titulo">
                            Cambio En Soles
                        </div>
                         <div class="exchange">
                            <!--<span id="ctl00_ContentPlaceHolder1_lblTotalAPagar">S/ 28.90</span>-->
                              S/.<asp:Label ID="lblExchange" runat="server"></asp:Label> 
                        </div>
                    </div>

                 </div>
                    
             
                 </div>
                 
                 <div class="box_proceso_compra">
                    <div class="box_detalle_cab">
                        <div class="bdc_texto_carrito"> Detalle de tu Pago </div>
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
                             <asp:Label ID="lblDescription" runat="server"></asp:Label> </a>
                             <br />
                            <asp:Label ID="lblDescriptionConsu" runat="server"></asp:Label> 
                        </div>
                        <div class="box_detalle_pie">
                            <div class="boxdp_precio">
                                <div class="boxdpp_texto"> Precio Unitario </div>
                               <!-- <div class="boxdpp_valor"> S/ <span id="ctl00_ContentPlaceHolder1_lvLista_ctrl0_ctl00_lblListingPrice">28.90</span></div> -->
                                 <asp:Label ID="lblPriceUnit" runat="server"></asp:Label> </a>
                                <br />
                                <asp:Label ID="lblPriceUnitConsu" runat="server"></asp:Label>
                            </div>
                            <div class="boxdp_cantidad">
                                <div class="boxdpc_texto"> cantidad </div>
                                <div class="boxdpc_select">
                                     <span id="ctl00_ContentPlaceHolder1_lvLista_ctrl0_ctl00_lblQuantity">1</span>
                                    <br />
                                     
                                </div> 
                            </div>
                            <div class="boxdp_precio">
                                <div class="boxdpp_texto"> subtotal </div>
                               <!-- <div class="boxdpp_valor"> S/ <span id="ctl00_ContentPlaceHolder1_lvLista_ctrl0_ctl00_lblListingPriceTotal">28.90</span></div> -->
                                <asp:Label ID="lblSubTotal" runat="server"></asp:Label> </a>
                                 <br /> 
                                <asp:Label ID="lblSubTotalConsu" runat="server"></asp:Label> 
                            </div>
                        </div>
                        <!--commitsdf-->
                    </div>
                     
                    
                    
                     
                    
                    <div class="box_total_oferta">
                        <div class="box_total_oferta_valor_total"><span id="ctl00_ContentPlaceHolder1_lblTotal"><asp:Label ID="lblTot" runat="server"></asp:Label> </div>
                        
                        <div class="box_total_oferta_texto"> Total </div>
                    </div>
                   
                 </div>
               </form>
                <!---->
            </div>
        </div>
    </div>

        </div>
        </div>
    <input type="hidden" name="ctl00$ContentPlaceHolder1$hfTI" id="ctl00_ContentPlaceHolder1_hfTI" value="636754779275986960">
    <input type="hidden" name="ctl00$ContentPlaceHolder1$hfRD" id="ctl00_ContentPlaceHolder1_hfRD">
    
    <input type="hidden" name="ctl00$ContentPlaceHolder1$hfDID" id="ctl00_ContentPlaceHolder1_hfDID" value="0">
    <input type="hidden" name="ctl00$ContentPlaceHolder1$hfDAM" id="ctl00_ContentPlaceHolder1_hfDAM" value="0.00">
    
    <input type="hidden" name="ctl00$ContentPlaceHolder1$hfCVA" id="ctl00_ContentPlaceHolder1_hfCVA" value="0"> 
    <input type="hidden" name="ctl00$ContentPlaceHolder1$hfCTV" id="ctl00_ContentPlaceHolder1_hfCTV" value="28.90">
    <input type="hidden" name="ctl00$ContentPlaceHolder1$hfVNC" id="ctl00_ContentPlaceHolder1_hfVNC" value="0">
    <input type="hidden" name="ctl00$ContentPlaceHolder1$hfCFP" id="ctl00_ContentPlaceHolder1_hfCFP" value="0">
    
    <input type="hidden" name="ctl00$ContentPlaceHolder1$hfFPEInd" id="ctl00_ContentPlaceHolder1_hfFPEInd" value="1"> 
    
    <script type="text/javascript">
        function selectRBMP(rd) {
            try {
                document.getElementById(rd).checked = true;
                if (document.getElementById('ctl00_ContentPlaceHolder1_hfFPEInd').value == "1") {
                    document.getElementById('ctl00_ContentPlaceHolder1_btnValidarMP').click();
                }
            } catch (Error) { }
        }
    </script>
    
    <script type="text/javascript">
        Sys.Application.add_load(BindEvents);
     </script>
     
    
</div>
    
        
    <input name="ctl00$LoginResult" type="hidden" id="ctl00_LoginResult">
    <input name="ctl00$pwHide" type="hidden" id="ctl00_pwHide" value="1">
    <input name="ctl00$SubscribeResult" type="hidden" id="ctl00_SubscribeResult">
     
     
    <div style="display:none;">
    <input type="image" name="ctl00$btnSuscribirme2" id="ctl00_btnSuscribirme2" border="0" src="./Proceso de Pago - Cuponidad_files/suscribirme_cupon_cuponidad.png" style="height:45px;width:175px;border-width:0px;"> </div>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $("#suscribirme").dialog({
                width: 'auto',
                maxWidth: 850,
                height: 'auto',
                modal: true,
                fluid: true,
                resizable: false,
                autoOpen: false,
                show: { effect: "fadeIn", duration: 500 },
                hide: { effect: "fadeOut", duration: 500 },
                open: function (type, data) {
                    $(this).parent().appendTo("form");
                }
            });
            $(".ui-dialog-titlebar").hide();
            $(".cssSuscribir").click(function (event) {
                $('#suscribirme').dialog('open');
            });
            $(".cssSuscribir2").click(function (event) {
                $('#suscribirme').dialog('open');
            });
            if ($("#ctl00_pwHide").val() == "0") {
                $('#suscribirme').dialog('open');
            }
        }); /*kv*/
    </script>
    <script type="text/javascript">
        $(window).resize(function () {
            fluidDialog();
        });
        $(window).load(function () {
            fluidDialog();
        });
        // catch dialog if opened within a viewport smaller than the dialog width
        $(document).on("dialogopen", ".ui-dialog", function (event, ui) {
            fluidDialog();
        });
        function fluidDialog() {
            var $visible = $(".ui-dialog:visible");
            // each open dialog
            $visible.each(function () {
                var $this = $(this);
                var dialog = $this.find(".ui-dialog-content").data("ui-dialog");
                // if fluid option == true
                if (dialog.options.fluid) {
                    var wWidth = $(window).width();
                    // check window width against dialog width
                    if (wWidth < (parseInt(dialog.options.maxWidth) + 50)) {
                        // keep dialog from filling entire screen
                        $this.css("max-width", "90%");
                    } else {
                        // fix maxWidth bug
                        $this.css("max-width", dialog.options.maxWidth + "px");
                    }
                    //reposition dialog
                    dialog.option("position", dialog.options.position);
                }
            });
        }
    </script> 
    
    <input type="hidden" name="ctl00$hfPPD" id="ctl00_hfPPD" value="0">
    <input type="hidden" name="ctl00$hfPPM" id="ctl00_hfPPM" value="0">
    <div style="width:100%;margin:0 auto;text-align:center;">
       
    </div>  
<script type="text/javascript">
    //<![CDATA[
    WebForm_AutoFocus('LoginBTN'); Sys.Application.initialize();
//]]>
</script>

    
    
    

    <script type="text/javascript">
        $(".fb-login-btn").click(function () {
            FB.login(
                function (response) {

                    if (response.authResponse) {
                        $.ajax(
                            {
                                type: "POST",
                                url: "fbProcessRegistration.aspx/FacebookLogin",
                                data: "{ 'accessToken': '" + response.authResponse.accessToken + "'}",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (msg) {

                                    switch (msg.d.split("|")[0]) {
                                        case "-1":
                                            // Offer to link emails 
                                            FB.api('/me', function (response) {
                                                window.location.href = "//www.cuponidad.pe/login.aspx?email=" + msg.d.split("|")[1] + "&fbid=" + msg.d.split("|")[2];
                                            });
                                            break;
                                        case "0":
                                            // Offer to create an account 
                                            window.location.href = "//www.cuponidad.pe/login.aspx?crearFB=true";
                                            break;
                                        case "1":
                                            //Account already linked  
                                            document.getElementById("ctl00_SingInLNK").innerHTML = "Salir";
                                            document.getElementById("ctl00_SingInLNK").removeAttribute("onclick", 0);
                                            document.getElementById("ctl00_SingInLNK").setAttribute("href", "/salir.aspx");
                                            document.getElementById("ctl00_RegistrateLNK").innerHTML = "Mi Cuenta";
                                            document.getElementById("ctl00_RegistrateLNK").setAttribute("href", "/micuentanew.aspx");
                                            window.location.href = "";
                                            break;
                                        default:
                                            alert('Unknown Error ' + msg.d.split("|")[0]);
                                            break;
                                    }

                                }
                                , error: function () {
                                    // TODO: Display error message
                                }
                            }
                        );
                    }
                    else {
                        FB.logout(function (response) {
                            //console.log('Logged out.');
                        });
                    }
                }
                , { scope: 'email,user_location,user_relationships,user_birthday,user_likes' }
            );
            return false;
        });

    </script>
     
    <script src="./Proceso de Pago - Cuponidad_files/jquery-1.12.4.js.download" type="text/javascript"></script>
    <script src="./Proceso de Pago - Cuponidad_files/jquery-ui-1.12.4.js.download" type="text/javascript"></script>
    <link href="./Proceso de Pago - Cuponidad_files/jquery-ui-1.10.3.custom2.css" rel="stylesheet" type="text/css">
    
    <script type="text/javascript"> 
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "fbProcessRegistration.aspx/GetSelectTitles",
                dataType: "json",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var arregloTitles = data.d.split("|");
                    $('#ctl00_txtBuscador').autocomplete({
                        maxShowItems: 10,
                        maxHeight: 200,
                        source: arregloTitles,
                        minLength: 2,
                        select: function (e, ui) {
                            window.location.href = "https://cuponidad.pe/BusquedaOferta.aspx?Buscar=" + ui.item.value + "&utm_source=BuscadorCuponidad&utm_medium=BuscadorCuponidad";
                        }
                    });
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            try {
                $.ajax({
                    type: "POST",
                    url: "fbProcessRegistration.aspx/GetSelectTitles",
                    dataType: "json",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var arregloTitles = data.d.split("|");
                        $('#ctl00_ContentPlaceHolder1_txtBuscador').autocomplete({
                            maxShowItems: 10,
                            maxHeight: 200,
                            source: arregloTitles,
                            minLength: 4,
                            select: function (e, ui) {
                                window.location.href = "https://cuponidad.pe/BusquedaOferta.aspx?Buscar=" + ui.item.value + "&utm_source=BuscadorCuponidad&utm_medium=BuscadorCuponidad";
                            }
                        });
                    }
                });
            } catch (Error) { }
            try {
                $.ajax({
                    type: "POST",
                    url: "fbProcessRegistration.aspx/GetSelectTitles",
                    dataType: "json",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var arregloTitles = data.d.split("|");
                        $('#ctl00_txtBuscadorMobile').autocomplete({
                            maxShowItems: 10,
                            maxHeight: 200,
                            source: arregloTitles,
                            minLength: 4,
                            select: function (e, ui) {
                                window.location.href = "https://cuponidad.pe/BusquedaOferta.aspx?Buscar=" + ui.item.value + "&utm_source=BuscadorCuponidad&utm_medium=BuscadorCuponidad";
                            }
                        });
                    }
                });
            } catch (Error) { }
        });
    </script>
    <script type="text/javascript">
        var google_conversion_id = 981866865;
        var google_custom_params = window.google_tag_params;
        var google_remarketing_only = true;
    </script>
    <script type="text/javascript" src="./Proceso de Pago - Cuponidad_files/f(1).txt">
    </script>
    <noscript>
        <div style="display: inline;height:0px;">
            <img height="1" width="1" style="border-style: none;" alt="" src="//googleads.g.doubleclick.net/pagead/viewthroughconversion/981866865/?value=0&amp;guid=ON&amp;script=0" />
        </div>
        <span id="ctl00_ContentPlaceHolder1_lblTotal">
        <asp:Label ID="Label31" runat="server" Text="Descuento Por Codigo"></asp:Label>
        </span>
    </noscript>
<script type="text/javascript" src="./Proceso de Pago - Cuponidad_files/republica_ar.js.download"></script> 


<div tabindex="-1" role="dialog" class="ui-dialog ui-corner-all ui-widget ui-widget-content ui-front ui-draggable" aria-describedby="logearme" aria-labelledby="ui-id-1" style="display: none;"><div class="ui-dialog-titlebar ui-corner-all ui-widget-header ui-helper-clearfix ui-draggable-handle" style="display: none;"><span id="ui-id-1" class="ui-dialog-title">&nbsp;</span><button type="button" class="ui-button ui-corner-all ui-widget ui-button-icon-only ui-dialog-titlebar-close" title="Close"><span class="ui-button-icon ui-icon ui-icon-closethick"></span><span class="ui-button-icon-space"> </span>Close</button></div><div id="logearme" style="" class="ui-dialog-content ui-widget-content">
        <div class="contenedorImg">
            <img src="./Proceso de Pago - Cuponidad_files/ingresar_cuponidad_cupon.png" width="483" height="349" alt="ingresa tu cuenta bienvenido cuponidad">
        </div>
        <div class="mainText">
            <div id="dialogClose">
            <a href="https://cuponidad.pe/ProcesoCompra.aspx#" onclick="$(&#39;#logearme&#39;).dialog(&#39;close&#39;); return false;">
                <img src="./Proceso de Pago - Cuponidad_files/cerrar_suboffers_cupon.png" width="16" height="16" border="0" alt="cerrar bienvenido"></a></div>
            <div class="cssTituloSuscribir"> 
                Bienvenido a Cuponidad
            </div>
            <div class="cssLetraSuscribir">
                Correo Electrónico <br>
                <input name="ctl00$LoginEmailTXT" type="text" id="ctl00_LoginEmailTXT" class="form-control ">
            </div>
            <div class="cssLetraSuscribir">
                Contraseña<br>
                <input name="ctl00$PasswordTXT" type="password" maxlength="15" id="ctl00_PasswordTXT" class="form-control ">
            </div>
            <div class="cssOlvidoPass">
                <a href="https://cuponidad.pe/password/RecoveryPassword.aspx" class="textSubTitle">¿Olvidaste la clave?</a>
            </div>
            <div id="TextRegistrateAqui" class="TextRegistrateAqui">
                <a href="https://cuponidad.pe/Register.aspx" class="TextRegistrateAqui"><b>Regístrate</b>, haz clic aqui!</a></div>
            <div id="RegistroFace"> 
                <div id="RegistroEntrar">
                    <input type="image" name="ctl00$LoginBTN" id="ctl00_LoginBTN" border="0" src="./Proceso de Pago - Cuponidad_files/entrar_cuponidad.png" style="height:35px;width:76px;border-width:0px;">
                </div>
            </div> 
            <div class="FBconnect">
                <a id="ctl00_FB_ButtonLNK" class="fb-login-btn"></a>
            </div> 
            <div class="ErrorMsg">
                
            </div>
        </div> 
    </div></div><div tabindex="-1" role="dialog" class="ui-dialog ui-corner-all ui-widget ui-widget-content ui-front ui-draggable" aria-describedby="PublicidadPopupDestok" aria-labelledby="ui-id-2" style="display: none;"><div class="ui-dialog-titlebar ui-corner-all ui-widget-header ui-helper-clearfix ui-draggable-handle" style="display: none;"><span id="ui-id-2" class="ui-dialog-title">&nbsp;</span><button type="button" class="ui-button ui-corner-all ui-widget ui-button-icon-only ui-dialog-titlebar-close" title="Close"><span class="ui-button-icon ui-icon ui-icon-closethick"></span><span class="ui-button-icon-space"> </span>Close</button></div><div id="PublicidadPopupDestok" class="ui-dialog-content ui-widget-content">
        <a href="https://cuponidad.pe/ProcesoCompra.aspx#" onclick="jQuery(&#39;#PublicidadPopupDestok&#39;).dialog(&#39;close&#39;); return false;" style="position:absolute;right:5px;top:5px;">
                <img src="./Proceso de Pago - Cuponidad_files/ico_close2.png" width="26" height="26" border="0" alt="cupones"></a>
        <img id="ctl00_imgPublicidadPopupDestok" src="https://cuponidad.pe/ProcesoCompra.aspx" style="border-width:0px;">
    </div></div><div tabindex="-1" role="dialog" class="ui-dialog ui-corner-all ui-widget ui-widget-content ui-front ui-draggable" aria-describedby="PublicidadPopupMobile" aria-labelledby="ui-id-3" style="display: none;"><div class="ui-dialog-titlebar ui-corner-all ui-widget-header ui-helper-clearfix ui-draggable-handle" style="display: none;"><span id="ui-id-3" class="ui-dialog-title">&nbsp;</span><button type="button" class="ui-button ui-corner-all ui-widget ui-button-icon-only ui-dialog-titlebar-close" title="Close"><span class="ui-button-icon ui-icon ui-icon-closethick"></span><span class="ui-button-icon-space"> </span>Close</button></div><div id="PublicidadPopupMobile" class="ui-dialog-content ui-widget-content">
        <a href="https://cuponidad.pe/ProcesoCompra.aspx#" onclick="jQuery(&#39;#PublicidadPopupMobile&#39;).dialog(&#39;close&#39;); return false;" style="position:absolute;right:5px;top:5px;">
                <img src="./Proceso de Pago - Cuponidad_files/ico_close2.png" width="26" height="26" border="0" alt="cupones"></a>
        <img id="ctl00_imgPublicidadPopupMobile" src="https://cuponidad.pe/ProcesoCompra.aspx" style="border-width:0px;">
    </div></div><div tabindex="-1" role="dialog" class="ui-dialog ui-corner-all ui-widget ui-widget-content ui-front ui-draggable" aria-describedby="suscribirme" aria-labelledby="ui-id-4" style="display: none;"><div class="ui-dialog-titlebar ui-corner-all ui-widget-header ui-helper-clearfix ui-draggable-handle" style="display: none;"><span id="ui-id-4" class="ui-dialog-title">&nbsp;</span><button type="button" class="ui-button ui-corner-all ui-widget ui-button-icon-only ui-dialog-titlebar-close" title="Close"><span class="ui-button-icon ui-icon ui-icon-closethick"></span><span class="ui-button-icon-space"> </span>Close</button></div><div id="suscribirme" style="" class="ui-dialog-content ui-widget-content">
            <div class="contenedorImg">
                <img src="./Proceso de Pago - Cuponidad_files/ingresar_cuponidad_popup.png">
            </div>
            <div class="mainText">
                <div id="suscribirmeClose">
                <a href="https://cuponidad.pe/ProcesoCompra.aspx#" onclick="$(&#39;#suscribirme&#39;).dialog(&#39;close&#39;); return false;">
                    <img src="./Proceso de Pago - Cuponidad_files/cerrar_suboffers_cupon.png" border="0"></a>
                </div>
                <div class="cssTituloSuscribir"> 
                    Bienvenido a Cuponidad
                </div>
                <div class="cssLetraSuscribir"> 
                Disfruta de las más variadas 
                ofertas con hasta <strong style="color:#BC212F;font-size:18px;">-95% de descuento</strong> 
                en todo lo que puedas imaginar.
                <br><br>
                Suscríbete y recibirás todos los días las mejores
                ofertas a un solo clic.
                </div>
                <div class="cssEtiquetaSuscribir">
                    Correo Electrónico <br>
                    <input name="ctl00$txtSuscripcion" type="text" id="ctl00_txtSuscripcion" class="form-control " style="width:100%;">
                </div>  
                <div id="SuscribirLine"> 
                    <div id="SuscribirBoton"> 
                        <input type="image" name="ctl00$btnSuscribirme" id="ctl00_btnSuscribirme" border="0" src="./Proceso de Pago - Cuponidad_files/suscribirme_cupon_cuponidad.png" style="height:35px;width:155px;border-width:0px;"> 
                            <br>
                        <span id="ctl00_lblMsjSuscripcion" style="color:Red;"></span>
                    </div>
                </div>          
            </div> 
    </div></div><ul id="ui-id-5" tabindex="0" class="ui-menu ui-widget ui-widget-content ui-autocomplete ui-front" style="display: none;"></ul><div role="status" aria-live="assertive" aria-relevant="additions" class="ui-helper-hidden-accessible"></div><div id="onesignal-bell-container" class="onesignal-bell-container onesignal-reset onesignal-bell-container-bottom-right"><div id="onesignal-bell-launcher" class="onesignal-bell-launcher onesignal-bell-launcher-md onesignal-bell-launcher-bottom-right onesignal-bell-launcher-theme-default onesignal-bell-launcher-active" style="bottom: 75px; right: 5px;"><div class="onesignal-bell-launcher-button"><svg class="onesignal-bell-svg" xmlns="http://www.w3.org/2000/svg" width="99.7" height="99.7" viewBox="0 0 99.7 99.7" style="filter: drop-shadow(0 2px 4px rgba(34,36,38,0.35));; -webkit-filter: drop-shadow(0 2px 4px rgba(34,36,38,0.35));;"><circle class="background" cx="49.9" cy="49.9" r="49.9" style=""></circle><path class="foreground" d="M50.1 66.2H27.7s-2-.2-2-2.1c0-1.9 1.7-2 1.7-2s6.7-3.2 6.7-5.5S33 52.7 33 43.3s6-16.6 13.2-16.6c0 0 1-2.4 3.9-2.4 2.8 0 3.8 2.4 3.8 2.4 7.2 0 13.2 7.2 13.2 16.6s-1 11-1 13.3c0 2.3 6.7 5.5 6.7 5.5s1.7.1 1.7 2c0 1.8-2.1 2.1-2.1 2.1H50.1zm-7.2 2.3h14.5s-1 6.3-7.2 6.3-7.3-6.3-7.3-6.3z" style=""></path><ellipse class="stroke" cx="49.9" cy="49.9" rx="37.4" ry="36.9" style=""></ellipse></svg></div><div class="onesignal-bell-launcher-badge" style="filter: drop-shadow(0 2px 4px rgba(34,36,38,0));; -webkit-filter: drop-shadow(0 2px 4px rgba(34,36,38,0));;"></div><div class="onesignal-bell-launcher-message"><div class="onesignal-bell-launcher-message-body"></div></div><div class="onesignal-bell-launcher-dialog" style="filter: drop-shadow(0px 2px 2px rgba(34,36,38,.15));; -webkit-filter: drop-shadow(0px 2px 2px rgba(34,36,38,.15));;"><div class="onesignal-bell-launcher-dialog-body"></div></div></div></div><iframe src="./Proceso de Pago - Cuponidad_files/webPushAnalytics.html" style="display: none;"></iframe><ul id="ui-id-6" tabindex="0" class="ui-menu ui-widget ui-widget-content ui-autocomplete ui-front" style="display: none;"></ul><div role="status" aria-live="assertive" aria-relevant="additions" class="ui-helper-hidden-accessible"></div>
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
    </body></html>
