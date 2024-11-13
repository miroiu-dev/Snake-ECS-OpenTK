using GameEngine;
using GameEngine.Components;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Snake;
public class Food : Entity, IRenderable
{
    public PositionComponent Position { get; private set; } = default!;

    protected override void Initialize()
    {
        base.Initialize();
        AddComponent<RendererComponent>();
        Position = AddComponent<PositionComponent>();
        var collider = AddComponent<ColliderComponent>();
        collider.Bounds = new Rectangle(0, 0, 1, 1);
    }

    public void Render()
    {
        GL.Rect(Position.X, Position.Y, Position.X + 1, Position.Y + 1);
    }
}
