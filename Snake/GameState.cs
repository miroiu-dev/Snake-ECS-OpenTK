namespace Snake;
public class GameState(Food food)
{
    public bool CanDrawFood { get; set; } = true;
    public bool GameOver { get; set; }
    public Direction Direction = Direction.Right;
    public Point GetFoodPosition() => food.GetPosition();
    public int Score { get; private set; }
    public static int GetSpeed(int snakeSize)
    {
        return snakeSize switch
        {
            int score when score > 10 => 15,
            int score when score > 20 => 20,
            int score when score > 30 => 30,
            _ => 10
        };
    }

    public void IncreaseScore()
    {
        Score += 10;
    }
}
