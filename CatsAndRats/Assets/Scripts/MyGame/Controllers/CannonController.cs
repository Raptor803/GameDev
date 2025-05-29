using UnityEngine;

namespace MyGame.Controllers
{
    public class CannonController : MonoBehaviour
    {
        private GameObject mouse;
        [SerializeField] GameObject projectilePrefab;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mouse = GameObject.FindGameObjectWithTag("mouse");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.V) && mouse.GetComponent<MouseCtrl>().IsOnTop())
            {
                GameObject projectile = Instantiate(projectilePrefab) as GameObject;
                projectile.transform.position = transform.TransformPoint(Vector3.forward * 2.5f + Vector3.up * 3f);
                projectile.transform.rotation = transform.rotation;
            }
        }
    }
}

