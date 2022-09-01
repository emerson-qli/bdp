var page = new Page("/ABCCompany/Locations");

$(document).ready(function () {

    $('#tbl-country-states').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('click', '#btn-add-region-state', function () {

        $('#mdl-new-region-state').modal('show');

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this region/state? ', deleteRegionState, id);

    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetStateRegion?id=' + id).then(function (data) {

            $('#fld-edit-region-state-name').val(data.Name);
            $('#fld-edit-region-state-id').val(data.Id);
            $('#mdl-edit-region-state').modal('show');
        });

    });

    $(document).on('click', '#btn-edit-region-state-save', function () {

        var validation = page.validate('#bdy-edit-region-state', 'CountryStateRegion');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateStateRegion', $('#btn-edit-region-state-save'), 'Region/State updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields</strong>', 'error')
        }

    });

    $(document).on('click', '#btn-new-region-state-save', function () {

        var validation = page.validate('#bdy-new-region-state', 'CountryStateRegion');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveStateRegion', $('#btn-new-region-state-save'), 'Region/State added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields</strong>', 'error')
        }

    });

});

var deleteRegionState = function (id) {
    page.get('/DeleteRegionState?id=' + id).then(function () {
        notify('Region/state deleted', 'success');
        done();
    });
}

var done = function () {
    location.reload();
}