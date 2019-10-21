var anwser = "";
var excel = "";
var rows = new Array();
var countRows = 0;
var pageCurrent = 0;
var rowsAcor = 0;
var AmountRES = 0;
var AmountBAR = 0;
var AmountMAN = 0;
var AmountBAF = 0;
var AmountAUTO = 0;
var AmountLOG = 0;
var equi = 0;
var dire = 0;


window.onload = function () {
    document.getElementById("afi").innerHTML = "0";
    document.getElementById("resi").innerHTML = "0";
    document.getElementById("rapi").innerHTML = "0";
    //document.getElementById("manti").innerHTML = "0";
    //document.getElementById("auto").innerHTML = "0";
    document.getElementById("log").innerHTML = "0";
    document.getElementById("toti").innerHTML = "0";
    document.getElementById("equi").innerHTML = "0";
    var params = null;
    document.getElementById("divProgressBar").style.display = "inline";
    Get("CommissionsData", params, ShowTable);
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
        if (part[0].split('|')[4] === '1') { part[0].split('|')[4] = 'No Transferido'; } else { part[0].split('|')[4] = 'Transferido'; }
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
            if (anwser !== "") {
                var item = anwser.split('^');
                for (var i = 0; i < item.length; i++) {
                    htmlAcordion += AcordionView(item[i], i);
                    htmlAcordion += "<br />";
                }

            }            
            document.getElementById("info_commission").innerHTML = htmlAcordion;      
            document.getElementById("divProgressBar").style.display = "none";
        }
    }
}

