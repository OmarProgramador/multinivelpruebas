
function readFile(input) {

    if (input.files && input.files[0]) {

        var reader = new FileReader();
        reader.onload = function (e) {

            /*borramos el contenido html del contenedor*/
            document.getElementById('file-preview-zone').innerHTML = "";
            var filePreview = document.createElement('img');
            //var filePreview = document.getElementById('file_preview');

            filePreview.id = 'file-preview';
            filePreview.width = 200;
            filePreview.height = 200;

            //e.target.result contents the base64 data from the image uploaded

            filePreview.src = e.target.result;
            var previewZone = document.getElementById('file-preview-zone');
            previewZone.appendChild(filePreview);
        }
        reader.readAsDataURL(input.files[0]);
    }

}

var fileUpload = document.getElementById('file_upload');

fileUpload.click = function (e) {

    readFile(e.srcElement);

};

function showimagepreview(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            document.getElementById('idpreview')[0].setAttribute("src", e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

window.onload = function () {
    let _document = getParameterByName("usuario");
    let _fullName = getParameterByName("fullname");
    let _desc = getParameterByName("description");
    let _id = getParameterByName("cod");

    if (_document !== "") {
        document.getElementById("txtNumeroDoc").value = _document;
        document.getElementById("txtFName").innerHTML = _fullName;
        if (_id !== "") {
            document.getElementById('DescriptionQuote').innerHTML = _desc;
            document.getElementById('DescriptionQuote').classList.toggle("border-primary");
            document.getElementById('LblIdMembership').value = _id;
        }
        $("#mdlSubirRecibo").modal("show");
    }
};



