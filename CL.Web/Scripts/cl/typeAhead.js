$(function () {
    //shorthand for document.ready

    var movies = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('movieName'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/movies?query=%QUERY',
            wildcard: '%QUERY'
        }
    });


    var customer = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/customers?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    var vm = {
        customerId: "",
        movieId: []
    };

    $("#rent-form #movie-typeahead").typeahead({
        minLengt: 1,
        highlight: true
    }, {
        name: 'movies',
        display: 'movieName',
        source: movies
    }).on("typeahead:select", function (e, movies) {
        console.log("View model customer: " + vm.movieId);
        $("#movies-list").append("<li class='list-group-item''>" + movies.movieName + "</li>")
        $("#rent-form #movie-typeahead").typeahead("val", "");
        vm.movieId.push(movies.id);
    });


    $("#rent-form input#customer-typeahead").typeahead({
        minLengt: 1,
        highlight: true
    }, {
        name: 'customer',
        display: 'name',
        source: customer
    }).on("typeahead:select", function (e, customer) {
        vm.customerId = customer.id;
    });

    $.validator.addMethod("validateCustomer", function () {
        return vm.customerId !== "";
    }, "Input a valid customer name");

    $.validator.addMethod("atlestOne", function () {
        return vm.movieId.length > 0;
    }, "Input atleast 1 movie")

    var validator = $("#rent-form").validate({
        ignore: ':hidden, .tt-hint',
        submitHandler: function (form, e) {

          

            $.ajax({
                url: "/api/rent",
                method: "POST",
                data: vm
            }).done(function () {
                toastr.success("Success");
                $("#rent-form #movie-typeahead").typeahead("val", "");
                $("#rent-form #customer-typeahead").typeahead("val", "");
                $("#movies-list").empty();

                vm = {
                    customerId: "",
                    movieId: []
                };
                validator.resetForm();
            }).fail(function () {
                toastr.error("Failure");
            });
        }
    });


});