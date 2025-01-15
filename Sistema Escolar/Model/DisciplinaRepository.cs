using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class DisciplinaRepository : IRepository<Disciplina>
{
    List<Disciplina> disciplinas = [];
    DB<Disciplina> database = new("/Database");

    public DisciplinaRepository()
    {
        disciplinas.Add(new(){
            Id = 1,
            Nome = "10",
            Professores = [0, 1]
        });

        disciplinas = database.All;
    }

    public List<Disciplina> All => disciplinas;

    public void Add(Disciplina obj) {
        this.disciplinas.Add(obj);
        database.Save(this.disciplinas);
    } 

    public Disciplina findById(int id)
    {
        throw new System.NotImplementedException();
    }
}