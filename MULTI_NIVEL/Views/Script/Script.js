
function loadPage() {
    document.getElementById("divProgressBar").style.display = "inline";
}




function nobackbutton() {
    window.location.hash = "no-back-button";
    window.location.hash = "Again-No-back-button" //chrome
    window.onhashchange = function () { window.location.hash = "no-back-button"; }
}


function getXMLHttpRequest() {
    if (window.ActiveXObject) {
        try {
            return new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                return new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e1) {
                return null;
            }
        }
    } else if (window.XMLHttpRequest) {
        return new XMLHttpRequest();
    } else {
        return null;
    }
}

function sendRequest(url, params, callback, method) {
    httpRequest = getXMLHttpRequest();
    var httpMethod = method ? method : 'GET';
    if (httpMethod !== 'GET' && httpMethod !== 'POST') {
        httpMethod = 'GET';
    }
    var httpParams = (params === null || params === '') ? null : params;
    var httpUrl = url;
    if (httpMethod === 'GET' && httpParams !== null) {
        httpUrl = httpUrl + "?" + httpParams;
    }
    httpRequest.open(httpMethod, httpUrl, true);
    httpRequest.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    httpRequest.onreadystatechange = callback;
    httpRequest.send(httpMethod === 'POST' ? httpParams : null);
}


function Get(url, params, callback) {
    //var params = null;
    //var params = "id=" + encodeURIComponent("");
    sendRequest(url + ".aspx", params, callback, "GET");
}
function Send(url, params, callback) {
    //var params = null;
    //var params = "id=" + encodeURIComponent("");
    sendRequest(url + ".aspx", params, callback, "POST");
}
function SendDos(url, params, callback) {
    //var params = null;
    //var params = "id=" + encodeURIComponent("");
    sendRequestDos(url + ".aspx", params, callback, "POST");
}
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function DateFormat(date) {
    if (date.trim() !== "") {  
        let array = date.split('-');
        return array[2] + '/' + array[1] + '/' + array[0];
    } else {
        return "";
    }
}

function DateHasta(_date) {
    var fecha = new Date(_date);

    // Añades los meses
    fecha.setMonth(fecha.getMonth() + 1);
    fecha.setDate(fecha.getDate());
    var mes = (fecha.getMonth() + 1);
    var mess = mes;
    if (mes < 10) {
        mess = "0" +  mes.toString();
    }

    return fecha.getDate() + '/' + mess + '/' + fecha.getFullYear();
}

function n() {
    //alert('it is working on script.js')
    
    var userName = encodeURI(document.cookie);
    Send('UpdateNotifC', userName, Httpr);
    document.getElementById('globo').style.display = "none";
}

function Httpr() {

    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var texto = '' + httpRequest.responseText;
            var arrayanwser = texto.split('¬');
           // document.getElementById("divProgressBar").style.display = "none";
         //   alert(texto);

          //  window.open("http://www.inresorts.club/Views/Users.aspx");
        }
    }
}

function ReplaceAll(str, find, replace) {
    return str.replace(new RegExp(find, 'g'), replace);
}

function CboSelectedText(selectName) {
    var select = document.getElementById(selectName);
    return select.options[select.selectedIndex];  
}

function DateInterval(date1) {
    let array = date1.split('-');
    let date = new Date(date1);
    let primerDia = new Date(date.getFullYear(), date.getMonth(), 1);
    let ultimoDia = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    var day = ultimoDia.getDate();
    let hasta = '';
    if (array[2] <= 15) {
        hasta = '' + '15' + '/' + array[1] + '/' + array[0] + '';
        array[2] = "01";
    } else {
        hasta = '' + day + '/' + array[1] + '/' + array[0] + '';
        array[2] = "16";
    }
    return '' + array[2] + '/' + array[1] + '/' + array[0] + ' - ' + hasta;
}


function GetDos(url, params, callback) {
    //var params = null;
    //var params = "id=" + encodeURIComponent("");
    sendRequestDos(url + ".aspx", params, callback, "GET");
}
function sendRequestDos(url, params, callback, method) {
    httpRequest = getXMLHttpRequest();
    var httpMethod = method ? method : 'GET';
    if (httpMethod !== 'GET' && httpMethod !== 'POST') {
        httpMethod = 'GET';
    }
    var httpParams = (params === null || params === '') ? null : params;
    var httpUrl = url;
    if (httpMethod === 'GET' && httpParams !== null) {
        httpUrl = httpUrl + "?" + httpParams;
    }
    httpRequest.open(httpMethod, httpUrl, true);
    httpRequest.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    httpRequest.onreadystatechange = function () {
        if (httpRequest.readyState === 4) {
            if (httpRequest.status === 200) {
                callback(httpRequest.responseText);
            }
        }
    };
    httpRequest.send(httpMethod === 'POST' ? httpParams : null);
}

function validationNumber(number) {
    /*/^([0-9])*$/*/
    if (!/^\d*\.?\d*$/.test(number)) {
        return false;
    }
    return true;
}