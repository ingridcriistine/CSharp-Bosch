namespace NewSystem;

public static class NewConsole 
{
    public static int? ReadLineInt()
    {
        var str = Console.ReadLine();

        if(int.TryParse(str, out int i))
            return i;
        
        return 0;
    }

    public static void Print(object obj) 
        => Console.WriteLine(obj.ToString());


}