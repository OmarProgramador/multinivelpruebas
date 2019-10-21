
window.onload = function () {
    GetDos("TransactionsDetailC", null, ShoInfo);
}

function ShoInfo(anwser) {
    let tableHtml = CreateTableTransac(anwser);
    document.getElementById('info_transacciones').innerHTML = tableHtml;
    document.getElementById('divProgressBar').style.display = "none";
}

function CreateTableTransac(info) {
    let table = "";

    table += "<table class='table table-hover'>";
    table += "<tr>";
    table += "<th>Item</th>";
    table += "<th>Fecha</th>";
    table += "<th>Ciclo</th>";
    table += "<th>Monto</th>";
    table += "<th></th>";
    table += "</tr>";
    if (info !== '') {
        let arrayInfo = info.split('¬');

        for (var i = 0; i < arrayInfo.length; i++) {
            let row = arrayInfo[i].split('|');
            table += "<tr>";
            table += "<td>" + (i + 1).toString() + "</td>";
            table += "<td>" + row[0] + "</td>";
            table += "<td>" + row[1] + "</td>";
            table += "<td>" + row[2] + "</td>";
            if (row[3] === "1") {
                row[3] = "<span class='label-success'>Abonado</span>";
            } else {
                row[3] = "<span class='label-danger'>No Abonado</span>";
            }
            table += "<td>" + row[3] + "</td>";
            table += "</tr>";
        }
    } else {
        table += "<tr><td colspan='5' class='text-center'>No hay transacciones.</td></tr>";
    }
    table += "</table>";

    return table;
}