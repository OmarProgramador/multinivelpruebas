var word = "hola";

var montoSoles = 0;
var cuotas = 0;
var montoCuota = 0;
var mestext;
var dia;
var anio;
var rtp;

function BorrarDecimal(num) {
    var resul = (parseInt(num * 100) / 100);

    return resul;
}


function isEmpty(str) {
    return (!str || 0 === str.length);
}

function fechaFormat(date) {
    var format = new Date(date);
    return ((getDia(format)) + "/" + (getMes(format)) + "/" + format.getFullYear());
}


function getMes(date) {
    var format = new Date(date);

    if ((format.getMonth() + 1) < 10) {
        return "0" + (format.getMonth() + 1).toString();
    }
    return (format.getMonth() + 1);
}
function getAnio(date) {
    var format = new Date(date);
    return (format.getFullYear());
}
function getDia(date) {

    var f = new Date(date);

    f.setDate(f.getDate() + 1);

    return f.getDate();
}


function DescargarPagare() {
    //CreateFilePagare();
    var blob = new Blob([word], { type: 'application/vnd.ms-word' });
    if (navigator.appVersion.toString().indexOf('.NET') > 0) {
        window.navigator.msSaveBlob(blob, "PAGARES.doc");
    } else {
        this.download = "PAGARES.doc";
        this.href = window.URL.createObjectURL(blob);
    }
}


