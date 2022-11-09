// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Password confirm
$('#password, #confirm_password').on('keyup', function () {
    if ($('#password').val() == $('#confirm_password').val()) {
        $('#message_password').html('').css('color', 'green'),
            $('#confirm_btn').prop('disabled', false);
    } else
        $('#message_password').html('As senhas não são iguais').css('color', 'red'),
            $('#confirm_btn').prop('disabled', true);
});
