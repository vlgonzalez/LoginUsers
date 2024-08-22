document.addEventListener("DOMContentLoaded", function () {
    const saveButton = document.getElementById("saveButton");

    saveButton.addEventListener("click", async function () {
        const userId = document.getElementById("userId").value;
        const name = document.getElementById("name").value;
        const email = document.getElementById("email").value;

        // Clear previous errors
        document.getElementById("nameError").textContent = "";
        document.getElementById("emailError").textContent = "";

        // Validate input
        if (!name || !email) {
            if (!name) document.getElementById("nameError").textContent = "Nome é obrigatório.";
            if (!email) document.getElementById("emailError").textContent = "Email é obrigatório.";
            return;
        }

        try {
            const response = await fetch(`/api/users/${userId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ id: userId, name: name, email: email }),
            });

            if (response.ok) {
                // Redirect to ListUsers after successful update
                window.location.href = '/Home/ListUsers';
            } else {
                const errorData = await response.json();
                alert("Erro ao atualizar usuário: " + errorData.message);
            }
        } catch (error) {
            console.error("Erro ao comunicar com a API: ", error);
        }
    });
});
