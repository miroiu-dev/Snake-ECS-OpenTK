using GameEngine;
using GameEngine.Components;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Snake;
public class Walls : Entity, IRenderable
{
    private ColliderComponent _leftCollider = default!;
    private ColliderComponent _rightCollider = default!;
    private ColliderComponent _bottomCollider = default!;
    private ColliderComponent _topCollider = default!;

    public void Render()
    {
        GL.LineWidth(3.0f);
        GL.Color3(1.0f, 0f, 0f);

        RenderLine(_leftCollider.Bounds);
        RenderLine(_rightCollider.Bounds);
        RenderLine(_bottomCollider.Bounds);
        RenderLine(_topCollider.Bounds);
    }

    private static void RenderLine(Rectangle bounds)
    {
        GL.Begin(PrimitiveType.LineLoop);
        GL.Vertex2(bounds.Left, bounds.Top);
        GL.Vertex2(bounds.Right, bounds.Top);
        GL.Vertex2(bounds.Right, bounds.Bottom);
        GL.Vertex2(bounds.Left, bounds.Bottom);
        GL.End();
    }

    protected override void Initialize()
    {
        base.Initialize();
        AddComponent<RendererComponent>();
        _leftCollider = AddComponent<ColliderComponent>();
        _rightCollider = AddComponent<ColliderComponent>();
        _bottomCollider = AddComponent<ColliderComponent>();
        _topCollider = AddComponent<ColliderComponent>();
        _leftCollider.Tag = "Left";
        _rightCollider.Tag = "Right";
        _topCollider.Tag = "Top";
        _bottomCollider.Tag = "Bottom";
        _leftCollider.Bounds = new Rectangle(0, 0, 1, Grid.SIZE);
        _rightCollider.Bounds = new Rectangle(Grid.SIZE - 1, 0, 1, Grid.SIZE);
        _bottomCollider.Bounds = new Rectangle(0, 0, Grid.SIZE, 1);
        _topCollider.Bounds = new Rectangle(0, Grid.SIZE - 1, Grid.SIZE, 1);
    }
}
