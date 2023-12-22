using System;
using System.Collections.Generic;
using GestaoProffff.Models;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Testes.RepositorioTestes
{
    public class TurmaRepositoryTestes
    {
        [Fact]
        public void GetAllTurmas_DeveRetornarListaDeTurmas()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var turmaRepository = new TurmaRepository(configurationMock.Object);

            // Act
            var result = turmaRepository.GetAllTurmas();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<TurmaModel>>(result);
        }

        [Fact]
        public void GetTurmaById_DeveRetornarTurmaCorreta()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var turmaRepository = new TurmaRepository(configurationMock.Object);
            int turmaId = 1;

            // Act
            var result = turmaRepository.GetTurmaById(turmaId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TurmaModel>(result);
            Assert.Equal(turmaId, result.IDTurma);
        }

        [Fact]
        public void AddTurma_DeveInserirNovaTurma()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var turmaRepository = new TurmaRepository(configurationMock.Object);
            var turmaModel = new TurmaModel
            {
                Nome = "Turma A",                
            };

            // Act
            turmaRepository.AddTurma(turmaModel);

            // Assert            
            var turmas = turmaRepository.GetAllTurmas();
            var turmaInserida = Assert.Single(turmas);

            Assert.NotNull(turmaInserida);
            Assert.Equal(turmaModel.Nome, turmaInserida.Nome);
            Assert.Equal(turmaModel.CursoAssociadoID, turmaInserida.CursoAssociadoID);
        }

        [Fact]
        public void UpdateTurma_DeveAtualizarTurma()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var turmaRepository = new TurmaRepository(configurationMock.Object);
            var turmaModel = new TurmaModel
            {
                IDTurma = 1,
                Nome = "Turma A",
                
            };

            // Act
            turmaRepository.UpdateTurma(turmaModel);

            // Assert
            var turmaAtualizada = turmaRepository.GetTurmaById(turmaModel.IDTurma);

            Assert.NotNull(turmaAtualizada);
            Assert.Equal(turmaModel.Nome, turmaAtualizada.Nome);
            Assert.Equal(turmaModel.CursoAssociadoID, turmaAtualizada.CursoAssociadoID);
        }

        [Fact]
        public void DeleteTurma_DeveExcluirTurma()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var turmaRepository = new TurmaRepository(configurationMock.Object);
            var turmaModel = new TurmaModel
            {
                IDTurma = 1,
                Nome = "Turma A"
            };

            // Act
            turmaRepository.DeleteTurma(turmaModel.IDTurma);

            // Assert
            var turmaExcluida = turmaRepository.GetTurmaById(turmaModel.IDTurma);
            Assert.Null(turmaExcluida);
        }
    }
}

namespace Testes.ModeloTestes
{
    public class TurmaModelTestes
    {
        [Fact]
        public void TurmaModel_DeveTerPropriedadesCorretas()
        {
            // Arrange
            var turmaModel = new TurmaModel();

            // Assert
            Assert.Equal(0, turmaModel.IDTurma);
            Assert.Null(turmaModel.Nome);
            Assert.Null(turmaModel.CursoAssociado);
            Assert.Null(turmaModel.AlunosMatriculados);
            Assert.Null(turmaModel.CursosDisponiveis);
            Assert.Null(turmaModel.AlunosDisponiveis);
        }
    }
}
