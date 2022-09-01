var page = new Page("/Setting/General");

var employees   = [];
var employeesId = [];

var $selectizeTextEditor = null;
var $selectizeTheme      = null;
var $selectizeEmployees  = null;

$(function () {


    loadRecipients();
    loadTextEditor();
    loadTheme();
    loadEmployees();
    loadSelectizeValues();

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
            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-value').val(data.Value);
            $('#fld-edit-group').val(data.Group);
            $('#mdl-edit').modal('show');
        });

    });


    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'Setting');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'General Setting Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });


    $(document).on('click', '#btn-update', function () {

        var name = $(this).data('name');

        var validation = page.validate('#bdy-update-' + name, 'Setting');

        if (validation.Valid) {
            if (employees.length != 0) {
                validation.Entity['Setting.EmployeeRecipients'] = employees;
            }
            page.save(validation.Entity, '/Update', $('#btn-update'), 'General Setting Updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this general setting? ', deleteGeneralSetting, id);

    });

    $(document).on('click', '#btn-test', function () {
        page.get('/TestNotif').then(function () {
            notify('test', 'success');
            done();
        });
    });
});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteGeneralSetting = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('General Setting deleted', 'success');
        done();
    });

}

var loadRecipients = function () {

    var id = $('#fld-id-recipients-for-expiring-documents').val();
    page.get('/GetAllIncludingRecipients?id=' + id).then(function (data) {

        for (var i = 0; i < data[0].EmployeeRecipients.length; i++) {
            employees.push({
                'EmployeeId': data[0].EmployeeRecipients[i].EmployeeId,
                'EmployeeName': data[0].EmployeeRecipients[i].EmployeeName
            });
            employeesId.push(data[0].EmployeeRecipients[i].EmployeeId);
        }
    });
}

var loadTextEditor = function () {
    if ($selectizeTextEditor != null) {
        return;
    }

    $selectizeTextEditor = $('.fld-text-editor').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {
                $('#fld-selected-value-text-editor').val(item.Name);
            } else {
            }

        },
    });
}

var loadTheme = function () {
    if ($selectizeTheme != null) {
        return;
    }

    $selectizeTheme = $('.fld-theme').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {
                $('#fld-selected-value-theme').val(item.Name);
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
            employees = [];

            for (var i = 0; i < value.length; i++) {

                var item = $(this)[0].options[value[i]];

                employees.push({
                    'EmployeeId'    : item.Id,
                    'EmployeeName'  : item.Fullname
                });
            }
        },
    });
}

var loadSelectizeValues = function () {

    setTimeout(
        function () {
            $selectizeTextEditor[0].selectize.setValue($('#fld-selected-value-text-editor').val());
            $selectizeTheme[0].selectize.setValue($('#fld-selected-value-theme').val());
            $selectizeEmployees[0].selectize.setValue(employeesId);
        }, 500);

}