var contIngre = 0;
var arrIngre = new Array();

function BuscarPlatos() {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/BuscarPlatos",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            $("#BodyTabla>tr").remove();
            var medidas = dato.BuscarPlatosResult;
            for (var i = 0; i < medidas.length; i++) {
                var arr = medidas[i].split("|");
                if (arr[3] == "Activo") {
                    $("#BodyTabla").append('  <tr>  <th scope="col" class="col-md-1">' + arr[0] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[1] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[2] + '</th>'
                        + '<th scope="col" class="col-md-1"><button onclick="Ingredientes(this.name)" class="btn" name="'+arr[0]+'">Ver ingredientes</button></th>'
                        + '<th scope="col" class="col-md-1">' + arr[3] + '</th>'
                        + '<th scope="col" class="col-md-2">'
                        + '<button id="btnModificar" onclick="cargar_ingredi(this.name)" name="' + arr[0] + '" class="btn col-md-12 my-1">Modificar</button>'
                        + '<button id="btnDesactivar" onclick="desactivar(this.name)" name="' + arr[0] + '" class="btn col my-1">Desactivar</button>'
                        + '</th>'
                        + '</tr>');
                } else {
                    $("#BodyTabla").append('  <tr>  <th scope="col" class="col-md-1">' + arr[0] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[1] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[2] + '</th>'
                        + '<th scope="col" class="col-md-1"><button onclick="Ingredientes(this.name)" class="btn" name="' + arr[0] + '">Ver ingredientes</button></th>'
                        + '<th scope="col" class="col-md-1">' + arr[3] + '</th>'
                        + '<th scope="col" class="col-md-2">'
                        + '<button id="btnModificar" onclick="cargar_ingredi(this.name)" name="' + arr[0] + '" class="btn col-md-12 my-1">Modificar</button>'
                        + '<button id="btnDesactivar" onclick="activar(this.name)" name="' + arr[0] + '" class="btn col my-1">Activar</button>'
                        + '</th>'
                        + '</tr>');
                }

            }
        }
    });
}

function Ingredientes(e) {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/BuscarIgrexPLato",
        data: '{"idPlato":"' + e + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            var validar = dato.BuscarIgrexPLatoResult;
            $("#BodyTabla2>tr").remove();
            for (var i = 0; i < validar.length; i++) {
                var arr = validar[i].split("|");
                $("#BodyTabla2").append('  <tr>  <th scope="col" class="col-md-1">' + arr[0] + '</th>'
                    + '<th scope="col" class="col-md-1">' + arr[1] + '</th>'
                    + '<th scope="col" class="col-md-1">' + arr[2] + '</th>'
                     
                    + '</tr>');

            }
            modal.showModal();
        }
    });
}


