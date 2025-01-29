using Radiance;

public class MovingState(int x, int y, Character mark) : State
{
    public override void Act()
    {
        if (character is null)
            return;
        
        var dx = x - character.X;
        var dy = y - character.Y;
        var mod = MathF.Sqrt(dx * dx + dy * dy);
        dx /= mod;
        dy /= mod;

        if((character?.X <= mark.X+5 || character?.X >= mark.X-5) && (character?.Y <= mark.Y+5 || character?.Y >= mark.Y-5)) {
            Console.WriteLine("Achou");
            if (character.type == 0) {
                character.SetState(new ChaseState(mark));
            } else {
                character.SetState(new RunState(Random.Shared.Next(Window.Width), Random.Shared.Next(Window.Height)));
            }
        }

        if (mod < 5) {

            character?.SetState(new WaitingState(mark));
            return;
        }

        character.X += 200 * Window.DeltaTime * dx;
        character.Y += 200 * Window.DeltaTime * dy;
    }
}