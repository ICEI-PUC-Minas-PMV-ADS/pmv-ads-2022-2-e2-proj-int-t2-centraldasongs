# Programação de Funcionalidades

## Tela Home

![Home](https://user-images.githubusercontent.com/100412134/203559601-9085dd1a-ca22-4200-9c5f-ae8b07578f57.png)

### Requisitos

- RF-003 - O sistema permitirá que os usuários criados efetuem login.

### Artefatos Produzidos
- HomeController.cs
- Index.cshtml
- Privacy.cshtml

## Tela "Sou uma ONG"

![Login ONG](https://user-images.githubusercontent.com/100412134/203559687-b4d54d47-a3d9-4904-9405-72d739050fa1.png)

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

![Login Voluntario](https://user-images.githubusercontent.com/100412134/203559744-5756f2a3-a5de-404c-b2d6-fda28e3d2093.png)

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

![CriarONG](https://user-images.githubusercontent.com/100412134/206039262-0f91eddf-acf4-4811-a651-b896d3358953.png)

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

![CadastroVoluntario](https://user-images.githubusercontent.com/100412134/203559936-131848d8-b84c-483b-9426-9f309c7da295.png)

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

![RecuperarSenhaONG](https://user-images.githubusercontent.com/100412134/203560094-79906b81-43c4-4e9a-b818-ae1abf9f3da7.png)

### Requisitos

- RF-005 - O sistema deve permitir que o usuário cadastre uma nova senha caso ele esqueça a atual.

### Artefatos Produzidos

- ONGController.cs
- UserONGModel.cs
- ForgotPassword.cshtml
- UpdatePassword.cshtml

## Tela de Recuperação de Senha do Usuário do Voluntário

![RecuperarSenhaVoluntario](https://user-images.githubusercontent.com/100412134/203560140-550b99a2-3445-46dc-99f7-9cd89425a4d2.png)

### Requisitos

- RF-005 - O sistema deve permitir que o usuário cadastre uma nova senha caso ele esqueça a atual.

### Artefatos Produzidos

- VoluntarioController.cs
- UserVoluntarioModel.cs
- ForgotPassword.cshtml
- UpdatePassword.cshtml

## Tela de Informações do Cadastro da ONG

![InformaçõesONG](https://user-images.githubusercontent.com/100412134/203560202-fb3d9ed4-8aff-4a00-9416-0a120efae5e1.png)

### Requisitos

- RF-011 -	O usuário Gestor das ONGs poderá descrever as atividades da sua ONG.

### Artefatos Produzidos

- ONGController.cs
- UserONGModel.cs
- Details.cshtml

## Tela de Informações do Cadastro do Voluntário

![InformaçõesVoluntario](https://user-images.githubusercontent.com/100412134/203560275-cc27278a-4eb2-4273-83be-4f7c886e43d0.png)

### Requisitos

- RF-007 - O sistema deve informar a a idade do usuario baseado na sua data de nascimento

### Artefatos Produzidos

- VoluntarioController.cs
- UserVoluntarioModel.cs
- Details.cshtml

## Tela de Edição das Informações do Cadastro da ONG

![EditarONG](https://user-images.githubusercontent.com/100412134/203560430-cf9266a1-48ac-4002-86ad-5fbadd914584.png)

### Requisitos

- RF-008 - O sistema deve permitir que o usuário edite seus dados.
- RF-010 - O usuário Gestor das ONGs poderá inserir informações para doações.
- RF-011 -	O usuário Gestor das ONGs poderá descrever as atividades da sua ONG.
### Artefatos Produzidos

- ONGController.cs
- UserONGModel.cs
- Edit.cshtml

## Tela de Edição das Informações do Cadastro do Voluntário

![EditarVoluntario](https://user-images.githubusercontent.com/100412134/203563696-53faf4af-87ec-4a36-9bea-3ebe8f344c4a.png)

### Requisitos

- RF-008 - O sistema deve permitir que o usuário edite seus dados.

### Artefatos Produzidos

- VoluntarioController.cs
- UserVoluntarioModel.cs
- Edit.cshtml

## Tela de Exclusão do Cadastro da ONG

![ExcluirONG](https://user-images.githubusercontent.com/100412134/203560533-e6dda27d-cd0a-4c35-b38e-c81819ed066a.png)

### Requisitos

- RF-004 - O sistema permitirá que os usuários criados possam excluir seu usuário

### Artefatos Produzidos

- ONGController.cs
- UserONGModel.cs
- Delete.cshtml

## Tela de Exclusão do Cadastro do Voluntário

![ExcluirVoluntario](https://user-images.githubusercontent.com/100412134/203560632-b475dc57-2070-41a3-b9de-cf57fef720bc.png)

### Requisitos

- RF-004 - O sistema permitirá que os usuários criados possam excluir seu usuário

### Artefatos Produzidos

- VoluntarioController.cs
- UserVoluntarioModel.cs
- Delete.cshtml

## Tela de Cadastro da Vaga de Trabalho

![CriarTrabalhoONG](https://user-images.githubusercontent.com/100412134/203560730-64aaacf5-fe25-4f00-9547-91b4b8a499e1.png)

### Requisitos

- RF-009 - O usuário Gestor das ONGs poderá criar vagas para voluntários.

### Artefatos Produzidos

- JobController.cs
- JobModel.cs
- JobType.cs
- CreateJob.cshtml

## Tela de Busca das Vagas de Trabalho

![Home](https://user-images.githubusercontent.com/100412134/203560786-14765a6b-2744-46bf-82b4-e85168a8f7e7.png)

### Requisitos

- RF-012 - O usuário voluntario poderá aplicar filtros nas vagas disponíveis.

### Artefatos Produzidos

- JobController.cs
- JobModel.cs
- JobType.cs
- Index.cshtml

## Tela de Informações das Vagas de Trabalho

![DetalhesVaga](https://user-images.githubusercontent.com/100412134/203560835-8884e10b-47e2-4607-9581-b446fd61124c.png)

### Requisitos

- RF-011	O usuário Gestor das ONGs poderá descrever as atividades da sua ONG.

### Artefatos Produzidos

- JobController.cs
- JobModel.cs
- JobType.cs
- Details.cshtml
- Edit.cshtml
- Delete.cshtml

## Tela de Candidatura às Vagas de Trabalho

![DetalhesVagaVoluntario](https://user-images.githubusercontent.com/100412134/203560908-af65b321-ca5c-402a-92e8-947ba21c53b0.png)

### Requisitos

- RF-015 - Usuários voluntários podem candidatar-se às vagas cadastradas pelas ONGs.

### Artefatos Produzidos

- VacancyCotroller.cs
- VacancyModel.cs
- Index.cshtml

## Tela de Visualização das Candidaturas

![MinhasCandidaturasVoluntario](https://user-images.githubusercontent.com/100412134/203561162-aed3e73e-42c1-4261-a32d-730363e1ef52.png)

### Requisitos

- RF-013 -	O usuário Gestor das ONGs poderá visualizar os voluntários candidatos à vaga.

### Artefatos Produzidos

- VacancyCotroller.cs
- VacancyModel.cs
- MyVacancies.cshtml

## Tela de Visualização dos Candidatos

![DetalhesCandidatosONG](https://user-images.githubusercontent.com/100412134/203561255-24cf36a2-9833-483f-baba-4d8c052946ce.png)

### Requisitos

- RF-013 - O usuário Gestor das ONGs poderá visualizar os voluntários candidatos à vaga.

### Artefatos Produzidos

- VacancyCotroller.cs
- VacancyModel.cs
- Index.cshtml
- Details.cshtml

## Tela de Recusar a Candidatura de Candidatos

![RejeitarCandidatoONG](https://user-images.githubusercontent.com/100412134/203561799-d6cc7e96-716f-4f40-89e5-b0cec37fdc66.png)

### Requisitos

- RF-013 - O usuário Gestor das ONGs poderá visualizar os voluntários candidatos à vaga.

### Artefatos Produzidos

- VacancyCotroller.cs
- VacancyModel.cs
- Index.cshtml
- Delete.cshtml

## Tela de Desistir da Candidatura à Vaga

![ExcluirCandidaturaVoluntario](https://user-images.githubusercontent.com/100412134/203561877-3b692983-d273-42bb-b07f-f2608679132b.png)

### Requisitos

- RF-014 - Usuários voluntários podem encerrar sua participação nas ONGs pelo site.

### Artefatos Produzidos

- VacancyCotroller.cs
- VacancyModel.cs
- Delete.cshtml
- MyVacancies.cshtml

## Tela "Meus Trabalhos" da ONG

![MeusTrabalhosONG](https://user-images.githubusercontent.com/100412134/203562308-4e84e635-0302-4a14-967c-5c8eda057a54.png)

### Requisitos

- RF-013 - O usuário Gestor das ONGs poderá visualizar os voluntários candidatos à vaga.

### Artefatos Produzidos

- VacancyCotroller.cs
- VacancyModel.cs
- Index.cshtml

<br></br>
# Instruções de acesso

A aplicação encontra-se disponível para acesso em: https://projeto-ong.herokuapp.com/
