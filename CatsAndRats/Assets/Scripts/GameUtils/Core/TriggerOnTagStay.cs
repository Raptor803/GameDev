using UnityEngine;


namespace GameUtils.Core
{
    public abstract class TriggerOnTagStay : TriggerOnTag
    {
        private void OnTriggerStay(Collider other)
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

