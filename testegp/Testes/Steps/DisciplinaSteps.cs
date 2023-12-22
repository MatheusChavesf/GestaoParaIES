using TechTalk.SpecFlow;
using Xunit;
using Moq;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using GestaoProffff.Models;
using System.Linq;

[Binding]
public class DisciplinaSteps
{
    private readonly DisciplinaRepository disciplinaRepository;
    private DisciplinaModel disciplinaModel;
    private IQueryable<DisciplinaModel> disciplinasResult;

    public DisciplinaSteps()
    {
        var configurationMock = new Mock<IConfiguration>();
        disciplinaRepository = new DisciplinaRepository(configurationMock.Object);
    }

    [Given("que há disciplinas cadastradas")]
    public void GivenHaDisciplinasCadastradas()
    {
        // Adiciona algumas disciplinas fictícias ao repositório para testar a busca
        var disciplinasFicticias = new List<DisciplinaModel>
    {
        new DisciplinaModel { IDDisciplina = 1, NomeDisciplina = "Matemática", ProfessorResponsavelID = 101, ProfessorMinistrante = "Prof. Matemático" },
        new DisciplinaModel { IDDisciplina = 2, NomeDisciplina = "História", ProfessorResponsavelID = 102, ProfessorMinistrante = "Prof. Historiador" },
        // Adicione mais disciplinas conforme necessário
    };

        foreach (var disciplina in disciplinasFicticias)
        {
            disciplinaRepository.AddDisciplina(disciplina);
        }
    }


    [When("eu realizo uma busca por disciplinas")]
    public void WhenEuRealizoUmaBuscaPorDisciplinas()
    {
        disciplinasResult = disciplinaRepository.BuscaDisciplina().AsQueryable();
    }

    [Given("que não há uma disciplina com o nome {string}")]
    public void GivenQueNaoHaUmaDisciplinaComONome(string nomeDisciplina)
    {
       
        var disciplinaExistente = disciplinaRepository.BuscaDisciplina().FirstOrDefault(d => d.NomeDisciplina == nomeDisciplina);
        if (disciplinaExistente != null)
        {
            disciplinaRepository.DeleteDisciplina(disciplinaExistente.IDDisciplina);
        }
    }


    [When("eu adiciono uma nova disciplina com o nome {string}, Professor Responsável ID {int} e Professor Ministrante {string}")]
    public void WhenEuAdicionoUmaNovaDisciplinaComONomeProfessorResponsavelIDEProfessorMinistrante(string nomeDisciplina, int professorResponsavelID, string professorMinistrante)
    {
        disciplinaModel = new DisciplinaModel
        {
            IDDisciplina = 1,
            NomeDisciplina = nomeDisciplina,
            ProfessorResponsavelID = professorResponsavelID,
            ProfessorMinistrante = professorMinistrante
        };
        disciplinaRepository.AddDisciplina(disciplinaModel);
    }

    [Then("uma lista de disciplinas é retornada")]
    public void ThenUmaListaDeDisciplinasERetornada()
    {
        Assert.NotNull(disciplinasResult);        
        Assert.NotEmpty(disciplinasResult);
    }

    [Then("a disciplina {string} é adicionada com sucesso")]
    public void ThenADisciplinaEAdicionadaComSucesso(string nomeDisciplina)
    {
        var disciplinaInserida = disciplinasResult.FirstOrDefault(d => d.NomeDisciplina == nomeDisciplina);
        Assert.NotNull(disciplinaInserida);
        Assert.Equal(disciplinaModel.ProfessorResponsavelID, disciplinaInserida.ProfessorResponsavelID);
        Assert.Equal(disciplinaModel.ProfessorMinistrante, disciplinaInserida.ProfessorMinistrante);
    }
}
