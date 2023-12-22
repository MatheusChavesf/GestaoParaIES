namespace GestaoProffff.Models
{
    public class PresencaModel
    {
        public int IDPresenca { get; set; }
        public DateTime Data { get; set; }
        public AlunoModel AlunoPresente { get; set; }
        public DisciplinaModel Disciplina { get; set; }
        public List<AlunoModel> AlunosDisponiveis { get; internal set; }
        public List<DisciplinaModel> DisciplinasDisponiveis { get; internal set; }
        public int DisciplinaID { get; internal set; }
        public int AlunoPresenteID { get; internal set; }
    }
}
