using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject activator; // in our case, it's the mouse
    [SerializeField] GameObject projectilePrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)) {
            GameObject projectile = Instantiate(projectilePrefab) as GameObject;
            projectile.transform.position =  transform.TransformPoint(Vector3.forward * 2.5f + Vector3.up * 3f);
            projectile.transform.rotation = transform.rotation;
        }
    }
}
