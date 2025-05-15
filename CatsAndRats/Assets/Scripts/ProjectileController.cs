using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 3f;
    public float angularSpeed = 2;
    private Rigidbody rb;
    private Vector3 directionForward, directionUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        directionForward = transform.forward;
        directionUp = transform.up;
    }

    // Update is called once per frametransform
    void Update()
    {
        Vector3 movement = directionForward * speed * Time.deltaTime
                        + directionUp * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        transform.Rotate(new Vector3(0, 0, angularSpeed), Space.World);
    }


    void OnTriggerEnter(Collider other)
    {
        /*
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if(player != null) {
            player.Hurt(1);
        } */  
        Destroy(this.gameObject);
    }

}
