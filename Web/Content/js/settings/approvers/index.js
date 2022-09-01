var page = new Page("/Setting/Approvers");

var $selectizeType              = null;
var $selectizeTypeEdit          = null;

var $selectizeDepartments       = null;
var $selectizeEditDepartments   = null;

var $selectizeLevels            = null;
var $selectizeLevelsEdit        = null;

$(function () {

    loadType();
    loadTypeEdit();

    loadDepartments();
    loadEditDepartments();

    loadLevels();
    loadLevelsEdit();

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

            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-name').val(data.GroupName);
            $('#fld-edit-description').val(data.Description);
            if ($selectizeTypeEdit != null) {
                $selectizeTypeEdit[0].selectize.setValue(data.Tag);
                $('#fld-edit-selected-type').val(data.Tag);
            }
            if ($selectizeLevelsEdit != null) {
                $selectizeLevelsEdit[0].selectize.setValue(data.LevelId);
                $('#fld-edit-level-id').val(data.LevelId);
                $('#fld-edit-level-name').val(data.LevelName);
                $('#fld-edit-level-order').val(data.LevelOrder);
            }
            if ($selectizeEditDepartments != null) {
                $selectizeEditDepartments[0].selectize.setValue(data.DepartmentId);
                $('#fld-edit-department-id').val(data.DepartmentId);
                $('#fld-edit-department-name').val(data.DepartmentName);
            }

            $('#mdl-edit').modal('show');
        });
    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'ApprovingAuthority');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Approving authority Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'ApprovingAuthority');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Approving authority Updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this approver? ', deleteApprover, id);

    });

    $(document).on('click', '.btn-view', function () {

        var id = $(this).data('id');
        location.href = '/Setting/Approvers/Members/' + id;

    });

});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteApprover = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Approver deleted', 'success');
        done();
    });

}

var loadType = function () {
    if ($selectizeType != null) {
        return;
    }

    $selectizeType = $('.fld-types').selectize({
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
                $('#fld-selected-type').val(item.Name);
            } else {
            }

        },
    });
}


var loadTypeEdit = function () {
    if ($selectizeTypeEdit != null) {
        return;
    }

    $selectizeTypeEdit = $('.fld-edit-types').selectize({
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
                $('#fld-edit-selected-type').val(item.Name);
            } else {
            }

        },
    });
}


var loadLevels = function () {
    if ($selectizeLevels != null) {
        return;
    }

    $selectizeLevels = $('.fld-levels').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Order',
            direction: 'desc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/Levels/GetAll',
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
                $('#fld-new-level-name').val(item.Name);
                $('#fld-new-level-id').val(item.Id);
                $('#fld-new-level-order').val(item.Order);
            } else {
            }

        },
    });
}

var loadLevelsEdit = function () {
    if ($selectizeLevelsEdit != null) {
        return;
    }

    $selectizeLevelsEdit = $('.fld-edit-levels').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Order',
            direction: 'desc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/Levels/GetAll',
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
                $('#fld-edit-level-name').val(item.Name);
                $('#fld-edit-level-id').val(item.Id);
                $('#fld-edit-level-order').val(item.Order);
            } else {
            }

        },
    });
}

var loadDepartments = function () {

    if ($selectizeDepartments != null) {
        return;
    }

    $selectizeDepartments = $('.fld-departments').selectize({
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
                url: '/HumanCapital/Departments/GetAll',
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
                $('#fld-department-id').val(item.Id);
                $('#fld-department-name').val(item.Name);
            } else {
            }

        },
    });

}

var loadEditDepartments = function () {

    if ($selectizeEditDepartments != null) {
        return;
    }

    $selectizeEditDepartments = $('.fld-edit-departments').selectize({
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
                url: '/HumanCapital/Departments/GetAll',
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
                $('#fld-edit-department-id').val(item.Id);
                $('#fld-editdepartment-name').val(item.Name);
            } else {
            }

        },
    });

}