function CreateFilePagare() {

    //var minum_cuotas = document.getElementById("num_cuotas");
    //var num_cuotas_letras = minum_cuotas.options[minum_cuotas.selectedIndex].innerText;
    word = "<html "
        + " xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'"
        + " xmlns:w='urn:schemas-microsoft-com:office:word' "
        + " xmlns:m='http://schemas.microsoft.com/office/2004/12/omml'"
        + " xmlns='http://www.w3.org/TR/REC-html40' >"
        + " <head><meta charset='UTF-8'></meta><style type='text/css'>"
        + "@page WordSection1{size:612.0pt 792.0pt;margin:28.4pt 23.7pt 70.85pt 1.0cm;mso-header-margin:35.4pt;mso-footer-margin:35.4pt;mso-paper-source:0;}div.WordSection1{page:WordSection1;}"
        + "</style>";

    word += "</head><body lang='EN-US' style='tab-interval:35.4pt' ><div class=WordSection1></div>";

    var array_pagares = new Array();
    var array_pagares_fechas = new Array();
    var array_pagares_cuotas = new Array();
    var array_tasa_anual = new Array();

    //var mi_num_pagares = document.getElementById('num_pagares');
    var mi_valor_pagares = 1

    //if (mi_valor_pagares >= 1) {
    //    array_pagares[0] = document.getElementById('monto_pagare1').value;
    //    array_pagares_fechas[0] = document.getElementById('fecha_pagare1').value;
    //    array_pagares_cuotas[0] = document.getElementById('cuotas_pagare1').value;
    //    array_tasa_anual[0] = document.getElementById('tasa_anual_pagare1').value;
    //}
    //if (mi_valor_pagares >= 2) {
    //    array_pagares[1] = document.getElementById('monto_pagare2').value;
    //    array_pagares_fechas[1] = document.getElementById('fecha_pagare2').value;
    //    array_pagares_cuotas[1] = document.getElementById('cuotas_pagare2').value;
    //    array_tasa_anual[1] = document.getElementById('tasa_anual_pagare2').value;
    //}
    //if (mi_valor_pagares >= 3) {
    //    array_pagares[2] = document.getElementById('monto_pagare3').value;
    //    array_pagares_fechas[2] = document.getElementById('fecha_pagare3').value;
    //    array_pagares_cuotas[2] = document.getElementById('cuotas_pagare3').value;
    //    array_tasa_anual[2] = document.getElementById('tasa_anual_pagare3').value;
    //}
    //if (mi_valor_pagares >= 4) {
    //    array_pagares[3] = document.getElementById('monto_pagare4').value;
    //    array_pagares_fechas[3] = document.getElementById('fecha_pagare4').value;
    //    array_pagares_cuotas[3] = document.getElementById('cuotas_pagare4').value;
    //    array_tasa_anual[3] = document.getElementById('tasa_anual_pagare4').value;
    //}
    //if (mi_valor_pagares == 5) {
    //    array_pagares[4] = document.getElementById('monto_pagare5').value;
    //    array_pagares_fechas[4] = document.getElementById('fecha_pagare5').value;
    //    array_pagares_cuotas[4] = document.getElementById('cuotas_pagare5').value;
    //    array_tasa_anual[4] = document.getElementById('tasa_anual_pagare5').value;
    //}

    //console.log(array_tasa_anual);
    /*inicio del for*/
    for (var i = 0; i < mi_valor_pagares; i++) {
        word += "<div style='font-size: 12pt;font-family:Calibri'><center><b> PAGARÉ N° <u>"
            + document.getElementById('num_contrato').value.toUpperCase()
            + "-"
            + (i + 1)
            + "</u></b></center></br></div>";

        word += "<div style='font-size: 10pt;font-family:Calibri'><center><b> POR UN VALOR DE (<u>&nbsp;"
            + NumerosaLetras((array_pagares[i] * parseFloat(document.getElementById('tipo_cambio').value)))
            + " SOLES</u>)</b></center></br></div>";

        word += "<div style='font-size: 10pt;font-family:Calibri'><center>(S/.&nbsp;<u>"
            + BorrarDecimal(parseFloat(array_pagares[i] * parseFloat(document.getElementById('tipo_cambio').value))).toFixed(2)
            + "&nbsp;</u>) ESTE VALOR ES EL SALDO A FINANCIAR</center></br></div>";

        word += "<div style='font-size: 10pt;margin: 0;padding:0;font-family:Calibri;text-align: justify;'><span> Yo <b>"
            + document.getElementById("nombres").value.toUpperCase() /*+ " "+document.getElementById("apellidos").value*/
            + "</b> identificado(a) con DNI Nº <b>"
            + document.getElementById("dni").value
            + "</b> con domicilio y residencia en <b>"
            + document.getElementById("domicilio").value.toUpperCase()
            + "</b> </span></div>";
        word += "<div style='font-size: 10pt;margin: 0;padding:0;font-family:Calibri;text-align: justify;'><span> "
            + "Me comprometo a pagar incondicionalmente a VALLE ENCANTADO S.A.C la suma de <b>"
            + NumerosaLetras((array_pagares[i] * parseFloat(document.getElementById('tipo_cambio').value)))
            + " SOLES </b> (S/ <b><u>&nbsp;"
            + BorrarDecimal(parseFloat(array_pagares[i] * parseFloat(document.getElementById('tipo_cambio').value))).toFixed(2)
            + "&nbsp;</u></b>) pagadero en <b>"
            + array_pagares_cuotas[i].toString()
            + "</b> cuotas mensuales y consecutivas con vencimiento la primera de ella el día <b>"
            + dateLarge(array_pagares_fechas[i])
            + "</b> , por valor de (S/. <b><u>&nbsp;"
   /**/ + (BorrarDecimal(calcularCuotaMensual((array_pagares[i] * parseFloat(document.getElementById('tipo_cambio').value)), array_tasa_anual[i], array_pagares_cuotas[i])).toFixed(2))
            + "&nbsp;</u></b> ). El pago de dichas cuotas se realizará en Soles a razón del cambio oficial vigente a la fecha en que se efectúe éste. En caso de mora y mientras ella subsista pagaré intereses moratorios a la tasa máxima establecida para el periodo correspondiente. De igual manera me obligo a pagar todos los gastos y costos de la cobranza judicial.  </span></div>";
        word += "<div style='font-family: Calibri ; margin: 3px;padding:3px;font-size: 10pt;text-align: justify;'> <span>En el evento en que el deudor no pague en el plazo estipulado una o más cuotas, el tenedor de este título podrá declarar vencidos todos los plazos de esta obligación y pedir su inmediato pago total o el pago del saldo.</span></b></div>";
        word += "<div style='font-family: Calibri ; margin: 3px;padding:3px;font-size: 10pt;text-align: justify;'> <span>También acepto que <b>VALLE ENCANTADO S.A.C</b>, declare de plazo vencido la obligación a la que se refiere este pagaré y exigir su pago total en el evento en que sea perseguido judicialmente. El recibo de abono de parciales no implica novación y cualquier pago que se efectúe se imputará primero a gastos, penalidades, y por último a capital. El suscriptor de este pagaré hace constatar que la obligación de pagarla indivisiblemente y solidariamente subsiste en caso de prórroga o prórrogas o de cualquier modificación a lo estipulado. El deudor declara que la suma que debe conforme a este pagaré, no estará sujeta ni a deducción ni a descuentos de cualquier naturaleza, incluyendo sin limitación cualquier impuesto que pueda gravar su pago, por lo tanto, en caso de existir alguna de estas deducciones o descuentos, el deudor deberá aumentar la suma a pagar de tal manera que el tenedor reciba siempre el valor estipulado del pagaré. El deudor acepta desde ahora el endoso, cesión o transferencia que de este pagaré a VALLE ENCANTADO S.A.C. todos los gastos e impuestos relacionados con la suscripción de este pagaré serán por cuenta del deudor. </span></div>";
        word += "<div style='font-family: Calibri ; margin: 3px;padding:3px;font-size: 10pt;text-align: justify;'> <span>Todos los pagos que deban hacerse según este pagaré serán hechos exclusivamente en Soles, a la <b>Cuenta Recaudadora Soles BCP N°193-2361209-0-94</b>, en su oficina central ubicada en Av. Guardia Civil 1321 oficina 602 – Surquillo o en Ribera del Río Club Resort ubicada en Mz. B Lt. 72. Tercera Etapa - Cieneguilla. </span> </div>";

        word += "<div style='font-family: Calibri ;margin: 0;padding:0;font-size: 10pt;text-align: justify;'><span>Todos los cálculos de intereses se efectuarán sobre la base de un año de trescientos sesenta (360) días, en cada caso por el número de días efectivamente transcurridos (incluyendo el primer día, pero excluyendo el último día) durante el pazo por el cual deban pagarse tale intereses. Si cualquiera de las fechas de pago de principal o intereses antes indicadas coincidiera con un día no hábil, se entenderá que el pago respectivo deberá ser efectuado el día hábil inmediatamente siguiente.</span></div>";

        word += "<div style='font-family: Calibri ;font-size: 10pt;text-align: justify;'><span>Cualquier referencia en este pagaré al agente deberá entenderse efectuada a cualquier tenedor del mismo, sea que lo adquiera por endoso o de otro modo.</span></div>";
        word += "<div style='font-family: Calibri ;font-size: 10pt;text-align: justify;'><span>En caso de mora, no será necesario requerimiento alguno para que el Cliente incurra en la misma, de acuerdo a lo establecido en el artículo 1333 inciso 1 del Código Civil Peruano. En dicho caso, durante todo el periodo de incumplimiento el cliente pagara a una tasa equivalente al máximo de interés permitido por la ley, por concepto de interés moratorio.</span></div>";
        word += "<div style='font-family: Calibri ;font-size: 10pt;text-align: justify;'><span>De conformidad con lo establecido por el artículo 158.2 concordante con el artículo 52° de la Ley de Títulos Valores, este pagaré no requerirá ser protestado por la falta de pago de cualquiera de las cuotas para ejercitar las acciones derivadas del mismo.</span></div>";
        word += "<div style='font-family: Calibri ;font-size: 10pt;text-align: justify;'><span>Adicionalmente, el cliente se obliga incondicionalmente a pagar al Agente todos los gastos en que éste incurra en razón de su incumplimiento, obligándose a pagar sobre éstos el mismo interés moratorio pactado en este pagaré.</span></div>";
        word += "<div style='font-family: Calibri ;font-size: 10pt;text-align: justify;'><span>Asimismo, el cliente acepta las renovaciones y prórrogas de vencimiento de este pagaré que el agente considere conveniente efectuar, ya sea por su importe parcial o total, aun cuando no hayan sido comunicadas al cliente. Dichas modificaciones serán anotadas en este mismo instrumento o en hoja anexa, sin que sea necesaria la suscripción de tal instrumento.</b></span></div>";
        word += "<div style='font-family: Calibri ;font-size: 10pt;text-align: justify;'><span>Este pagare se devolverá a su cancelación total. Queda expresamente establecido que el domicilio del cliente es "
            + "<b>" + document.getElementById("domicilio").value.toUpperCase()
            + " - Lima Perú</b>, lugar a donde se dirigirán todas las comunicaciones y notificaciones derivadas de este pagaré. </span></div>";
        word += "<div style='font-family: Calibri ;font-size: 10pt;text-align: justify;'><span>Queda establecido que las obligaciones contenidas en este pagaré, constituyendo el presente acuerdo pacto en contrario a lo dispuesto por el artículo 1233° del Código Civil.</span></div>";
        word += "<div style='font-family: Calibri ;font-size: 10pt;text-align: justify;'><span>Este pagaré se regirá bajo las leyes de la República del Perú.</span></div>";
        word += "<div style='font-family: Calibri ;font-size: 10pt;text-align: justify;'><span>Cualquier acción o procedimiento legal relacionado con y derivado del presente pagaré podrá ser iniciado ante los órganos judiciales del Cercado de Lima, Lima, Perú. El cliente renuncia a la jurisdicción de cualquier otro tribunal que pudiere corresponderle por cualquier otra razón.</span></div>";
        word += "<div style='font-family: Calibri ;font-size: 10pt;text-align: justify;'><span>En constancia de lo anterior, se firma el presente pagaré el día <b>"
            + dateLarge(document.getElementById("fecha_actual").value)
            + "</b> en la ciudad de Lima, <br>El Deudor.<br><br></span></div>";


        word += "  <div style='margin-left: 350px ;font-family: Calibri ;font-size: 10pt'>_______________________</div>";
        word += "  <div style='margin-left: 350px ;font-family: Calibri ;font-size: 10pt'>FIRMA</div>";
        word += "  <div style='margin-left: 350px ;font-family: Calibri ;font-size: 10pt'>DNI N° <b>"
            + document.getElementById("dni").value
            + "</b></div><br><br><br>";

    }/*fin de for*/


    word += "</body></html>";

}

