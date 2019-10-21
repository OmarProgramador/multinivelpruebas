var idDoc = 0;


function RefuseSolitud() {
    $("#refuseModal").modal("hide")

    let obs = document.getElementById('Deposit-Obs-Re').value
    let param = "action=refuse&id=" + idDoc.toString() + "&obs=" + obs
    GetDos("BDepositRequestC", param, ShowMessage)
}

function DisplayModalRefuse(id) {
    idDoc = id

    $("#refuseModal").modal("show")
}


function ShowMessage(data) {

    document.getElementById('Deposit-Obs').value = ""
    document.getElementById('Deposit-Obs-Re').value = ""
    let param = "action=get"
    GetDos("BDepositRequestC", param, ShowHtml)

    document.getElementById('pmessage').innerHTML = data

    $("#messageModal").modal("show")
}

function ShowModal(id) {
    idDoc = id

    $("#aceptModal").modal("show")
}

function AceptSolitud() {
    $("#aceptModal").modal("hide")

    let obs = document.getElementById('Deposit-Obs').value
    let param = "action=acept&id=" + idDoc.toString() + "&obs=" + obs
    GetDos("BDepositRequestC", param, ShowMessage)
}

function ShowHtml(data) {
    document.getElementById('dataHtml').innerHTML = data
}

window.onload = function () {
    let param = "action=get"
    GetDos("BDepositRequestC", param, ShowHtml)
}