
jQuery(document).ready(function ($) {

    bgLoad();

    $(window).on('resize', function () {
        location.reload();
    });

    $(document).on('click', '.btn-login', function () {
        $.ajax({
            type: "POST",
            url: '/account/login/index',
            data: {
                'Email': $('#fld-email').val(),
                'Password': $('#fld-password').val()
            },
            context: document.body,
            dataType: 'json',
        }).done(function (data) {
            notify("Authenticated", 'info');
            location.href = data.Direction;
        }).fail(function (data) {
            notify("Username/Password is incorrect", 'error');
        });
    });


    $('.fld-security-code').keyup(function () {
        if (this.value.length == 1) {
            $(this).next('.fld-security-code').focus();
        }
    });

});


var notify = function (msg, type) {

    var color = '#5fbae9'

    if (type == 'error') {
        color = '#de2a2a';
    } else if ('success') {
        color = '#4ed179';
    }

    $.amaran({
        content: {
            bgcolor: color,
            color: '#fff',
            message: msg,
        },
        position: "bottom left",
        'sticky': true,
        theme: 'colorful'
    });


}

var bgLoad = function () {
    var mobile = (/iphone|ipod|android|blackberry|mini|windows\sce|palm/i.test(navigator.userAgent.toLowerCase()));
    if (mobile) {
        $('#dv-bg-1').hide();
        $('#dv-bg-2').hide();
    }
    else {
        $('#dv-bg-2').hide();
        showDiv1();
    }
}

var showDiv1 = function () {
    $('#dv-bg-1').show();
    setTimeout(function () { $('#dv-bg-1').hide(); showDiv2() }, 5000);
} 


var showDiv2 = function () {
    $('#dv-bg-2').show();
    setTimeout(function () { $('#dv-bg-2').hide(); showDiv1() }, 5000);
}

