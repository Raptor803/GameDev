using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
// adds the component to the components menu
public class MouseCtrl : MonoBehaviour
{
    Animator m_Animator;
    Boolean isWalking;
    Boolean isJumping;
    Boolean isMovingForward;
    public float speed = 1.5f;
    private const float JUMP_HEIGHT = 0.5f;
    public const float GROUND_DISTANCE = 0.02f;
    private const float GRAVITY = -9.81f * 0.00001f;

    // Using CharacterController to make movements takes into account the collisions
    private CharacterController characterCtrl;
    private Rigidbody body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterCtrl = GetComponent<CharacterController>();

        body = GetComponent<Rigidbody>();
        if(body != null) {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = 0;
        if(Input.GetKeyDown(KeyCode.A)) {
            deltaX = speed;
        } else if(Input.GetKeyDown(KeyCode.D)) {
            deltaX = -speed;
        }
        deltaX = deltaX * Time.deltaTime;

        // direction
        if(deltaX < 0 && isMovingForward) {
            isMovingForward = false;
            transform.Rotate(new Vector3(0, 180), Space.World);
        } else if (deltaX > 0 && !isMovingForward) {
            isMovingForward = true;
            transform.Rotate(new Vector3(0, 180), Space.World);
        }

        Vector3 movement = new Vector3(deltaX, GRAVITY, 0);
        characterCtrl.Move(movement);
    }
}

