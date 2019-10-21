
window.onload = function () {
    
}

document.getElementById('rbUpgrade').onchange = function () {
    let lblAmountUpgrad = document.getElementById('lblAmountUpgrade');
    lblAmountUpgrad.innerHTML = "";

    if (this.checked) {
        document.getElementById('ddlMysMembership').style.display = "inline";
       
    }    
}

document.getElementById('rbnNewPackage').onchange = function () {
    if (this.checked) {
        document.getElementById('ddlMysMembership').style.display = "none";
    }
}
var ddlMysMembershi = document.getElementById('ddlMysMembership');

ddlMysMembershi.addEventListener("click", function () {
    let param = "id=" + this.value;
    GetDos("VerifUpgrade", param, ShowUpgrate);

});


function infoCode() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var texto = '' + httpRequest.responseText;
            texto = texto.split('¬');
            if (texto[0] === "true") {
                document.getElementById('lblMessaggeVerif').innerText = "Valido";
                document.getElementById('lblMessaggeVerif').style.color = "Green";
                document.getElementById('lblMessaggeVerif').style.fontWeight = "Bold";
                document.getElementById('lblMessaggeVerif').style.fontSize = "14pt";
            } else {
                document.getElementById('txtCodPromocional').value = "";
                document.getElementById('lblMessaggeVerif').innerText = "No Valido";
                document.getElementById('lblMessaggeVerif').style.color = "Red";
                document.getElementById('lblMessaggeVerif').style.fontWeight = "Bold";
                document.getElementById('lblMessaggeVerif').style.fontSize = "14pt";
            }
        }
    }
}

document.getElementById('cbCodPromocional').onchange = function () {
    if (this.checked) {
        document.getElementById('txtCodPromocional').disabled = false;
    } else {
        document.getElementById('txtCodPromocional').disabled = true;
    }
}

document.getElementById('btnVerificar').onclick = function () {
    var cbCode = document.getElementById('cbCodPromocional');
    if (cbCode.checked) {
        var code = document.getElementById('txtCodPromocional').value;
        if (code.trim() !== "") {
            var param = "code=" + code;
            Get("VerificationCodeC", param, infoCode);
        }else {
        document.getElementById('lblMessaggeVerif').innerText = "Ingrese Un Codigo";
        }
    }
    
}

document.getElementById('cbConfig').onchange = function () {
    if (this.checked) {
        document.getElementById('ddlDateCuotas').disabled = false;
        
    } else {
        document.getElementById('ddlDateCuotas').disabled = true;
    }
}

function ShowUpgrate(answer) {
    let number = parseInt(answer);
    let lblAmountUpgrad = document.getElementById('lblAmountUpgrade');
    if (number == 0) {
        lblAmountUpgrad.innerHTML = "";
    } else {
        lblAmountUpgrad.innerHTML = "El Upgrade tiene un adicional de $ " + number.toString() + "";
    }
}

document.getElementById('btnCodSecreto').onclick = function () {
    document.getElementById('lblResponseCod').innerText = "";
    let valor = document.getElementById('txtCodSecreto').value;
    if (valor !== "") {
        let param = "option=codSecreto&valueCod=" + valor;
        Get("RegisterData", param, ResponseCod);
    }
}

function ResponseCod() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var response = '' + httpRequest.responseText;
            if (response !== "") {
                if (response === "true") {
                    document.getElementById('DivFrac').className = "";
                    document.getElementById('memVacacional').className = "";

                }
                else {
                    document.getElementById('lblResponseCod').innerText = "Codigo Incorrecto";
                }
            }
            else {
                document.getElementById('lblResponseCod').innerText = "Codigo Incorrecto";
            }
        }
    }
}

function CalculateQuotes() {
    let numQuotes = parseInt(document.getElementById('NumQuotes').value);
    let variante = 0;
    let valueTotal = parseFloat(document.getElementById('ValueTotal').value);
    let first = parseFloat(document.getElementById('QuoteFirts').value);
    if (numQuotes === 2) {
        variante = valueTotal - first;
        document.getElementById('QuoteSecond').value = variante;
        document.getElementById('QuoteThird').value = "0";

    }
    if (numQuotes === 3) {
        let second = parseFloat(document.getElementById('QuoteSecond').value);
        variante = (valueTotal - (first + second));
        document.getElementById('QuoteThird').value = variante;
    }
}
