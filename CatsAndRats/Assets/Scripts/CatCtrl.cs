using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
// adds the component to the components menu
[AddComponentMenu("Banana/CatCtrl")]
public class CatCtrl : MonoBehaviour
{
    Animator m_Animator;
    Boolean isWalking;
    Boolean isJumping;
    Boolean isMovingForward;
    public float speed = 1.5f;
    private const float JUMP_HEIGHT = 0.5f;
    public const float GROUND_DISTANCE = 0.02f;
    private const float GRAVITY = -9.81f * 0.001f;
    private LayerMask groundLayer;


    // Using CharacterController to make movements takes into account the collisions
    private CharacterController characterCtrl;
    private Rigidbody body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isJumping = false;
        isWalking = false;
        isMovingForward = true;

        characterCtrl = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();

        body = GetComponent<Rigidbody>();
        if(body != null) {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            isJumping = true;
            StartCoroutine(Jump());
        }

        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(deltaX == 0) {
            isWalking = false;
        } else {
            isWalking = true;
        }

        // direction
        if(deltaX < 0 && isMovingForward) {
            isMovingForward = false;
            transform.Rotate(new Vector3(0, 180), Space.World);
        } else if (deltaX > 0 && !isMovingForward) {
            isMovingForward = true;
            transform.Rotate(new Vector3(0, 180), Space.World);
        }

        // animation
        if(isJumping) {
            m_Animator.SetFloat("State", 1f);
        } else {
            m_Animator.SetFloat("State", 0f);
        }

        if (isJumping || isWalking) {
            m_Animator.SetFloat("Vert", 1f);
        } else {
            m_Animator.SetFloat("Vert", 0f);
        }

        Vector3 movement = new Vector3(deltaX, GRAVITY, 0);
        characterCtrl.Move(movement);
    }

    IEnumerator Jump() {
        //m_Animator.SetFloat("Vert", 1f);
        //m_Animator.SetFloat("State", 1f);
        for(float i = 0.5f; i >= 0; i -= 0.007f){
            yield return characterCtrl.Move(new Vector3(0, i*i*0.3f, 0));
        };
        //m_Animator.SetFloat("State", 0f);
        //m_Animator.SetFloat("Vert", 0f);
        isJumping = false;
    }


    bool IsGrounded()
    {
        // assegniamo come layer del terreno "Floor" che andrà settato nell'ispector
        groundLayer = LayerMask.GetMask("Floor");

        // raggio leggermente sopra i piedi dele personaggio
        Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;

        // vogliamo controllare il terreno quindi il raggio è verso il basso
        Vector3 rayDirection = Vector3.down;

        // distanza
        float rayDistance = 0.6f; // regolabile se necessario

        // il risulatato sarà messo in hit
        RaycastHit hit;

        // Verifichiamo se il raggio colpisce un oggetto di layer "Floor" (usando l'ultimo parametro come filtro della condizione) 
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayDistance, groundLayer))
        {
            // Se il raggio colpisce un oggetto nel groundLayer, siamo a terra
            return true;
        }

        // non siamo a terra
        return false;
    }




}

