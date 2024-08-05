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
