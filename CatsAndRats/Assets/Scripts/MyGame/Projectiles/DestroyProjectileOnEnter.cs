using UnityEngine;

// when a projectile enter a tagged area destroy itself
namespace MyGame.Projectiles{
    public class DestroyProjectileOnEnter : GameUtils.Core.TriggerOnTagEnter
    {
        public override void Trigger(string tag)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
