
window.onload = function () {
    let host = window.location.toString();
    host = host.replace('Register', 'Login');

    let afiliate = document.getElementById('lblU').innerText;
    
    document.getElementById('miEnlaces').innerText = host + "?afiliate=" + afiliate.trim();
    
}



var country = document.getElementById('ddlCountry');
var codPais = document.getElementById('codPais');

document.getElementById('cbConfig').onchange = function () {
    if (this.checked) {
        document.getElementById('ddlDateCuotas').disabled = false;
    } else {
        document.getElementById('ddlDateCuotas').disabled = true;
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
                    document.getElementById('memVacacional').className = "";
                    document.getElementById('DivFrac').className = "";
                    document.getElementById('spnQuotesExp').className = "";
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



document.getElementById('btnGenerarlink').addEventListener("click", function () {

    let host = window.location.toString();
    host = host.replace('Register', 'Login');

    let upliner = CboSelectedText('ddlSons');
    let afiliate = document.getElementById('lblU').innerText;
    let arrayupliner = upliner.innerText.split('/');
    document.getElementById('lblGenerarLink').innerText = host + "?afiliate=" + afiliate.trim() + "&upliner=" + arrayupliner[1].trim();
    document.getElementById('lblGenerarLink2').innerText = host + "?afiliate=" + afiliate.trim();
    miEnlaces
});

function ButonnCopiar(idelemento) {
    var aux = document.createElement("div");
    aux.setAttribute("contentEditable", true);
    aux.innerHTML = document.getElementById(idelemento).innerText;
    aux.setAttribute("onfocus", "document.execCommand('selectAll',false,null)");
    document.body.appendChild(aux);
    aux.focus();
    document.execCommand("copy");
    document.body.removeChild(aux);
}


function CalculateQuotes() {
    let numQuotes = parseInt(document.getElementById('NumQuotes').value);
    let variante = 0;
    let valueTotal = parseFloat(document.getElementById('ValueTotal').value);
    let first = parseFloat(document.getElementById('QuoteFirts').value);
    if (numQuotes === 2) {
        variante = valueTotal - first;
        document.getElementById('QuoteThird').value = "0";
        document.getElementById('QuoteSecond').value = variante;
    }
    if (numQuotes === 3) {
        let second = parseFloat(document.getElementById('QuoteSecond').value);
        variante = (valueTotal - (first + second));
        document.getElementById('QuoteThird').value = variante;
    }
}

country.addEventListener('change', function () {
    codPais.value = '+' + listCodPais[this.selectedIndex].toString();

    var textcountry = this.options[this.selectedIndex].text;

    document.getElementById('p1').style.display = "none";
    document.getElementById('p2').style.display = "none";

    if (textcountry === "Perú") {
        document.getElementById('p1').style.display = "block";
    } else {
        document.getElementById('p2').style.display = "block";
    }
});


var listCodPais = new Array();
listCodPais[0] = 0;
listCodPais[1] = 93;
listCodPais[2] = 355;
listCodPais[3] = 49;
listCodPais[4] = 376;
listCodPais[5] = 244;
listCodPais[6] = 1;
listCodPais[7] = 966;
listCodPais[8] = 213;
listCodPais[9] = 54;
listCodPais[10] = 374;
listCodPais[11] = 61;
listCodPais[12] = 43;
listCodPais[13] = 994;
listCodPais[14] = 1;
listCodPais[15] = 880;
listCodPais[16] = 1;
listCodPais[17] = 973;
listCodPais[18] = 32;
listCodPais[19] = 501;
listCodPais[20] = 229;
listCodPais[21] = 375;
listCodPais[22] = 591;
listCodPais[23] = 387;
listCodPais[24] = 267;
listCodPais[25] = 55;
listCodPais[26] = 673;
listCodPais[27] = 359;
listCodPais[28] = 226;
listCodPais[29] = 257;
listCodPais[30] = 975;
listCodPais[31] = 238;
listCodPais[32] = 855;
listCodPais[33] = 237;
listCodPais[34] = 1;
listCodPais[35] = 974;
listCodPais[36] = 235;
listCodPais[37] = 56;
listCodPais[38] = 86;
listCodPais[39] = 357;
listCodPais[40] = 57;
listCodPais[41] = 269;
listCodPais[42] = 850;
listCodPais[43] = 82;
listCodPais[44] = 225;
listCodPais[45] = 506;
listCodPais[46] = 385;
listCodPais[47] = 53;
listCodPais[48] = 45;
listCodPais[49] = 1;
listCodPais[50] = 593;
listCodPais[51] = 20;
listCodPais[52] = 503;
listCodPais[53] = 971;
listCodPais[54] = 291;
listCodPais[55] = 421;
listCodPais[56] = 386;
listCodPais[57] = 34;
listCodPais[58] = 1;
listCodPais[59] = 372;
listCodPais[60] = 251;
listCodPais[61] = 679;
listCodPais[62] = 63;
listCodPais[63] = 358;
listCodPais[64] = 33;
listCodPais[65] = 241;
listCodPais[66] = 220;
listCodPais[67] = 995;
listCodPais[68] = 233;
listCodPais[69] = 1;
listCodPais[70] = 30;
listCodPais[71] = 502;
listCodPais[72] = 224;
listCodPais[73] = 240;
listCodPais[74] = 245;
listCodPais[75] = 592;
listCodPais[76] = 509;
listCodPais[77] = 504;
listCodPais[78] = 36;
listCodPais[79] = 91;
listCodPais[80] = 62;
listCodPais[81] = 964;
listCodPais[82] = 98;
listCodPais[83] = 353;
listCodPais[84] = 354;
listCodPais[85] = 692;
listCodPais[86] = 677;
listCodPais[87] = 972;
listCodPais[88] = 39;
listCodPais[89] = 1;
listCodPais[90] = 81;
listCodPais[91] = 962;
listCodPais[92] = 7;
listCodPais[93] = 254;
listCodPais[94] = 996;
listCodPais[95] = 686;
listCodPais[96] = 965;
listCodPais[97] = 856;
listCodPais[98] = 266;
listCodPais[99] = 371;
listCodPais[100] = 961;
listCodPais[101] = 231;
listCodPais[102] = 218;
listCodPais[103] = 423;
listCodPais[104] = 370;
listCodPais[105] = 352;
listCodPais[106] = 389;
listCodPais[107] = 261;
listCodPais[108] = 60;
listCodPais[109] = 265;
listCodPais[110] = 960;
listCodPais[111] = 223;
listCodPais[112] = 356;
listCodPais[113] = 212;
listCodPais[114] = 230;
listCodPais[115] = 222;
listCodPais[116] = 52;
listCodPais[117] = 691;
listCodPais[118] = 373;
listCodPais[119] = 377;
listCodPais[120] = 976;
listCodPais[121] = 382;
listCodPais[122] = 258;
listCodPais[123] = 95;
listCodPais[124] = 264;
listCodPais[125] = 674;
listCodPais[126] = 977;
listCodPais[127] = 505;
listCodPais[128] = 227;
listCodPais[129] = 234;
listCodPais[130] = 47;
listCodPais[131] = 64;
listCodPais[132] = 968;
listCodPais[133] = 31;
listCodPais[134] = 92;
listCodPais[135] = 680;
listCodPais[136] = 507;
listCodPais[137] = 675;
listCodPais[138] = 595;
listCodPais[139] = 51;
listCodPais[140] = 48;
listCodPais[141] = 351;
listCodPais[142] = 44;
listCodPais[143] = 236;
listCodPais[144] = 420;
listCodPais[145] = 242;
listCodPais[146] = 243;
listCodPais[147] = 1;
listCodPais[148] = 250;
listCodPais[149] = 40;
listCodPais[150] = 7;
listCodPais[151] = 685;
listCodPais[152] = 1;
listCodPais[153] = 378;
listCodPais[154] = 1;
listCodPais[155] = 1;
listCodPais[156] = 239;
listCodPais[157] = 221;
listCodPais[158] = 381;
listCodPais[159] = 248;
listCodPais[160] = 232;
listCodPais[161] = 65;
listCodPais[162] = 963;
listCodPais[163] = 252;
listCodPais[164] = 94;
listCodPais[165] = 268;
listCodPais[166] = 27;
listCodPais[167] = 249;
listCodPais[168] = 211;
listCodPais[169] = 46;
listCodPais[170] = 41;
listCodPais[171] = 597;
listCodPais[172] = 66;
listCodPais[173] = 255;
listCodPais[174] = 992;
listCodPais[175] = 670;
listCodPais[176] = 228;
listCodPais[177] = 676;
listCodPais[178] = 1;
listCodPais[179] = 216;
listCodPais[180] = 993;
listCodPais[181] = 90;
listCodPais[182] = 688;
listCodPais[183] = 380;
listCodPais[184] = 256;
listCodPais[185] = 598;
listCodPais[186] = 998;
listCodPais[187] = 678;
listCodPais[188] = 58;
listCodPais[189] = 84;
listCodPais[190] = 967;
listCodPais[191] = 253;
listCodPais[192] = 260;
listCodPais[193] = 263;

var cboHtml = "";

var ddlDateCuota = document.getElementById('ddlDateCuotas');
var isValidInitia = document.getElementById('IsValidInitial');
isValidInitia.addEventListener("change", function () {
    if (this.checked) {
        GetDos("_DatePayInitial", null, (_data) => {
            ddlDateCuota.innerHTML = _data;
            let cbogroups = {};
            $("select option[data-category]").each(function () {
                cbogroups[$.trim($(this).attr("data-category"))] = true;
            });
            $.each(cbogroups, function (c) {
                $("select option[data-category='" + c + "']").wrapAll('<optgroup label="' + c + '">');
            });
        });
    } else {
        ddlDateCuota.innerHTML = cboHtml;
        let cbogroups = {};
        $("select option[data-category]").each(function () {
            cbogroups[$.trim($(this).attr("data-category"))] = true;
        });
        $.each(cbogroups, function (c) {
            $("select option[data-category='" + c + "']").wrapAll('<optgroup label="' + c + '">');
        });
    }
});

ddlDateCuota.addEventListener("change", function () {
    DateCbo.value = this.options[this.selectedIndex].value;
});

cboHtml = ddlDateCuota.innerHTML;