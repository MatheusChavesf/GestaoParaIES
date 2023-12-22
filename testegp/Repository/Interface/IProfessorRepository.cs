using GestaoProffff.Models;
using System.Collections.Generic;

namespace GestaoProffff.Repository
{
    public interface IProfessorRepository
    {
        IEnumerable<ProfessorModel> BuscarProfessores();
        void AdicionarProfessor(ProfessorModel professorRepository);
    }
}
