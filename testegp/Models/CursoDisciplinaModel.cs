namespace GestaoProffff.Models
{
    public class CursoDisciplinaModel
    {
        public int CursoID { get; set; }
        public CursoModel NomeCurso { get; set; }

        public int DisciplinaID { get; set; }
        public DisciplinaModel NomeDisciplina { get; set; }
    }

}
