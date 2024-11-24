using GameEngine;
using GameEngine.Systems;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Snake.Systems;

namespace Snake;

public class Game : GameWindow
{
    private readonly GameplaySystem _gameplaySystem;
    private readonly Scene _scene;
    private readonly Snake _snake;

    public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        _scene = Scene.CreateDefault();
        _scene.CreateEntity<Food>();
        _scene.CreateEntity<Walls>();
        //_snake = _scene.CreateEntity<Snake>();

        //_gameplaySystem = _scene.AddSystem<GameplaySystem>();
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
        _scene.Update(args.Time);

        SwapBuffers();

        //if (_gameplaySystem.GameOver)
        //{
        //    Close();
        //}
    }

    protected override void OnKeyDown(KeyboardKeyEventArgs e)
    {
        base.OnKeyDown(e);

        _snake.Direction = e.Key switch
        {
            Keys.Left or Keys.A when _snake.Direction != Direction.Right => Direction.Left,
            Keys.Right or Keys.D when _snake.Direction != Direction.Left => Direction.Right,
            Keys.Up or Keys.W when _snake.Direction != Direction.Down => Direction.Up,
            Keys.Down or Keys.S when _snake.Direction != Direction.Up => Direction.Down,
            _ => _snake.Direction
        };
    }
}
