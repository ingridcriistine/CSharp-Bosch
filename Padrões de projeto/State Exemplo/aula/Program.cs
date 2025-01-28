using Radiance;
using static Radiance.Utils;

Character garu = new Character(blue);
garu.SetState(new WaitingState());

Character pucca = new Character(red);
pucca.SetState(new WaitingState());

bool run = false;
DateTime? lastTime = null;

Window.OnFrame += () =>
{
    pucca.Act();
    garu.Act();
};

Window.OnRender += () =>
{
    pucca.Draw();
    garu.Draw();
};

if(pucca.X <= garu.X+5 && pucca.Y <= garu.Y+5) {
    pucca.SetState(new ChaseState(garu.X, garu.Y));
    run = true;
}

while(run) {
    if (lastTime is null)
    {
        lastTime = DateTime.Now.AddSeconds(1);
        return;
    }

    if (DateTime.Now < lastTime)
        return;
    
    lastTime = null;
}

Window.CloseOn(Input.Escape);
Window.Open();