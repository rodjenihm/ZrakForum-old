$(document).ready(function () {
    if (loginError !== null && loginError !== '') {
        toastr.error(loginError);
    }
});