int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];
var result = array.Where(i => i % 2 == 0).Select(i => i * i);

System.Console.WriteLine(array.FirstOrDefault());
System.Console.WriteLine(array.LastOrDefault());
System.Console.WriteLine(array.ToArray());
System.Console.WriteLine(array.ToList());
System.Console.WriteLine(array.Take(5));
System.Console.WriteLine(array.Skip(5));
System.Console.WriteLine(array.Append(3));
System.Console.WriteLine(array.Preprend(3));
System.Console.WriteLine(array.Count());
System.Console.WriteLine(result);


Pessoa[] pessoas = [
    new Pessoa("Don", "123"),
    new Pessoa("Queila", "456")
];

var query = pessoas
    .Where(p => p.Cpf.Length < 4)
    .Select(p => p.Nome);

var quer2 =
    from p in pessoas
    where p.Cpf.Length < 4
    select p.Nome;

Pagamento[] pagamento = [
    new Pagamento("123", 1000),
    new Pagamento("123", 800),
    new Pagamento("123", 250),
    new Pagamento("456", 3000),
]

var pagamentoDados = pessoas
.Join(pagamentoDados, p => p.Cpf, p => p.Cpf, 
(pessoa, pagamento) => new { pessoa.Nome, pagamento.Valor });

public record Pessoa(string Nome, string Cpf);
public record Pagamento(string Cpf, decimal Valor);

public static class Enumerator
{
    public static void Join<T, U, K, R> (this IEnumerable<T> source, IEnumerable<U> other, Func<T, K> keyA, Func<U, K> keyB, Func<T, U, R> map) 
    {

    }

    public static IEnumerable<R> Select<T, R>(this IEnumerable<T> source, Func<T, R> map)
    {
        foreach (var item in source)
            yield return map(item);
    }

    public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                yield return item;
        }
    }

    public static T? FirstOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();

        if (it.MoveNext())
        {
            return it.Current;
        }

        return default;
    }

    public static T? LastOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        T r;

        if (it.MoveNext())
        {
            r = it.Current;

            while (it.MoveNext())
            {
                r = it.Current;
            }
            return r;
        }
        else
        {
            return default;
        }
    }

    public static T[] ToArray<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        var size = coll.Count();
        T[] array = new T[size];

        for (int i = 0; i < size; i++)
        {
            it.MoveNext();
            array[i] = it.Current;
        }

        return array;
    }

    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        List<T> list = [];

        while (it.MoveNext())
        {
            list.Add(it.Current);
        }

        return list;
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int num)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < num; i++)
        {
            if (it.MoveNext())
                yield return it.Current;
        }
    }

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int num)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < num; i++)
        {
            it.MoveNext();
        }

        while (it.MoveNext())
            yield return it.Current;
    }

    public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();
        List<T> list = [];

        while (it.MoveNext())
        {
            list.Add(it.Current);
        }
        list.Add(item);

        return list;
    }

    public static IEnumerable<T> Preprend<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();
        List<T> list = [];

        list.Add(item);
        while (it.MoveNext())
        {
            list.Add(it.Current);
        }

        return list;
    }

    public static int Count<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        int count = 0;

        while (it.MoveNext())
            count++;

        return count;
    }

    // public static IEnumerable<int> PegaPar(this IEnumerable<int> coll)
    // {
    //     foreach (var val in coll)
    //         if (val % 2 == 0)
    //             yield return val;
    // }

    // public static IEnumerable<int> PegaQuadrado(this IEnumerable<int> coll)
    // {
    //     foreach (var x in coll)
    //         yield return x * x;
    // }

    // public static IEnumerable<int> PegaTop4(this IEnumerable<int> coll)
    // {
    //     var it = coll.GetEnumerator();
    //     for (int i = 0; i < 4; i++)
    //     {
    //         if (it.MoveNext())
    //             yield return it.Current;
    //     }
    // }

    // public static int Sum(this IEnumerable<int> array)
    // {
    //     int soma = 0;
    //     var it = array.GetEnumerator();
    //     while (it.MoveNext())
    //     {
    //         soma += it.Current;
    //     }
    //     return soma;
    // }
}

// public interface IEnumberable<T>
// {
//     IEnumerator<T> GetEnumerator();
// }

// public interface IEnumerator<T>
// {
//     bool MoveNext();
//     T Current { get; }
// }
