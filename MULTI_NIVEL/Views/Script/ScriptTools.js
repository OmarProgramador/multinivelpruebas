window.onload = function () {
    let param = "";
    GetDos("UploadToolsC", param, ShowVideos);
}

function ShowVideos(data) {
    let tableHtml = "";
    if (data !== "") {

        let arrayData = data.split('|');
        for (var i = 0; i < arrayData.length; i++) {
            if (arrayData[i] !== "") {
                tableHtml += "<div style='width: 210px;margin: 8px auto;text-align: center;'>";
                tableHtml += "<video controls='controls'>";
                //let sinespcarp = arrayData[i].replace(/ /g, "");
                tableHtml += "<source src='../Archivos/videos/" + arrayData[i] + "' type='video/mp4'>";
                tableHtml += "</video>";
                tableHtml += "</div>";

            }
        }
        document.getElementById('idvideos').innerHTML = tableHtml;
    }
}

function Response(data) {
    alert(data);
    location.reload();
}
