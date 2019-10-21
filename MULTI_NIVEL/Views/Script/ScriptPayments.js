var anwser = "";
var excel = "";
var rows = new Array();
var countRows = 0;
var pageCurrent = 0;
var idMembreship = "";
var numcuotes = "";
var symbol = "|";
var auxJs = "";
var tschedule;
var McArray;
var idMembershipRefu = 0;


window.onload = function () {

    let message = getParameterByName("msg");
    if (message !== "") {
        this.document.getElementById('mensajes').innerHTML = "<div class='alert alert-success' role='alert'><strong>Se efectuo el pago!!</strong> " + message +
            "<button type = 'button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>";
    }
    var params = null;
    Get("PaymentsData", params, helloFromServer);

    document.getElementById("divProgressBar").style.display = "inline";
}

function rejectNow() {

    $.ajax(
        {
            type: "POST",
            dataType: "json",
            url: "PaymentsC.aspx",
            data: { action: "reject", id: idMembershipRefu },
            success: function (answer) {
                location.reload();
            }
        }
    );
    location.reload();
}

function UserToRefuse(_id) {
    idMembershipRefu = parseInt(_id);


    $("#mdlRefuse").modal("show");

}


function showData(rowsData, pgo, pend) {
    anwser = '';
    let interr = 0;
    for (var i = pgo; i < pend; i++) {
        var row = rowsData[i].split('|');
        if (row.length > 0) {

            if (parseFloat(list[4]) === 0) {
                interr = 1;
            }
            anwser += "<tr role='row' class='even'>";
            anwser += "<td>" + row[1] + "</td>";
            anwser += "<td>" + row[2] + "</td>";
            anwser += "<td>" + row[3] + "</td>";
            anwser += "<td>" + row[4] + "</td>";
            anwser += "<td>" + row[5] + "</td>";
            anwser += "<td>" + row[6] + "</td>";
            if (row[9] === "0") {
                anwser += "<td>No Pagado</td>";
            } else if (row[9] === "2") {
                anwser += "<td>Por Verificarse</td>";
            } else if (row[9] === "1") {
                anwser += "<td>Pagado</td>";
            }
            else {
                anwser += "<td></td>";
            }
            if (row[9] === "0" && interr === 0) {
                auxJs = "888009999";
                anwser += "<td><input type='button' data-toggle='modal' id='" + row[0] + "' value='Pagar' onclick='modal(" + row[0] + "," + row[6] + ");'/></td>";
                anwser += "<td><input type='button' data-toggle='modal' data-target='#mdlImages' id='" + row[0] + "' value='Amortizar' onclick='modalR(" + row[0] + ");'/></td>";
            }
            else {
                anwser += "<td></td>";
                anwser += "<td></td>";
            }
        } else {
            document.getElementById("divProgressBar").style.display = "none";
        }
    }
    document.getElementById('tblPayments').innerHTML = anwser;

    var numPages2 = parseInt(document.getElementById('cboNumRows').value);
    document.getElementById("divProgressBar").style.display = "none";
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

function helloFromServer() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var response = '' + httpRequest.responseText;
            if (response === "") {
                document.getElementById("divProgressBar").style.display = "none";

            } else {
                var schedules = response.split('$');
                var collapse = '';
                for (var i = 0; i < schedules.length; i++) {
                    let tschedule = schedules[i].split('¬');
                    let membresia = tschedule[i].split('|')[0];
                    let fullName = membresia.split('^');
                    collapse += itemCollapse(schedules[i], i, fullName[0].toUpperCase() + ' adquiria en la fecha ' + DateFormat(fullName[1]) + ' ' + fullName[2]);
                }
                //alert("response: " + response)
                document.getElementById('zona-collapse').innerHTML = collapse;
                document.getElementById("divProgressBar").style.display = "none";
                /* pageCurrent = parseInt("1");
                 document.getElementById('lblNumPageCurrent').innerHTML = pageCurrent;
                 var data = texto.split('~');
                 rows = data[1].split('¬');
                 var numPages = parseInt(document.getElementById('cboNumRows').value);
                 pagination(numPages);*/
                var capsule = response.split('^')[2].split('|')[0];
                //window.location.href = 'PenaltyC.aspx?varible1=' + capsule;
            }
        }
    }
}

