// PresencaRepository.cs
using Dapper;
using GestaoProffff.Models;
using GestaoProffff.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GestaoProffff.Repository
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly IConfiguration _configuration;

        public PresencaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<PresencaModel> GetPresencas()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                string sql = @"SELECT P.IDPresenca, P.Data, P.AlunoPresenteID, P.DisciplinaID, 
                               A.IDAluno, A.NomeAluno, D.IDDisciplina, D.NomeDisciplina
                               FROM Presencas P
                               INNER JOIN Alunos A ON P.AlunoPresenteID = A.IDAluno
                               INNER JOIN Disciplinas D ON P.DisciplinaID = D.IDDisciplina";
                return db.Query<PresencaModel, AlunoModel, DisciplinaModel, PresencaModel>(
                    sql,
                    (presenca, aluno, disciplina) =>
                    {
                        presenca.AlunoPresente = aluno;
                        presenca.Disciplina = disciplina;
                        return presenca;
                    },
                    splitOn: "IDAluno, IDDisciplina"
                ).ToList();
            }
        }

        public PresencaModel GetPresencaById(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                string sql = @"SELECT P.IDPresenca, P.Data, P.AlunoPresenteID, P.DisciplinaID, 
                               A.IDAluno, A.NomeAluno, D.IDDisciplina, D.NomeDisciplina
                               FROM Presencas P
                               INNER JOIN Alunos A ON P.AlunoPresenteID = A.IDAluno
                               INNER JOIN Disciplinas D ON P.DisciplinaID = D.IDDisciplina
                               WHERE P.IDPresenca = @Id";
                return db.Query<PresencaModel, AlunoModel, DisciplinaModel, PresencaModel>(
                    sql,
                    (presenca, aluno, disciplina) =>
                    {
                        presenca.AlunoPresente = aluno;
                        presenca.Disciplina = disciplina;
                        return presenca;
                    },
                    new { Id = id },
                    splitOn: "IDAluno, IDDisciplina"
                ).FirstOrDefault();
            }
        }

        public void AdicionarPresenca(PresencaModel presenca)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"INSERT INTO Presencas (Data, AlunoPresenteID, DisciplinaID)
                               VALUES (@Data, @AlunoPresenteID, @DisciplinaID)";
                db.Execute(sql, presenca);
            }
        }

        public void AtualizarPresenca(PresencaModel presenca)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"UPDATE Presencas
                               SET Data = @Data, AlunoPresenteID = @AlunoPresenteID, DisciplinaID = @DisciplinaID
                               WHERE IDPresenca = @IDPresenca";
                db.Execute(sql, presenca);
            }
        }

        public void ExcluirPresenca(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"DELETE FROM Presencas WHERE IDPresenca = @Id";
                db.Execute(sql, new { Id = id });
            }
        }
    }
}
