using GameUtils.Core;
using System;
using UnityEngine;

namespace MyGame.Traps
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

        protected override void OnCatEnter()
        {
            deactivate();
        }


        protected override void OnDeactivate()
        {
            if(!GetMouse().GetComponent<MyGame.Controllers.MouseCtrl>().IsOnTop())
                GetMouse().GetComponent<MyGame.Controllers.MouseCtrl>().ActivateInput();
            
            // eat the cheese and heal the mouse when deactivated
            Destroy(cheese);
            GetMouse().GetComponent<DamageHandler>().Heal(20);
            
        }

        protected override void OnMouseEnter()
        {
            DamageMouse();
            // Mouse stays trapped
            GetMouse().GetComponent<MyGame.Controllers.MouseCtrl>().DeactivateInput();
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

    }

}
