

function ListPartner() {
    let param = "action=list";
    GetDos("MailAccountActiveC", param, ShowList);
}

function ShowList(data) {
    let tableHtml = "<p>No hay Datos</p>";
    if (data !== "") {
        tableHtml = "<table class='table table-hover'>";
        let arrayData = data.split('¬');
        tableHtml += "<tr>";
        tableHtml += "<th>#</th>";
        tableHtml += "<th>UserName</th>";
        tableHtml += "<th>Nombres</th>";
        tableHtml += "<th>Estado</th>";
        tableHtml += "<th>Correo Corporativo</th>";
        tableHtml += "<th>Contraseña</th>";

        tableHtml += "</tr>";

        for (var i = 0; i < arrayData.length; i++) {
            let row = arrayData[i].split('|');
            tableHtml += "<tr>";
            tableHtml += "<td>" + (i + 1).toString() + "</td>";
            tableHtml += "<td>" + row[0] + "</td>";
            tableHtml += "<td>" + row[1] + "</td>";
            tableHtml += "<td>" + row[7] + "</td>";
            tableHtml += "<td>" + row[5] + "</td>";
            tableHtml += "<td>" + row[0] + "</td>";
            var qwe = "'" + row[0] + "'"; 
            tableHtml += "<td> <button id='btnCorreo" + (i + 1).toString() + "' onclick=modalR2(" + qwe + "," + qwe + ");  class='btn btn-danger'>Eliminar</button></td>";

            tableHtml += "</tr>";
        }
        tableHtml += "</table>";
    }
    document.getElementById('data').innerHTML = tableHtml;
    document.getElementById('divProgressBar').style.display = "none";
}
function crearcorreo(correo, num) {
    var newemail = correo + "@inresorts.club";
    document.getElementById('cor' + num + '').innerHTML = newemail;

    return newemail;
}

function modalR2(correo, username) {

    //params = "params=" + crearcorreo(correo) + "|" + username;
    params = "params=" + username;
    GetDos("MailDeleteBussinesC", params, modalS);
}

function FilterPartner(_value) {
    let value = document.getElementById(_value).value;
    let param = "action=filter&value=" + value;
    GetDos("MailAccountActiveC", param, ShowList);
}

function modalS(data) {
    alert(data);
    location.href = "MailAccountActive.aspx";
}