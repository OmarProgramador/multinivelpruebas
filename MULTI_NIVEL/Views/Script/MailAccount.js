

function ListPartner() {
    let param = "action=list";
    GetDos("MailAccountC", param, ShowList);
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
        //tableHtml += "<th>Nuevo correo</th>";

        tableHtml += "</tr>";

        for (var i = 0; i < arrayData.length; i++) {
            let row = arrayData[i].split('|');
            tableHtml += "<tr>";
            tableHtml += "<td>" + (i + 1).toString() + "</td>";
            tableHtml += "<td>" + row[0] + "</td>";
            tableHtml += "<td>" + row[1] + "</td>";
            tableHtml += "<td>" + row[7] + "</td>";
            tableHtml += "<td>" + row[5] + "</td>";
            
            var qwe = "'" + row[0] + "'"; //correo
            //var asd = qwe.toString();
            //tableHtml += "<td> <button id='btnCorreo" + (i + 1).toString() + "' onclick=crearcorreo(" + qwe + "," + (i + 1).toString() + ")  class='btn btn-primary'>crear</button></td>";
            //tableHtml += "<td> <asp:Button ID='btnProcess' runat='server' CssClass='btn btn-md btn-primary recuperar ladda-button' Text='Generar' OnClick='btnProcess_Click'  /></td>";
            tableHtml += "<td><input type='button' id='' class='btn btn-primary'  onclick=modalR2(" + qwe + "," + qwe  + ");  value='Crear Correo Corporativo'/></td>";  

            tableHtml += "</tr>";
        }
        tableHtml += "</table>";
    }
    document.getElementById('data').innerHTML = tableHtml;
    document.getElementById('divProgressBar').style.display = "none";
}
function crearcorreo(correo) {
    var newemail = correo + "@inresorts.club";
    //document.getElementById('cor' + num + '').innerHTML = newemail;

    return newemail;
}
function modalR2(correo, username) {

    params = "params=" + crearcorreo(correo) + "|" + username;
    GetDos("MailSetBussinesC", params, modalS);
}

function modalR(data) {
    //Send("ReceiptsUser", 'dd', ej);
    alert(data);
    window.location.href = 'ReceiptsUser.aspx?action=1&variable1=' + (data);

}

function modalS(data) {
    alert(data);
    location.href = "MailAccountActive.aspx";
}




function FilterPartner(_value) {
    let value = document.getElementById(_value).value;
    let param = "action=filter&value=" + value;
    GetDos("MailAccountC", param, ShowList);
}

