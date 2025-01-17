using System.Data;
using DataBase;

namespace Model;

public class Professor : DataBaseObject
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Formacao { get; set; }

    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.Formacao = data[1];
        this.Id = int.Parse(data[2]);
    }

    protected override string[] SaveTo() =>
        new string[] { this.Nome, this.Formacao, this.Id.ToString() };

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.Nome = data[0].ToString();
        this.Formacao = data[1].ToString();
        this.Id = int.Parse(data[2].ToString());
    }

    protected override string SaveToSql() =>
        $"INSERT INTO [Professor] VALUES ('{Id}', {Nome}, {Formacao})";
}
