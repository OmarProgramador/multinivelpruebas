
function GetNotConfirmed() {
    document.getElementById('divProgressBar').style.display = "inline";
    let param = "action=getNotConfirmed";
    GetDos("CodeTravelBC", param, ShowNotConfirmed);
    
}

function ShowNotConfirmed(data) {
    let tableHTML = "<p>No hay datos</p>";
    if (data != "") {
        tableHTML = "<table class='table'>";
        tableHTML += "<tr>";
        tableHTML += "<th>#</th>";
        tableHTML += "<th>Nombres</th>";
        tableHTML += "<th>Correo</th>";
        tableHTML += "<th>Telefono</th>";
        tableHTML += "<th>Estado</th>";
        tableHTML += "<th>Fecha Solicitud</th>";
        tableHTML += "<th>Fecha caducidad</th>";
        tableHTML += "<th></th>";
        tableHTML += "<th></th>";
        tableHTML += "</tr>";
        let rows = data.split('¬');
        for (var i = 0; i < rows.length; i++) {
            let row = rows[i].split('|');
            tableHTML += "<tr>";
            tableHTML += "<td>" + (i + 1).toString() + "</td>";
            tableHTML += "<td>" + row[3] + "</td>";
            tableHTML += "<td>" + row[4] + "</td>";
            tableHTML += "<td>" + row[5] + "</td>";
            tableHTML += "<td>" + row[6] + "</td>";
            tableHTML += "<td>" + row[7] + "</td>";
            tableHTML += "<td>" + row[8] + "</td>";
            tableHTML += "<td><a href='CodeTravelBData.aspx?id=" + row[0] + "' class='btn btn-primary'>Aceptar</a></td>";
            tableHTML += "<td><button type='button' onclick='btnDeny(" + row[0] +")' name='btnDeny' class='btn btn-secondary'>Rechazar</button></td>";
            tableHTML += "</tr>";
        }
        tableHTML += "</table>";
    }
    document.getElementById('data').innerHTML = tableHTML;
    document.getElementById('divProgressBar').style.display = "none";
}

function btnDeny(_id) {
    alert(_id);
}

function btnConfirm() {
    let _id = document.getElementById('id').innerText;
    //let _userTravel = document.getElementById('userTravel').value;
    let _passTravel = document.getElementById('passTravel').value;
    let _code = document.getElementById('code').value;
    let param = "action=confirm&id=" + _id + "&pass=" + _passTravel + "&code=" + _code;

    if (_id == "" || _passTravel == "" || _code == "") {
        document.getElementById('error-confir').innerHTML = "Completa todos los campos";
    } else {
        GetDos("CodeTravelBC", param, ShowMessagge);
    }
    //alert(param);
}

function ShowMessagge(data) {
    alert(data);
    location.href = "CodeTravelB.aspx";
}