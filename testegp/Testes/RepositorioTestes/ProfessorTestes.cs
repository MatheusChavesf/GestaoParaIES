using System;
using System.Collections.Generic;
using GestaoProffff.Models;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Testes.RepositorioTestes
{
    public class ProfessorRepositoryTestes
    {
        [Fact]
        public void BuscarProfessores_DeveRetornarListaDeProfessores()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var professorRepository = new ProfessorRepository(configurationMock.Object);

            // Act
            var result = professorRepository.BuscarProfessores();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ProfessorModel>>(result);
        }

        [Fact]
        public void AdicionarProfessor_DeveInserirNovoProfessor()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var professorRepository = new ProfessorRepository(configurationMock.Object);
            var professorModel = new ProfessorModel
            {
                NomeProfessor = "Nome do Professor",
                MatriculaProfessor = "12345",
                DataNascimento = DateTime.Now,
                DisciplinaMinistrada = "Matemática"
            };

            // Act
            professorRepository.AdicionarProfessor(professorModel);

            // Assert            
            var professores = professorRepository.BuscarProfessores();
            var professorInserido = Assert.Single(professores);

            Assert.NotNull(professorInserido);
            Assert.Equal(professorModel.NomeProfessor, professorInserido.NomeProfessor);
            Assert.Equal(professorModel.MatriculaProfessor, professorInserido.MatriculaProfessor);
            Assert.Equal(professorModel.DataNascimento, professorInserido.DataNascimento);
            Assert.Equal(professorModel.DisciplinaMinistrada, professorInserido.DisciplinaMinistrada);
        }
    }
}
