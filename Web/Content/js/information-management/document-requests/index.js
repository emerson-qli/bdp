
var page = new Page("/InformationManagement/DocumentRequests");

var $selectizeCategories                = null;
var $selectizeDocumentTypes             = null;
var $selectizeDocumentControlNumber     = null;
var $selectizeReviewPeriods             = null;
var $selectizeLevels                    = null;
var $selectizeSections                  = null;
var $selectizeQualifications            = null;
var $selectizeReviewers                 = null;
var $selectizeApprovers                 = null;
var $selectizePublisher                 = null;
var $selectizeMStype                    = null;
var $selectizeDepartments               = null;
var $selectizeAccessLevel               = null;

var $selectizeEditDepartments           = null;
var $selectizeEditDocumentControlNumber = null;
var $selectizeCategoriesEdit            = null;
var $selectizeDocumentTypesEdit         = null;
var $selectizeReviewPeriodsEdit         = null;
var $selectizeLevelsEdit                = null;
var $selectizeSectionsEdit              = null;
var $selectizeQualificationsEdit        = null;
var $selectizeReviewersEdit             = null;
var $selectizeApproversEdit             = null;
var $selectizePublisherEdit             = null;
var $selectizeMStypeEdit                = null;
var $selectizeAccessLevelEdit           = null;

var documentNumber = [];

