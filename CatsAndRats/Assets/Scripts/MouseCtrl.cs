using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(GravityComponent))]
public class MouseCtrl : MonoBehaviour
{
    public float speed = 3f;
    public bool canIMove= true;
    private int[][] ANGLES = new int[][]{
        new int[]{135,  90, 45},
        new int[]{180,  0,  0},
        new int[]{225,  270, 315}
    };

    private enum VER_DIR {DOWN, STILL, UP};
    private enum HOR_DIR {LEFT, STILL, RIGHT};
    private HOR_DIR xAngleIndex;
    private VER_DIR yAngleIndex;
    private const float CAT_MAX_DISTANCE = 0.5f;
    private bool onTop = true;
    private float deltaX, deltaZ;
    private GameObject cat;

    // Using CharacterController to make movements takes into account the collisions
    private CharacterController mouseController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cat = GameObject.FindGameObjectWithTag("cat");
        mouseController = GetComponent<CharacterController>();
        mouseController.enabled = false;
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
        
        if( canIMove){
            deltaX = 0;
            xAngleIndex = HOR_DIR.STILL;
            if(Input.GetKey(KeyCode.LeftArrow)) {
                deltaX = -speed;
                xAngleIndex = HOR_DIR.LEFT;
            } else if(Input.GetKey(KeyCode.RightArrow)) {
                deltaX = speed;
                xAngleIndex = HOR_DIR.RIGHT;
            }

            deltaZ = 0;
            yAngleIndex = VER_DIR.STILL;
            if(Input.GetKey(KeyCode.UpArrow)) {
                deltaZ = speed;
                yAngleIndex = VER_DIR.UP;
            } else if(Input.GetKey(KeyCode.DownArrow)) {
                deltaZ = -speed;
                yAngleIndex = VER_DIR.DOWN;
            }

            if(!(xAngleIndex == HOR_DIR.STILL && yAngleIndex == VER_DIR.STILL)) {
                transform.eulerAngles = new Vector3(0, ANGLES[(int) yAngleIndex][(int) xAngleIndex], 0);
            }

            Vector3 movement = new Vector3(deltaX, 0, deltaZ) * Time.deltaTime;
                mouseController.Move(movement);
        }
    }

    void CheckInteraction() {
        float catDistance = Vector3.Distance(transform.position, cat.transform.position);
        if(catDistance < CAT_MAX_DISTANCE && !onTop) {
            cat.GetComponent<Outline>().enabled = true;
        } else {
            cat.GetComponent<Outline>().enabled = false;
        }
        if(catDistance < CAT_MAX_DISTANCE && Input.GetKeyDown(KeyCode.F)) {
            if(onTop) {
                getOffCat();
            } else {
                getOnCat();
            }
        } 
    }

    void getOnCat() {
        GetComponent<GravityComponent>().enabled = false;
        mouseController.enabled = false;
        transform.SetParent(cat.transform);
        transform.position = cat.transform.position + new Vector3(0, .28f, 0);

        if(cat.GetComponent<CatCtrl>().IsMovingForward()){
            transform.eulerAngles = new Vector3(0,0,45);
        } else {
            transform.eulerAngles = new Vector3(0,180,45);
        }

        onTop = true;
    }

    void getOffCat() {
        transform.SetParent(null);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        transform.position = cat.transform.position + new Vector3(0, .28f, -.30f);
        GetComponent<GravityComponent>().Reset();
        GetComponent<GravityComponent>().enabled = true;
        mouseController.enabled = true;
        onTop = false;
    }

    public bool IsOnTop() {
        return onTop;
    }

    public void DeactivateInput()
    {
        canIMove = false;
    }
    public void ActivateInput()
    {
        canIMove = true;
    }

}

