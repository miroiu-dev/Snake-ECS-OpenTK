using GameEngine;
using GameEngine.Components;
using System.Drawing;

namespace Snake;
public class Food : Entity
{
    public TransformComponent Position { get; private set; } = default!;
    private RendererComponent _renderer = default!;
    private Random _random = new();
    private int _spriteIndex = 54;

    protected override void Initialize()
    {
        base.Initialize();
        _renderer = AddComponent<RendererComponent>();
        var texture = Scene.Assets.GetTexture("snake");
        _renderer.SpriteIndex = _spriteIndex;
        _renderer.Texture = texture;
        Position = AddComponent<TransformComponent>();
        Position.Width = 1;
        Position.Height = 1;
        var collider = AddComponent<ColliderComponent>();
        collider.Bounds = new Rectangle(0, 0, 1, 1);
    }

    public void ChangeSpriteRandom()
    {
        int[] sprites = [6, 22, 54, 55, 70];
        _spriteIndex = sprites[_random.Next(0, sprites.Length)];
    }

    protected override void Update(double time)
    {
        base.Update(time);
        _renderer.SpriteIndex = _spriteIndex;
    }
}
