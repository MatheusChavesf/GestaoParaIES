using GestaoProffff.Models;

namespace GestaoProffff.Repository.Interface
{
    public interface ICertificadoRepository
    {
        IEnumerable<CertificadoModel> GetCertificados();
        CertificadoModel GetCertificadoById(int id);
        void AdicionarCertificado(CertificadoModel certificado);
        void AtualizarCertificado(CertificadoModel certificado);
        void ExcluirCertificado(int id);
    }
}