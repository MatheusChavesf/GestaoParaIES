Feature: Operações de Disciplina

  Scenario: Buscar Disciplinas
    Given que o sistema está configurado
    When eu busco por disciplinas
    Then a lista de disciplinas não deve ser nula

  Scenario: Adicionar Nova Disciplina
    Given que o sistema está configurado
    When eu adiciono uma nova disciplina
    Then a disciplina inserida deve estar correta

Examples:
  | IDDisciplina | NomeDisciplina         | ProfessorResponsavelID | ProfessorMinistrante          |
  | 1            | Nome da Disciplina     | 1                      | Nome do Professor Ministrante |


  Feature: Gerenciar Disciplinas

  Scenario: Buscar Disciplinas
    Given que há disciplinas cadastradas
    When eu realizo uma busca por disciplinas
    Then uma lista de disciplinas é retornada

  Scenario: Adicionar Nova Disciplina
    Given que não há uma disciplina com o nome "Nome da Disciplina"
    When eu adiciono uma nova disciplina com o nome "Nome da Disciplina", Professor Responsável ID 1 e Professor Ministrante "Nome do Professor Ministrante"
    Then a disciplina "Nome da Disciplina" é adicionada com sucesso

    Feature: Disciplina Feature

Scenario: Buscar Disciplina
    Given que há disciplinas cadastradas
    When eu busco por disciplinas
    Then a lista de disciplinas não deve estar vazia

Scenario: Adicionar Nova Disciplina
    Given que não há uma disciplina com o nome "Nome da Disciplina"
    When eu adiciono uma nova disciplina com o nome "Nome da Disciplina", responsável "Prof. Responsável" e ministrante "Prof. Ministrante"
    Then a disciplina com o nome "Nome da Disciplina" deve estar na lista de disciplinas

Scenario: Adicionar Nova Disciplina com Nome Existente
    Given que há uma disciplina com o nome "Nome da Disciplina Existente"
    When eu tento adicionar uma nova disciplina com o nome "Nome da Disciplina Existente", responsável "Prof. Responsável" e ministrante "Prof. Ministrante"
    Then a disciplina com o nome "Nome da Disciplina Existente" não deve ser adicionada à lista de disciplinas
