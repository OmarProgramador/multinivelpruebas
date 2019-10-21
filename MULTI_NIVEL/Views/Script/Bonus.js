
var nameDiv = "";

function ShowListBonus(data) {
    document.getElementById(nameDiv).innerHTML = data;
}


function ShowBonus(_div, idPeriod) {
    nameDiv = _div;

    let contediv = document.getElementById(_div).innerHTML;

    if (contediv === "") {
        let param = "action=bonus&period=" + idPeriod;
        GetDos("BonusC", param, ShowListBonus);
    }
}


function ShowPeriod(data) {
    document.getElementById('info_bonus').innerHTML = data;

    document.getElementById('divProgressBar').className = "display-none";
}


window.onload = function () {
    let param = "action=period&pag=10";
    GetDos("BonusC", param, ShowPeriod);
}


document.getElementById('numDiv').onchange = function () {
    let param = "action=period&pag=" + this.options[this.selectedIndex].text;
    GetDos("BonusC", param, ShowPeriod);
}