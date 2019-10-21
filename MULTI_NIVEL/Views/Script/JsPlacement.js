var userNameChildren = "";
var fatherId = 0;

function AnswerAsignar(data) {
    
    alert(data);
    location.reload();
}

function AsignarUpliner() {
  
    let param = "action=posi&children=" + userNameChildren + "&father=" + fatherId;
    GetDos("PlacementCc", param,AnswerAsignar);
}

function ShowModalAsignar(_userName,_children) {

    var _select = document.getElementById(_userName).firstChild;
    var _item = _select.options[_select.selectedIndex];
    var _value = _item.value;
    var _father = _item.text;

    if (parseInt(_value) < 1) {
        return;
    }

    fatherId = parseInt(_value);
    

    document.getElementById('father_mdl').innerHTML = _father;
    document.getElementById('children_mdl').innerHTML = _children;

    var arraParam = _userName.split('_');
    userNameChildren = arraParam[1];

    $("#modal1").modal("show");
}


function ShowSponsored(data) {

    document.getElementById('datasp').innerHTML = data;

}

window.onload = function () {
    let param = "action=get";
    GetDos("PlacementCc", param, ShowSponsored);
}

