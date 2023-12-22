Feature: Operações com Turmas

  Scenario: Buscar Lista de Turmas
    Given que o sistema está configurado
    When eu busco a lista de turmas
    Then a lista de turmas não deve ser nula e deve ser do tipo Lista de Turmas

  Scenario: Buscar Turma por ID
    Given que o sistema está configurado
    When eu busco uma turma pelo ID
    Then a turma encontrada deve ter o ID correto

  Scenario: Adicionar Nova Turma
    Given que o sistema está configurado
    When eu adiciono uma nova turma
    Then a turma inserida deve ter os dados corretos

  Scenario: Atualizar Turma
    Given que o sistema está configurado
    When eu atualizo uma turma
    Then a turma atualizada deve ter os dados corretos

  Scenario: Excluir Turma
    Given que o sistema está configurado
    When eu excluo uma turma
    Then a turma excluída não deve ser encontrada

Examples:
  | Nome     | CursoAssociadoID |
  | Turma A  | null             |

  Feature: TurmaRepository
    Como desenvolvedor
    Eu quero interagir com o repositório de turmas
    Para que eu possa realizar operações CRUD

    Background:
        Given que não há turmas cadastradas

    Scenario: Buscar a lista de turmas quando há turmas cadastradas
        Given que há turmas cadastradas
        When eu busco a lista de turmas
        Then a lista de turmas não está vazia

    Scenario: Adicionar uma nova turma
        When eu adiciono uma nova turma
        Then a lista de turmas contém uma única turma
        And as propriedades da turma estão corretas

