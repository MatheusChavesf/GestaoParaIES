Feature: Adicionar Avalia��o no Banco de Dados

  Scenario: Adicionar Nova Avalia��o
    Given que o sistema est� configurado
    When eu adiciono uma nova avalia��o no banco de dados
    Then a avalia��o inserida deve estar correta

  Scenario Outline: Adicionar Nova Avalia��o com Dados Espec�ficos
    Given que o sistema est� configurado
    When eu adiciono uma nova avalia��o no banco de dados com os seguintes detalhes:
      | Nome                | Nota   | AlunoAssociadoID | DisciplinaAssociadaID |
      | <Nome da Avalia��o> | <Nota> | <Aluno ID>       | <Disciplina ID>       |
    Then a avalia��o inserida deve estar correta

Examples:
  | Nome da Avalia��o | Nota | Aluno ID | Disciplina ID |
  | Avaliacao1        | 9.0  | 101      | 201           |



  Feature: Adicionar Avalia��o no Banco de Dados

  Scenario: Inserir nova avalia��o no banco de dados
    Given que o reposit�rio de avalia��es est� configurado
    And uma tabela de Avaliacoes existe no banco de dados em mem�ria
    When adiciono uma nova avalia��o com os seguintes detalhes:
      | IDAvaliacao | Nome         | Nota | AlunoAssociadoID | DisciplinaAssociadaID  |
      | 1           | Avaliacao1   | 9    | 101              | 201                    |
    Then a avalia��o � inserida no banco de dados com sucesso
    And posso recuperar a avalia��o do banco de dados

