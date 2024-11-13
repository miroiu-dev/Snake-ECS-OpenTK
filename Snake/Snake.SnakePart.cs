using GameEngine;
using GameEngine.Components;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Snake;
public partial class Snake
{
    private class SnakePart : Entity, IRenderable
    {
        public Color Color { get; set; } = Color.FromArgb(0, 255, 0);
        public PositionComponent Position { get; private set; } = default!;
        public ColliderComponent Collider { get; private set; } = default!;

        protected override void Initialize()
        {
            base.Initialize();
            AddComponent<RendererComponent>();
            Position = AddComponent<PositionComponent>();
            Collider = AddComponent<ColliderComponent>();
            Collider.Tag = "Snake";
            Collider.Bounds = new Rectangle(0, 0, 1, 1);
        }

        public void Render()
        {
            GL.Color3(Color);
            GL.Rect(Position.X, Position.Y, Position.X + 1, Position.Y + 1);
        }

        public void MoveTo(Point point)
        {
            Position.X = point.X;
            Position.Y = point.Y;
        }
    }
}
