using UnityEngine;


namespace MyGame.Mechanisms
{
    public class Barile : GameUtils.Core.TriggerOntag
    {
        public override void Trigger()
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

