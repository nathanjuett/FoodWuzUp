
function PropertyAutocomplete(url, htmlcontrolid, htmlhiddenfieldid) {
    $("#" + htmlcontrolid).autocomplete({
        source: (url + $("#" + htmlcontrolid)[0].value),
        minLength: 1,
        select: function (event, ui) {
            $('input[name=' + htmlhiddenfieldid + ']').val(ui.item.id);
        }
    });
};

function CreateModal(ModalDivName, CreateButton) {
    var gdialog = $('#' + ModalDivName).dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            Cancel: function () {
                $(this).dialog('close');
            }
        }
    });
    $('#' + CreateButton).click(function () {
        var url = $('#' + ModalDivName).data('url');
        gdialog.dialog('open').load(url);
    });
};

