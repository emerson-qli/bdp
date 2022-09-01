var page                    = new Page("/HumanCapital/Employees");
var submittedTo             = [];

var $selectizeFrequency     = null;
var $selectizeEditFrequency = null;

var $selectizeEmployees     = null;
var $selectizeEditEmployees = null;

$(function () {

    loadFrequencies();
    loadEditFrequencies();
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

    $(document).on('click', '#btn-add', function () {
        $('#mdl-new').modal('show');
    });

    $(document).on('click', '#btn-back', function () {
        location.href = '/HumanCapital/Employees/';
    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetReport?id=' + id).then(function (data) {
            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-description').val(data.Description);

            if ($selectizeEditFrequency != null) {
                $selectizeEditFrequency[0].selectize.setValue(data.Frequency);
                $('#fld-edit-selected-frequency').val(data.Frequency);
            }
            if ($selectizeEditEmployees != null) {
                var employeeIds = [];
                for (var i = 0; i < data.Recipients.length; i++) {
                    employeeIds.push(data.Recipients[i].SubmittedToId);
                }
                $selectizeEditEmployees[0].selectize.setValue(employeeIds);
            }

            $('#fld-edit-file-name').val(data.UniqueFileName);
            $('#fld-edit-original-file-name').val(data.OriginalFileName);
            $('.lbl-edit-file').html('<a target="_blank" href="/content/files/' + data.UniqueFileName + '">' + data.OriginalFileName + '</a>');

            $('#mdl-edit').modal('show');
        });
    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validateWithChild('#bdy-new', 'EmployeeReport', submittedTo, 'Recipients');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveReport', $('#btn-new-save'), 'Report Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this report? ', deleteReport, id);
        }
    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validateWithChild('#bdy-edit', 'EmployeeReport', submittedTo, 'Recipients');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateReport', $('#btn-edit-save'), 'Report updated', 'Update failed', done);
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
                $('#mdl-edit-file-upload').modal('hide');
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

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteReport = function (id) {

    page.get('/DeleteReport?id=' + id).then(function () {
        notify('Report deleted', 'success');
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
            submittedTo = [];
            for (var i = 0; i < value.length; i++) {
                submittedTo.push({
                    'SubmittedToId': value[i]
                });
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

            submittedTo = [];
            for (var i = 0; i < value.length; i++) {
                submittedTo.push({
                    'SubmittedToId'   : value[i]
                });
            }
        },
    });
}

var loadFrequencies = function () {
    if ($selectizeFrequency != null) {
        return;
    }

    $selectizeFrequency = $('.fld-frequencies').selectize({
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
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {
                $('#fld-new-selected-frequency').val(item.Id);
            } else {
            }

        },
    });
}

var loadEditFrequencies = function () {
    if ($selectizeEditFrequency != null) {
        return;
    }

    $selectizeEditFrequency = $('.fld-edit-frequencies').selectize({
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
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {
                $('#fld-edit-selected-frequency').val(item.Id);
            } else {
            }

        },
    });
}

var noPermissionAlert = function () {
    $('#mdl-permission').modal('show');
    $('#mdl-permission').find('.p-message').html('You have no permission to delete, please contact the administrator');
}