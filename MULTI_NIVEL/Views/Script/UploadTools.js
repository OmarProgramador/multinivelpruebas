window.onload = function(){
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
                let sinespcarp = arrayData[i].replace(/ /g, "") + ",videos";
                tableHtml += "<span onClick=deleteDoc('" + sinespcarp +"')>X</span>";
                tableHtml += "</div>";

            }
        }
        document.getElementById('idvideos').innerHTML = tableHtml;
    }
}
function deleteDoc(idImg) {
    let data = idImg;
    let asd = data.split(',');
    
    let param = "id=" + asd[0] + "&carpeta=" + asd[1] + "&action=borrarv";
    GetDos("UploadToolsC", param, Response);
}

function Response(data) {
    alert(data);
    location.reload();
}
