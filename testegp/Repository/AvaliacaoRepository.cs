using Dapper;
using GestaoProffff.Models;
using GestaoProffff.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

public class AvaliacaoRepository : IAvaliacaoRepository
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<AvaliacaoRepository> _logger;

    public AvaliacaoRepository(IConfiguration configuration, ILogger<AvaliacaoRepository> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public void AddAvaliacao(AvaliacaoModel avaliacao)
    {
        using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            try
            {
                db.Open();

                string sql = @"INSERT INTO Avaliacoes (IDAvaliacao, Nome, Nota, AlunoAssociadoID, DisciplinaAssociadaID)
                               VALUES (@IDAvaliacao, @Nome, @Nota, @AlunoAssociadoID, @DisciplinaAssociadaID)";
                db.Execute(sql, avaliacao);

                _logger.LogInformation("Avaliação adicionada ao banco de dados.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar a avaliação no banco de dados.");
                throw;
            }
        }
    }

    public IEnumerable<AvaliacaoModel> BuscarAvaliacoesComListas()
    {
        using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            db.Open();

            var query = @"SELECT a.IDAvaliacao, a.Nome, a.Nota, a.AlunoAssociadoID, a.DisciplinaAssociadaID,
                      d.IDDisciplina, d.NomeDisciplina,
                      al.IDAluno, al.MatriculaAluno, al.NomeAluno
                      FROM Avaliacoes a
                      LEFT JOIN Disciplinas d ON a.DisciplinaAssociadaID = d.IDDisciplina
                      LEFT JOIN dadosalunos al ON a.AlunoAssociadoID = al.IDAluno";

            var avaliacoes = db.Query<AvaliacaoModel, DisciplinaModel, AlunoModel, AvaliacaoModel>(
                query,
                (avaliacao, disciplina, aluno) =>
                {
                    avaliacao.DisciplinasDisponiveis = avaliacao.DisciplinasDisponiveis ?? new List<DisciplinaModel>();
                    avaliacao.AlunosDisponiveis = avaliacao.AlunosDisponiveis ?? new List<AlunoModel>();

                    if (disciplina != null && !avaliacao.DisciplinasDisponiveis.Any(d => d.IDDisciplina == disciplina.IDDisciplina))
                        avaliacao.DisciplinasDisponiveis.Add(disciplina);

                    if (aluno != null && !avaliacao.AlunosDisponiveis.Any(a => a.IDAluno == aluno.IDAluno))
                        avaliacao.AlunosDisponiveis.Add(aluno);

                    return avaliacao;
                },
                splitOn: "IDDisciplina, IDAluno"
            );

            return avaliacoes.ToList();
        }
    }

}
