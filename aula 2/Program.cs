int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];
var result = array.FirstOrDefault<int>();

public static class Enumerator
{
    public static T? FirstOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();

        if (it.MoveNext()) =>
            return it.Current();

        else => 
            return default;
    }

    public static T? LastOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        var r;

        if (it.MoveNext()) {
            r = it.Current();

            while(it.MoveNext()) {
                r = it.Current();
            }
            return r;
        }

        else => 
            return default;
    }

    public static T[] ToArray<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        var size = Count(it);
        T[] array = [size];
        
        for (int i = 0; i < size; i++)
        {
            it.MoveNext()
            array[i] = it.Current();
        }

        return array;
    }

    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        List<T> list = [];

        while(it.MoveNext()) {
            list.Append(it.Current());
        }
            
        return list;
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int num)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < num; i++)
        {
            if (it.MoveNext()) 
                yield return it.Current();
        }
    }

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int num)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < num; i++)
        {
            it.MoveNext();
        }

        while (it.MoveNext()) => 
            yield return it.Current();
    }

    public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();
        List<T> list = [];

        while(it.MoveNext()) {
            list.Append(it.Current());
        }
        list.Append(item);

        return list;
    }

    public static IEnumerable<T> Preprend<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();
        List<T> list = [];

        list.Append(item);
        while(it.MoveNext()) {
            list.Append(it.Current());
        }

        return list;
    }

    public static int Count<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        int count = 0;

        while (it.MoveNext()) => 
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
