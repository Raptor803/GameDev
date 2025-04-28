using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class MouseCtrl : MonoBehaviour
{
    public float speed = 4f;
    private const float GRAVITY = -9.81f;
    private float[] DEPTH_RANGE = {-0.5f, 0.5f};
    private int[][] angles = new int[][]{
        new int[]{135,  90, 45},
        new int[]{180,  0,  0},
        new int[]{225,  270, 315}
    };
    private int xAngleIndex, yAngleIndex;

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
        xAngleIndex = 1;
        if(Input.GetKey(KeyCode.A)) {
            deltaX = -speed;
            xAngleIndex = 0;
        } else if(Input.GetKey(KeyCode.D)) {
            deltaX = speed;
            xAngleIndex = 2;
        }

        float deltaZ = 0;
        yAngleIndex = 1;
        if(Input.GetKey(KeyCode.W)) {
            deltaZ = speed;
            yAngleIndex = 2;
        } else if(Input.GetKey(KeyCode.S)) {
            deltaZ = -speed;
            yAngleIndex = 0;
        }

        if(xAngleIndex * yAngleIndex != 1) {
            transform.eulerAngles = new Vector3(0, angles[yAngleIndex][xAngleIndex], 0);
        }
            
        Vector3 movement = new Vector3(deltaX, GRAVITY * Time.deltaTime, deltaZ) * Time.deltaTime;
        characterCtrl.Move(movement);
    }
}

