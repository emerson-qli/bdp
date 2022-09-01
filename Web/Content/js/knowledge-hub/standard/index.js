var page = new Page("/KnowledgeHub/Standard");

var $selectizeDepartments           = null;
var $selectizeEmployees             = null;
var $selectizeMStype                = null;

var $selectizeDepartmentsEdit       = null;
var $selectizeEmployeesEdit         = null;
var $selectizeMStypeEdit            = null;

$(function () {

    loadDepartments();
    loadEmployees();
    loadMSType();

    loadDepartmentsEdit();
    loadEmployeesEdit();
    loadMSTypeEdit();

    $('#tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('change', '#fle-photo-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-photo-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-photo-upload').val('');
                $("#file-uploadphoto-progress").attr({
                    value: 0,
                    max: 100
                });
                notify('File uploaded', 'success');
                $('#fld-file-name').val(file.Item3);
                $('#fld-original-file-name').val(file.Item1);
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

    $(document).on('change', '#fle-edit-photo-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-edit-photo-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-edit-photo-upload').val('');
                $("#file-edit-uploadphoto-progress").attr({
                    value: 0,
                    max: 100
                });
                notify('File uploaded', 'success');
                $('#fld-edit-file-name').val(file.Item3);
                $('#fld-edit-original-file-name').val(file.Item1);
                $('.lbl-edit-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
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

    $(document).on('click', '#btn-new-standard', function () {
        $('#mdl-new').modal('show');
    });
    $(document).on('click', '.btn-edit', function () {
        var id = $(this).data('id');
        page.get('/Get?id=' + id).then(function (data) {
            if ($selectizeEmployeesEdit != null) {
                $selectizeEmployeesEdit[0].selectize.setValue(data.EmployeeId);
                $('#fld-edit-employee-id').val(data.EmployeeId);
                $('#fld-edit-employee-name').val(data.EmployeeName);
            }

            if ($selectizeDepartmentsEdit != null) {
                $selectizeDepartmentsEdit[0].selectize.setValue(data.DepartmentId);
                $('#fld-edit-department-id').val(data.DepartmentId);
                $('#fld-edit-department-name').val(data.DepartmentName);
            }

            if ($selectizeMStypeEdit != null) {
                $selectizeMStypeEdit[0].selectize.setValue(data.ManagementSystemId);
                $('#fld-edit-ms-type-id').val(data.ManagementSystemId);
                $('#fld-edit-ms-type-name').val(data.ManagementSystemName);
            }


            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-description').val(data.Description);
            $('.lbl-edit-file-uploaded').html('<a target="_blank" href="/content/files/' + data.UniqueFileName + '">' + data.OriginalFileName + '</a>');
            $('#fld-edit-file-name').val(data.UniqueFileName);
            $('#fld-edit-original-file-name').val(data.OriginalFileName);

            $('#mdl-edit').modal('show');
        });

    });


    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'KnowledgeHubStandard');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Standard Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'KnowledgeHubStandard');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Standard Updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this standard? ', deleteStandard, id);

    });


});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteStandard = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Standard deleted', 'success');
        done();
    });

}

var loadDepartments = function () {

    if ($selectizeDepartments != null) {
        return;
    }

    $selectizeDepartments = $('.fld-departments').selectize({
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
                url: '/HumanCapital/Departments/GetAll',
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
                $('#fld-new-department-id').val(item.Id);
                $('#fld-new-department-name').val(item.Name);
            } else {
            }

        },
    });

}

var loadDepartmentsEdit = function () {

    if ($selectizeDepartmentsEdit != null) {
        return;
    }

    $selectizeDepartmentsEdit = $('.fld-edit-departments').selectize({
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
                url: '/HumanCapital/Departments/GetAll',
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
                $('#fld-edit-department-id').val(item.Id);
                $('#fld-edit-department-name').val(item.Name);
            } else {
            }

        },
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
                $('#fld-new-employee-name').val(item.Fullname);
            } else {
            }

        },
    });

}

var loadEmployeesEdit = function () {

    if ($selectizeEmployeesEdit != null) {
        return;
    }

    $selectizeEmployeesEdit = $('.fld-edit-employees').selectize({
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
                $('#fld-edit-employee-name').val(item.Fullname);
            } else {
            }

        },
    });

}

var loadMSType = function () {

    if ($selectizeMStype != null) {
        return;
    }

    $selectizeMStype = $('.fld-ms-types').selectize({
        valueField: 'Id',
        searchField: 'Type',
        labelField: 'Type',
        preload: true,
        create: true,
        sortField: {
            field: 'Type',
            direction: 'asc'
        }, render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Type) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Type) + '</div>'
                    + '</div>';
            }
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Organization/Profile/GetAllManagementSystem',
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
                $('#fld-new-ms-type-id').val(item.Id);
                $('#fld-new-ms-type-name').val(item.Type);
            } else {
            }

        },
    });
}

var loadMSTypeEdit = function () {

    if ($selectizeMStypeEdit != null) {
        return;
    }

    $selectizeMStypeEdit = $('.fld-edit-ms-types').selectize({
        valueField: 'Id',
        searchField: 'Type',
        labelField: 'Type',
        preload: true,
        create: true,
        sortField: {
            field: 'Type',
            direction: 'asc'
        }, render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Type) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Type) + '</div>'
                    + '</div>';
            }
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Organization/Profile/GetAllManagementSystem',
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
                $('#fld-edit-ms-type-id').val(item.Id);
                $('#fld-edit-ms-type-name').val(item.Type);
            } else {
            }

        },
    });
}