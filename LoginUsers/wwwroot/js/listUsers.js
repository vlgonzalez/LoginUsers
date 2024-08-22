document.addEventListener("DOMContentLoaded", function () {
    async function loadUsers() {
        try {
            const response = await fetch('/api/users');
            if (!response.ok) throw new Error('Erro ao carregar usuários.');

            const users = await response.json();
            const tableBody = document.getElementById('usersTableBody');
            tableBody.innerHTML = '';

            if (users.length === 0) {
                tableBody.innerHTML = '<tr><td colspan="3">Nenhum usuário encontrado.</td></tr>';
                return;
            }

            users.forEach(user => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${user.name}</td>
                    <td>${user.email}</td>
                    <td class="actions">
                        <a href="/Home/EditUser?email=${user.email}" class="btn btn-success btn-sm">Editar</a>
                        <button class="btn btn-danger btn-sm delete" data-email="${user.email}" data-name="${user.name}">
                            <i class="glyphicon glyphicon-trash"></i> Deletar
                        </button>
                    </td>
                `;
                tableBody.appendChild(row);
            });

            attachDeleteEventHandlers(); // Chama a função para adicionar eventos de deleção
        } catch (error) {
            console.error('Erro ao carregar usuários:', error);
            document.getElementById('usersTableBody').innerHTML = '<tr><td colspan="3">Erro ao carregar usuários.</td></tr>';
        }
    }

    function attachDeleteEventHandlers() {
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

        // Garantir que o botão "Cancelar" fecha a modal
        $('#deleteConfirmationModal').on('hidden.bs.modal', function () {
            emailToDelete = null; // Limpar o email para evitar exclusão acidental
        });
    }

    loadUsers(); // Carrega a lista de usuários quando a página é carregada
});
