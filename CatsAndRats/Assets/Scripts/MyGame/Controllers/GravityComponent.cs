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
            // assegniamo come layer del terreno "Floor" che andr� settato nell'ispector
            LayerMask groundLayer = LayerMask.GetMask("Floor");

            // raggio leggermente sopra i piedi dele personaggio
            Vector3 rayOrigin = transform.position;// + Vector3.up * 0.01f;

            // vogliamo controllare il terreno quindi il raggio � verso il basso
            Vector3 rayDirection = Vector3.down;

            // Verifichiamo se il raggio colpisce un oggetto di layer "Floor" (usando l'ultimo parametro come filtro della condizione) 
            if (Physics.Raycast(rayOrigin, rayDirection, FLOOR_DISTANCE, groundLayer))
            {
                return true;
            }

            // non siamo a terra
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
