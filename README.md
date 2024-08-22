# Aplicação ASP.NET MVC (.NET 8) - Tela de Login

## Objetivo

Este projeto ASP.NET MVC tem como objetivo a gestão de usuários, com funcionalidades de registro, login, edição e redefinição de senha.

## Estrutura do Projeto

- **ASP.NET Core** (MVC Pattern)
- **.NET 8**
- **Identity Framework** para autenticação e autorização de usuários.
- **AccountService** para a lógica de negócios de gestão de usuários.

---

## Funcionalidades

### 1. Registro de Usuário

#### Estrutura do Código:
- **Controller**: `AccountController`
  - Ações responsáveis pela exibição e submissão do formulário de registro.
- **ViewModel**: `RegisterVM`
  - Define os campos e validações necessárias para o registro.
- **View**: `Register.cshtml`
  - Exibe o formulário de registro.
- **Serviço**: `AccountService`
  - Responsável pela criação do usuário e processos de autenticação.

#### Fluxo de Registro:
1. O usuário acessa a página de registro e preenche o formulário.
2. O `AccountController` valida os dados e chama o `AccountService` para criar o usuário.
3. Após o registro bem-sucedido, o usuário é autenticado automaticamente e redirecionado.

---

### 2. Login

#### Estrutura do Código:
- **Controller**: `AccountController`
  - Gerencia a exibição do formulário de login e a autenticação do usuário.
- **ViewModel**: `LoginVM`
  - Contém campos como email, senha e a opção de "Lembrar-me".
- **View**: `Login.cshtml`
  - Exibe o formulário de login.
- **Serviço**: `AccountService`
  - Lida com a autenticação usando o `SignInManager` do ASP.NET Core Identity.

#### Fluxo de Login:
1. O usuário acessa a página de login e insere suas credenciais.
2. O `AccountService` autentica o usuário.
3. Após o login, o usuário é redirecionado para a página inicial ou URL de retorno.

---

### 3. Esqueceu a Senha

#### Componentes:
- **Controller**: `AccountController`
  - Exibe o formulário para recuperação de senha e lida com o envio do email.
- **ViewModel**: `ForgotPasswordVM`
  - Define o campo de email para validação.
- **Serviço**: `AccountService`
  - Responsável por gerar a senha temporária e enviar por email.

#### Fluxo:
1. O usuário insere seu email na página de recuperação de senha.
2. O sistema gera uma nova senha e a envia por email.
3. O usuário usa a nova senha para realizar login.

---

### 4. Página Inicial (Login Sucesso)

- **Autenticação**: Verifica se o usuário está autenticado e exibe uma mensagem de boas-vindas.
- **Navegação**: Oferece opção para o usuário acessar a lista de usuários cadastrados no sistema.

---

### 5. Lista de Usuários

#### Componentes:
- **API Controller**: Um endpoint `GetUsers()` retorna a lista de usuários.
- **HomeController**: O método `ListUsers()` busca a lista de usuários e a exibe na view.
- **ViewModel**: `ListUsersVM` encapsula uma lista de usuários.
- **View**: `ListUsers.cshtml` exibe a tabela com ações para editar e excluir usuários.

#### Funcionalidades:
1. Exibe uma lista de usuários cadastrados.
2. Permite editar ou excluir um usuário.

---

### 6. Editar Usuário

#### Componentes:
- **API Controller**: 
  - Endpoint `EditUser` para obter as informações de um usuário.
  - Endpoint `UpdateUser` para atualizar as informações.
- **ViewModel**: `EditUserVM` define os campos editáveis.
- **View**: `EditUser.cshtml` permite ao administrador editar os dados do usuário.
- **Serviço**: `AccountService` lida com a atualização do usuário.

#### Funcionalidades:
1. Permite a edição dos dados do usuário.
2. Valida os campos e salva as alterações no banco de dados.

---

### 7. Deletar Usuário

#### Componentes:
- **API Controller**: 
  - Endpoint `DeleteUser` para remover um usuário.
- **Modal de Confirmação**: Exibe um modal antes de deletar o usuário.
- **HomeController**: Chama o serviço de deletar e retorna à lista de usuários.

#### Fluxo:
1. O administrador clica para deletar um usuário.
2. Um modal de confirmação é exibido.
3. Após confirmação, o usuário é removido do banco de dados.

---

## Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-repositorio.git
