$(document).ready(() => {

    getPrice();

    var priceDisco = 0.0;

    $("#DiscoID").on("change", function() {
        getPrice();
    });

    $("#Cantidad").on("change",
        function () {
            $("#PrecioVenta").val(($("#Cantidad").val() * priceDisco).toFixed(2));
        });

    function getPrice() {
        $.ajax({
            url: `/discoes/getprice?idDisco=${$("#DiscoID").val()}`,
            success: function(response) {
                priceDisco = response;
                $("#ShowPrice").html("$"+parseFloat(response).toFixed(2));
                $("#PrecioVenta").val(($("#Cantidad").val() * response).toFixed(2));
            }

        });
    }

});