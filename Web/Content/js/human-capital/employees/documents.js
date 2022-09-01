var page                    = new Page("/HumanCapital/Employees");
var path                    = 'Content/files/';
var $selectizeDocuments     = null;
var $selectizeEditDocuments = null;

$(function () {

    loadDocumentsSelectize();
    loadEditDocumentsSelectize();

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

    $(document).on('click', '.btn-upload', function () {
        $('#mdl-new').modal('hide');
        $('#mdl-edit').modal('hide');
        $('#modal-file-upload').modal('show');

    });

    $(document).on('click', '.btn-edit-upload', function () {
        $('#mdl-new').modal('hide');
        $('#mdl-edit').modal('hide');
        $('#mdl-edit-file-upload').modal('show');
    });

    $(document).on('click', '#btn-back', function () {
        location.href = '/HumanCapital/Employees/';
    })

    $(document).on('click', '.btn-delete', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this document? ', deleteEmployeeDocument, id);
        }

    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetDocument?id=' + id).then(function (data) {

            $('#mdl-edit').modal('show');

            if ($selectizeEditDocuments != null) {
                $selectizeEditDocuments[0].selectize.setValue(data.DocumentGroupId);
                $('#selected-edit-document-type-id').val(data.DocumentGroupId);
                $('#selected-edit-document-type-name').val(data.DocumentGroupName);
            }
            $('.lbl-edit-file').html('<a target="_blank" href="/content/files/' + data.FileName + '">' + data.OriginalFileName + '</a>')
            $('#fld-edit-label').val(data.Label);
            $('#fld-edit-description').val(data.Description);
            $('#fld-edit-path').val(data.Path);
            $('#fld-edit-file-name').val(data.FileName);
            $('#fld-edit-original-file-name').val(data.OriginalFileName);
            $('#fld-edit-id').val(data.Id);

        });
    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'EmployeeDocument');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveDocument', $('#btn-new-save'), 'Document Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'EmployeeDocument');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateDocument', $('#btn-edit-save'), 'Document updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('change', '#fle-file-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-file-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-file-upload').val('');
                $("#file-upload-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#modal-file-upload').modal('hide');
                notify('File uploaded', 'success');
                $('#fld-path').val(path);
                $('#fld-file-name').val(file.Item3);
                $('#fld-original-file-name').val(file.Item1);
                $('#mdl-new').modal('show');

                $('.lbl-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-upload-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-upload-progress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                        }
                    }, false);
                }
                return fileXhr;
            }
        });

    });

    $(document).on('change', '#fle-edit-file-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-edit-file-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-edit-file-upload').val('');
                $("#file-edit-upload-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#mdl-edit-file-upload').modal('hide');
                notify('File uploaded', 'success');

                $('#fld-edit-path').val(path);
                $('#fld-edit-file-name').val(file.Item3);
                $('#fld-edit-original-file-name').val(file.Item1);
                $('#mdl-edit').modal('show');

                $('.lbl-edit-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-edit-upload-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-edit-upload-progress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                        }
                    }, false);
                }
                return fileXhr;
            }
        });

    });

});

var deleteEmployeeDocument = function (id) {

    page.get('/DeleteDocument?id=' + id).then(function () {
        notify('Document deleted', 'success');
        done();
    });

}

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}


var loadDocumentsSelectize = function () {

    if ($selectizeDocuments != null) {
        return;
    }

    $selectizeDocuments = $('.fld-document-types').selectize({
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
                url: '/Setting/DocumentTypes/GetAll',
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
                $('#selected-document-type-id').val(item.Id);
                $('#selected-document-type-name').val(item.Name);
            } else {
            }

        },
    });

}


var loadEditDocumentsSelectize = function () {

    if ($selectizeEditDocuments != null) {
        return;
    }

    $selectizeEditDocuments = $('.fld-edit-document-types').selectize({
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
                url: '/Setting/DocumentTypes/GetAll',
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
                $('#selected-edit-document-type-id').val(item.Id);
                $('#selected-edit-document-type-name').val(item.Name);
            } else {
            }

        },
    });

}

var noPermissionAlert = function () {
    $('#mdl-permission').modal('show');
    $('#mdl-permission').find('.p-message').html('You have no permission to delete, please contact the administrator');
}