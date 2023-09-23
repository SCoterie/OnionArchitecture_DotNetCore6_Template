// Validation form
$(function () {

    // password validation regex
    var passValue = $('#password').val();
    $.validator.addMethod("pwcheck", function (passValue) {
        return /^[A-Za-z0-9\d=!\-@._*]*$/.test(passValue) && /[a-z]/.test(passValue) && /\d/.test(passValue) && /[A-Z]/.test(passValue);
    });

    // email validator regex
    var emailValue = $('#email').val();
    $.validator.addMethod("emailExt", function (emailValue) {
        return emailValue.match(/^[a-zA-Z0-9_\.%\+\-]+@[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,}$/);
    });

    // form validation rules
    var val = $('#loginFormId').validate({
        rules: {
            email: {
                email: true,
                required: true,
                emailExt: true
            },
            password: {
                required: true,
                minlength: 6,
                pwcheck: true
            }
        },
        messages: {

            email: {
                required: "Please enter email address",
                emailExt: "Email address is incorrect"
            },
            password: {
                required: "Please enter password",
                minlength: "Password must be 6 characters",
                pwcheck: "Password should be contain alpha-numeric & special characters"
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-outline').append(error);
            $('.input-group').attr('style', 'margin-bottom:1.9rem !important;');
            $('.ph').attr('style', 'margin-bottom:1rem !important;');
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });

    // form submit functionality
    $('#btnSubmit').click(function () {
        // when submit form $("#phone1").val().replace(/\s+/g, '');
        if ($('#loginFormId').valid()) {
            $('#loginFormId').submit();
        }
        else {
            val.focusInvalid();
        }
    });
});

// password eye button
$("#togglePassword").on('click', function (event) {
    event.preventDefault();
    if ($('#password').attr("type") == "password") {
        $('#password').attr('type', 'text');
        $('#togglePassword').addClass("fa-eye");
        $('#togglePassword').removeClass("fa-eye-slash");
    } else if ($('#password').attr("type") == "text") {
        $('#password').attr('type', 'password');
        $('#togglePassword').removeClass("fa-eye");
        $('#togglePassword').addClass("fa-eye-slash");
    }
});
