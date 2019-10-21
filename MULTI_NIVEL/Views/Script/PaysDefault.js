

window.onload = function () {
    //userName = encodeURI(document.cookie);
    //params = "Key=" + userName;
    var params = "";
    Send('PaysDefaultC', params, Http);
    //Send('CurrentPointsC', params, Http2);
}

function Http() {

    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            //var parameters = '' + httpRequest.responseText;
            var data = '' + httpRequest.responseText;
            // alert(texto);

            anwser = '';
            var listRegister = data.split('¬');
            for (var i = 0; i <= listRegister.length - 1; i++) {
                var listColumns = listRegister[i].split('|');
                anwser += "<tr role='row' class='even'>";
                for (var q = 0; q <= listColumns.length - 1; q++) {
                   
                    anwser += "<td>" + listColumns[q] + "</td>";
                }
                anwser += "<td><input type='button' data-toggle='modal' data-target='#mdlImages' id='" + listColumns[0] + "'  onclick=modalR('" + listColumns[0] + "');  value='Suspender'/></td>";
            }
            document.getElementById('tblPayments').innerHTML = anwser;
            var numPages2 = parseInt(document.getElementById('cboNumRows').value);
            document.getElementById("divProgressBar").style.display = "none";
            var hasta = parseFloat(rows.length / numPages2);
            if (parseFloat(pageCurrent) > hasta) {
                disabledButton(1);
            }
            if (pageCurrent === 1) {
                disabledButton(0);
            }
        }
    }
}

function modalR(id) {
    document.getElementById("divProgressBar").style.display = "inline";
    var params = "params=" + id ;
    Send('DisabledAccountC', params, modal);
   // alert(id)
}

function modal() {
    //alert(httpRequest.responseText);
    document.getElementById("divProgressBar").style.display = "none";
    location.reload();
}