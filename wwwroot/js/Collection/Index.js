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
    var timestamp;
    var interval = 300;
    $("#inputName").on("input", function () {
        var q = $("#inputName").val();
        if (q.length >= 2) {

            timestamp = Date.now();

            setTimeout(function () {
                //check if the user hasn't triggered the event for atleast the amount of milliseconds equal to interval
                if (Date.now() >= timestamp + interval) {
                    getAutocomplete(q);
                }
            }, interval);

        }
    });

    function getAutocomplete(query) {
        $.ajax({
            url: "https://api.scryfall.com/cards/autocomplete?q=" + query,
            success: function (result) {
                $("#nameOptionList option").each(function () { $(this).remove(); })

                let options = result['data'];
                if (options.length == 1 || options.includes(query)) {
                    //fill list with options
                    $("#inputName").val(options[0]);
                    getSetsForCard(options[0]);
                } else if (options.length > 1) {
                    options.forEach(i => $("#nameOptionList").append("<option value=\"" + i + "\">"));
                }
            }
        });
    }

    function getSetsForCard(cardName) {
        $.ajax({
            url: "/Collection?handler=SetsForCard",
            data: {
                cardName: cardName
            },
            success: function(result) {
                $("#selectSet").children().remove();

                currentSets = result;

                result.forEach(function (item, index) {
                    $("#selectSet").append("<option data-content=\""+item.name+"\"></option>");
                });

                $("#selectSet").selectpicker("refresh");

                //prepend images
                var elements = $(".dropdown-item").toArray();
                elements.forEach(function (item, index) {
                    var image = new Image(25, 25);
                    image.src = 'data:image/svg+xml;base64,' + result[index].iconSvgBase64;

                    item.prepend("    ");
                    item.prepend(image);
                });

                $(".filter-option-inner-inner").first().html("<img height='25' width='25' src='" + 'data:image/svg+xml;base64,' + result[0].iconSvgBase64 + "'>"+ result[0].name);

            }
        });
    }

    //triggers when set is selected
    $("body").on("DOMSubtreeModified", '.filter-option-inner-inner', function () {
        let selectedSet = $(".filter-option-inner-inner").first().html();
        let cardName = $("#inputName").val();

        if (selectedSet && cardName) {
            //strip tags from set, there might be an image in there
            getLanguagesForCardInSet(cardName, selectedSet.stripTags());
        }
    });

    function getLanguagesForCardInSet(cardName, setName) {
        $.ajax({
            url: "/Collection?handler=LanguagesForCardInSet",
            data: {
                cardName: cardName,
                setName: setName
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

        //data['x'] is 'on' or does not exist, here we convert that into true/false
        data['isFoil'] = (data['isFoil'] ? true : false);
        data['isSigned'] = (data['isSigned'] ? true : false);

        data['setName'] = $(".filter-option-inner-inner").first().html().stripTags();

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
        $("#selectSet").selectpicker("refresh");
    }

    function showAlert(alert, message) {
        $(alert).html(message);

        $(alert).show();

        setTimeout(function () {
            $(alert).hide();
        }, 3000)
    }

    String.prototype.stripTags = function stripTags() {
        return this.replace(/<\/?[^>]+(>|$)/g, "");
    }
});