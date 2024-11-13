using GameEngine.Components;

namespace GameEngine.Systems;
public class TimeSystem : GameSystem
{
    protected internal override void Update(double time)
    {
        base.Update(time);

        foreach (var component in Scene.GetComponents<TimerComponent>())
        {
            component.Update(time);
        }
    }
}
