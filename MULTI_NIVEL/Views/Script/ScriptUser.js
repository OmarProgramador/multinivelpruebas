
var data = new Array();

window.onload = function () {
    var params = null;
    Send("UserC", params, samirSito);

    // document.getElementById("divProgressBar").style.display = "inline";
}


function samirSito() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var texto = '' + httpRequest.responseText;
            var data = texto.split('¬');

        }
    }
}