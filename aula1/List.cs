using System.Runtime.CompilerServices;

public class List<T>
{
    const int ExpandConstant = 2;
    private int size = 0;
    private T[] array = new T[10];
    public int Count => size;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            return array[index];
        }
        set
        {
            if (array.Length < index)
                throw new IndexOutOfRangeException();
            array[index] = value;
        }
    }

    public void Add(T item)
    {
        ExpandIfNeeded();
        array[size] = item;
        size++;
    }

    private void ExpandIfNeeded()
    {
        if (size < array.Length)
            return;
        Expand();
    }

    private void Expand()
    {
        var copy = new T[ExpandConstant * array.Length];
        Array.Copy(array, copy, array.Length);
        array = copy;
    }
}
