# Plano de Testes de Software
 
| **Caso de Teste** 	| **CT-01 – Cadastrar usuário gestores de ONG** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - O sistema permitirá cadastro de usuários gestores de ONG;<br>RF-010 - O usuário Gestor das ONGs poderá inserir informações para doações ;<br>RF-011 - O usuário Gestor das ONGs poderá descrever as atividades da sua ONG.|
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Sou uma ONG"; <br> - Preencher os campos obrigatórios (e-mail, nome, contato, área de atuação, senha, confirmação de senha, classificação, sobre, endereço) e não obrigatorios (caixa postal, dados bancarios); <br> - Aceitar os termos de uso; <br> - Clicar em "Cadastrar". |
|Critério de Êxito | - O usuário consegue efetuar login com os dados cadastrados. |
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Cadastrar perfil usuário voluntários/doadores** 	|
|	Requisito Associado 	| RF-002 - O sistema permitirá cadastro de usuários voluntários/doadores. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Quero ser voluntário"; <br> - Preencher os campos obrigatórios (e-mail, nome completo, data de nascimento, contato, CPF, qualificações, endereço, senha, confirmação de senha); <br> - Aceitar os termos de uso; <br> - Clicar em "Cadastrar". |
|Critério de Êxito | - O usuário consegue efetuar login com os dados cadastrados. |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Efetuar Login** 	|
|	Requisito Associado 	| RF-003 - O sistema permitirá que os usuários criados efetuem login. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login na aplicação. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Entrar"; <br> - Preencher os campos obrigatórios (e-mail e senha); <br> - Clicar em "Login". |
|Critério de Êxito | - Redirecionamento para a página home com o login efetuado. |
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Cadastrar perfil utilizando CPF já cadastrado** 	|
|	Requisito Associado 	| RF-006 - O sistema deve verificar se o usuário já foi cadastrado. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastradar utilizando um CPF ja presente no banco de dados. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Cadastrar usuário. |
|Critério de Êxito | - Mensagem de erro, informando que o CPF ja foi cadastrado. |
|  	|  	|
| **Caso de Teste** 	| **CT-05 – Edição dos Dados Cadastrados do Usuário** 	|
|	Requisito Associado 	| RF-008 - O sistema deve permitir que o usuário edite seus dados. |
| Objetivo do Teste 	| Verificar se o usuário consegue editar os dados que foram cadastrados. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Fazer Login; <br> - Acessar a página de informações do usuário; <br> - Clicar em "Editar". |
|Critério de Êxito | - As informações sobre o usuário foram alteradas. |
|  	|  	|
| **Caso de Teste** 	| **CT-06 – Verificação de idade do candidato** 	|
|	Requisito Associado 	| RF-007 - O sistema deve verificar se o usuário possui mais de 18 anos. |
| Objetivo do Teste 	| Aparecer vagas para maiores de idade apenas para usuarios com mais de 18 anos |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Fazer login com usuario voluntario; <br> - Clicar em "Minha conta". |
|Critério de Êxito | - Devera aparecer um campo informando a idade do ususário |
|  	|  	|
| **Caso de Teste** 	| **CT-07 – Encerrar participação em atividades** 	|
|	Requisito Associado 	| RF-014 - Usuários voluntários podem encerrar sua participação nas ONGs pelo site. |
| Objetivo do Teste 	| Conseguir encerrar candidatura/participação nas vagas abertas pelas ONGs. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Fazer login com usuario voluntario; <br> - Clicar em Minha Conta; <br> - Clicar em Minhas candidaturas; <br> - Clicar na candidatura que deseja encerrar participação;<br> - Clicar em Encerrar participação.|
|Critério de Êxito | - A vaga deverá sumir do painel das candidaturas |
|  	|  	|
| **Caso de Teste** 	| **CT-08 – Recuperar Senha** 	|
|	Requisito Associado 	| RF-005 - O sistema deve permitir que o usuário cadastre uma nova senha caso ele esqueça a atual. |
| Objetivo do Teste 	| Recuperar senha de login. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Entrar"; <br> - Clicar em "Esqueci minha senha"; <br>Preencher os campos obrigatórios (e-mail, CNPJ/CPF); <br> - Inserir nova senha; <br> - Clicar em "Concluir".|
|Critério de Êxito | - Redirecionamento para a pagina Login <br> - Realização do login com a nova senha |
|  	|  	|
| **Caso de Teste** 	| **CT-09 – Visualizar Candidaturas** 	|
|	Requisito Associado 	| RF-013 - O usuário Gestor das ONGs poderá visualizar os voluntários candidatos à vaga. |
| Objetivo do Teste 	| Usuario ONG poderá visulizar os voluntários que candidataram-se às vagas. |
| Passos 	| - Verificar os detalhes da vaga cadastrada; <br>- Verifircar o contato dos voluntários que candidataram-se.|
|Critério de Êxito | - Exibição de tabela com os dados dos voluntários cadastrados. |
|  	|  	|
| **Caso de Teste** 	| **CT-10 – Criar atividades para os voluntários** 	|
|	Requisito Associado 	| RF-009 - O usuário Gestor das ONGs poderá criar vagas para voluntários. |
| Objetivo do Teste 	| Criar atividades para que os voluntarios possam se candidatar. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em Minha Conta; <br> - Clicar em Minhas Vagas; <br> - Clicar em Cadastras Nova Vaga; <br> - Inserir dados obrigatorios <br> - Clicar em Concluir|
|Critério de Êxito | -  A vaga criada devera aparecer no painel de Lista de Trabalhos|
|  	|  	|
| **Caso de Teste** 	| **CT-11 – Filtrar vagas disponíveis** 	|
|	Requisito Associado 	| RF-012 - O usuário Voluntario poderá aplicar filtros nas vagas |
| Objetivo do Teste 	| O usuário Voluntario poderá aplicar filtros para que apareça apenas vagas de seu interesse |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Fazer o login; <br>Escolher quais filtros deseja aplicar.|
|Critério de Êxito | -  Aparecer somente as vagas de seu interesse. |
|  	|  	|
| **Caso de Teste** 	| **CT-012 – Excluir usuário** 	|
|	Requisito Associado 	| RF-004 - O sistema permitirá que os usuários criados possam excluir seu usuário. |
| Objetivo do Teste 	| Verificar se o usuário consegue excluir seu usuario |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Entrar"; <br> - Fazer login <br> - Clicar em Minha ONG/Meu Perfil;<br> - Clicar em Excluir Conta; <br> - Clicar em Confirmar.|
|Critério de Êxito | - O usuário não consegue efetuar o login com os dados excluídos.|
|  	|  	|
| **Caso de Teste** 	| **CT-013 – Voluntários podem candidatar-se às vagas cadastradas** 	|
|	Requisito Associado 	| RF-015 - Usuários voluntários podem candidatar-se às vagas cadastradas pelas ONGs. |
| Objetivo do Teste 	| Verificar se o voluntário consegue candidatar-se à vaga. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Entrar"; <br> - Fazer login <br> - Clicar em Meu Perfil;<br> - Clicar em Lista de Trabalhos; <br> - Clicar em Candidatar-se.|
|Critério de Êxito | - O voluntário consegue visualizar a cadidatura no seu perfil.|
|  	|  	|










 
