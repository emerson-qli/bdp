var page                        = new Page("/AuditManagement/InternalAudit");

var $selectizeMSType            = null;
var $selectizeAuditCategory     = null;
var $selectizeAuditLeader       = null;
var $selectizeAuditors          = null;
var $selectizeAuditProgram      = null;
var $selectizeAudited           = null;

var $selectizeEditAuditors      = null;
var $selectizeEditMSType        = null;
var $selectizeEditAuditCategory = null;
var $selectizeEditAuditLeader   = null;

var $selectizeMonths            = null;
var $selectizeEditMonths        = null;
var $selectizeYears             = null;
var $selectizeEditYears         = null;

var audits                       = [];
var managementSystems            = [];
var processes                    = [];
var auditPlans                   = [];
var auditPlanSupportingDocuments = [];

$(function () {
    
    
    

    loadMSType();
    loadAuditCategory();
    loadAuditLeader();
    loadAuditors();
    loadMonths();
    loadYears();
    loadAuditProgram();
    loadAuditProgramAudited();

    loadEditMonths();
    loadEditYears();
    loadEditMSType();
    loadEditAuditCategory();
    loadEditAuditLeader();
    loadEditAuditors();

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
                $("#file-uploadphoto-progress").attr({
                    value: 0,
                    max: 100
                });
                notify('File uploaded', 'success');
                $('#fld-file-name').val(file.Item3);
                $('#fld-original-file-name').val(file.Item1);
                $('.lbl-file').append('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a><br />');

                auditPlanSupportingDocuments.push({
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
                    $("#file-uploadphoto-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-uploadphoto-progress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                        }
                    }, false);
                }

                $("#file-uploadphoto-progress").hide();
                return fileXhr;

            }
        });

       

    });

    if (window.location.hash) {
        $("a[href='" + window.location.hash + "']").tab('show');
    } else {
        $("a[href='#nav-program']").tab('show');
    }

    $(document).on('click', '.nav-item', function () {
        var hash = $(this).data('hash');
        if (hash) {
            location.href = '/AuditManagement/InternalAudit' + hash;
        }
    })

    $('#tbl-program #tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });
    $('#tbl-auditplan #tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });
    $('#tbl-audit #tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });
    $('#tbl-report #tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });
    $('#tbl-branch #tbl-list').DataTable({
        "bFilter": false,
        "bInfo": false,
        "bLengthChange": false,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });


    

    $(document).on('click', '.dv-audits', function () {
        var id = $(this).data('id');
        populateDetails(id);
    });
    

    $(document).on('click', '#btn-new-program-save', function () {
        audits.push({
            'AuditCategoryId'   : $('#fld-selected-audit-id').val(),
            'AuditCategoryName' : $('#fld-selected-audit-category').val(),
            'StartDate'         : $('#fld-new-start-date').val(),
            'EndDate'           : $('#fld-new-end-date').val()
        });


        var validation = page.validate('#bdy-new-program', 'AuditProgram');

        if (validation.Valid) {
            validation.Entity['AuditProgram.Audits']    = audits;
            validation.Entity['AuditProgram.Name']      = $('#fld-selected-audit-category').val();
            page.save(validation.Entity, '/SaveAuditProgram', $('#btn-new-program-save'), 'Audit Program Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

        
    });

    $(document).on('click', '#btn-new-auditplan-save', function () {
        auditPlans.push({
            'AuditCategoryId'                : $('#fld-selected-auditplan-id').val(),
            'AuditCategoryName'              : $('#fld-selected-auditplan-category').val(),
            'StartDatePlan'                  : $('.fld-new-auditplan-start-date').val(),
            'EndDatePlan'                    : $('.fld-new-auditplan-end-date').val(),
            'Name'                           : $('#fld-new-auditplan-title').val(),
            'Description'                    : $('#fld-new-audit-description').val(),
            'Objective'                      : $('#fld-new-auditplan-objective').val(),
            'Criteria'                       : $('#fld-new-auditplan-criteria').val(),
            'AuthorId'                       : $('#fld-author-id').val(),
            'AuthorName'                     : $('#fld-author-name').val()
        });


        var validation = page.validate('#bdy-new-auditplan', 'Audit');

        if (validation.Valid) {
            validation.Entity['Audit.Id']           = $('#hdn-auditplan-id').val();
            validation.Entity['Audit.AuditPlans']   = auditPlans;
            page.save(validation.Entity, '/SaveAuditPlan', $('#btn-new-auditplan-save'), 'Audit Plan Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }


    });

    $(document).on('click', '#btn-edit-program-save', function () {
        
        var validation = page.validate('#bdy-edit-program', 'AuditProgram');

        if (validation.Valid) {
            validation.Entity['AuditProgram.Name']   = $('#fld-selected-edit-audit-category').val();
            page.save(validation.Entity, '/UpdateAuditProgram', $('#btn-edit-program-save'), 'Audit Program Info Updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }


    });

    $(document).on('click', '#btn-delete-audit-program', function () {
        var id = $('#hdn-edit-auditprogram-id').val();
        showConfirm('Are you sure you want to delete this audit program? ', deleteProgram, id);

    });

    $(document).on('click', '.btn-delete-mstype', function () {
        var id = $(this).data('id');
        $('#mdl-new-audit-mstypes').modal('hide');
        showConfirm('Are you sure you want to delete this system? ', deleteManagementSystem, id);
    });

    $(document).on('click', '.btn-delete-process', function () {
        var id = $(this).data('id');
        $('#mdl-new-auditprogram-processes').modal('hide');
        showConfirm('Are you sure you want to delete this process?', deleteAuditProcess, id);
    });

    $(document).on('click', '.btn-delete-auditors', function () {
        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this auditor? ', deleteAuditor, id);
    });

    $(document).on('click', '#btn-edit-auditplan-delete', function () {
        var id = $('#fld-edit-auditplan-id').val();
        $('#mdl-view-audit-plan').modal('hide');
        showConfirm('Are you sure you want to delete this audit plan? ', deleteAuditPlan, id);
    });

    $(document).on('click', '.btn-delete-finding', function () {
        var id = $(this).data('id');
        showConfirm('Are you sure you want to delete this audit plan? ', deleteAuditFinding, id);
    });


    $(document).on('click', '.btn-view-audit', function () {
        var d = $(this).data('div');

        if (d == 'dv-audit-info') {
            $('#btn-audit-info').addClass('btn-primary').removeClass('btn-outline-primary');
            $('#btn-audit-findings').addClass('btn-outline-primary').removeClass('btn-primary');
            $('#btn-add-audit-findings').addClass('d-none');
        } else {
            $('#btn-audit-info').addClass('btn-outline-primary').removeClass('btn-primary');
            $('#btn-audit-findings').addClass('btn-primary').removeClass('btn-outline-primary');
            $('#btn-add-audit-findings').removeClass('d-none');

        }

        $('.dv').addClass('d-none');
        $('.' + d).removeClass('d-none');
    });

    $(document).on('click', '#btn-add-program', function () {
        $('#mdl-new-program').modal('show');
    });

    $(document).on('click', '#btn-edit-program', function () {
        var id = $('#hdn-edit-auditprogram-id').val();
        page.get('/GetAuditProgram?Id=' + id).then(function (data) {
            $('#fld-edit-auditprogram-id').val(data.Id);
            $('#fld-edit-auditprogram-description').val(data.Description);

            if ($selectizeEditAuditCategory != null) {
                $selectizeEditAuditCategory[0].selectize.setValue(data.AuditCategoryId);
                $('#fld-selected-edit-audit-category').val(data.Name);
                $('#fld-selected-edit-audit-id').val(data.AuditCategoryId);
            }

            $('#mdl-edit-program').modal('show');
        });

    });

    $(document).on('click', '.btn-update-finding', function () {
        var id = $(this).data('id');

        page.get('/GetAuditFinding?Id=' + id).then(function (data) {
            $('#fld-edit-finding-auditplan-id').val(data.AuditPlanId);
            $('#fld-edit-finding-id').val(data.Id);
            $('#fld-edit-finding-name').val(data.Name);
            $('#fld-edit-finding-description').val(data.Description);

            $('#mdl-edit-finding').modal('show');
        });

    });

    $(document).on('click', '#btn-add-audit-findings', function () {
        $('#mdl-new-finding').modal('show');
    });

    $(document).on('click', '#btn-new-finding-save', function () {

        var validation = page.validate('#bdy-new-finding', 'AuditFinding');

        if (validation.Valid) {
            validation.Entity['AuditFinding.AuditPlanId'] = $('#hdn-audited-plan-id').val();
            page.save(validation.Entity, '/SaveAuditFinding', $('#btn-new-finding-save'), 'Audit finding saved', 'Save failed', refreshAuditFinding);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

        $('#mdl-new-finding').modal('hide');
    });



    $(document).on('click', '#btn-edit-finding-save', function () {
        var validation = page.validate('#bdy-edit-finding', 'AuditFinding');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateAuditFinding', $('#btn-edit-finding-save'), 'Audit finding Updated', 'Save failed', refreshAuditFinding);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

        $('#mdl-edit-finding').modal('hide');
    });

    $(document).on('click', '.btn-save-mstype', function () {

        var id = $('#hdn-edit-audit-id').val();


        managementSystems.push({
            'AuditId'                           : $('#fld-mstype-audit-id').val(),
            'OrganizationManagementSystemId'    : $('#fld-selected-mstype-id').val(),
            'OrganizationManagementSystemType'  : $('#fld-selected-mstype-type').val()
        });

        var validation = page.validate('#bdy-new-mstype', 'Audit');

        if (validation.Valid) {
            validation.Entity['Audit.Id'] = id;
            validation.Entity['Audit.ManagementSystems'] = managementSystems;
            page.save(validation.Entity, '/SaveAuditMSType', $('.btn-save-mstype'), 'Audit Program updated', 'Save failed', refreshMSType);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
        $selectizeMSType[0].selectize.setValue("");
        managementSystems = [];
        
    });

    $(document).on('click', '.btn-save-process', function () {
        var id = $('#hdn-edit-audit-id').val();

        processes.push({
            'AuditId'                         : id,
            'OrganizationBusinessProcessName' : $('#fld-new-audit-process').val()
        });

        var validation = page.validate('#bdy-new-process', 'Audit');

        if (validation.Valid) {
            validation.Entity['Audit.Id'] = id;
            validation.Entity['Audit.BusinessProcesses'] = processes;
            page.save(validation.Entity, '/SaveAuditProcess', $('#btn-new-process'), 'Audit Process Added', 'Save failed', refreshProcess);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
        $('#fld-new-audit-process').val('');
        processes = [];
    });

    $(document).on('click', '#btn-new-schedule-save', function () {

        var id = $('#hdn-edit-audit-id').val();

        var validation = page.validate('#bdy-new-schedule', 'Audit');

        if (validation.Valid) {
            validation.Entity['Audit.Id'] = id;
            page.save(validation.Entity, '/UpdateAuditSchedule', $('#btn-new-schedule-save'), 'Audit Program updated', 'Save failed', done); 
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }


    });

    $(document).on('click', '#btn-edit-mstypes', function () {
        var id = $('#hdn-edit-auditprogram-id').val();
        $('#fld-mstype-audit-id').val(id);
        $('#mdl-new-audit-mstypes').modal('show');

        page.get('/GetAudit?id=' + id).then(function (data) {
            populateMSType(data);

        });
    });

    $(document).on('click', '#btn-edit-auditprogram-schedule', function () {
        $('#mdl-new-auditprogram-schedule').modal('show');
    });

    $(document).on('click', '#btn-add-audit-plan', function () {
        $('#mdl-new-audit-plan').modal('show');
    });

    $(document).on('click', '.btn-edit-audit-plan', function () {
        $('#mdl-edit-audit-plan').modal('show');
    });

    $(document).on('click', '#btn-edit-audit-process', function () {
        var id = $('#hdn-edit-auditprogram-id').val();
        $('#fld-process-audit-id').val(id);
        $('#mdl-new-auditprogram-processes').modal('show');

        page.get('/GetAudit?id=' + id).then(function (data) {
            populateProcesses(data);
        });
    });

    $(document).on('click', '#btn-edit-auditprogram-leaders', function () {
        var id = $('#hdn-edit-auditprogram-id').val();
        $('#fld-audit-id-auditor').val(id);
        $('#mdl-new-auditprogram-auditleader').modal('show');

        page.get('/GetAudit?id=' + id).then(function (data) {
            populateAuditors(data);

        });
        
    });

    $(document).on('click', '#btn-new-auditprogram-leader-close', function () {
        setTimeout(
            function () {
                location.reload();
            }, 1000);
    });

    $(document).on('click', '.btn-auditplan-view', function () {
        var id = $(this).data('id');
        location.href = '/AuditManagement/InternalAudit/View/' + id
    });

    $(document).on('click', '.audit-item', function () {
        $('.audited-title').html('');
        $('.td-audited-audit-category').html('');
        $('.td-audited-description').html('');
        $('.td-audited-objective').html('');
        $('.td-audited-criteria').html('');

        $('#dv-audited').addClass('d-none');
        $('.audit-item').removeClass('selected');
        $(this).addClass('selected');

        var id = $(this).data('id');

        page.get('/GetAudited?id=' + id).then(function (data) {

            $('#hdn-audited-plan-id').val(data.Id);
            $('.audited-title').html('<strong>' + data.Name + '</strong><br /><small><em>' + moment(data.StartDatePlan).format('MMM DD, YYYY') + ' to ' + moment(data.EndDatePlan).format('MMM DD, YYYY') + '</em></small>');
            $('.td-audited-audit-category').html(data.AuditCategoryName);
            $('.td-audited-description').html(data.Description);
            $('.td-audited-objective').html(data.Objective);
            $('.td-audited-criteria').html(data.Criteria);
            $('.td-audited-date').html('<em>' + moment(data.StartDatePlan).format('MMM DD, YYYY') + ' to ' + moment(data.EndDatePlan).format('MMM DD, YYYY') + '</em>');

            var d = _.sortBy(data.AuditPlanAuditors, 'CreatedAt');
            var htmlAuditPlanAuditors = '';
            if (d.length != 0) {
                for (var i = 0; i < d.length; i++) {
                    htmlAuditPlanAuditors += '<li class="list-group-item">' + d[i].AuditorName + '</li>';
                   
                }
            } else {
                htmlAuditPlanAuditors = '<li class="list-group-item"> No record. </li>';
            }
            $('.ul-audited-auditors').html(htmlAuditPlanAuditors);

            var de = _.sortBy(data.AuditPlanSupportingDocuments, 'CreatedAt');
            var htmlAuditPlanSupportingFiles = '';
            if (de.length != 0) {
                for (var i = 0; i < de.length; i++) {
                    htmlAuditPlanSupportingFiles += '<li class="list-group-item"><a target="_blank" href="/content/files/' + de[i].UniqueFileName + '">' + de[i].OriginalFileName + '</a></li>';

                }
            } else {
                htmlAuditPlanSupportingFiles = '<li class="list-group-item"> No record. </li>';
            }
            $('.ul-audited-supporting-files').html(htmlAuditPlanSupportingFiles);
            refreshAuditFinding();

            $('#dv-audited').removeClass('d-none');
        });

    });

    $(document).on('click', '.tr-auditprogram', function () {
        var id = $(this).data('id');

        $('#dv-audit-schedule').remove();

        $('.tr-auditprogram').removeClass('selected');
        $(this).addClass('selected');
        $('#tbl-audits').removeClass('d-none');

        $('#hdn-edit-auditprogram-id').val(id);

        

        page.get('/GetAuditProgram?id=' + id).then(function (data) {
            $('.td-audit-name').html(data.Name);
        });

        page.get('/GetAudit?id=' + id).then(function (data) {

            $('#hdn-edit-auditprogram-id').val(data.AuditProgramId);
            $('#hdn-edit-audit-id').val(data.Id);
           

            var htmlMSTypes = '';
            var d = _.sortBy(data.ManagementSystems, 'CreatedAt');
            for (var i = 0; i < d.length; i++) {
                htmlMSTypes += '<li>' + d[i].OrganizationManagementSystemType + '</li>';
            }
            $('.ul-mstypes').html(htmlMSTypes);

            var htmlProcesses = '';
            var a = _.sortBy(data.BusinessProcesses, 'CreatedAt');
            for (var i = 0; i < a.length; a++) {
                htmlProcesses += '<li>' + a[i].OrganizationBusinessProcessName + '</li>';
            }
            $('.ul-proceses').html(htmlProcesses);

            if (data.StartDate != null && data.EndDate != null) {
                $('.td-audit-Schedule').html('<div id="dv-audit-schedule">Start Date: <strong>' + moment(data.StartDate).format('MM/DD/YYYY') + '</strong><br /> End Date: <strong>' + moment(data.EndDate).format('MM/DD/YYYY') + '</strong></div>');
            }

            var c = _.sortBy(data.AuditPlans, 'CreatedAt');
            if (c.length != null) {
                $('.td-total-auditors').html('<strong>' + c.length + '</strong>');
            }
            
        });

    });

    $(document).on('click', '.tr-auditplan', function () {
        var id = $(this).data('id');
        $('.auditplan-title').html('');
        $('.tr-norecords').removeClass('d-none');
        $('.tr-content').addClass('d-none');

        $('.tr-auditplan').removeClass('selected');
        $(this).addClass('selected');
        $('#tbl-auditplans').removeClass('d-none');

        page.get('/GetAuditProgram?id=' + id).then(function (data) {
            $('.auditplan-title').html(data.Name + '<button id="btn-add-audit-plan" class="btn btn-outline-primary f12 btn-sm fa-pull-right"><i class="fa fa-plus"></i> New Plan</button> ');

        });

        page.get('/GetAudit?id=' + id).then(function (data) {

            $('#hdn-auditplan-id').val(data.Id);

            var d = _.sortBy(data.AuditPlans, 'CreatedAt');
            var htmlAuditPlanContent = '';
            var status = '';
            if (d.length != 0) {
                for (var i = 0; i < d.length; i++) {
                    $('.tr-content').removeClass('d-none');
                    if (d[i].Tag == 0) { status = 'Initiated'; }
                    if (d[i].Tag == 1) { status = 'In Progress'; }
                    if (d[i].Tag == 2) { status = 'Audited'; }

                    htmlAuditPlanContent += '<li class="list-group-item"><button data-id="' + d[i].Id +
                                            '" class="btn btn-link btn-auditplan-view">' + d[i].Name + 
                                            '</button><em>' + status + '</em>' + 
                                            '<small class="fa-pull-right">' + moment(d[i].StartDatePlan).format('MMM DD YYYY') + ' to ' + moment(d[i].EndDatePlan).format('MMM DD YYYY') + '</small></li>';

                    $('.tr-norecords').addClass('d-none');
                }
            } else {
                htmlAuditPlanContent = '<li class="list-group-item"> No record. </li>';
            }

            $('.auditplan-content').html(htmlAuditPlanContent);
        });


    });
});

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var populateMSType = function (data) {

    var htmlMStypes = '';
    var htmlTr = '';

    var d = _.sortBy(data.ManagementSystems, 'CreatedAt');

    for (var i = 0; i < d.length; i++) {
        htmlMStypes += '<li>' + d[i].OrganizationManagementSystemType + '</li>';
        htmlTr += '<tr>' +
            '<td class="align-middle">' + d[i].OrganizationManagementSystemType + '</td>' +
            '<td class="w-10">' +
            '<div class="btn-group" role="group">' +
            '<a href="javascript:void(0);" class="btn btn-sm btn-danger btn-delete-mstype" data-id="' + d[i].Id + '" title="Delete"><i class="fa fa-trash"></i></a>' +
            '</div>' +
            '</td>' +
            '</tr>';
    }

    $('.tbl-mstypes').html(htmlTr);
    $('.ul-mstypes').html(htmlMStypes);
}

var refreshMSType = function () {

    var id = $('#hdn-edit-auditprogram-id').val();

    $('#fld-selected-mstype-id').val('');
    $('#fld-selected-mstype-type').val('');

    page.get('/GetAudit?id=' + id).then(function (data) {
        populateMSType(data);

    });
}

var populateProcesses = function (data) {
    var htmlProcesses = '';
    var htmlTr = '';

    var d = _.sortBy(data.BusinessProcesses, 'CreatedAt');

    for (var i = 0; i < d.length; i++) {
        htmlProcesses += '<li>' + d[i].OrganizationBusinessProcessName + '</li>';
        htmlTr += '<tr>' +
            '<td class="align-middle"><li>' + d[i].OrganizationBusinessProcessName + '</li>' +
            '<td class="w-10">' +
            '<div class="btn-group" role="group">' +
            '<a href="javascript:void(0);" class="btn btn-sm btn-danger btn-delete-process" data-id="' + d[i].Id + '" title="Delete"><i class="fa fa-trash"></i></a>' +
            '</div>' +
            '</td>' +
            '</tr>';
    }

    $('.tbl-processes').html(htmlTr);
    $('.ul-proceses').html(htmlProcesses);
}

var refreshProcess = function () {
    var id = $('#hdn-edit-auditprogram-id').val();

    page.get('/GetAudit?id=' + id).then(function (data) {
        populateProcesses(data);

    });
}

var populateAuditFinding = function (data) {
    $('.tbl-audit-finding').html('');
    var htmlAuditFinding = '';
    var ctr = 0;

    if (data.length != 0) {
        for (var i = 0; i < data.length; i++) {
            ctr++;
            htmlAuditFinding += '<tr>' +
                '<td class="w-5     text-center">' + ctr + '</td>' +
                '<td>' + data[i].Name + '</td>' +
                '<td>' + data[i].Description + '</td>' +
                '<td class="w-10 text-center">' +
                '<div class="btn-group" role="group">' +
                '<a href="javascript:void(0);" class="btn btn-sm btn-secondary btn-update-finding" data-id="' + data[i].Id + '" title="Edit"><i class="fa fa-edit"></i></a>' +
                '<a href="javascript:void(0);" class="btn btn-sm btn-danger btn-delete-finding" data-id="' + data[i].Id + '" title="Delete"><i class="fa fa-trash"></i></a>' +
                '</div>' +
                '</td>' +
                '</tr>';
        }
    } else {
        htmlAuditFinding = '<tr><td colspan="4">No information.</td></tr>'
    }
    

    $('.tbl-audit-finding').html(htmlAuditFinding);
}

var refreshAuditFinding = function () {

    var id = $('#hdn-audited-plan-id').val();

    $('#fld-new-finding-name').val('');
    $('#fld-new-finding-description').val('');

    page.get('/GetAllAuditFinding?id=' + id).then(function (data) {
        populateAuditFinding(data);

    });
}

var deleteAuditFinding = function (id) {
    page.get('/DeleteAuditFinding?id=' + id).then(function () {
        notify('Audit finding deleted', 'success');
        $('#mdl-confirm').modal('hide');
        refreshAuditFinding();
    });
}


var deleteProgram = function (id) {

    page.get('/DeleteProgram?id=' + id).then(function () {
        notify('Program deleted', 'success');
        done();
    });

}

var deleteManagementSystem = function (id) {
    page.get('/DeleteManagementSystem?id=' + id).then(function () {
        notify('Management System deleted', 'success');
        $('#mdl-confirm').modal('hide');
        $('#mdl-new-audit-mstypes').modal('show');
        refreshMSType();
    });
}

var deleteAuditProcess = function (id) {
    page.get('/DeleteAuditProcess?id=' + id).then(function () {
        notify('Process deleted', 'success');
        $('#mdl-confirm').modal('hide');
        $('#mdl-new-auditprogram-processes').modal('show');
        refreshProcess();
    });
}

var deleteAuditor = function (id) {
    page.get('/DeleteAuditor?id=' + id).then(function () {
        notify('Auditor deleted', 'success');
        $('#mdl-confirm').modal('hide');
        refreshAuditors();
    });
}

var deleteAuditPlan = function (id) {

    page.get('/DeleteAuditPlan?id=' + id).then(function () {
        notify('Audit plan deleted', 'success');
        done();
    });

}

var populateDetails = function (id) {

    var htmlFindings = '';
    var htmlInfo = '';

    htmlFindings += "";
    $('#tblItems tbody').append('<tbody>' + txt + '</tbody>');
   

}

var loadMSType = function () {
    if ($selectizeMSType != null) {
        return;
    }

    $selectizeMSType = $('.fld-ms-type').selectize({
        valueField: 'Id',
        searchField: 'Type',
        labelField: 'Type',
        placeholder: "MS Type",
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
                $('#fld-selected-mstype-id').val(item.Id);
                $('#fld-selected-mstype-type').val(item.Type);
            } else {
            }

        },
    });
}

var loadEditMSType = function () {
    if ($selectizeEditMSType != null) {
        return;
    }

    $selectizeEditMSType = $('.fld-edit-ms-type').selectize({
        valueField: 'Id',
        searchField: 'Type',
        labelField: 'Type',
        placeholder: "MS Type",
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

            } else {
            }

        },
    });
}

var loadAuditCategory = function () {
    if ($selectizeAuditCategory != null) {
        return;
    }

    $selectizeAuditCategory = $('.fld-audit-category').selectize({
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
                url: '/Setting/AuditCategory/GetAll',
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
                $('#fld-selected-audit-category').val(item.Name);
                $('#fld-selected-audit-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadEditAuditCategory = function () {
    if ($selectizeEditAuditCategory != null) {
        return;
    }

    $selectizeEditAuditCategory = $('.fld-edit-audit-category').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "Audit Category",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        load: function (query, callback) {
            $.ajax({
                url: '/Setting/AuditCategory/GetAll',
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
                $('#fld-selected-edit-audit-category').val(item.Name);
                $('#fld-selected-edit-audit-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadAuditLeader = function () {
    if ($selectizeAuditLeader != null) {
        return;
    }

    $selectizeAuditLeader = $('.fld-audit-leader').selectize({
        valueField: 'Id',
        searchField: 'Fullname',
        placeholder: "Audit Leader",
        labelField: 'Fullname',
        preload: true,
        create: true,
        sortField: {
            field: 'Fullname',
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
                $('#fld-selected-employee-id').val(item.Id);
                $('#fld-selected-employee-name').val(item.Fullname);
            } else {
            }

        },
    });
}

var loadEditAuditLeader = function () {
    if ($selectizeEditAuditLeader != null) {
        return;
    }

    $selectizeEditAuditLeader = $('.fld-edit-audit-leader').selectize({
        valueField: 'Id',
        searchField: 'Fullname',
        labelField: 'Fullname',
        placeholder: "Audit Leader",
        preload: true,
        create: true,
        sortField: {
            field: 'Fullname',
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

            } else {
            }

        },
    });
}

var loadMonths = function () {
    if ($selectizeMonths != null) {
        return;
    }

    $selectizeMonths = $('.fld-months').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "Months",
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
                $('#fld-selected-months').val(item.Id);
            } else {
            }

        },
    });
}
var loadYears = function () {
    if ($selectizeYears != null) {
        return;
    }

    $selectizeYears = $('.fld-years').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "Years",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {

            } else {
            }

        },
    });
}

var loadEditMonths = function () {
    if ($selectizeEditMonths != null) {
        return;
    }

    $selectizeEditMonths = $('.fld-edit-months').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "Months",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {

            } else {
            }

        },
    });
}

var loadEditYears = function () {
    if ($selectizeEditYears != null) {
        return;
    }

    $selectizeEditYears = $('.fld-edit-years').selectize({
        valueField: 'Id',
        searchField: 'Name',
        labelField: 'Name',
        placeholder: "Years",
        preload: true,
        create: true,
        sortField: {
            field: 'Name',
            direction: 'asc'
        },
        dropdownParent: 'body',
        onChange: function (value) {
            var item = $(this)[0].options[value];

            if (item) {

            } else {
            }

        },
    });
}

var loadAuditors = function () {
    if ($selectizeAuditors != null) {
        return;
    }

    $selectizeAuditors = $('.fld-auditors').selectize({
        valueField: 'Id',
        searchField: 'Fullname',
        placeholder: "Auditors",
        labelField: 'Fullname',
        preload: true,
        create: true,
        sortField: {
            field: 'Fullname',
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
                $('#fld-auditleader-id').val(item.Id);
                $('#fld-auditleader-name').val(item.Fullname);
            } else {
            }

        },
    });
}

var loadEditAuditors = function () {
    if ($selectizeEditAuditors != null) {
        return;
    }

    $selectizeEditAuditors = $('.fld-edit-auditors').selectize({
        valueField: 'Id',
        searchField: 'Fullname',
        labelField: 'Fullname',
        placeholder: "Auditors",
        preload: true,
        create: true,
        sortField: {
            field: 'Fullname',
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

            } else {
            }

        },
    });
}

