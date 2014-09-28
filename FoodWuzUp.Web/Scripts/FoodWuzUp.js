
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
        width: 'auto',
        buttons: {
            Save: function () {
                var form;
                form = gdialog.find("form");
                form.submit();
                gdialog.dialog('close');
            },
            Cancel: function () {
                gdialog.dialog('close');
            }
        }
    });
    $('#' + CreateButton).click(function () {
        var url = $('#' + ModalDivName).data('url');
        gdialog.dialog('open').load(url);
    });
};

function CreateToolTip(ToolTipClass, ActionToCall) {
    var mouseLeaveTimer = 0;
    $('.' + ToolTipClass).tooltip({
        content: function (callback) {
            var rid = $(this).data('id');
            $.ajax({
                url: ActionToCall,
                data: { id: rid },
                success: function (data) {
                    callback(data);
                }
            });
        },
        show: null,
        position: {
            my: "right center",
            at: "left top",
        },
        open: function (ev, ui) {
            if (typeof (ev.originalEvent) === 'undefined') {
                return false;
            }
            var $id = $(ui.tooltip).attr('id');
            $('div.ui-tooltip').not('#' + $id).remove();
        },
        close: function (ev, ui) {
            ui.tooltip.hover(function () {
                $(this).stop(true).fadeTo(400, 1);
            },
            function () {
                $(this).fadeOut('400', function () {
                    $(this).remove();
                });
            });
        }
    }).on('mouseleave', function (e, ui) {
        var that = this;
        // close the tooltip later (maybe ...)
        mouseLeaveTimer = setTimeout(function () {
            $(that).tooltip('close');
        }, 100);
        //prevent tooltip widget to close the tooltip now
        e.stopImmediatePropagation();
    });
    $(document).on('mouseenter', '.ui-tooltip', function (e) {
        // cancel tooltip closing on hover
        clearTimeout(mouseLeaveTimer);
    });
    $(document).on('mouseleave', '.ui-tooltip', function () {
        // make sure tooltip is closed when the mouse is gone
        $('.' + ToolTipClass).tooltip('close');
    });
};

