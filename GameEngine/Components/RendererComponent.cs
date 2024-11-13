namespace GameEngine.Components;

public interface IRenderable
{
    void Render();
}

public class RendererComponent : Component
{
    protected internal override void Update(double time)
    {
        base.Update(time);
        ((IRenderable)Entity).Render();
    }
}
