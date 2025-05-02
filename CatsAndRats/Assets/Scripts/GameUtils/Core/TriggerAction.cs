using UnityEngine;

namespace GameUtils.Core
{
    public abstract class TriggerAction : GameUtils.Core.InteractionCollider
    {
        [SerializeField] public ActionComponent ObjectToInteractWith;

        // public abstract void Trigger();
    }


}
