using System.Data.SQLite;
using System.Linq;
using Dapper;
using GestaoProffff.Models;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Testes.Steps
{
    [Binding]
    public class AvaliacaoSteps
    {
        private AvaliacaoRepository avaliacaoRepository;
        private AvaliacaoModel avaliacaoModel;
        private AvaliacaoModel avaliacaoInserida;

        [Given(@"uma instância do repositório de avaliações")]
        public void GivenUmaInstanciaDoRepositorioDeAvaliacoes()
        {
            avaliacaoRepository = new AvaliacaoRepository(GetConfiguration(), GetLogger());
        }

        [When(@"eu adiciono uma avaliação com os detalhes")]
        public void WhenEuAdicionoUmaAvaliacaoComOsDetalhes(Table table)
        {
            avaliacaoModel = table.CreateInstance<AvaliacaoModel>();
            avaliacaoRepository.AddAvaliacao(avaliacaoModel);
        }

        [Then(@"posso recuperar a avaliação do banco de dados")]
        public void ThenPossoRecuperarAAvaliacaoDoBancoDeDados()
        {
            using (var connection = new SQLiteConnection("Data Source=:memory:"))
            {
                connection.Open();

                avaliacaoInserida = Dapper.SqlMapper.Query<AvaliacaoModel>(
                    connection,
                    "SELECT * FROM Avaliacoes WHERE IDAvaliacao = @IDAvaliacao",
                    new { IDAvaliacao = avaliacaoModel.IDAvaliacao }
                ).FirstOrDefault();
            }

            Assert.NotNull(avaliacaoInserida);
            Assert.Equal(avaliacaoModel.Nome, avaliacaoInserida.Nome);
            Assert.Equal(avaliacaoModel.Nota, avaliacaoInserida.Nota);
            Assert.Equal(avaliacaoModel.AlunoAssociadoID, avaliacaoInserida.AlunoAssociadoID);
            Assert.Equal(avaliacaoModel.DisciplinaAssociadaID, avaliacaoInserida.DisciplinaAssociadaID);
        }

        private IConfiguration GetConfiguration()
        {
            return new Mock<IConfiguration>().Object;
        }

        private ILogger<AvaliacaoRepository> GetLogger()
        {
            return new Mock<ILogger<AvaliacaoRepository>>().Object;
        }
    }
}
