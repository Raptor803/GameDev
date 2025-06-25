using System.Collections;
using UnityEngine;
using UnityGLTF.Interactivity.VisualScripting.Export;

namespace MyGame.Controllers
{
    [AddComponentMenu(menuName: "MyScripts/Controllers/JumpController")]
    [RequireComponent(typeof(GravityComponent))]
    [RequireComponent(typeof(CharacterController))]
    public class JumpController : MonoBehaviour
    {

        private GravityComponent gravityComponent;
        private CharacterController controller;
        public bool jumpingAllowed = true;
        private bool jumping = false;
        private float deltaY;

        public float STARTING_SPEED = 10f; // initial speed of the jump
        public float ENDING_SPEED = 5f; // speed at which the jump ends
        public float JUMP_DECREMENT = 0.08f; // decrement of the jump speed per frame
        public KeyCode jumpKey = KeyCode.Space; // key to trigger the jump

        [SerializeField] protected AudioClip jumpSound;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            gravityComponent = GetComponent<GravityComponent>();
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (gravityComponent.IsGrounded() && jumpingAllowed)
            {
                if (Input.GetKeyDown(jumpKey))
                {
                    jumping = true;
                    StartCoroutine(Jump());
                }
                else
                {
                    jumping = false;
                    deltaY = 0;
                }
            }

            Vector3 movement = new Vector3(0, deltaY, 0) * Time.deltaTime;
            controller.Move(movement);
        }

        IEnumerator Jump()
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(jumpSound);
            for (float i = STARTING_SPEED; i > ENDING_SPEED; i -= JUMP_DECREMENT)
            {
                deltaY = i;
                yield return true;
            }
        }

        public bool IsJumping()
        {
            return jumping;
        }
    }

}
