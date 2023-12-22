using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using GestaoProffff.Models;
using GestaoProffff.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Testes.RepositorioTestes
{
    public class AvaliacaoRepositoryTestes
    {
        [Fact]
        public void AddAvaliacao_DeveInserirNovaAvaliacaoNoBancoDeDados()
        {
            // Arrange
            var connection = new SQLiteConnection("Data Source=:memory:");
            connection.Open();

            var avaliacaoRepository = new AvaliacaoRepository(GetConfiguration(), GetLogger());

            // Criação da tabela em memória
            connection.Execute(@"
                CREATE TABLE Avaliacoes (
                    IDAvaliacao INTEGER PRIMARY KEY,
                    Nome TEXT,
                    Nota REAL,
                    AlunoAssociadoID INTEGER,
                    DisciplinaAssociadaID INTEGER
                )");

            var avaliacaoModel = new AvaliacaoModel
            {
                IDAvaliacao = 1,
                Nome = "Avaliacao1",
                Nota = 9,
                AlunoAssociadoID = 101,
                DisciplinaAssociadaID = 201
            };

            // Act
            avaliacaoRepository.AddAvaliacao(avaliacaoModel);

            // Assert
            var avaliacaoInserida = connection.Query<AvaliacaoModel>(
                "SELECT * FROM Avaliacoes WHERE IDAvaliacao = @IDAvaliacao",
                new { IDAvaliacao = avaliacaoModel.IDAvaliacao }
            ).FirstOrDefault();

            Assert.NotNull(avaliacaoInserida);
            Assert.Equal(avaliacaoModel.Nome, avaliacaoInserida.Nome);
            Assert.Equal(avaliacaoModel.Nota, avaliacaoInserida.Nota);
            Assert.Equal(avaliacaoModel.AlunoAssociadoID, avaliacaoInserida.AlunoAssociadoID);
            Assert.Equal(avaliacaoModel.DisciplinaAssociadaID, avaliacaoInserida.DisciplinaAssociadaID);

            connection.Close();
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
