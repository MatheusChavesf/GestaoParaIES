using GestaoProffff.Models;

namespace GestaoProffff.Models
{
    public class AvaliacaoModel
    {
        public int IDAvaliacao { get; set; }
        public string Nome { get; set; }
        public decimal Nota { get; set; }
        public int AlunoAssociadoID { get; set; }
        public int DisciplinaAssociadaID { get; set; }
       
        public List<AlunoModel> AlunosDisponiveis { get; set; }
        
        public List<DisciplinaModel> DisciplinasDisponiveis { get; set; }
    }
}

