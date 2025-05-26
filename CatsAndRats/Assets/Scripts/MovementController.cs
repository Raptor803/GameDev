using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    public float speed = 3f;
    private bool canIMove = true;
    public bool xMovementAllowed = true;
    public bool zMovementAllowed = true;
    public Vector3 initialOrientation = new Vector3(0, 90, 0);

    // used for character rotation
    private int[][] ANGLES = new int[][]{
        new int[]{-135,  -90, -45},
        new int[]{180,  0,  0},
        new int[]{135,  90, 45}
    };

    private enum X_DIR { LEFT, STILL, RIGHT };
    private enum Z_DIR { IN, STILL, OUT };
    private X_DIR xAngleIndex;
    private Z_DIR zAngleIndex;
    private float deltaX, deltaZ;

    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode inKey = KeyCode.UpArrow; // key for movement with increasing Z value (away from the camera)
    public KeyCode outKey = KeyCode.DownArrow; // key for movement with decreasing Z value (towards the camera)

    // using CharacterController to make movements takes into account the collisions
    private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        deltaX = 0;
        deltaZ = 0;
        xAngleIndex = X_DIR.STILL;
        zAngleIndex = Z_DIR.STILL;
    }

    // Update is called once per frame
    void Update()
    {
        if (canIMove)
        {
            ControlMovement();
        }
    }

    private void ControlMovement() {
    
        deltaX = 0;
        xAngleIndex = X_DIR.STILL;
        if (xMovementAllowed)
        {
            HandleXMovement();
        }

        deltaZ = 0;
        zAngleIndex = Z_DIR.STILL;
        if (zMovementAllowed)
        {
            HandleZMovement();
        }

        if(!(xAngleIndex == X_DIR.STILL && zAngleIndex == Z_DIR.STILL)) {
            transform.eulerAngles = new Vector3(0, ANGLES[(int) zAngleIndex][(int) xAngleIndex], 0) + initialOrientation;
        }

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed) * Time.deltaTime;
        controller.Move(movement);
    }

    private void HandleXMovement()
    {
        if (Input.GetKey(leftKey))
        {
            deltaX = -speed;
            xAngleIndex = X_DIR.LEFT;
        }
        else if (Input.GetKey(rightKey))
        {
            deltaX = speed;
            xAngleIndex = X_DIR.RIGHT;
        } 
    }

    private void HandleZMovement()
    {
        if (Input.GetKey(inKey))
        {
            deltaZ = speed;
            zAngleIndex = Z_DIR.IN;
        }
        else if (Input.GetKey(outKey))
        {
            deltaZ = -speed;
            zAngleIndex = Z_DIR.OUT;
        }
    }

    public Vector3 GetOrientation()
    {
        return transform.eulerAngles - initialOrientation;
    }

    public bool IsMoving()
    {
        return (deltaX != 0 || deltaZ != 0);
    }

    public bool CanMove()
    {
        return canIMove;
    }

    public void Deactivate()
    {
        canIMove = false;
    }

    public void Activate()
    {
        canIMove = true;
    }

}

