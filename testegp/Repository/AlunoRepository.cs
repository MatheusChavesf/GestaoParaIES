using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using GestaoProffff.Models;

namespace GestaoProffff.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IConfiguration _configuration;

        public AlunoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<AlunoModel> BuscarAlunos()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                return db.Query<AlunoModel>("SELECT IDAluno, MatriculaAluno, NomeAluno, EmailAluno, TelefoneAluno, CursoAluno FROM dadosalunos").ToList();
            }
        }

        public void AdicionarAluno(AlunoModel aluno)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"INSERT INTO dadosalunos (MatriculaAluno, NomeAluno, EmailAluno, TelefoneAluno, CursoAluno)
                               VALUES (@MatriculaAluno, @NomeAluno, @EmailAluno, @TelefoneAluno, @CursoAluno)";
                db.Execute(sql, aluno);
            }
        }

    }
}
