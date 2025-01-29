using Radiance;
using static Radiance.Utils;

var cenario = Textures.Open("cenario.png");
var cenarioRender = render((img photo) =>
{
    color = texture(photo, x * photo.xratio, y * photo.yratio);
    fill();
});

Character garu = new Character("garu.png", blue);
Character pucca = new Character("pucca.png", red);
pucca.type = 0;
garu.type = 1;

garu.SetState(new WaitingState(pucca));
pucca.SetState(new WaitingState(garu));

Window.OnFrame += () =>
{
    pucca.Act();
    garu.Act();
};

Window.OnRender += () =>
{
    cenarioRender(Polygons.Screen, cenario);
    pucca.Draw();
    garu.Draw();
};

Window.CloseOn(Input.Escape);
Window.Open();