var loadAuditProgram = function () {
    if ($selectizeAuditProgram != null) {
        return;
    }

    $selectizeAuditProgram = $('.fld-auditprogram-category').selectize({
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
                url: '/AuditManagement/InternalAudit/GetAuditPrograms',
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
                $('#fld-selected-auditplan-category').val(item.Name);
                $('#fld-selected-auditplan-id').val(item.Id);
            } else {
            }

        },
    });
}

var loadAuditProgramAudited = function () {
    if ($selectizeAudited != null) {
        return;
    }

    $selectizeAudited = $('.fld-audited').selectize({
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
                url: '/AuditManagement/InternalAudit/GetAuditPrograms',
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
                $('#dv-audited').addClass('d-none');
                var htmlAuditPlans = '';

                page.get('/GetAllAudited?id=' + item.Id).then(function (data) {
                    var d = _.sortBy(data.AuditPlans, 'CreatedAt');
                    var htmlAuditPlanContent = '';
                    var status = '';
                    if (d.length != 0) {
                        for (var i = 0; i < d.length; i++) {
                            if (d[i].Tag == 2) {
                                status = 'Audited';
                                htmlAuditPlanContent += '<li class="list-group-item audit-item" data-id="'+ d[i].Id  +'" ><strong>' + d[i].Name + '</strong><br />' + '<em class="text-success">' + status + '</em></li>';
                            }
                        }
                    } else {
                        htmlAuditPlanContent = '<li class="list-group-item"> No record. </li>';
                    }

                    $('.ul-audited').html(htmlAuditPlanContent);
                });

            } else {
            }

        },
    });
}