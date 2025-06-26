/**
* GravityComponent.cs
* 
* This script applies gravity to the attached GameObject.
*/

using UnityEngine;

namespace MyGame
{
    [AddComponentMenu(menuName: "MyScripts/Controllers/GravityComponent")]
    [RequireComponent(typeof(CharacterController))]
    public class GravityComponent : MonoBehaviour
    {
        private const float GRAVITY = -9.81f;
        public float FLOOR_DISTANCE = 0.05f;
        public float MUL = 1f;
        private float deltaY;
        private CharacterController controller;
        public bool IsFalling { get; private set; }
        private bool canFall = true;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            deltaY = 0;
        }

        void Update()
        {
            if (canFall)
            {
                ApplyGravity();
            }
        }

        private void ApplyGravity()
        {
            if (IsGrounded() && deltaY < 0)
            {
                deltaY = 0;
                IsFalling = false;
            }
            else
            {
                deltaY += GRAVITY * MUL * Time.deltaTime;
                IsFalling = true;
            }

            controller.Move(new Vector3(0, deltaY * Time.deltaTime, 0));

        }

        public bool IsGrounded()
        {
            // The ground layer is labelled as Floor
            LayerMask groundLayer = LayerMask.GetMask("Floor");

            // Raycasting from the GameObject's position
            Vector3 rayOrigin = transform.position;

            // We cast a ray downward
            Vector3 rayDirection = Vector3.down;

            // We check whether it hits something marked as Floor 
            if (Physics.Raycast(rayOrigin, rayDirection, FLOOR_DISTANCE, groundLayer))
            {
                return true;
            }

            return false;
        }

        public void Activate()
        {
            canFall = true;
            deltaY = 0;
        }

        public void Deactivate()
        {
            canFall = false;
            deltaY = 0;
        }
    }
}
