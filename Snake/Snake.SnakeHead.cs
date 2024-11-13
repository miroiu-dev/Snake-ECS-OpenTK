using System.Drawing;

namespace Snake;
public partial class Snake
{
    private class SnakeHead : SnakePart
    {
        public SnakeHead()
        {
            Color = Color.Red;
        }

        public void Move(Direction direction)
        {
            if (direction == Direction.Right)
            {
                Position.X++;
            }
            else if (direction == Direction.Left)
            {
                Position.X--;
            }
            else if (direction == Direction.Up)
            {
                Position.Y++;

            }
            else if (direction == Direction.Down)
            {
                Position.Y--;
            }
        }
    }
}
