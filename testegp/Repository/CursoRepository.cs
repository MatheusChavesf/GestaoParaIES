// CursoRepository.cs
using System.Collections.Generic;
using System.Data;
using Dapper;
using GestaoProffff.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GestaoProffff.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly IConfiguration _configuration;

        public CursoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<CursoModel> GetAllCursos()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                return db.Query<CursoModel>("SELECT IDCurso, NomeCurso FROM cursos").ToList();
            }
        }

        public CursoModel GetCursoById(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                return db.QueryFirstOrDefault<CursoModel>("SELECT IDCurso, NomeCurso FROM cursos WHERE IDCurso = @id", new { id });
            }
        }

        public void AddCurso(CursoModel curso)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"INSERT INTO cursos (NomeCurso) VALUES (@NomeCurso)";
                db.Execute(sql, curso);
            }
        }

        public void UpdateCurso(CursoModel curso)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"UPDATE cursos SET NomeCurso = @NomeCurso WHERE IDCurso = @IDCurso";
                db.Execute(sql, curso);
            }
        }

        public void DeleteCurso(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = "DELETE FROM cursos WHERE IDCurso = @id";
                db.Execute(sql, new { id });
            }
        }
    }
}
