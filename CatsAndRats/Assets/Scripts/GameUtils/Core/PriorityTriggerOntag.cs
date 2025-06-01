using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


/*
 * Implements a priority list
 * 
 * 
 */

namespace GameUtils.Core
{
    public abstract class PriorityTriggerOntag : TriggerOnTag
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created

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

