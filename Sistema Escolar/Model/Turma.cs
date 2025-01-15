using System.Collections.Generic;
using System.Linq;
using DataBase;

namespace Model;

public class Turma : DataBaseObject
{
    public int Id { get; set; }
    public string Periodo { get; set; }
    public int Professor { get; set; }
    public List<int> Alunos { get; set; }

    protected override void LoadFrom(string[] data)
    {
        this.Id = int.Parse(data[0]);
        this.Periodo = data[1];
        this.Professor = int.Parse(data[2]);
        this.Alunos = data[3].Split('.').Select(i=>int.Parse(i)).ToList();
    }

    protected override string[] SaveTo()
     => new string[]
        {
            this.Id.ToString(),
            this.Periodo,
            this.Professor.ToString(),
            string.Join('.', this.Alunos)
        };
}