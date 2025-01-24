using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;
using Converter;

var obj = typeof(Empresa);

var empresa = new Empresa(
    "Bosch", 
    new Funcionario(1, "Fábio", 100_000), 
    [
        new Funcionario(2, "Don", 50_000),
        new Funcionario(3, "Queila", 50_000),
        new Funcionario(4, "Trevis", 50_000),
    ]
);

Console.WriteLine(Converter.Converter.ToJson(empresa));

public record Funcionario(int Id, string Nome, decimal Salario);
public record Empresa(string Nome, Funcionario Chefe, List<Funcionario> Funcionarios);



