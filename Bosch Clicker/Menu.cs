using System.Collections.Generic;
using Machine;
using static NewSystem.NewConsole;

public static class Menu
{
    public static string statusCursor = "UNAVAILABLE";
    public static string statusFarm = "UNAVAILABLE";
    public static string statusFactory = "UNAVAILABLE";
    public static List<string> status = [];
    public static List<int> prices = [];

    public static void menu(int coins, Cursor cursor, Farm farm, Factory factory)
    {
        prices.Add(cursor.price);
        prices.Add(farm.price);
        prices.Add(factory.price);

        status = [statusCursor, statusFarm, statusFactory];

        for (int i = 0; i < 3; i++)
        {
            if (coins >= prices[i])
            {
                status[i] = "AVAILABLE";
            }
            else
            {
                status[i] = "UNAVAILABLE";
            }
        }

        Print("\n\n****************************** BOSCH CLICKER ******************************");
        Print("\nMENU: ");
        Print(
            "\n1 - Cursor: Value: "
                + cursor.price
                + " | "
                + (cursor.itemPs + 1)
                + " coins per second | "
                + status[0]
        );
        Print(
            "\n2 - Farm: Value: "
                + farm.price
                + " | "
                + (farm.itemPs + 1)
                + " coins per second | "
                + status[1]
        );
        Print(
            "\n3 - Factory: Value: "
                + factory.price
                + " | "
                + (factory.itemPs + 1)
                + " coins per second | "
                + status[2]
        );
        Print("\n\nTOTAL OF COINS: " + coins);
        Print("\n\nPress ENTER to start and E to leave!\n");
    }
}
