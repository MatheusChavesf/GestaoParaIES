Feature: Opera��es de Presen�a

  Scenario: Obter Lista de Presen�as
    Given que o sistema est� configurado
    When eu obtenho a lista de presen�as
    Then a lista de presen�as n�o deve ser nula

  Scenario: Obter Presen�a por ID
    Given que o sistema est� configurado
    When eu obtenho a presen�a com ID espec�fico
    Then a presen�a retornada deve ser correta

  Scenario: Adicionar Nova Presen�a
    Given que o sistema est� configurado
    When eu adiciono uma nova presen�a
    Then a presen�a inserida deve estar correta

Examples:
  | IDPresenca | Data                  | AlunoPresenteID | DisciplinaID |
  | 1          | 2023-01-01T00:00:00   | 1               | 1            |


  Feature: Presenca Feature

Scenario: Get Presencas
    Given que h� presen�as cadastradas
    When eu obtenho a lista de presen�as
    Then a lista de presen�as n�o deve estar vazia

Scenario: Get Presenca by Id
    Given que h� uma presen�a com o ID 1
    When eu obtenho a presen�a com o ID 1
    Then a presen�a obtida deve ter o ID 1

Scenario: Adicionar Nova Presenca
    Given que n�o h� uma presen�a registrada para a data atual, Aluno ID 1 e Disciplina ID 1
    When eu adiciono uma nova presen�a com a data atual, Aluno ID 1 e Disciplina ID 1
    Then a presen�a com a data atual, Aluno ID 1 e Disciplina ID 1 deve ser adicionada � lista de presen�as
