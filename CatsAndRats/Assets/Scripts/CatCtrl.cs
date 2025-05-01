using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CatCtrl : MonoBehaviour
{
    Animator animator;
    bool walking;
    bool jumping;
    bool movingForward;
    public float speed = 1.3f;
    public float FLOOR_DISTANCE = 0.12f;
    private const float GRAVITY = -9.81f;
    private float vertVelocity;

    private CharacterController catCharacterCtrl;

    void Start()
    {
        jumping = false;
        walking = false;
        movingForward = true;

        animator = GetComponent<Animator>();
        catCharacterCtrl = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        // movimento asse verticale
        vertVelocity += GRAVITY * 5f * Time.deltaTime; 
        if(IsGrounded() && vertVelocity < 0) {
            vertVelocity = 0;
            jumping = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            jumping = true;
            StartCoroutine(Jump());
        }

        // movimento asse orizzontale
        float deltaX = 0;
        walking = false;
        
        if(Input.GetKey(KeyCode.RightArrow)) {
            deltaX = speed;
        } else if(Input.GetKey(KeyCode.LeftArrow)) {
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

        Vector3 movement = new Vector3(deltaX, vertVelocity, 0) * Time.deltaTime;
        catCharacterCtrl.Move(movement);

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
            vertVelocity = i;
            yield return true;
        }
    }


    bool IsGrounded()
    {
        // assegniamo come layer del terreno "Floor" che andr� settato nell'ispector
        LayerMask groundLayer = LayerMask.GetMask("Floor");

        // raggio leggermente sopra i piedi dele personaggio
        Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;

        // vogliamo controllare il terreno quindi il raggio � verso il basso
        Vector3 rayDirection = Vector3.down;

        // il risulatato sar� messo in hit
        RaycastHit hit;

        // Verifichiamo se il raggio colpisce un oggetto di layer "Floor" (usando l'ultimo parametro come filtro della condizione) 
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, FLOOR_DISTANCE, groundLayer)) {
            return true;
        }

        // non siamo a terra
        return false;
    }

    public bool IsMovingForward() {
        return movingForward;
    }

    public bool IsJumping() {
        return jumping;
    }


}

