$(document).ready(function () {
    $(function () {
        $('.get-modal').click(function () {
            var url = '/Home/Contact';
            $.get(url, function (data) {
                $('#contact-modal-container').html(data);
                $('#displayModal').modal('show');
            })

        });
    });

    $('form[data-async]').submit(function (event) {
        event.preventDefault();
        var $form = $(this);
        var $target = $($form.attr('data-target'));

        $.ajax({
            type: $form.method,
            url: $form.action,
            data: $form.serialize(),

            success: function (result) {
                if (result.success) {
                    $('#displayModal').modal('hide');
                    location.reload();
                }

            }
        })
        ;
        return false;
    });

});