using UnityEngine;
using GameUtils.Core;

namespace MyGame.Damage
{
    public class DamageOnTag : PriorityTriggerOntag
    {
        [SerializeField] float damageAmount;
        public override void Trigger()
        {
            GameObject.FindWithTag("cat").GetComponent<GameUtils.Core.DamageHandler>().TakeDamage(damageAmount);
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            TagToInteractWith.Add("cat");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


