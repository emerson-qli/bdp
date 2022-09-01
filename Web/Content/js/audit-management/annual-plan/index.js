
$(function () {

    if (window.location.hash) {
        $("a[href='" + window.location.hash + "']").tab('show');
    } else {
        $("a[href='#nav-by-auditor']").tab('show');
    }
    $(document).on('click', '.nav-item', function () {
        var hash = $(this).data('hash');
        if (hash) {
            location.href = '/AuditManagement/AnnualPlans' + hash;
        }
    })

    $('#tbl-auditors').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $('#tbl-audits').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });
});