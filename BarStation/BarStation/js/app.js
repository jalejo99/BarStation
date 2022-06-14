//Mesa 1 --------------------------------------------------------------




var contPlatos = 0;
var arrayPlatos = new Array();
var arrycantPlatos = new Array(); 
var Mesa;

function eliminarPlato(e) {  
    arrycantPlatos[e,1] = 0; 
    $("#divPlato" + e).remove();  
}

function platosModal(name) { 
    $("#btn-enviar-modal").attr("name", name);
    modal.showModal(); 
    $("#h3TituloCm").text("Mesa " + name);
}

function cargarPlato(id) {
    arrycantPlatos[id] = new Array();
    arrycantPlatos[id][0] = id;
    arrycantPlatos[id][1] = 1;
    id = "slcPlato" + id;
    $("#" + id+">   option").remove();
    $("#" + id).append("<option name='12255522' selected disabled>Seleccione plato</option>"    );
    for (var i = 0; i < arrayPlatos.length; i++) {
        $("#" + id).append("<option name='" + arrayPlatos[i][0]+"'>"+
            arrayPlatos[i][1]+"</option>"
        );
    } 
}

function cargarMesas() {


    $(document).ready(function () {
        $.ajax({
            type: "POST",
            url: "Services/ServiceComandas.svc/NumeroMesas",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            processdata: true,
            success: function (Fotos) {
                var num = Fotos.NumeroMesasResult; 
                for (var i = 1; i <= num;i++) {
                    $("#contMesas").append('<div class="mesa" id="dvMesa' + i+'">' +
                        '<p class="mesa__nombre">Mesa ' + i+'</p>'+
                        '<button id="btn-abrir-modal" onclick="platosModal(this.name)" class="btnMesa" name="' + i+'"><img src="../img/mesa.jpg" alt=""></button>'+
            '</div>');
                }

            }
        });
    }) 
}

function cargarPlatos() {
    $(document).ready(function () {
        $.ajax({
            type: "POST",
            url: "Services/ServiceComandas.svc/CargarPlatos",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            processdata: true,
            success: function (platos) { 
                var platosarr = platos.CargarPlatosResult;  
                for (var i = 0; i < platosarr.length; i++) {
                    var arr = platosarr[i].split("|");
                    arrayPlatos.push(arr);
                }
                cargarPlato(0);
            }
        });
    })
}

$(document).ready(function () {

    $("#btn-enviar-modal").click(function () {
        var Platos = ""; 
        for (var i = 0; i < arrycantPlatos.length; i++) {
            var arr = arrycantPlatos[i]; 
            if (arr[1] == 1) {
                Platos += $("#slcPlato" + i).val() + "|" + $("#cantPlato" + i).val()+"*";
            }          
          
        }
        Mesa = $(this).attr("name");
        var comentario = $("#txtComentario").val(); 
        $.ajax({
            type: "POST",
            url: "Services/ServiceComandas.svc/crearComandas",
            data: '{"Platos": "' + Platos + '", "idMesa": "' + Mesa + '","Comentario":"' + comentario+'"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            processdata: true,
            success: function (Fotos) {
                var num = Fotos.CrearComandasResult;  
                swal(num[2], num[1], num[0]);
                    cargarPlato(0); 
            }
        });
        modal.close();
        $("#txtComentario").val(""); 
            $("#MorePlatos").remove();
            $("#cantPlato0").val("0");
    });
    cargarMesas(); 
    cargarPlatos();
    $('.js-example-basic-single').select2({
        dropdownParent: $('#modal')
    });

    $("#btnAddPlato").click(function () {
        contPlatos = contPlatos + 1;
        $("#MorePlatos").append('    <div id="divPlato' + contPlatos+'" style = "margin-top:15px; display: inline-flex;" > <div>' +
            '  <select id="slcPlato' + contPlatos + '" class="js-example-basic-single" name="state">' +
            '</select> ' +
            '   </div> ' +
            '  <div> ' +
            '<input type = "number" min="1" class="inpCantPlato" values="1" id="cantPlato' + contPlatos + '" /> ' +
            '</div> ' +
            ' <div> ' +
            '<button id = "btnEliminarPLato" onclick="eliminarPlato(this.name)" name="' + contPlatos + ' "class="botoncierre" style ="margin-top: -2px;"> -</button> ' +
            '</div> </div>');
        cargarPlato(contPlatos);
        $('#slcPlato' + contPlatos).select2({
            dropdownParent: $('#modal')
        });
        arrycantPlatos[contPlatos][0] = contPlatos;
        arrycantPlatos[contPlatos][1] = 1;

    });
     
    $(".btnMesa").click(function () { 
        Mesa = $(this).attr("name");
        $("#btn-enviar-modal").attr("name", name);
        modal.showModal();
        contPlatos = 1;
        $("#h3TituloCm").text("Mesa " + name);
    });

    $(".boton-orden").click(function () {
        var name = $(this).attr("name");
    }); 

    $("#btn-cerrar-modal").click(function () {
        modal.close();
        $("#MorePlatos").remove();
        $("#cantPlato1").val("0");
    });

    $(".btnMesa").hover(function () {
        var name = $(this).attr("name");
        $("#dvMesa" + name).removeClass("mesa");
        $("#dvMesa" + name).addClass("mesa_ov");
    }, function () {
        var name = $(this).attr("name");
        $("#dvMesa" + name).removeClass("mesa_ov");
        $("#dvMesa" + name).addClass("mesa");
    });

});

 