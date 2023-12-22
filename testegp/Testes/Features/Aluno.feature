Feature: AlunoRepository
  Como um desenvolvedor
  Eu quero garantir que a classe AlunoRepository funcione corretamente

  Scenario: Buscar Alunos
    Given que existe um reposit�rio de alunos
    When eu chamar o m�todo BuscarAlunos
    Then o resultado n�o deve ser nulo

  Scenario: Adicionar Aluno
    Given que existe um reposit�rio de alunos
    When eu adicionar um novo aluno
    Then eu devo ser capaz de recuperar o aluno inserido
    And os atributos do aluno recuperado devem coincidir com os atributos do aluno original