window.onload = function () {
   // alert("hola jeej");
    var params = null;
    Send("ComissionC", params, FromServer);
}

function FromServer() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
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
                anwser += "<td><input type='button' data-toggle='modal' data-target='#mdlImages' id='" + listColumns[1] + "'  onclick=modalR('" + listColumns[1] + "');  value='Verificar'/></td>";
            }
            document.getElementById('tblPayments').innerHTML = anwser;
            //var numPages2 = parseInt(document.getElementById('cboNumRows').value);
            document.getElementById("divProgressBar").style.display = "none";
            //var hasta = parseFloat(listRegister.length / numPages2);
            //if (parseFloat(numPages2) > hasta) {
            //    disabledButton(1);
            //}
            //if (numPages2 === 1) {
            //    disabledButton(0);
            //}

        }
    }
}

function modalR(data) {
    alert(data)
   // var params = "id="+n;
   // Send("ComissionList", params, c);
    window.location.href = 'ComissionList.aspx?action=1&variable1=' + (data);
}

function c(n) {
    alert('Verificado Correctamente')
    location.reload(true);
}