var page                         = new Page("/HumanCapital/Employees");
var $selectizeContactDetails     = null;
var $selectizeEditContactDetails = null;

$(function () {

    loadContactDetails();
    loadContactEditDetails();

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

    $(document).on('click', '.btn-edit', function () {

        var id = $(this).data('id');
        page.get('/GetContactDetail?id=' + id).then(function (data) {
            $('#fld-edit-id').val(data.Id);
            $('#mdl-edit').modal('show');
            $('#fld-edit-contact').val(data.Contact);
            $('#selected-edit-contact-type').val(data.Label);
            $('#selected-edit-contact-emergency').val(data.Tag);

            if ($selectizeEditContactDetails != null) {
                $selectizeEditContactDetails[0].selectize.setValue(data.Label);
            }
        });
    });

    $(document).on('click', '.btn-delete', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this contact detail? ', deleteContactDetail, id);
        }

    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'EmployeeContactDetail');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveContactDetail', $('#btn-new-save'), 'Contact Detail Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'EmployeeContactDetail');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateContactDetail', $('#btn-edit-save'), 'Contact Detail updated', 'Update failed', done);
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

var deleteContactDetail = function (id) {

    page.get('/DeleteContactDetail?id=' + id).then(function () {
        notify('Contact detail deleted', 'success');
        done();
    });

}


var loadContactDetails = function () {

    if ($selectizeContactDetails != null) {
        return;
    }

    $selectizeContactDetails = $('.fld-contact-types').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {
                var tag = (item.Id == 'Emergency Contact Number') ? 1 : 0;
                $('#selected-contact-emergency').val(tag);
                $('#selected-contact-type').val(item.Id);
            } else {
            }

        },
    });

}


var loadContactEditDetails = function () {

    if ($selectizeEditContactDetails != null) {
        return;
    }

    $selectizeEditContactDetails = $('.fld-edit-contact-types').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {
                var tag = (item.Id == 'Emergency Contact Number') ? 1 : 0;
                $('#selected-edit-contact-emergency').val(tag);
                $('#selected-edit-contact-type').val(item.Id);
            } else {
            }

        },
    });

}

var noPermissionAlert = function () {
    $('#mdl-permission').modal('show');
    $('#mdl-permission').find('.p-message').html('You have no permission to delete, please contact the administrator');
}