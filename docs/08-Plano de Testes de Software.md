# Plano de Testes de Software
 
| **Caso de Teste** 	| **CT-01 – Cadastrar usuário gestores de ONG** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - O sistema permitirá cadastro de usuários gestores de ONG;<br>RF-009 - O usuário Gestor das ONGs poderá inserir informações para doações ;<br>RF-010 - O usuário Gestor das ONGs poderá descrever as atividades da sua ONG.|
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Sou uma ONG"; <br> - Preencher os campos obrigatórios (e-mail, nome, contato, área de atuação, senha, confirmação de senha, classificação, sobre, endereço) e não obrigatorios (caixa postal, dados bancarios); <br> - Aceitar os termos de uso; <br> - Clicar em "Cadastrar". |
|Critério de Êxito | - Uma mensagem informando que o cadastro foi realizado com sucesso devera aparecer e o usuario devera ser redirecionado para a pagina home com o login efetuado. |
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Cadastrar perfil usuário voluntários/doadores** 	|
|	Requisito Associado 	| RF-002 - O sistema permitirá cadastro de usuários voluntários/doadores. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Quero ser voluntário"; <br> - Preencher os campos obrigatórios (e-mail, nome completo, data de nascimento, contato, CPF, qualificações, endereço, senha, confirmação de senha); <br> - Aceitar os termos de uso; <br> - Clicar em "Cadastrar". |
|Critério de Êxito | - Uma mensagem informando que o cadastro foi realizado com sucesso devera aparecer e o usuario devera ser redirecionado para a pagina home com o login efetuado. |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Efetuar login** 	|
|	Requisito Associado 	| RF-003 - O sistema permitirá que os usuários criados efetuem login. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login na aplicação. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Entrar"; <br> - Preencher os campos obrigatórios (e-mail e senha); <br> - Clicar em "Login". |
|Critério de Êxito | - Redirecionamento para a pagina home com o login efetuado. |
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Cadastrar perfil utilizando e-mail ja cadastrado** 	|
|	Requisito Associado 	| RF-006 - O sistema deve verificar se o usuário já foi cadastrado. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastradar utilizando um email ja presente no banco de dados. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Sou uma ONG" ou  "Quero ser voluntário"; <br> - Preencher os campos obrigatórios; <br> - Clicar em "Cadastrar". |
|Critério de Êxito | - Mensagem de erro, informando que o e-mail ja foi cadastrado. |
|  	|  	|
| **Caso de Teste** 	| **CT-05 – Aprovação de candidaturas voluntarios** 	|
|	Requisito Associado 	| RF-012 - O usuário Gestor das ONGs poderá avaliar o perfil dos candidatos das vagas assim como podendo aceitar ou negar a candidatura. |
| Objetivo do Teste 	| Verificar se o usuário consegue aceitar ou negar cadidaduras. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "A definir painel adm". |
|Critério de Êxito | - A definir fomra como os cards deverão aparecer. |
|  	|  	|
| **Caso de Teste** 	| **CT-06 – Verificação de idade do candidato** 	|
|	Requisito Associado 	| RF-007 - O sistema deve verificar se o usuário possui mais de 18 anos. |
| Objetivo do Teste 	| Aparecer vagas para maiores de idade apenas para usuarios com mais de 18 anos |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Fazer login com usuario voluntario; <br> - Clicar em "Minha conta". |
|Critério de Êxito | - Devera aparecer um campo informando a idade do ususario |
|  	|  	|
| **Caso de Teste** 	| **CT-07 – Encerrar participação em atividades** 	|
|	Requisito Associado 	| RF-014 - Usuários voluntários podem encerrar sua participação nas ONGs pelo site. |
| Objetivo do Teste 	| Conseguir encerrar candidatura/participação nas vagas abertas pelas ONGs. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Fazer login com usuario voluntario; <br> - Clicar em Minha Conta; <br> - Clicar em Minhas candidaturas; <br> - Clicar na candidatura que deseja encerrar participação;<br> - Clicar em Encerrar participação.|
|Critério de Êxito | - A vaga devera sumir do painel das candidaturas |
|  	|  	|
| **Caso de Teste** 	| **CT-08 – Recuperar Senha** 	|
|	Requisito Associado 	| RF-005 - O sistema deve permitir que o usuário cadastre uma nova senha caso ele esqueça a atual. |
| Objetivo do Teste 	| Recuperar senha de login. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Entrar"; <br> - Clicar em "Esqueci minha senha"; <br>Preencher os campos obrigatórios (e-mail, CNPJ/CPF); <br> - Inserir nova senha; <br> - Clicar em "Concluir".|
|Critério de Êxito | - Redirecionamento para a pagina Login <br> - Realização do login com a nova senha |
|  	|  	|
| **Caso de Teste** 	| **CT-09 – Confirmação de aprovação** 	|
|	Requisito Associado 	| RF-013 - Usuários aprovados pelos gestores receberam um e-mail de confirmação. |
| Objetivo do Teste 	| Usuario voluntario ter uma confirmação por e-mail de que sua candidatura foi aprovada. |
| Passos 	| - Verificar caixa de entrada do e-mail; <br>- Verifircar se chegou algum email da Central das ONGs relacionado a vaga candidatada.|
|Critério de Êxito | - E-mail enviado para a caixa de mensagens do usuario voluntario. |
|  	|  	|
| **Caso de Teste** 	| **CT-10 – Criar atividades para os voluntarios** 	|
|	Requisito Associado 	| RF-008 - O usuário Gestor das ONGs poderá criar vagas para voluntários. |
| Objetivo do Teste 	| Criar atividades para que os voluntarios possam se candidatar. |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em Minha Conta; <br> - Clicar em Minhas Vagas; <br> - Clicar em Cadastras Nova Vaga; <br> - Inserir dados obrigatorios <br> - Clicar em Concluir|
|Critério de Êxito | -  A vaga criada devera aparecer no painel de Vagas Ativas|
|  	|  	|
| **Caso de Teste** 	| **CT-11 – Filtrar vagas disponiveis** 	|
|	Requisito Associado 	| RF-011 - O usuário Voluntario poderá aplicar filtros nas vagas |
| Objetivo do Teste 	| O usuário Voluntario poderá aplicar filtros para que apareça apenas vagas/doeações de seu interesse |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Quero ser voluntario"; <br>Escolher no menu superior a esquerda quais filtros deseja aplicar.|
|Critério de Êxito | -  Aparecer somente as vagas/doações de seu interesse. |
|  	|  	|
| **Caso de Teste** 	| **CT-012 – Excluir usuario** 	|
|	Requisito Associado 	| RF-004 - O sistema permitirá que os usuários criados possam excluir seu usuário. |
| Objetivo do Teste 	| Verificar se o usuário consegue excluir seu usuario |
| Passos 	| - Acessar o navegador; <br> - Informar o endereço do site; <br> - Clicar em "Entrar"; <br> - Fazer login <br> - Clicar em Minha ONG/Meu Perfil;<br> - Clicar em Excluir Conta; <br> - Clicar em Confirmar.|
|Critério de Êxito | - Mensagem de confirmação de exclusão.|












 
