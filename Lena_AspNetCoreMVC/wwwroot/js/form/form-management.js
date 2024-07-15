
$(document).ready(function () {

    var $form = $("#add-modal-form");

    $('#table-name-search-input').on('keyup', function () {
        var value = $(this).val().toLowerCase();
        $('#form-table tbody tr').filter(function () {
            var nameText = $(this).data('table-name').toLowerCase();
            $(this).toggle(nameText.startsWith(value));
        });
    });


    $('#add-new-form-btn').on('click', function () {
        $('#form-create-modal').modal('show');
    });

    
    $form.on("submit", function (e) {
        e.preventDefault();

        $.validator.unobtrusive.parse($form);

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
                            title: "Adding Form Failed!",
                            text: response.errorMessage,
                            icon: "error",
                            showConfirmButton: true
                        });
                    }
                    else {
                        Swal.fire({
                            position: "top-end",
                            title: "Data Added Successfully!",
                            icon: "success",
                            showConfirmButton: false,
                            timer: 3000
                        });


                        const formTable = document.getElementById('form-table');

                        const form = response.data;

                        formTable.innerHTML +=
                            `<tr data-table-name="${form.name}">
                                <td>${form.id}</td>
                                <td>${form.name}</td>
                                <td>${form.description}</td>
                                <td>${formatDate(form.createdAt)}</td>
                                <td>${form.createdBy}</td>
                                <td>
                                    <a href="/forms/${form.id}" class="btn btn-primary">Show</a>
                                </td>
                            </tr>`;

                        $('#form-create-modal').modal('hide');
                    }
                }
            });
        }

        return false;
    });

    function formatDate(dateString) {
        const date = new Date(dateString);

        const day = String(date.getDate()).padStart(2, '0');
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const year = date.getFullYear();
        const hours = String(date.getHours()).padStart(2, '0');
        const minutes = String(date.getMinutes()).padStart(2, '0');
        const seconds = String(date.getSeconds()).padStart(2, '0');

        return `${day}.${month}.${year} ${hours}:${minutes}:${seconds}`;
    }
});