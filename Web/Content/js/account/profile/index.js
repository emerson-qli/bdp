var page = new Page("/Account/Profile");
var $selectizeGender = null;

$(function () {
    loadGenders();

    $(document).on('change', '#fle-photo-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-photo-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-photo-upload').val('');
                $("#file-upload-progress").attr({
                    value: 0,
                    max: 100
                });
                notify('File uploaded', 'success');
                $('#fld-file-name').val(file.Item3);
                $('#fld-original-file-name').val(file.Item1);
                $('.lbl-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-upload-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-upload-progress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                        }
                    }, false);
                }
                return fileXhr;
            }
        });

    });

    $(document).on('click', '#btn-back', function () {
        location.href = '/HumanCapital/Employees/';
    });

    $(document).on('click', '#btn-update', function () {
        var validation = page.validate('.bdy-profile', 'Employee');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-update'), 'Profile updated!', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + '' + validation.Message.join('<br />'), 'error')
        }
    });

    $(document).on('click', '.btn-update-photo', function () {
        $('.lbl-file-uploaded').html('<a target="_blank" href="/content/files/"></a>');
        var id = $(this).data('id');
        page.get('/Get?id=' + id).then(function (data) {
            if (data.Photo != null && data.PhotoOriginalFileName != null) {
                $('.lbl-file-uploaded').html('<a target="_blank" href="/content/files/' + data.Photo + '">' + data.PhotoOriginalFileName + '</a>');
            }
            $('#fld-edit-photo-id').val(data.Id);
            $('#mdl-photo').modal('show');
        });
    });

    $(document).on('click', '#btn-new-photo-save', function () {

        var validation = page.validate('#bdy-update-photo', 'Employee');

        if (validation.Valid) {
            page.save(validation.Entity, '/UploadPhoto', $('#btn-new-photo-save'), 'Profile updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + '' + validation.Message.join('<br />'), 'error')
        }

    });
});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var loadGenders = function () {

    if ($selectizeGender != null) {
        return;
    }

    $selectizeGender = $('.fld-gender').selectize({
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
                $('#fld-edit-selected-gender').val(item.Name);
            } else {
            }

        },
    });
}