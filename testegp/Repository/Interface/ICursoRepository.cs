using System.Collections.Generic;
using GestaoProffff.Models;

namespace GestaoProffff.Repository
{
    public interface ICursoRepository
    {
        IEnumerable<CursoModel> GetAllCursos();
        CursoModel GetCursoById(int id);
        void AddCurso(CursoModel curso);
        void UpdateCurso(CursoModel curso);
        void DeleteCurso(int id);
    }
}
