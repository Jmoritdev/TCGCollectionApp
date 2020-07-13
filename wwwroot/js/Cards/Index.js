$(document).ready(function () {
    function GetCardsBySet(code, lang) {
        $.ajax({
            url: "/Cards?handler=CardsFromSet",
            data: {
                "code": code,
                "lang": lang
            },
            success: function (result) {
                $("tbody").children().remove();

                var array = JSON.parse(result);
                console.log(array);

                $.each(array, function (i, item) {
                    console.log(array[i]);
                    $('<tr>')
                        .html("<td>" + array[i].Name + "</td></tr>")
                        .appendTo('tbody')
                        .tooltip({ title: "<img src='" + array[i].ImageUris.Normal + "' />", animation: true, trigger: "hover", html: true });
                });
            }
        })
    }

    $('select').on('change', function () {
        GetCardsBySet(this.value, "en");
    });
});

