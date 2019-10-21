window.onload = function () {
    Get("HistoryTravelersC", null, CreateTable);
}

function CreateTable() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var texto = '' + httpRequest.responseText;
            let table = "<p>No hay Datos</p>";
            if (texto !== "") {

                let rows = texto.split('¬');
                table = "<div class='container'>";
                table += "<div class='panel-body' style='padding: 15px 15px 15px 0;'>";
                table += "<div class='table-responsive'>";
                table += "<table class='table table-bordered dataTables-example dataTable thead-dark'><tr>";
                table += "<th>Nro</th>";
                table += "<th>Nombre </th>";
                table += "<th>Apellido </th>";
                table += "<th>Correo</th>";
                table += "<th>Code</th>";
                table += "<th>Teléfono</th>";
                table += "<th></th>";
                table += "<th></th>";

                table += "</tr>";
                for (var j = 0; j < rows.length; j++) {
                    let row = rows[j].split('|');
                    let sum = parseInt(j) + 1;
                    table += "<tr>";
                    table += "<td>" + sum + "</td>";
                    table += "<td>" + row[1] + "</td>";
                    table += "<td>" + row[2] + "</td>";
                    table += "<td>" + row[3] + "</td>";
                    table += "<td class='text-right'>" + row[6] + "</td>";
                    table += "<td>" + row[4] + "</td>";
                    table += "<td> <button type='button' onclick=EditBene('" + row[0] + "|" + row[1] + "|" + row[2] + "|" + row[3] + "|" + row[4] + "|" + row[6] + "') class='btn btn-primary'><i class='fa fa-edit'></i></button></td>";
                    table += "<td><button type='button' onclick=DeleteBene('" + row[0] + "') class='btn btn-primary'><i class='fa fa-trash'></i></button></td>";
                    table += "</tr>";
                }
                table += "</table>";
                table += "</div>";
                table += "</div>";
                table += "</div>";
                table += "</div>";
            }
            document.getElementById('listBeneficiarios').innerHTML = table;
        }
    }
}


function EditBene(_data) {
    let _datar = _data;
    let _array = _datar.split('|');
    
    document.getElementById('idEdit').value = _array[0];
    document.getElementById('nameEdit').value = _array[1];
    document.getElementById('lastNameEdit').value = _array[2];
    document.getElementById('emailEdit').value = _array[3];
    document.getElementById('telefEdit').value = _array[4];
    document.getElementById('codeEdit').value = _array[5];
    document.getElementById('operacion').value = "edit";
    $('#mdlEditBenef').modal('show');
}

function DeleteBene(_data) {    
    document.getElementById('idDispose').value = _data;
    document.getElementById('operacion').value = "delete";
    $('#mdlDelete').modal('show');
}

function SaveChange() {
    let action = document.getElementById('operacion').value;
    let _id = document.getElementById('idEdit').value;
    let _name = document.getElementById('nameEdit').value;
    let _lastName = document.getElementById('lastNameEdit').value;
    let _email = document.getElementById('emailEdit').value;
    let _telef = document.getElementById('telefEdit').value;
    let _code = document.getElementById('codeEdit').value;

    let param = "action=" + action + "&name=" + _name + "&lastName=" + _lastName + "&email=" + _email + "&telef=" + _telef + "&id=" + _id + "&code=" + _code;
    GetDos("TravelBenefitsC", param, ResponseSaveShange);
}

function ResponseSaveShange(data) {
    alert(data);
    location.reload();
}

function DisposeBenef() {
    let _id = document.getElementById('idDispose').value;
    let param = "id=" + _id + "&action=delete"; 
    GetDos("TravelBenefitsC", param, ResponseSaveShange);
}