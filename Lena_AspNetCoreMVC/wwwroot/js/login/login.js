var $form = $("#LoginForm");
$.validator.unobtrusive.parse($form);
$form.on("submit", function (e) {
    e.preventDefault();
    var formData = new FormData(this);

    if ($form.valid()) {

        $.ajax({
            url: this.action,
            type: this.method,
            data: formData,
            contentType: false,
            processData: false,
            dataType: "json",
            success: function (response) {
                if (response.isSuccess == false) {
                    Swal.fire({
                        position: "top-end",
                        title: "Login Failed!",
                        text: response.errorMessage,
                        icon: "error",
                        showConfirmButton: true
                    });
                }
                else {
                    Swal.fire({
                        position: "top-end",
                        title: "Login Success!",
                        icon: "success",
                        showConfirmButton: false,
                        timer: 2000
                    });

                    window.location.href = response.data;
                }
            }
        });
    }

    return false;
});