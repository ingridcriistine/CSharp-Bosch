using System.Drawing;
using System.Xml.Serialization;
using Radiance;
using Radiance.Bufferings;
using static Radiance.Utils;

public class Character (vec4 characterColor)
{
    dynamic charRender = render((vec2 dx) =>
    {
        zoom(40);
        move(dx);
        color = characterColor;
        fill();

    });
    Polygon polygon = Polygons.Circle;
    public void Draw()
    {
        charRender(polygon, X, Y);
    }

    public float X { get; set; } = Random.Shared.Next(200);
    public float Y { get; set; } = Random.Shared.Next(200);

    State? state = null;
    public void SetState(State state)
    {
        this.state = state;
        this.state.SetContext(this);
    }
    
    public void Act()
        => state?.Act();
}