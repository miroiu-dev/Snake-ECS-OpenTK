using System.Diagnostics;
using System.Drawing;

namespace GameEngine.Components;

public class RendererComponent : Component
{
    public const int SPRITE_SIZE = 8;
    public int SpriteIndex { get; set; }
    public Texture? Texture { get; set; }

    protected internal override void Update(double time)
    {
        var transform = Entity.GetComponent<TransformComponent>();

        if (transform is not null && Texture is not null)
        {
            int cols = Texture.Width / SPRITE_SIZE;
            int row = SpriteIndex % cols;
            int col = cols - SpriteIndex / cols - 1;

            Texture?.Draw(new Point(row * SPRITE_SIZE, col * SPRITE_SIZE), new Size(SPRITE_SIZE, SPRITE_SIZE), transform, transform);
        }
    }
}
