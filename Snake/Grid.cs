using GameEngine;
using GameEngine.Components;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Snake;
public class Grid : Entity, IRenderable
{
    public const int SIZE = 40;
    public void Render()
    {
        for (int x = 1; x < SIZE - 1; x++)
        {
            for (int y = 1; y < SIZE - 1; y++)
            {
                DrawCell(new Point(x, y));
            }
        }
    }

    protected override void Initialize()
    {
        base.Initialize();
        AddComponent<RendererComponent>();
    }

    public static void DrawCell(Point point)
    {

        GL.LineWidth(1.0f);
        GL.Color3(1.0f, 1.0f, 1.0f);

        GL.Begin(PrimitiveType.LineLoop);
        GL.Vertex2(point.X, point.Y);
        GL.Vertex2(point.X + 1, point.Y);
        GL.Vertex2(point.X + 1, point.Y + 1);
        GL.Vertex2(point.X, point.Y + 1);
        GL.End();
    }
}
