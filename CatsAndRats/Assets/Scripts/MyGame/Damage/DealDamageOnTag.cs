using UnityEngine;
using GameUtils.Core;

namespace MyGame.Damage
{
    public class DamageOnTag : PriorityTriggerOntag
    {
        [SerializeField] float damageAmount;
        public override void Trigger(string tag)
        {
            GameObject.FindWithTag(tag).GetComponent<GameUtils.Core.DamageHandler>().TakeDamage(damageAmount);
        }
    }
}


