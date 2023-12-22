Feature: Operações de Presença

  Scenario: Obter Lista de Presenças
    Given que o sistema está configurado
    When eu obtenho a lista de presenças
    Then a lista de presenças não deve ser nula

  Scenario: Obter Presença por ID
    Given que o sistema está configurado
    When eu obtenho a presença com ID específico
    Then a presença retornada deve ser correta

  Scenario: Adicionar Nova Presença
    Given que o sistema está configurado
    When eu adiciono uma nova presença
    Then a presença inserida deve estar correta

Examples:
  | IDPresenca | Data                  | AlunoPresenteID | DisciplinaID |
  | 1          | 2023-01-01T00:00:00   | 1               | 1            |


  Feature: Presenca Feature

Scenario: Get Presencas
    Given que há presenças cadastradas
    When eu obtenho a lista de presenças
    Then a lista de presenças não deve estar vazia

Scenario: Get Presenca by Id
    Given que há uma presença com o ID 1
    When eu obtenho a presença com o ID 1
    Then a presença obtida deve ter o ID 1

Scenario: Adicionar Nova Presenca
    Given que não há uma presença registrada para a data atual, Aluno ID 1 e Disciplina ID 1
    When eu adiciono uma nova presença com a data atual, Aluno ID 1 e Disciplina ID 1
    Then a presença com a data atual, Aluno ID 1 e Disciplina ID 1 deve ser adicionada à lista de presenças