$(function () {
    
    
    reload();

    loadCategories();
    loadDocumentControlNumber();
    loadReviewPeriods();
    loadLevels();
    loadSections();
    loadQualifications();
    loadReviewers();
    loadApprovers();
    loadPublishers();
    loadMSType();
    loadDepartments();
    loadAccessLevel();

    loadAccessLevelEdit();
    loadEditDepartments();
    loadEditDocumentControlNumber();
    loadReviewPeriodsEdit();
    loadLevelsEdit();
    loadSectionsEdit();
    loadQualificationsEdit();
    loadReviewersEdit();
    loadApproversEdit();
    loadPublishersEdit();
    loadMStypeEdit();
    loadCategoriesEdit();

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
        if ($('#fld-new-department-name').val() == 'Blank') {
            noPositionAlert();
        } else {
            $('#mdl-new').modal('show');
        }
    });

    $(document).on('click', '.btn-view', function () {
        var id = $(this).data('id');
        location.href = '/InformationManagement/DocumentRequests/View/' + id
    });

    $(document).on('click', '#btn-alert-contact', function () {
        $('#mdl-alert').modal('hide');
    });

    $(document).on('click', '.btn-edit', function () {
        
        var id = $(this).data('id');

        page.get('/Get?id=' + id).then(function (data) {

            if ($selectizeEditDocumentControlNumber != null) {
                $selectizeEditDocumentControlNumber[0].selectize.setValue(' ');
            }

            if ($selectizeCategoriesEdit != null) {
                $selectizeCategoriesEdit[0].selectize.setValue(' ');

            }

            if ($selectizeAccessLevelEdit != null) {
                $selectizeAccessLevelEdit[0].selectize.setValue(' ');

            }

            if ($selectizeReviewPeriodsEdit != null) {
                $selectizeReviewPeriodsEdit[0].selectize.setValue(' ');

            }

            if ($selectizeSectionsEdit != null) {
                $selectizeSectionsEdit[0].selectize.setValue(' ');

            }

            if ($selectizeQualificationsEdit != null) {
                $selectizeQualificationsEdit[0].selectize.setValue(' ');

            }

            if ($selectizeReviewersEdit != null) {
                $selectizeReviewersEdit[0].selectize.setValue(' ');

            }

            if ($selectizeApproversEdit != null) {
                $selectizeApproversEdit[0].selectize.setValue(' ');

            }

            if ($selectizePublisherEdit != null) {
                $selectizePublisherEdit[0].selectize.setValue(' ');

            }

            if ($selectizeMStypeEdit != null) {
                $selectizeMStypeEdit[0].selectize.setValue(' ');

            }
            if ($selectizeEditDepartments != null) {
                $selectizeEditDepartments[0].selectize.setValue(' ');

            }

            if ($selectizeDocumentTypesEdit != null) {
                $selectizeDocumentTypesEdit[0].selectize.setValue(' ');
            }


            $('#fld-edit-id').val(data.Id);
            $('#fld-edit-dcrn').val(data.DCRN);
            $('#fld-edit-tag').val(data.Tag);
            $('#fld-edit-name').val(data.Name);
            $('#fld-edit-purpose').val(data.Purpose);
            $('#fld-edit-document-control-number').val(data.DocumentControlNumber);
            $('.fld-editor').val(data.Content);

            var DocumentNumberSplit = data.DocumentControlNumber.split("-");
            var companyCode = DocumentNumberSplit[0];
            var DocumentPrefix = DocumentNumberSplit[1];
            var DepartmentCode = DocumentNumberSplit[2] + '-' + DocumentNumberSplit[3];
            var PrefixNumber = DocumentNumberSplit[4];

            $('#fld-edit-employee-name').val(data.EmployeeName);
            $('#fld-edit-employee-id').val(data.EmployeeId);

            $('#fld-edit-company-code').val(companyCode);
            $('#fld-edit-document-type-prefix').val(DocumentPrefix);
            $('#fld-edit-department-code').val(DepartmentCode);
            $('#fld-edit-selected-prefix-number').val(PrefixNumber);

            $('#fld-edit-document-category-id').val(data.DocumentCategoryId);
            $('#fld-edit-document-category-name').val(data.DocumentCategoryName);

            $('#fld-edit-access-level-id').val(data.AccessLevelId);
            $('#fld-edit-access-level-name').val(data.AccessLevelName);

            $('#fld-edit-document-type-id').val(data.DocumentTypeId);
            $('#fld-edit-document-type-name').val(data.DocumentTypeName);

            $('#fld-edit-review-period').val(data.ReviewPeriod);

            $('#fld-edit-level-id').val(data.LevelId);
            $('#fld-edit-level-name').val(data.LevelName);

            $('#fld-edit-section-id').val(data.SectionId);
            $('#fld-edit-section-name').val(data.SectionName);

            $('#fld-edit-qualification-id').val(data.QualificationId);
            $('#fld-edit-qualification-name').val(data.QualificationName);

            $('#fld-edit-reviewer-id').val(data.ReviewerSetId);
            $('#fld-edit-reviewer-name').val(data.ReviewerSetName);

            $('#fld-edit-approver-id').val(data.ApproverSetId);
            $('#fld-edit-approver-name').val(data.ApproverSetName);

            $('#fld-edit-publisher-id').val(data.PublisherSetId);
            $('#fld-edit-publisher-name').val(data.PublisherSetName);

            $('#fld-edit-ms-type-id').val(data.OrganizationManagementSystemId);
            $('#fld-edit-ms-type-name').val(data.OrganizationManagementSystemName);

            $('#fld-edit-department-id').val(data.DepartmentId);
            $('#fld-edit-department-name').val(data.DepartmentName);
            
            $('#mdl-edit').modal('show');
        });
    });

    $(document).on('click', '#btn-new-save', function () {
        var companyCode             = $('#fld-new-company-code').val();
        var selectedDocumentNumber  = $('.fld-selected-prefix-number').val();
        var selectedPrefix          = $('#fld-new-document-type-prefix').val();
        var selectedDepartmentCode  = $('#fld-new-department-code').val();

        if ($('#fld-new-level-name').val() == 'Level 1' || $('#fld-new-level-name').val() == 'Level 2') { selectedDepartmentCode = '000-000'; }
        if ($('#fld-new-level-name').val() == 'Level 4') { companyCode = '000'; }
        

        var documentNumber = companyCode + "-" + selectedPrefix + "-" + selectedDepartmentCode + "-" + selectedDocumentNumber;
        $('#fld-new-document-control-number').val(documentNumber);

        var validation = page.validate('#bdy-new', 'DocumentRequest');

        if (validation.Valid) {
            page.save(validation.Entity, '/Save', $('#btn-new-save'), 'Document Request Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-save', function () {
        var companyCode             = $('#fld-edit-company-code').val();
        var selectedDocumentNumber  = $('#fld-edit-selected-prefix-number').val();
        var selectedPrefix          = $('#fld-edit-document-type-prefix').val();
        var selectedDepartmentCode  = $('#fld-edit-department-code').val();

        if ($('#fld-edit-level-name').val() == 'Level 1' || $('#fld-edit-level-name').val() == 'Level 2') { selectedDepartmentCode = '000-000'; }
        if ($('#fld-edit-level-name').val() == 'Level 4') { companyCode = '000'; }
        if ($('#fld-edit-level-name').val() != 'Level 4') { companyCode = $('#fld-new-company-code').val(); }

        var documentNumber = companyCode + "-" + selectedPrefix + "-" + selectedDepartmentCode + "-" + selectedDocumentNumber;
        $('#fld-edit-document-control-number').val(documentNumber);
            

        var validation = page.validate('#bdy-edit', 'DocumentRequest');

        if (validation.Valid) {
            page.save(validation.Entity, '/Update', $('#btn-edit-save'), 'Document Request Updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });   

    $(document).on('click', '.btn-delete', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this document request? ', deleteRequest, id);

    });

    $('#mdl-edit').on('shown.bs.modal', function () {
        var prefixNumber        = $('#fld-edit-selected-prefix-number').val();
        var documentCategoryId  = $('#fld-edit-document-category-id').val();
        var accessLevelId       = $('#fld-edit-access-level-id').val();
        var reviewPeriod        = $('#fld-edit-review-period').val();
        var sectionId           = $('#fld-edit-section-id').val();
        var qualificationId     = $('#fld-edit-qualification-id').val();
        var reviewerSetId       = $('#fld-edit-reviewer-id').val();
        var approverId          = $('#fld-edit-approver-id').val();
        var publisherId         = $('#fld-edit-publisher-id').val();
        var mstypeId            = $('#fld-edit-ms-type-id').val();
        var departmentId        = $('#fld-edit-department-id').val();


        setTimeout(
            function () {

                if ($selectizeEditDocumentControlNumber != null) {
                    $selectizeEditDocumentControlNumber[0].selectize.setValue(prefixNumber);
                }

                if ($selectizeCategoriesEdit != null) {
                    $selectizeCategoriesEdit[0].selectize.setValue(documentCategoryId);
                    
                }

                if ($selectizeAccessLevelEdit != null) {
                    $selectizeAccessLevelEdit[0].selectize.setValue(accessLevelId);
                    
                }

                if ($selectizeReviewPeriodsEdit != null) {
                    $selectizeReviewPeriodsEdit[0].selectize.setValue(reviewPeriod);
                    
                }

                if ($selectizeSectionsEdit != null) {
                    $selectizeSectionsEdit[0].selectize.setValue(sectionId);
                    
                }

                if ($selectizeQualificationsEdit != null) {
                    $selectizeQualificationsEdit[0].selectize.setValue(qualificationId);
                    
                }

                if ($selectizeReviewersEdit != null) {
                    $selectizeReviewersEdit[0].selectize.setValue(reviewerSetId);
                    
                }

                if ($selectizeApproversEdit != null) {
                    $selectizeApproversEdit[0].selectize.setValue(approverId);
                    
                }

                if ($selectizePublisherEdit != null) {
                    $selectizePublisherEdit[0].selectize.setValue(publisherId);
                    
                }

                if ($selectizeMStypeEdit != null) {
                    $selectizeMStypeEdit[0].selectize.setValue(mstypeId);
                    
                }
                if ($selectizeEditDepartments != null) {
                    $selectizeEditDepartments[0].selectize.setValue(departmentId);
                    
                }
            }, 1300);
    });

});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteRequest = function (id) {

    page.get('/Delete?id=' + id).then(function () {
        notify('Document request deleted', 'success');
        done();
    });

}

var loadCategories = function () {
    if ($selectizeCategories != null) {
        return;
    }

    $selectizeCategories = $('.fld-document-categories').selectize({
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
                url: '/Setting/DocumentCategories/GetAll',
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

            $('.dv-company-code').addClass('d-none');
            $('.dv-document-type-prefix').addClass('d-none');
            $('.dv-department-code').addClass('d-none');
            $('.dv-prefix-number').addClass('d-none');

            var item = $(this)[0].options[value];
            $('#dv-document-type').removeClass('d-none');
                
            if (item) {

                if (item.LevelName != 'Level 3' && item.LevelName != 'Level 4') {
                    $('.dv-company-code').removeClass('d-none');
                    $('.dv-document-type-prefix').removeClass('d-none');
                    $('.dv-prefix-number').removeClass('d-none');
                }

                if (item.LevelName == 'Level 3') {
                    $('.dv-company-code').removeClass('d-none');
                    $('.dv-document-type-prefix').removeClass('d-none');
                    $('.dv-department-code').removeClass('d-none');
                    $('.dv-prefix-number').removeClass('d-none');
                }

                if (item.LevelName == 'Level 4') {
                    $('.dv-document-type-prefix').removeClass('d-none');
                    $('.dv-department-code').removeClass('d-none');
                    $('.dv-prefix-number').removeClass('d-none');
                }

                $('#fld-new-document-category-name').val(item.Name);
                $('#fld-new-document-category-id').val(item.Id);
                $('#fld-new-level-name').val(item.LevelName);
                $('#fld-new-level-id').val(item.LevelId);
                loadDocumentTypes(item.Id);


            } else {
            }

        },
    });
}

var loadDocumentTypes = function (id) {
    if ($selectizeDocumentTypes != null) {
        $selectizeDocumentTypes[0].selectize.destroy();
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
                url: '/Setting/DocumentTypes/GetAllBy?id=' + id,
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
                $('#fld-new-document-type-name').val(item.Name);
                $('#fld-new-document-type-id').val(item.Id);
                $('#fld-new-document-type-prefix').val(item.DocumentTypePrefix);
            } else {
            }

        },
    });
}

