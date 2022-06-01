var idProduc;
function BuscarProductos() {

    //Cargar todos los productos
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/BuscarProductos",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            $("#BodyTabla>tr").remove();
            var medidas = dato.BuscarProductosResult;
            for (var i = 0; i < medidas.length; i++) {
                var arr = medidas[i].split("|");
                if (arr[6] == "Activo") {
                    $("#BodyTabla").append('  <tr>  <th scope="col" class="col-md-1">' + arr[0] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[1] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[2] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[3] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[4] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[5] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[6] + '</th>'
                        + '<th scope="col" class="col-md-2">'
                        + '<button id="btnModificar" onclick="cargar_ingredi(this.name)" name="' + arr[0] + '" class="btn col-md-12 my-1">Modificar</button>'
                        + '<button id="btnDesactivar" onclick="desactivar(this.name)" name="' + arr[0] + '" class="btn col my-1">Desactivar</button>'
                        + '</th>'
                        + '</tr>');
                } else {
                    $("#BodyTabla").append('  <tr>  <th scope="col" class="col-md-1">' + arr[0] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[1] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[2] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[3] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[4] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[5] + '</th>'
                        + '<th scope="col" class="col-md-1">' + arr[6] + '</th>'
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

//Desactivar ingrediente por id
function desactivar(e) {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/DesactivarIngredientes",
        data: '{"idIng":"' + e +'"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            $("#BodyTabla>tr").remove();
            var validar = dato.DesactivarIngredientesResult;
            if (validar != 0) {
                swal("Genial!", "Se a desactivado correctamente!", "success");
                BuscarProductos();
            } else {

                swal("Upss!", "Error al desactivar!", "error");
            }
        }
    });
}

//Desactivar ingrediente por id
function cargar_ingredi(e) {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/BuscarIngrediente",
        data: '{"idIng":"' + e + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) { 
            var validar = dato.BuscarIngredienteResult;
            $("#inpCodProduct").val(validar[0]);
            $("#inpNombre").val(validar[1]);
            $("#inpCantidad").val(validar[2]);
            $("#inpCantMin").val(validar[3]);
            $("#slcUnidad").val(validar[4]); 
            $("#inpCost").val(validar[5]);
            $("#inpCodProduct").attr("disable", "true");
            $("#btnRegistrar").addClass("invisible");
            $("#btnModificarT").removeClass("invisible");
            idProduc = validar[0];
        }
    }); 
}

//Desactivar activar por id
function activar(e) {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/ActivarIngredientes",
        data: '{"idIng":"' + e + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            $("#BodyTabla>tr").remove();
            var validar = dato.ActivarIngredientesResult;
            if (validar != 0) {
                swal("Genial!", "Activado Correctamente!", "success");
                BuscarProductos();
            } else {
                swal("Upss!", "Error al activar!", "error");

            }
        }
    });
}

//Registrar ingredientes
$("#btnRegistrar").click(function () {
    if ($("#inpCodProduct").val() == "" || $("#inpNombre").val() == "" || $("#inpCantidad").val() == "" || $("#inpCantMin").val() == "" || $("#inpCost").val() == "") {
        swal("Upss!", "Todos los campos deben estar llenos!", "error");
    } else {
        var producto = $("#inpCodProduct").val() + "|" + $("#inpNombre").val() + "|" + $("#inpCantidad").val() + "|" + $("#inpCantMin").val() + "|" + $("#inpCost").val() + "|" + $("#slcUnidad").val();
        $.ajax({
            type: "POST",
            url: "Services/ServiceComandas.svc/CrearIngredientes",
            data: '{"producto":"' + producto +'"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            processdata: true,
            success: function (dato) {
                var valor = dato.CrearIngredientesResult;
                if (valor != 0) {
                    swal("Genial!", "Ingresado Correctamente!", "success");
                    $("#inpCodProduct").val("");
                    $("#inpNombre").val("");
                    $("#inpCantidad").val("");
                    $("#inpCantMin").val("");
                    $("#inpCost").val("");  
                }
                BuscarProductos();
            }
        }); 
    }
});

//Modificar ingredientes
$("#btnModificarT").click(function () {
    if ($("#inpCodProduct").val() == "" || $("#inpNombre").val() == "" || $("#inpCantidad").val() == "" || $("#inpCantMin").val() == "" || $("#inpCost").val() == "") {
        swal("Upss!", "Todos los campos deben estar llenos!", "error");
    } else {
        var producto = $("#inpCodProduct").val() + "|" + $("#inpNombre").val() + "|" + $("#inpCantidad").val() + "|" + $("#inpCantMin").val() + "|" + $("#inpCost").val() + "|" + $("#slcUnidad").val() + "|" + idProduc+" |";
        $.ajax({
            type: "POST",
            url: "Services/ServiceComandas.svc/ModificarIngredientes",
            data: '{"producto":"' + producto + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            processdata: true,
            success: function (dato) {
                var valor = dato.CrearIngredientesResult;
                if (valor != 0) {
                    swal("Genial!", "Modificado Correctamente!", "success");
                    $("#inpCodProduct").val("");
                    $("#inpNombre").val("");
                    $("#inpCantidad").val("");
                    $("#inpCantMin").val("");
                    $("#inpCost").val("");
                    $("#slcUnidad").val("1"); 
                    $("#btnRegistrar").removeClass("invisible");
                    $("#btnModificarT").addClass("invisible");
                }
                BuscarProductos();
            }
        });
    }
});


//Cargar medidas de los ingrediente 
function cargarUnidad(){
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/CargarMedidas",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            var medidas = dato.CargarMedidasResult;
            for (var i = 0; i < medidas.length; i++) {
                $("#slcUnidad").append("<option>" + medidas[i] + "</option>");
            }
            cargarPlato(0);
        }
    }); 
}



$(document).ready(function () {

    //Cerrar sesion
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
    //Validamos la sesion para saber si cuenta con acceso
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
                }else if(validar == "Administrador") {

                    cargarUnidad();
                    BuscarProductos();
                } else if (validar != "Administrador") {
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
     
});