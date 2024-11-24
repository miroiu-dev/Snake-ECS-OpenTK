using System.Drawing;

namespace GameEngine.Components;

public class RendererComponent : Component
{
    public const int SPRITE_SIZE = 8;
    public int SpriteIndex { get; set; }
    public string TextureName { get; set; } = string.Empty;

    private Texture _texture = default!;

    public void Initialize()
    {
        _texture = Entity.Scene.Assets.GetTexture(TextureName) ?? throw new Exception("Texture not found!");
    }

    protected internal override void Update(double time)
    {
        var transform = Entity.GetComponent<TransformComponent>();

        if (transform is not null && _texture is not null)
        {
            _texture?.Draw(new Point(SpriteIndex * SPRITE_SIZE, SpriteIndex * SPRITE_SIZE), new Size(SPRITE_SIZE, SPRITE_SIZE), transform, transform);
        }
    }
}
