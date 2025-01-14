using System.Reflection.PortableExecutable;
using static NewSystem.NewConsole;

int coins = 0;
bool game = false;
List<Machine> activeMachine = new();
Cursor cursor = new();
int value = 1;

while(true) {
    Menu.menu(coins, cursor);

    var start = ReadKeyInt();
    if(start == 13) {
        game = true;
    }
    else if (start == 49) {
        value = cursor.itemPs;
        coins -= cursor.price;
        cursor.itemPs += cursor.upgrade;
        cursor.price *= cursor.upgrade;
    }

    while(game == true) {
        var click = ReadKeyInt();
        Print("Total of coins: " + coins);

        if(click == 32) {
            coins+=value;
        }
        else if(click == 8) {
            game = false;
        }
    }
}

