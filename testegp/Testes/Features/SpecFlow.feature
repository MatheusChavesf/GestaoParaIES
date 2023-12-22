Feature: Alunos
Scenario: Buscar Alunos
    Given o sistema está configurado e funcionando
    When o usuário busca por alunos
    Then a lista de alunos é retornada

Scenario: Adicionar Aluno
    Given o sistema está configurado e funcionando
    When o usuário adiciona um novo aluno
    Then o aluno é inserido na lista
