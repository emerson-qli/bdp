var page = new Page("/Setting/Ratings");

$(function () {

    $('#dv-new-color-picker').colorpicker();
    $('#dv-edit-color-picker').colorpicker();

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
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-description').val(data.Description);
            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-color').val(data.Color);
            $('#fld-edit-color-display').html('<i style="background-color:' + data.Color + '"></i>');
            $('#mdl-edit').modal('show');
        });
    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'Rating');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Rating Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this rating? ', deleteRating, id);

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'Rating');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Rating updated', 'Rating failed', done);
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

var deleteRating = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Rating deleted', 'success');
        done();
    });

}