var page                                    = new Page("/Organization/Context");
var $selectizeRatings                       = null;
var $selectizeRatingsEdit                   = null;
var $selectizePestleRatings                 = null;
var $selectizePestleRatingsEdit             = null;

var $selectizeInternalRatings               = null;
var $selectizeInternalRatingsEdit           = null;

var $selectizeExternalRatings               = null;
var $selectizeExternalRatingsEdit           = null;

var $selectizeIssueTypes                    = null;
var $selectizeIssueTypesEdit                = null;
var $selectizeBusinessRiskTypes             = null;
var $selectizeBusinessRiskTypesEdit         = null;
var $selectizeEmployees                     = null;
var $selectizeEmployeesEdit                 = null;

var $selectizeInternalIssueTypes            = null;
var $selectizeInternalIssueTypesEdit        = null;
var $selectizeInternalBusinessRiskTypes     = null;
var $selectizeInternalBusinessRiskTypesEdit = null;
var $selectizeInternalEmployees             = null;
var $selectizeInternalEmployeesEdit         = null;

var $selectizeExternalIssueTypes            = null;
var $selectizeExternalIssueTypesEdit        = null;
var $selectizeExternalBusinessRiskTypes     = null;
var $selectizeExternalBusinessRiskTypesEdit = null;
var $selectizeExternalEmployees             = null;
var $selectizeExternalEmployeesEdit         = null;

var swotTypes = ['Strength', 'Weakness', 'Opportunity', 'Threat'];
var pestleTypes = ['General', 'Political', 'Economical', 'Socal', 'Technological', 'Legal'];

