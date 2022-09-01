
var page                         = new Page("/AuditManagement/InternalAudit");

var $selectizeEditAuditor        = null;


var auditPlanSupportingDocuments = [];
var auditPlanAuditors            = [];
var auditSchedules               = [];


$(function () {

    loadEditAuditor();

    var id = $('#hdn-auditplan-id').val();

    page.get('/GetAuditPlan?id=' + id).then(function (data) {
        $('.dv-auditplan-date').html('<em>' + moment(data.StartDatePlan).format('MMM DD, YYYY') + ' to ' + moment(data.EndDatePlan).format('MMM DD, YYYY') + '</em>');

    });

    $(document).on('click', '#btn-upload-save', function () {

        var validation = page.validate('.dv-content', 'AuditPlan');

        if (validation.Valid) {
            validation.Entity['AuditPlan.AuditPlanSupportingDocuments'] = auditPlanSupportingDocuments;
            page.save(validation.Entity, '/SaveAuditPlanFile', $('#btn-upload-save'), 'File uploaded', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />') + validateUpload.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-edit-audit-plan-save', function () {
        var validation = page.validate('#bdy-edit', 'AuditPlan');
        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateAuditPlan', $('#btn-edit-audit-plan-save'), 'Audit Plan Updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />') + validateUpload.Message.join('<br />'), 'error')
        }
    });

    $(document).on('click', '#btn-edit-audit-plan-schedule-save', function () {
        var validation = page.validate('#bdy-new-schedule', 'AuditPlan');
        auditSchedules.push({
            'AuditPlanName' : $('#fld-edit-auditplan-schedule-name').val(),
            'StartDate'     : $('#fld-new-auditplan-schedule-start-date').val(),
            'EndDate'       : $('#fld-new-auditplan-schedule-end-date').val()
        });

        if (validation.Valid) {
            validation.Entity['AuditPlan.AuditSchedules'] = auditSchedules;
            page.save(validation.Entity, '/SaveAuditPlanSchedule', $('#btn-edit-audit-plan-schedule-save'), 'Audit Plan Updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />') + validateUpload.Message.join('<br />'), 'error')
        }

        auditSchedules = [];
    });

    $(document).on('click', '#btn-edit', function () {
        var id = $('#hdn-auditplan-id').val();
        page.get('/GetAuditPlan?id=' + id).then(function (data) {
            $('#fld-edit-audit-plan-id').val(data.Id);
            $('#fld-edit-audit-plan-name').val(data.Name);
            $('#fld-edit-audit-plan-description').val(data.Description);
            $('#fld-edit-audit-plan-objective').val(data.Objective);
            $('#fld-edit-audit-plan-criteria').val(data.Criteria);

            $('#mdl-edit-audit-plan').modal('show');
        });
    });

    $(document).on('click', '#btn-add-auditor', function () {
        $('#mdl-new-audit-plan-auditors').modal('show');
    });

    $(document).on('click', '#btn-new-audit-plan-auditor-save', function () {
        var validation = page.validate('#bdy-new-auditor', 'AuditPlan');

        if (validation.Valid) {
            validation.Entity['AuditPlan.Id'] = id;
            validation.Entity['AuditPlan.AuditPlanAuditors'] = auditPlanAuditors;
            page.save(validation.Entity, '/SaveAuditPlanAuditors', $('#btn-new-audit-plan-auditor-save'), 'Audit Plan Updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />') + validateUpload.Message.join('<br />'), 'error')
        }

        auditSchedules = [];
    });

    $(document).on('click', '#btn-add-schedule', function () {
        $('#mdl-new-audit-plan-schedule').modal('show');
    });

    $(document).on('click', '#btn-approve-audit-plan-request', function () {
        var id = $(this).data('id');
        var auditPlanId = $(this).data('auditplan-id');

        page.get('/ApproveAudit?id=' + auditPlanId + '&employeeId=' + id).then(function () {
            notify('Approved!', 'success');
            done();
        });

    });

    $(document).on('click', '.btn-remove-auditor', function () {
        var id = $(this).data('id');

        auditPlanAuditors = auditPlanAuditors.slice(0);
        auditPlanAuditors.forEach((element) => {
            if (id.includes(element['AuditorId'])) {
                var removeIndex = auditPlanAuditors.map((item) => item['AuditorId']).indexOf(element['AuditorId']);
                auditPlanAuditors.splice(removeIndex, 1);
            }
        });

        $('.' + id).remove();
    });

    $(document).on('click', '#btn-back', function () {
        location.href = "/AuditManagement/InternalAudit#nav-auditplan";
    });

    $(document).on('click', '#btn-delete', function () {
        var id = $('#hdn-auditplan-id').val();
        showConfirm('Are you sure you want to delete this audit plan? ', deleteAuditPlan, id);
    });

    $(document).on('click', '#btn-approval-submit', function () {
        var id = $(this).data('id');
        var auditPlanId = 0;
        var auditorCount = 0;
        var auditScheduleCount = 0;
        page.get('/GetAuditPlan?id=' + id).then(function (data) {
            if (data.AuditPlanAuditors.length != 0 && data.AuditSchedules.length != 0) {
                auditPlanId = data.Id;
                auditorCount = 1;
                auditScheduleCount = 1;
            }
            if (auditorCount != 0 && auditScheduleCount != 0) {
                page.get('/SubmitAuditPlan/' + auditPlanId).then(function (data) {
                    notify('Audit Plan Submitted for approval', 'success');
                    done();
                });
            } else {
                notify('Error!', 'error');
            }
            
        });

        
    });

    $(document).on('click', '#btn-delete-audit-plan-auditor', function () {
        var id = $(this).data('id');
        showConfirm('Are you sure you want to remove this auditor? ', deleteAuditPlanAuditor, id);
    });

    $(document).on('click', '#btn-delete-audit-plan-supporting-file', function () {
        var id = $(this).data('id');
        showConfirm('Are you sure you want to remove this file?', deleteAuditPlanSupportingFile, id);
    });

    $(document).on('click', '#btn-delete-audit-plan-schedule', function () {
        var id = $(this).data('id');
        showConfirm('Are you sure you want to remove this schedule?', deleteAuditPlanSchedule, id);
    });

    $(document).on('click', '#btn-upload-remove', function () {
        if (auditPlanSupportingDocuments.length != 0) {
            auditPlanSupportingDocuments = [];
            $('.lbl-file').html('');
            notify('All files removed', 'success');
        } else {
            notify('no files uploaded', 'error');
        }
    });

    $(document).on('click', '#btn-upload', function () {
        $('#mdl-file-upload').modal('show');
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
                $("#file-uploadfile-progress").hide();
                $('#fle-file-upload').val('');
                $("#file-uploadfile-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#mdl-file-upload').modal('hide');
                notify('File uploaded', 'success');
                $('#fld-file-name').val(file.Item3);
                $('#fld-original-file-name').val(file.Item1);
                $('.lbl-file').append('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a><br />');

                var id = $('#fld-audit-plan-id').val();
                auditPlanSupportingDocuments.push({
                    'AuditPlanId': id,
                    'OriginalFileName': file.Item1,
                    'UniqueFileName': file.Item3
                });
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-uploadfile-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-uploadfile-progress").attr({
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
});

var deleteAuditPlan = function (id) {

    page.get('/DeleteAuditPlan?id=' + id).then(function () {
        notify('Audit plan deleted', 'success');
        deleteDone();
    });

}

var deleteAuditPlanAuditor = function (id) {

    page.get('/DeleteAuditPlanAuditor?id=' + id).then(function () {
        notify('Auditor removed', 'success');
        done();
    });

}

var deleteAuditPlanSupportingFile = function (id) {

    page.get('/DeleteAuditPlanSupportingFile?id=' + id).then(function () {
        notify('File deleted', 'success');
        done();
    });
}

var deleteAuditPlanSchedule = function (id) {
    page.get('/DeleteAuditPlanSchedule?id=' + id).then(function () {
        notify('Schedule removed', 'success');
        done();
    });
}

var deleteDone = function () {
    setTimeout(
        function () {
            location.href = "/AuditManagement/InternalAudit#nav-auditplan";
        }, 1000);
}

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var loadEditAuditor = function () {
    if ($selectizeEditAuditor != null) {
        return;
    }

    $selectizeEditAuditor = $('.fld-edit-auditor').selectize({
        valueField: 'EmployeeId',
        searchField: 'EmployeeName',
        labelField: 'EmployeeName',
        placeholder: "Auditor",
        preload: true,
        create: true,
        sortField: {
            field: 'EmployeeName',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/AuditAuditors/GetAll',
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
                $('#fld-selected-audit-name').val(item.EmployeeName);
                $('#fld-selected-audit-id').val(item.EmployeeId);

                var id = $('#fld-audit-plan-id').val();
                auditPlanAuditors.push({
                    'AuditPlanId': id,
                    'AuditorId': item.EmployeeId,
                    'AuditorName': item.EmployeeName
                });

                $('.dv-auditors').append('<tr class="' + item.EmployeeId + '"><td class="align-middle">' + item.EmployeeName + '</td>' +
                    '<td class="w-25">' + 
                    '<button class="btn btn-outline-danger btn-sm btn-remove-auditor" data-id="' + item.EmployeeId + '" ><i class="fa fa-times"></i></button > <br />' + 
                    '</td></tr>');
            } else {
            }

        },
    });
}