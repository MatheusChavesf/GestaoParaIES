using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoProffff.Models
{
    public class TurmaModel
    {
        public int IDTurma { get; set; }
        public string Nome { get; set; }
        public CursoModel CursoAssociado { get; set; }
        public List<AlunoModel> AlunosMatriculados { get; set; }
        public SelectList CursosDisponiveis { get; internal set; }
        public List<AlunoModel> AlunosDisponiveis { get; internal set; }
        public IEnumerable<object>? CursoAssociadoID { get; internal set; }
    }
}
