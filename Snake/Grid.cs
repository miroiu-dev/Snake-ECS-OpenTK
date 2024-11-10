using OpenTK.Graphics.OpenGL;

namespace Snake;
public class Grid
{
    public const int SIZE = 40;
    public void Draw()
    {
        for (int x = 0; x < SIZE; x++)
        {
            for (int y = 0; y < SIZE; y++)
            {
                DrawCell(new Point(x, y));
            }
        }
    }

    public void DrawCell(Point point)
    {
        var isBoundingCell = point.X == 0 || point.Y == 0 || point.X == SIZE - 1 || point.Y == SIZE - 1;
        if (isBoundingCell)
        {
            GL.LineWidth(3.0f);
            GL.Color3(1.0f, 0f, 0f);
        }
        else
        {
            GL.LineWidth(1.0f);
            GL.Color3(1.0f, 1.0f, 1.0f);
        }

        GL.Begin(PrimitiveType.LineLoop);
        GL.Vertex2(point.X, point.Y);
        GL.Vertex2(point.X + 1, point.Y);
        GL.Vertex2(point.X + 1, point.Y + 1);
        GL.Vertex2(point.X, point.Y + 1);
        GL.End();
    }

}
