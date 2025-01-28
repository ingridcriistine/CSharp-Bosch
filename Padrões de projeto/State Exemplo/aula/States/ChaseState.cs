using Radiance;

public class ChaseState(float x, float y) : State
{
    DateTime? lastTime = null;
    public override void Act()
    {
        if (character is null)
            return;

        if (lastTime is null)
        {
            lastTime = DateTime.Now.AddSeconds(1);
            return;
        }

        if (DateTime.Now < lastTime)
            return;
        
        lastTime = null;
        
        var dx = x - character.X;
        var dy = y - character.Y;
        var mod = MathF.Sqrt(dx * dx + dy * dy);
        dx /= mod;
        dy /= mod;

        character.X += 200 * Window.DeltaTime * dx;
        character.Y += 200 * Window.DeltaTime * dy;

        character?.SetState(new ChaseState(
            x+20,y+20
        ));
    }
}