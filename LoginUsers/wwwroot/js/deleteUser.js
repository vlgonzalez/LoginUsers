$(document).ready(function () {
    var emailToDelete;

    // Abrir modal de confirmação ao clicar em deletar
    $(document).on('click', '.delete', function () {
        emailToDelete = $(this).data("email");
        var userNameToDelete = $(this).data("name");
        $("#userNameToDelete").text(userNameToDelete);
        $("#deleteConfirmationModal").modal("show");
    });

    // Deletar o usuário se confirmado
    $('#confirmDeleteButton').on('click', function () {
        $.ajax({
            url: '/api/users/Delete/' + emailToDelete,
            type: 'DELETE',
            success: function (result) {
                if (result.success) {
                    location.reload(); // Recarrega a página
                } else {
                    alert('Erro ao deletar usuário.');
                }
            },
            error: function () {
                alert('Erro ao processar a solicitação.');
            }
        });
    });
});
