var page = new Page("/System/Users");

var $selectizeEditRole = null;

$(function () {

    loadEditRole();

    $('#tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('click', '.btn-edit', function () {
        var id = $(this).data('id');
        page.get('/Get?id=' + id).then(function (data) {
            if ($selectizeEditRole != null) {
                $selectizeEditRole[0].selectize.setValue(data.RoleId);
                $('#fld-edit-selected-role').val(data.RoleName);
            }
            $('#fld-edit-user').text(data.EmployeeName);
            $('#fld-edit-id').val(data.UserId);
            $('#fld-edit-email').val(data.Email);
            $('#fld-edit-selected-role').val(data.RoleId);
            $('#mdl-edit').modal('show');
            
        });
        
    });

    $(document).on('click', '#btn-edit-save', function () {

        var validation = page.validate('#bdy-edit', 'User');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'User Updated', 'Update failed', done);
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

var loadEditRole = function () {
    if ($selectizeEditRole != null) {
        return;
    }

    $selectizeEditRole = $('.fld-edit-role').selectize({
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
                url: '/System/Users/GetAllRoles',
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
                $('#fld-edit-selected-role').val(item.Id);
                
            } else {

            }

        },
    });
}