using GestaoProffff.Models;

namespace GestaoProffff.Repository.Interface
{
    public interface IMensalidadeRepository
    {
        IEnumerable<MensalidadeModel> GetMensalidades();
        MensalidadeModel GetMensalidadeById(int id);
        void AdicionarMensalidade(MensalidadeModel mensalidade);
        void AtualizarMensalidade(MensalidadeModel mensalidade);
        void ExcluirMensalidade(int id);
    }
}
