using GameEngine;
using GameEngine.Components;
using System.Drawing;

namespace Snake;
public partial class Snake : Entity
{
    private double Speed => _snakeParts.Count switch
    {
        int score when score > 36 => 0.02,
        int score when score > 32 => 0.03,
        int score when score > 28 => 0.04,
        int score when score > 24 => 0.05,
        int score when score > 20 => 0.06,
        int score when score > 16 => 0.07,
        int score when score > 12 => 0.08,
        int score when score > 8 => 0.09,
        int score when score > 5 => 0.1,
        _ => 0.12
    };
    private SnakeHead Head => (SnakeHead)_snakeParts[0];
    public Direction Direction { get; set; } = Direction.Left;

    private readonly List<SnakePart> _snakeParts = [];
    public const int DEFAULT_SIZE = 5;

    public event Action? FoodEaten;
    public event Action? Died;

    private TimerComponent _timer = default!;

    protected override void Initialize()
    {
        InitializeSnake();
        _timer = AddComponent<TimerComponent>();
        _timer.Interval = Speed;
        _timer.Tick += MoveSnake;

        Head.Collider.CollisionEnter += OnHeadCollided;
    }
    private void OnHeadCollided(ColliderComponent component)
    {
        if (component.Entity is Food)
        {
            _timer.Interval = Speed;
            FoodEaten?.Invoke();
            Grow();
        }

        if (component.Entity is SnakePart or Tile)
        {
            Died?.Invoke();
        }
    }

    private void Grow()
    {
        var newPart = Scene.CreateEntity<SnakePart>();
        var lastPart = _snakeParts.Last();
        newPart.MoveTo(lastPart.Position);
        _snakeParts.Add(newPart);
    }

    private void MoveSnake()
    {
        FollowHead();
        Head.Move(Direction);
    }

    public void FollowHead()
    {
        for (int i = _snakeParts.Count - 1; i > 0; i--)
        {
            _snakeParts[i].MoveTo(_snakeParts[i - 1].Position);
        }
    }

    public bool IsInsideSnake(Point point)
    {
        return _snakeParts.Any(part => part.Position == point);
    }

    private void InitializeSnake()
    {
        var head = Scene.CreateEntity<SnakeHead>();
        head.Position.X = 20;
        head.Position.Y = 20;
        _snakeParts.Add(head);

        for (int i = 1; i < DEFAULT_SIZE; i++)
        {
            var snakePart = Scene.CreateEntity<SnakePart>();
            snakePart.Position.X = i + 20;
            snakePart.Position.Y = 20;
            _snakeParts.Add(snakePart);
        }
    }
}
