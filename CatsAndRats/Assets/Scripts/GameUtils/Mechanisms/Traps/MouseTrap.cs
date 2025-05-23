using GameUtils.Core;
using System;
using UnityEngine;

namespace GameUtils.MouseTrap.Traps
{
    /*
    * A classic MouseTrap
    * the trap deals damage to the mouse when it enters the trap and paralize it
    * the cat is not affected by the trap, and can disable it
    */

    [AddComponentMenu("Traps/MouseTrap")]
    class MouseTrap : GameUtils.Core.Trap
    {
        [SerializeField] private GameObject cheese;
        protected override void Initialize()
        {
            throw new NotImplementedException();
        }

        protected override void OnCatEnter()
        {
            deactivate();
            // TODO: change graphic as a destroyed mouseTrap
        }

        protected override void OnCatExit()
        {
            throw new NotImplementedException();
        }

        protected override void OnCatStaying()
        {
            throw new NotImplementedException();
        }

        protected override void OnDeactivate()
        {
            GetMouse().GetComponent<MouseCtrl>().ActivateInput();
            // eat the cheese and heal the mouse when deactivated
            Destroy(cheese);
            GetMouse().GetComponent<DamageHandler>().TakeDamage(-20);
            
        }

        protected override void OnMouseEnter()
        {
            DamageMouse();
            // il topo rimane intrappolato
            GetMouse().GetComponent<MouseCtrl>().DeactivateInput();
        }

        protected override void OnMouseExit()
        {
            throw new NotImplementedException();
        }

        protected override void OnMouseStaying()
        {
            timer += Time.deltaTime;
            if (timer >= trapCooldown)
            {
                DamageMouse();
                timer = 0f;
            }
            
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }

}
