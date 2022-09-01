var page = new Page("/HumanCapital/Employees");

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
        $('#modal-file-upload').modal('show');

    });

    $(document).on('click', '#btn-back', function () {
        location.href = '/HumanCapital/Employees/';
    })

    $(document).on('click', '.btn-delete', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this program? ', deleteProgram, id);
        }

    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetProgram?id=' + id).then(function (data) {

            $('#mdl-edit').modal('show');
            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-expected-start-date').val(moment(data.ExpectedStartDate).format('MM/DD/YYYY'));
            $('#fld-edit-expected-end-date').val(moment(data.ExpectedEndDate).format('MM/DD/YYYY'));

            if (data.ActualStartDate != null) {
                $('#fld-edit-actual-start-date').val(moment(data.ActualStartDate).format('MM/DD/YYYY'));
            }
            if (data.ActualEndDate != null) {
                $('#fld-edit-actual-end-date').val(moment(data.ActualEndDate).format('MM/DD/YYYY'));
            }

        });
    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'EmployeeProgram');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveProgram', $('#btn-new-save'), 'Program Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'EmployeeProgram');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateProgram', $('#btn-edit-save'), 'Program updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

});

var deleteProgram = function (id) {

    page.get('/DeleteProgram?id=' + id).then(function () {
        notify('Program deleted', 'success');
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

