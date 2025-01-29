using Radiance;

public class RunState(float x, float y) : State
{
    DateTime? lastTime = null;
    public override void Act()
    {
        if (character is null)
            return;
        
        var dx = x - character.X;
        var dy = y - character.Y;
        var mod = MathF.Sqrt(dx * dx + dy * dy);
        dx /= mod;
        dy /= mod;

        character.X += 300 * Window.DeltaTime * dx;
        character.Y += 300 * Window.DeltaTime * dy;

        if(mod < 5) {
            character?.SetState(new RunState(
                Random.Shared.Next(Window.Width),
                Random.Shared.Next(Window.Height)
            ));
        }
    }
}