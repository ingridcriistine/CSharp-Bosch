using System.Reflection.PortableExecutable;
using static NewSystem.NewConsole;

int coins = 0;
bool game = false;
List<Machine> activeMachine = new();
Cursor cursor = new();

Menu.menu(cursor);

var start = ReadKeyInt();
if(start == 13) {
    game = true;
}
else if (start == 49) {
    cursor.itemPs += cursor.upgrade;
    cursor.price *= cursor.upgrade;
}

while(game == true) {
    var click = ReadKeyInt();
    Print("Total of coins: " + coins);

    if(click == 32) {
        coins++;
    }
    else if(click == 8) {
       Menu.menu(cursor);
    }
}
