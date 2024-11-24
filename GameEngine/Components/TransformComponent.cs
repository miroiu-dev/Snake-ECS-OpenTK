using System.Drawing;

namespace GameEngine.Components;
public class TransformComponent : Component
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public static implicit operator Point(TransformComponent positionComponent)
    {
        return new Point { X = positionComponent.X, Y = positionComponent.Y };
    }

    public static implicit operator Size(TransformComponent positionComponent)
    {
        return new Size { Width = positionComponent.Width, Height = positionComponent.Height };
    }
}