$(function () {

    loadRatings();
    loadRatingsEdit();
    loadPestleRatings();
    loadPestleRatingsEdit();

    loadInternalRatings();
    loadInternalRatingsEdit();

    loadExternalRatings();
    loadExternalRatingsEdit();

    loadIssueTypes();
    loadIssueEditTypes();
    loadBusinessRiskTypes();
    loadBusinessRiskTypesEdit();
    loadEmployees();
    loadEmployeesEdit();

    loadIssueTypesInternal();
    loadIssueEditTypesInternal();
    loadBusinessRiskTypesInternal();
    loadBusinessRiskTypesEditInternal();
    loadInternalEmployees();
    loadInternalEmployeesEdit();

    loadIssueTypesExternal();
    loadIssueEditTypesExternal();
    loadBusinessRiskTypesExternal();
    loadBusinessRiskTypesEditExternal();
    loadExternalEmployees();
    loadExternalEmployeesEdit();

    if (window.location.hash) {
        $("a[href='" + window.location.hash + "']").tab('show');
    } else {
        $("a[href='#nav-swot']").tab('show');
    }

    $(document).on('click', '.nav-item', function () {
        var hash = $(this).data('hash');
        if (hash) {
            location.href = '/Organization/Context' + hash;
        }
    });

    $(document).on('click', '#btn-add-strength', function () {

        $('#mdl-new-swot').modal('show');
        $('.swot-type').html('Strength');
        $('#fld-new-swot-tag').val(0);
        $('#mdl-new-swot').find('.modal-title').html('New Strengths');

    });

    $(document).on('click', '#btn-add-weakness', function () {

        $('#mdl-new-swot').modal('show');
        $('.swot-type').html('Weakness');
        $('#fld-new-swot-tag').val(1);
        $('#mdl-new-swot').find('.modal-title').html('New Weaknesses');

    });

    $(document).on('click', '#btn-add-opportunity', function () {

        $('#mdl-new-swot').modal('show');
        $('.swot-type').html('Opportunity');
        $('#fld-new-swot-tag').val(2);
        $('#mdl-new-swot').find('.modal-title').html('New Opportunities');

    });

    $(document).on('click', '#btn-add-threat', function () {

        $('#mdl-new-swot').modal('show');
        $('.swot-type').html('Threat');
        $('#fld-new-swot-tag').val(3);
        $('#mdl-new-swot').find('.modal-title').html('New Threats');

    });

    $(document).on('click', '#btn-new-swot-save', function () {

        var validation = page.validate('#bdy-new', 'SWOT');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveSWOT', $('#btn-new-save'), 'Department Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });


    $(document).on('click', '#btn-edit-swot-save', function () {

        var validation = page.validate('#bdy-edit', 'SWOT');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateSWOT', $('#btn-edit-swot-save'), 'SWOT Updated', 'Update failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-edit-swot', function () {

        var id = $(this).data('id');
        page.get('/GetSWOT?id=' + id).then(function (data) {

            $('#mdl-edit-swot').modal('show');
            $('#fld-edit-swot-id').val(data.Id);
            $('#fld-edit-swot-tag').val(data.Tag);
            $('#fld-edit-swot-name').val(data.Name);
            $('.modal-title').html('Edit ' + swotTypes[data.Tag]);

            if ($selectizeRatingsEdit != null) {
                $selectizeRatingsEdit[0].selectize.setValue(data.RatingId);
                $('#fld-edit-rating-id').val(data.RatingId);
                $('#fld-edit-rating-name').val(data.RatingName);
                $('#fld-edit-rating-color').val(data.RatingColor);
            }

            if ($selectizeBusinessRiskTypesEdit != null) {
                $selectizeBusinessRiskTypesEdit[0].selectize.setValue(data.BusinessRiskTypeId);
                $('#fld-edit-business-risk-type-id').val(data.BusinessRiskTypeId);
                $('#fld-edit-business-risk-type-name').val(data.BusinessRiskTypeName);
            }

            if ($selectizeIssueTypesEdit != null) {
                $selectizeIssueTypesEdit[0].selectize.setValue(data.IssueTypeId);
                $('#fld-edit-issue-type-id').val(data.IssueTypeId);
                $('#fld-edit-issue-type-name').val(data.IssueTypeName);
            }

            if ($selectizeEmployeesEdit != null) {
                $selectizeEmployeesEdit[0].selectize.setValue(data.EmployeeId);
                $('#fld-edit-employee-id').val(data.EmployeeId);
                $('#fld-edit-employee-name').val(data.EmployeeName);
            }


        });

    });

    $(document).on('click', '.btn-delete-swot', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this item? ', deleteSwot, id);

    });

    $(document).on('click', '#btn-add-pestle-general', function () {

        $('#mdl-new-pestle').modal('show');
        $('.pestle-type').html('General');
        $('#fld-new-pestle-tag').val(0);
        $('#mdl-new-pestle').find('.modal-title').html('New General');

    });

    $(document).on('click', '#btn-add-pestle-political', function () {

        $('#mdl-new-pestle').modal('show');
        $('.pestle-type').html('Political');
        $('#fld-new-pestle-tag').val(1);
        $('#mdl-new-pestle').find('.modal-title').html('New Political');

    });

    $(document).on('click', '#btn-add-pestle-economical', function () {

        $('#mdl-new-pestle').modal('show');
        $('.pestle-type').html('Economical');
        $('#fld-new-pestle-tag').val(2);
        $('#mdl-new-pestle').find('.modal-title').html('New Economical');

    });

    $(document).on('click', '#btn-add-pestle-social', function () {

        $('#mdl-new-pestle').modal('show');
        $('.pestle-type').html('Social');
        $('#fld-new-pestle-tag').val(3);
        $('#mdl-new-pestle').find('.modal-title').html('New Social');

    });

    $(document).on('click', '#btn-add-pestle-technological', function () {

        $('#mdl-new-pestle').modal('show');
        $('.pestle-type').html('Technological');
        $('#fld-new-pestle-tag').val(4);
        $('#mdl-new-pestle').find('.modal-title').html('New Technological');

    });

    $(document).on('click', '#btn-add-pestle-legal', function () {

        $('#mdl-new-pestle').modal('show');
        $('.pestle-type').html('Legal');
        $('#fld-new-pestle-tag').val(5);
        $('#mdl-new-pestle').find('.modal-title').html('New Legal');

    });

    $(document).on('click', '#btn-add-pestle-ecological', function () {

        $('#mdl-new-pestle').modal('show');
        $('.pestle-type').html('Ecological');
        $('#fld-new-pestle-tag').val(6);
        $('#mdl-new-pestle').find('.modal-title').html('New Legal');

    });

    $(document).on('click', '#btn-new-pestle-save', function () {

        var validation = page.validate('#bdy-new-pestle', 'PESTLE');

        if (validation.Valid) {
            page.save(validation.Entity, '/SavePESTLE', $('#btn-new-pestle-save'), 'PESTLE Saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-pestle-save', function () {

        var validation = page.validate('#bdy-edit-pestle', 'PESTLE');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdatePESTLE', $('#btn-edit-pestle-save'), 'PESTLE Saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-edit-pestle', function () {

        var id = $(this).data('id');
        page.get('/GetPESTLE?id=' + id).then(function (data) {

            $('#mdl-edit-pestle').modal('show');
            $('#fld-edit-pestle-id').val(data.Id);
            $('#fld-edit-pestle-tag').val(data.Tag);
            $('#fld-edit-pestle-name').val(data.Name);
            $('.modal-title').html('Edit ' + pestleTypes[data.Tag]);

            if ($selectizePestleRatingsEdit != null) {
                $selectizePestleRatingsEdit[0].selectize.setValue(data.RatingId);
                $('#fld-edit-pestle-rating-id').val(data.RatingId);
                $('#fld-edit-pestle-rating-name').val(data.RatingName);
                $('#fld-edit-pestle-rating-color').val(data.RatingColor);
            }

        });

    });

    $(document).on('click', '.btn-delete-pestle', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this item? ', deletePestle, id);

    });

    $(document).on('click', '.btn-add-internal-issue', function () {

        var id = $(this).data('issue-category-id');
        var name = $(this).data('issue-category-name');

        $('#mdl-new-internal').modal('show');
        $('#fld-new-internal-category-id').val(id);
        $('#fld-new-internal-category-name').val(name);

        $('.internal-type').html(name);
        $('#mdl-new-internal').find('.modal-title').html('New Internal Issue (' + name + ')');

    });

    $(document).on('click', '#btn-new-internal-save', function () {

        var validation = page.validate('#bdy-new-internal', 'InternalIssue');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveInternalIssue', $('#btn-new-internal-save'), 'Internal Issue Saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-edit-internal-issue', function () {

        var id = $(this).data('id');
        page.get('/GetInternalIssue?id=' + id).then(function (data) {

            $('#mdl-edit-internal').modal('show');
            $('#fld-edit-internal-id').val(data.Id);
            $('#fld-edit-internal-category-id').val(data.IssueCategoryId);
            $('#fld-edit-internal-category-name').val(data.IssueCategoryName);
            $('#fld-edit-internal-name').val(data.Name);
            $('#mdl-edit-internal').find('.modal-title').html('Edit Internal Issue (' + data.IssueCategoryName + ')' );

            if ($selectizeInternalRatingsEdit != null) {
                $selectizeInternalRatingsEdit[0].selectize.setValue(data.RatingId);
                $('#fld-edit-internal-rating-id').val(data.RatingId);
                $('#fld-edit-internal-rating-name').val(data.RatingName);
                $('#fld-edit-internal-rating-color').val(data.RatingColor);
            }

            if ($selectizeInternalBusinessRiskTypesEdit != null) {
                $selectizeInternalBusinessRiskTypesEdit[0].selectize.setValue(data.BusinessRiskTypeId);
                $('#fld-edit-internal-business-risk-type-id').val(data.BusinessRiskTypeId);
                $('#fld-edit-internal-business-risk-type-name').val(data.BusinessRiskTypeName);
            }

            if ($selectizeInternalIssueTypesEdit != null) {
                $selectizeInternalIssueTypesEdit[0].selectize.setValue(data.IssueTypeId);
                $('#fld-edit-internal-issue-type-id').val(data.IssueTypeId);
                $('#fld-edit-internal-issue-type-name').val(data.IssueTypeName);
            }

            if ($selectizeInternalEmployeesEdit != null) {
                $selectizeInternalEmployeesEdit[0].selectize.setValue(data.EmployeeId);
                $('#fld-edit-internal-employee-id').val(data.EmployeeId);
                $('#fld-edit-internal-employee-name').val(data.EmployeeName);
            }

        });

    });

    $(document).on('click', '#btn-edit-internal-save', function () {

        var validation = page.validate('#bdy-edit-internal', 'InternalIssue');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateInternalIssue', $('#btn-edit-internal-save'), 'Internal Issue Updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete-internal-issue', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this item? ', deleteInternalIssue, id);

    });

    $(document).on('click', '.btn-add-external-issue', function () {

        var id      = $(this).data('issue-category-id');
        var name    = $(this).data('issue-category-name');

        $('#mdl-new-external').modal('show');
        $('#fld-new-external-category-id').val(id);
        $('#fld-new-external-category-name').val(name);

        $('.external-type').html(name);
        $('#mdl-new-external').find('.modal-title').html('New External Issue (' + name + ')');

    });

    $(document).on('click', '#btn-new-external-save', function () {

        var validation = page.validate('#bdy-new-external', 'ExternalIssue');

        if (validation.Valid) {
            page.save(validation.Entity, '/SaveExternalIssue', $('#btn-new-external-save'), 'External Issue Saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-edit-external-issue', function () {

        var id = $(this).data('id');
        page.get('/GetExternalIssue?id=' + id).then(function (data) {

            $('#mdl-edit-external').modal('show');
            $('#fld-edit-external-id').val(data.Id);
            $('#fld-edit-external-category-id').val(data.IssueCategoryId);
            $('#fld-edit-external-category-name').val(data.IssueCategoryName);
            $('#fld-edit-external-name').val(data.Name);
            $('#mdl-edit-external').find('.modal-title').html('Edit External Issue (' + data.IssueCategoryName + ')');

            if ($selectizeExternalRatingsEdit != null) {
                $selectizeExternalRatingsEdit[0].selectize.setValue(data.RatingId);
                $('#fld-edit-external-rating-id').val(data.RatingId);
                $('#fld-edit-external-rating-name').val(data.RatingName);
                $('#fld-edit-external-rating-color').val(data.RatingColor);
            }

            if ($selectizeExternalBusinessRiskTypesEdit != null) {
                $selectizeExternalBusinessRiskTypesEdit[0].selectize.setValue(data.BusinessRiskTypeId);
                $('#fld-edit-external-business-risk-type-id').val(data.BusinessRiskTypeId);
                $('#fld-edit-external-business-risk-type-name').val(data.BusinessRiskTypeName);
            }

            if ($selectizeExternalIssueTypesEdit != null) {
                $selectizeExternalIssueTypesEdit[0].selectize.setValue(data.IssueTypeId);
                $('#fld-edit-external-issue-type-id').val(data.IssueTypeId);
                $('#fld-edit-external-issue-type-name').val(data.IssueTypeName);
            }

            if ($selectizeExternalEmployeesEdit != null) {
                $selectizeExternalEmployeesEdit[0].selectize.setValue(data.EmployeeId);
                $('#fld-edit-external-employee-id').val(data.EmployeeId);
                $('#fld-edit-external-employee-name').val(data.EmployeeName);
            }

        });

    });

    $(document).on('click', '#btn-edit-external-save', function () {

        var validation = page.validate('#bdy-edit-external', 'ExternalIssue');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateExternalIssue', $('#btn-new-external-save'), 'External Issue Saved', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '.btn-delete-external-issue', function () {

        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this item? ', deleteExternalIssue, id);

    });

});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var deleteInternalIssue = function (id) {

    page.get('/DeleteInternalIssue?id=' + id).then(function () {
        notify('Internal Issue deleted', 'success');
        done();
    });

}

var deleteExternalIssue = function (id) {

    page.get('/DeleteExternalIssue?id=' + id).then(function () {
        notify('External Issue deleted', 'success');
        done();
    });

}


var deleteSwot = function (id) {

    page.get('/DeleteSWOT?id=' + id).then(function () {
        notify('SWOT deleted', 'success');
        done();
    });

}

var deletePestle = function (id) {

    page.get('/DeletePESTLE?id=' + id).then(function () {
        notify('PESTLE deleted', 'success');
        done();
    });

}


var loadRatings = function () {
    if ($selectizeRatings != null) {
        return;
    }

    $selectizeRatings = $('.fld-ratings').selectize({
        render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Name) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f121">' + escape(item.Name) + '</div>'
                    + '</div>';
            }
        },
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
                url: '/Setting/Ratings/GetAll',
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
                $('#fld-new-rating-id').val(item.Id);
                $('#fld-new-rating-name').val(item.Name);
                $('#fld-new-rating-color').val(item.Color);
            } else {
            }

        },
    });
}

var loadRatingsEdit = function () {
    if ($selectizeRatingsEdit != null) {
        return;
    }

    $selectizeRatingsEdit = $('.fld-edit-ratings').selectize({
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
                url: '/Setting/Ratings/GetAll',
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
                $('#fld-edit-rating-id').val(item.Id);
                $('#fld-edit-rating-name').val(item.Name);
                $('#fld-edit-rating-color').val(item.Color);
            } else {
            }

        },
    });
}

