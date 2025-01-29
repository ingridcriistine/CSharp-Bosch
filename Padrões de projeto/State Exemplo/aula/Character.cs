using System.Drawing;
using System.Xml.Serialization;
using Radiance;
using Radiance.Bufferings;
using Radiance.Primitives;
using static Radiance.Utils;

public class Character (string foto, vec4 characterColor)
{
    Texture pic = Textures.Open(foto);
    dynamic charRender = render((img photo, vec2 dx) =>
    {
        zoom(50);
        move(dx);
        move(0, 0, 1);
        // color = characterColor;
        color = texture(photo, x - dx.x + 45, y - dx.y + 45);
        fill();
    });
    Polygon polygon = Polygons.Circle;
    public void Draw()
    {
        charRender(polygon, pic, X, Y);
    }

    public float X { get; set; } = Random.Shared.Next(200);
    public float Y { get; set; } = Random.Shared.Next(200);
    public int type { get; set; } = 1;

    State? state = null;
    public void SetState(State state)
    {
        this.state = state;
        this.state.SetContext(this);
    }
    
    public void Act()
        => state?.Act();
}