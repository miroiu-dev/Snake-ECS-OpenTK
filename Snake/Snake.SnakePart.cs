using GameEngine;
using GameEngine.Components;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Snake;
public partial class Snake
{
    private class SnakePart : Entity
    {
        public Color Color { get; set; } = Color.FromArgb(0, 255, 0);
        public TransformComponent Position { get; private set; } = default!;
        public ColliderComponent Collider { get; private set; } = default!;
        protected int SpriteIndex = 53;
        private RendererComponent _renderer = default!;

        protected override void Initialize()
        {
            base.Initialize();
            var texture = Scene.Assets.GetTexture("snake");
            _renderer = AddComponent<RendererComponent>();
            _renderer.SpriteIndex = SpriteIndex;
            _renderer.Texture = texture;
            Position = AddComponent<TransformComponent>();
            Position.Width = 1;
            Position.Height = 1;
            Collider = AddComponent<ColliderComponent>();
            Collider.Bounds = new Rectangle(0, 0, 1, 1);
        }

        protected override void Update(double time)
        {
            base.Update(time);
            _renderer.SpriteIndex = SpriteIndex;
        }

        public void MoveTo(Point point)
        {
            Position.X = point.X;
            Position.Y = point.Y;
        }
    }
}
