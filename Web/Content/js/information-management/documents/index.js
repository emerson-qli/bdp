var page = new Page("/InformationManagement/Documents");
$(function () {

    $('#tbl-list').DataTable({
        "bFilter": true,
        "bInfo": false,
        "bLengthChange": true,
        language: { search: '', searchPlaceholder: "Search..." },
        oLanguage: {
            sLengthMenu: "_MENU_",
        }
    });

    $(document).on('click', '.btn-view', function () {
        var id = $(this).data('id');
        location.href = '/InformationManagement/DocumentRequests/View/' + id
    });

});


