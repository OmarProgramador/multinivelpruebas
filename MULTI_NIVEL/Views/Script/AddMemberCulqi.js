
var numcuotes = "";

function ShowMessage(anwser) {

    document.getElementById('divProgressBar').className = "display-none";
    var data = anwser.split('¬');
    if (data[0] === "true") {
        //document.getElementById('txtMessagge').innerText = "Su Pago se Realizó con Exito";
        //$("#mdlMessagge").modal("show");
        location.href = "/Views/" + data[1];
    }
    else {
        document.getElementById('txtMessagge').innerText = data[1];
        document.getElementById('btnEnlace').href = "";
        $("#mdlMessagge").modal("show");
    }
}

$('#btnRegistePay').on('click', function (e) {
    document.getElementById('divProgressBar').className = "";

    //validar el formulario
    /* Culqi.publicKey = 'pk_live_0VvfZdSKhqDXHPvn';*/
    Culqi.publicKey = 'pk_test_8lmFNlrqh9MZp7VG';
    Culqi.init();

    var ddlQuotes = document.getElementById("ddlQuote");
    numcuotes = ddlQuotes.options[ddlQuotes.selectedIndex].value;

    // Crea el objeto Token con Culqi JS
    Culqi.createToken();
    e.preventDefault();
    culqi();

    if (Culqi.token) { // ¡Objeto Token creado exitosamente!
        var token = Culqi.token.id;
        document.getElementById('divProgressBar').className = "display-none";
        var params = "token=" + token + "&numcuotes=" + numcuotes;
        GetDos("AddMembPayWalletCc", params, ShowMessage);

    } else { // ¡Hubo algún problema!                                     
        //alert(Culqi.error.user_message);
        if (Culqi.error !== undefined) {
            alert(Culqi.error.user_message);
        }
    }

});