var loadPestleRatings = function () {
    if ($selectizePestleRatings != null) {
        return;
    }

    $selectizePestleRatings = $('.fld-pestle-ratings').selectize({
        render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Name) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f121">' + escape(item.Name) + '</div>'
                    + '</div>';
            }
        },
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
                url: '/Setting/Ratings/GetAll',
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
                $('#fld-new-pestle-rating-id').val(item.Id);
                $('#fld-new-pestle-rating-name').val(item.Name);
                $('#fld-new-pestle-rating-color').val(item.Color);
            } else {
            }

        },
    });
}

var loadPestleRatingsEdit = function () {
    if ($selectizePestleRatingsEdit != null) {
        return;
    }

    $selectizePestleRatingsEdit = $('.fld-edit-pestle-ratings').selectize({
        render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Name) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f121">' + escape(item.Name) + '</div>'
                    + '</div>';
            }
        },
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
                url: '/Setting/Ratings/GetAll',
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
                $('#fld-edit-pestle-rating-id').val(item.Id);
                $('#fld-edit-pestle-rating-name').val(item.Name);
                $('#fld-edit-pestle-rating-color').val(item.Color);
            } else {
            }

        },
    });
}


var loadInternalRatings = function () {

    if ($selectizeInternalRatings != null) {
        return;
    }

    $selectizeInternalRatings = $('.fld-internal-ratings').selectize({
        render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Name) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f121">' + escape(item.Name) + '</div>'
                    + '</div>';
            }
        },
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
                url: '/Setting/Ratings/GetAll',
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
                $('#fld-new-internal-rating-id').val(item.Id);
                $('#fld-new-internal-rating-name').val(item.Name);
                $('#fld-new-internal-rating-color').val(item.Color);
            } else {
            }

        },
    });

}

