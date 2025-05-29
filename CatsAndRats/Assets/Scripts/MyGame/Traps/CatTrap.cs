using UnityEngine;

namespace MyGame.Traps
{
    /*
    * Trap that deals damage only to cats
    */
    [AddComponentMenu("Traps/CatTrap")]
    public class CatTrap : GameUtils.Core.Trap
    {
        protected override void OnCatEnter()
        {
            DamageCat();
        }
    }
}
