using System.Collections.Generic;
using UnityEngine;

/* 
 * Connect the Itrigger interface with a list of tag
 * We can decide in the implemetation how it works.
 * 
 */

namespace GameUtils.Core
{
    public abstract class TriggerOnTag : MonoBehaviour, ITrigger
    {
        [SerializeField] public List<string> TagToInteractWith;
        public abstract void Trigger();

    }
}

