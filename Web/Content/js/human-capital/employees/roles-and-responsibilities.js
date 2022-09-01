var page                    = new Page("/HumanCapital/Employees");
var path                    = 'Content/files/';

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

    $(document).on('click', '.btn-upload', function () {
        $('#mdl-new').modal('hide');
        $('#mdl-edit').modal('hide');
        $('#modal-file-upload').modal('show');

    });

    $(document).on('click', '.btn-edit-upload', function () {
        $('#mdl-new').modal('hide');
        $('#mdl-edit').modal('hide');
        $('#modal-edit-file-upload').modal('show');

    });

    $(document).on('click', '#btn-back', function () {
        location.href = '/HumanCapital/Employees/';
    })

    $(document).on('click', '.btn-delete', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this item? ', deleteRoleAndResponsibility, id);
        }

    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetRoleAndResponsibility?id=' + id).then(function (data) {
            $('#mdl-edit').modal('show');
            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-description').val(data.Description);
            $('#fld-edit-file-name').val(data.UniqueFileName);
            $('#fld-edit-original-file-name').val(data.OriginalFileName);
            $('.lbl-edit-file').html('<a target="_blank" href="/content/files/' + data.UniqueFileName + '">' + data.OriginalFileName + '</a>');

        });
    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'EmployeeRoleAndResponsibility');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveRoleAndResponsibility', $('#btn-new-save'), 'Role and Responsibility Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'EmployeeRoleAndResponsibility');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateRoleAndResponsibility', $('#btn-edit-save'), 'Role and Responsibility updated', 'Update failed', done);
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
                $('#modal-edit-file-upload').modal('hide');
                notify('File uploaded', 'success');
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

var deleteRoleAndResponsibility  = function (id) {

    page.get('/DeleteRoleAndResponsibility?id=' + id).then(function () {
        notify('Role and Responsibility deleted', 'success');
        done();
    });

}

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var noPermissionAlert = function () {
    $('#mdl-permission').modal('show');
    $('#mdl-permission').find('.p-message').html('You have no permission to delete, please contact the administrator');
}