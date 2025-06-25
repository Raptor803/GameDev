using UnityEngine;


namespace GameUtils.Core {

    public abstract class TriggerOnTagExit : TriggerOnTagEnter
    {
        private void OnTriggerExit(Collider other)
        {
            foreach (string tag in TagToInteractWith)
            {
                if (other.CompareTag(tag))
                {
                    Trigger(tag);
                    break;
                }
            }
        }
    }




}

