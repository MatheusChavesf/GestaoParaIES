using Xunit;
using Moq;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using GestaoProffff.Models;
using NuGet.ContentModel;

namespace Testes.RepositorioTestes
{
    public class AlunoTestes
    {
        [Fact]
        public void BuscarAlunos_DeveRetornarListaDeAlunos()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var alunoRepository = new AlunoRepository(configurationMock.Object);

            // Act
            var result = alunoRepository.BuscarAlunos();

            // Assert
            Assert.NotNull(result);
            
        }

        // Método de teste para AdicionarAluno
        [Fact]
        public void AdicionarAluno_DeveInserirNovoAluno()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var alunoRepository = new AlunoRepository(configurationMock.Object);

            var alunoModel = new AlunoModel
            {
                MatriculaAluno = 12345,
                NomeAluno = "Nome do Aluno",
                EmailAluno = "email@example.com",
                TelefoneAluno = "123456789",
                CursoAluno = "Curso"
            };

            // Act
            alunoRepository.AdicionarAluno(alunoModel);

            // Assert            
            var alunoInserido = alunoRepository.BuscarAlunos().FirstOrDefault(a => a.MatriculaAluno == alunoModel.MatriculaAluno);

            Assert.NotNull(alunoInserido);
            Assert.Equal(alunoModel.MatriculaAluno, alunoInserido.MatriculaAluno);
            Assert.Equal(alunoModel.NomeAluno, alunoInserido.NomeAluno);
            Assert.Equal(alunoModel.EmailAluno, alunoInserido.EmailAluno);
            Assert.Equal(alunoModel.TelefoneAluno, alunoInserido.TelefoneAluno);
            Assert.Equal(alunoModel.CursoAluno, alunoInserido.CursoAluno);

        }
    }
}
