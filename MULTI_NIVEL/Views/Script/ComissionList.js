var anwser = "";
var excel = "";
var rows = new Array();
var countRows = 0;
var pageCurrent = 0;


window.onload = function () {
    
    var params = "params="+getParameterByName('variable1');

    //alert(params)
    //document.getElementById("divProgressBar").style.display = "inline";
    Get("ComissionListC", params, ShowTable);
}

function showData(rowsData, pgo, pend) {

    anwser = '';
    for (var i = pgo; i < pend; i++) {

        var part = rowsData[i].split('$');
        var row = part[0].split('|');
        anwser += "<tr role='row' class='even'>";
        anwser += "<td>" + row[0] + "</td>";
        anwser += "<td>" + DateFormat(row[1]) + "</td>";
        anwser += "<td>" + row[2] + "</td>";
        if (part[0].split('|')[4] == '1') { part[0].split('|')[4] = 'No Transferido'; } else { part[0].split('|')[4] = 'Transferido'; }
        anwser += "<td>" + part[0].split('|')[4] + "</td>";
        anwser += "<td><button id='' class='btn btn-sm btn-primary'  type='button' onclick=ShowModal(\"" + part[1] + "\")>Ver Detalle</button></td></tr>";

    }
    document.getElementById('tblComissions').innerHTML = anwser;

    var numPages2 = parseInt(document.getElementById('cboNumRows').value);

    var hasta = parseFloat(rows.length / numPages2);
    /*desactivar siguiente*/
    if (parseFloat(pageCurrent) > hasta) {
        disabledButton(1);
    }
    /*anterior*/
    if (pageCurrent === 1) {
        disabledButton(0);
    }
}

function pagination(numRows) {

    var go = parseInt((parseInt(pageCurrent) - parseInt("1")) * parseInt(numRows));
    var end = parseInt(parseInt(go) + parseInt(numRows));

    if (end > rows.length) {
        end = rows.length;
    }

    var passar = new Array();
    for (var i = go; i < end; i++) {
        passar[i] = rows[i];
    }
    /*habilitamos los botones*/
    document.getElementById("DataTables_Table_0_previous").className = "paginate_button previous";
    document.getElementById("DataTables_Table_0_next").className = "paginate_button next";

    showData(passar, go, end);
    document.getElementById('lblNumPageCurrent').innerHTML = pageCurrent;
    document.getElementById("divProgressBar").style.display = "none";
}


function cboNumRows_OnChange() {
    pageCurrent = parseInt("1");
    document.getElementById('lblNumPageCurrent').innerHTML = pageCurrent;
    var numPages = parseInt(document.getElementById('cboNumRows').value);
    pagination(numPages);
}


function buttonPages(type) {

    var numPages2 = parseInt(document.getElementById('cboNumRows').value);
    var hasta = parseFloat(rows.length / numPages2);
    /*siguiente*/
    if (type === 1 && parseFloat(pageCurrent) < hasta) {
        pageCurrent += parseInt("1");
    }
    /*anterior*/
    if (type === 0 && pageCurrent !== 1) {
        pageCurrent -= parseInt("1");
    }
    var numPages = parseInt(document.getElementById('cboNumRows').value);
    pagination(numPages);

}

function ShowTable() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var htmlAcordion = "";
            var anwser = '' + httpRequest.responseText;
            var item = anwser.split('^');
            var dataBank = item[item.length-1];
            for (var i = 0; i < item.length-1; i++) {
                htmlAcordion += AcordionView(item[i] + '&' + dataBank , i);
                htmlAcordion += "<br />";
            }

            document.getElementById("info_commission").innerHTML = htmlAcordion;
            document.getElementById("divProgressBar").style.display = "none";
        }
    }
}

