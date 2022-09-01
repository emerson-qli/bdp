var page                                            = new Page("/Organization/Profile");
var accessibleDepartments                           = [];
var accessibleDepartmentsEdit                       = [];
var departmentIds                                   = [];

var $selectizeDocumentTypes                         = null;
var $selectizeDepartmentsAccessible                 = null;
var $selectizeDepartmentsResponsible                = null;
var $selectizeSubsidiaries                          = null;
var $selectizeMStype                                = null;

var $selectizeDocumentTypesEdit                     = null;
var $selectizeDepartmentsAccessibleEdit             = null;
var $selectizeDepartmentsResponsibleEdit            = null;
var $selectizeSubsidiariesEdit                      = null;
var $selectizeEditMStype                            = null;

var $selectizeDepartmentProcess                     = null;

var $selectizeInteractingDepartments                = null;

var $selectizeSubProcess                            = null;

var $selectizeCertificateDepartmentsResponsible     = null;
var $selectizeCertificateDepartmentsResponsibleEdit = null;

$(function () {

    loadDocumentTypes();
    loadDepartmentsAccessible();
    loadDepartmentsResponsible();
    loadSubsidiaries();
    loadMSType();

    loadEditDocumentTypes();
    loadEditDepartmentsAccessible();
    loadEditDepartmentsResponsible();
    loadEditSubsidiaries();
    loadEditMSType();

    loadDepartmentProcess();

    loadInteractingDepartments();

    loadSubProcess();

    loadCertificateDepartmentResponsible();
    loadCertificateDepartmentResponsibleEdit();

    $('#tbl-oc').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-policy').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-obligations #tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-certificates #tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('click', '#btn-select-all-department', function () {
        $selectizeDepartmentsAccessible[0].selectize.setValue(Object.keys($selectizeDepartmentsAccessible[0].selectize.options));
    });

    $(document).on('click', '#btn-clear-all-department', function () {
        $selectizeDepartmentsAccessible[0].selectize.setValue([]);
    });

    $(document).on('click', '#btn-edit-select-all-department', function () {
        $selectizeDepartmentsAccessibleEdit[0].selectize.setValue(Object.keys($selectizeDepartmentsAccessibleEdit[0].selectize.options));
    });

    $(document).on('click', '#btn-edit-clear-all-department', function () {
        $selectizeDepartmentsAccessibleEdit[0].selectize.setValue([]);
    });

    $(document).on('click', '#btn-add-obligation', function () {
        $('#mdl-new-obligation').modal('show');
    });


    $(document).on('click', '.btn-certificate-upload', function () {
        $('#mdl-new-certificate').modal('hide');
        $('#mdl-new-certificate-file-upload').modal('show');
    });

    $(document).on('change', '#fle-new-certificate-file-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-new-certificate-file-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-new-certificate-file-upload').val('');
                $("#file-new-certificate-upload-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#mdl-new-certificate-file-upload').modal('hide');
                notify('File uploaded', 'success');
                $('#fld-certificate-file-name').val(file.Item3);
                $('#fld-certificate-original-file-name').val(file.Item1);
                $('#mdl-new-certificate').modal('show');

                $('.lbl-certificate-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-new-certificate-upload-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-new-certificate-upload-progress").attr({
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
                $("#file-uploadphoto-progress").attr({
                    value: 0,
                    max: 100
                });
                notify('File uploaded', 'success');
                $('#fld-oc-file-name').val(file.Item3);
                $('#fld-oc-original-file-name').val(file.Item1);
                $('.lbl-oc-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-uploadphoto-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-uploadphoto-progress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                            $("#file-uploadphoto-progress").hide();
                        }
                    }, false);
                }
                return fileXhr;
            }
        });

    });

    $(document).on('click', '#btn-upload-org-chart', function () {
        $('#mdl-new-oc-upload').modal('show');
    });

    $(document).on('click', '#btn-new-oc-upload-save', function () {
        var validation = page.validate('#bdy-new-oc-upload', 'OrganizationChart');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveOrganizationalChart', $('#btn-new-oc-upload-save'), 'File uploaded', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });

    $(document).on('click', '.btn-edit-certificate-upload', function () {
        $('#mdl-edit-certificate').modal('hide');
        $('#mdl-edit-certificate-file-upload').modal('show');
    });

    $(document).on('change', '#fle-edit-certificate-file-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-edit-certificate-file-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-edit-certificate-file-upload').val('');
                $("#file-edit-certificate-upload-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#mdl-edit-certificate-file-upload').modal('hide');
                notify('File uploaded', 'success');
                $('#fld-edit-certificate-file-name').val(file.Item3);
                $('#fld-edit-certificate-original-file-name').val(file.Item1);
                $('#mdl-edit-certificate').modal('show');

                $('.lbl-edit-certificate-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-edit-certificate-upload-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-edit-certificate-upload-progress").attr({
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

    $(document).on('click', '.btn-obligation-upload', function () {
        $('#mdl-new-obligation').modal('hide');
        $('#mdl-new-obligation-file-upload').modal('show');
    });

    $(document).on('change', '#fle-new-obligation-file-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-new-obligation-file-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-new-obligation-file-upload').val('');
                $("#file-new-obligation-upload-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#mdl-new-obligation-file-upload').modal('hide');
                notify('File uploaded', 'success');
                $('#fld-obligation-file-name').val(file.Item3);
                $('#fld-obligation-original-file-name').val(file.Item1);
                $('#mdl-new-obligation').modal('show');

                $('.lbl-obligation-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-new-obligation-upload-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-new-obligation-upload-progress").attr({
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

    $(document).on('click', '.btn-edit-obligation-upload', function () {
        $('#mdl-edit-obaligation').modal('hide');
        $('#mdl-edit-obligation-file-upload').modal('show');
    });

    $(document).on('change', '#fle-edit-obligation-file-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-edit-obligation-file-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-edit-obligation-file-upload').val('');
                $("#file-edit-obligation-upload-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#mdl-edit-obligation-file-upload').modal('hide');
                notify('File uploaded', 'success');
                $('#fld-edit-obligation-file-name').val(file.Item3);
                $('#fld-edit-obligation-original-file-name').val(file.Item1);
                $('#mdl-edit-obaligation').modal('show');

                $('.lbl-edit-obligation-file').html('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a>');
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-edit-obligation-upload-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-edit-obligation-upload-progress").attr({
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



    if (window.location.hash) {
        $("a[href='" + window.location.hash + "']").tab('show');
    } else {
        $("a[href='#nav-profile']").tab('show');
    }

    $(document).on('click', '.nav-item', function () {
        var hash = $(this).data('hash');
        if (hash) {
            location.href = '/Organization/Profile' + hash;
        }
    })

    $(document).on('click', '#btn-view-organization-profile', function () {
        var id = $(this).data('id');
        location.href = '/Organization/Profile/View/' + id;
    })

    $('.fld-editor').trumbowyg({
        btns: [['bold', 'italic'], ['link']]
    });

    $(document).on('click', '#btn-add-management-system', function () {
        $('#mdl-new-management-system').modal('show');
    });

    $(document).on('click', '#btn-add-subsidiary', function () {
        $('#mdl-new-subsidiary').modal('show');
    });

    $(document).on('click', '#btn-add-product', function () {
        $('#mdl-new-product').modal('show');
    });

    $(document).on('click', '#btn-add-service', function () {
        $('#mdl-new-service').modal('show');
    });

    $(document).on('click', '.btn-view-compliance', function () {
        var d = $(this).data('table');
        $('.btn-compliance').addClass('d-none');

        if (d == 'tbl-obligations') {
            $('#btn-obligations').addClass('btn-primary').removeClass('btn-outline-primary');
            $('#btn-certificates').addClass('btn-outline-primary').removeClass('btn-primary');

            $('#btn-add-obligation').removeClass('d-none');
        } else {
            $('#btn-obligations').addClass('btn-outline-primary').removeClass('btn-primary');
            $('#btn-certificates').addClass('btn-primary').removeClass('btn-outline-primary');

            $('#btn-add-certification').removeClass('d-none');
        }

        $('.tbl').addClass('d-none');
        $('#' + d).removeClass('d-none');
    });

    $(document).on('click', '.btn-upload', function () {
        $('#modal-file-upload').modal('show');
    });

    $(document).on('change', '#fle-file-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-file-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-file-upload').val('');
                $("#file-upload-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#modal-file-upload').modal('hide');
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

    $(document).on('click', '.btn-save-profile', function () {

        var validation = page.validate('.dv-profile', 'Organization');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveProfile', $('#btn-new-save'), 'Profile Saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-new-management-system-save', function () {

        var organizationId = $('#fld-profile-organization-id').val()

        var validation = page.validate('#bdy-new-management-system', 'OrganizationManagementSystem');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveManagementSystem', $('#btn-new-management-system-save'), 'Management System Saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

        

    });

    $(document).on('click', '.btn-delete-oc', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this file? ', deleteOrganizationChart, id);
        }
    });

    $(document).on('click', '.btn-delete-management-system', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this management system? ', deleteManagementSystem, id);
        }


    });

    $(document).on('click', '.btn-edit-management-system', function () {

        var id = $(this).data('id');
        page.get('/GetManagementSystem?id=' + id).then(function (data) {

            $('#mdl-edit-management-system').modal('show');
            $('#fld-edit-management-system-id').val(data.Id);
            $('#fld-edit-management-system-type').val(data.Type);
            $('#fld-edit-management-system-version').val(data.Version);
            $('#fld-edit-management-system-description').val(data.Description);

        });
    });

    $(document).on('click', '#btn-edit-management-system-save', function () {

        var validation = page.validate('#bdy-edit-management-system', 'OrganizationManagementSystem');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateManagementSystem', $('#btn-edit-management-system-save'), 'Management system updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-new-subsidiary-save', function () {

        var validation = page.validate('#bdy-new-subsidiary', 'OrganizationSubsidiary');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveSubsidiary', $('#btn-new-subsidiary-save'), 'Subsidiary Saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete-subsidiary', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this subsidiary? ', deleteSubsidiary, id);
        }
        

    });

    $(document).on('click', '.btn-edit-subsidiary', function () {

        var id = $(this).data('id');
        page.get('/GetSubsidiary?id=' + id).then(function (data) {

            $('#mdl-edit-subsidiary').modal('show');
            $('#fld-edit-subsidiary-id').val(data.Id);
            $('#fld-edit-subsidiary-name').val(data.Name);
            $('#fld-edit-subsidiary-address').val(data.Address);
            $('#fld-edit-description').val(data.Description);

        });
    });

    $(document).on('click', '#btn-edit-subsidiary-save', function () {

        var validation = page.validate('#bdy-edit-subsidiary', 'OrganizationSubsidiary');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateSubsidiary', $('#btn-edit-subsidiary-save'), 'Subsidiary updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-new-product-save', function () {

        var validation = page.validate('#bdy-new-product', 'OrganizationProduct');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveProduct', $('#btn-new-product-save'), 'Product Saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-product-save', function () {

        var validation = page.validate('#bdy-edit-product', 'OrganizationProduct');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateProduct', $('#btn-edit-product-save'), 'Product Updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete-product', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this product? ', deleteProduct, id);
        }

    });

    $(document).on('click', '.btn-edit-product', function () {

        var id = $(this).data('id');
        page.get('/GetProduct?id=' + id).then(function (data) {

            $('#mdl-edit-product').modal('show');
            $('#fld-edit-product-id').val(data.Id);
            $('#fld-edit-product-name').val(data.Name);
            $('#fld-edit-product-description').val(data.Description);

        });
    });

    $(document).on('click', '#btn-edit-subsidiary-save', function () {

        var validation = page.validate('#bdy-edit-subsidiary', 'OrganizationSubsidiary');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateSubsidiary', $('#btn-edit-subsidiary-save'), 'Subsidiary updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-new-service-save', function () {

        var validation = page.validate('#bdy-new-service', 'OrganizationService');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateService', $('#btn-new-service-save'), 'Service updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete-service', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this service? ', deleteService, id);
        }

    });

    $(document).on('click', '.btn-edit-service', function () {

        var id = $(this).data('id');
        page.get('/GetService?id=' + id).then(function (data) {

            $('#mdl-edit-service').modal('show');
            $('#fld-edit-service-id').val(data.Id);
            $('#fld-edit-service-name').val(data.Name);
            $('#fld-edit-service-description').val(data.Description);

        });
    });

    $(document).on('click', '#btn-edit-service-save', function () {

        var validation = page.validate('#bdy-edit-service', 'OrganizationService');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateService', $('#btn-edit-service-save'), 'Service updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-save-vision', function () {

        var validation = page.validate('.dv-vision', 'OrganizationVision');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveVision', $('#btn-save-vision'), 'Vision / Mission updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error');
        }

    });

    $(document).on('click', '#btn-add-value', function () {

        $('#mdl-new-value').modal('show');

    });

    $(document).on('click', '#btn-new-value-save', function () {

        var validation = page.validate('#bdy-new-value', 'OrganizationValue');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveValues', $('#btn-new-value-save'), 'Values saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error');
        }

    });

    $(document).on('click', '.btn-delete-value', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this values? ', deleteValue, id);
        }

    });

    $(document).on('click', '.btn-edit-value', function () {

        var id = $(this).data('id');
        page.get('/GetValue?id=' + id).then(function (data) {

            $('#mdl-edit-value').modal('show');
            $('#fld-edit-value-id').val(data.Id);
            $('#fld-edit-value-name').val(data.Name);
            $('#fld-edit-value-description').val(data.Description);

        });
    });

    $(document).on('click', '#btn-edit-value-save', function () {

        var validation = page.validate('#bdy-edit-value', 'OrganizationValue');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateValue', $('#btn-edit-value-save'), 'Value updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-new-obligation-save', function () {

        var validation = page.validateWithChild('#bdy-new-obligation', 'OrganizationCompliance', accessibleDepartments, 'AccessibleDepartments');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveOrganizationCompliance', $('#btn-new-obligation-save'), 'Organization compliance saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-edit-obligation', function () {

        var id = $(this).data('id');
        page.get('/GetOrganizationCompliance?id=' + id).then(function (data) {
            if ($selectizeDocumentTypesEdit != null) {
                $selectizeDocumentTypesEdit[0].selectize.setValue(' ');
            }

            if ($selectizeDepartmentsResponsibleEdit != null) {
                $selectizeDepartmentsResponsibleEdit[0].selectize.setValue(' ');
            }

            if ($selectizeDepartmentsAccessibleEdit != null) {
                $selectizeDepartmentsAccessibleEdit[0].selectize.setValue(' ');
            }

            if ($selectizeSubsidiariesEdit != null) {
                $selectizeSubsidiariesEdit[0].selectize.setValue(' ');

            }

            $('#mdl-edit-obaligation').modal('show');
            $('#fld-edit-obligation-id').val(data.Id);
            $('#fld-edit-obligation-name').val(data.Name);
            $('#fld-edit-obligation-issued-date').val(moment(data.IssuedDate).format('MM/DD/YYYY'));
            $('#fld-edit-obligation-expiration-date').val(moment(data.ExpirationDate).format('MM/DD/YYYY'));
            $('#fld-edit-obligation-issuing-authority').val(data.IssuingAuthority);

            $('#fld-selected-edit-document-type-name').val(data.DocumentTypeName);
            $('#fld-selected-edit-document-type-id').val(data.DocumentTypeId);

            $('#fld-selected-edit-department-name').val(data.ResponsibleDepartmentName);
            $('#fld-selected-edit-department-id').val(data.ResponsibleDepartmentId);

            $('#fld-selected-edit-subsidiary-name').val(data.SubsidiaryName);
            $('#fld-selected-edit-subsidiary-id').val(data.SubsidiaryId);

            departmentIds = [];
            for (var i = 0; i < data.AccessibleDepartments.length; i++) {
                departmentIds.push(data.AccessibleDepartments[i].DepartmentId);
            }

            $('#fld-edit-obligation-description').val(data.Description);
            $('#fld-edit-obligation-file-name').val(data.ObligationUniqueFileName);
            $('#fld-edit-obligation-original-file-name').val(data.ObligationOriginalFileName);

            $('.lbl-edit-obligation-file').html('<a target="_blank" href="/content/files/' + data.ObligationUniqueFileName + '">' + data.ObligationOriginalFileName + '</a>');
            $('#fld-edit-obligation-category').val(data.Category);
        });

    });

    $(document).on('click', '.btn-edit-certificate', function () {

        var id = $(this).data('id');
        page.get('/GetOrganizationComplianceCertificate?id=' + id).then(function (data) {
            
            if ($selectizeEditMStype != null) {
                $selectizeEditMStype[0].selectize.setValue(' ');
                $('#fld-edit-certificate-management-system-version').val(' ');
            }

            if ($selectizeCertificateDepartmentsResponsibleEdit != null) {
                $selectizeCertificateDepartmentsResponsibleEdit[0].selectize.setValue(' ');
            }
            
            $('#fld-edit-certificate-id').val(data.Id);
            $('#fld-edit-certificate-name').val(data.Name);
            $('#fld-edit-certificate-issued-date').val(moment(data.IssuedDate).format('MM/DD/YYYY'));
            $('#fld-edit-certificate-expiration-date').val(moment(data.ExpirationDate).format('MM/DD/YYYY'));
            $('#fld-edit-certificate-scope').val(data.Scope);

            $('#fld-edit-ms-type-name').val(data.ManagementSystemType);
            $('#fld-edit-ms-type-id').val(data.ManagementSystemId);
            $('#fld-selected-edit-department-name').val(data.ResponsibleDepartmentName);
            $('#fld-selected-edit-department-id').val(data.ResponsibleDepartmentId);

            $('#fld-edit-certificate-description').val(data.Description);
            $('#fld-edit-certificate-file-name').val(data.CertificateUniqueFileName);
            $('#fld-edit-certificate-original-file-name').val(data.CertificateOriginalFileName);

            $('.lbl-edit-certificate-file').html('<a target="_blank" href="/content/files/' + data.CertificateUniqueFileName + '">' + data.CertificateOriginalFileName + '</a>');
            $('#mdl-edit-certificate').modal('show');
        });

    });

    $(document).on('click', '#btn-edit-obligation-save', function () {

        var validation = page.validate('#bdy-edit-obligation', 'OrganizationCompliance');

        if (validation.Valid) {
            validation.Entity['OrganizationCompliance.AccessibleDepartments'] = accessibleDepartmentsEdit;
            page.save(validation.Entity, '/UpdateOrganizationCompliance', $('#btn-edit-obligation-save'), 'Organization compliance updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }


    });

    $(document).on('click', '.btn-delete-obligation', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this obligation? ', deleteObligation, id);
        }

    });

    $(document).on('click', '.btn-delete-certificate', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this certificate? ', deleteCertificate, id);
        }

    });

    $(document).on('click', '#btn-add-bpm', function () {

        $('#mdl-new-bpm').modal('show');

    });

    $(document).on('click', '#btn-new-bpm-save', function () {

        var validation = page.validate('#bdy-new-bpm', 'OrganizationBusinessProcess');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveOrganizationProcess', $('#btn-new-bpm-save'), 'Organization process save', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }


    });

    $(document).on('click', '.tr-bpm', function () {

        var id = $(this).data('id');

        $('.tr-bpm').removeClass('selected');
        $(this).addClass('selected');
        $('#tbl-bpm').removeClass('d-none');

        page.get('/GetOrganizationProcess?id=' + id).then(function (data) {
            $('#hdn-edit-bpm-id').val(data.Id);
            $('.td-process-name').html(data.Name);
            $('.td-department').html(data.DepartmentName);

            var htmlSteps = '';
            var d = _.sortBy(data.OrganizationBusinessProcessSteps, 'Order');

            for (var i = 0; i < d.length; i++) {
                htmlSteps += '<li>' + d[i].Name + '&nbsp; (' + d[i].Order + ')</li>';
            }

            $('.ul-steps').html(htmlSteps);

            var htmlDepartments = '';
            for (var i = 0; i < data.OrganizationBusinessProcessInteractingDepartments.length; i++) {
                htmlDepartments += '<div class="col-3">' +
                                        '<div class="card">' +
                                            '<div class="card-header">' +
                                                data.OrganizationBusinessProcessInteractingDepartments[i].DepartmentName +
                                            '</div>' +
                                        '</div>' +
                                    '</div>';
            }

            $('.dv-interacting-departments').html(htmlDepartments);

            var htmlSubProcess = '';
            for (var i = 0; i < data.SubProcesses.length; i++) {
                htmlSubProcess += '<li>' + data.SubProcesses[i].OrganizationBusinessProcessSubProcessName + '</li>';
            }

            $('.ul-sub-process').html(htmlSubProcess);

        });
    });

    $(document).on('click', '#btn-edit-bpm', function () {
        var id = $('#hdn-edit-bpm-id').val();

        page.get('/GetOrganizationProcess?id=' + id).then(function (data) {
            $('#mdl-edit-bpm').modal('show');
            $('#fld-edit-bpm-name').val(data.Name);
            $('#fld-edit-bpm-id').val(data.Id);
        });

    });

    $(document).on('click', '#btn-edit-bpm-save', function () {

        var validation = page.validate('#bdy-edit-bpm', 'OrganizationBusinessProcess');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateOrganizationProcess', $('#btn-edit-bpm-save'), 'Organization process updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-bpm-department', function () {
        var id = $('#hdn-edit-bpm-id').val();

        page.get('/GetOrganizationProcess?id=' + id).then(function (data) {
            $('#mdl-edit-bpm-department').modal('show');
            $('#fld-edit-department-bpm-id').val(data.Id);
            if ($selectizeDepartmentProcess != null) {
                $selectizeDepartmentProcess[0].selectize.setValue(data.DepartmentId);
                $('#fld-edit-department-name').val(data.DepartmentName);
                $('#fld-edit-department-id').val(data.DepartmentId);
            }
        });

    });

    $(document).on('click', '#btn-edit-department-bpm-save', function () {

        var validation = page.validate('#bdy-edit-department-bpm', 'OrganizationBusinessProcess');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateOrganizationProcessDepartment', $('#btn-edit-department-bpm-save'), 'Organization process updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-bpm-steps', function () {

        var id = $('#hdn-edit-bpm-id').val();
        $('#mdl-edit-bpm-steps').modal('show');

        page.get('/GetOrganizationProcess?id=' + id).then(function (data) {
            $('#fld-edit-step-bpm-id').val(id);

            populateSteps(data);

        });


    });

    $(document).on('click', '.btn-save-step', function () {

        var validation = page.validate('#bdy-edit-step-bpm', 'OrganizationBusinessProcessStep');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveStep', $('.btn-save-step'), 'Organization process step added', 'Save failed', refreshSteps);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete-step', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this step? ', deleteStep, id);
        }

    });

    $(document).on('click', '#btn-edit-bpm-interacting-department', function () {
        var id = $('#hdn-edit-bpm-id').val();
        $('#fld-edit-interacting-department-bpm-id').val(id);
        $('#mdl-edit-bpm-interacting-department').modal('show');
        page.get('/GetOrganizationProcess?id=' + id).then(function (data) {
            populateInteractingDepartments(data);

        });
    });

    $(document).on('click', '.btn-save-interacting-department', function () {

        var validation = page.validate('#bdy-edit-interacting-department-bpm', 'OrganizationBusinessProcessInteractingDepartment');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveInteractingDepartment', $('.btn-save-interacting-department'), 'Interacting department saved', 'Save failed', refreshID);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-bpm-sub-process', function () {

        var id = $('#hdn-edit-bpm-id').val();
        $('#fld-edit-sub-process-bpm-id').val(id);
        $('#mdl-edit-bpm-sub-process').modal('show');
        page.get('/GetAllSubProcess?id=' + id).then(function (data) {

            populateSubProcess(data);

        });

    });

    $(document).on('click', '.btn-save-sub-process', function () {

        var validation = page.validate('#bdy-edit-sub-process-bpm', 'OrganizationBusinessProcessSubProcess');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveSubProcess', $('.btn-save-sub-process'), 'Sub process added', 'Save failed', refreshSubProcess);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete-sub-process', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this subprocess? ', deleteSubProcess, id);
        }

    });


    $(document).on('click', '.btn-delete-department', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this department? ', deleteDepartment, id);
        }

    });

    $(document).on('click', '#btn-add-certification', function () {

        $('#mdl-new-certificate').modal('show');

    });

    $(document).on('click', '#btn-new-certificate-save', function () {

        var validation = page.validate('#bdy-new-certificate', 'OrganizationComplianceCertificate');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveOrganizationComplianceCertificate', $('#btn-new-certificate-save'), 'Certificate added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-certificate-save', function () {

        var validation = page.validate('#bdy-edit-certificate', 'OrganizationComplianceCertificate');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateOrganizationComplianceCertificate', $('#btn-edit-certificate-save'), 'Certificate added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-new-policy', function () {
        $('#mdl-new-policy').modal('show');
    });

    $(document).on('click', '#btn-new-policy-save', function () {
        var validation = page.validate('#bdy-new-policy', 'OrganizationPolicy');

        if (validation.Valid) {
            page.save(validation.Entity, '/SavePolicy', $('#btn-new-policy-save'), 'Info added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });

    $(document).on('click', '.btn-edit-policy', function () {
        var id = $(this).data('id');

        page.get('/GetPolicy?id=' + id).then(function (data) {
            $('#fld-edit-policy-id').val(data.Id);
            $('#fld-edit-policy-name').val(data.Name);
            $('#fld-edit-policy-description').val(data.Description);
           

            $('#mdl-edit-policy').modal('show');
        });

    });

    $(document).on('click', '#btn-edit-policy-save', function () {
        var validation = page.validate('#bdy-edit-policy', 'OrganizationPolicy');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdatePolicy', $('#btn-edit-policy-save'), 'Info updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });

    $(document).on('click', '.btn-delete-policy', function () {
        if ($('#fld-permission-delete').val() == 'Denied') {
            noPermissionAlert();
        } else {
            var id = $(this).data('id');
            showConfirm('Are you sure you want to delete this info? ', deletePolicy, id);
        }

    });

    $('#mdl-edit-obaligation').on('shown.bs.modal', function () {
        var documentTypeId          = $('#fld-selected-edit-document-type-id').val();
        var responsibleDepartmentId = $('#fld-selected-edit-department-id').val();
        var subsidiaryId            = $('#fld-selected-edit-subsidiary-id').val();


        setTimeout(
            function () {
                if ($selectizeDocumentTypesEdit != null) {
                    $selectizeDocumentTypesEdit[0].selectize.setValue(documentTypeId);
                }

                if ($selectizeDepartmentsResponsibleEdit != null) {
                    $selectizeDepartmentsResponsibleEdit[0].selectize.setValue(responsibleDepartmentId);
                }

                if ($selectizeDepartmentsAccessibleEdit != null) {
                    $selectizeDepartmentsAccessibleEdit[0].selectize.setValue(departmentIds);
                }

                if ($selectizeSubsidiariesEdit != null) {
                    $selectizeSubsidiariesEdit[0].selectize.setValue(subsidiaryId);
                    
                }
            }, 1500);
    });

    $('#mdl-edit-certificate').on('shown.bs.modal', function () {
        var mstypeId                = $('#fld-edit-ms-type-id').val();
        var responsibleDepartmentId = $('#fld-selected-edit-department-id').val();

        setTimeout(
            function () {
                if ($selectizeEditMStype != null) {
                    $selectizeEditMStype[0].selectize.setValue(mstypeId);
                }

                if ($selectizeCertificateDepartmentsResponsibleEdit != null) {
                    $selectizeCertificateDepartmentsResponsibleEdit[0].selectize.setValue(responsibleDepartmentId);
                }
            }, 1000);
    });

});

var deletePolicy = function (id) {

    page.get('/DeletePolicy?id=' + id).then(function () {
        notify('Info deleted', 'success');
        $('#mdl-confirm').modal('hide');
        done();
    });

}

var deleteDepartment = function (id) {

    page.get('/DeleteInteractingDepartment?id=' + id).then(function () {
        notify('Department deleted', 'success');
        $('#mdl-confirm').modal('hide');
        refreshID();
    });

}


var deleteSubProcess = function (id) {

    page.get('/DeleteSubProcess?id=' + id).then(function () {
        notify('Subprocess deleted', 'success');
        $('#mdl-confirm').modal('hide');
        refreshSubProcess();
    });

}

var refreshSubProcess = function () {

    var id = $('#hdn-edit-bpm-id').val();

    $('#fld-edit-sub-process-id').val('');
    $('#fld-edit-sub-process-name').val('');

    if ($selectizeSubProcess != null) {
        $selectizeSubProcess[0].selectize.setValue('');
    }

    page.get('/GetAllSubProcess?id=' + id).then(function (data) {
        $('#fld-edit-sub-process-bpm-id').val(id);
        populateSubProcess(data);

    });

}

var deleteStep = function (id) {

    page.get('/DeleteStep?id=' + id).then(function () {
        notify('Step deleted', 'success');
        $('#mdl-confirm').modal('hide');
        refreshSteps();
    });

}

var refreshSteps = function () {

    var id = $('#hdn-edit-bpm-id').val();

    $('#fld-edit-department-step-name').val('');
    $('#fld-edit-department-step-order').val('');



    page.get('/GetOrganizationProcess?id=' + id).then(function (data) {
        $('#fld-edit-step-bpm-id').val(id);
        populateSteps(data);

    });

}

var refreshID = function () {
    var id = $('#hdn-edit-bpm-id').val();

    if ($selectizeInteractingDepartments != null) {
        $selectizeInteractingDepartments[0].selectize.setValue('');
    }

    page.get('/GetOrganizationProcess?id=' + id).then(function (data) {
        populateInteractingDepartments(data);

    });
}

var populateSteps = function (data) {

    var htmlSteps = '';
    var htmlTr = '';

    var d = _.sortBy(data.OrganizationBusinessProcessSteps, 'Order');

    for (var i = 0; i < d.length; i++) {
        htmlSteps += '<li>' + d[i].Name + '&nbsp; (' + d[i].Order + ')</li>';
        htmlTr += '<tr>' +
                        '<td class="align-middle">' + d[i].Name + '</td>' +
                        '<td class="align-middle w-10 text-center">' + d[i].Order + '</td>' +
                        '<td class="w-10">' +
                            '<div class="btn-group" role="group">' +
                                '<a href="javascript:void(0);" class="btn btn-sm btn-danger btn-delete-step" data-id="' + d[i].Id + '" title="Delete"><i class="fa fa-trash"></i></a>' +
                            '</div>' +
                        '</td>' +
                    '</tr>';
    }

    $('.tbl-steps').html(htmlTr);
    $('.ul-steps').html(htmlSteps);

}

var populateInteractingDepartments = function (data) {

    var htmlDepartments = '';
    var htmlTr          = '';

    var d = data.OrganizationBusinessProcessInteractingDepartments;

    for (var i = 0; i < d.length; i++) {

        htmlDepartments += '<div class="col-3">' +
                                '<div class="card">' +
                                    '<div class="card-header">' +
                                        d[i].DepartmentName +
                                    '</div>' +
                                '</div>' +
                            '</div>';

        htmlTr += '<tr>' +
                        '<td class="align-middle">' + d[i].DepartmentName + '</td>' +
                        '<td class="w-10">' +
                            '<div class="btn-group" role="group">' +
                                '<a href="javascript:void(0);" class="btn btn-sm btn-danger btn-delete-department" data-id="' + d[i].Id + '" title="Delete"><i class="fa fa-trash"></i></a>' +
                            '</div>' +
                        '</td>' +
                    '</tr>';
    }

    $('.tbl-interacting-departments').html(htmlTr);
    $('.dv-interacting-departments').html(htmlDepartments);

}

var populateSubProcess = function (data) {

    var htmlSubProcess  = '';
    var htmlTr = '';

    for (var i = 0; i < data.length; i++) {
        htmlSubProcess += '<li>' + data[i].OrganizationBusinessProcessSubProcessName + '</li>';
        htmlTr += '<tr>' +
                        '<td class="align-middle">' + data[i].OrganizationBusinessProcessSubProcessName + '</td>' +
                        '<td class="w-10">' +
                            '<div class="btn-group" role="group">' +
                                '<a href="javascript:void(0);" class="btn btn-sm btn-danger btn-delete-sub-process" data-id="' + data[i].Id + '" title="Delete"><i class="fa fa-trash"></i></a>' +
                            '</div>' +
                        '</td>' +
                    '</tr>';
    }

    $('.tbl-sub-process').html(htmlTr);
    $('.ul-sub-process').html(htmlSubProcess);

}


var loadDocumentTypes = function () {
    if ($selectizeDocumentTypes != null) {
        return;
    }

    $selectizeDocumentTypes = $('.fld-document-types').selectize({
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
                url: '/Setting/DocumentTypes/GetAll',
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
                $('#fld-selected-document-type-name').val(item.Name);
                $('#fld-selected-document-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadDepartmentsResponsible = function () {
    if ($selectizeDepartmentsResponsible != null) {
        return;
    }

    $selectizeDepartmentsResponsible = $('.fld-department-responsible').selectize({
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
                $('#fld-selected-department-name').val(item.Name);
                $('#fld-selected-department-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadDepartmentsAccessible = function () {
    if ($selectizeDepartmentsAccessible != null) {
        return;
    }

    $selectizeDepartmentsAccessible = $('.fld-department-accessible').selectize({
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
            accessibleDepartments = [];

            for (var i = 0; i < value.length; i++) {
                accessibleDepartments.push({
                    'DepartmentId': value[i]
                });
            }

        },
    });
}

var loadSubsidiaries = function () {
    var id = $('#fld-profile-organization-id').val();

    if ($selectizeSubsidiaries != null) {
        return;
    }

    $selectizeSubsidiaries = $('.fld-subsidiaries').selectize({
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
                url: '/Organization/Profile/GetAllSubsidiaries/' + id,
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
                $('#fld-selected-subsidiary-name').val(item.Name);
                $('#fld-selected-subsidiary-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadEditDocumentTypes = function () {

    if ($selectizeDocumentTypesEdit != null) {
        return;
    }

    $selectizeDocumentTypesEdit = $('.fld-edit-document-types').selectize({
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
                url: '/Setting/DocumentTypes/GetAll',
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
                $('#fld-selected-edit-document-type-name').val(item.Name);
                $('#fld-selected-edit-document-type-id').val(item.Id);
            } else {
            }

        },
    });

}

var loadEditDepartmentsAccessible = function () {
    if ($selectizeDepartmentsAccessibleEdit != null) {
        return;
    }

    $selectizeDepartmentsAccessibleEdit = $('.fld-edit-department-accessible').selectize({
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
            accessibleDepartmentsEdit = [];
            var id = $('#fld-edit-obligation-id').val();
            for (var i = 0; i < value.length; i++) {
                accessibleDepartmentsEdit.push({
                    'OrganizationComplianceId'  : id,
                    'DepartmentId'              : value[i]
                });
            }

        },
    });
}

var loadEditDepartmentsResponsible = function () {
    if ($selectizeDepartmentsResponsibleEdit != null) {
        return;
    }

    $selectizeDepartmentsResponsibleEdit = $('.fld-edit-department-responsible').selectize({
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
                $('#fld-selected-edit-department-name').val(item.Name);
                $('#fld-selected-edit-department-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadEditSubsidiaries = function () {
    var id = $('#fld-profile-organization-id').val();

    if ($selectizeSubsidiariesEdit != null) {
        return;
    }

    $selectizeSubsidiariesEdit = $('.fld-edit-subsidiaries').selectize({
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
                url: '/Organization/Profile/GetAllSubsidiaries/' + id,
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
                $('#fld-selected-edit-subsidiary-name').val(item.Name);
                $('#fld-selected-edit-subsidiary-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadInteractingDepartments = function () {
    if ($selectizeInteractingDepartments != null) {
        return;
    }

    $selectizeInteractingDepartments = $('.fld-interacting-departments').selectize({
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
                $('#fld-edit-interacting-department-name').val(item.Name);
                $('#fld-edit-interacting-department-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadDepartmentProcess = function () {
    if ($selectizeDepartmentProcess != null) {
        return;
    }

    $selectizeDepartmentProcess = $('.fld-edit-departments').selectize({
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
                $('#fld-edit-department-process-name').val(item.Name);
                $('#fld-edit-department-process-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadSubProcess = function () {
    if ($selectizeSubProcess != null) {
        return;
    }

    $selectizeSubProcess = $('.fld-sub-process').selectize({
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
                url: '/Organization/Profile/GetAllBusinessProcess',
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
                $('#fld-edit-sub-process-name').val(item.Name);
                $('#fld-edit-sub-process-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadCertificateDepartmentResponsible = function () {
    if ($selectizeCertificateDepartmentsResponsible != null) {
        return;
    }

    $selectizeCertificateDepartmentsResponsible = $('.fld-certificate-department-responsible').selectize({
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
                $('#fld-selected-certificate-department-name').val(item.Name);
                $('#fld-selected-certificate-department-id').val(item.Id);
            } else {
            }

        },
    });
}


var loadCertificateDepartmentResponsibleEdit = function () {
    if ($selectizeCertificateDepartmentsResponsibleEdit != null) {
        return;
    }

    $selectizeCertificateDepartmentsResponsibleEdit = $('.fld-edit-certificate-department-responsible').selectize({
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
                $('#fld-selected-edit-certificate-department-name').val(item.Name);
                $('#fld-selected-edit-certificate-department-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadMSType = function () {

    if ($selectizeMStype != null) {
        return;
    }

    $selectizeMStype = $('.fld-ms-types').selectize({
        valueField: 'Id',
        searchField: 'Type',
        labelField: 'Type',
        preload: true,
        create: true,
        sortField: {
            field: 'Type',
            direction: 'asc'
        }, render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Type) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Type) + '</div>'
                    + '</div>';
            }
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Organization/Profile/GetAllManagementSystem',
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
                $('#fld-new-ms-type-id').val(item.Id);
                $('#fld-new-ms-type-name').val(item.Type);
                $('#fld-new-certificate-management-system-version').val(item.Version);
            } else {
            }

        },
    });
}

var loadEditMSType = function () {

    if ($selectizeEditMStype != null) {
        return;
    }

    $selectizeEditMStype = $('.fld-edit-ms-types').selectize({
        valueField: 'Id',
        searchField: 'Type',
        labelField: 'Type',
        preload: true,
        create: true,
        sortField: {
            field: 'Type',
            direction: 'asc'
        }, render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Type) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Type) + '</div>'
                    + '</div>';
            }
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Organization/Profile/GetAllManagementSystem',
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
                $('#fld-edit-ms-type-id').val(item.Id);
                $('#fld-edit-ms-type-name').val(item.Type);
                $('#fld-edit-certificate-management-system-version').val(item.Version);
            } else {
            }

        },
    });
}

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteManagementSystem = function (id) {

    page.get('/DeleteManagementSystem?id=' + id).then(function () {
        notify('Management system deleted', 'success');
        done();
    });

}

var deleteOrganizationChart = function (id) {

    page.get('/DeleteOrganizationChart?id=' + id).then(function () {
        notify('Organization chart deleted', 'success');
        done();
    });

}


var deleteSubsidiary = function (id) {

    page.get('/DeleteSubsidiary?id=' + id).then(function () {
        notify('Subsidiary deleted', 'success');
        done();
    });

}

var deleteProduct = function (id) {

    page.get('/DeleteProduct?id=' + id).then(function () {
        notify('Product deleted', 'success');
        done();
    });

}

var deleteService = function (id) {

    page.get('/DeleteService?id=' + id).then(function () {
        notify('Service deleted', 'success');
        done();
    });

}

var deleteValue = function (id) {

    page.get('/DeleteValue?id=' + id).then(function () {
        notify('Value deleted', 'success');
        done();
    });

}


var deleteObligation = function (id) {

    page.get('/DeleteOrganizationCompliance?id=' + id).then(function () {
        notify('Obligation deleted', 'success');
        done();
    });

}

var deleteCertificate = function (id) {

    page.get('/DeleteOrganizationComplianceCertificate?id=' + id).then(function () {
        notify('Certificate deleted', 'success');
        done();
    });

}

var noPermissionAlert = function () {
    $('#mdl-permission').modal('show');
    $('#mdl-permission').find('.p-message').html('You have no permission to delete, please contact the administrator');
}


