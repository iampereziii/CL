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
                    return "<a class='btn btn-link' href='/Movies/Details/" + data + "'>View</a> ";
                }
            }
        ]
    });

});
