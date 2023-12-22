using GestaoProffff.Models;
using System.Collections.Generic;

namespace GestaoProffff.Repository
{
    public interface IAlunoRepository
    {
        IEnumerable<AlunoModel> BuscarAlunos();
        void AdicionarAluno(AlunoModel aluno);       
    }
}
