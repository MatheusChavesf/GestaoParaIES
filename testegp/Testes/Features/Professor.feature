Feature: Opera��es com Professores

  Scenario: Buscar Lista de Professores
    Given que o sistema est� configurado
    When eu busco a lista de professores
    Then a lista de professores n�o deve ser nula e deve ser do tipo Lista de Professores

  Scenario: Adicionar Novo Professor
    Given que o sistema est� configurado
    When eu adiciono um novo professor
    Then o professor inserido deve estar correto

Examples:
  | Nome do Professor  | Matricula Professor | Data de Nascimento      | Disciplina Ministrada |
  | NomeProfessor      | 12345               | 2023-01-01T00:00:00     | Matem�tica            |

  Feature: Gerenciar Professores

  Scenario: Buscar lista de professores
    Given que h� professores cadastrados
    When eu busco a lista de professores
    Then a lista de professores n�o est� vazia

  Scenario: Adicionar novo professor
    Given que n�o h� professores cadastrados
    When eu adiciono um novo professor
    Then a lista de professores cont�m um �nico professor
    And as propriedades do professor est�o corretas

