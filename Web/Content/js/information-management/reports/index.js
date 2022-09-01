var page                    = new Page("/InformationManagement/ExternalDocument");

var $selectizeEmployees     = null;
var $selectizeEditEmployees = null;

$(function () {

    loadEmployees();
    loadEditEmployees();

    $('#tbl-drcn-report').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-internal .tbl-masterlist-of-documents').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-external .tbl-masterlist-of-documents').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-obsolete .tbl-masterlist-of-documents').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-registration-for-external-document').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-list-of-departmental-records').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-transfer #tbl-list-of-departmental-records').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-disposal #tbl-list-of-departmental-records').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('click', '.btn-view-record', function () {
        var d = $(this).data('table');

        if (d == 'tbl-transfer') {
            $('#btn-transfer').addClass('btn-primary').removeClass('btn-outline-primary');
            $('#btn-disposal').addClass('btn-outline-primary').removeClass('btn-primary');

        } else {
            $('#btn-transfer').addClass('btn-outline-primary').removeClass('btn-primary');
            $('#btn-disposal').addClass('btn-primary').removeClass('btn-outline-primary');

        }

        $('.tbl-form').addClass('d-none');
        $('#' + d).removeClass('d-none');
    });

    $(document).on('click', '.btn-view-masterlist-documents', function () {
        var d = $(this).data('table');

        if (d == 'tbl-internal') {
            $('#btn-internal').addClass('btn-primary').removeClass('btn-outline-primary');
            $('#btn-external').addClass('btn-outline-primary').removeClass('btn-primary');
            $('#btn-obsolete').addClass('btn-outline-primary').removeClass('btn-primary');
        } else if (d == 'tbl-external') {
            $('#btn-internal').addClass('btn-outline-primary').removeClass('btn-primary');
            $('#btn-external').addClass('btn-primary').removeClass('btn-outline-primary');
            $('#btn-obsolete').addClass('btn-outline-primary').removeClass('btn-primary');

        } else {
            $('#btn-internal').addClass('btn-outline-primary').removeClass('btn-primary');
            $('#btn-external').addClass('btn-outline-primary').removeClass('btn-primary');
            $('#btn-obsolete').addClass('btn-primary').removeClass('btn-outline-primary');
        }

        $('.tbl').addClass('d-none');
        $('#' + d).removeClass('d-none');
    });

    if (window.location.hash) {
        $("a[href='" + window.location.hash + "']").tab('show');
    } else {
        $("a[href='#nav-drcn-report']").tab('show');
    }

    $(document).on('click', '.nav-item', function () {
        var hash = $(this).data('hash');
        if (hash) {
            location.href = '/InformationManagement/Reports' + hash;
        }
    });

    $(document).on('click', '#btn-add-external-document', function () {
        $('.lbl-file-uploaded').html('');
        $('#mdl-new-external-document').modal('show');
    });
    $(document).on('click', '.btn-edit-external-document', function () {
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

            $('#mdl-edit-external-document').modal('show');
        });

    });


    $(document).on('click', '#btn-new-external-document-save', function () {

        var validation = page.validate('#bdy-new-external-document', 'ExternalDocument');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-external-document-save'), 'External Document Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });

    $(document).on('click', '#btn-edit-external-document-save', function () {

        var validation = page.validate('#bdy-edit-external-document', 'ExternalDocument');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-external-document-save'), 'Document Updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete-external-document', function () {

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

