namespace GameEngine;
public abstract class GameSystem
{
    public Scene Scene { get; internal set; } = default!;

    protected internal virtual void Update(double time)
    {
    }

    protected internal virtual void Initialize()
    {

    }
}
