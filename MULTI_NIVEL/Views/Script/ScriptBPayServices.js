var id = "";
var userName = "";
var action = 0;

window.onload = function () {
    document.getElementById("divProgressBar").style.display = "inline";
    let param = "action=Get";
    GetDos("BPayServicesC", param, ShowPayPendient);
};

function ShowPayPendient(anwser) {
    let tableHTML = "No hay datos";
    if (anwser !== "") {
        tableHTML = "";
        tableHTML += "<table class='table'>";
        let data = anwser.split('¬');
        tableHTML += "<tr>";
        tableHTML += "<th>#</th>";
        tableHTML += "<th>Nombre del Beneficiario</th>";
        tableHTML += "<th>Usuario</th>";
        tableHTML += "<th>Servicio</th>";
        tableHTML += "<th>Fecha de Compra</th>";
        tableHTML += "<th>Imagen</th>";
        tableHTML += "<th>Estado</th>";
        tableHTML += "<th>Obs</th>";
        tableHTML += "<th>Codigo de reserva</th>";
        tableHTML += "<th></th>";
        tableHTML += "<th></th>";
        tableHTML += "</tr>";

        for (var i = 0; i < data.length; i++) {
            let row = data[i].split('|');
            tableHTML += "<tr>";
            tableHTML += "<td>" + (i + 1).toString() + "</td>";
            tableHTML += "<td>" + row[0] + "</td>";
            tableHTML += "<td>" + row[1] + "</td>";
            tableHTML += "<td>" + row[2] + "</td>";
            tableHTML += "<td>" + row[3] + "</td>";
            tableHTML += "<td><a href='/Resources/ImgServices/" + row[4] + "' target='_blank'><img width='50' src='/Resources/ImgServices/" + row[4] + "'/></a></td>";
            tableHTML += "<td>" + row[6] + "</td>";
            tableHTML += "<td>" + row[7] + "</td>";
            tableHTML += "<td>" + row[8] + "</td>";

            if (row[8] !== "") {
                if (row[10] == "3") {
                    tableHTML += "<td><input type='button' class='btn btn-primary' onclick=ShowModalConfirm('" + row[5] + "','" + row[1] + "','" + row[9] + "','" + row[8] + "','1') value=Pagado /></td > ";
                } else {
                    tableHTML += "<td></td>";
                }
            } else {
                tableHTML += "<td><input type='button' class='btn btn-primary' onclick=ShowModalConfirm('" + row[5] + "','" + row[1] + "','" + row[9] + "','" + row[8] + "','1') value=Pagado /></td > ";
            }

            if (row[8] !== "") {
                if (row[10] != "3") {
                    tableHTML += "<td><input type='button' class='btn btn-success' onclick=ShowModalConfirm('" + row[5] + "','" + row[1] + "','" + row[9] + "','" + row[8] + "','2') value=Conforme /></td > ";
                } else {
                    tableHTML += "<td></td>";
                }
            } else {
                tableHTML += "<td></td>";
            }
            if (row[10] == "3") {
                tableHTML += "<td></td>";
            } else {
                tableHTML += "<td><input type='button' class='btn btn-danger' onclick=ShowModalConfirm('" + row[5] + "','" + row[1] + "','" + row[9] + "','" + row[8] + "','0') value=Rechazar /></td > ";
            }
                /* tableHTML += "<td><button type='button' class='btn btn-primary' data-toggle='modal' data-target='#exampleModal'>";
            tableHTML += "Launch demo modal</button></td>";*/
            tableHTML += "</tr>";
        }
        tableHTML += "</table>";
    }
    document.getElementById('listAccount').innerHTML = tableHTML;
    document.getElementById("divProgressBar").style.display = "none";
}

function ShowModalConfirm(_id, _userName, _price, _type ,_action) {
    id = _id;
    userName = _userName;
    action = parseInt(_action);
    document.getElementById('Amount').value = _price;

    if (_type === "") {
        document.getElementById('DivAmount').style.display = "none";
    }
    if (action === 1) {
        document.getElementById('TitleModal').innerHTML = "¿Esta seguro de aceptar el recibo?";
    }
    if (action === 0) {
        document.getElementById('TitleModal').innerHTML = "¿Esta seguro de rechazar el recibo?";
    }
    $('#confirmModal').modal('show');
}
document.getElementById('Aceptar').onclick = function () {
    $('#confirmModal').modal('hide');
    document.getElementById("divProgressBar").style.display = "inline";

    let obs = document.getElementById('Obs').value;
    let price = parseFloat(document.getElementById('Amount').value);
    let prices = document.getElementById('Amount').value;

    if (validationNumber(prices)) {
        if (action === 1 && price > 0) {
            AceptarPay(id, userName, obs, price);
        }
        else if (action === 0 && obs !== "") {
            RechazarPay(id, userName, obs, price);
        }
        else if (action === 2 && price > 0) {
            ConformePay(id, userName, obs, price);
        } else {
            document.getElementById("divProgressBar").style.display = "none";
            alert('Monto debe ser mayor a 0 y/o Observaciones es Obligatorio.');
        }
    } else {
        document.getElementById("divProgressBar").style.display = "none";
        alert('Ha ocurrido un error.');
    }
};

function ShowAnwserPay(anwser) {
    document.getElementById("divProgressBar").style.display = "none";
    alert(anwser);
    location.reload();
}
function AceptarPay(_id, _userName, _obs, _price) {
    let param = "action=AceptarPay&id=" + _id + "&userName=" + _userName + "&obs=" + _obs + "&price=" + _price.toString();
    GetDos("BPayServicesC", param, ShowAnwserPay);
}
function RechazarPay(_id, _userName, _obs, _price) {
    let param = "action=RechazarPay&id=" + _id + "&userName=" + _userName + "&obs=" + _obs + "&price=" + _price.toString();
    GetDos("BPayServicesC", param, ShowAnwserPay);
}
function ConformePay(_id, _userName, _obs, _price) {
    let param = "action=ConformePay&id=" + _id + "&userName=" + _userName + "&obs=" + _obs + "&price=" + _price.toString();
    GetDos("BPayServicesC", param, ShowAnwserPay);
}

