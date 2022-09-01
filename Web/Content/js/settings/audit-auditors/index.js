var page                        = new Page("/Setting/AuditAuditors");

var $selectizeDepartments       = null;
var $selectizeEmployees         = null;

var $selectizeDepartmentsEdit   = null;
var $selectizeEmployeesEdit     = null;

$(function () {

    loadEmployees();
    loadDepartments();

    loadEmployeesEdit();
    loadDepartmentsEdit();

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

            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-description').val(data.Description);
            $('#mdl-edit').modal('show');
        });

    });


    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'AuditAuditor');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Auditor Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'AuditAuditor');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Auditor Updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this issue category? ', deleteAuditor, id);

    });


});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteAuditor = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Auditor deleted', 'success');
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