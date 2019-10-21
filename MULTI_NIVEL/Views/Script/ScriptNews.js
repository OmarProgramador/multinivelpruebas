window.onload = function () {

    let param = "action=1";
    Get("NewsC", param, CreateTable);

        //userName = encodeURI(document.cookie);
        //params = "Key=" + userName;
        //Send('NotificationC', userName, HttpNews);
    }
let roro = "";


function CreateTable() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var Arraytexto = '' + httpRequest.responseText;
            let table = "";
            var estilo = "";
            if (Arraytexto !== "") {
                let rol = Arraytexto.split('$')[0];
                let texto = Arraytexto.split('$')[1];
                let rows = texto.split('¬');
                for (var i = 0; i < rows.length; i++) {
                    let row = rows[i].split('|');
                    let texto = row[3];
                    roro = row[1];
                    var Reducido = texto.substr(0, 40) + " ... ";
                    if ( rol == 1) {
                        estilo = "block";
                    } else {
                         estilo = "none";
                    }
                    //if (1 == 1) ) style = display: display = 'none';
                    table += "<div class='container'>";
                    table += "<div class='row'>";
                    table += "<div class='.col-md-4'>";
                    table += "<div class='panel-group' id='accordion'>";
                    table += "<div class='panel panel-default sombra'>";
                    table += "<div style='padding: 5px; margin: 5px auto'>";
                    table += "<a data-toggle='collapse' data-parent='#accordion' href='#collapse" + i + "'>";
                    table += "<div id='costado' style=''>";
                    table += "<img id='img' src='/Resources/ImgNews/" + row[4] + "' class='img'  style='box-shadow: -4px 5px 10px grey; border-radius: 6px;' /><br><br>"; 
                    table += "<div class='panel-heading btn btn-block t1' style='text-align: start; color: white; width: 95%; font-size: 16px; margin: 0px 10px; background-color: rgb(100, 116, 140);white-space: normal;box-shadow: -4px 5px 10px grey;'>";
                    table += "<h2><b>" + row[1] + "</b></h2> ";
                    table += "<span style='white-space: normal;'>" + Reducido + "</span><div style='font-size:14px'>Publicado el: " + row[5] +"</div> </div>";
                    table += "</div></a>";

                    table += "<center>";
                    table += "<div class='grupoboton' style='display: flex;'>";
                    table += "<div id='des' class='bontoncito' style='display:" + estilo + "'><a href='EditNews.aspx?id=" + row[0] +"&title=" + row[1] + "&content=" + row[3] + "&img=" +row[4]+"&date=" + row[5] +"' class=' btn btn-md bot'>Editar <i class='fas fa-edit'> </i></a></div>";
                    table += "<div id='des' class='bontoncito' style='display:" + estilo + "'><input type='button' id='myBtn' onclick='shohModal(" + row[0] +")' class='btn btn-md bot' value='Eliminar'> <i class='fas fa-trash-alt'></i> </input></div>";
                    table += "</div>";
                    table += "</center>";

                 //"<button type='button' id='myBtn' data-toggle='modal' data-target='#myModal' style='width: 76%;font-weight: bold;height: 40px;' class='btn btn-md btn-primary m-t-n-xs plomo'>Eliminar <i class='fas fa-trash-alt'></i> </button>"
 
                    table += "<div id='collapse" + i + "' class='panel-collapse collapse'>";
                    table += "<div class='panel-body' style='margin-right: 9px; margin-left: 9px;'>";
                    table += "<div class='' id='cssbox'>";
                    table += "<div class='row sombra'>";
                    table += "<div id='divStarterKithh' class='row minimalSpacing'>";
                    table += "<div class='col-md-12'>";
                    table += "<div class='csspqts' style=''>";
                    table += "<div class='panel-heading'>";
                    table += "<h2><strong>";
                    table += "<span style='color: black' id='lblStartedrKit'>" + row[3] + "</span>";
                    table += "</strong></h2>";
                    table += " </div> </div> </div></div></div> </div> </div></div> </div></div></div></div>";
                    table += " </div></div>";
                   
                }
                
                document.getElementById('dataList').innerHTML = table;

            }

        }
    }
    $(function () {
        $('.img').on('click', function () {
            $('.enlargeImageModalSource').attr('src', $(this).attr('src'));
            $('#enlargeImageModal').modal('show');
        });
    });


}



function shohModal(id) {
    document.getElementById('idNewsDelete').innerText = id;
    //document.getElementById('lbltitulo').innerHTML = roro;
    $('#myModal').modal('show');
}

function DeleteNews() {
    let id = document.getElementById('idNewsDelete').innerText;
    let param = "action=2&id=" + id;
    Get("NewsC", param, ResponseDelete);
    

}

function ResponseDelete() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var Arraytexto = '' + httpRequest.responseText;
            let param = "action=1";
            Get("NewsC", param, CreateTable);
            $('#myModal').modal('hide');
        }
    }
}

