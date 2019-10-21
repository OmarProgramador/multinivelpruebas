window.onload = function () {
    GetDos("EditC", null, (anwser) => {

        let textHtml = "";
        let arrayInfo = anwser.split('¬');
        if (arrayInfo.length > 1) {
            let list = arrayInfo[0].split('|');
            let name = arrayInfo[1];
            textHtml += "<ul>";
            textHtml += "<li><a href='/Resources/PoliticsPdf/PLAN_COMPENSACION_INRESORTS.pdf' target='_blank'>Plan de Conpensacion</a></li>";
            textHtml += "<li><a href='/Resources/PoliticsPdf/Reglamento_de_Ética_inResorts.pdf' target='_blank'>Reglamento de ETICA</a></li>";
            textHtml += "<li><a href='/Resources/PoliticsPdf/PLAN_DE_BENEFICIOS_INRESORTS.pdf' target='_blank'>Plan de Beneficios</a></li>";
            textHtml += "</ul>";
            for (var i = 0; i < list.length; i++) {

                if (list[i].trim() === "SBY") {
                    textHtml += "<ul>";
                    textHtml += "<li><a href='/Resources/PoliticsPdf/CON" + name + i.toString() + ".pdf' target='_blank'>Contrato</a></li>";
                    textHtml += "<li><a href='/Resources/PoliticsPdf/CRO" + name + i.toString() + ".pdf' target='_blank'>Cronograma</a></li>";
                    textHtml += "<li><a href='/Resources/PoliticsPdf/PAG" + name + i.toString() + ".pdf' target='_blank'>Pagare</a></li>";
                    textHtml += "<li><a href='/Resources/PoliticsPdf/Certi" + name + i.toString() + ".pdf' target='_blank'>Certificado</a></li>";
                    textHtml += "</ul>";
                } else if (list[i].trim() === "KIT") {
                    textHtml += "";

                } else {
                    textHtml += "<ul>";
                    textHtml += "<li><a href='/Resources/PoliticsPdf/CON" + name + i.toString() + ".pdf' target='_blank'>Contrato</a></li>";
                    textHtml += "<li><a href='/Resources/PoliticsPdf/CRO" + name + i.toString() + ".pdf' target='_blank'>Cronograma</a></li>";
                    textHtml += "<li><a href='/Resources/PoliticsPdf/PAG" + name + i.toString() + ".pdf' target='_blank'>Pagare</a></li>";
                    textHtml += "<li><a href='/Resources/PoliticsPdf/CER" + name + i.toString() + ".pdf' target='_blank'>Certificado</a></li>";
                    textHtml += "</ul>";
                }
            }
        }
        document.getElementById('listDoc').innerHTML = textHtml;
        document.getElementById('divProgressBar').classList.toggle('display-none');
    });


    //GetDos("EditB", "action=get", (_data) => {
    //    ShowTable(_data);
    //});

};

function ShowListDoc(anwser) {

}

var btnGuardarBenef = document.getElementById('GuardarBenef');
var nameBenefi = document.getElementById('NameBenef');
var docBenefi = document.getElementById('DocBenef');
var parentescoBenefi = document.getElementById('ParentescoBenef');
var typeBenefi = document.getElementById('TypeBenef');

btnGuardarBenef.addEventListener("click", function () {
    let count = 0;
    let nameb = nameBenefi.value;
    let docb = docBenefi.value;
    let parentb = parentescoBenefi.value;
    let typeb = typeBenefi.value;

    nameBenefi.classList.remove('is-invalid');
    docBenefi.classList.remove('is-invalid');
    parentescoBenefi.classList.remove('is-invalid');
    typeBenefi.classList.remove('is-invalid');


    if (nameb === "" || nameb.length < 10) {
        nameBenefi.classList.add('is-invalid');
        count++;
    }
    if (docb === "" || docb.length < 8) {
        docBenefi.classList.add('is-invalid');
        count++;
    }
    if (parentb === "" || parentb.length < 5) {
        parentescoBenefi.classList.add('is-invalid');
        count++;
    }
    if (typeb === "") {
        typeBenefi.classList.add('is-invalid');
        count++;
    }
    if (count > 0) {
        return;
    }

    let param = "action=insert&name=" + nameb + "&numdoc=" + docb + "&parent=" + parentb + "&type=" + typeb;
    SendDos("EditB", param, ShowMessagge);
});

nameBenefi.addEventListener("click", function () {
    this.classList.remove('is-invalid');
});
docBenefi.addEventListener("click", function () {
    this.classList.remove('is-invalid');
});
parentescoBenefi.addEventListener("click", function () {
    this.classList.remove('is-invalid');
});
typeBenefi.addEventListener("click", function () {
    this.classList.remove('is-invalid');
});



function ShowMessagge(answer) {
    //document.getElementById('beneficiarioModalCenter').style.display = "none";
    $('#beneficiarioModalCenter').modal('hide');
    document.getElementById('divMessagge').className = "row";
    document.getElementById('messagge').innerHTML = answer;
    GetDos("EditB", "action=get", ShowTable);
}

function ShowTable(answer) {
    let tableHtml = "<p>No hay Datos</p>";
    if (answer !== "") {
        tableHtml = "";
        tableHtml += "<table class='table'>";
        tableHtml += "<tr>";
        tableHtml += "<th>#</th>";
        tableHtml += "<th>Id</th>";
        tableHtml += "<th>Nombres</th>";
        tableHtml += "<th>Nro Documento</th>";
        tableHtml += "<th>Parentesco</th>";
        tableHtml += "<th>Type</th>";
        tableHtml += "</tr>";

        let rows = answer.split('¬');
        for (var i = 0; i < rows.length; i++) {
            let row = rows[i].split('|');
            tableHtml += "<tr><td>" + (i + 1).toString() + "</td>";
            tableHtml += "<td>" + row[0] + "</td>";
            tableHtml += "<td>" + row[1] + "</td>";
            tableHtml += "<td>" + row[2] + "</td>";
            tableHtml += "<td>" + row[3] + "</td>";
            if (row[4] === "0") {
                row[4] = "Directo";
            } else {
                row[4] = "Adicional";
            }
            tableHtml += "<td>" + row[4] + "</td></tr>";

        }
        tableHtml += "</table>";
    }
    document.getElementById('listBeneficiarios').innerHTML = tableHtml;
}