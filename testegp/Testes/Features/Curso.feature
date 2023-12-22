Feature: Gerenciar Cursos

  Scenario: Adicionar um novo curso
    Given que h� cursos existentes
    When eu adiciono um novo curso com o nome "Nome do Curso"
    Then o curso "Nome do Curso" � exibido na lista de cursos

  Scenario: Atualizar informa��es de um curso
    Given que h� um curso chamado "Nome do Curso"
    When eu atualizo o nome do curso para "Novo Nome do Curso"
    Then as informa��es do curso s�o atualizadas corretamente

  Scenario: Excluir um curso
    Given que h� um curso chamado "Nome do Curso"
    When eu excluo o curso
    Then o curso "Nome do Curso" n�o est� mais na lista de cursos
