using System.Collections.Generic;
using GestaoProffff.Models;

namespace GestaoProffff.Repository
{
    public interface IDisciplinaRepository
    {
        IEnumerable<DisciplinaModel> BuscaDisciplina();
        void AddDisciplina(DisciplinaModel disciplina);
    }
}
