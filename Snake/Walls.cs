using GameEngine;

namespace Snake;
public class Walls : Entity
{
    public const int GRID_SIZE = 40;
    protected override void Initialize()
    {
        base.Initialize();

        CreateTopWalls();
        CreateLeftWalls();
        CreateRightWalls();
        CreateBottomWalls();
    }

    public void CreateTopWalls()
    {
        for (int i = 0; i < GRID_SIZE; i++)
        {
            CreateWall(i, 0, Wall.TOP_WALL_SPRITE);
        }
    }

    public void CreateLeftWalls()
    {
        for (int i = 0; i < GRID_SIZE; i++)
        {
            CreateWall(0, i, Wall.LEFT_WALL_SPRITE);
        }
    }

    public void CreateRightWalls()
    {
        for (int i = 0; i < GRID_SIZE; i++)
        {
            CreateWall(GRID_SIZE - 1, i, Wall.RIGHT_WALL_SPRITE);
        }
    }

    public void CreateBottomWalls()
    {
        for (int i = 0; i < GRID_SIZE; i++)
        {
            CreateWall(i, GRID_SIZE - 1, Wall.BOTTOM_WALL_SPRITE);
        }
    }

    public void CreateWall(int x, int y, int spriteIndex)
    {
        var wall = Scene.CreateEntity<Wall>();
        wall.SpriteIndex = spriteIndex;
        wall.Position.X = x;
        wall.Position.Y = y;
    }
}
