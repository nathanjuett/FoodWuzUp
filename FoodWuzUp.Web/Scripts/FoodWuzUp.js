
function PropertyAutocomplete(url, htmlcontrolid, htmlhiddenfieldid) {
    $("#" + htmlcontrolid).autocomplete({
        source: (url + $("#" + htmlcontrolid)[0].value),
        minLength: 1,
        select: function (event, ui) {
            $('input[name=' + htmlhiddenfieldid + ']').val(ui.item.id);
        }
    });
};
