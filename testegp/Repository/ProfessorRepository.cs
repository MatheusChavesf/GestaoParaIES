using System.Collections.Generic;
using System.Data;
using Dapper;
using GestaoProffff.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GestaoProffff.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly IConfiguration _configuration;

        public ProfessorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<ProfessorModel> BuscarProfessores()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                return db.Query<ProfessorModel>("SELECT IDProfessor, NomeProfessor, MatriculaProfessor, DataNascimento, DisciplinaMinistrada FROM dadosprofessores").ToList();
            }
        }

        public void AdicionarProfessor(ProfessorModel professor)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"INSERT INTO dadosprofessores (NomeProfessor, MatriculaProfessor, DataNascimento, DisciplinaMinistrada)
                       VALUES (@NomeProfessor, @MatriculaProfessor, @DataNascimento, @DisciplinaMinistrada)";
                db.Execute(sql, professor);
            }
        }

    }
}