var loadInternalRatingsEdit = function () {

    if ($selectizeInternalRatingsEdit != null) {
        return;
    }

    $selectizeInternalRatingsEdit = $('.fld-edit-internal-ratings').selectize({
        render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Name) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f121">' + escape(item.Name) + '</div>'
                    + '</div>';
            }
        },
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
                url: '/Setting/Ratings/GetAll',
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
                $('#fld-edit-internal-rating-id').val(item.Id);
                $('#fld-edit-internal-rating-name').val(item.Name);
                $('#fld-edit-internal-rating-color').val(item.Color);
            } else {
            }

        },
    });

}

var loadExternalRatings = function () {

    if ($selectizeExternalRatings != null) {
        return;
    }

    $selectizeExternalRatings = $('.fld-external-ratings').selectize({
        render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Name) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f121">' + escape(item.Name) + '</div>'
                    + '</div>';
            }
        },
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
                url: '/Setting/Ratings/GetAll',
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
                $('#fld-new-external-rating-id').val(item.Id);
                $('#fld-new-external-rating-name').val(item.Name);
                $('#fld-new-external-rating-color').val(item.Color);
            } else {
            }

        },
    });

}

var loadExternalRatingsEdit = function () {

    if ($selectizeExternalRatingsEdit != null) {
        return;
    }

    $selectizeExternalRatingsEdit = $('.fld-edit-external-ratings').selectize({
        render: {
            option: function (item, escape) {
                return '<div>'
                    + '<div class="f12">' + escape(item.Name) + '</div>'
                    + '</div>';
            },
            item: function (item, escape) {
                return '<div>'
                    + '<div class="f121">' + escape(item.Name) + '</div>'
                    + '</div>';
            }
        },
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
                url: '/Setting/Ratings/GetAll',
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
                $('#fld-edit-external-rating-id').val(item.Id);
                $('#fld-edit-external-rating-name').val(item.Name);
                $('#fld-edit-external-rating-color').val(item.Color);
            } else {
            }

        },
    });

}

