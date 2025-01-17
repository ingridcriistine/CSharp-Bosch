using System.Collections.Generic;
using System.Linq;
using System.Data;
using DataBase;

namespace Model;

public class Disciplina : DataBaseObject
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<int> Professores { get; set; }

    protected override void LoadFrom(string[] data)
    {
        this.Id = int.Parse(data[0]);
        this.Nome = data[1];
        this.Professores = data[2].Split('.').Select(i => int.Parse(i)).ToList();
    }

    protected override string[] SaveTo() =>
        new string[] { this.Id.ToString(), this.Nome, string.Join('.', this.Professores) };

     protected override void LoadFromSqlRow(DataRow data)
    {
        return;
    }

    protected override string SaveToSql()
    {
        var disc = $"INSERT INTO [Disciplina] VALUES ('{Id}', {Nome});";
        // var profs = $"INSERT INTO [ProfessorDisciplina](IdProfessor, IdDisciplina) VALUES ('{IdProfessor}', {});";
        return disc;
    }
}
