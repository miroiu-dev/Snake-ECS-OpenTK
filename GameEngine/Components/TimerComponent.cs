namespace GameEngine.Components;
public class TimerComponent: Component
{
    private double _elapsedTime;
    public double Interval { get; set; } = 1;

    public event Action? Tick;

    protected internal override void Update(double time)
    {
        base.Update(time);

        if (_elapsedTime < Interval)
        {
            _elapsedTime += time;
        }
        else
        {
            _elapsedTime = 0;
            Tick?.Invoke();
        }
    }
}
