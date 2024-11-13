using GameEngine.Components;

namespace GameEngine.Systems;
public class CollisionSystem : GameSystem
{
    protected internal override void Update(double time)
    {
        base.Update(time);

        var entities = Scene.GetComponents<ColliderComponent>().ToList();

        for (int thisColliderIndex = 0; thisColliderIndex < entities.Count - 1; thisColliderIndex++)
        {
            for (int otherColliderIndex = thisColliderIndex + 1; otherColliderIndex < entities.Count; otherColliderIndex++)
            {
                var thisCollider = entities[thisColliderIndex];
                var otherCollider = entities[otherColliderIndex];

                bool isColliding = thisCollider.IntersectsWith(otherCollider);
                bool wasColliding = thisCollider.IsCollidingWith(otherCollider);

                if (isColliding && !wasColliding)
                {
                    thisCollider.OnCollisionEnter(otherCollider);
                    otherCollider.OnCollisionEnter(thisCollider);
                }
                else if (!isColliding && wasColliding)
                {
                    thisCollider.OnCollisionExit(otherCollider);
                    otherCollider.OnCollisionExit(thisCollider);
                }
            }
        }
    }
}
