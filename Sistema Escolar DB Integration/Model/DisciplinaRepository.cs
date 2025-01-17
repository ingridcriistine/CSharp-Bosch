using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class DisciplinaRepository : IRepository<Disciplina>
{
    List<Disciplina> disciplinas = [];

    protected DBSqlSrv<Disciplina> db;

    public DisciplinaRepository()
    {
        db = new DBSqlSrv<Disciplina>("CA-C-0064Y\\SQLEXPRESS", "SistemaEscolar");
        disciplinas = db.All;
    }

    public List<Disciplina> All => disciplinas;

    public void Add(Disciplina obj)
    {
        this.disciplinas.Add(obj);
    }

    public Disciplina findById(int id)
    {
        foreach (var disc in disciplinas)
        {
            if (disc.Id == id)
            {
                return disc;
            }
        }

        return null;
    }

    public int getMaxId()
    {
        var maior = 0;

        for (int i = 0; i < disciplinas.Count; i++)
        {
            if (disciplinas[i].Id > maior)
            {
                maior = disciplinas[i].Id;
            }
        }

        return maior;
    }
}
