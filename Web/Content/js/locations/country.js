var page = new Page("/ABCCompany/Locations");

$(document).ready(function () {

    $('#tbl-countries').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('click', '#btn-add-country', function () {

        $('#mdl-new-country').modal('show');

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this country? ', deleteCountry, id);

    });



    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetCountry?id=' + id).then(function (data) {

            $('#fld-edit-country-name').val(data.Name);
            $('#fld-edit-country-id').val(data.Id);
            $('#mdl-edit-country').modal('show');
        });

    });

    $(document).on('click', '#btn-edit-country-save', function () {

        var validation = page.validate('#bdy-edit-country', 'Country');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateCountry', $('#btn-country-save'), 'Country updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields</strong>', 'error')
        }

    });


    $(document).on('click', '#btn-new-country-save', function () {

        var validation = page.validate('#bdy-new-country', 'Country');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveCountry',$('#btn-country-save'), 'Country added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields</strong>', 'error')
        }

    });
});


var deleteCountry = function (id) {
    page.get('/DeleteCountry?id=' + id).then(function () {
        notify('Country deleted', 'success');
        done();
    });
}

var done = function () {
    location.reload();
}
