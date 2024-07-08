$(document).ready(function () {

   var table = $("#movies").DataTable({
        ajax: {
            url: "/api/movies",
            dataSrc: "",
        },
        columns: [
            { data: "id" },
            { data: "movieName" },
            { data: "genre.name" },
            {
                data: "id",
                render: function (data, type, movieRow) {
                    return "<a class='btn btn-link' href='/Movies/EditMovie/" + data + "'>Edit</a> | <button class='btn btn-link' id='js-btn-delete' data-to-delete='" + data + "'>Delete</a>";
                }
            }
        ]
    });


    $("#movies").on("click", "#js-btn-delete", function () {
        const obj = $(this);
        bootbox.confirm("Are you sure youw want to delete? ", function (result) {

            if (result) {
                $.ajax({
                    url: "/api/movies/"+obj.attr("data-to-delete"),
                    method: "DELETE",
                    success: function () {
                        table.row(obj.parents("tr")).remove().draw();
                    }
                });

            }
        });

    });
});