var loadIssueTypes = function () {
    if ($selectizeIssueTypes != null) {
        return;
    }

    $selectizeIssueTypes = $('.fld-issue-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/IssueTypes/GetAll',
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
                $('#fld-new-issue-type-name').val(item.Name);
                $('#fld-new-issue-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadIssueEditTypes = function () {
    if ($selectizeIssueTypesEdit != null) {
        return;
    }

    $selectizeIssueTypesEdit = $('.fld-edit-issue-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/IssueTypes/GetAll',
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
                $('#fld-edit-issue-type-name').val(item.Name);
                $('#fld-edit-issue-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadBusinessRiskTypes = function () {
    if ($selectizeBusinessRiskTypes != null) {
        return;
    }

    $selectizeBusinessRiskTypes = $('.fld-business-risk-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/BusinessRiskTypes/GetAll',
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
                $('#fld-new-business-risk-type-name').val(item.Name);
                $('#fld-new-business-risk-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadBusinessRiskTypesEdit = function () {
    if ($selectizeBusinessRiskTypesEdit != null) {
        return;
    }

    $selectizeBusinessRiskTypesEdit = $('.fld-edit-business-risk-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/BusinessRiskTypes/GetAll',
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
                $('#fld-edit-business-risk-type-name').val(item.Name);
                $('#fld-edit-business-risk-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadIssueTypesInternal = function () {
    if ($selectizeInternalIssueTypes != null) {
        return;
    }

    $selectizeInternalIssueTypes = $('.fld-internal-issue-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/IssueTypes/GetAll',
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
                $('#fld-new-internal-issue-type-name').val(item.Name);
                $('#fld-new-internal-issue-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadIssueEditTypesInternal = function () {
    if ($selectizeInternalIssueTypesEdit != null) {
        return;
    }

    $selectizeInternalIssueTypesEdit = $('.fld-edit-internal-issue-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/IssueTypes/GetAll',
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
                $('#fld-edit-internal-issue-type-name').val(item.Name);
                $('#fld-edit-internal-issue-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadBusinessRiskTypesInternal = function () {
    if ($selectizeInternalBusinessRiskTypes != null) {
        return;
    }

    $selectizeInternalBusinessRiskTypes = $('.fld-internal-business-risk-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/BusinessRiskTypes/GetAll',
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
                $('#fld-new-internal-business-risk-type-name').val(item.Name);
                $('#fld-new-internal-business-risk-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadBusinessRiskTypesEditInternal = function () {
    if ($selectizeInternalBusinessRiskTypesEdit != null) {
        return;
    }

    $selectizeInternalBusinessRiskTypesEdit = $('.fld-edit-internal-business-risk-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/BusinessRiskTypes/GetAll',
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
                $('#fld-edit-internal-business-risk-type-name').val(item.Name);
                $('#fld-edit-internal-business-risk-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadIssueTypesExternal = function () {
    if ($selectizeExternalIssueTypes != null) {
        return;
    }

    $selectizeExternalIssueTypes = $('.fld-external-issue-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/IssueTypes/GetAll',
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
                $('#fld-new-external-issue-type-name').val(item.Name);
                $('#fld-new-external-issue-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadIssueEditTypesExternal = function () {
    if ($selectizeExternalIssueTypesEdit != null) {
        return;
    }

    $selectizeExternalIssueTypesEdit = $('.fld-edit-external-issue-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/IssueTypes/GetAll',
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
                $('#fld-edit-external-issue-type-name').val(item.Name);
                $('#fld-edit-external-issue-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadBusinessRiskTypesExternal = function () {
    if ($selectizeExternalBusinessRiskTypes != null) {
        return;
    }

    $selectizeExternalBusinessRiskTypes = $('.fld-external-business-risk-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/BusinessRiskTypes/GetAll',
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
                $('#fld-new-external-business-risk-type-name').val(item.Name);
                $('#fld-new-external-business-risk-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadBusinessRiskTypesEditExternal = function () {
    if ($selectizeExternalBusinessRiskTypesEdit != null) {
        return;
    }

    $selectizeExternalBusinessRiskTypesEdit = $('.fld-edit-external-business-risk-type').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "-",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/BusinessRiskTypes/GetAll',
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
                $('#fld-edit-external-business-risk-type-name').val(item.Name);
                $('#fld-edit-external-business-risk-type-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadEmployees = function () {

    if ($selectizeEmployees != null) {
        return;
    }

    $selectizeEmployees = $('.fld-employees').selectize({
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
                $('#fld-new-employee-id').val(item.Id);
                $('#fld-new-employee-name').val(item.Fullname);
            } else {
            }

        },
    });

}

var loadEmployeesEdit = function () {

    if ($selectizeEmployeesEdit != null) {
        return;
    }

    $selectizeEmployeesEdit = $('.fld-edit-employees').selectize({
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
                $('#fld-edit-employee-id').val(item.Id);
                $('#fld-edit-employee-name').val(item.Fullname);
            } else {
            }

        },
    });

}

var loadInternalEmployees = function () {

    if ($selectizeInternalEmployees != null) {
        return;
    }

    $selectizeInternalEmployees = $('.fld-internal-employees').selectize({
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
                $('#fld-new-internal-employee-id').val(item.Id);
                $('#fld-new-internal-employee-name').val(item.Fullname);
            } else {
            }

        },
    });

}

var loadInternalEmployeesEdit = function () {

    if ($selectizeInternalEmployeesEdit != null) {
        return;
    }

    $selectizeInternalEmployeesEdit = $('.fld-edit-internal-employees').selectize({
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
                $('#fld-edit-internal-employee-id').val(item.Id);
                $('#fld-edit-internal-employee-name').val(item.Fullname);
            } else {
            }

        },
    });

}

var loadExternalEmployees = function () {

    if ($selectizeExternalEmployees != null) {
        return;
    }

    $selectizeExternalEmployees = $('.fld-external-employees').selectize({
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
                $('#fld-new-external-employee-id').val(item.Id);
                $('#fld-new-external-employee-name').val(item.Fullname);
            } else {
            }

        },
    });

}

var loadExternalEmployeesEdit = function () {

    if ($selectizeExternalEmployeesEdit != null) {
        return;
    }

    $selectizeExternalEmployeesEdit = $('.fld-edit-external-employees').selectize({
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
                $('#fld-edit-external-employee-id').val(item.Id);
                $('#fld-edit-external-employee-name').val(item.Fullname);
            } else {
            }

        },
    });
}