using Xunit;
using Moq;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using GestaoProffff.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Testes.RepositorioTestes
{
    public class DisciplinaTestes
    {
        [Fact]
        public void BuscaDisciplina_DeveRetornarListaDeDisciplinas()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var disciplinaRepository = new DisciplinaRepository(configurationMock.Object);

            // Act
            var result = disciplinaRepository.BuscaDisciplina();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddDisciplina_DeveInserirNovaDisciplina()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var disciplinaRepository = new DisciplinaRepository(configurationMock.Object);

            var disciplinaModel = new DisciplinaModel
            {
                IDDisciplina = 1, 
                NomeDisciplina = "Nome da Disciplina",
                ProfessorResponsavelID = 1, 
                ProfessorMinistrante = "Nome do Professor Ministrante"
            };

            // Act
            disciplinaRepository.AddDisciplina(disciplinaModel);

            // Assert            
            var disciplinaInserida = disciplinaRepository.BuscaDisciplina().FirstOrDefault(d => d.IDDisciplina == disciplinaModel.IDDisciplina);

            Assert.NotNull(disciplinaInserida);
            Assert.Equal(disciplinaModel.IDDisciplina, disciplinaInserida.IDDisciplina);
            Assert.Equal(disciplinaModel.NomeDisciplina, disciplinaInserida.NomeDisciplina);
            Assert.Equal(disciplinaModel.ProfessorResponsavelID, disciplinaInserida.ProfessorResponsavelID);
            Assert.Equal(disciplinaModel.ProfessorMinistrante, disciplinaInserida.ProfessorMinistrante);
        }
    }
}
