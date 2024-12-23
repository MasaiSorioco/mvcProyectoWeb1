var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblProductos").DataTable({
        "ajax": {
            "url": "/Admin/Producto/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
                { "data": "id", "width": "5%" },
                { "data": "nombre", "width": "15%" },
                { "data": "descripcion", "width": "30%" },
                { "data": "precio", "width": "10%" },
                { "data": "stock", "width": "10%" },
                {
                "data": "urlImagen",
                "render": function (imagen) {
                    return `<img src="../${imagen}" width="120">`
                    }
                },   
                {
                    "data": "id",
                    "render": function (data) {
                        return `<div class="text-center">
                            <a href="/Admin/Producto/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                            <i class="far fa-edit"></i> Editar
                            </a>
                            &nbsp;
                            <a onclick=Delete("/Admin/Producto/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:140px;">
                            <i class="far fa-trash-alt"></i> Borrar
                            </a>
                        </div>
                        `;
                    }, "width": "20%"
                }
            ],
            "language": {
                "decimal": "",
                "emptyTable": "No hay registros",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 a 0 de 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "No se encontraron registros",
                "paginate": {
                    "first": "Primero",
                    "last": "Último",
                    "next": "Siguiente",
                    "previous": "Anterior"
            }
        }
    });
