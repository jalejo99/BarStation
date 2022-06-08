
function TraerRoles() {
    $.ajax({
        type: "POST",
        url: "Services/ServiceComandas.svc/TraerRoles",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (dato) {
            var valor = dato.TraerRolesResult;
            $("#slcRol>option").remove();
            $("#slcRol").append("<option disabled selected name='0'> Rol </option>");
            for (var i = 0; i < valor.length; i++) { 
                var arr = valor[i].split("|"); 
                $("#slcRol").append("<option name='" + arr[0] + "'>" + arr[1] + "</option>");
            }

        }
    }); 
}

$(document).ready(function () {

    TraerRoles();
    $("#btnLogin").click(function () {
        if ($("#inpCorreo").val() == "" || $("#inpContras").val() == "") {
            swal("Upps!", "Todos los campos deben estar llenos!", "error");
        } else {
            var datos = $("#inpCorreo").val() + "|" + $("#inpContras").val();
            $.ajax({
                type: "POST",
                url: "Services/ServiceComandas.svc/Login",
                data: '{"datos":"' + datos + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                processdata: true,
                success: function (dato) {
                    var valor = dato.LoginResult;
                    if (valor == "Mesero") {
                        location.href = "Comandas.html"
                    } else if (valor == "Administrador") {
                        location.href = "Registro_inventario.html"
                    } else if (valor == "Cocinero") {
                        location.href = "Cocinero.html"
                    } else if (valor == "No existe") {

                        swal("Upps!", "Usuario o contraseña incorrecta!", "error");
                    } 
                    
                }
            }); 
            
            }
    });

    $("#btnRegistrar").click(function () {
        if ($("#slcRol option:selected").attr("name") == 0 || $("#inpCedula").val() == "" || $("#inpNombre").val() == "" || $("#inpApellido").val() == "" || $("#inpCorreoElect").val() == "" || $("#inpCelular").val() == "" || $("#inpContraseña").val() == "") {
            swal("Upps!", "Todos los campos deben estar llenos!", "error");
        } else {
            var datos = $("#inpCedula").val() + "|" + $("#inpNombre").val() + "|" + $("#inpApellido").val() + "|" + $("#inpCorreoElect").val() + "|" + $("#inpCelular").val() + "|" + $("#inpContraseña").val() + "|" +$("#slcRol option:selected").attr("name");
            $.ajax({
                type: "POST",
                url: "Services/ServiceComandas.svc/ValidarUsuarioCreado",
                data: '{"cedula":"' + $("#inpCedula").val() + '","correos":"' + $("#inpCorreoElect").val() + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                processdata: true,
                success: function (dato) {
                    var valor2 = dato.ValidarUsuarioCreadoResult;
                    if (valor2 != 0) {
                        swal("Upps!", "Usuario ya registrado!", "error");
                    } else {
                        $.ajax({
                            type: "POST",
                            url: "Services/ServiceComandas.svc/Insertar_Usuario",
                            data: '{"datos":"' + datos + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            processdata: true,
                            success: function (dato) {
                                var valor = dato.Insertar_UsuarioResult;
                                if (valor == "0") {
                                    swal("Upps!", "Usuario no registrado!", "error");
                                } else if (valor == "1") {
                                    swal("Buen trabajo!", "Usuario registrado correctamente!", "success");
                                    $("#inpCedula").val("");
                                    $("#inpNombre").val("");
                                    $("#inpApellido").val("");
                                    $("#inpCorreoElect").val("");
                                    $("#inpCelular").val("");
                                    $("#inpContraseña").val("");
                                    TraerRoles();
                                }

                            }
                        });
                    }
                }
            });

        
        }
    });

});