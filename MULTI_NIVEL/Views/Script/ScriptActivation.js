
window.onload = function () {
    document.getElementById('divProgressBar').style.display = "inline";
    let param = "action=get";
    GetDos("ActivationC", param, ShowTable);
}



function ShowTable(answer) {
    let tableHtml = "<p>No hay datos</p>";
    if (answer !== "") {
        tableHtml = "";
        tableHtml += "<div class='row'>";
        tableHtml += "<table class='table' style='max-width: 500px;'>";
        tableHtml += "<tr style='background-image: linear-gradient(#2b80ab, #0b84bee8);color:white'>";
        tableHtml += "<th>#</th>";
        tableHtml += "<th>Activo Desde</th>";
        tableHtml += "<th>Activo Hasta</th>";
        tableHtml += "<th>Puntos</th>";
        tableHtml += "<th></th>";
        tableHtml += "</tr>";
        let rows = answer.split('¬');
        let classRange = "";
        let interr = 0;
        for (var i = 0; i < rows.length; i++) {
            let row = rows[i].split('|');
//style='background-color: #e0edf4;
            classRange = "range-bag";
            tableHtml += "<tr >";
            let correlativo = (i).toString();
            if (row[4] == 2) {
                correlativo = 0;
                interr = 1;
            }
            if (interr != 1) {
                correlativo = (i + 1).toString();
            }
            tableHtml += "<td>" + correlativo + "</td>";
            tableHtml += "<td>" + DateFormat(row[0]) + "</td>";
            tableHtml += "<td>" + DateFormat(row[3]) + "</td>";
            tableHtml += "<td>" + row[2] + "</td>";
            if (row[1] == 1) {
                classRange = "range-good";
            }
            tableHtml += "<td> <div style='display: block' class='" + classRange + "'></div> </td>";
            tableHtml += "</tr>";
        }
        tableHtml += "</table>";
        tableHtml += "<style> tr:nth-child(odd) { background-color: #f2f2f2;}";
        tableHtml += "</style >";
        

        tableHtml += "</div>";
    }
    document.getElementById('tblDatos').innerHTML = tableHtml;
    document.getElementById('divProgressBar').style.display = "none";
}