var page = new Page("/Setting/Levels");

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

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this level? ', deleteLevel, id);

    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'Level');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Level Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/Get?id=' + id).then(function (data) {
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-order').val(data.Order);
            $('#fld-edit-id').val(data.Id);
            $('#mdl-edit').modal('show');
        });
    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'Level');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Level updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });





});

var deleteLevel = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Level deleted', 'success');
        done();
    });

}



var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}