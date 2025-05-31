using UnityEngine;


namespace MyGame.Projectiles
{
    public class Gomitolo : GameUtils.Core.PriorityTriggerOntag
    {
        private Rigidbody rb;
        public float velocita = 10f;
        public int maxRimbalzi = 10;
        private int conteggioRimbalzi = 0;
        public override void Trigger()
        {
            Debug.Log("Collide chiamato da: " + gameObject.name);
            Destroy(gameObject);
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            this.TagToInteractWith.Add("ProjectileCheese");
            this.TagToInteractWith.Add("ProjectileApple");

        }

        private void OnCollisionEnter(Collision collision)
        {
            conteggioRimbalzi++;
            if (conteggioRimbalzi >= maxRimbalzi)
            {
                Destroy(gameObject);
            }
            rb.linearVelocity = transform.forward * velocita;
        }


    }
}

