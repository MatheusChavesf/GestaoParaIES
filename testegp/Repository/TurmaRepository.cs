using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GestaoProffff.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GestaoProffff.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly IConfiguration _configuration;

        public TurmaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<TurmaModel> GetAllTurmas()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                return db.Query<TurmaModel>("SELECT IDTurma, Nome, CursoAssociadoID FROM Turmas").ToList();
            }
        }

        public TurmaModel GetTurmaById(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                return db.QueryFirstOrDefault<TurmaModel>("SELECT IDTurma, Nome, CursoAssociadoID FROM Turmas WHERE IDTurma = @Id", new { Id = id });
            }
        }

        public void AddTurma(TurmaModel turma)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"INSERT INTO Turmas (Nome, CursoAssociadoID)
                               VALUES (@Nome, @CursoAssociadoID)";
                db.Execute(sql, turma);
            }
        }

        public void UpdateTurma(TurmaModel turma)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"UPDATE Turmas
                               SET Nome = @Nome, CursoAssociadoID = @CursoAssociadoID
                               WHERE IDTurma = @IDTurma";
                db.Execute(sql, turma);
            }
        }

        public void DeleteTurma(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                string sql = "DELETE FROM Turmas WHERE IDTurma = @Id";
                db.Execute(sql, new { Id = id });
            }
        }
    }
}
