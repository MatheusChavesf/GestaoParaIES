using Xunit;
using Moq;
using GestaoProffff.Repository;
using GestaoProffff.Models;

namespace Testes.RepositorioTestes
{
    public class CertificadoTestes
    {
        [Fact]
        public void AdicionarCertificado_DeveInserirNovoCertificado()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var certificadoRepository = new CertificadoRepository(configurationMock.Object);

            var alunoAssociado = new AlunoModel
            {
                IDAluno = 1, 
                MatriculaAluno = 12345,
                NomeAluno = "Nome do Aluno",
                EmailAluno = "email@example.com",
                TelefoneAluno = "123456789",
                CursoAluno = "Curso"
            };

            var certificadoModel = new CertificadoModel
            {
                IDCertificado = 1, 
                Tipo = "Tipo",
                DataEmissao = DateTime.Now,
                AlunoAssociado = alunoAssociado
            };

            // Act
            certificadoRepository.AdicionarCertificado(certificadoModel);

            // Assert            
            var certificadoInserido = certificadoRepository.GetCertificados().FirstOrDefault(c => c.IDCertificado == certificadoModel.IDCertificado);

            Assert.NotNull(certificadoInserido);
            Assert.Equal(certificadoModel.IDCertificado, certificadoInserido.IDCertificado);
            Assert.Equal(certificadoModel.Tipo, certificadoInserido.Tipo);
            Assert.Equal(certificadoModel.DataEmissao, certificadoInserido.DataEmissao);
            Assert.NotNull(certificadoInserido.AlunoAssociado);
            Assert.Equal(alunoAssociado.IDAluno, certificadoInserido.AlunoAssociado.IDAluno);
            Assert.Equal(alunoAssociado.MatriculaAluno, certificadoInserido.AlunoAssociado.MatriculaAluno);
            Assert.Equal(alunoAssociado.NomeAluno, certificadoInserido.AlunoAssociado.NomeAluno);
            Assert.Equal(alunoAssociado.EmailAluno, certificadoInserido.AlunoAssociado.EmailAluno);
            Assert.Equal(alunoAssociado.TelefoneAluno, certificadoInserido.AlunoAssociado.TelefoneAluno);
            Assert.Equal(alunoAssociado.CursoAluno, certificadoInserido.AlunoAssociado.CursoAluno);
        }
    }
}
