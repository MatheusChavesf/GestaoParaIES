using System;
using System.Collections.Generic;
using GestaoProffff.Models;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
using TechTalk.SpecFlow;
using Xunit;

[Binding]
public class ProfessorRepositorySteps
{
    private readonly IConfiguration _configuration;
    private readonly ProfessorRepository _professorRepository;
    private List<ProfessorModel> _resultProfessores;

    public ProfessorRepositorySteps()
    {
        _configuration = new Mock<IConfiguration>().Object;
        _professorRepository = new ProfessorRepository(_configuration);
        _resultProfessores = new List<ProfessorModel>();
    }

    [Given(@"que há professores cadastrados")]
    public void GivenHaProfessoresCadastrados()
    {
        
        var professorModel = new ProfessorModel
        {
            NomeProfessor = "Nome do Professor",
            MatriculaProfessor = "12345",
            DataNascimento = DateTime.Now,
            DisciplinaMinistrada = "Matemática"
        };

        _professorRepository.AdicionarProfessor(professorModel);
    }

    [When(@"eu busco a lista de professores")]
    public void WhenEuBuscoAListaDeProfessores()
    {
        _resultProfessores = (List<ProfessorModel>)_professorRepository.BuscarProfessores();
    }

    [Then(@"a lista de professores não está vazia")]
    public void ThenAListaDeProfessoresNaoEstaVazia()
    {
        Assert.NotNull(_resultProfessores);
        Assert.NotEmpty(_resultProfessores);
    }
    

    [When(@"eu adiciono um novo professor")]
    public void WhenEuAdicionoUmNovoProfessor()
    {
        var novoProfessorModel = new ProfessorModel
        {
            NomeProfessor = "Novo Professor",
            MatriculaProfessor = "67890",
            DataNascimento = DateTime.Now,
            DisciplinaMinistrada = "História"
        };

        _professorRepository.AdicionarProfessor(novoProfessorModel);
        _resultProfessores = (List<ProfessorModel>)_professorRepository.BuscarProfessores();
    }

    [Then(@"a lista de professores contém um único professor")]
    public void ThenAListaDeProfessoresContemUmUnicoProfessor()
    {
        Assert.Single(_resultProfessores);
    }

    [Then(@"as propriedades do professor estão corretas")]
    public void ThenAsPropriedadesDoProfessorEstaoCorretas()
    {
        var professorInserido = Assert.Single(_resultProfessores);

        Assert.NotNull(professorInserido);
        Assert.Equal("Novo Professor", professorInserido.NomeProfessor);
        Assert.Equal("67890", professorInserido.MatriculaProfessor);
        
    }
}
