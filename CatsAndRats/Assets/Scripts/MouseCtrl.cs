using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MouseCtrl : MonoBehaviour
{
    public float speed = 3f;
    private const float GRAVITY = -9.81f;
    private int[][] ANGLES = new int[][]{
        new int[]{135,  90, 45},
        new int[]{180,  0,  0},
        new int[]{225,  270, 315}
    };
    private int xAngleIndex, yAngleIndex;
    private GameObject cat;
    private const float CAT_MAX_DISTANCE = 0.5f;
    private bool onTop = true;

    // Using CharacterController to make movements takes into account the collisions
    private CharacterController mouseCharCtrl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cat = GameObject.FindGameObjectWithTag("cat");
        mouseCharCtrl = GetComponent<CharacterController>();
        mouseCharCtrl.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        
        if(!onTop) {
            ControlMovement();
        }   
    }

    void ControlMovement() {
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
            transform.eulerAngles = new Vector3(0, ANGLES[yAngleIndex][xAngleIndex], 0);
        }

        Vector3 movement = new Vector3(deltaX, GRAVITY * 50f * Time.deltaTime, deltaZ) * Time.deltaTime;
        mouseCharCtrl.Move(movement);
    }

    void CheckInteraction() {
        if(Input.GetKeyDown(KeyCode.F) && Vector3.Distance(transform.position, cat.transform.position) < CAT_MAX_DISTANCE) {
            if(onTop) {
                transform.SetParent(null);
                transform.position = cat.transform.position + new Vector3(0, -0.1f, -.12f);
                onTop = false;
                mouseCharCtrl.enabled = true;
            } else {
                mouseCharCtrl.enabled = false;
                transform.SetParent(cat.transform);
                transform.position = cat.transform.position + new Vector3(0, .28f, 0);

                if(cat.GetComponent<CatCtrl>().IsMovingForward()){
                    transform.eulerAngles = new Vector3(0,0,0);
                } else {
                    transform.eulerAngles = new Vector3(0,180,0);
                }

                //transform.Translate(new Vector3(.01f,0,0), Space.Self);

                onTop = true;
            }
        } 
    }
}

