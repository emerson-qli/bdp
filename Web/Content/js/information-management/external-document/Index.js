var page = new Page("/InformationManagement/ExternalDocument");

var $selectizeEmployees     = null;
var $selectizeEditEmployees = null;
$(function () {

    loadEmployees();
    loadEditEmployees();

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
        $('.lbl-file-uploaded').html('');
        $('#mdl-new').modal('show');
    });
    $(document).on('click', '.btn-edit', function () {
        var id = $(this).data('id');
        page.get('/Get?id=' + id).then(function (data) {
            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-title').val(data.Title);
            $('#fld-edit-date').val(moment(data.Date).format('MM-DD-YYYY'));
            $('#fld-edit-employee-id').val(data.EmployeeId);
            $('#fld-edit-received-by').val(data.ReceivedBy);
            $('#fld-edit-from').val(data.From);
            $('#fld-edit-remarks').val(data.Remarks);
            $('.lbl-file-uploaded').html('<a target="_blank" href="/content/files/' + data.UniqueFileName + '">' + data.OriginalFileName + '</a>');
            $('#fld-edit-unique-file-name').val(data.UniqueFileName);
            $('#fld-edit-original-file-name').val(data.OriginalFileName);

            if ($selectizeEditEmployees != null) {
                $selectizeEditEmployees[0].selectize.setValue(data.EmployeeId);
            }

            $('#mdl-edit').modal('show');
        });

    });


    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'ExternalDocument');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Document Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'ExternalDocument');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Document Updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this document? ', deleteExternalDocument, id);

    });

    $(document).on('change', '#fle-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-photo-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-upload').val('');
                $("#file-uploadphoto-progress").attr({
                    value: 0,
                    max: 100
                });
                notify('File uploaded', 'success');
                $('#fld-new-unique-file-name').val(file.Item3);
                $('#fld-new-original-file-name').val(file.Item1);
                $('.lbl-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-uploadphoto-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-uploadphoto-progress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                            $("#file-uploadphoto-progress").hide();
                        }
                    }, false);
                }
                return fileXhr;
            }
        });

    });

    $(document).on('change', '#fle-edit-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-edit-photo-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-edit-upload').val('');
                $("#file-edit-uploadphoto-progress").attr({
                    value: 0,
                    max: 100
                });
                notify('File uploaded', 'success');
                $('#fld-edit-unique-file-name').val(file.Item3);
                $('#fld-edit-original-file-name').val(file.Item1);
                $('.lbl-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-edit-uploadphoto-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-edit-uploadphoto-progress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                            $("#file-edit-uploadphoto-progress").hide();
                        }
                    }, false);
                }
                return fileXhr;
            }
        });

    });


});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteExternalDocument = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Document deleted', 'success');
        done();
    });

}

var loadEmployees = function () {

    if ($selectizeEmployees != null) {
        return;
    }

    $selectizeEmployees = $('.fld-employees').selectize({
        valueField: 'Id',
        searchField: 'Fullname',
        labelField: 'Fullname',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/HumanCapital/Employees/GetAll',
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
                $('#fld-new-employee-id').val(item.Id);
                $('#fld-new-received-by').val(item.Fullname);
            } else {
            }

        },
    });

}

var loadEditEmployees = function () {

    if ($selectizeEditEmployees != null) {
        return;
    }

    $selectizeEditEmployees = $('.fld-edit-employees').selectize({
        valueField: 'Id',
        searchField: 'Fullname',
        labelField: 'Fullname',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/HumanCapital/Employees/GetAll',
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
                $('#fld-edit-employee-id').val(item.Id);
                $('#fld-edit-received-by').val(item.Fullname);
            } else {
            }

        },
    });

}