function activar(e) {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/ActivarPlatos",
        data: '{"idPlato":"' + e + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            var validar = dato.ActivarPlatosResult;
            if (validar != 0) {
                $("#BodyTabla>tr").remove();
                swal("Genial!", "Activado Correctamente!", "success");
                BuscarPlatos();
            } else {
                swal("Upps!", "A ocurrido un error!", "error");
            }
        }
    });
}
function desactivar(e) {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/DesactivarPlatos",
        data: '{"idPlato":"' + e + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            var validar = dato.DesactivarPlatosResult;
            if (validar != 0) {
                $("#BodyTabla>tr").remove();
                swal("Genial!", "Desactivado Correctamente!", "success");
                BuscarPlatos();
            } else {
                swal("Upps!", "A ocurrido un error!", "error");
            }
        }
    });
}
var arrycantingre = new Array(); 
function cargaringre(id) {
    arrycantingre[id] = new Array();
    arrycantingre[id] = id; 
    id = "slcIngre" + id;
    for (var i = 0; i < arrIngre.length; i++) {
        $("#" + id).append("<option name='" + arrIngre[i][2] + "'>" +
            arrIngre[i][0] + "</option>"
        );
    }
}
$(document).ready(function () {
    BuscarPlatos();

    $(".botoncierre").click(function () {
        modal.close();
        $("#BodyTabla2>tr").remove();
    });

    $("#btnAgregar").click(function () {
        modal2.showModal();

        $('#slcIngre' + contIngre).select2({
            dropdownParent: $('#modal2')
        });
        $.ajax({
            type: "POST",
            url: "Services/ServiceComandas.svc/BuscarIgres",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            processdata: true,
            success: function (dato) {
                var validar = dato.BuscarIgresResult;
                $("#BodyTabla2>tr").remove();
                for (var i = 0; i < validar.length; i++) {
                    arrIngre[i] = validar[i].split("|"); 
                }
                cargaringre(contIngre);
            }
        });
    });
    $("#btnAddPlato").click(function () {
        contIngre = contIngre + 1;
        $("#MorePlatos").append('    <div id="divIngre' + contIngre + '" style = "margin-top:15px; display: inline-flex;" > <div>' +
            '  <select id="slcIngre' + contIngre + '"  onchange="a(this.value,this.id)" class="js-example-basic-single" style="width:110px" name="state"><option selected disabled>Ingrediente </option>' +
            '</select> ' +
            '   </div> ' +
            '  <div> ' +
            '<input type = "number" min="1" class="inpCantPlato" values="1" id="cantIngre' + contIngre + '" /> ' +
            '</div> ' +
           ' <div>' + 
            '    <input type="text" disabled class="inpCantPlato" values="1" id="AslcIngre' + contIngre+'" />' +
           ' </div>' +
            ' <div> ' +
            '<button id = "btnEliminarPLato" onclick="eliminarPlato(this.name)" name="' + contIngre + '"class="botoncierre" style ="margin-top: -2px;"> -</button> ' +
            '</div> </div>'); 
        $('#slcIngre' + contIngre).select2({
            dropdownParent: $('#modal2')
        });
        arrycantingre[contIngre]= contIngre;
        cargaringre(contIngre);

    });

    $("#btnEnviarIngre").click(function () {
        modal2.close();
    });
    $("#btnCerrarModal2").click(function () {
        modal2.close();
    });

    $("#btnRegistrar").click(function () {
        if ($("#inpCodProduct").val() == "" || $("#inpNombre").val() == "" || $("#inpPrecio").val() == "" || $("#cantIngre0").val() == "") { 
            swal("Upps!", "Todos los campos deben estar llenos!", "error");
        } else {
            var datos = $("#inpCodProduct").val() + "|" + $("#inpNombre").val() + "|" + $("#inpPrecio").val() + "|";
            $.ajax({
                type: "POST",
                url: "Services/ServiceComandas.svc/IngresarPlato",
                data: '{"datos":"' + datos+'"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                processdata: true,
                success: function (dato) {
                    var validar = dato.IngresarPlatoResult; 
                    var datos2="";
                    if (validar != 0) {
                        for (var i = 0; i < arrycantingre.length; i++) {
                            if (arrycantingre[i] != -1) {
                                var val = $("#slcIngre" + i).val();
                                for (var j = 0; j < arrIngre.length; j++) {
                                    if (arrIngre[j][0] == val) {
                                        datos2 += arrIngre[j][3] + "|" + $("#cantIngre" + i).val()+"*";
                                    }
                                } 
                            }
                        }
                        $.ajax({
                            type: "POST",
                            url: "Services/ServiceComandas.svc/IngresarPlato_Ingredi",
                            data: '{"datos":"' + datos2 + '","idPlato":"' + $("#inpCodProduct").val()+'"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            processdata: true,
                            success: function (dato) {
                                var validar2 = dato.IngresarPlato_IngrediResult;
                                if (validar2 != 0) {
                                    swal("Genial!", "Insertado correctamente!", "success");
                                    $("#inpCodProduct").val("");
                                    $("#inpNombre").val("");
                                    $("#inpPrecio").val("");
                                    $("#MorePlatos>div").remove();
                                    $("#slcIngre0").val(0); 
                                    cargaringre(0);
                                    $("#AslcIngre0").val("");
                                    BuscarPlatos();
                                } else {
                                    swal("Upps!", "Error al ingresar!", "error");
                                }
                            }
                        });
                    } else {
                        swal("Upps!", "Error al ingresar!", "error");
                    } 
                }
            });
        }
    });
});

function a(e, id) {
    for (var i = 0; i < arrIngre.length; i++) {
        if (arrIngre[i][0] == e) { 
            id = "A" + id; 
            $("#"+id).val(arrIngre[i][2]);
        }
    }
}

function eliminarPlato(e) {
    arrycantingre[e] = -1;
    $("#divIngre" + e).remove();
}