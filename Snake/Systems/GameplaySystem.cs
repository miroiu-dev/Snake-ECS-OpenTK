using GameEngine;
using GameEngine.Components;

namespace Snake.Systems;
public class GameplaySystem : GameSystem
{
    public bool GameOver { get; private set; }
    private Snake _snake = default!;
    private readonly Random _random = new();
    private Food _food = default!;

    protected override void Initialize()
    {
        base.Initialize();
        _snake = Scene.GetEntity<Snake>() ?? throw new Exception($"No {nameof(Snake)} entity found!");
        _food = GenerateFood();

        _snake.FoodEaten += OnFoodEaten;
        _snake.Died += OnDied;
    }

    private void OnDied()
    {
        GameOver = true;
    }

    private void OnFoodEaten()
    {
        _food.Destroy();
        _food = GenerateFood();
    }

    private Food GenerateFood()
    {
        int max = Walls.GRID_SIZE - 2;
        int min = 1;

        int x = _random.Next(min, max);
        int y = _random.Next(min, max);

        while (_snake.IsInsideSnake(new(x, y)))
        {
            x = _random.Next(min, max);
            y = _random.Next(min, max);
        }

        var food = Scene.CreateEntity<Food>();
        food.Position.X = x;
        food.Position.Y = y;

        return food;
    }
}
