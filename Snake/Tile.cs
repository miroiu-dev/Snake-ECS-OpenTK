using GameEngine;
using GameEngine.Components;
using System.Drawing;

namespace Snake;
public class Tile : Entity
{
    public const int TOP_WALL_SPRITE = 39;
    public const int LEFT_WALL_SPRITE = 41;
    public const int RIGHT_WALL_SPRITE = 40;
    public const int BOTTOM_WALL_SPRITE = 42;
    public const int BACKGROUND_SPRITE = 38;
    public TransformComponent Position { get; set; } = default!;
    private RendererComponent _renderer = default!;
    public int SpriteIndex { get; set; } = BACKGROUND_SPRITE;

    protected override void Initialize()
    {
        Position = AddComponent<TransformComponent>();
        Position.Width = 1;
        Position.Height = 1;
        _renderer = AddComponent<RendererComponent>();
        var texture = Scene.Assets.GetTexture("snake");
        var collider = AddComponent<ColliderComponent>();
        collider.Bounds = new Rectangle(0, 0, 1, 1);
        _renderer.SpriteIndex = SpriteIndex;
        _renderer.Texture = texture;
    }

    protected override void Update(double time)
    {
        base.Update(time);
        _renderer.SpriteIndex = SpriteIndex;
    }
}
