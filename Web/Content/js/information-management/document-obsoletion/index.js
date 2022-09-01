var page = new Page("/InformationManagement/DocumentObsoletion");

var $selectizeDocuments = null;


$(function () {
    LoadDocuments();

    $('.fld-editor').trumbowyg({
        btns: [['viewHTML'],
        ['undo', 'redo'], // Only supported in Blink browsers
        ['strong', 'em', 'del'],
        ['superscript', 'subscript'],
        ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
        ['unorderedList', 'orderedList'],
        ['horizontalRule'],
        ['removeformat']]
    });

    $('#tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('click', '.btn-view-change-requests', function () {
        var id = $(this).data('id');
        location.href = '/InformationManagement/DocumentRequests/View/' + id
    });

    $(document).on('click', '#btn-change', function () {
        $selectizeDocuments[0].selectize.setValue('');
        $('#hdn-edit-id').val('');
        $('#fld-edit-document-name').val('');
        $('#hdn-edit-document-name').val('');
        $('#hdn-edit-document-id').val('');
        $('#hdn-edit-employee-name').val('');
        $('#fld-edit-employee-name').val('');
        $('#hdn-edit-employee-id').val('');
        $('.fld-editor').trumbowyg('html', '');
        $('#fld-edit-date').val('');
        $('#mdl-edit').modal('show');
    });
    $(document).on('click', '#btn-edit-next', function () {

        $('#mdl-edit').modal('hide');
        $('#mdl-edit-pdf').modal('show');
    });

    $(document).on('click', '#btn-edit-submit', function () {
        var id = $('#hdn-edit-id').val();
        page.get('/RequestForObsoletion?id=' + id).then(function (data) {
            notify('Document Obsoletion Request Submitted', 'success');
            done();
        });
    });

});

var LoadDocuments = function () {
    if ($selectizeDocuments != null) {
        return;
    }

    $selectizeDocuments = $('.fld-edit-document').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/InformationManagement/ChangeRequests/GetAll',
                type: 'GET',
                error: function () {
                    callback();
                },
                success: function (data) {
                    callback(data);
                }
            });
        },
        onChange: function (value) {
            var item = $(this)[0].options[value];
            if (item) {
                $('#hdn-edit-id').val(item.Id);
                $('#fld-edit-document-name').val(item.Name);
                $('#hdn-edit-document-name').val(item.Name);
                $('#hdn-edit-document-id').val(item.Id);
                $('#hdn-edit-employee-name').val(item.EmployeeName);
                $('#fld-edit-employee-name').val(item.EmployeeName);
                $('#hdn-edit-employee-id').val(item.EmployeeId);
                $('.fld-editor').trumbowyg('html', item.Content);
                $('#fld-edit-date').val(moment(item.UpdatedAt).format('MM/DD/YYYY hh:mm A'));

                displayPDF();
            } else {
            }
        }
    });
}

var displayPDF = function () {
    var id = $('#hdn-edit-document-id').val().substring(0, 5);
    var name = $('#fld-edit-document-name').val();
    PDFObject.embed("../../../content/files/" + name + "-" + id + ".pdf", "#dv-pdf-viewer");
}
var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}