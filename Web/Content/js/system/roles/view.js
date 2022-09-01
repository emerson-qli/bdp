var page = new Page("/System/Roles");



$(function () {
    var roleTemplate = [];
    var revokePermission = [];

    $('#tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('click', '#btn-grant-permissions', function () {
        if (roleTemplate != "") {
            $('#mdl-grant-permissions').modal('show');
        } else {
            notify('No flag selected for granting permissions', 'error');
        }
    });
    $(document).on('click', '#btn-revoke-permissions', function () {
        if (revokePermission != "") {
            $('#mdl-revoke-permissions').modal('show');
        } else {
            notify('No flag selected for revoking permissions', 'error');
        }
    });

    $(document).on('click', '#btn-new-grant-permissions', function () {
        page.save({ 'RoleTemplates': roleTemplate }, '/GrantPermissions', $('#btn-grant-permissions'), 'Permission Granted', 'Permission failed', done);
    });

    $(document).on('click', '#btn-remove-permissions', function () {
        for (var c = 0; c <= revokePermission.length; c++) {
            var id = revokePermission[c];
            page.get('/RevokePermissions?id=' + id)
            if (c == revokePermission.length) {
                notify('Resources Access Revoked', 'success');
                done();
            } 
        }
        
    });

    $(document).on('click', '.btn-grant', function () {
        var data = $(this).data();

        $('#fld-grant-role-application-element').val(data.applicationElement);
        $('#fld-grant-role-role-id').val(data.roleId);
        $('#mdl-new').modal('show');
    });

    $(document).on('click', '.btn-revoke', function () {
        var id = $(this).data('roleTemplateId');
        showConfirm('Are you sure you want to revoke this user access to this resource? ', revokeAccess, id);
    });

    $(document).on('click', '#btn-new-save', function () {
        var validation = page.validate('#bdy-new', 'RoleTemplate');

        if (validation.Valid) {
            page.save(validation.Entity, '/GrantPermission', $('#btn-new-save'), 'Permission Granted', 'Permission failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });


    $(document).on('click', '#btn-back', function () {
        location.href = "/System/Roles";
    });
    $(document).on('click', '.btn-revoke-role-permission', function () {
        $(this).removeClass('btn-revoke-role-permission');
        $(this).removeClass('btn-info');
        $(this).addClass('btn-cancel-revoke-role-permission');
        $(this).addClass('btn-secondary');

        var id = $(this).data('role-template-id');
        revokePermission.push(id);


    });
    $(document).on('click', '.btn-cancel-revoke-role-permission', function () {
        $(this).removeClass('btn-cancel-revoke-role-permission');
        $(this).removeClass('btn-secondary');
        $(this).addClass('btn-revoke-role-permission');
        $(this).addClass('btn-info');

        var id = $(this).data('role-template-id');
        revokePermission = $.grep(revokePermission, function (e) {
            return e != id;
        });

    });
    
    $(document).on('click', '#btn-role-permission', function () {
        $(this).attr('id', 'btn-remove-role-permission');
        $(this).removeClass('btn-secondary');
        $(this).addClass('btn-info');


        var name = $(this).data('role-permission-name');
        var id = $(this).data('role-id');
        var entity = {};
        entity['ApplicationElement'] = name;
        entity['RoleId'] = id;

        roleTemplate.push(entity);

    });
    $(document).on('click', '#btn-remove-role-permission', function () {
        $(this).attr('id', 'btn-role-permission');
        $(this).removeClass('btn-info');
        $(this).addClass('btn-role-permission');
        $(this).addClass('btn-secondary');

        var name = $(this).data('role-permission-name');

        tempRoleTemplate = roleTemplate.slice(0);
        tempRoleTemplate.forEach((element) => {
            if (name.includes(element['ApplicationElement'])) {
                var removeIndex = roleTemplate.map((item) => item['ApplicationElement']).indexOf(element['ApplicationElement']);
                roleTemplate.splice(removeIndex, 1);
            }
        });
    });
});

var revokeAccess = function (id) {
    page.get('/RevokePermission?roleTemplateId=' + id).then(function () {
        notify('Access Revoked', 'success');
        done();
    });
}


var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

