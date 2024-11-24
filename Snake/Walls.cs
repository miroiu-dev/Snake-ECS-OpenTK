using GameEngine;
using GameEngine.Components;
using System.Drawing;

namespace Snake;
public class Walls : Entity
{
    public const int GRID_SIZE = 40;
    protected override void Initialize()
    {
        base.Initialize();
        AddComponent<RendererComponent>();
        var leftCollider = AddComponent<ColliderComponent>();
        var rightCollider = AddComponent<ColliderComponent>();
        var bottomCollider = AddComponent<ColliderComponent>();
        var topCollider = AddComponent<ColliderComponent>();
     
        leftCollider.Bounds = new Rectangle(0, 0, 1, GRID_SIZE);
        rightCollider.Bounds = new Rectangle(0, 0, 1, GRID_SIZE);
        bottomCollider.Bounds = new Rectangle(0, 0, GRID_SIZE, 1);
        topCollider.Bounds = new Rectangle(0, 0, GRID_SIZE, 1);

        var leftRenderer = AddComponent<RendererComponent>();
        var rightRenderer = AddComponent<RendererComponent>();
        var bottomRenderer = AddComponent<RendererComponent>();
        var topRenderer = AddComponent<RendererComponent>();

        var leftTransform = AddComponent<TransformComponent>();
        var rightTransform = AddComponent<TransformComponent>();
        var bottomTransform = AddComponent<TransformComponent>();
        var topTransform = AddComponent<TransformComponent>();

        leftTransform.Width = 1;
        leftTransform.Height = GRID_SIZE;
        leftTransform.X = 0;
        leftTransform.Y = 0;

        rightTransform.Width = 1;
        rightTransform.Height = GRID_SIZE;
        rightTransform.X = GRID_SIZE - 1;
        rightTransform.Y = 0;

        bottomTransform.Width = GRID_SIZE;
        bottomTransform.Height = 1;
        bottomTransform.X = 0;
        bottomTransform.Y = 0;

        topTransform.Width = GRID_SIZE;
        topTransform.Height = 1;
        topTransform.X = 0;
        topTransform.Y = GRID_SIZE - 1;

        leftRenderer.SpriteIndex = 0;
        leftRenderer.TextureName = "snake";
        rightRenderer.SpriteIndex = 0;
        rightRenderer.TextureName = "snake";
        bottomRenderer.SpriteIndex = 0;
        bottomRenderer.TextureName = "snake";
        topRenderer.SpriteIndex = 0;
        topRenderer.TextureName = "snake";
    }
}
