
using GameEngine.Components;

namespace GameEngine.Systems;
public class RenderSystem : GameSystem
{
    protected internal override void Update(double time)
    {
        base.Update(time);

        foreach (var component in Scene.GetComponents<RendererComponent>())
        {
            component.Update(time);
        }
    }
}
