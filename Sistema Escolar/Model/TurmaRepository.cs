using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class TurmaRepository : IRepository<Turma>
{
    List<Turma> turmas = [];
    DB<Turma> database = DB<Turma>.App;

    public TurmaRepository()
    {
        turmas.Add(
            new()
            {
                Id = 1,
                Periodo = "Noturno",
                Alunos = [0, 1, 2, 3],
            }
        );

        turmas = database.All;
    }

    public List<Turma> All => turmas;

    public void Add(Turma obj)
    {
        this.turmas.Add(obj);
        database.Save(this.turmas);
    }

    public Turma findById(int id)
    {
        throw new System.NotImplementedException();
    }
}
