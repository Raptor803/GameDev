using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


/*
 *  We use this script to handle bullets interaction with some environment object.
 *  A class implement InteractionOnTag if it has to handle a specific behavior with "trigger":
 *  You need to specify in the inspector which tag trigger the "Trigger()" method.
 *
 *  Exemple: an object you destroy with a bullet implement this class...
 *  
 */

namespace Core
{
    public abstract class InterationOnTag : MonoBehaviour
    {
        [SerializeField] List<string> TagToInteractWith;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public abstract void Trigger();

        private void OnTriggerEnter(Collider other)
        {
            foreach (string tag in TagToInteractWith)
            {
                if (other.CompareTag(tag))
                {
                    Trigger();
                    break;
                }
            }
        }
    }


}

