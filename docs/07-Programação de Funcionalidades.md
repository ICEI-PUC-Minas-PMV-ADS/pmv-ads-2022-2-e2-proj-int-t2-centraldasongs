# Programação de Funcionalidades

## Tela Home

*inserir imagem*

### Requisitos

- RF-003 - O sistema permitirá que os usuários criados efetuem login.

### Artefatos Produzidos
- HomeController.cs
- Index.cshtml
- Privacy.cshtml

## Tela "Sou uma ONG"

*inserir imagem*

### Requisitos

- RF-003 - O sistema permitirá que os usuários criados efetuem login.

### Artefatos Produzidos

- UserModel.cs
- UserONGModel.cs
- UserType.cs
- ErrorViewModel.cs
- LoginController.cs
- Index.cshtml
- Login.cshtml

## Tela "Sou Voluntário"

*inserir imagem*

### Requisitos

- RF-003 - O sistema permitirá que os usuários criados efetuem login.

### Artefatos Produzidos

- UserModel.cs
- UserVoluntarioModel.cs
- UserType.cs
- ErrorViewModel.cs
- LoginController.cs
- Index.cshtml
- Login.cshtml

## Tela de Cadastro de ONG

*inserir imagem*

### Requisitos

- RF-001 - O sistema permitirá cadastro de usuários gestores de ONG.
- RF-006 - O sistema deve verificar se o usuário já foi cadastrado.
- RF-010 - O usuário Gestor das ONGs poderá inserir informações para doações.
- RF-011 -	O usuário Gestor das ONGs poderá descrever as atividades da sua ONG.

### Artefatos Produzidos

- UserController.cs
- AddressModel.cs
- bankAccountModel.cs
- BankModel.cs
- StateModel.cs
- UserModel.cs
- UserONGModel.cs
- UserType.cs
- Create.cshtml

## Tela de Cadastro de Voluntário

*inserir imagem*

### Requisitos

- RF-002 - O sistema permitirá cadastro de usuários voluntários/doadores.
- RF-006 - O sistema deve verificar se o usuário já foi cadastrado.

### Artefatos Produzidos

- UserController.cs
- AddressModel.cs
- StateModel.cs
- UserModel.cs
- UserVoluntarioModel.cs
- UserType.cs
- Create.cshtml

## Tela de Recuperação de Senha do Usuário da ONG

Essa tela permite a recuperação da senha do cadastro de uma ONG.

*inserir imagem*

### Requisitos

- RF-005 - O sistema deve permitir que o usuário cadastre uma nova senha caso ele esqueça a atual.

### Artefatos Produzidos

- ONGController.cs
- UserONGModel.cs
- ForgotPassword.cshtml
- UpdatePassword.cshtml

## Tela de Recuperação de Senha do Usuário do Voluntário

Essa tela permite a recuperação da senha do cadastro de um usuário.

*inserir imagem*

### Requisitos

- RF-005 - O sistema deve permitir que o usuário cadastre uma nova senha caso ele esqueça a atual.

### Artefatos Produzidos

- VoluntarioController.cs
- UserVoluntarioModel.cs
- ForgotPassword.cshtml
- UpdatePassword.cshtml

## Tela de Informações do Cadastro da ONG

Essa tela permite a visualização das informações de cadastro de uma ONG.

*inserir imagem*

### Requisitos

- RF-011 -	O usuário Gestor das ONGs poderá descrever as atividades da sua ONG.

### Artefatos Produzidos

- ONGController.cs
- UserONGModel.cs
- Details.cshtml

## Tela de Informações do Cadastro do Voluntário

Essa tela permite a visualização das informações de cadastro de um voluntário.

*inserir imagem*

### Requisitos

- RF-007 - O sistema deve informar a a idade do usuario baseado na sua data de nascimento

### Artefatos Produzidos

- VoluntarioController.cs
- UserVoluntarioModel.cs
- Details.cshtml

## Tela de Edição das Informações do Cadastro da ONG

Essa tela permite a edição das informações de cadastro de uma ONG.

*inserir imagem*

### Requisitos

- RF-008 - O sistema deve permitir que o usuário edite seus dados.
- RF-010 - O usuário Gestor das ONGs poderá inserir informações para doações.
- RF-011 -	O usuário Gestor das ONGs poderá descrever as atividades da sua ONG.
### Artefatos Produzidos

- ONGController.cs
- UserONGModel.cs
- Edit.cshtml

## Tela de Edição das Informações do Cadastro do Voluntário

Essa tela permite a edição das informações de cadastro de um voluntário.

*inserir imagem*

### Requisitos

- RF-008 - O sistema deve permitir que o usuário edite seus dados.
- 
### Artefatos Produzidos

- VoluntarioController.cs
- UserVoluntarioModel.cs
- Edit.cshtml

## Tela de Exclusão do Cadastro da ONG

Essa tela permite a edição das informações de cadastro de uma ONG.

*inserir imagem*

### Requisitos

- RF-004 - O sistema permitirá que os usuários criados possam excluir seu usuário

### Artefatos Produzidos

- ONGController.cs
- UserONGModel.cs
- Delete.cshtml

## Tela de Exclusão do Cadastro do Voluntário

Essa tela permite a edição das informações de cadastro de um voluntário.

*inserir imagem*

### Requisitos

- RF-004 - O sistema permitirá que os usuários criados possam excluir seu usuário

### Artefatos Produzidos

- VoluntarioController.cs
- UserVoluntarioModel.cs
- Delete.cshtml

## Tela de Cadastro da Vaga de Trabalho

Essa tela permite a criação de vagas de trabalho.

*inserir imagem*

### Requisitos

- RF-009 - O usuário Gestor das ONGs poderá criar vagas para voluntários.

### Artefatos Produzidos

- JobController.cs
- JobModel.cs
- JobType.cs
- CreateJob.cshtml

## Tela de Busca das Vagas de Trabalho

Essa tela permite a busca de vagas de trabalho. Mais detalhes sobre as vagas podem ser visualizados por meio da opção "Mais Informações".

*inserir imagem*

### Requisitos

- RF-012 - O usuário voluntario poderá aplicar filtros nas vagas disponíveis.

### Artefatos Produzidos

- JobController.cs
- JobModel.cs
- JobType.cs
- Index.cshtml

## Tela de Informações das Vagas de Trabalho

Essa tela permite a visualização dos detalhes das vagas de trabalho cadastradas.

*inserir imagem*

### Requisitos

### Artefatos Produzidos

- JobController.cs
- JobModel.cs
- JobType.cs
- Details.cshtml
- Edit.cshtml
- Delete.cshtml

## Tela de Candidatura às Vagas de Trabalho

Essa tela permite que o voluntário candidate-se às vagas de trabalho cadastradas.

*inserir imagem*

### Requisitos

- RF-015 - Usuários voluntários podem candidatar-se às vagas cadastradas pelas ONGs.

### Artefatos Produzidos


## Tela de Visualização das Candidaturas

Essa tela permite que o voluntário veja suas candidaturas.

*inserir imagem*

### Requisitos

- RF-013 -	O usuário Gestor das ONGs poderá visualizar os voluntários candidatos à vaga.

### Artefatos Produzidos


## Tela de Visualização dos Candidatos

Essa tela permite que a ONG veja os voluntários candidatos às suas vagas.

*inserir imagem*

### Requisitos

- RF-014 - Usuários voluntários podem encerrar sua participação nas ONGs pelo site.

### Artefatos Produzidos

<br></br>
# Instruções de acesso

A aplicação encontra-se disponível para acesso em: https://projeto-ong.herokuapp.com/
