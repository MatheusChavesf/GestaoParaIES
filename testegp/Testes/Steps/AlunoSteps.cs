using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Moq;
using TechTalk.SpecFlow;
using GestaoProffff.Models;
using GestaoProffff.Repository;
using Xunit;

namespace Testes.Steps
{
    [Binding]
    public class AlunoSteps
    {
        private AlunoRepository alunoRepository;
        private List<AlunoModel> alunosEncontrados;
        private AlunoModel novoAluno;

        public AlunoSteps()
        {
            var configurationMock = new Mock<IConfiguration>();
            alunoRepository = new AlunoRepository(configurationMock.Object);
        }

        [When(@"o usuário busca por alunos")]
        public void WhenOUsuarioBuscaPorAlunos()
        {            
            alunosEncontrados = alunoRepository.BuscarAlunos().ToList();

            ScenarioContext.Current.Add("AlunosEncontrados", alunosEncontrados);
        }


        [Then(@"a lista de alunos é retornada")]
        public void ThenAListaDeAlunosERetornada()
        {
            alunosEncontrados = ScenarioContext.Current.Get<List<AlunoModel>>("AlunosEncontrados");

            Assert.NotNull(alunosEncontrados);
            Assert.True(alunosEncontrados.Count > 0, "A lista de alunos deveria conter pelo menos um aluno.");
        }

        [When(@"o usuário adiciona um novo aluno")]
        public void WhenOUsuarioAdicionaUmNovoAluno()
        {           
            novoAluno = new AlunoModel
            {
                MatriculaAluno = 54321,
                NomeAluno = "Novo Aluno",
                EmailAluno = "novo@email.com",
                TelefoneAluno = "987654321",
                CursoAluno = "Novo Curso"
            };

            alunoRepository.AdicionarAluno(novoAluno);
                        
            ScenarioContext.Current.Add("NovoAluno", novoAluno);
        }        
    }
}
