using GameEngine;
using GameEngine.Components;
using System.Drawing;

namespace Snake;
public class Food : Entity
{
    public TransformComponent Position { get; private set; } = default!;
    private RendererComponent _renderer = default!;
    protected override void Initialize()
    {
        base.Initialize();
        _renderer = AddComponent<RendererComponent>();
        var texture = Scene.Assets.GetTexture("snake");
        _renderer.SpriteIndex = 54;
        _renderer.Texture = texture;
        Position = AddComponent<TransformComponent>();
        Position.Width = 1;
        Position.Height = 1;
        var collider = AddComponent<ColliderComponent>();
        collider.Bounds = new Rectangle(0, 0, 1, 1);
    }
}
