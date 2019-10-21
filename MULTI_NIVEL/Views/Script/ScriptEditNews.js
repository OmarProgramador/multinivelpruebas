window.onload = function(){
    Get("NewsC", null, CreateTable);
}


function CreateTable() {
    if (httpRequest.readyState == 4) {
        if (httpRequest.status == 200 ) {
            var texto = '' + httpRequest.responseText;
            let table = "";
            if (texto != "") {
                let rows = texto.split('¬');
                for (var i = 0; i < rows.length; i++) {
                    let row = rows[i].split('|')
                    let texto = row[2];
                    let reducido = texto.substr(0, 40) + " ... ";



                    table += "<div class='wrapper wrapper-content animated fadeInUp nuevosocio'>";
                    table += "<div class='contenedor container'>";
                    table += "<div class='ibox float-e-margins'>";
                    table += "<div class='ibox-content'>";
                    table += "<br />";
                    table += "<div class='row sombra'>";
                    table += " <div class='col-md-12'>";
                    table += "<h4>Editar Noticia <asp: Label ID='amountAPayCulqui' runat='server' ForeColor='Red' /></h4>";
                    table += "<hr> </div>";
                    table += "<div class=''>";
                    table += "<div class=''>";
                    table += "<div class='col-md 8 col-md-offset-1'>";
                    table += "<label><span>Titulo</span>";
                    table += "<textbox ID='txtTitu' runat='server' name='usuariorec'  class='input-sm form-control' Style='border: 0.5px solid #2981c5; ' size='100'>" + row[0] + "</textbox>";
                    table += "<asp:RequiredFieldValidator ID='RequiredFieldValidator1' runat='server' ErrorMessage='Campo obligatorio' ControlToValidate='txtTitu' ForeColor='Red'> </asp: RequiredFieldValidator>";
                    table += "</label></div>";
                    table += "<div class='col-md-8 col-md-offset-1'>";
                    table += "<label><span>Subtitulo</span>";
                    table += "<textbox ID='txtSub' runat='server' name='usuariorec'  class='input-sm form-control' Style='border: 0.5px solid #2981c5; ' size='100'></textbox>";
                    table += "<asp:RequiredFieldValidator ID='RequiredFieldValidator2' runat='server' ErrorMessage='Campo obligatorio' ControlToValidate='txtSub' ForeColor='Red'> </asp: RequiredFieldValidator>";
                    table += "</label></div>";
                    table += "<div class='col-md-8 col-md-offset-1'>";
                    table += "<label><span>Contenido</span>";
                    table += "<textbox ID='txtCont' runat='server' name='usuariorec' placeholder='' class='input-sm form-control' Style='border: 0.5px solid #2981c5; height: 100px ' size='100; '>" + row[2] + "</textbox>";
                    table += "<asp:RequiredFieldValidator ID='RequiredFieldValidator3' runat='server' ErrorMessage='Campo obligatorio' ControlToValidate='txtCont' ForeColor='Red'> </asp: RequiredFieldValidator>";
                    table += "</label></div> </div>";
                    table += "<div class='col-md-8 col-md-offset-1'>";
                    table += "<label><span>Imagen</span>";
                    //table += "<asp:FileUpload ID='file_upload' runat='server' ></asp: FileUpload>";
                    table += "<input type='file' ID='file_upload' name='name' />";

                    table += "</label></div>";
                    table += "<div class='col-md-8 col-md-offset-1'>";
                    table += "<label><span>Fecha</span>";
                    table += "<label ID='txtFecha' runat='server' class='input-sm form-control' Style='border: 0.5px solid #2981c5;' ></label>";
                    table += "</label></div>";
                    table += "<div class='col-md-6'><br>";
                    table += "<center><button ID='btnProcess' runat='server' CssClass='btn btn-md btn-primary recuperar ladda-button' Text='Guardar' OnClick='btnProcess_Click'  />";
                    table += " </center></div>";
                    table += "<div class='col-md-6'><br>";
                    table += "<center><button ID='btnCancelar' class='btn btn-md btn-primary recuperar ladda-button' value='Cancelar' onclick='MenuBackend.aspx' >";
                    table += "Cancelar</button></center></div>";
                    table += "<div class='col-md-12'> <center> <asp: Label ID='lblErrorSi' runat='server' ForeColor='Blue' /></center>";
                    table += "</div></div></div></div ></div > </div > </div >";
              
                document.getElementById('dataList').innerHTML = table;
            }
        }
    }
    $(function () {
        $('.img').on('click', function () {
            $('.enlargeImageModalSource').attr('src', $(this).attr('src'));
            $('#enlargeImageModal').modal('show');
        });
    });
}