using UnityEngine;
namespace GameUtils.Core
{
    public abstract class Trap : GameUtils.Core.InteractionCollider
    {
        [SerializeField] protected float damageAmount = 10f;
        [SerializeField] protected bool isLethal = false;
        [SerializeField] protected float trapCooldown = 3f;

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
