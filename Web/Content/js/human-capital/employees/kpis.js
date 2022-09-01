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
            showConfirm('Are you sure you want to delete this KPI? ', deleteKPI, id);
        }

    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetKPI?id=' + id).then(function (data) {

            $('#mdl-edit').modal('show');
            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-description').val(data.Description);
            $('#fld-edit-target').val(data.Target);

        });
    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'EmployeeKPI');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveKPI', $('#btn-new-save'), 'KPI Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'EmployeeKPI');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateKPI', $('#btn-edit-save'), 'KPI updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

});

var deleteKPI = function (id) {

    page.get('/DeleteKPI?id=' + id).then(function () {
        notify('KPI deleted', 'success');
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