function guardarImagenFichero(img) {
    if (typeof img == 'object')
        img = img.src;
    window.newW = open(img);
    newW.document.execCommand("SaveAs");
    newW.close();
}
function calc() {
    var pmf = parseInt(document.getElementById("max_financiamiento_porcentaje").value.toString());
    var cuoIni = 100 - pmf;
    console.log(cuoIni);
    document.getElementById("cuota_inicial").value = cuoIni.toString();

}


function fechanom() {
    var fecha = new Date();
    var actual = fecha.getDate() + "/" + fecha.getMes() + "/" + fecha.getFullYear();
    var verdad = fecha.getFullYear() + "/" + fecha.getMes() + "/" + fecha.getDate();
    document.getElementById("fecha").value = verdad.value;

}
function fin() {
    var meses = new Array("Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre");
    var diasSemana = new Array("Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado");
    var f = new Date(); /*fecha de la computadora*/
    var fechainput = document.getElementById("fecha").value; /*fecha seleccionada en el input*/
    var hola = (/*diasSemana[f.getDia()] + ", " +*/ f.getDate() + " de " + meses[f.getMes()] + " de " + f.getFullYear());

    var k = (f.getFullYear() + "-" + f.getMes() + "-" + f.getDate());
    document.getElementById("fecha").value = (f.getFullYear() + "-" + f.getMes() + "-" + f.getDate());
    var parts = fechainput.split("-");

    anio = parts[0];
    var mes = parseInt(parts[1]);
    dia = parts[2];
    mestext = meses[mes - 1];
    document.getElementById("anotar").value = dia + " " + mestext + " " + anio;
    var qqq = dia + " " + mestext + " " + anio;

}


function api_tipo_cambio() {
    /*
    URL = 'https://www.deperu.com/api/rest/cotizaciondolar.json'
    fetch(URL)
        .then(response => response.json())
        .then(response => {
        var resp = response.Cotizacion[0].Venta;
        document.getElementById("tipo_cambio").value = resp;
        rtp = resp;
        console.log(resp);
    });
       */
}



function ToSoles(dolar, typeChange) {
    var mdol = parseFloat(dolar);
    var rtp = parseFloat(typeChange);

    var cambio = rtp * mdol;
    return cambio.toString();
}


function dateLarge(date) {
    var meses = new Array("Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre");
    var f = new Date(date);
    return ((getDia(f)) + " de " + meses[f.getMonth()] + " de " + f.getFullYear());
}


function cortarDecimales(num) {
    var de_array = num.split('.');
    return (de_array[0].toString() + "." + de_array[1].toString().substr(0, 2));
}


