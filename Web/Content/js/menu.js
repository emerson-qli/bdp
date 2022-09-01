

$(document).ready(function () {

    var loc = location.pathname.split('/');
    var area = loc[1];

    $('.nav-item').each(function () {

        if ($(this).data('area') == area) {
            var acc = $(this).data('accordion');
            $('#' + acc).addClass('show');
            $(this).addClass('active');
        } else {
            $(this).removeClass('active');
        }

    });

    $(document).on('click', '#sidebarToggle', function () {

        if ($('.sidebar-brand-text').css('display') == 'none') {
            $('.dv-menu-logo-collapse').removeClass('d-none');
            $('.dv-menu-logo').addClass('d-none');
        } else {
            $('.dv-menu-logo-collapse').addClass('d-none');
            $('.dv-menu-logo').removeClass('d-none');
        }
    });

});
