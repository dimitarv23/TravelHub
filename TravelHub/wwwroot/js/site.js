function fireSweetAlert(id, entity) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
        if (result.isConfirmed) {
            debugger;
            const baseUrl = window.location.origin;
            const deleteUrl = `${baseUrl}/${entity}s/Delete?${entity}Id=${id}`;
            fetch(deleteUrl, {
                method: 'POST'
            }).then((response) => {
                if (response.ok) {
                    Swal.fire(
                        'Deleted!',
                        'Deleted successfully.',
                        'success'
                    ).then(() => {
                        window.location.href = `${baseUrl}/${entity}s/All`;
                    });
                } else {
                    Swal.fire(
                        'Error!',
                        'Failed to delete.',
                        'error'
                    );
                }
            }).catch(() => {
                Swal.fire(
                    'Error!',
                    'Failed to delete.',
                    'error'
                );
            });
        }
    });
}