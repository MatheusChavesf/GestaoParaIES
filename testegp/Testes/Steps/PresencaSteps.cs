using System;
using System.Collections.Generic;
using System.Linq;
using GestaoProffff.Models;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
using TechTalk.SpecFlow;

[Binding]
public class PresencaSteps
{
    private readonly PresencaRepository _presencaRepository;
    private readonly Mock<IConfiguration> _configurationMock;

    public PresencaSteps()
    {
        _configurationMock = new Mock<IConfiguration>();
        _presencaRepository = new PresencaRepository(_configurationMock.Object);
    }

    [Given(@"que há presenças cadastradas")]
    public void GivenQueHaPresencasCadastradas()
    {
        
        var presencasFicticias = new List<PresencaModel>
        {
            new PresencaModel { IDPresenca = 1, Data = DateTime.Now.AddDays(-1), AlunoPresenteID = 101, DisciplinaID = 201 },
            new PresencaModel { IDPresenca = 2, Data = DateTime.Now.AddDays(-2), AlunoPresenteID = 102, DisciplinaID = 202 },
            new PresencaModel { IDPresenca = 3, Data = DateTime.Now.AddDays(-3), AlunoPresenteID = 103, DisciplinaID = 203 },
        };

        foreach (var presenca in presencasFicticias)
        {
            _presencaRepository.AdicionarPresenca(presenca);
        }
    }
}
