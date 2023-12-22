Feature: Opera��es de Disciplina

  Scenario: Buscar Disciplinas
    Given que o sistema est� configurado
    When eu busco por disciplinas
    Then a lista de disciplinas n�o deve ser nula

  Scenario: Adicionar Nova Disciplina
    Given que o sistema est� configurado
    When eu adiciono uma nova disciplina
    Then a disciplina inserida deve estar correta

Examples:
  | IDDisciplina | NomeDisciplina         | ProfessorResponsavelID | ProfessorMinistrante          |
  | 1            | Nome da Disciplina     | 1                      | Nome do Professor Ministrante |


  Feature: Gerenciar Disciplinas

  Scenario: Buscar Disciplinas
    Given que h� disciplinas cadastradas
    When eu realizo uma busca por disciplinas
    Then uma lista de disciplinas � retornada

  Scenario: Adicionar Nova Disciplina
    Given que n�o h� uma disciplina com o nome "Nome da Disciplina"
    When eu adiciono uma nova disciplina com o nome "Nome da Disciplina", Professor Respons�vel ID 1 e Professor Ministrante "Nome do Professor Ministrante"
    Then a disciplina "Nome da Disciplina" � adicionada com sucesso

    Feature: Disciplina Feature

Scenario: Buscar Disciplina
    Given que h� disciplinas cadastradas
    When eu busco por disciplinas
    Then a lista de disciplinas n�o deve estar vazia

Scenario: Adicionar Nova Disciplina
    Given que n�o h� uma disciplina com o nome "Nome da Disciplina"
    When eu adiciono uma nova disciplina com o nome "Nome da Disciplina", respons�vel "Prof. Respons�vel" e ministrante "Prof. Ministrante"
    Then a disciplina com o nome "Nome da Disciplina" deve estar na lista de disciplinas

Scenario: Adicionar Nova Disciplina com Nome Existente
    Given que h� uma disciplina com o nome "Nome da Disciplina Existente"
    When eu tento adicionar uma nova disciplina com o nome "Nome da Disciplina Existente", respons�vel "Prof. Respons�vel" e ministrante "Prof. Ministrante"
    Then a disciplina com o nome "Nome da Disciplina Existente" n�o deve ser adicionada � lista de disciplinas
