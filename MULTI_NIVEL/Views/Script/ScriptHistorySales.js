window.onload = function () {
    Get("HistorySalesC", null, CreateTable);
}

function CreateTable() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var texto = '' + httpRequest.responseText;
            let table = "";
            if (texto !== "") {

                let rows = texto.split('¬');
                let compar = "";
                let arrag = [];
                for (var i = 0; i < rows.length; i++) {
                    let sep = rows[i].split('|');
                    let categoria = sep[0];
                    if (categoria != compar) {
                        compar = categoria;
                       
                        if (!arrag.includes(categoria)) {
                            arrag[i] = categoria;
                            table += "<div class='container'><div class='panel-group' id='accordion'>";
                            table += "<div >";
                            table += "<a class=' panel-default' data-toggle='collapse' data-parent='#accordion' href='#collapse" + i + "'>";
                            table += "<div class='panel-heading ' style='background-color:rgb(100,116,140);color:white'>";
                            table += "<h4 class='panel-title'>";
                            table += "" + compar + "";
                            table += "</h4>";
                            table += "</div>";
                            table += "</a>";
                            table += "<div id='collapse" + i + "' class='panel-collapse collapse'>";
                            table += "<div class='panel-body'>";
                            table += "<div class='table-responsive'>";
                            table += "<table class='table table-bordered dataTables-example dataTable'><tr>";
                            table += "<th>Item</th>";
                            table += "<th>Nombre del Beneficiario</th>";
                            table += "<th>Fecha de Adquisición</th>";
                                if (sep[3] != "") {
                                    table += "<th>Código</th>";
                                    if (sep[7] > 0) {
                                        table += "<th>Monto</th>";
                                    } else {
                                        table += "<th> Monto</th>";
                                    }
                                } else {
                                    table += "<th>Monto</th>";
                                }
                            table += "<th>Cantidad</th>";
                            table += "<th>Estado</th>";
                            table += "</tr>";
                            for (var j = 0; j < rows.length; j++) {
                                let row = rows[j].split('|');
                                if (row[0] == compar ) {
                                    table += "<tr>";
                                    table += "<td>" + row[0] + "</td>";
                                    table += "<td>" + row[1] + "</td>";
                                    table += "<td>" + row[2] + "</td>";
                                    if (row[3] != "") {
                                        table += "<td>" + row[3] + "</td>";
                                        if (row[7] > 0) {
                                            table += "<td>" + row[7] + "</td>";
                                        }
                                        else {
                                            table += "<td> En Revision</td>";
                                        }
                                    } else {
                                        table += "<td>" + row[7] + "</td>";
                                    }
                                    table += "<td>" + row[4] + "</td>";
                                    //table += "<td>" + row[5] + "</td>";
                                    table += "<td>" + row[6] + "";
                                    if (row[6] == "Rechazado") {
                                        table += " " + "<input type='button' id='btninfo' onclick=alerta('" + ReplaceAll(row[8], ' ', '&nbsp;') + "') value='!' style='border-radius:50%;background-color: #fefcfc;border: 1px solid #bf2828;color: #bf2828;width:21px'></input>";
                                    }

                                    table += "</td>";
                                    table += "</tr>";
                                }
                           
                            }
                            table += "</table>";
                            table += "</div>";
                            }
                        

                    }
                    

                    

                    table += "</div>";
                    table += "</div>";
                    table += "</div>";
                    table += "</div>";
                    table += "</div>";
                     
                };

            }
            document.getElementById('dataList').innerHTML = table;
        }
    }
}