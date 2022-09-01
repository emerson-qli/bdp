

$(function () {

    loadMenuActive();

    $('.fld-date').datepicker();

    $('.vw-date').each(function () {
        $(this).html(moment($(this).html()).format('MM/DD/YYYY'));
    })

    var d = $('.fld-date').val();
    if (d == '1/1/0001' || d == '') {
        $('.fld-date').val('');
    } else {
        $('.fld-date').val(moment(d).format('MM/DD/YYYY'));
    }
    var cPage = new Page("/Account/Login");
    cPage.get('/GetCurrentUser').then(function (data) {

        console.log(data);

    });

    cPage.get('/GetEmployeePhoto').then(function (data) {
        $('#dv-employee-photo').html('<img class="img-profile rounded-circle" src="/content/files/' + data + '">');
    });

    $(document).on('click', '.dv-alert-item', function () {

        var cPage = new Page("/Account/Login");
        var id = $(this).data('id');
        cPage.get('/ReadNotifcation/' + id).then(function () {});

    });

    getNotifications();

})

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
        theme: 'colorful',
        delay: 6000
    });

}

var showConfirm = function (msg, callback, id) {

    $('#mdl-confirm').modal('show');
    $('#mdl-confirm').find('p.p-message').html(msg);
    $('#mdl-confirm').find('#btn-confirm-proceed').off().on('click', function () {
        callback(id);
    });

}

var getNotifications = function () {

    var cPage = new Page("/Account/Login");
    var html = '';
    cPage.get('/GetNotifications').then(function (data) {

        var count = data.Notifications.length;
        var d     = data.Notifications;
        for (var i = 0; i < count; i++) {
            var readClass = (d[i].Tag == 0) ? 'dv-alert-item unread' : '';
            html += '<a class="dropdown-item d-flex align-items-center ' + readClass + '" href="' + d[i].Link + '" data-id="' + d[i].Id + '">' +
                        '<div class="mr-3">' +
                            '<div class="icon-circle bg-primary">' +
                                '<i class="fas fa-file-alt text-white"></i>' +
                            '</div>' +
                        '</div>' +
                        '<div>' +
                            '<div class="small font-weight-bold">' + moment(d[i].CreatedAt).format('MM/DD/YYYY hh:mm A') + '</div>' +
                            '<span class="font-weight-bold">' + d[i].Description + '!</span>' +
                        '</div>' +
                    '</a>';
        }

        if (data.Count > 0) {
            $('.badge-counter').html(data.Count);
        }
        $('#dv-alerts').html(html);

    });


}

var loadMenuActive = function () {

    $('.collapse-item').each(function () {
        var loc = location.pathname.split('/');
        var locmenu = 'http://localhost:9292' + loc[0] + '/' + loc[1] + '/' + loc[2];

        if (this.href == locmenu) {
            $(this).toggleClass("active");
        }
    });
}