using static NewSystem.NewConsole;

public static class Menu {

    public static string status = "UNAVAILABLE";
    public static void menu(int coins, Cursor cursor) {

        if(coins >= cursor.price) {
            status = "AVAILABLE";
        }

        Print("\n\n****************************** BOSCH CLICKER ******************************");
        Print("\nMENU: ");
        Print("\n1 - Cursor: Value: " + cursor.price + " | " + cursor.itemPs + " coins per second | " + status);
        Print("2 - Machine 2 MENU: ");
        Print("3 - Machine 2 MENU: ");
        Print("\n\nTOTAL OF COINS: " + coins);
        Print("\n\nPress ENTER to start and E to leave!\n");
    }
}