function AcordionView(anwser, num) {
    let amountTotal = 0.00;
    let dataBank = anwser.split('&')[1];
    let texto = (anwser.split('&')[0]).split('$')[0];
    let levels = anwser.split('$')[1];
    let level1 = parseInt(levels.split('|')[0]);
    let level2 = parseInt(levels.split('|')[1]);
    let table = "";
    let valueInt;
    let codeDate;
    let request;
    if (texto !== '') {

        let rows = texto.split('¬');
        let dateServidor = rows[0].split('|')[2];

        table += "<div class='accordion bg-plomo' id='accordionExample'><div class='card'><div class='card-header' id='headingOne'><h2 class='mb-0'>";
        table += "<button class='btn btn-link' type='button' data-toggle='collapse' data-target='#collapse" + num + "' aria-expanded='true' aria-controls='collapse" + num + "'>";
        table += "Periodo del " + DateInterval(dateServidor) + "<i class='fas fa-caret-down'></i></button></h2></div><div id='collapse" + num + "' class='collapse' aria-labelledby='headingOne'";
        table += "data-parent='#accordionExample'><div class='card-body'>";
        table += "<hr>";
        table += "<table class='table table-hover'>";
        table += "<tr>";
        table += "<th>Descripción</th>";
        table += "<th>Nombres</th>";
        table += "<th>Puntos</th>";
        table += "<th>Fecha</th>";
        table += "<th>Porcentaje</th>";
        table += "<th>Monto S/.</th>";
        table += "<th>Cobro Activo ?</th>";
        table += "<th>Cobro Nivel?</th>";
        table += "</tr>";

        let row;
        for (var i = 0; i < rows.length; i++) {
            row = rows[i].split('|');
            table += "<tr>";
            table += "<td>" + row[8] + " </td>";
            table += "<td>" + row[0] + " </td>";
            table += "<td>" + row[1] + " </td>";
            table += "<td>" + row[2] + " </td>";
            table += "<td>" + row[3] + " </td>";
            table += "<td>" + row[4] + " </td>";
            codeDate = row[9];
            
            if (row[10] >= 1) {
                request = "Transferido"
            } else {
                request = "NoTransferido"
            }
            if (row[5] === "1") {
                row[5] = "SI";
            } else {
                row[5] = "NO";
            }
            if (row[7] === "BAF") {
                if (parseInt(row[6]) <= level1) {
                    row[6] = "SI";
                } else {
                    row[6] = "NO";
                }
            }
            if (row[7] === "RES") {
                if (parseInt(row[6]) <= level2) {
                    row[6] = "SI";
                } else {
                    row[6] = "NO";
                }
            }
            if (row[7] === "MAN") {
                row[6] = "SI";
            }
            table += "<td>" + row[5] + " </td>";
            table += "<td>" + row[6] + " </td>";
            table += "</tr>";
            if (row[5] === "SI" && row[6] === "SI") {
                amountTotal += parseFloat(row[4]);
            }
        }


        //example
        table += "<tr style='background-color:yellow'>" + "<td >TOTAL A COBRAR : </td><td></td><td></td><td></td><td></td><td></td><td></td><td>S/" + amountTotal + "</td></tr>";
        table += "<tr style='background-color:RED'>" + "<td><input type='button' data-target='#mdlImages'   value='ABONAR' onclick=modalR(" + dataBank.split('|')[0] + ",'" + dateServidor + "'" + ",'" + amountTotal + "') /></td><td >" + dataBank + '|' + codeDate + '|' + request +"  </td></tr>";
        table += "</table>";
        table += "</div></div></div>";
        table += "</div>";

    }
    return table;
}


function helloFromServer() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {

            var texto = '' + httpRequest.responseText;
            var acordionHtml = "";
            if (texto !== '') {
                var array = texto.split('~');
                var fecha = "";
                var ciclo = "";
                for (var i = 0; i < array.length; i++) {
                    var rowsData = array[i].split('¬');
                    for (var j = 0; j < rowsData.length; j++) {
                        var part = rowsData[j].split('$');
                        var row = part[0].split('|');
                        fecha = DateFormat(row[1]);
                        ciclo = fecha;
                    }
                    acordionHtml += itemCollapse(array[i], i, fecha);
                }
            }
            document.getElementById("info_commission").innerHTML = acordionHtml;

            document.getElementById("divProgressBar").style.display = "none";

        }
    }
}

function disabledButton(option) {

    document.getElementById("DataTables_Table_0_previous").className = "paginate_button previous";
    document.getElementById("DataTables_Table_0_next").className = "paginate_button next";

    if (option === 0) {
        document.getElementById("DataTables_Table_0_previous").className += " disabled";
    }
    if (option === 1) {
        document.getElementById("DataTables_Table_0_next").className += " disabled";
    }
}

