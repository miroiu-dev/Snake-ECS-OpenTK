using System.Drawing;

namespace GameEngine.Components;
public class ColliderComponent : Component
{
    private readonly HashSet<ColliderComponent> _currentCollisions = [];
    public Rectangle Bounds { get; set; }
    
    public event Action<ColliderComponent>? CollisionEnter;
    public event Action<ColliderComponent>? CollisionExit;
        
    protected internal void OnCollisionEnter(ColliderComponent other)
    {
        StartCollisionWith(other);
        CollisionEnter?.Invoke(other);
    }

    protected internal void OnCollisionExit(ColliderComponent other)
    {
        EndCollisionWith(other);
        CollisionExit?.Invoke(other);
    }

    public bool IsCollidingWith(ColliderComponent other) => _currentCollisions.Contains(other);
    private void StartCollisionWith(ColliderComponent other) => _currentCollisions.Add(other);
    private void EndCollisionWith(ColliderComponent other) => _currentCollisions.Remove(other);
    
    internal bool IntersectsWith(ColliderComponent otherCollider)
    {
        var thisBounds = GetBounds(this);
        var otherBounds = GetBounds(otherCollider);

        return thisBounds.IntersectsWith(otherBounds);
    }

    private static Rectangle GetBounds(ColliderComponent collider)
    {
        var position = collider.Entity.GetComponent<TransformComponent>();

        if (position is not null)
        {
            return new Rectangle(position.X + collider.Bounds.X, position.Y + collider.Bounds.Y, collider.Bounds.Width, collider.Bounds.Height);
        }

        return collider.Bounds;
    }
}