var padLeadingZeros = function(num, size) {
    var s = num + "";
    while (s.length < size) s = "0" + s;
    documentNumber.push({
        'Id': s,
        'Name': s
    });
}

var loadDocumentControlNumber = function () {

    if ($selectizeDocumentControlNumber != null) {
        return;
    }

    for (var c = 1; c <= 50; c++) {
        var a = c;
        padLeadingZeros(a, 3);
        
    }

    $selectizeDocumentControlNumber = $('.fld-selected-prefix-number').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        options: documentNumber,
        dropdownParent: 'body',
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {
            } else {
            }

        },
    });
}

var loadEditDocumentControlNumber = function () {

    if ($selectizeEditDocumentControlNumber != null) {
        return;
    }

    $selectizeEditDocumentControlNumber = $('.fld-edit-selected-prefix-number').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        options: documentNumber,
        dropdownParent: 'body',
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {
                $('#fld-edit-selected-prefix-number').val(item.Id);
            } else {
            }

        },
    });
}

var loadReviewPeriods = function () {
    if ($selectizeReviewPeriods != null) {
        return;
    }

    $selectizeReviewPeriods = $('.fld-review-period').selectize({
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
                $('#fld-new-review-period').val(item.Name);
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
                $('#fld-new-level-id').val(item.Id);
                $('#fld-new-level-name').val(item.Name);
            } else {
            }

        },
    });
}

