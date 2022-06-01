 
var bandera = 0;
var textcom = "";
var nameant = "";
function a(name) {  
    if (bandera == 0) {
        bandera = 1; 
        textcom = $("#liCm" + name).html();
        nameant = name;
    } else {
        bandera = 0;
        var aux = $("#liCm" + name).html();
        $("#liCm" + name + ">div").remove();
        $("#liCm" + name).html(textcom);
        $("#liCm" + nameant).html(aux);
        textcom = "";
        nameant = "";  
    }
}
function cargar() {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/CargarComandas",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            $("#draggable-list>li").remove();
            var validar = dato.CargarComandasResult;
            for (var i = 0; i < validar.length; i++) {
                var asd = validar[i].split("|")
                $("#draggable-list").append('<li  data-index="' + i + '"   name="fasdfa" id="liCm' + i + '" class="col-md-6">' +
                    '<div class="draggable" draggable="true">' +
                    '<p class="tables col-md-2">Mesa ' + asd[3] + '</p>' +
                    '<button class="number col-md-3" style="border:none"  onclick="Consultar(this.id)" id="' + asd[0] + '" name="' + i + '"> Mostrar Comanda </button>' +
                                        '<button class="number col-md-3" style="border:none"  onclick="a(this.name)" id="divCm' + i + '" name="' + i + '">  Orden ' + i + ' </button>' +
                    '<div class="listButtons row col-md-4">' +
                    '<button name="' + asd[0] + '" id="2" onclick="Cumplir(this.name,this.id)" class="btn col-12">Cumplida</button>' +
                    ' <button name="' + asd[0] + '" id="3" onclick="Cumplir(this.name,this.id)" class="btn col-12">Cancelar</button>' +
                    '</div>' +
                    '<dialog id="modal" class="modalestilo">' +
                    ' <h3>Mesa undefined</h3>' +
                    '< p class= "listaOrden" > undefined</p > ' +
                    ' < button id = "btn-cerrar-modal" class= "botoncierre" > cerrar</button > ' +
                    '  </dialog > ' +
                    ' </div > ' +
                    '</li>');

            }
        }
    });
}
$("#aCerrarSesion").click(function () {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/CerrarSesion",
        data: '{ }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            location.href = 'Login.html';

        }
    });
});
$(document).ready(function () {
   
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/ValidarSesion",
        data: '{ }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            var validar = dato.ValidarSesionResult;
            if (validar == "No") {
                swal({
                    title: "Alerta",
                    text: "Inicia seccion para poder acceder",
                    icon: "warning",
                    dangerMode: true,
                })
                    .then((willDelete) => {
                        location.href = 'Login.html';
                    });
            } else if (validar != "Cocinero") {
                swal({
                    title: "Alerta",
                    text: "No tienes acceso",
                    icon: "warning",
                    dangerMode: true,
                })
                    .then((willDelete) => {
                        $("body").remove();
                    });
            }
        }
    });

    cargar(); 
}); 

function Consultar(name) {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/BuscarPlatosComanda",
        data: '{"idComanda":"'+name+'"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) { 
            var validar = dato.BuscarPlatosComandaResult;
            $("#BodyTabla2>tr").remove();
            for (var i = 0; i < validar.length; i++) {
                var arr = validar[i].split("|");
                $("#BodyTabla2").append('  <tr>  '+
                    '<th scope="col" class="col-md-1">' + arr[0] + '</th>'
                    + '<th scope="col" class="col-md-1">' + arr[1] + '</th>' 

                    + '</tr>');

            }
            popapp.showModal();
        }
    });
}
$("#btn-cerrar-modal").click(function () {
    $("#BodyTabla2>tr").remove();
    popapp.close();
});
function Cumplir(id,estad) {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/ModificarEstdoComanda",
        data: '{"idComanda":"' + id + '","estado":"' + estad+'"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            var validar = dato.ModificarEstdoComandaResult;
            if (validar != 0) {
                swal("Genial!", "Modificado Correctamente!", "success");
                cargar();
            } else {
                swal("Upps!", "Error al Modificado!", "error");
            }
             
        }
    });
}
