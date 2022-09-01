var page                    = new Page("/HumanCapital/Departments");
var $selectizeLevels        = null;
var $selectizeEmployees     = null;
var $selectizeDivisions     = null;
var $selectizeLevelsEdit    = null;
var $selectizeEmployeesEdit = null;
var $selectizeDivisionsEdit = null;

$(function () {
    loadLevelsEdit();
    loadDivisionsEdit();
    loadEmployeesEdit();

    loadLevels();
    loadEmployees();
    loadDivisions();

   

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
        showConfirm('Are you sure you want to delete this department? ', deleteDepartment, id);

    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'Department');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Department Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-edit', function () {
        var id = $(this).data('id');

        page.get('/Get?id=' + id).then(function (data) {

            if ($selectizeDivisionsEdit != null) {
                $selectizeDivisionsEdit[0].selectize.setValue(' ');
            }

            if ($selectizeEmployeesEdit != null) {
                $selectizeEmployeesEdit[0].selectize.setValue(' ');
            }

            if ($selectizeLevelsEdit != null) {
                $selectizeLevelsEdit[0].selectize.setValue(' ');
            }

            $('#fld-edit-selected-division-name').val(data.DivisionName);
            $('#fld-edit-selected-division-id').val(data.DivisionId);

            $('#fld-edit-selected-hod-name').val(data.HeadName);
            $('#fld-edit-selected-hod-id').val(data.HeadId);

            $('#fld-edit-selected-level-name').val(data.LevelName);
            $('#fld-edit-selected-level-id').val(data.LevelId);

            $('#fld-edit-divisions').val(data.DivisionName);
            $('#fld-edit-process-code').val(data.ProcessCode);
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-description').val(data.Description);
            $('#fld-edit-code').val(data.Code);
            $('#fld-edit-id').val(data.Id);
            $('#mdl-edit').modal('show');



        });
    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'Department');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Department updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });


    $('#mdl-edit').on('shown.bs.modal', function () {

        var divisionId  = $('#fld-edit-selected-division-id').val();
        var headId      = $('#fld-edit-selected-hod-id').val();
        var levelId     = $('#fld-edit-selected-level-id').val();

        setTimeout(
            function () {
                if ($selectizeDivisionsEdit != null) {
                    $selectizeDivisionsEdit[0].selectize.setValue(divisionId);
                }

                if ($selectizeEmployeesEdit != null) {
                    $selectizeEmployeesEdit[0].selectize.setValue(headId);
                }

                if ($selectizeLevelsEdit != null) {
                    $selectizeLevelsEdit[0].selectize.setValue(levelId);
                }
            }, 1000);
    });
   

});

var loadLevels = function () {
    if ($selectizeLevels != null) {
        return;
    }

    $selectizeLevels = $('.fld-levels').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "Levels",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
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
                $('#fld-selected-level-name').val(item.Name);
                $('#fld-selected-level-id').val(item.Id);
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
            field: 'Name',
            direction: 'asc'
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
                $('#fld-edit-selected-level-name').val(item.Name);
                $('#fld-edit-selected-level-id').val(item.Id);
            } else {

            }

        },
    });
}


var loadEmployees = function () {
    if ($selectizeEmployees != null) {
        return;
    }

    $selectizeEmployees = $('.fld-hods').selectize({
        valueField: 'Id',
        searchField: 'Fullname',
        labelField: 'Fullname',
        placeholder: "Employees",
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/HumanCapital/Employees/GetAll',
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
                $('#fld-selected-hod-name').val(item.Fullname);
                $('#fld-selected-hod-id').val(item.Id);
            } else {
            }

        },
    });

}


var loadEmployeesEdit = function () {
    if ($selectizeEmployeesEdit != null) {
        return;
    }


    $selectizeEmployeesEdit = $('.fld-edit-hods').selectize({
        valueField: 'Id',
        searchField: 'Fullname',
        labelField: 'Fullname',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/HumanCapital/Employees/GetAll',
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
                $('#fld-edit-selected-hod-name').val(item.Fullname);
                $('#fld-edit-selected-hod-id').val(item.Id);
            } else {

            }

        },
    });
}

var loadDivisions = function () {
    if ($selectizeDivisions != null) {
        return;
    }
    

    $selectizeDivisions = $('.fld-divisions').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "Divisions",
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/HumanCapital/Divisions/GetAll',
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
                $('#fld-selected-division-name').val(item.Name);
                $('#fld-selected-division-id').val(item.Id);
            } else {
            }

        },
    });

}

var loadDivisionsEdit = function () {
    if ($selectizeDivisionsEdit != null) {
        return;
    }

    $selectizeDivisionsEdit = $('.fld-edit-divisions').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/HumanCapital/Divisions/GetAll',
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
                $('#fld-edit-selected-division-name').val(item.Name);
                $('#fld-edit-selected-division-id').val(item.Id);
            } else {

            }

        },
    });
}

var deleteDepartment = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Department deleted', 'success');
        done();
    });

}



var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}