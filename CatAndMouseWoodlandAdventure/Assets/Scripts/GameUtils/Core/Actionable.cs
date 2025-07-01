using UnityEngine;


namespace GameUtils.Core
{
    /*
    * abstraction is used for objects that can be triggered by something like a button
    */
    public abstract class Actionable : MonoBehaviour, IAction
    {
        public virtual void Action()
        {
            print(gameObject + ".Action()");
        }
    }
}
