using Radiance;

public class ChaseState(Character mark) : State
{
    public override void Act()
    {
        if (character is null)
            return;
        
        var dx = mark.X - character.X;
        var dy = mark.Y - character.Y;
        var mod = MathF.Sqrt(dx * dx + dy * dy);
        dx /= mod;
        dy /= mod;

        character.X += 180 * Window.DeltaTime * dx;
        character.Y += 180 * Window.DeltaTime * dy;

        if(mod < 15) {
            character?.SetState(new ChaseState(
                mark
            ));    
        }
        else {
            character?.SetState(new ChaseState(
                mark
            ));  
        }
    }
}