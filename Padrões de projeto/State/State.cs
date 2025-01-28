using System.Runtime.Serialization;

Character character = new Character();
character.SetState(new MovingState(100, 200));

while (true)
{
    Thread.Sleep(200);
    Console.WriteLine(character.X);
    Console.WriteLine(character.Y);
    character.Act();
}

public class Character
{
    public int X { get; set; }
    public int Y { get; set; }

    IState? state = null;
    public void SetState(IState state)
    {
        this.state = state;
        this.state.SetContext(this);
    }
    
    public void Act()
        => this.state?.Act();
}

public interface IState
{
    void Act();
    void SetContext(Character character);
}

public class MovingState(int x, int y) : IState
{
    public void Act()
    {
        if (character is null)
            return;
        
        if (character.X < x)
            character.X += 5;
        
        if (character.Y < y)
            character.Y += 5;
        
        if (character.X == x && character.Y == y)
            character.SetState(new IdleState());
    }

    Character? character;
    public void SetContext(Character character)
        => this.character = character;
}

public class IdleState : IState
{
    public void Act() { }

    public void SetContext(Character character) { }
}