function itemCollapse(_schedule, i, membresia) {
    let response = '';
    let idmembershipac = _schedule.split('^')[3].split('|')[0];


    let schedule = _schedule.split('+')[0];

    tschedule = schedule.split('¬');

    let daysFree = _schedule.split('+')[1];
    let arraydaysFree = daysFree.split('|');

    let countCuota = 0;
    let quote = 0;
    for (var jk = 0; jk < tschedule.length; jk++) {
        let list1 = tschedule[jk].split('|');
        let descrit = list1[1].substring(0, 10);
        if (descrit === "Cuota nro:" && list1[9] === "0") {
            countCuota++;
            quote = list1[4];
        }
    }

    if (i >= 1) {

        McArray += '$' + schedule;
    } else {
        McArray = schedule;
    }

    if (quote == "0") {
        quote = "0.00 PEN";
    }

    let currencyCode = quote.substring(6, quote.length);

    quote = ReplaceAll(quote, 'PEN', '');
    quote = ReplaceAll(quote, 'USD', '');
    quote = quote.trim();


    response = "<div class='panel-group' id='accordion'><div style='padding: 5px;margin:5px auto'> <a data-toggle='collapse' data-parent='#accordion' href='#collapse" + i + "'>";
    response += "<div class='panel-heading btn btn-block' style='color:white;width:100%;font-size:16px; background-color:rgb(100,116,140)'>" + membresia + "</div></a><div id='collapse" + i + "' class='panel-collapse collapse'>";
    response += "<div class='panel-body' style='margin-right: 9px; margin-left: 9px;'><div class=' ' id='cssbox'><div class='row sombra'><div id='divStarterKithh' class='row minimalSpacing'><div class='col-md-12' >";
    response += "<div class='csspqts' ><div class='panel-heading' >";
    response += "<div class='row'><div class='col-sm-12'>";
    response += "<label style='font-weight:bold;font-size:15px;text-transform: uppercase;'>Operaciones: </label>";
    response += "</div></div>";
    response += "<div class='row'><div class='col-sm-12'>";
    response += "<input type='button' class='btn btn-primary' data-toggle='modal' data-target='#mdlImages' id='' value='Amortizar' onclick='modalR(1,1);'/>";
    response += "&nbsp;<input type='button' class='btn btn-primary' value='Adelanto de pago de cuotas'";
    response += "id='btnAdvancePay' onclick=btnAdvancePaym('" + countCuota + "','" + quote + "','" + idmembershipac + "','" + currencyCode + "') /> ";
    //response += '<a href="Advancepay.aspx?id=' + idmembershipac + '" class="btn btn-primary" >Adelanto el pago de cuotas</a>';
    response += "</div></div>";
    if (arraydaysFree[0] !== "0") {
        response += "<div class='text-right'><h3>" + arraydaysFree[0] + " de " + arraydaysFree[1] + " dias utilizados de Holgura.</h3></div>";
    }
    response += "<br />";

    var table = '<div class="table-responsive"><table class="table table-striped">';
    table += '<thead>';
    table += '<th>Descripcion</th>';
    table += '<th>Fecha de vencimiento</th>';
    table += '<th>Capital</th>';
    table += '<th>Amortizacion</th>';
    table += '<th>Interes</th>';
    table += '<th>Cuota</th>';
    table += '<th>Observaciones</th>';
    // table += '<th>Puntaje</th>';
    // table += '<th>Puntaje</th>';
    table += '<th>Fecha de Pago</th>';
    table += '<th>Estado</th>';
    table += '<th></th>';
    table += '</thead><tbody>';
    let interr = 0;
    for (var j = 0; j < tschedule.length; j++) {
        var list = tschedule[j].split('|');
        interr = 0;
        if (parseFloat(list[4]) === 0) {
            interr = 1;
        }
        let id = list[0].split('^')[3];
        table += '<tr>';
        table += '<td>' + list[1] + '</td>';
        table += '<td>' + DateFormat(list[2]) + '</td>';
        table += '<td>' + list[3] + '</td>';
        table += '<td>' + list[4] + '</td>';
        table += '<td>' + list[5] + '</td>';
        table += '<td>' + list[6] + '</td>';
        table += '<td>' + list[7] + '</td>';
        table += '<td>' + DateFormat(list[11]) + '</td>';
        //table += '<td>' + list[8] + " "+"Pts"+'</td>';
        //  table += '<td>' + list[9] + '</td>';

        let arrayImage = list[10].split('~');
        let extemsion = arrayImage[0].split('.');
        if (list[9] === "1") {
            table += '<td>Pagado</td>';
            if (list[10] === "") {
                table += '<td></td>';

            } else {
                table += '<td>';
                for (var z = 0; z < arrayImage.length; z++) {
                    if (arrayImage[z] !== "") {
                        let extePen = arrayImage[z].split('.');
                        if (extePen[extePen.length - 1] === "pdf") {
                            
                            table += '&nbsp; <a href="../Resources/RecibosRegister/' + arrayImage[z] + '" target="_blank"><img src="../Resources/RecibosRegister/pdf.png" width="50" /></a>';
                        } else if (extePen[extePen.length - 1].toUpperCase() === "JPG" || extePen[extePen.length - 1].toUpperCase() === "PNG" || extePen[extePen.length - 1].toUpperCase() === "JPEG") {
                            table += '&nbsp; <a href="../Resources/RecibosRegister/' + arrayImage[z] + '" target="_blank"><img src="../Resources/RecibosRegister/' + arrayImage[z] + '" width="50" /></a>';


                        } else {
                            table += "";
                        }

                    }
                }
                table += '</td >';

            }
        }
        else if (list[9] === "2") {
            table += '<td>Por Verif.</td>';
            if (list[10] === "") {
                table += '<td></td>';
            } else {
                table += '<td>';
                var interrutorrec = 0;
                for (var z = 0; z < arrayImage.length; z++) {
                    if (arrayImage[z] !== "") {
                        let extePen = arrayImage[z].split('.');
                        if (interrutorrec < 3) {

                            if (extePen[extePen.length - 1] === "pdf") {
                                interrutorrec++;
                                table += '&nbsp; <a href="../Resources/RecibosRegister/' + arrayImage[z] + '" target="_blank"><img src="../Resources/RecibosRegister/pdf.png" width="50" /></a>';
                            } else if (extePen[extePen.length - 1].toUpperCase() === "JPG" || extePen[extePen.length - 1].toUpperCase() === "PNG" || extePen[extePen.length - 1].toUpperCase() === "JPEG") {
                                table += '&nbsp; <a href="../Resources/RecibosRegister/' + arrayImage[z] + '" target="_blank"><img src="../Resources/RecibosRegister/' + arrayImage[z] + '" width="50" /></a>';
                                interrutorrec++;

                            } else {
                                table += "";
                            }
                        }
                    }
                }
                table += '</td >';
            }
        }
        else if (list[9] === "3") {
            table += '<td>Rechazado</td>';
            table += '<td><a href="PayQuoteWallet.aspx?id=' + id + '&numCuota=' + list[1] + '" class="btn btn-primary" >Pagar</a></td>';
            // table += '<td><a href="Pagos.aspx?id=' + id + '&quota=' + list[6] + '" class="btn btn-primary" >Amortizacion</a></td>';
            //table += "<td><input type='PayQuoteWallet' data-toggle='modal' data-target='#mdlImages' id='" + id + "' value='Amortizar' onclick='modalR(" + id + "," + list[6] + ");'/></td>";
            //table += '<td><a href="Advancepay.aspx ? id = ' + id + ' & numCuota=' + list[1] + '" class="btn btn - primary" >Adelanto de cuota</a></td>';

        } else if (list[9] === "4") {
            table += '<td>Pendiente';
            for (var z = 0; z < arrayImage.length; z++) {
                if (arrayImage[z] !== "") {
                    let extePen = arrayImage[z].split('.');
                    if (extePen[extePen.length - 1] === "pdf") {
                        table += '<a href="../Resources/RecibosRegister/' + arrayImage[z] + '" target="_blank"><img src="../Resources/RecibosRegister/pdf.png" width="50" /></a>';
                    }
                }
            }
            table += '</td >';
            table += '<td><a onclick="UserToRefuse(' + id + ')" class="btn btn-success" >Rehacer</a></td>';

        } else {
            if (interr === 1) {
                table += '<td></td>';
            } else {
                table += '<td>No Pagado</td>';
                table += '<td><a href="PayQuoteWallet.aspx?id=' + id + '&numCuota=' + list[1] + '" class="btn btn-primary" >Pagar</a></td>';
                //table += "<td><input type='PayQuoteWallet' class='btn btn-primary' data-toggle='modal' data-target='#mdlImages' id='" + id + "' value='Amortizar' onclick='modalR(" + id + "," + list[6] + ");'/></td>";
                //table += '<td><a href="Advancepay.aspx?id=' + id + '&numCuota=' + list[1] + '" class="btn btn-primary" >Adelanto de cuota</a></td>';
            }
        }
        //input type = 'button' data - toggle='modal' data - target='#mdlImages'
        table += '</tr>';
    }
    table += '</tbody></table></div>';
    response += table;
    response += "</div></div></div></div></div></div></div></div></div></div></div></div></div>";

    return response;
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
        excel += "<tr><td>" + row[3] + "</td></tr>";
    }
    excel += "</tbody></table></body></html>";
}

