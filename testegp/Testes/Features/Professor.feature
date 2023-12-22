Feature: Operações com Professores

  Scenario: Buscar Lista de Professores
    Given que o sistema está configurado
    When eu busco a lista de professores
    Then a lista de professores não deve ser nula e deve ser do tipo Lista de Professores

  Scenario: Adicionar Novo Professor
    Given que o sistema está configurado
    When eu adiciono um novo professor
    Then o professor inserido deve estar correto

Examples:
  | Nome do Professor  | Matricula Professor | Data de Nascimento      | Disciplina Ministrada |
  | NomeProfessor      | 12345               | 2023-01-01T00:00:00     | Matemática            |

  Feature: Gerenciar Professores

  Scenario: Buscar lista de professores
    Given que há professores cadastrados
    When eu busco a lista de professores
    Then a lista de professores não está vazia

  Scenario: Adicionar novo professor
    Given que não há professores cadastrados
    When eu adiciono um novo professor
    Then a lista de professores contém um único professor
    And as propriedades do professor estão corretas

