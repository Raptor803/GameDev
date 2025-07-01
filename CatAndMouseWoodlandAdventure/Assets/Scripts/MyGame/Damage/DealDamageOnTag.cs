using UnityEngine;
using GameUtils.Core;
using MyGame.Controllers;

namespace MyGame.Damage
{
    public class DamageOnTag : TriggerOnTagEnter
    {
        [SerializeField] float damageAmount;
        public override void Trigger(string tag)
        {
            if(GameObject.FindWithTag("mouse").GetComponent<MouseCtrl>().IsOnTop())
            {
                GameObject.FindWithTag("mouse").GetComponent<GameUtils.Core.DamageHandler>().TakeDamage(damageAmount / 2);
                GameObject.FindWithTag("cat").GetComponent<GameUtils.Core.DamageHandler>().TakeDamage(damageAmount / 2);


            }
            else
                GameObject.FindWithTag(tag).GetComponent<GameUtils.Core.DamageHandler>().TakeDamage(damageAmount);
        }
    }
}


