using Dapper;
using GestaoProffff.Models;
using GestaoProffff.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace GestaoProffff.Repository
{
    public class MensalidadeRepository : IMensalidadeRepository
    {
        private readonly IConfiguration _configuration;

        public MensalidadeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<MensalidadeModel> GetMensalidades()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                string sql = @"SELECT M.IDMensalidade, M.Valor, M.DataVencimento, M.AlunoAssociadoID, A.IDAluno, A.NomeAluno
                       FROM dadosmensalidades M
                       INNER JOIN dadosalunos A ON M.AlunoAssociadoID = A.IDAluno";
                return db.Query<MensalidadeModel, AlunoModel, MensalidadeModel>(
                    sql,
                    (mensalidade, aluno) =>
                    {
                        mensalidade.AlunoAssociado = aluno;
                        return mensalidade;
                    },
                    splitOn: "IDAluno"
                ).ToList();
            }
        }

        public MensalidadeModel GetMensalidadeById(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                return db.QueryFirstOrDefault<MensalidadeModel>("SELECT IDMensalidade, Valor, DataVencimento, AlunoAssociadoID FROM dadosmensalidades WHERE IDMensalidade = @Id", new { Id = id });
            }
        }

        public void AdicionarMensalidade(MensalidadeModel mensalidade)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"INSERT INTO dadosmensalidades (Valor, DataVencimento, AlunoAssociadoID)
                               VALUES (@Valor, @DataVencimento, @AlunoAssociadoID)";
                db.Execute(sql, mensalidade);
            }
        }

        public void AtualizarMensalidade(MensalidadeModel mensalidade)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"UPDATE dadosmensalidades
                               SET Valor = @Valor, DataVencimento = @DataVencimento, AlunoAssociadoID = @AlunoAssociadoID
                               WHERE IDMensalidade = @IDMensalidade";
                db.Execute(sql, mensalidade);
            }
        }

        public void ExcluirMensalidade(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"DELETE FROM dadosmensalidades WHERE IDMensalidade = @Id";
                db.Execute(sql, new { Id = id });
            }
        }
    }
}
