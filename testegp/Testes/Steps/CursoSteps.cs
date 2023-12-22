using System;
using System.Linq;
using GestaoProffff.Models;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
using TechTalk.SpecFlow;
using Xunit;

namespace Testes.Steps
{
    public class CursoSteps
    {
        private readonly IConfiguration _configuration;
        private readonly CursoRepository _cursoRepository;

        public CursoSteps()
        {
            // Configuração mock para IConfiguration
            var configurationMock = new Mock<IConfiguration>();
            _configuration = configurationMock.Object;

            // Inicialização do repositório
            _cursoRepository = new CursoRepository(_configuration);
        }

        [Given("que o curso com ID {int} existe no sistema")]
        public void GivenQueOCursoComIDExisteNoSistema(int cursoId)
        {
            var cursoModel = new CursoModel
            {
                IDCurso = cursoId,
                NomeCurso = $"Nome do Curso {cursoId}"
            };

            _cursoRepository.AddCurso(cursoModel);
        }

        [When("eu obtenho o curso com ID {int}")]
        public void WhenEuObtenhoOCursoComID(int cursoId)
        {
            // Obtém o curso com o ID especificado
            var result = _cursoRepository.GetCursoById(cursoId);

            // Armazena o resultado para verificação posterior
            ScenarioContext.Current.Set(result);
        }

        [When("eu adiciono um novo curso com o nome {string}")]
        public void WhenEuAdicionoUmNovoCursoComONome(string nomeCurso)
        {
            var novoCurso = new CursoModel
            {
                IDCurso = 0, // O ID será atribuído automaticamente
                NomeCurso = nomeCurso
            };

            // Adiciona o novo curso
            _cursoRepository.AddCurso(novoCurso);

            // Armazena o novo curso para verificação posterior
            ScenarioContext.Current.Set(novoCurso);
        }

        [When("eu atualizo o nome do curso para {string}")]
        public void WhenEuAtualizoONomeDoCursoPara(string novoNomeCurso)
        {
            // Obtém o curso armazenado durante a criação
            var cursoAtualizado = ScenarioContext.Current.Get<CursoModel>();

            // Atualiza o nome do curso
            cursoAtualizado.NomeCurso = novoNomeCurso;

            // Atualiza o curso no repositório
            _cursoRepository.UpdateCurso(cursoAtualizado);
        }

        [When("eu excluo o curso com ID {int}")]
        public void WhenEuExcluoOCursoComID(int cursoId)
        {
            
            _cursoRepository.DeleteCurso(cursoId);
        }

        [Then("o sistema retorna o curso com o nome {string}")]
        public void ThenOSistemaRetornaOCursoComONome(string expectedNomeCurso)
        {
            
            var cursoObtido = ScenarioContext.Current.Get<CursoModel>();
            
            Assert.NotNull(cursoObtido);
            Assert.Equal(expectedNomeCurso, cursoObtido.NomeCurso);
        }

        [Then("o sistema não possui mais o curso com ID {int}")]
        public void ThenOSistemaNaoPossuiOMaisOCursoComID(int cursoId)
        {
            
            var cursoExcluido = _cursoRepository.GetCursoById(cursoId);
            Assert.Null(cursoExcluido);
        }
    }
}
