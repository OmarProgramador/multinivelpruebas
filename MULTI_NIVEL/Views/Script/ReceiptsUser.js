window.onload = function () {
    document.getElementById("divProgressBar").style.display = "inline";

    var thing = getParameterByName('variable1');
    //alert(thing)
    var params = "action=0";
    Send('ReceiptsUserC', params, Http);
}
function Httpa() {

    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var texto = '' + httpRequest.responseText;
            var arrayanwser = texto.split('¬');
            document.getElementById("divProgressBar").style.display = "none";
            alert(arrayanwser[1]);
            // window.open("http://www.inresorts.club/Views/Users.aspx");
            location.reload();


            //data = texto;
            //alert(texto);
            // var data = texto.split('¬');
            //showData(texto);
        }
    }
}

function modalA(id, _quote) {

    let quote = parseFloat(_quote);

    document.getElementById("divProgressBar").style.display = "inline";

    var params = "id=" + id + "&action=1" + "&quote=" + quote.toString();
    Send('ReceiptsUserC', params, Httpa);
}
function modalR(id) {
    document.getElementById("divProgressBar").style.display = "inline";

    var params = "id=" + id + "&action=3";
    Send('ReceiptsUserC', params, Httpa);
}
function Httpr() {

    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var texto = '' + httpRequest.responseText;
            var arrayanwser = texto.split('¬');
            document.getElementById("divProgressBar").style.display = "none";
            alert(arrayanwser[1]);

            window.open("http://www.inresorts.club/Views/Users.aspx");
        }
    }
}
function Http() {

    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var response = '' + httpRequest.responseText;
            //var collapse= showData(texto);
            if (response === "") {
                document.getElementById("divProgressBar").style.display = "none";

            } else {
                var schedules = response.split('$');
                var collapse = '';
                for (var i = 0; i < schedules.length; i++) {
                    let tschedule = schedules[i].split('¬');
                    let membresia = tschedule[i].split('|')[0];
                    let fullName = membresia.split('^');
                    collapse += showData(schedules[i], i, fullName[0].toUpperCase() + ' adquirida en la fecha ' + DateFormat(fullName[1]) + ' ' + fullName[2]);
                }
                document.getElementById('zona-collapse').innerHTML = collapse;
                document.getElementById("divProgressBar").style.display = "none";
                //document.getElementById("divProgressBar").style.display = "none";

                //data = texto;
                //alert(texto);
                // var data = texto.split('¬');
                //showData(texto);
            }
        }
    }

    function showData(schedule, i, membresia) {
        anwser = '';
        schedule = schedule.split('¬');
        //for (var i = 0; i <= schedule.length - 1; i++) {
        // var listRegister = schedule[i].split('|');
        // let listColumns = listRegister[0].split('^')[2];

        //anwser += "<tr >";
        anwser = "<div class='panel-group' id='accordion'><div style='padding: 5px;margin:5px auto'> <a data-toggle='collapse' data-parent='#accordion' href='#collapse" + i + "'>";
        anwser += "<div class='panel-heading btn btn-block' style='color:white;width:100%;font-size:16px; background-color:rgb(100,116,140)'>" + membresia + "</div></a><div id='collapse" + i + "' class='panel-collapse collapse'>";
        anwser += "<div class='panel-body' style='margin-right: 9px; margin-left: 9px;'><div class=' ' id='cssbox'><div class='row sombra'><div id='divStarterKithh' class='row minimalSpacing'><div class='col-md-12' >";
        anwser += "<div class='csspqts' ><div class='panel-heading' >";
        var table = '<div class="table-responsive"><table class="table table-striped">';
        table += '<thead>';
        table += '<th>Descripcion</th>';
        table += '<th>Fecha</th>';
        table += '<th>Capital</th>';
        table += '<th>Amortizacion</th>';
        table += '<th>Interes</th>';
        table += '<th>Cuota</th>';
        table += '<th>Observaciones</th>';
        table += '<th>Puntaje</th>';
        table += '<th>Estado</th>';

        table += '<th></th>';
        table += '<th></th>';
        table += '</thead><tbody>';
        for (var j = 0; j < schedule.length; j++) {
            var list = schedule[j].split('|');
            let id = list[0].split('^')[3];
            table += '<tr>';
            table += '<td>' + list[1] + '</td>';
            table += '<td>' + DateFormat(list[2]) + '</td>';
            table += '<td>' + list[3] + '</td>';
            table += '<td>' + list[4] + '</td>';
            table += '<td>' + list[5] + '</td>';
            table += '<td>' + list[6] + '</td>';
            table += '<td>' + list[7] + '</td>';
            table += '<td>' + list[8] + " " + "Pts" + '</td>';
            if (list[9] === "1") {
                table += '<td>Pagado</td>';
                if (list[10] === "") {
                    table += '<td></td>';
                    table += '<td></td>';
                } else {
                    table += '<td><a href="../Resources/RecibosRegister/' + list[10] + '" target="_blank"><img src="../Resources/RecibosRegister/' + list[10] + '" width="50" /></a></td>';
                    table += '<td></td>';
                }
            }
            else if (list[9] === "2") {
                
                if (list[10] === "") {
                    table += '<td>No ha subido recibo</td>';
                    table += '<td></td>';
                    table += '<td></td>';
                } else {
                    table += '<td>Por Verif.</td>';
                    table += '<td><a href="../Resources/RecibosRegister/' + list[10] + '" target="_blank"><img src="../Resources/RecibosRegister/' + list[10] + '" width="50"/></a></td>';
                    table += '<td></td>';
                    let amountPay = ReplaceAll(list[6], 'PEN', '');
                    amountPay = ReplaceAll(amountPay, 'USD', '');
                    amountPay = amountPay.toString().trim();
                    table += "<td><input type='button' data-toggle='modal' data-target='#mdlImages' id='" + id + "' value='Aceptar' onclick=modalA(" + id + ",'" + amountPay + "') /></td>";
                    table += "<td><input type='button' data-toggle='modal' data-target='#mdlImages' id='" + id + "' value='Rechazar' onclick='modalR(" + id + ");'/></td>";
                }
            }
            else if (list[9] === "3") {
                table += '<td>Rechazado</td>';
                // table += '<td><a href="Pagos.aspx?id=' + id + '&quota=' + list[6] + '" class="btn btn-primary" >Pagar</a></td>';

                table += '<td><a href="Pagos.aspx?id=' + id + '&quota=' + list[6] + '" class="" ></a></td>';
            } else {
                table += '<td>No Pagado</td>';
                // table += '<td><a href="Pagos.aspx?id=' + id + '&quota=' + list[6] + '" class="btn btn-primary" >Aceptar</a></td>';
                // table += '<td><a href="Pagos.aspx?id=' + id + '&quota=' + list[6] + '" class="btn btn-primary" >Amortizacion</a></td>';
                // table += "<td><input type='button' data-toggle='modal' data-target='#mdlImages' id='" + id + "' value='Rechazar' onclick='modalR(" + id + "," + list[6] + ");'/></td>";
            }
            //input type = 'button' data - toggle='modal' data - target='#mdlImages'
            table += '</tr>';
        }
        table += '</tbody></table></div>';
        anwser += table;
        anwser += "</div></div></div></div></div></div></div></div></div></div></div></div></div>";


        return anwser;
        //  document.getElementById("divProgressBar").style.display = "none";
        //var hasta = parseFloat(rows.length / numPages2);
        /*if (parseFloat(pageCurrent) > hasta) {
            disabledButton(1);
        }
        if (pageCurrent === 1) {
            disabledButton(0);
        }*/
    }




}