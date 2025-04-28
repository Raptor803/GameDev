using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class CatCtrl : MonoBehaviour
{
    Animator m_Animator;
    Boolean isWalking;
    Boolean isJumping;
    Boolean isMovingForward;
    public float speed = 1.3f;
    public float RAY_DISTANCE = 0.12f;
    private const float GRAVITY = -9.81f;
    private float vertVelocity;

    private CharacterController characterCtrl;
    private Rigidbody body;

    void Start()
    {
        isJumping = false;
        isWalking = false;
        isMovingForward = true;

        m_Animator = GetComponent<Animator>();
        characterCtrl = GetComponent<CharacterController>();

        body = GetComponent<Rigidbody>();
        if(body != null) {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // movimento asse verticale
        vertVelocity += GRAVITY * 5f * Time.deltaTime; 
        if(IsGrounded() && vertVelocity < 0) {
            vertVelocity = 0;
            isJumping = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            isJumping = true;
            StartCoroutine(Jump());
        }

        // movimento asse orizzontale
        float deltaX = 0;
        isWalking = false;
        
        if(Input.GetKey(KeyCode.RightArrow)) {
            deltaX = speed;
        } else if(Input.GetKey(KeyCode.LeftArrow)) {
            deltaX = -speed;
        }

        if(deltaX != 0) {
            isWalking = true;
        }

        // gestione della direzione
        if(deltaX < 0 && isMovingForward) {
            isMovingForward = false;
            transform.Rotate(new Vector3(0, 180), Space.World);
        } else if (deltaX > 0 && !isMovingForward) {
            isMovingForward = true;
            transform.Rotate(new Vector3(0, 180), Space.World);
        }

        Vector3 movement = new Vector3(deltaX, vertVelocity, 0) * Time.deltaTime;
        characterCtrl.Move(movement);

        HandleCharacterAnimation();
    }

    void HandleCharacterAnimation() {
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
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, RAY_DISTANCE, groundLayer)) {
            return true;
        }

        // non siamo a terra
        return false;
    }




}

