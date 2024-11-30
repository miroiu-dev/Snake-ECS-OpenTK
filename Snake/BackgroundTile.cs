using GameEngine;
using GameEngine.Components;

namespace Snake;
public class BackgroundTile: Entity
{
    public TransformComponent Position { get; set; } = default!;
    private RendererComponent _renderer = default!;
    private readonly Random _random = new();
    protected override void Initialize()
    {
        Position = AddComponent<TransformComponent>();
        Position.Width = 1;
        Position.Height = 1;
        _renderer = AddComponent<RendererComponent>();

        var texture = Scene.Assets.GetTexture("snake");
        _renderer.SpriteIndex = _random.Next(26, 28);
        _renderer.Texture = texture;
        _renderer.Opacity = 0.3f;
    }

    protected override void Update(double time)
    {
        base.Update(time);
    }
}