var loadSections = function () {
    if ($selectizeSections != null) {
        return;
    }

    $selectizeSections = $('.fld-sections').selectize({
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
                url: '/Setting/DocumentSections/GetAll',
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
                $('#fld-new-section-id').val(item.Id);
                $('#fld-new-section-name').val(item.Name);
            } else {
            }

        },
    });
}

var loadQualifications = function () {
    if ($selectizeQualifications != null) {
        return;
    }

    $selectizeQualifications = $('.fld-qualifications').selectize({
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
                url: '/Setting/DocumentQualifications/GetAll',
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
                $('#fld-new-qualification-id').val(item.Id);
                $('#fld-new-qualification-name').val(item.Name);
            } else {
            }

        },
    });
}

var loadReviewers = function () {
    if ($selectizeReviewers != null) {
        return;
    }

    $selectizeReviewers = $('.fld-reviewers').selectize({
        valueField: 'Id',
        searchField: 'GroupName',
        labelField: 'GroupName',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/Approvers/GetAllReviewers',
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
                $('#fld-new-reviewer-id').val(item.Id);
                $('#fld-new-reviewer-name').val(item.GroupName);
            } else {
            }

        },
    });
}

var loadApprovers = function () {
    if ($selectizeApprovers != null) {
        return;
    }

    $selectizeApprovers = $('.fld-approvers').selectize({
        valueField: 'Id',
        searchField: 'GroupName',
        labelField: 'GroupName',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/Approvers/GetAllApprovers',
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
                $('#fld-new-approver-id').val(item.Id);
                $('#fld-new-approver-name').val(item.GroupName);
            } else {
            }

        },
    });
}

