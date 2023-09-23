

$(function () {

    // initialize country code with mobile input
    $("#mobile").intlTelInput({
        initialCountry: "in",
        separateDialCode: true,
        preferredCountries: ["in"],
        autoPlaceholder: "polite",
        formatOnDisplay: true,
        onlyCountries: ["in"],
        allowDropdown: false,
        utilsScript: "../../plugins/tel-input/tel_input_utils.js"
        //geoIpLookup: function (callback) {
        //    $.get('https://ipinfo.io', function () {
        //    }, "jsonp").always(function (resp) {
        //        var countryCode = (resp && resp.country) ? resp.country : "";
        //        callback(countryCode);
        //    });
        //},
    });
     
    // password validation regex
    var passValue = $('#password').val();
    $.validator.addMethod("pwcheck", function (passValue) {
        return /^[A-Za-z0-9\d=!\-@._*]*$/.test(passValue) && /[a-z]/.test(passValue) && /\d/.test(passValue) && /[A-Z]/.test(passValue);
    });

    // confirm password validation regex
    var cnfpassValue = $('#cnfpassword').val();
    $.validator.addMethod("cnfpwcheck", function (cnfpassValue) {
        return /^[A-Za-z0-9\d=!\-@._*]*$/.test(cnfpassValue) && /[a-z]/.test(cnfpassValue) && /\d/.test(cnfpassValue) && /[A-Z]/.test(cnfpassValue);
    });

    // email validator regex
    var emailValue = $('#email').val();
    $.validator.addMethod("emailExt", function (emailValue) {
        return emailValue.match(/^[a-zA-Z0-9_\.%\+\-]+@[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,}$/);
    });

    // form validation rules
    var val = $('#registerFormId').validate({
        rules: {
            FirstName: {
                required: true
            },
            LastName: {
                required: true
            },
            Mobile: {
                required: true,
                minlength: 10,
                maxlength: 10
            },
            Email: {
                email: true,
                required: true,
                emailExt: true
            },

            Password: {
                required: true,
                minlength: 6,
                pwcheck: true
            },
            CnfPassword: {
                required: true,
                minlength: 6,
                cnfpwcheck: true,
                equalTo: "#password"

            },
        },
        messages: {
            FirstName: {
                required: "Please enter first name"
            },
            LastName: {
                required: "Please enter last name"
            },
            Mobile: {
                required: "Please enter phone number",
                minlength: "Phone number must be 10 digits",
                maxlength: "Phone number is incorrect"
            },
            Email: {
                required: "Please enter email address",
                emailExt: "Email address is incorrect"
            },
            Password: {
                required: "Please enter password",
                minlength: "Password must be 6 characters",
                pwcheck: "Password should be contain alpha-numeric & special characters"
            },
            CnfPassword: {
                required: "Please enter confirm password",
                minlength: "Confirm password must be 6 characters",
                cnfpwcheck: "Confirm password should be contain alpha-numeric & special characters",
                equalTo: "Confirm password is not matched"
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
            PhoneNumberValidation(element);
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
            PhoneNumberValidation(element);
        }
    });

    // form submit functionality
    $('#btnSubmit').click(function () {
        // when submit form $("#phone1").val().replace(/\s+/g, '');
        if ($('#registerFormId').valid()) {
            $('#registerFormId').submit();
        }
        else {
            val.focusInvalid();
        }
    });
});

// phone number validation
function PhoneNumberValidation(element) {
    if (element.id == "mobile") {
        if (element.value == "" || element.value.length < 10 || element.value.length > 10) {
            $('.intl-tel-input').addClass('tel-input-is-invalid');
            $(element).addClass("validation-placeholder");
        }
        else {
            $('.intl-tel-input').removeClass('tel-input-is-invalid');
        }
    }
}

//mobile number input only numeric
document.getElementById('mobile').addEventListener('input', function (event) {
    event.target.value = event.target.value.replace(/\D/g, '');
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

// confirm password eye button
$("#toggleCnfPassword").on('click', function (event) {
    event.preventDefault();
    if ($('#cnfpassword').attr("type") == "password") {
        $('#cnfpassword').attr('type', 'text');
        $('#toggleCnfPassword').addClass("fa-eye");
        $('#toggleCnfPassword').removeClass("fa-eye-slash");
    } else if ($('#cnfpassword').attr("type") == "text") {
        $('#cnfpassword').attr('type', 'password');
        $('#toggleCnfPassword').removeClass("fa-eye");
        $('#toggleCnfPassword').addClass("fa-eye-slash");
    }
});
