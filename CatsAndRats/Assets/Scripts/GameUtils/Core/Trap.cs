using UnityEngine;
namespace GameUtils.Core
{
    /*
    * This abstract class extend InteractionCollider.
    * Does not implement InteractionCollider, however it adds some methods in order to
    * damage cat/mouse.
    * We extend Trap clas to create a new logic of a trap and decided HOW the interaction
    * is performed in the collider and WHEN the damage is applied in our collider logic.
    */
    public abstract class Trap : GameUtils.Core.TriggerInteraction
    {
        [SerializeField] protected float damageAmount = 10f;
        [SerializeField] protected bool isLethal = false;
        [SerializeField] protected float trapCooldown = 3f;
        protected float timer = 0f;

        public void DamageCat()
        {
            if (isLethal)
            {
                GetCat().GetComponent<DamageHandler>().InstantDie();
            }
            else GetCat().GetComponent<DamageHandler>().TakeDamage(damageAmount);
        }
        public void DamageMouse()
        {
            GetMouse().GetComponent<DamageHandler>().TakeDamage(damageAmount);
        }
    }
}
