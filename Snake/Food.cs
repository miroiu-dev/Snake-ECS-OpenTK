using OpenTK.Graphics.OpenGL;

namespace Snake;
public class Food()
{
    private readonly Random _random = new();
    private Point _position = new(0, 0);

    public void Draw(GameState gameState)
    {
        if (gameState.CanDrawFood)
        {
            _position = GetFood();
            gameState.CanDrawFood = false;
        }

        GL.Rect(_position.X, _position.Y, _position.X + 1, _position.Y + 1);
    }

    private Point GetFood()
    {
        var newPosition = GenerateFood();
        
        while (newPosition == _position)
        {
            newPosition = GenerateFood();
        }

       return newPosition;
    }

    private Point GenerateFood()
    {
        int max = Grid.SIZE - 2;
        int min = 1;

        int x = _random.Next(min, max);
        int y = _random.Next(min, max);

        return new Point(x, y);
    }

    public void SetPosition(int x, int y)
    {
        if (x < 0 || x > Grid.SIZE || y < 0 || y > Grid.SIZE)
        {
            throw new ArgumentException("Position is out of bounds");
        }

        _position = new Point(x, y);
    }

    public Point GetPosition()
    {
        return _position;
    }
}
