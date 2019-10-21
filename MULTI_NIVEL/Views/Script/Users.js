var data = '';
var rows = new Array();
window.onload = function () {
    document.getElementById("divProgressBar").style.display = "inline";
    var params = null;
    Send("UserC", params, samirSito);

   // document.getElementById("divProgressBar").style.display = "inline";
    /*MERGE*/
}


function samirSito() {
    
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var texto = '' + httpRequest.responseText;
            //data = texto;
            //alert(texto);
            // var data = texto.split('¬');
            showData(texto);
            document.getElementById("divProgressBar").style.display = "none";
        }
    }
}

function showData(data) {
    anwser = '';
    var listRegister = data.split('¬');
    for (var i = 0; i <= listRegister.length-1; i++) {
        var listColumns = listRegister[i].split('|');
        anwser += "<tr role='row' class='even'>";
        for (var q = 0; q <= listColumns.length - 1; q++) {
            anwser += "<td>" + listColumns[q] + "</td>";
        }
        anwser += "<td><input type='button' data-toggle='modal' data-target='#mdlImages' id='" + listColumns[0] + "'  onclick=modalR('" + listColumns[0] + "');  value='Verificar'/></td>";  
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

function modalR(data) {
    //Send("ReceiptsUser", 'dd', ej);
    alert(data)
    window.location.href = 'ReceiptsUser.aspx?action=1&variable1=' + (data);

}

function ej() {
    alert('listo')
}
