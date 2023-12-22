using GestaoProffff.Models;
using System.Collections.Generic;

namespace GestaoProffff.Repository
{
    public interface IAvaliacaoRepository
    {
        IEnumerable<AvaliacaoModel> BuscarAvaliacoesComListas();
        void AddAvaliacao(AvaliacaoModel avaliacao);

    }
}
