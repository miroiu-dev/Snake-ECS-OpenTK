namespace GameEngine;
public abstract class Entity : IDisposable
{
    public Scene Scene { get; internal set; } = default!;

    public T AddComponent<T>() where T : Component, new()
    {
        return Scene.AddComponent<T>(this);
    }

    public T? GetComponent<T>() where T : Component
    {
        return Scene.GetComponent<T>(this);
    }

    public IEnumerable<T> GetComponents<T>() where T : Component
    {
        return Scene.GetComponents<T>(this);
    }

    public void RemoveComponent<T>() where T : Component
    {
        Scene.RemoveComponent<T>(this);
    }

    public void Destroy()
    {
        Scene.RemoveEntity(this);
    }

    protected internal virtual void Update(double time)
    {

    }

    protected internal virtual void Initialize()
    {

    }

    public virtual void Dispose()
    {

    }
}
