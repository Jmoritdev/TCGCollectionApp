function GetCardsBySet(code, lang) {
    $.ajax({
        url: "/?handler=CardsFromSet",
        data: {
            "code": code,
            "lang": lang
        },
        success: function (result) {
            Console.log(result);
        }
    })
}

$('#SetSelector').on('change', function () {
    Console.log(this.value);
});