function readFile(input) {

    if (input.files && input.files[0]) {

        var reader = new FileReader();
        reader.onload = function (e) {

            /*borramos el contenido html del contenedor*/
            document.getElementById('file-preview-zone').innerHTML = "";
            var filePreview = document.createElement('img');
            //var filePreview = document.getElementById('file_preview');

            filePreview.id = 'file-preview';
            filePreview.width = 200;
            filePreview.height = 200;

            //e.target.result contents the base64 data from the image uploaded

            filePreview.src = e.target.result;
            var previewZone = document.getElementById('file-preview-zone');
            previewZone.appendChild(filePreview);
        }
        reader.readAsDataURL(input.files[0]);
    }

}

//var fileUpload = document.getElementById('file_upload');

/*fileUpload.onchange = function (e) {

    readFile(e.srcElement);

}*/

/*function modal(pid,pid2) {
    alert(pid)
    alert(pid2)
    var str = pid + '|' + pid2;

    window.location.href = 'Pagos.aspx?varible1=' + encodeURIComponent(str);
    // Post("Pagos", pid, "hola");
   // document.getElementById('lblIdImagen').value = pid;
}*/

function modal(pid, pid2) {
    //alert(pid)
    //alert(pid2)
    var str = pid + '|' + pid2;

    window.location.href = 'PayQuote.aspx?varible1=' + encodeURIComponent(str);
    // Post("Pagos", pid, "hola");
    // document.getElementById('lblIdImagen').value = pid;
}

