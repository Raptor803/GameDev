using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, speed * Time.deltaTime));
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
