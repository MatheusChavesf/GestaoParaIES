Feature: Adicionar Avaliação no Banco de Dados

  Scenario: Adicionar Nova Avaliação
    Given que o sistema está configurado
    When eu adiciono uma nova avaliação no banco de dados
    Then a avaliação inserida deve estar correta

  Scenario Outline: Adicionar Nova Avaliação com Dados Específicos
    Given que o sistema está configurado
    When eu adiciono uma nova avaliação no banco de dados com os seguintes detalhes:
      | Nome                | Nota   | AlunoAssociadoID | DisciplinaAssociadaID |
      | <Nome da Avaliação> | <Nota> | <Aluno ID>       | <Disciplina ID>       |
    Then a avaliação inserida deve estar correta

Examples:
  | Nome da Avaliação | Nota | Aluno ID | Disciplina ID |
  | Avaliacao1        | 9.0  | 101      | 201           |



  Feature: Adicionar Avaliação no Banco de Dados

  Scenario: Inserir nova avaliação no banco de dados
    Given que o repositório de avaliações está configurado
    And uma tabela de Avaliacoes existe no banco de dados em memória
    When adiciono uma nova avaliação com os seguintes detalhes:
      | IDAvaliacao | Nome         | Nota | AlunoAssociadoID | DisciplinaAssociadaID  |
      | 1           | Avaliacao1   | 9    | 101              | 201                    |
    Then a avaliação é inserida no banco de dados com sucesso
    And posso recuperar a avaliação do banco de dados