function modalR(pid, pid2) {
    var Macro = McArray.split('$');
    var Naux = "";
    var storage;
    var count2 = 0;
    let numQuotasPay = 0;
    let idMembership = 0;
    let description = "";

    for (var x = 0; x <= Macro.length - 1; x++) {
        var AuxMacro = Macro[x].split('¬');
        for (var y = 0; y <= AuxMacro.length - 1; y++) {
            var Micro = AuxMacro[y].split('^');
            let arrayQu = Micro[3].split('|');
            let descri = arrayQu[1];
            if ((descri.substring(0, 5)).trim() === "Cuota") {
                numQuotasPay++;
            }
            if (Micro[3].split('|')[9] === "0") {
                idMembership = parseInt(Micro[3].split('|')[0]);
                description = Micro[3].split('|')[1];
                Naux = Macro[x].split('¬');
                storage = Micro[3].split('|');
                for (var z = numQuotasPay; z <= Naux.length - 1; z++) {
                    var ArraySpace = Naux[z];
                    var ArrayNotSpace = (ArraySpace.split('|'))[1];
                    if (ArrayNotSpace.indexOf("Cuota") !== -1) {
                        count2++;
                    }
                }
                break;
            }
        }
    }

    var resp = count2;
    document.getElementById("txtTest").value = count2;
    document.getElementById("lblQuotes").innerText = count2;
    document.getElementById("lblCapital").innerText = storage[3];
    document.getElementById("lblIdMembership").value = idMembership;
    document.getElementById("txtMemb").value = description;

}


