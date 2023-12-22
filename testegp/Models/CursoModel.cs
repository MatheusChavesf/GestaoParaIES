namespace GestaoProffff.Models
{
    public class CursoModel
    {
        public int IDCurso { get; set; }
        public string NomeCurso { get; set; }
        public List<DisciplinaModel> DisciplinasAssociadas { get; set; }
    }
}
