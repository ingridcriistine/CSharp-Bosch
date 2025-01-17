using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class ProfessorRepository : IRepository<Professor>
{
    List<Professor> professores = [];
    protected DBSqlSrv<Professor> db;

    public ProfessorRepository()
    {
        db = new DBSqlSrv<Professor>("CA-C-0064Y\\SQLEXPRESS", "SistemaEscolar");
        professores = db.All;
    }

    public List<Professor> All => professores;

    public void Add(Professor obj)
    {
        this.professores.Add(obj);
    }

    public Professor findById(int id)
    {
        foreach (var prof in professores)
        {
            if (prof.Id == id)
            {
                return prof;
            }
        }

        return null;
    }

    public int getMaxId()
    {
        var maior = 0;

        for (int i = 0; i < professores.Count; i++)
        {
            if (professores[i].Id > maior)
            {
                maior = professores[i].Id;
            }
        }

        return maior;
    }
}
