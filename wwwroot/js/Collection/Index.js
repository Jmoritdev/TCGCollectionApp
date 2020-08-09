$(document).ready(function () {
    GetUserCards();
    function GetUserCards() {
        $.ajax({
            url: "/Collection?handler=UserCards",
            success: function (result) {
                $("tbody").children().remove();

                var array = JSON.parse(result);
                $.each(array, function (i, item) {
                    $('<tr>')
                        .html("<th scope='row'>" + array[i].Card.Name + "</th><td>" + array[i].Card.SetName + "</td><td>" + array[i].Amount + "</td></tr>")
                        .appendTo('tbody')
                        .tooltip({ title: "<img src='" + array[i].Card.ImageUris.Normal + "' />", animation: true, trigger: "hover", html: true });
                });
            }
        })
    }

    //takes care of autocompleting card names
    var ts;
    var interval = 300;
    $("#inputName").on("input", function () {
        var q = $("#inputName").val();
        if (q.length >= 2) {

            ts = Date.now();

            setTimeout(function () {

                //check if the user hasn't triggered the event for atleast the amount of milliseconds equal to interval
                if (Date.now() >= ts + interval) {

                    //send request
                    $.ajax({
                        url: "https://api.scryfall.com/cards/autocomplete?q=" + q,
                        success: function (result) {
                            $("#nameOptionList option").each(function () { $(this).remove(); })

                            let options = result['data'];
                            if (options.length == 1 || options.includes(q)){
                                //fill list with options
                                $("#inputName").val(options[0]);
                                getSetsForCard(options[0]);
                            } else if (options.length > 1) {
                                options.forEach(i => $("#nameOptionList").append("<option value=\"" + i + "\">"));
                            }
                        }
                    });

                }
            }, interval);

        }
    });

    function getSetsForCard(cardName) {
        $.ajax({
            url: "/Collection?handler=SetsForCard",
            data: {
                cardName: cardName
            },
            success: function(result) {
                $("#selectSet").children().remove();

                result.forEach(i => $("#selectSet").append("<option value=\"" + i.code + "\">" + i.name + "</option>"));

                $("#selectSet").trigger("change");
            }
        });
    }

    $("#selectSet").change(function () {
        let selectedSet = $("#selectSet").val();
        let cardName = $("#inputName").val();

        getLanguagesForCardInSet(cardName, selectedSet);
    });

    function getLanguagesForCardInSet(cardName, setCode) {
        $.ajax({
            url: "/Collection?handler=LanguagesForCardInSet",
            data: {
                cardName: cardName,
                setCode: setCode
            },
            success: function (result) {
                $("#selectLang").children().remove();

                result.forEach(i => $("#selectLang").append("<option value='" + i + "'>"+ i +"</option>"));
            }
        })
    }

    $("#addCardForm").submit(function (event) {
        event.preventDefault();

        var data = {};
        
        $.map($("#addCardForm").serializeArray(), function (n, i) {
            data[n['name']] = n['value'];
        });

        if (data['isFoil'] == 'on') {
            data['isFoil'] = true;
        }

        if (data['isSigned'] == 'on') {
            data['isSigned'] = true;
        }

        addToCollection(data);
    });

    function addToCollection(data) {
        $.ajax({
            url: "/Collection?handler=AddToCollection",
            method: "POST",
            data: data,
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            success: function (result) {
                showAlert(".alert-success", result);

                resetForm();
                GetUserCards();
            },
            error: function (result) {
                showAlert(".alert-danger", result);
            }

        });
    }

    function resetForm() {
        $("#inputName").val("");
        $("#selectSet").children().remove();
        $("#selectLang").children().remove();
        $("#inputAmount").val("1");
        $("#inputSigned").prop("checked", false);
        $("#inputFoil").prop("checked", false);
        $("#inputName").focus();
    }

    function showAlert(alert, message) {
        $(alert).html(message);

        $(alert).show();

        setTimeout(function () {
            $(alert).hide();
        }, 3000)
    }
});