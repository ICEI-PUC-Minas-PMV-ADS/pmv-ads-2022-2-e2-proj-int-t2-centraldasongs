# Especificações do Projeto

A determinação exata do problema, suas personas, requisitos funcionais e não-funcionais foram acordadas em reuniões online entre os membros da equipe. Foram reunidas informações e observações e, complementarmente. Os detalhes levantados nesse processo auxiliaram na construção de personas e histórias de usuários.

## Personas

Pedro Paulo tem 26 anos, é arquiteto recém-formado e autônomo. Pensa em se desenvolver profissionalmente através de um mestrado fora do país, pois adora viajar, é solteiro e sempre quis fazer um intercâmbio. Está buscando uma agência que o ajude a encontrar universidades na Europa que aceitem alunos estrangeiros.

Enumere e detalhe as personas da sua solução. Para tanto, baseie-se tanto nos documentos disponibilizados na disciplina e/ou nos seguintes links:
>
Lembre-se que você deve ser enumerar e descrever precisamente e personalizada todos os clientes ideais que sua solução almeja.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Usuário do sistema  | Registrar minhas tarefas           | Não esquecer de fazê-las               |
|Administrador       | Alterar permissões                 | Permitir que possam administrar contas |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

## Requisitos

O escopo funcional do projeto é definido por meio dos requisitos funcionais que descrevem as possibilidades interação dos usuários, bem como os requisitos não funcionais que descrevem os aspectos que o sistema deverá apresentar de maneira geral. Estes requisitos são apresentados a seguir.

### Requisitos Funcionais

A tabela a seguir apresenta os requisitos do projeto, identificando a prioridade em que os mesmos devem ser entregues.

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| O sistema permitirá cadastro de usuários gestores de ONG; | ALTA | 
|RF-002| O sistema permitirá cadastro de usuários voluntários/doadores;   | ALTA |
|RF-003| O sistema permitirá que os usuários criados efetuem login;   | ALTA |
|RF-004| O sistema deve permitir que o usuário cadastre uma nova senha caso ele esqueça a atual;   | MÉDIA |
|RF-005| O sistema deve verificar se o usuário já foi cadastrado   | ALTA |
|RF-006| O sistema deve verificar se o usuário possui mais de 18 anos   | MÉDIA |
|RF-007| O usuário Gestor das ONGs poderá cadastrar sua ONG   | ALTA |
|RF-008| O usuário Gestor das ONGs poderá criar vagas para voluntários   | ALTA |
|RF-009| O usuário Gestor das ONGs poderá inserir informações para doações   | ALTA |
|RF-010| O usuário Gestor das ONGs poderá cadastrar ponto de coletas de doação   | ALTA |
|RF-011| O usuário voluntario poderá aplicar filtros nas vagas disponíveis   | MÉDIA |
|RF-012| O usuário Gestor das ONGs poderá avaliar o perfil dos candidatos das vagas assim como podendo aceitar ou negar a candidatura   | ALTA |
|RF-013| Usuários aprovados pelos gestores receberam um e-mail de confirmação   | BAIXA |
|RF-014| Usuários voluntários podem encerrar sua participação nas ONGs pelo site   | BAIXA |
|RF-015| O sistema deve permitir que haja uma avaliação entre perfis de ONGs e Voluntários   | BAIXA |

### Requisitos não Funcionais

A tabela a seguir apresenta os requisitos não funcionais que o projeto deverá atender.

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O site deve ser publicado em um ambiente acessível publicamente na Internet (Repl.it, GitHub Pages, Heroku);  | ALTA | 
|RNF-002| O site deverá ser responsivo permitindo a visualização em um celular de forma adequada |  MÉDIA | 
|RNF-003| O site deve ter bom nível de contraste entre os elementos da tela em conformidade  | MÉDIA | 
|RNF-004| O site deve ser compatível com os principais navegadores do mercado (Google Chrome, Firefox, Microsoft Edge) |  ALTA | 
|RNF-005| O site deverá utilizar banco de dados relacional (SQL like) | ALTA | 
|RNF-006| Utilizar a linguagem C# framework .net utilizando Entity framework e React |  ALTA | 

## Restrições

As questões que limitam a execução desse projeto e que se configuram como obrigações claras para o desenvolvimento do projeto em questão são apresentadas na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|RE-01| O projeto deverá ser entregue no final do semestre letivo, não podendo extrapolar a data de 11/12/2022. |
|RE-02| O aplicativo deve se restringir às tecnologias básicas da Web no Frontend e no Back-end.|
|RE-03| A equipe não pode subcontratar o desenvolvimento do trabalho.|

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
