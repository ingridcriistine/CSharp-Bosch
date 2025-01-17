using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class AlunoRepository : IRepository<Aluno>
{
    List<Aluno> alunos = [];

    protected DBSqlSrv<Aluno> db;

    public AlunoRepository()
    {
        db = new DBSqlSrv<Aluno>("CA-C-0064Y\\SQLEXPRESS", "SistemaEscolar");
        alunos = db.All;
    }

    public List<Aluno> All => alunos;

    public void Add(Aluno obj)
    {
        this.alunos.Add(obj);
    }

    public Aluno findById(int id)
    {
        foreach (var alun in alunos)
        {
            if (alun.Id == id)
            {
                return alun;
            }
        }

        return null;
    }

    public int getMaxId()
    {
        var maior = 0;

        for (int i = 0; i < alunos.Count; i++)
        {
            if (alunos[i].Id > maior)
            {
                maior = alunos[i].Id;
            }
        }

        return maior;
    }
}
