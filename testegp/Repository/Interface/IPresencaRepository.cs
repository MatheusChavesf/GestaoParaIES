using GestaoProffff.Models;
using System.Collections.Generic;

namespace GestaoProffff.Repository.Interface
{
    public interface IPresencaRepository
    {
        IEnumerable<PresencaModel> GetPresencas();
        PresencaModel GetPresencaById(int id);
        void AdicionarPresenca(PresencaModel presenca);
        void AtualizarPresenca(PresencaModel presenca);
        void ExcluirPresenca(int id);
    }
}