

if (screen.width < 450) {
    document.getElementById('tbDetalle').className += " table-responsive";
}


document.getElementById('btnProcesar').onclick = function () {

    var rbOnLine = document.getElementById('rbOnLine');
    var rbAgentes = document.getElementById('rbAgentes');
    var rbBanca = document.getElementById('rbBanca');
    var rbOficina = document.getElementById('rbOficina'); 
    var rbWallet = document.getElementById('rbWallet'); 

    if (rbWallet.checked) {
        location.href = "/Views/AddMembPayWallet.aspx?for=4";
    }
    if (rbOnLine.checked) {
        location.href = "/Views/AddMembCulqui.aspx";
    }
    if (rbAgentes.checked) {
        location.href = "/Views/AddMembPayDeposito.aspx?for=2";
    }
    if (rbBanca.checked) {
        location.href = "/Views/AddMembPayDeposito.aspx?for=3";
    }
    if (rbOficina.checked) {
        location.href = "/Views/AddMembPayDeposito.aspx?for=4";
    }
    
}