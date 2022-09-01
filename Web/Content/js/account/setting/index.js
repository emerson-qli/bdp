var page = new Page("/Account/Setting");

$(function () {

    $(document).on('click', '#btn-save', function () {

        var validation = page.validate('#bdy', 'User');

        if (validation.Valid) {
            page.save(validation.Entity, '/UpdateUser', $('#btn-save'), 'Updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }
    });

});

var done = function () {
    setTimeout(
        function () {
            location.href = '/Account/Login';
        }, 1000);
}

