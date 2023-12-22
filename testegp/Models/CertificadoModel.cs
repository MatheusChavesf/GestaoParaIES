using GestaoProffff.Models;

namespace GestaoProffff.Models
{
    public class CertificadoModel
    {

        public int IDCertificado { get; set; }
        public string Tipo { get; set; }
        public DateTime DataEmissao { get; set; }
        public AlunoModel AlunoAssociado { get; set; }
    }
}
