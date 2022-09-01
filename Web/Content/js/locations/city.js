var page = new Page("/ABCCompany/Locations");

$(document).ready(function () {

    $('#tbl-cities').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('click', '#btn-add-city', function () {

        $('#mdl-new-city').modal('show');

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this city? ', deleteCity, id);

    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetCity?id=' + id).then(function (data) {

            $('#fld-edit-city-name').val(data.Name);
            $('#fld-edit-city-id').val(data.Id);
            $('#mdl-edit-city').modal('show');
        });

    });

    $(document).on('click', '#btn-edit-city-save', function () {

        var validation = page.validate('#bdy-edit-city', 'City');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateCity', $('#btn-edit-city-save'), 'City updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields</strong>', 'error')
        }

    });


    $(document).on('click', '#btn-new-city-save', function () {

        var validation = page.validate('#bdy-new-city', 'City');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveCity', $('#btn-city-save'), 'City added', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields</strong>', 'error')
        }

    });

});

var deleteCity = function (id) {
    page.get('/DeleteCity?id=' + id).then(function () {
        notify('City deleted', 'success');
        done();
    });
}

var done = function () {
    location.reload();
}
