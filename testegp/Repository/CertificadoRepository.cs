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
    public class CertificadoRepository : ICertificadoRepository
    {
        private readonly IConfiguration _configuration;

        public CertificadoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<CertificadoModel> GetCertificados()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                return db.Query<CertificadoModel>("SELECT IDCertificado, Tipo, DataEmissao FROM dadoscertificados").ToList();
            }
        }

        public CertificadoModel GetCertificadoById(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();
                return db.QueryFirstOrDefault<CertificadoModel>("SELECT IDCertificado, Tipo, DataEmissao FROM dadoscertificados WHERE IDCertificado = @Id", new { Id = id });
            }
        }

        public void AdicionarCertificado(CertificadoModel certificado)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"INSERT INTO dadoscertificados (Tipo, DataEmissao, AlunoAssociadoID)
                               VALUES (@Tipo, @DataEmissao, @AlunoAssociadoID)";
                db.Execute(sql, certificado);
            }
        }

        public void AtualizarCertificado(CertificadoModel certificado)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"UPDATE dadoscertificados
                               SET Tipo = @Tipo, DataEmissao = @DataEmissao, AlunoAssociadoID = @AlunoAssociadoID
                               WHERE IDCertificado = @IDCertificado";
                db.Execute(sql, certificado);
            }
        }

        public void ExcluirCertificado(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.Open();

                string sql = @"DELETE FROM dadoscertificados WHERE IDCertificado = @Id";
                db.Execute(sql, new { Id = id });
            }
        }
    }
}