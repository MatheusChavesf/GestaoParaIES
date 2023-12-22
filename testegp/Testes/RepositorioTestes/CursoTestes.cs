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
    public class CursoTestes
    {
        [Fact]
        public void GetAllCursos_DeveRetornarListaDeCursos()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var cursoRepository = new CursoRepository(configurationMock.Object);

            // Act
            var result = cursoRepository.GetAllCursos();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetCursoById_DeveRetornarCursoCorreto()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var cursoRepository = new CursoRepository(configurationMock.Object);

            var cursoModel = new CursoModel
            {
                IDCurso = 1, 
                NomeCurso = "Nome do Curso"
            };

            
            cursoRepository.AddCurso(cursoModel);

            // Act
            var result = cursoRepository.GetCursoById(cursoModel.IDCurso);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cursoModel.IDCurso, result.IDCurso);
            Assert.Equal(cursoModel.NomeCurso, result.NomeCurso);
        }

        [Fact]
        public void AddCurso_DeveInserirNovoCurso()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var cursoRepository = new CursoRepository(configurationMock.Object);

            var cursoModel = new CursoModel
            {
                IDCurso = 1, 
                NomeCurso = "Nome do Curso"
            };

            // Act
            cursoRepository.AddCurso(cursoModel);

            // Assert            
            var cursoInserido = cursoRepository.GetAllCursos().FirstOrDefault(c => c.IDCurso == cursoModel.IDCurso);

            Assert.NotNull(cursoInserido);
            Assert.Equal(cursoModel.IDCurso, cursoInserido.IDCurso);
            Assert.Equal(cursoModel.NomeCurso, cursoInserido.NomeCurso);
        }

        [Fact]
        public void UpdateCurso_DeveAtualizarCursoCorretamente()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var cursoRepository = new CursoRepository(configurationMock.Object);

            var cursoModel = new CursoModel
            {
                IDCurso = 1, 
                NomeCurso = "Nome do Curso"
            };

            
            cursoRepository.AddCurso(cursoModel);

            
            cursoModel.NomeCurso = "Novo Nome do Curso";

            // Act
            cursoRepository.UpdateCurso(cursoModel);

            // Assert            
            var cursoAtualizado = cursoRepository.GetAllCursos().FirstOrDefault(c => c.IDCurso == cursoModel.IDCurso);

            Assert.NotNull(cursoAtualizado);
            Assert.Equal(cursoModel.IDCurso, cursoAtualizado.IDCurso);
            Assert.Equal(cursoModel.NomeCurso, cursoAtualizado.NomeCurso);
        }

        [Fact]
        public void DeleteCurso_DeveExcluirCursoCorretamente()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var cursoRepository = new CursoRepository(configurationMock.Object);

            var cursoModel = new CursoModel
            {
                IDCurso = 1, 
                NomeCurso = "Nome do Curso"
            };

            
            cursoRepository.AddCurso(cursoModel);

            // Act
            cursoRepository.DeleteCurso(cursoModel.IDCurso);

            // Assert            
            var cursoExcluido = cursoRepository.GetAllCursos().FirstOrDefault(c => c.IDCurso == cursoModel.IDCurso);

            Assert.Null(cursoExcluido);
        }
    }
}
