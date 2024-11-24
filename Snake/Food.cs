using GameEngine;
using GameEngine.Components;
using System.Drawing;

namespace Snake;
public class Food : Entity
{
    public TransformComponent Position { get; private set; } = default!;

    protected override void Initialize()
    {
        base.Initialize();
        var renderer = AddComponent<RendererComponent>();
        renderer.SpriteIndex = 0;
        renderer.TextureName = "snake";
        Position = AddComponent<TransformComponent>();
        Position.Width = 2;
        Position.Height = 2;
        var collider = AddComponent<ColliderComponent>();
        collider.Bounds = new Rectangle(0, 0, 1, 1);
    }
}
