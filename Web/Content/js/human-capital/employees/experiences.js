var page                            = new Page("/HumanCapital/Employees");

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

    $(document).on('click', '#btn-back', function () {
        location.href = '/HumanCapital/Employees/';
    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetExperience?id=' + id).then(function (data) {
            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-company-name').val(data.CompanyName);
            $('#fld-edit-company-location').val(data.CompanyLocation);
            $('#fld-edit-designation').val(data.PositionName);
            $('#fld-edit-start-year').val(data.StartYear);
            $('#fld-edit-end-year').val(data.EndYear);
            $('#mdl-edit').modal('show');
        });
    });

    

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'EmployeeExperience');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveExperience', $('#btn-new-save'), 'Experience Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this experience? ', deleteExperience, id);
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'EmployeeExperience');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateExperience', $('#btn-edit-save'), 'Experience updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });


});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteExperience = function (id) {

    page.get('/DeleteExperience?id=' + id).then(function () {
        notify('Experience deleted', 'success');
        done();
    });

}

var noPermissionAlert = function () {
    $('#mdl-permission').modal('show');
    $('#mdl-permission').find('.p-message').html('You have no permission to delete, please contact the administrator');
}