using UnityEngine;

namespace MyGame.Projectiles{
    public class DestroyProjectileOnEnter : GameUtils.Core.TriggerOnTagEnter
    {
        public override void Trigger(string tag)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
