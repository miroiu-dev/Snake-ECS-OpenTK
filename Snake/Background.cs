using GameEngine;

namespace Snake;
public class Background : Entity
{
    protected override void Initialize()
    {
        base.Initialize();

        for (int i = 1; i < Walls.GRID_SIZE - 1; i++)
        {
            for (int j = 1; j < Walls.GRID_SIZE - 1; j++)
            {
                CreateBackground(i, j);
            }
        }
    }

    public void CreateBackground(int x, int y)
    {
        var wall = Scene.CreateEntity<BackgroundTile>();
        wall.Position.X = x;
        wall.Position.Y = y;
    }
}
