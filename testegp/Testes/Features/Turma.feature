Feature: Opera��es com Turmas

  Scenario: Buscar Lista de Turmas
    Given que o sistema est� configurado
    When eu busco a lista de turmas
    Then a lista de turmas n�o deve ser nula e deve ser do tipo Lista de Turmas

  Scenario: Buscar Turma por ID
    Given que o sistema est� configurado
    When eu busco uma turma pelo ID
    Then a turma encontrada deve ter o ID correto

  Scenario: Adicionar Nova Turma
    Given que o sistema est� configurado
    When eu adiciono uma nova turma
    Then a turma inserida deve ter os dados corretos

  Scenario: Atualizar Turma
    Given que o sistema est� configurado
    When eu atualizo uma turma
    Then a turma atualizada deve ter os dados corretos

  Scenario: Excluir Turma
    Given que o sistema est� configurado
    When eu excluo uma turma
    Then a turma exclu�da n�o deve ser encontrada

Examples:
  | Nome     | CursoAssociadoID |
  | Turma A  | null             |

  Feature: TurmaRepository
    Como desenvolvedor
    Eu quero interagir com o reposit�rio de turmas
    Para que eu possa realizar opera��es CRUD

    Background:
        Given que n�o h� turmas cadastradas

    Scenario: Buscar a lista de turmas quando h� turmas cadastradas
        Given que h� turmas cadastradas
        When eu busco a lista de turmas
        Then a lista de turmas n�o est� vazia

    Scenario: Adicionar uma nova turma
        When eu adiciono uma nova turma
        Then a lista de turmas cont�m uma �nica turma
        And as propriedades da turma est�o corretas

