using System;
using System.Collections;
using UnityEngine;



namespace MyGame.Projectiles
{
    public class YarnBall : GameUtils.Core.TriggerOnTagEnter
    {
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float gravity = -20f;        // simulate gravity
        [SerializeField] private float forwardSpeed = 5f;
        [SerializeField] private LayerMask floorLayer;        // Floor layer to interact with

        private int _currentJumps = 0;
        [SerializeField] private int MaxJumps = 100;
        [SerializeField] GameObject effectDestroy;

        [SerializeField] private AudioClip soundFire;

        private float verticalVelocity;
        private bool isFalling = false;

        private void Start()
        {
            verticalVelocity = jumpForce;
        }

        private void Update()
        {
            // destroy it reached max jumps
            if (_currentJumps >= MaxJumps) Destroy(transform.parent.gameObject);


            // Apply gravity to vertical jump
            verticalVelocity += gravity * Time.deltaTime;

            // Vertical movement
            Vector3 verticalMove = Vector3.up * verticalVelocity * Time.deltaTime;

            // Move forward 
            Vector3 forwardMove = transform.forward * forwardSpeed * Time.deltaTime;

            // Apply it
            transform.position += forwardMove + verticalMove;

            // If the floor is reached...
            if (verticalVelocity < 0f && IsTouchingFloor())
            {
                verticalVelocity = jumpForce;


                Vector3 pos = transform.position;
                pos.y = GetFloorY();
                transform.position = pos;
                _currentJumps++;
                gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                //Debug.Log($"RIMBALZO #{_currentJumps}");

            }
        }

        private bool IsTouchingFloor()
        {
            // adjust maxDistance if necessary!
            return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.3f, floorLayer);
        }


        private float GetFloorY()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f, floorLayer))
            {
                return hit.point.y;
            }
            return transform.position.y;
        }

        public override void Trigger(string tag)
        {
            effectDestroy.SetActive(true);
            Debug.Log("ciao");
            StartCoroutine(WaitAndDestroy());
        }

        private IEnumerator WaitAndDestroy()
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(soundFire);
            ParticleSystem ps = effectDestroy.GetComponent<ParticleSystem>();
            while (!ps.isStopped)
            {
                yield return null;
            }

            Destroy(transform.parent.gameObject);

        }
    }

}
