using UnityEngine;
using GameUtils.Core;

namespace MyGame.Damage
{
    public class HealOnTag : PriorityTriggerOntag
    {
        [SerializeField] float healAmount;
        public override void Trigger(string tag)
        {
            GameObject.FindWithTag(tag).GetComponent<GameUtils.Core.DamageHandler>().Heal(healAmount);
        }
    }
}


