using DataBase;
using System.Data;

namespace Model;

public class Aluno : DataBaseObject
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }

    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.Idade = int.Parse(data[1]);
        this.Id = int.Parse(data[2]);
    }

    protected override string[] SaveTo() =>
        new string[] { this.Nome, this.Idade.ToString(), this.Id.ToString() };

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.Nome = data[0].ToString();
        this.Idade = int.Parse(data[1].ToString());
        this.Id = int.Parse(data[2].ToString());
    }

    protected override string SaveToSql() =>
        $"INSERT INTO [Aluno] VALUES ('{Id}', '{Nome}', '{Idade}')";
}
