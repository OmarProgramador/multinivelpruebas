


document.addEventListener("click", e => {

    let _html = document.getElementById('Partial-VirtualOffice').innerHTML;

    if (_html.trim() === "") {
        GetDos("_VitualOffice", null, (data) => {

            document.getElementById('Partial-VirtualOffice').innerHTML = data;

            var lateral = document.getElementById('Oficce-Enlace');

            lateral.addEventListener("click", function () {
                document.getElementById('Oficce-Lateral').classList.toggle("display-none");
            });
        });
    }
});
