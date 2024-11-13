using System.Drawing;

namespace GameEngine.Components;
public class PositionComponent : Component
{
    public int X { get; set; }
    public int Y { get; set; }

    public static implicit operator Point(PositionComponent positionComponent)
    {
        return new Point { X = positionComponent.X, Y = positionComponent.Y };
    }
}
