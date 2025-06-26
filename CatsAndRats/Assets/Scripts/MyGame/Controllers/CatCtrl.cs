/**
* CatCtrl.cs
* 
* This script controls the cat character and animations.
*/

using UnityEngine;

namespace MyGame.Controllers
{
    [AddComponentMenu(menuName: "MyScripts/Controllers/CatCtrl")]
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(GravityComponent))]
    [RequireComponent(typeof(JumpController))]
    public class CatCtrl : MonoBehaviour
    {
        private Animator animator;
        private MovementController movementController;
        private JumpController jumpController;

        void Start()
        {
            animator = GetComponent<Animator>();
            jumpController = GetComponent<JumpController>();
            movementController = GetComponent<MovementController>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleCharacterAnimation();
        }

        void HandleCharacterAnimation()
        {
            // animation
            if (jumpController.IsJumping())
            {
                animator.SetFloat("State", 1f);
            }
            else
            {
                animator.SetFloat("State", 0f);
            }

            if (jumpController.IsJumping() || movementController.IsMoving())
            {
                
                animator.SetFloat("Vert", 1f);
            }
            else
            {
                animator.SetFloat("Vert", 0f);
            }
        }
    }


}