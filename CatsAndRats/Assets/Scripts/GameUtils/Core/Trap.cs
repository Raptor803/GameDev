using UnityEngine;
namespace GameUtils.Core
{
    /*
    * We extend Trap class to create a new logic of a trap and decided HOW the interaction
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
            if (isLethal)
            {
                GetMouse().GetComponent<DamageHandler>().InstantDie();
            }
            else GetMouse().GetComponent<DamageHandler>().TakeDamage(damageAmount);
        }
    }
}
