//Register functionality
document.addEventListener("DOMContentLoaded", function () {
    var passwordToggle = document.getElementById("showPasswordToggle");
    var confirmPasswordToggle = document.getElementById("showConfirmPasswordToggle");

    passwordToggle.addEventListener("click", function () {
        var passwordInput = document.getElementById(passwordToggle.dataset.target);
        togglePasswordVisibility(passwordInput, passwordToggle);
    });

    confirmPasswordToggle.addEventListener("click", function () {
        var confirmPasswordInput = document.getElementById(confirmPasswordToggle.dataset.target);
        togglePasswordVisibility(confirmPasswordInput, confirmPasswordToggle);
    });

    function togglePasswordVisibility(input, toggle) {
        if (input.type === "password") {
            input.type = "text";
            toggle.innerHTML = ' <i class="far fa-eye-slash"></i>Hide';
        } else {
            input.type = "password";
            toggle.innerHTML = ' <i class="far fa-eye"></i>Show';
        }
    }
});

//Shopping cart Icon
var cartIcon = document.getElementById("cart-icon");

cartIcon.addEventListener("mouseenter", function () {
    cartIcon.classList.add("fa-cart-shopping-animation");
});

cartIcon.addEventListener("mouseleave", function () {
    cartIcon.classList.remove("fa-cart-shopping-animation");
});


//Account Icon
var accountIcon = document.getElementById('accountIcon');

accountIcon.addEventListener('mouseenter', function () {
    accountIcon.classList.add('rotate-animation');
});

accountIcon.addEventListener('mouseleave', function () {
    accountIcon.classList.remove('rotate-animation');
});