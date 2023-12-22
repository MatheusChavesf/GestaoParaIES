using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoProffff.Models
{
    public class DisciplinaModel
    {
        public int IDDisciplina { get; set; }
        public string NomeDisciplina { get; set; }
        public ProfessorModel ProfessorResponsavel { get; set; }
        public SelectList ProfessoresSelectList { get; set; }
        public int ProfessorResponsavelID { get; internal set; }
        public string ProfessorMinistrante { get; internal set; }
    }
}
