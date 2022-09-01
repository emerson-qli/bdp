var page = new Page("/Setting/Reviewers");

var $selectizeMembers       = null;
var $selectizeMembersEdit   = null;
var $selectizeRoles         = null;
var $selectizeRolesEdit     = null;

$(function () {

    loadMembers();
    loadMembersEdit();

    loadRoles();
    loadRolesEdit();

    $(document).on('click', '#btn-back', function () {

        location.href = '/Setting/Reviewers/';

    });

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
        page.get('/GetMember?id=' + id).then(function (data) {

            $('#fld-edit-id').val(data.Id);
            if ($selectizeMembersEdit != null) {
                $selectizeMembersEdit[0].selectize.setValue(data.EmployeeId);
                $('#fld-edit-employee-name').val(data.EmployeeName);
                $('#fld-edit-employee-id').val(data.EmployeeId);
            }
            if ($selectizeRolesEdit != null) {
                $selectizeRolesEdit[0].selectize.setValue(data.EmployeePosition);
                $('#fld-edit-employee-position').val(data.EmployeePosition);
            }
            $('#mdl-edit').modal('show');
        });
    });

    $(document).on('click', '#btn-new-save', function () {

        var validation = page.validate('#bdy-new', 'ReviewerMember');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveMember', $('#btn-new-save'), 'Reviewer member added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'ReviewerMember');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateMember', $('#btn-edit-save'), 'Reviewer member updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this member? ', deleteReviewerMember, id);

    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'ApprovingAuthorityMember');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateMember', $('#btn-edit-save'), 'Approving authority member updated', 'Update failed', done);
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

var deleteApproverMember = function (id) {

    page.get('/DeleteMember?id=' + id).then(function () {
        notify('Approver member deleted', 'success');
        done();
    });

}


var loadMembers = function () {
    if ($selectizeMembers != null) {
        return;
    }

    $selectizeMembers = $('.fld-new-members').selectize({
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
                $('#fld-new-employee-name').val(item.Fullname);
                $('#fld-new-employee-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadMembersEdit = function () {
    if ($selectizeMembersEdit != null) {
        return;
    }

    $selectizeMembersEdit = $('.fld-edit-members').selectize({
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
                $('#fld-edit-employee-name').val(item.Fullname);
                $('#fld-edit-employee-id').val(item.Id);
            } else {
            }

        },
    });
}



var loadRoles = function () {
    if ($selectizeRoles != null) {
        return;
    }

    $selectizeRoles = $('.fld-new-roles').selectize({
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
                $('#fld-new-employee-position').val(item.Name);
            } else {
            }

        },
    });
}

var loadRolesEdit = function () {
    if ($selectizeRolesEdit != null) {
        return;
    }

    $selectizeRolesEdit = $('.fld-edit-roles').selectize({
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
                $('#fld-edit-employee-position').val(item.Name);
            } else {
            }

        },
    });
}