$(document).ready(function () {

    const ddlCountry = $("#DdlCountry");
    const ddlState = $("#DdlState");
    const ddlCity = $("#DdlCity");

    ddlCountry.on("change", (e) => {
        ddlState.empty().append('<option selected="selected" value="">Select State</option>');
        ddlCity.empty().append('<option selected="selected" value="">Select City</option>');
        const countryId = e.target.value;
        $.ajax({
            type: "POST",
            url: "/State/GetStates/" + countryId,
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(countryId)
                console.log(response);
                $.each(response, function () {
                    ddlState.append($("<option></option>").val(this['value']).html(this['text']));
                });
            },
            failure: function (response) {
                console.log(response);
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

    ddlState.on("change", (e) => {
        ddlCity.empty().append('<option selected="selected" value="">Select City</option>');
        const stateId = e.target.value;
        $.ajax({
            type: "POST",
            url: "/City/GetCity/" + stateId,
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response);
                $.each(response, function () {
                    ddlCity.append($("<option></option>").val(this['value']).html(this['text']));
                });
            },
            failure: function (response) {
                console.log(response);
            },
            error: function (response) {
                console.log(response);
            }
        });
    });
});
