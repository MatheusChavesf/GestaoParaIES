using System.Collections.Generic;
using System.Data;
using Dapper;
using GestaoProffff.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GestaoProffff.Repository
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly IConfiguration _configuration;

        public DisciplinaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<DisciplinaModel> BuscaDisciplina()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();                
                string sql = @"
                    SELECT d.IDDisciplina, d.NomeDisciplina, 
                           d.ProfessorResponsavelID, p.NomeProfessor AS ProfessorResponsavelNome,
                           d.ProfessorMinistrante
                    FROM disciplinasdados d
                    LEFT JOIN dadosprofessores p ON d.ProfessorResponsavelID = p.IDProfessor";
                return db.Query<DisciplinaModel>(sql).ToList();
            }
        }

        public void AddDisciplina(DisciplinaModel disciplina)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();                
                string sql = @"INSERT INTO disciplinasdados (NomeDisciplina, ProfessorResponsavelID, ProfessorMinistrante)
                               VALUES (@NomeDisciplina, @ProfessorResponsavelID, @ProfessorMinistrante)";
                db.Execute(sql, disciplina);
            }
        }

        internal void DeleteDisciplina(int iDDisciplina)
        {
            throw new NotImplementedException();
        }
    }
}
