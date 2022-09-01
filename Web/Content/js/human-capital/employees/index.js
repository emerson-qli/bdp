var page                    = new Page("/HumanCapital/Employees");
var $selectizePositions     = null;
var $selectizeDepartments   = null;
var $selectizeGender        = null;
var $selectizeGenderEdit    = null;
var $selectizeEmployees     = null;
var $positionState          = null;


$(function () {

    loadPositions();
    loadDepartments();
    loadEmployees();
    loadGenders();

    loadGendersEdit();

    loadPositionState();

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

    $(document).on('click', '#btn-add', function () {

        $('#mdl-new').modal('show');

    });

    $(document).on('click', '.btn-account', function () {
        var id = $(this).data('id');
        $('#mdl-user').find('#fld-account-employee-id').val(id);

        page.get('/GetUser?id=' + id).then(function (data) {
            $('#fld-account-email').val(data.Username);

            $('#mdl-user').modal('show');
        });

    });

    $(document).on('click', '#btn-new-account-save', function () {
       

        var validation = page.validate('#bdy-new-account', 'Account');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateUser', $('#btn-new-account-save'), 'Account saved', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + '-' + validation.Message.join('<br />'), 'error')
        }

    });


    $(document).on('click', '.btn-delete', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this employee? ', deleteEmployee, id);
        }

    });

    $(document).on('click', '#btn-new-save', function () {
        var validation = page.validate('#bdy-new', 'Employee');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Employee Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/Get?id=' + id).then(function (data) {
            $('#fld-edit-first-name').val(data.Firstname);
            $('#fld-edit-middle-name').val(data.Middlename);
            $('#fld-edit-last-name').val(data.Lastname);
            $('#fld-edit-date-of-birth').val(moment(data.DateOfBirth).format('MM/DD/YYYY'));
            $('#fld-edit-address').val(data.Address);
            
            $('#fld-edit-nationality').val(data.Nationality);
            $('#fld-edit-user-id').val(data.UserId);
            $('#fld-edit-id').val(data.Id);
            $('#mdl-edit').modal('show');

            if ($selectizeGenderEdit != null) {
                $selectizeGenderEdit[0].selectize.setValue(data.Gender);
                $('#fld-edit-selected-gender').val(data.Gender);
            }

        });
    });


    $(document).on('click', '.btn-photo', function () {
        $('.lbl-file-uploaded').html('<a target="_blank" href="/content/files/"></a>');
        var id = $(this).data('id');
        page.get('/Get?id=' + id).then(function (data) {
            if (data.Photo != null && data.PhotoOriginalFileName != null) {
                $('.lbl-file-uploaded').html('<a target="_blank" href="/content/files/' + data.Photo + '">' + data.PhotoOriginalFileName + '</a>');
            }
            $('#fld-edit-photo-id').val(data.Id);
            $('#mdl-photo').modal('show');
        });
        
    });

    $(document).on('click', '#btn-new-photo-save', function () {

        var validation = page.validate('#bdy-update-photo', 'Employee');

        if (validation.Valid) {
            page.save(validation.Entity, '/UploadPhoto', $('#btn-new-photo-save'), 'Employee updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + '' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {
        var validation = page.validate('#bdy-edit', 'Employee');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Employee updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + '' + validation.Message.join('<br />'), 'error')
        }

    });

    var positionCtr = 0;
    var positions = [];

    $(document).on('click', '.btn-add-position', function () {

        positionCtr++;

        positions.push({
            'Order'                         : positionCtr,
            'DepartmentId'                  : $('#fld-department-id').val(),
            'DepartmentName'                : $('#fld-department-name').val(),
            'PositionId'                    : $('#fld-position-id').val(),
            'PositionName'                  : $('#fld-position-name').val(),
            'StartDate'                     : $('.fld-start-date').val(),
            'EndDate'                       : $('.fld-end-date').val(),
            'ReportingTo'                   : $('#fld-supervisor-id').val(),
            'ReportingToEmployeeFullName'   : $('#fld-supervisor-name').val(),
            'Tag'                           : $('#fld-selected-position-state').val()
        })

        if ($selectizeEmployees != null) {
            $selectizeEmployees[0].selectize.setValue('');
        }

        if ($positionState != null) {
            $positionState[0].selectize.setValue('');
        }

        if ($selectizeDepartments != null) {
            $selectizeDepartments[0].selectize.setValue('');
        }

        if ($selectizePositions != null) {
            $selectizePositions[0].selectize.setValue('');
        }

        $('.fld-start-date').val('')
        $('.fld-end-date').val('')

        var html = '';

        positions = _.sortBy(positions, 'Order').reverse();

        $.each(positions, function (k, v) {

            html += '<tr>' +
                        '<td class="align-middle">' + 
                            '<span>' + v.DepartmentName + '</span>' +
                        '</td>' +
                        '<td class="align-middle">' + 
                            '<span>' + v.PositionName + '</span>' +
                        '</td>' +
                        '<td class="align-middle">' + 
                            '<span>' + v.ReportingToEmployeeFullName + '</span>' +
                        '</td>' +
                        '<td class="align-middle">' + 
                            '<span>' + v.StartDate + '</span>' +
                        '</td>' +
                        '<td class="align-middle">' + 
                            '<span>' + ((v.Tag == 1) ? 'Current' : v.EndDate) + '</span>' +
                        '</td>' +
                        '<td class="text-center">' + 
                            '<a href="#" class="btn btn-sm btn-danger btn-delete" data-id="' + v.Order + '" title="Delete"><i class="fa fa-trash"></i></a>' +
                        '</td>' +
                    '</tr>';

        });

        $('.bdy-positions').html(html);

    });
   
    $(document).on('click', '.btn-view', function () {

        var id = $(this).data('id');
        location.href = '/Account/Profile/Index/' + id;

    });
});