function hola() {

}

function refresh() {

    location.reload(true);
}

function fSaveImages() {
    var param = document.getElementById('lblIdImagen').value;
    var params = "id=" + rows[param] + "images=a";
    Get("PaymentsData", params, refresh);

}


document.getElementById('btnRegistePay').onclick = function () {
    idMembreship = document.getElementById('lblIdImagen').value;

}


document.getElementById('txtCount').onkeyup = function () {
    let quotesRest = parseInt(document.getElementById('lblQuotes').innerText);
    let quotesMin = parseInt(document.getElementById('txtCount').value);
    if (quotesMin < 0) {
        document.getElementById('quotesResult').innerText = 'Valor para disminuir no valido.';
        document.getElementById('txtCount').value = 0;
        return;
    }
    let result = quotesRest - quotesMin;
    if (result > -1) {
        document.getElementById('quotesResult').innerText = result;
    }
    else {
        document.getElementById('quotesResult').innerText = 'No se Puede Disminuir tus cuotas a ese valor.';

    }
}

document.getElementById('txtCount').addEventListener("click", function () {
    let quotesRest = parseInt(document.getElementById('lblQuotes').innerText);
    let quotesMin = parseInt(document.getElementById('txtCount').value);
    if (quotesMin < 0) {
        document.getElementById('quotesResult').innerText = 'Valor para disminuir no valido.';
        document.getElementById('txtCount').value = 0;
        return;
    }
    let result = quotesRest - quotesMin;
    if (result > -1) {
        document.getElementById('quotesResult').innerText = result;
    }
    else {
        document.getElementById('quotesResult').innerText = 'No se Puede Disminuir tus cuotas a ese valor.';

    }
});


document.getElementById('btnAdvance').onclick = function () {
    let numQuotes = document.getElementById('numQuotesAdvanc').value;
    let idMember = document.getElementById('idMembers').value;
    let _valueTotal = document.getElementById('valueTotal').innerHTML;

    let _spanQuot = _valueTotal.split('S/');

    if (_spanQuot.length < 2) {
        _spanQuot = _valueTotal.split('$');
    }
    let _valueQuot = _spanQuot[1].split('>');
    let valueQuot = parseFloat(_valueQuot[1]);

    location.href = "Advancepay.aspx?nq=" + numQuotes + "&im=" + idMember + "&tm=" + valueQuot.toString();
}

function btnAdvancePaym(_numQuotes, _quote, _idMembers, _currencyCode) {

    let symbol = "S/";

    if (_currencyCode === "USD") {
        symbol = "$";
    }

    document.getElementById('idMembers').value = _idMembers;
    let slctHTML = "";
    for (var i = 0; i < _numQuotes; i++) {
        let value = (i + 1).toString();
        slctHTML += "<option value='" + value + "'>" + value + "</option>";
    }
    document.getElementById('numQuotesAdvanc').innerHTML = slctHTML;
    document.getElementById('valueQuote').innerHTML = "<span id='spanvalue' style='font-weight: bold;'>" + symbol + "</span>" + _quote;
    document.getElementById('valueTotal').innerHTML = "<span style='font-weight: bold;'>" + symbol + "</span>" + _quote;

    $('#mdlAdelanto').modal('show');
}

document.getElementById('numQuotesAdvanc').onchange = function () {
    let symbol = "S/";
    let numQuot = parseFloat(this.value);
    let _valueQuot = document.getElementById('valueQuote').innerHTML;
    let _spanQuot = _valueQuot.split('S/');

    if (_spanQuot.length < 2) {
        _spanQuot = _valueQuot.split('$');
        symbol = "$";
    }
    _valueQuot = _spanQuot[1].split('>');
    let valueQuot = parseFloat(_valueQuot[1]);
    document.getElementById('valueTotal').innerHTML = "<span style='font-weight: bold;'>" + symbol + "</span>" + (numQuot * valueQuot).toString();

}