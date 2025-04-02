using System;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
// adds the component to the components menu
[AddComponentMenu("Banana/CatCtrl")]
public class CatCtrl : MonoBehaviour
{
    Animator m_Animator;
    Boolean isWalking;
    Boolean isMovingForward;
    public float speed = 1.5f;
    private const float GRAVITY = -9.81f;
    // Using CharacterController to make movements takes into account the collisions
    private CharacterController characterCtrl;

    public float vert = 0f;
    public float state = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isWalking = false;
        isMovingForward = true;
        characterCtrl = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(deltaX < 0 && isMovingForward) {
            isMovingForward = false;
            transform.Rotate(new Vector3(0, 180), Space.World);
        } else if (deltaX > 0 && !isMovingForward) {
            isMovingForward = true;
            transform.Rotate(new Vector3(0, 180), Space.World);
        }

        if(deltaX != 0 && !isWalking) {
            isWalking = true;
            m_Animator.SetFloat("Vert", 1f);
            m_Animator.SetFloat("State", state);
        } else if (deltaX == 0 && isWalking) {
            isWalking = false;
            m_Animator.SetFloat("Vert", 0f);
            m_Animator.SetFloat("State", state);
        }
        transform.Translate(deltaX, 0, 0, Space.World);
    }
}

