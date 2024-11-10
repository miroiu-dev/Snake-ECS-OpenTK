using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Snake;

public class Game : GameWindow
{
    private readonly Food _food;
    private readonly GameState _gameState;
    private readonly Grid _grid = new();
    private readonly Snake _snake = new();

    public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        _food = new();
        _gameState = new(_food);
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        GL.Viewport(0, 0, e.Width, e.Height);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        GL.Ortho(0d, 40d, 0d, 40d, -1.0d, 1.0d);
        GL.MatrixMode(MatrixMode.Modelview);

        base.OnResize(e);
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
    }
    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);

        GL.ClearColor(Color4.Black);
        GL.Clear(ClearBufferMask.ColorBufferBit);

        _grid.Draw();
        _snake.DrawSnake(_gameState);
        _food.Draw(_gameState);

        int speed = GameState.GetSpeed(_snake.SnakeSize);
        UpdateFrequency = speed;

        SwapBuffers();

        if (_gameState.GameOver)
        {
            Close();
        }
    }

    protected override void OnKeyDown(KeyboardKeyEventArgs e)
    {
        base.OnKeyDown(e);

        switch (e.Key)
        {
            case Keys.Left:
            case Keys.A:
                if (_gameState.Direction != Direction.Right)
                {
                    _gameState.Direction = Direction.Left;
                }
                break;
            case Keys.Right:
            case Keys.D:
                if (_gameState.Direction != Direction.Left)
                {
                    _gameState.Direction = Direction.Right;
                }
                break;
            case Keys.Up:
            case Keys.W:
                if (_gameState.Direction != Direction.Down)
                {
                    _gameState.Direction = Direction.Up;
                }
                break;
            case Keys.Down:
            case Keys.S:
                if (_gameState.Direction != Direction.Up)
                {
                    _gameState.Direction = Direction.Down;
                }
                break;
        }
    }
}
