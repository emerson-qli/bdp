var page                            = new Page("/HumanCapital/Employees");
var $selectizeCompetencyTypes       = null;
var $selectizeEditCompetencyTypes   = null;

$(function () {

    loadCompetencyTypes();
    loadCompetencyEditTypes();

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
        page.get('/GetCompetency?id=' + id).then(function (data) {
            $('#fld-edit-id').val(data.Id);
            $('#mdl-edit').modal('show');
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-training-provider').val(data.Provider);
            $('#fld-edit-training-start-date').val(moment(data.TrainingStartDate).format('MM/DD/YYYY')); 
            $('#fld-edit-training-end-date').val(moment(data.TrainingEndDate).format('MM/DD/YYYY'));
            $('#fld-edit-description').val(data.Description);
            $('#fld-edit-user-proficiency').val(data.UserProficiency);
            $('#fld-edit-proficiency').val(data.Proficiency);

            if ($selectizeEditCompetencyTypes != null) {
                $selectizeEditCompetencyTypes[0].selectize.setValue(data.CompetencyTypeId);
                $('#fld-selected-edit-comptency-type-name').val(data.CompetencyTypeName);
                $('#fld-selected-edit-comptency-type-id').val(data.CompetencyTypeId);
            }
        });
    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'EmployeeCompetency');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveCompetency', $('#btn-new-save'), 'Training Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this competency? ', deleteCompetency, id);
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'EmployeeCompetency');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateCompetency', $('#btn-edit-save'), 'Competency updated', 'Update failed', done);
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

var deleteCompetency = function (id) {

    page.get('/DeleteCompetency?id=' + id).then(function () {
        notify('Training deleted', 'success');
        done();
    });

}

var loadCompetencyTypes = function () {

    if ($selectizeCompetencyTypes != null) {
        return;
    }

    $selectizeCompetencyTypes = $('.fld-competency-types').selectize({
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
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/CompetencyTypes/GetAll',
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
                $('#fld-selected-comptency-type-name').val(item.Name);
                $('#fld-selected-comptency-type-id').val(item.Id);
            } else {
            }

        },
    });

}

var loadCompetencyEditTypes = function () {

    if ($selectizeEditCompetencyTypes != null) {
        return;
    }

    $selectizeEditCompetencyTypes = $('.fld-edit-competency-types').selectize({
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
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/CompetencyTypes/GetAll',
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
                $('#fld-selected-edit-comptency-type-name').val(item.Name);
                $('#fld-selected-edit-comptency-type-id').val(item.Id);
            } else {
            }

        },
    });

}

var noPermissionAlert = function () {
    $('#mdl-permission').modal('show');
    $('#mdl-permission').find('.p-message').html('You have no permission to delete, please contact the administrator');
}