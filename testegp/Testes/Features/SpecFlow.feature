Feature: Alunos
Scenario: Buscar Alunos
    Given o sistema est� configurado e funcionando
    When o usu�rio busca por alunos
    Then a lista de alunos � retornada

Scenario: Adicionar Aluno
    Given o sistema est� configurado e funcionando
    When o usu�rio adiciona um novo aluno
    Then o aluno � inserido na lista
