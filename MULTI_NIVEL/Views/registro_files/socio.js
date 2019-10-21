//Inciamos JQuery
$(function(){  
	//Validamos el formulario
	$('form').validate({
		rules: {
            nombres: {required: true,maxlength: 100,minlength: 2},
            apaterno: {required: true,maxlength: 150,minlength: 2},
            amaterno: {required: true,maxlength: 150,minlength: 2},
            fecnac: {required: true, dateISO: true},
            sexo: {required: true},
            tipodoc: {required: true},
            nrodoc: {required: true,maxlength: 15,minlength: 5},
            correo: {required: true,maxlength: 150,minlength: 5,email: true},
            celular: {required: true,maxlength: 20,minlength: 5,digits: true},
            direccion: {required: true,maxlength: 255,minlength: 1},
            referencia: {maxlength: 255},
            razonsocial: {maxlength: 255},
            direccionfiscal: {maxlength: 255},
        },
        messages: {
            nombres: {
                required: "Este campo es obligatorio",
                minlength: jQuery.validator.format("Por favor, debe tener como mínimo {0} caracteres"),
                maxlength: jQuery.validator.format("Por favor, debe tener como máximo {0} caracteres")
            },
            apaterno: {
                required: "Este campo es obligatorio",
                minlength: jQuery.validator.format("Por favor, debe tener como mínimo {0} caracteres"),
                maxlength: jQuery.validator.format("Por favor, debe tener como máximo {0} caracteres")
            },
            amaterno: {
                required: "Este campo es obligatorio",
                minlength: jQuery.validator.format("Por favor, debe tener como mínimo {0} caracteres"),
                maxlength: jQuery.validator.format("Por favor, debe tener como máximo {0} caracteres")
            },
            fecnac: {
                required: "Este campo es obligatorio",
                dateISO: jQuery.validator.format("Por favor, el formato es incorrecto")
            },
            sexo: {
                required: "Este campo es obligatorio"
            },
            tipodoc: {
                required: "Este campo es obligatorio"
            },
            nrodoc: {
                required: "Este campo es obligatorio",
                minlength: jQuery.validator.format("Por favor, debe tener como mínimo {0} caracteres"),
                maxlength: jQuery.validator.format("Por favor, debe tener como máximo {0} caracteres")
            },
            correo: {
                required: "Este campo es obligatorio",
                minlength: jQuery.validator.format("Por favor, debe tener como mínimo {0} caracteres"),
                maxlength: jQuery.validator.format("Por favor, debe tener como máximo {0} caracteres"),
                email: jQuery.validator.format("Por favor, ingresar un correo válido")
            },
            celular: {
                required: "Este campo es obligatorio",
                minlength: jQuery.validator.format("Por favor, debe tener como mínimo {0} caracteres"),
                maxlength: jQuery.validator.format("Por favor, debe tener como máximo {0} caracteres"),
                digits: jQuery.validator.format("Por favor, ingresar solo dígitos")
            },
            direccion: {
                required: "Este campo es obligatorio",
                minlength: jQuery.validator.format("Por favor, debe tener como mínimo {0} caracteres"),
                maxlength: jQuery.validator.format("Por favor, debe tener como máximo {0} caracteres")
            },
            referencia: {
                maxlength: jQuery.validator.format("Por favor, debe tener como máximo {0} caracteres")
            },
            razonsocial: {
                maxlength: jQuery.validator.format("Por favor, debe tener como máximo {0} caracteres")
            },
            direccionfiscal: {
                maxlength: jQuery.validator.format("Por favor, debe tener como máximo {0} caracteres")
            }
        },
        submitHandler: function (form) {
            //document.getElementById('divProgressBar').style.display = "inline";
			$('form').submit();
		}
	});
})


//Funciones
function changuePack(item, box){
	porcentaje 	= $('#porcentaje_'+item).val();
	precio 		= $('#precio_'+item).val();
	puntos 		= $('#puntos_'+item).val();
	//$('.pack_radio').prop('checked', false);
	//$('input[name=pack_'+box+']:first-child').attr('checked',true);
	$('#packafilia_'+box).trigger('click');
	$('.txt_precio').html('S/. '+precio +' <small>'+ parseInt(puntos) +' ptos.</small>');
	$('.txt_porcentaje_'+box).html(porcentaje);
}