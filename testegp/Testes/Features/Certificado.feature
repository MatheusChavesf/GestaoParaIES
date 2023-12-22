Feature: Adicionar Certificado

  Scenario: Adicionar Novo Certificado
    Given que o sistema está configurado
    When eu adiciono um novo certificado
    Then o certificado inserido deve estar correto

Examples:
  | Tipo   | DataEmissao       | Aluno_ID | MatriculaAluno  | NomeAluno       | EmailAluno      | TelefoneAluno   | CursoAluno       |
  | Tipo   | <Data de Emissao> | <AlunoID> | <Matricula>    | <Nome do Aluno> | <Email do Aluno> | <TelefoneAluno> | <Curso do Aluno> |


Feature: Adicionar Certificado

  Scenario: Adicionar um certificado com os detalhes corretos
    Given que estou na página de certificados
    When eu adiciono um certificado com os seguintes detalhes:
      | Tipo         | DataEmissao         | AlunoAssociadoID |
      | Certificado1 | 2023-01-01T12:00:00 | 1                |
    Then o certificado é adicionado com sucesso

