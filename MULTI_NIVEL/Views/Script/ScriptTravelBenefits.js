
function OnloadBody() {

    let param = "action=infoPerson";
    GetDos("CodeTravelBC", param, ShowDatos); 
     
}

function ShowDatos(data) {
    let arrayData = data.split('|');
    document.getElementById('nameUser').value = arrayData[1];
    document.getElementById('lastNameUser').value = arrayData[2];
    document.getElementById('emailUser').value = arrayData[5];
    document.getElementById('phoneUser').value = arrayData[6];
    let param2 = "action=listCode";
    GetDos("CodeTravelBC", param2, ListCode);
}

function btnPutTravel() {
    document.getElementById('btnPutTrave').disabled = true;
    let _name =  document.getElementById('nameUser').value;
    let _lastname =  document.getElementById('lastNameUser').value;
    let _email = document.getElementById('emailUser').value;
    let _phone = document.getElementById('phoneUser').value;
    let _duraction = document.getElementById('duration').value;

   
    if (_name == "" || _lastname == "" || _email == "" || _phone == "" || _duraction == "") {
        document.getElementById('error-travel').innerHTML = "Completa todos los campos.";
        document.getElementById('btnPutTrave').disabled = false;
    } else {
        let param = "action=putTravel&name=" + _name + "&lastname=" + _lastname + "&email=" + _email + "&phone=" + _phone + "&duration=" + _duraction;
        GetDos("CodeTravelBC", param, ShowResponse); 
    }
     
}

function ShowResponse(data) {
    alert(data);
    location.reload();
}

function OnLoadListBene() {
    alert("espera bro");
}

function ListCode(data) {
    let tableHTML = "<p>No hay codigos solicitados.</p>";
    if (data != "") {
        tableHTML = "<table class='table table-hover'>";
        tableHTML += "<tr>";
        tableHTML += "<td>#</td>";
        tableHTML += "<td>Nombres</td>";
        tableHTML += "<td>Correo</td>";
        tableHTML += "<td>Telefono</td>";
        tableHTML += "<td>Estado</td>";
        tableHTML += "<td>Fecha de Solicitud</td>";
        tableHTML += "<td>Fecha de Caducidad</td>";
        tableHTML += "<td>Usuario</td>";
        tableHTML += "<td>Password</td>";
        tableHTML += "<td>Codigo</td>";
        tableHTML += "<td>Fecha de Aceptacion</td>";
        tableHTML += "</tr>";
        let arrayData = data.split('¬');
        for (var i = 0; i < arrayData.length; i++) {
            let row = arrayData[i].split('|');
            tableHTML += "<tr>";
            tableHTML += "<td>Codigo " + (i + 1).toString() + "</td>";
            //tableHTML += "<td>" + row[0] + "</td>";
            //tableHTML += "<td>" + row[1] + "</td>";
            //tableHTML += "<td>" + row[2] + "</td>";
            tableHTML += "<td>" + row[3] + "</td>";
            tableHTML += "<td>" + row[4] + "</td>";
            tableHTML += "<td>" + row[5] + "</td>";
            if (row[6] == "2") {
                row[6] = "<label class='label-warning'>En proceso</label>";
            } else if (row[6] == "0") {
                row[6] = "<label class='label-danger'>Caducado</label>";
            } else {
                row[6] = "<label class='label-success'>Aceptado</label>";
            }
            tableHTML += "<td>" + row[6] + "</td>";
            tableHTML += "<td>" + row[7] + "</td>";
            tableHTML += "<td>" + row[8] + "</td>";
            tableHTML += "<td>" + row[9] + "</td>";
            tableHTML += "<td>" + row[10] + "</td>";
            tableHTML += "<td>" + row[11] + "</td>";
            tableHTML += "<td>" + row[12] + "</td>";
            tableHTML += "</tr>";
        }
        tableHTML += "</table>";
    }
    document.getElementById('listTravel').innerHTML = tableHTML;

    let param2 = "action=listHotel2";
    GetDos("CodeTravelBC", param2, ListHotelDos);

    
}

function ListHotelDos(data) {
    let tableHTML = "<p>No hay Datos</p>";

    if (data != "") {
        tableHTML = "<table class='table table-hover'>";
        tableHTML += "<tr>";
        tableHTML += "<th>Item</th>";
        tableHTML += "<th>Nombre del Beneficiario</th>";
        tableHTML += "<th>Fecha de Adquisición</th>";
        tableHTML += "<th>Código</th>";
        tableHTML += "<th>Monto</th>";
        tableHTML += "<th>Cantidad</th>";
        tableHTML += "<th>Estado</th>";      					
        tableHTML += "</tr>";
        let arrayData = data.split('¬');
        for (var i = 0; i < arrayData.length; i++) {
            let row = arrayData[i].split('|');
            tableHTML += "<tr>";
            tableHTML += "<td>" + row[0] + "</td>";
            tableHTML += "<td>" + row[1] + "</td>";
            tableHTML += "<td>" + row[2] + "</td>";
            tableHTML += "<td>" + row[3] + "</td>";
            tableHTML += "<td>" + row[4] + "</td>";
            tableHTML += "<td>" + row[5] + "</td>";
            tableHTML += "<td>" + row[6] + "</td>";
           // tableHTML += "<td>" + row[7] + "</td>";
            tableHTML += "</tr>";
        }
        tableHTML += "</table>";
    }

    document.getElementById('listHotel2').innerHTML = tableHTML;
    document.getElementById("divProgressBar").className = "display-none";
}