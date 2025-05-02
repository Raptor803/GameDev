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
        protected override void Initialize()
        {
            throw new NotImplementedException();
        }

        protected override void OnCatEnter()
        {
            throw new NotImplementedException();
        }

        protected override void OnCatExit()
        {
            throw new NotImplementedException();
        }

        protected override void OnCatStaying()
        {
            throw new NotImplementedException();
        }

        protected override void OnMouseEnter()
        {
            throw new NotImplementedException();
        }

        protected override void OnMouseExit()
        {
            throw new NotImplementedException();
        }

        protected override void OnMouseStaying()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }

}
