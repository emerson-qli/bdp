var page                    = new Page("/HumanCapital/Employees");
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
        $('#mdl-new').modal('show');
    });


    $(document).on('click', '#btn-back', function () {
        location.href = '/HumanCapital/Employees/';
    })

    $(document).on('click', '.btn-delete', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this job description? ', deleteJobDescription, id);
        }

    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetJobDescription?id=' + id).then(function (data) {

            $('#mdl-edit').modal('show');
            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-title').val(data.Title);
            $('#fld-edit-description').val(data.Description);

            if ($selectizeEditEmployees != null) {
                $selectizeEditEmployees[0].selectize.setValue(data.SupervisorId);
                $('#fld-edit-supervisor-id').val(data.SupervisorId);
                $('#fld-edit-supervisor-name').val(data.SupervisorName);
            }


        });
    });

    $(document).on('click', '#btn-new-save', function () {
        var validation = page.validate('#bdy-new', 'EmployeeJobDescription');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveJobDescription', $('#btn-new-save'), 'Job description Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'EmployeeJobDescription');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateJobDescription', $('#btn-edit-save'), 'Job description updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });


});

var deleteJobDescription = function (id) {

    page.get('/DeleteJobDescription?id=' + id).then(function () {
        notify('Job description deleted', 'success');
        done();
    });

}

var done = function () {
    setTimeout(
    function () {
        location.reload();
    }, 1000);
}

var loadEmployees = function () {
    if ($selectizeEmployees != null) {
        return;
    }

    $selectizeEmployees = $('.fld-new-employees').selectize({
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
                $('#fld-new-supervisor-name').val(item.Fullname);
                $('#fld-new-supervisor-id').val(item.Id);
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
                $('#fld-edit-supervisor-name').val(item.Fullname);
                $('#fld-edit-supervisor-id').val(item.Id);
            } else {
            }

        },
    });
}

var noPermissionAlert = function () {
    $('#mdl-permission').modal('show');
    $('#mdl-permission').find('.p-message').html('You have no permission to delete, please contact the administrator');
}