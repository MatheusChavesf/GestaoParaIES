using System;

namespace GestaoProffff.Models
{
    public class MensalidadeModel
    {
        public int IDMensalidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public AlunoModel AlunoAssociado { get; set; }
        public int AlunoAssociadoID { get; set; }
    }
}