var loadPublishers = function () {
    if ($selectizePublisher != null) {
        return;
    }

    $selectizePublisher = $('.fld-publishers').selectize({
        valueField: 'Id',
        searchField: 'GroupName',
        labelField: 'GroupName',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/Approvers/GetAllPublishers',
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
                $('#fld-new-publisher-id').val(item.Id);
                $('#fld-new-publisher-name').val(item.GroupName);
            } else {
            }

        },
    });
}

var loadCategoriesEdit = function () {
    if ($selectizeCategoriesEdit != null) {
        return;
    }

    $selectizeCategoriesEdit = $('.fld-edit-document-categories').selectize({
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
                url: '/Setting/DocumentCategories/GetAll',
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

            $('.dv-edit-company-code').addClass('d-none');
            $('.dv-edit-document-type-prefix').addClass('d-none');
            $('.dv-edit-department-code').addClass('d-none');
            $('.dv-edit-prefix-number').addClass('d-none');

            $('#dv-edit-document-type').removeClass('d-none');
            var item = $(this)[0].options[value];
            if (item) {

                if (item.LevelName != 'Level 3' && item.LevelName != 'Level 4') {
                    $('.dv-edit-company-code').removeClass('d-none');
                    $('.dv-edit-document-type-prefix').removeClass('d-none');
                    $('.dv-edit-prefix-number').removeClass('d-none');
                }

                if (item.LevelName == 'Level 3') {
                    $('.dv-edit-company-code').removeClass('d-none');
                    $('.dv-edit-document-type-prefix').removeClass('d-none');
                    $('.dv-edit-department-code').removeClass('d-none');
                    $('.dv-edit-prefix-number').removeClass('d-none');
                }

                if (item.LevelName == 'Level 4') {
                    $('.dv-edit-document-type-prefix').removeClass('d-none');
                    $('.dv-edit-department-code').removeClass('d-none');
                    $('.dv-edit-prefix-number').removeClass('d-none');
                }

                $('#fld-edit-document-category-name').val(item.Name);
                $('#fld-edit-document-category-id').val(item.Id);
                $('#fld-edit-level-name').val(item.LevelName);
                $('#fld-edit-level-id').val(item.LevelId);
                loadDocumentTypesEdit(item.Id);


                var documentTypeId = $('#fld-edit-document-type-id').val();

                setTimeout(
                    function () {
                        if ($selectizeDocumentTypesEdit != null) {
                            $selectizeDocumentTypesEdit[0].selectize.setValue(documentTypeId);
                        }
                    }, 1000);
                
            } else {
            }

        },
    });
}

var loadDocumentTypesEdit = function (id) {
    if ($selectizeDocumentTypesEdit != null) {
        $selectizeDocumentTypesEdit[0].selectize.destroy();
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
                url: '/Setting/DocumentTypes/GetAllBy?id=' + id,
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
                $('#fld-edit-document-type-name').val(item.Name);
                $('#fld-edit-document-type-id').val(item.Id);
                $('#fld-edit-document-type-prefix').val(item.DocumentTypePrefix);
            } else {
            }

        },
    });
}

var loadReviewPeriodsEdit = function () {
    if ($selectizeReviewPeriodsEdit != null) {
        return;
    }

    $selectizeReviewPeriodsEdit = $('.fld-edit-review-period').selectize({
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
                $('#fld-edit-review-period').val(item.Name);
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
        dropdownParent: 'body',
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {
                $('#fld-edit-level-id').val(item.Id);
                $('#fld-edit-level-name').val(item.Name);
            } else {
            }

        },
    });
}

var loadSectionsEdit = function () {
    if ($selectizeSectionsEdit != null) {
        return;
    }

    $selectizeSectionsEdit = $('.fld-edit-sections').selectize({
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
                url: '/Setting/DocumentSections/GetAll',
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
                $('#fld-edit-section-id').val(item.Id);
                $('#fld-edit-section-name').val(item.Name);
            } else {
            }

        },
    });
}

