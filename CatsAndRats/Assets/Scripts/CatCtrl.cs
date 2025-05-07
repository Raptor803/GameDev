using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(GravityComponent))]
public class CatCtrl : MonoBehaviour
{
    Animator animator;
    bool walking;
    bool jumping;
    bool movingForward;
    public float speed = 1.3f;
    private float deltaY;

    private CharacterController catController;

    void Start()
    {
        jumping = false;
        walking = false;
        movingForward = true;

        animator = GetComponent<Animator>();
        catController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        // movimento asse verticale
        if(GetComponent<GravityComponent>().IsGrounded()) {
            if(Input.GetKeyDown(KeyCode.Space)){
                jumping = true;
                StartCoroutine(Jump());
            } else {
                jumping = false;
                deltaY = 0;
            }
        }

        // movimento asse orizzontale
        float deltaX = 0;
        walking = false;
        
        if(Input.GetKey(KeyCode.D)) {
            deltaX = speed;
        } else if(Input.GetKey(KeyCode.A)) {
            deltaX = -speed;
        }

        if(deltaX != 0) {
            walking = true;
        }

        // gestione della direzione
        if(deltaX < 0 && movingForward) {
            movingForward = false;
            transform.eulerAngles = new Vector3(0, -90);
        } else if (deltaX > 0 && !movingForward) {
            movingForward = true;
            transform.eulerAngles = new Vector3(0, 90);
        }

        Vector3 movement = new Vector3(deltaX, deltaY, 0) * Time.deltaTime;
        catController.Move(movement);

        HandleCharacterAnimation();
    }

    void HandleCharacterAnimation() {
        // animation
        if(jumping) {
            animator.SetFloat("State", 1f);
        } else {
            animator.SetFloat("State", 0f);
        }

        if (jumping || walking) {
            animator.SetFloat("Vert", 1f);
        } else {
            animator.SetFloat("Vert", 0f);
        }   
    }


    IEnumerator Jump() {
        for(float i = 10; i > 5; i -= 0.08f) {
            deltaY = i;
            yield return true;
        }
    }


    public bool IsMovingForward() {
        return movingForward;
    }

    public bool IsJumping() {
        return jumping;
    }


}

