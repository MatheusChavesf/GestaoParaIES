using Xunit;
using Moq;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using GestaoProffff.Models;
using System;
using System.Linq;

namespace Testes.RepositorioTestes
{
    public class PresencaRepositoryTestes
    {
        [Fact]
        public void GetPresencas_DeveRetornarListaDePresencas()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var presencaRepository = new PresencaRepository(configurationMock.Object);

            // Act
            var result = presencaRepository.GetPresencas();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPresencaById_DeveRetornarPresencaCorreta()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var presencaRepository = new PresencaRepository(configurationMock.Object);
            int presencaId = 1;

            // Act
            var result = presencaRepository.GetPresencaById(presencaId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PresencaModel>(result);
            Assert.Equal(presencaId, result.IDPresenca);
        }

        [Fact]
        public void AdicionarPresenca_DeveInserirNovaPresenca()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var presencaRepository = new PresencaRepository(configurationMock.Object);
            var presencaModel = new PresencaModel
            {
                Data = DateTime.Now,
                AlunoPresenteID = 1,
                DisciplinaID = 1
            };

            // Act
            presencaRepository.AdicionarPresenca(presencaModel);

            // Assert
            var presencaInserida = presencaRepository.GetPresencaById(presencaModel.IDPresenca);

            Assert.NotNull(presencaInserida);
            Assert.Equal(presencaModel.IDPresenca, presencaInserida.IDPresenca);
            Assert.Equal(presencaModel.Data, presencaInserida.Data);
            Assert.Equal(presencaModel.AlunoPresenteID, presencaInserida.AlunoPresenteID);
            Assert.Equal(presencaModel.DisciplinaID, presencaInserida.DisciplinaID);
        }
    }
}