function createExcel() {
    excel += "<html><body>";
    excel += "<table><thead><th><td>Uno</td></th><th><td>Dos</td></th><th><td>Tres</td></th><th><td>Cuatro</td></th></thead><tbody>";

    for (var i = 0; i < rows.length; i++) {
        var row = rows[i].split('|');
        excel += "<tr><td>" + row[0] + "</td></tr>";
        excel += "<tr><td>" + row[1] + "</td></tr>";
        excel += "<tr><td>" + row[2] + "</td></tr>";
    }
    excel += "</tbody></table></body></html>";
}

function DownLoadExcel() {
    createExcel();

    var blob = new Blob([excel], { type: 'application/vnd.ms-excel' });
    if (navigator.appVersion.toString().indexOf('.NET') > 0) {
        window.navigator.msSaveBlob(blob, "Commissions.xls");
    } else {
        this.download = "Commissions.xls";
        this.href = window.URL.createObjectURL(blob);
    }
    alert('excel ');
}

function modalR(n,date,amount) {
    
    params = "params="+n + '|' + date + '|' + amount;
    GetDos("TransactionC", params, modalS);
}

function modalS(ans) {
    if (ans == 'True') {
        alert("Pago Exitoso");
        location.reload(true);
    } else {
        alert("Este pago ya fue efectuado")
        location.reload(true);
    }
    
}

function ShowModal(detail) {
    let body = "<table class='table'>";
    body += "<tr><th>Nombres</th><th>Puntos</th><th>Monto S/.</th><th>Fecha</th></tr>";
    document.getElementById('seeDetail').innerHTML = body;
    if (detail !== '') {

        let rows = detail.split('^');
        for (var i = 0; i < rows.length; i++) {
            let row = rows[i].split('|');
            body += "<tr>";
            body += "<td>" + ReplaceAll(row[0], '_', ' ') + "</td>";
            body += "<td>" + row[1] + "</td>";
            body += "<td>S/. " + row[2] + "</td>";
            body += "<td>" + DateFormat(row[3]) + "</td>";
            body += "</tr>";
        }
        body += "</table>";
        document.getElementById('seeDetail').innerHTML = body;
    }
    $('#mdlSeeDetail').modal('show');
}

function itemCollapse(data, item, fecha) {
    let response = '';
    response = "<div class='panel-group' id='accordion'><div style='padding: 5px;margin:5px auto'> <a data-toggle='collapse' data-parent='#accordion' href='#collapse" + item + "'>";
    response += "<div class='panel-heading btn btn-block' style='color:white;width:100%;font-size:16px; background-color:rgb(100,116,140)'>Fecha " + fecha + "</div></a><div id='collapse" + item + "' class='panel-collapse collapse'>";
    response += "<div class='panel-body' style='margin-right: 9px; margin-left: 9px;'><div class=' ' id='cssbox'><div class='row sombra'><div id='divStarterKithh' class='row minimalSpacing'><div class='col-md-12' >";
    response += "<div class='csspqts' ><div class='panel-heading' >";

    var table = '<div class="table-responsive"><table class="table table-striped">';
    table += "<tr>";
    table += "<th>Descripcion</th>";
    table += "<th>Fecha de Publicación</th>";
    table += "<th>Comisión</th>";
    table += "<th>Puntos</th>";
    table += "<th>Estatus</th>";
    table += "<th></th>";
    table += "</tr>";
    var rowsData = data.split('¬');
    for (var i = 0; i < rowsData.length; i++) {
        var part = rowsData[i].split('$');
        var row = part[0].split('|');
        table += "<tr>";
        table += "<td>" + row[0] + "</td>";
        table += "<td>" + DateFormat(row[1]) + "</td>";
        table += "<td>" + row[2] + "</td>";
        table += "<td>" + row[3] + "</td>";
        if (row[4] === '1') { row[4] = 'No Transferido'; } else { row[4] = 'Transferido'; }
        table += "<td>" + row[4] + "</td>";
        table += "<td><button id='' class='btn btn-sm btn-primary'  type='button' onclick=ShowModal(\"" + part[1] + "\")>Ver Detalle</button></td></tr>";
    }
    table += '</tbody></table></div>';
    response += table;
    response += "</div></div></div></div></div></div></div></div></div></div></div></div></div>";

    return response;
}
