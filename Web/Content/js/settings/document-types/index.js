var page = new Page("/Setting/DocumentTypes");

var $selectizeDocumentCategories     = null;
var $selectizeEditDocumentCategories = null;

$(function () {

    loadDocumentCategories();
    loadEditDocumentCategories();

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

            if ($selectizeEditDocumentCategories != null) {
                $selectizeEditDocumentCategories[0].selectize.setValue(data.DocumentCategoryId);
                $('#fld-edit-selected-document-category-id').val(data.DocumentCategoryId);
                $('#fld-edit-selected-document-category-name').val(data.DocumentCategoryName);
            }

            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-document-prefix').val(data.DocumentTypePrefix);
            $('#fld-edit-description').val(data.Description);

            $('#mdl-edit').modal('show');
        });
    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'DocumentGroup');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Document type Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'DocumentGroup');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Document type Updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this document type? ', deleteRating, id);

    });

});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteRating = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Document type deleted', 'success');
        done();
    });

}

var loadDocumentCategories = function () {
    if ($selectizeDocumentCategories != null) {
        return;
    }

    $selectizePositions = $('.fld-document-categories').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/DocumentCategories/GetAll',
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
                $('#fld-selected-document-category-id').val(item.Id);
                $('#fld-selected-document-category-name').val(item.Name);
            } else {
            }

        },
    });
}

var loadEditDocumentCategories = function () {
    if ($selectizeEditDocumentCategories != null) {
        return;
    }

    $selectizeEditDocumentCategories = $('.fld-edit-document-categories').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/DocumentCategories/GetAll',
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
                $('#fld-edit-selected-document-category-id').val(item.Id);
                $('#fld-edit-selected-document-category-name').val(item.Name);
            } else {
            }

        },
    });
}