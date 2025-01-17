using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class TurmaRepository : IRepository<Turma>
{
    List<Turma> turmas = [];
    protected DBSqlSrv<Turma> db;

    public TurmaRepository()
    {
        db = new DBSqlSrv<Turma>("CA-C-0064Y\\SQLEXPRESS", "SistemaEscolar");
        turmas = db.All;
    }

    public List<Turma> All => turmas;

    public void Add(Turma obj)
    {
        this.turmas.Add(obj);
    }

    public Turma findById(int id)
    {
        foreach (var turm in turmas)
        {
            if (turm.Id == id)
            {
                return turm;
            }
        }

        return null;
    }

    public int getMaxId()
    {
        var maior = 0;

        for (int i = 0; i < turmas.Count; i++)
        {
            if (turmas[i].Id > maior)
            {
                maior = turmas[i].Id;
            }
        }

        return maior;
    }
}
