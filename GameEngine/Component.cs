namespace GameEngine;
public abstract class Component
{
    public Entity Entity { get; internal set; } = default!;

    protected internal virtual void Update(double time)
    {
    }

    protected internal virtual void Initialize()
    {
    }
}
