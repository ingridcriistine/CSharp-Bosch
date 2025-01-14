using System.Timers;
using Machine;
using static NewSystem.NewConsole;

class Program
{
    static int coins = 0;
    static bool game = false;
    static int value = 1;

    static Cursor cursor = new();
    static Farm farm = new();
    static Factory factory = new();

    static void Main()
    {
        System.Timers.Timer myTimer = new(2000);

        while (true)
        {
            myTimer.Elapsed += Tick;
            myTimer.Enabled = true;

            var start = ReadKeyInt();
            if (start == 13)
            {
                game = true;
            }
            else if (start == 49)
            {
                if (coins >= cursor.price)
                {
                    value += cursor.itemPs;
                    coins -= cursor.price;
                    cursor.itemPs += cursor.upgrade;
                    cursor.price *= cursor.upgrade;
                }
                else
                {
                    Print("\n\nNot enough coins!!");
                }
            }
            else if (start == 50)
            {
                if (coins >= farm.price)
                {
                    value += farm.itemPs;
                    coins -= farm.price;
                    farm.itemPs += farm.upgrade;
                    farm.price *= farm.upgrade;
                }
                else
                {
                    Print("\n\nNot enough coins!!");
                }
            }
            else if (start == 51)
            {
                if (coins >= factory.price)
                {
                    value += factory.itemPs;
                    coins -= factory.price;
                    factory.itemPs += factory.upgrade;
                    factory.price *= factory.upgrade;
                }
                else
                {
                    Print("\n\nNot enough coins!!");
                }
            }
            else if (start == 101)
            {
                break;
            }

            while (game == true)
            {
                myTimer.Elapsed += Tick;
                myTimer.Enabled = true;
                var click = ReadKeyInt();

                if (click == 32)
                {
                    coins += value;
                    Console.Clear();
                    Print("Total of coins: " + coins);
                }
                else if (click == 8)
                {
                    game = false;
                }
            }
        }
    }

    static void Tick(Object source, ElapsedEventArgs e)
    {
        coins += value;

        Console.Clear();

        if (game)
        {
            Print("Total of coins: " + coins);
        }
        else
        {
            Menu.menu(coins, cursor, farm, factory);
        }
    }
}