var deleteEmployee = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Employee deleted', 'success');
        done();
    });

}



var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var loadPositionState = function () {

    if ($positionState != null) {
        return;
    }


    $positionState = $('.fld-position-states').selectize({
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
                if (item.Id == 1) {
                    $('.fld-end-date').prop('disabled', true);
                } else {
                    $('.fld-end-date').prop('disabled', false);
                }
                $('#fld-selected-position-state').val(item.Id);
            } else {
            }

        },
    });

}

var loadGenders = function () {

    if ($selectizeGender != null) {
        return;
    }

    $selectizeGender = $('.fld-gender').selectize({
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
                $('#fld-selected-gender').val(item.Name);
            } else {
            }

        },
    });
}



var loadGendersEdit = function () {
    if ($selectizeGenderEdit != null) {
        return;
    }
    $selectizeGenderEdit = $('.fld-edit-gender').selectize({
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
                $('#fld-edit-selected-gender').val(item.Name);
            } else {
            }

        },
    });

}


var loadDepartments = function () {

    if ($selectizeDepartments != null) {
        return;
    }

    $selectizePositions = $('.fld-departments').selectize({
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
                $('#fld-department-id').val(item.Id);
                $('#fld-department-name').val(item.Name);
            } else {
            }

        },
    });

}

var loadPositions = function () {

    if ($selectizePositions != null) {
        return;
    }

    $selectizePositions = $('.fld-positions').selectize({
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
                url: '/HumanCapital/Positions/GetAll',
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
                $('#fld-position-id').val(item.Id);
                $('#fld-position-name').val(item.Name);
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
                $('#fld-supervisor-id').val(item.Id);
                $('#fld-supervisor-name').val(item.Fullname);
            } else {
            }

        },
    });

}

var noPermissionAlert = function () {
    $('#mdl-permission').modal('show');
    $('#mdl-permission').find('.p-message').html('You have no permission to delete, please contact the administrator');
}