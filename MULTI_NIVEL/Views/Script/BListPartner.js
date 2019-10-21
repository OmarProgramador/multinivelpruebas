function ListPartner() {
    let param = "action=list";
    GetDos("BListPartnerC", param, ShowList);
}

function ShowList(data) {
    let tableHtml = "<p>No hay Datos</p>";
    if (data !== "") {
        tableHtml = "<table class='table table-hover'>";
        let arrayData = data.split('¬');
        tableHtml += "<tr>";
        tableHtml += "<th>#</th>";
        tableHtml += "<th>UserName</th>";
        tableHtml += "<th>Nro Doc.</th>";
        tableHtml += "<th>Nombres</th>";
        tableHtml += "<th>Apellidos</th>";
        tableHtml += "<th>Genero</th>";
        tableHtml += "<th>Email</th>";
        tableHtml += "<th>Telefono</th>";
        tableHtml += "<th>Estado</th>";
        tableHtml += "<th>Fech. Cuota Pendiente</th>";
        tableHtml += "<th>Cuota Pendiente</th>";
        tableHtml += "<th>Desc.cuota Pendiente</th>";
        tableHtml += "<th>Fech. Ultima cuota pagada</th>";
        tableHtml += "</tr>";

        for (var i = 0; i < arrayData.length; i++) {
            let row = arrayData[i].split('|');
            tableHtml += "<tr>";
            tableHtml += "<td>" + (i + 1).toString() + "</td>";
            tableHtml += "<td>" + row[0] + "</td>";
            tableHtml += "<td>" + row[11] + "</td>";
            tableHtml += "<td>" + row[1] + "</td>";
            tableHtml += "<td>" + row[2] + "</td>";
            tableHtml += "<td>" + row[3] + "</td>";
            tableHtml += "<td>" + row[4] + "</td>";
            tableHtml += "<td>" + row[5] + "</td>";
            tableHtml += "<td>" + row[6] + "</td>";
            tableHtml += "<td>" + row[7] + "</td>";
            tableHtml += "<td>" + row[8] + "</td>";
            tableHtml += "<td>" + row[9] + "</td>";
            tableHtml += "<td>" + row[10] + "</td>";

            tableHtml += "</tr>";
        }
        tableHtml += "</table>";
    }
    document.getElementById('data').innerHTML = tableHtml;
    document.getElementById('divProgressBar').style.display = "none";
}



function FilterPartner(_value) {
    let value = document.getElementById(_value).value;
    let param = "action=filter&value=" + value;
    GetDos("BListPartnerC", param, ShowList);
}


