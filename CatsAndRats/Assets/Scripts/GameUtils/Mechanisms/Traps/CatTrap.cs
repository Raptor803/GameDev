using UnityEngine;

namespace GameUtils.Mechanisms.Traps
{
    /*
    * Trap that deals damage only to cats
    */
    [AddComponentMenu("Traps/CatTrap")]
    public class CatTrap : GameUtils.Core.Trap
    {
        protected override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnCatEnter()
        {
            DamageCat();
        }

        protected override void OnCatExit()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnCatStaying()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnDeactivate()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnMouseEnter()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnMouseExit()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnMouseStaying()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}
