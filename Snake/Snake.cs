using OpenTK.Graphics.OpenGL;
using System.Diagnostics;

namespace Snake;
public class Snake
{
    private readonly int[] _positionX;
    private readonly int[] _positionY;

    public const int MAX_SNAKE_SIZE = 60;
    public int SnakeSize { get; private set; } = 5;

    public Snake()
    {
        _positionX = new int[MAX_SNAKE_SIZE];
        _positionY = new int[MAX_SNAKE_SIZE];

        InitializeSnake();
    }

    public void DrawSnake(GameState gameState)
    {
        ShiftBody();
        MoveSnake(gameState.Direction);
        DrawSnakeBody();
        HandleFoodConsumption(gameState);
        HandleCollision(gameState);
    }
    private Point GetHeadPosition()
    {
        return new Point(_positionX[0], _positionY[0]);
    }

    public void DrawSnakeBody()
    {
        for (int i = 0; i < SnakeSize; i++)
        {
            if (i == 0)
            {
                GL.Color3(1.0f, 0f, 0f);
            }
            else
            {
                GL.Color3(0f, 1.0f, 0f);
            }

            GL.Rect(_positionX[i], _positionY[i], _positionX[i] + 1, _positionY[i] + 1);
        }
    }

    public void MoveSnake(Direction direction)
    {
        if (direction == Direction.Right)
        {
            _positionX[0]++;
        }
        else if (direction == Direction.Left)
        {
            _positionX[0]--;
        }
        else if (direction == Direction.Up)
        {
            _positionY[0]++;

        }
        else if (direction == Direction.Down)
        {
            _positionY[0]--;
        }
    }

    public void ShiftBody()
    {
        for (int i = SnakeSize - 1; i > 0; i--)
        {
            Debug.WriteLine(SnakeSize);
            _positionX[i] = _positionX[i - 1];
            _positionY[i] = _positionY[i - 1];
        }
    }

    public void HandleFoodConsumption(GameState gameState)
    {
        var foodPosition = gameState.GetFoodPosition();
        var headPosition = GetHeadPosition();
        bool isFoodConsumed = headPosition.X == foodPosition.X && headPosition.Y == foodPosition.Y;

        if (isFoodConsumed)
        {
            SnakeSize = Math.Min(++SnakeSize, MAX_SNAKE_SIZE);
            gameState.IncreaseScore();
            gameState.CanDrawFood = true;
        }
    }

    public void HandleCollision(GameState gameState)
    {
        var headPosition = GetHeadPosition();
        bool isHeadOutOfBounds = headPosition.X == 0 || headPosition.X == Grid.SIZE - 1 || headPosition.Y == 0 || headPosition.Y == Grid.SIZE - 1;

        if (isHeadOutOfBounds)
        {
            gameState.GameOver = true;
        }

        for (int i = 1; i < SnakeSize; i++)
        {
            bool isHeadColidingWithTail = _positionX[i] == headPosition.X && _positionY[i] == headPosition.Y;

            if (isHeadColidingWithTail)
            {
                gameState.GameOver = true;
            }
        }
    }

    private void InitializeSnake()
    {
        for (int i = 0; i < SnakeSize; i++)
        {
            _positionX[i] = 20;
            _positionY[i] = 20;
        }
    }
}
