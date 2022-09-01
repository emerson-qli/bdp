var page                        = new Page("/HumanCapital/Employees");
var $selectizePositions         = null;
var $selectizeDepartments       = null;
var $selectizeEmployees         = null;
var $positionState              = null;
var $selectizeContactType       = null;

var $selectizeEditPositions     = null;
var $selectizeEditDepartments   = null;
var $selectizeEditEmployees     = null;
var $EditpositionState          = null;
var $selectizeEditContactType   = null;

$(function () {

    loadPositionState();
    loadDepartments();
    loadEmployees();
    loadPositions();
    loadContactType();

    loadEditEmployees();
    loadEditDepartments();
    loadEditPositions();
    loadEditPositionState();

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
        $('#modal-file-upload').modal('show');
        bt-n
    });

    $(document).on('click', '#btn-back', function () {
        location.href = '/HumanCapital/Employees/';
    })

    $(document).on('click', '.btn-delete', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this document? ', deleteEmployeeDesignation, id);
        }
    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');

        page.get('/GetDesignation?id=' + id).then(function (data) {
            if (data.EndDate != null) {
                $('.fld-edit-end-date').val(moment(data.EndDate).format('MM/DD/YYYY'));
            }
            if ($selectizeEditPositions != null) {
                $selectizeEditPositions[0].selectize.setValue(' ');
            }
            if ($selectizeEditDepartments != null) {
                $selectizeEditDepartments[0].selectize.setValue(' ');
            }
            if ($selectizeEditEmployees != null) {
                $selectizeEditEmployees[0].selectize.setValue(' ');
            }   

            $('#fld-edit-position-id').val(data.PositionId);
            $('#fld-edit-position-name').val(data.PositionName);

            $('#fld-edit-department-id').val(data.DepartmentId);
            $('#fld-edit-department-name').val(data.DepartmentName);

            $('#fld-edit-supervisor-id').val(data.ReportingTo);
            $('#fld-edit-supervisor-name').val(data.ReportingToEmployeeFullName);

            $('.fld-edit-start-date').val(moment(data.StartDate).format('MM/DD/YYYY'));
            $('#fld-edit-id').val(data.Id);

            
            
            $('#mdl-edit').modal('show');
        });
    });

    $(document).on('click', '#btn-new-save', function () {
        var validation = page.validate('#bdy-new', 'EmployeePosition');

        if (validation.Valid) {
            page.save(validation.Entity, '/SavePosition', $('#btn-new-save'), 'Designation Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'EmployeePosition');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdatePosition', $('#btn-edit-save'), 'Designation updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });


    $('#mdl-edit').on('shown.bs.modal', function () {
        var positionId      = $('#fld-edit-position-id').val();
        var departmentId    = $('#fld-edit-department-id').val();
        var reportingTo     = $('#fld-edit-supervisor-id').val();

        setTimeout(
            function () {

                if ($selectizeEditPositions != null) {
                    $selectizeEditPositions[0].selectize.setValue(positionId);
                    
                }
                if ($selectizeEditDepartments != null) {
                    $selectizeEditDepartments[0].selectize.setValue(departmentId);
                    
                }
                if ($selectizeEditEmployees != null) {
                    $selectizeEditEmployees[0].selectize.setValue(reportingTo);
                    
                }

            }, 1000);
    });

});

var deleteEmployeeDesignation = function (id) {

    page.get('/DeletePosition?id=' + id).then(function () {
        notify('Designation deleted', 'success');
        done();
    });

}

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var loadContactType = function () {

    if ($selectizeContactType != null) {
        return;
    }

    $positionState = $('.fld-edit-contact-types').selectize({
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
                if (item.Id == 0) {
                   
                } else {
                   
                }
                $('#selected-edit-contact-type').val(item.Id);
            } else {
            }

        },
    });

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
                if (item.Id == 0) {
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

var loadEditPositionState = function () {

    if ($EditpositionState != null) {
        return;
    }

    $positionState = $('.fld-edit-position-states').selectize({
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
                if (item.Id == 0) {
                    $('.fld-edit-end-date').prop('disabled', true);
                } else {
                    $('.fld-edit-end-date').prop('disabled', false);
                }
                $('#fld-edit-selected-position-state').val(item.Id);
            } else {
            }

        },
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
                $('#fld-department-id').val(item.Id);
                $('#fld-department-name').val(item.Name);
            } else {
            }

        },
    });

}

var loadEditDepartments = function () {

    if ($selectizeEditDepartments != null) {
        return;
    }

    $selectizeEditDepartments = $('.fld-edit-departments').selectize({
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

var loadEditPositions = function () {

    if ($selectizeEditPositions != null) {
        return;
    }

    $selectizeEditPositions = $('.fld-edit-positions').selectize({
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
                $('#fld-edit-position-id').val(item.Id);
                $('#fld-edit-position-name').val(item.Name);
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
                $('#fld-edit-supervisor-id').val(item.Id);
                $('#fld-edit-supervisor-name').val(item.Fullname);
            } else {
            }

        },
    });

}

var noPermissionAlert = function () {
    $('#mdl-permission').modal('show');
    $('#mdl-permission').find('.p-message').html('You have no permission to delete, please contact the administrator');
}