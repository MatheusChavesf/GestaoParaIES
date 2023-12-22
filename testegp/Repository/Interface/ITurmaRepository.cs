using System.Collections.Generic;
using GestaoProffff.Models;

public interface ITurmaRepository
{
    IEnumerable<TurmaModel> GetAllTurmas();
    TurmaModel GetTurmaById(int id);
    void AddTurma(TurmaModel turma);
    void UpdateTurma(TurmaModel turma);
    void DeleteTurma(int id);
}
