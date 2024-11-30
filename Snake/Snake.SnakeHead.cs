using System.Drawing;

namespace Snake;
public partial class Snake
{
    private class SnakeHead : SnakePart
    {
        public SnakeHead()
        {
            Color = Color.Red;
            SpriteIndex = 50;
        }

        public void Move(Direction direction)
        {
            if (direction == Direction.Right)
            {
                Position.X++;
                SpriteIndex = 52;
            }
            else if (direction == Direction.Left)
            {
                Position.X--;
                SpriteIndex = 50;
            }
            else if (direction == Direction.Up)
            {
                Position.Y++;
                SpriteIndex = 49;
            }
            else if (direction == Direction.Down)
            {
                Position.Y--;
                SpriteIndex = 51;
            }
        }
    }
}
