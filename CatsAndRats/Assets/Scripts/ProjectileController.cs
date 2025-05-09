using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime
                        + transform.up * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
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
