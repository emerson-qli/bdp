var page = new Page("/Setting/DocumentClassification");

$(function () {
    $('#tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('click', '#btn-add', function () {
        $('#mdl-new').modal('show');
    });
    $(document).on('click', '.btn-edit', function () {
        var id = $(this).data('id');
        page.get('/Get?id=' + id).then(function (data) {
            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-description').val(data.Description);
            $('#mdl-edit').modal('show');
        });

    });


    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'DocumentClassification');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Document Classification Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'DocumentClassification');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Document Classification Updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this issue category? ', deleteDocumentClassification, id);

    });


});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteDocumentClassification = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Document Classification deleted', 'success');
        done();
    });

}