var loadQualificationsEdit = function () {

    if ($selectizeQualificationsEdit != null) {
        return;
    }

    $selectizeQualificationsEdit = $('.fld-edit-qualifications').selectize({
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
                url: '/Setting/DocumentQualifications/GetAll',
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
                $('#fld-edit-qualification-id').val(item.Id);
                $('#fld-edit-qualification-name').val(item.Name);
            } else {
            }

        },
    });
}

var loadReviewersEdit = function () {

    if ($selectizeReviewersEdit != null) {
        return;
    }

    $selectizeReviewersEdit = $('.fld-edit-reviewers').selectize({
        valueField: 'Id',
        searchField: 'GroupName',
        labelField: 'GroupName',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/Approvers/GetAllReviewers',
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
                $('#fld-edit-reviewer-id').val(item.Id);
                $('#fld-edit-reviewer-name').val(item.GroupName);
            } else {
            }

        },
    });
}

var loadApproversEdit = function () {
    if ($selectizeApproversEdit != null) {
        return;
    }

    $selectizeApproversEdit = $('.fld-edit-approvers').selectize({
        valueField: 'Id',
        searchField: 'GroupName',
        labelField: 'GroupName',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/Approvers/GetAllApprovers',
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
                $('#fld-edit-approver-id').val(item.Id);
                $('#fld-edit-approver-name').val(item.GroupName);
            } else {
            }

        },
    });
}

var loadPublishersEdit = function () {

    if ($selectizePublisherEdit != null) {
        return;
    }

    $selectizePublisherEdit = $('.fld-edit-publishers').selectize({
        valueField: 'Id',
        searchField: 'GroupName',
        labelField: 'GroupName',
        preload: true,
        create: true,
        sortField: {
            field: 'Id',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/Approvers/GetAllPublishers',
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
                $('#fld-edit-publisher-id').val(item.Id);
                $('#fld-edit-publisher-name').val(item.GroupName);
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
                    + '<div class="f12">' + escape(item.Type) + ' (' + item.Version + ')</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f121">' + escape(item.Type) + ' (' + item.Version + ')</div>'
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
                $('#fld-new-ms-type-name').val(item.Type + ' - ' + item.Version);
            } else {
            }

        },
    });
}


var loadMStypeEdit = function () {

    if ($selectizeMStypeEdit != null) {
        return;
    }

    $selectizeMStypeEdit = $('.fld-edit-ms-types').selectize({
        valueField: 'Id',
        searchField: 'Type',
        labelField: 'Type',
        preload: true,
        create: true,
        sortField: {
            field: 'Type',
            direction: 'asc'
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
                $('#fld-edit-ms-type-name').val(item.Type + ' - ' + item.Version);
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
                $('#fld-new-department-code').val(item.ProcessCode + '-' + item.Code);
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
                $('#fld-edit-department-name').val(item.Name);
                $('#fld-edit-department-code').val(item.ProcessCode + '-' + item.Code);
            } else {
            }

        },
    });

}

var loadAccessLevel = function () {

    if ($selectizeAccessLevel != null) {
        return;
    }

    $selectizeAccessLevel = $('.fld-access-level').selectize({
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
                url: '/Setting/DocumentClassification/GetAll',
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
                $('#fld-new-access-level-id').val(item.Id);
                $('#fld-new-access-level-name').val(item.Name);
            } else {
            }

        },
    });

}

var loadAccessLevelEdit = function () {

    if ($selectizeAccessLevelEdit != null) {
        return;
    }

    $selectizeAccessLevelEdit = $('.fld-edit-access-level').selectize({
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
                url: '/Setting/DocumentClassification/GetAll',
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
                $('#fld-edit-access-level-id').val(item.Id);
                $('#fld-edit-access-level-name').val(item.Name);
            } else {
            }

        },
    });

}

var reload = function () {
    if (window.location.href.indexOf("#") > -1) {
        location.href = "/InformationManagement/DocumentRequests"
    }
}
var noPositionAlert = function () {
    $('#mdl-alert').modal('show');
    $('#mdl-alert').find('.p-message').html('You have no current designation, please contact the administrator');
}