function AcordionView(anwser, num) {
    let table = "";
    if (anwser !== '' ) {
        let amountTotal = 0.00;
        let texto = anwser.split('$')[0];
        let leveldos = anwser.split('$')[1];
        let levels = leveldos.split('|');
        let level1 = parseInt(levels[0]);
        let level2 = parseInt(levels[1]);
        let dateTrans = "";
        let amountTrans = "";
        let statusTrans = "";
        if (levels.length > 3) {
            dateTrans = levels[2];
            amountTrans = levels[3];
            if (levels[4] === "1") {
                levels[4] = "<span class='label-success'>Abonado</span>";
            } else {
                levels[4] = "<span class='label-danger'>No Abonado</span>";
            }
            statusTrans = levels[4];
        }
       
        if (texto !== '') {

            rowsAcor = texto.split('¬');
            
            let dateServidor = rowsAcor[0].split('|')[2];

            table += "<div class='accordion' id='accordionExample'>";
            table += "<div class='card'> <div class='card-header' id='headingOne'><h2 style='' class='mb-0'>";
            table += "<div style='font-family: open sans, Helvetica Neue, Helvetica, Arial, sans-serif; color:black'>";
            table += "<div class='card-body table-responsive'>";
            table += "<table class='table thead-dark table-bordered'>";
            table += "<thead style='font-size: 15px'>";
            table += "<tr>";
            table += "<th>Periodo</th>";
            table += "<th>Fecha de Publicación </th>";
            table += "<th>Comisión</th>";
            table += "<th></th>";
            table += "</tr>";
            table += "</thead>";
            table += "<tr>";
            table += "<td><div color:black;font-size:14px'>" + DateInterval(dateServidor) + " </div> </td>";
            var di = DateInterval(dateServidor);
            document.getElementById("di").innerHTML = di.toString();
            if (levels.length > 3) {
                table += "<td> " + DateFormat(dateTrans) + "</td>";
                table += "<td>S/." + amountTrans + "</td>";
            } else {
                table += "<td> -- </td>";
                table += "<td> -- </td>";
            }
            table += "<td> <button type='button' id='myBtn' data-toggle='modal' data-target='#myModal' style='color:white;' class='btn btn-xl m-t-n-xs ' >Resumen </button><button style='background-color:white' class='btn ' type='button' data-toggle='collapse' data-target='#collapse" + num + "' aria-expanded='true' aria-controls='collapse" + num + "'>ver detalle</button></div></td>";
            table += "</tr>";
            table += "</table>";
            table += "</div>";
            table += " ";
            table += "</h2>";
            table += "</div > <div id='collapse" + num + "' class='collapse' aria-labelledby='headingOne'";
            table += "data-parent='#accordionExample'>";
            table += "<div class='card-body table-responsive'>";
            table += "<hr>";
            table += "<table class='table table-hover'>";
            table += "<tr>";
            table += "<th>#</th>";       
            table += "<th>Nombres</th>";
            table += "<th>Descripción</th>";
            table += "<th>Nivel</th>";
            table += "<th>Puntos</th>";
            table += "<th>Fecha</th>";
            table += "<th>Porcentaje</th>";
            table += "<th>Monto S/.</th>";
            table += "<th>Cobro Activo ?</th>";
            table += "<th>Cobro Nivel?</th>";
            table += "</tr>";

            for (var i = 0; i < rowsAcor.length; i++) {
                let row = rowsAcor[i].split('|');
             
                if (i > 0) {
                    if (rowsAcor[i - 1].split('|')[0] !== row[0]) {
                        
                        table += "<tr>";
                        table += "<td colspan='10'>.</td>";              
                        table += "</tr>";
                    }
                } 

                table += "<tr>";
                table += "<td>" + (i + 1).toString() + " </td>";
                table += "<td>" + row[0] + " </td>";
                table += "<td>" + row[8] + " </td>";              
                table += "<td>" + row[6] + " </td>";
                table += "<td>" + row[1] + " </td>";
                table += "<td>" + DateFormat(row[2]) + " </td>";
                table += "<td>" + row[3] + " </td>";
                table += "<td class=' pr-20'>" + row[4] + " </td>";
                if (row[5] === "1" || row[5] === "6" || row[5] === "7") {
                    row[5] = "SI";
                  
                } else {
                    row[5] = "NO";
                }
                if (row[7] === "BAF") {
                    if (parseInt(row[6]) <= level1 && parseInt(row[6]) > 0) {
                        if (parseInt(row[6]) == 1) {
                            dire = dire + parseFloat(row[4]);
                        }
                        else {
                            equi = equi + parseFloat(row[4]);
                        }
                        row[6] = "SI";
                        AmountBAF = AmountBAF + parseFloat(row[4]);
                        document.getElementById("afi").innerHTML = dire.toFixed(2).toString();
                        document.getElementById("equi").innerHTML = equi.toFixed(2).toString();
                        
                    } else {
                        row[6] = "NO";
                    }
                }
                if (row[7] === "RES") {
                    if (parseInt(row[6]) <= level2) {
                        row[6] = "SI";
                        AmountRES = AmountRES + parseFloat(row[4]);
                        document.getElementById("resi").innerHTML = AmountRES.toFixed(2).toString();
                    } else {
                        row[6] = "NO";
                    }
                }
                if (row[7] === "BAR") {
                    if (row[6] === "1") {
                        row[6] = "SI";
                        AmountBAR = AmountBAR + parseFloat(row[4]);
                        document.getElementById("rapi").innerHTML = AmountBAR.toFixed(2).toString();
                    } else {
                        row[6] = "NO";
                    }   
                }
                if (row[7] === "MAN") {
                    row[6] = "SI";
                    AmountMAN = AmountMAN + parseFloat(row[4]);
                    document.getElementById("manti").innerHTML = AmountMAN.toFixed(2).toString();
                }
                if (row[7] === "AUT") {
                    row[6] = "SI";
                    AmountAUTO = AmountAUTO + parseFloat(row[4]);
                    document.getElementById("auto").innerHTML = AmountAUTO.toFixed(2).toString();
                }
                if (row[7] === "LOG") {
                    row[6] = "SI";
                    AmountLOG = AmountLOG + parseFloat(row[4]);
                    document.getElementById("log").innerHTML = AmountLOG.toFixed(2).toString();
                }
                if (row[5] === "SI" && row[6] === "SI") {
                    amountTotal += parseFloat(row[4]);
                    document.getElementById("toti").innerHTML = amountTotal.toFixed(2).toString();
                }
                //mostrar 
                if (row[5] === "SI") {
                    row[5] = "<span class='label-success'>Si</span>";
                }
                else {
                    row[5] = "<span class='label-danger'>No</span>";
                }
                if (row[6] === "SI") {
                    row[6] = "<span class='label-success'>Si</span>";
                }
                else {
                    row[6] = "<span class='label-danger'>No</span>";
                }
                table += "<td class=''>" + row[5] + " </td>";
                table += "<td class=''>" + row[6] + " </td>";
                table += "</tr>";
            }
            //example
            table += "<tr style='background-color:yellow'>" + "<td>TOTAL A COBRAR : </td><td></td><td></td><td></td><td></td><td></td><td></td><td class='pr-20'>S/" + amountTotal.toFixed(2) + "</td>";
            table += "</table>";
            table += "</div></div></div>";
            table += "</div>";
        }
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

function ShowModal(detail) {
    let body = "<table class='table'>";
    body += "<tr><th>Nombres</th><th>Puntos</th><th>Monto S/.</th><th>Fecha</th></tr>";
    document.getElementById('seeDetail').innerHTML = body;
    if (detail !== '') {
       
        let rows = detail.split('^');
        for (var i = 0; i < rows.length; i++) {
            let row = rows[i].split('|');
            body += "<tr>";
            body += "<td>" + ReplaceAll(row[0],'_', ' ') + "</td>";
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

function itemCollapse(data,item,fecha) {
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
