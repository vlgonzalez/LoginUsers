Documentação - Aplicação ASP.NET MVC (.NET 8)
Projeto Tela de Login
Objetivo
Este projeto ASP.NET MVC tem como objetivo a gestão de usuários, oferecendo funcionalidades como registro, login, edição, redefinição de senha e gerenciamento completo de usuários. Ele é desenvolvido com o .NET 8 e ASP.NET Core, utilizando uma arquitetura em camadas para organizar controllers, views, view models e serviços.

Funcionalidades Principais
1. Registro de Usuário
Controller: AccountController
Método GET Register: Exibe o formulário de registro.
Método POST Register: Processa o registro do usuário, validando os dados e, em caso de sucesso, realiza login automático.
ViewModel: RegisterVM
Define os campos e validações necessárias para o registro (Nome, Email, Senha, Confirmação de Senha).
View: Register.cshtml
Formulário de registro para o usuário.
Serviço: AccountService
Lida com a criação do usuário e outros processos relacionados à autenticação.
Fluxo de Registro:

O usuário acessa o formulário de registro.
Os dados são validados e, caso estejam corretos, o usuário é criado.
O sistema realiza login automático e redireciona para a página inicial.
2. Login
Controller: AccountController
Método GET Login: Exibe o formulário de login.
Método POST Login: Processa o login do usuário e redireciona conforme a URL de retorno.
ViewModel: LoginVM
Campos de email, senha e opção de "Lembrar-me".
View: Login.cshtml
Formulário de login para o usuário.
Serviço: AccountService
Responsável pela autenticação utilizando o SignInManager do ASP.NET Core Identity.
Fluxo de Login:

O usuário insere as credenciais e submete o formulário.
Caso a autenticação seja bem-sucedida, o usuário é redirecionado para a URL solicitada ou a página inicial.
3. Esqueceu a Senha
Controller: AccountController
Método GET/POST ForgotPassword: Lida com o fluxo de redefinição de senha.
ViewModel: ForgotPasswordVM
Define o campo de email para recuperação de senha.
View: ForgotPassword.cshtml
Formulário para o usuário inserir o email cadastrado.
Serviço: AccountService
Envia um email ao usuário com uma nova senha gerada.
Fluxo de Redefinição de Senha:

O usuário solicita a redefinição de senha.
O sistema verifica o email e, caso encontrado, envia uma nova senha por email.
4. Tela de Login Sucesso
Após o login, o usuário é redirecionado para uma página inicial, que exibe uma mensagem de boas-vindas personalizada e permite navegação para outras funcionalidades, como a lista de usuários ou logout.

5. Lista de Usuários
API Controller: Expõe um endpoint GetUsers() para retornar a lista de usuários.
HomeController: Utiliza o método ListUsers() para renderizar a lista de usuários.
ViewModel: ListUsersVM
Contém uma lista de usuários e mensagens para feedback.
View: ListUsers.cshtml
Exibe os usuários em uma tabela com opções para editar ou deletar.
Fluxo:

A página exibe a lista de usuários.
O administrador pode editar ou excluir usuários, utilizando modais de confirmação para a exclusão.
6. Editar Usuários
API Controller:
Métodos EditUser e UpdateUser para editar as informações de um usuário.
HomeController: Método EditUser para carregar os dados do usuário e exibir na view.
ViewModel: EditUserVM
Dados do usuário como ID, nome e email.
View: EditUser.cshtml
Formulário para edição de dados do usuário.
Serviço: AccountService
Lida com a busca e atualização dos dados no banco de dados.
7. Deletar Usuários
API Controller: Método Delete para excluir um usuário.
HomeController: Utiliza modais de confirmação para garantir que a exclusão é intencional.
View: Modal de confirmação antes da exclusão definitiva do usuário.
Requisitos
.NET 8
ASP.NET Core Identity
Entity Framework Core para interação com o banco de dados
Instalação
Clone o repositório: git clone https://github.com/seu-repositorio/projeto-aspnet-mvc.git
Configure as variáveis de ambiente para conexão com o banco de dados e o SMTP para envio de emails.
Restaure os pacotes NuGet: dotnet restore
Execute a aplicação: dotnet run
Contribuição
Sinta-se à vontade para abrir issues ou enviar pull requests.# Projetos
