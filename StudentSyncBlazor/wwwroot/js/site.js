


function showModal(modalId) {
    var modal = new bootstrap.Modal(document.getElementById(modalId));
    modal.show();
}

function hideModal(modalId) {
    var modal = bootstrap.Modal.getInstance(document.getElementById(modalId));
    if (modal) {
        modal.hide();
    }

}

function ShowModal(modalId) {
    $('#' + modalId).modal('show');
}

function HideModal(modalId) {
    $('#' + modalId).modal('hide');
}
function showSuccess(message) {
    toastr.success(message, "Success", { positionClass: "toast-bottom-center" });
}

function showError(message) {
    toastr.error(message, "Error", { positionClass: "toast-bottom-center" });
}

function showInfo(message) {
    toastr.info(message, "Info", { positionClass: "toast-bottom-center" });
}

function showWarning(message) {
    toastr.warning(message, "Warning", { positionClass: "toast-bottom-center" });
}

function showModal(modalId) {
    $(`#${modalId}`).modal('show');
}

function hideModal(modalId) {
    $(`#${modalId}`).modal('hide');
}


// wwwroot/js/site.js
$(document).ready(function () {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-bottom-center", // Positioning here
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
});
