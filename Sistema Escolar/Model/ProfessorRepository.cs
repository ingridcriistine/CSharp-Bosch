using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class ProfessorRepository : IRepository<Professor>
{
    List<Professor> professores = [];
    DB<Professor> database = new("/Database");

    public ProfessorRepository()
    {
        professores.Add(
            new()
            {
                Id = 0,
                Nome = "Gilmar",
                Formacao = "Doutor",
            }
        );
        professores.Add(
            new()
            {
                Id = 1,
                Nome = "Vanessa",
                Formacao = "Doutora",
            }
        );

        professores = database.All;
    }

    public List<Professor> All => professores;

    public void Add(Professor obj) {
        this.professores.Add(obj);
        database.Save(this.professores);
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
        ;

        return null;
    }
}
