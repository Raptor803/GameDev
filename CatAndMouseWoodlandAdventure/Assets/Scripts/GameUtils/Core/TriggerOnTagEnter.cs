using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;



namespace GameUtils.Core
{
    public abstract class TriggerOnTagEnter : TriggerOnTag
    {
        private void OnTriggerEnter(Collider other)
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

