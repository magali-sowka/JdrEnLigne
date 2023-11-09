function Remove(url) {
    Swal.fire({
        title: 'Êtes-vous sûr(e)?',
        text: "Cette action est irréversible.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Oui',
        allowOutsideClick: false,
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'POST',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    Swal.fire(
                        'Réussite',
                        result.messsage,
                        'success');
                    $.ajax({
                        url: result.html,
                        type: 'GET'
                    }).done(function (result) {
                        $("#joueursDetails").html(result);
                    });
                }
            })
        }
    })
}