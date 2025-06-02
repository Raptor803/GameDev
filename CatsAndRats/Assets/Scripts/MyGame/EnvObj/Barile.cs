using UnityEngine;


namespace MyGame.EnvObj
{
    public class Barile : GameUtils.Core.PriorityTriggerOntag
    {
        public override void Trigger(string tag)
        {
            Destroy(gameObject);
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

