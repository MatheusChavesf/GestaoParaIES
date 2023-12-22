Feature: Gerenciar Cursos

  Scenario: Adicionar um novo curso
    Given que há cursos existentes
    When eu adiciono um novo curso com o nome "Nome do Curso"
    Then o curso "Nome do Curso" é exibido na lista de cursos

  Scenario: Atualizar informações de um curso
    Given que há um curso chamado "Nome do Curso"
    When eu atualizo o nome do curso para "Novo Nome do Curso"
    Then as informações do curso são atualizadas corretamente

  Scenario: Excluir um curso
    Given que há um curso chamado "Nome do Curso"
    When eu excluo o curso
    Then o curso "Nome do Curso" não está mais na lista de cursos
