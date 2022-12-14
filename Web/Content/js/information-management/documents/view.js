
var page = new Page("/InformationManagement/Documents");

$(function () {

    $('.fld-editor').trumbowyg({
        btns: [['viewHTML'],
        ['undo', 'redo'], // Only supported in Blink browsers
        ['strong', 'em', 'del'],
        ['superscript', 'subscript'],
        ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
        ['unorderedList', 'orderedList'],
        ['horizontalRule'],
        ['removeformat'],
        ['fullscreen']]
    });

    $(document).on('click', '#btn-back', function () {
        location.href = "/InformationManagement/Documents";
    });

    

    

});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

