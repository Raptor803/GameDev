
using UnityEngine;

namespace Deprecated
{
    /*
    * Abstract class for all action components.
    * a GameObject extends ActionComponent, in order to perform actions.
    * The ActionComponent interact with TriggerAction Base class giving it a method to invoke.
    */

    public abstract class ActionComponent : MonoBehaviour
    {
        public abstract void Action();
    }
}
