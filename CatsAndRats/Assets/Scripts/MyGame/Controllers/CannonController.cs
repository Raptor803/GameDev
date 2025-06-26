using UnityEngine;

namespace MyGame.Controllers
{
    [AddComponentMenu(menuName: "MyScripts/Controllers/CannonController")]
    public class CannonController : MonoBehaviour
    {
        private GameObject mouse;
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] AudioClip _clipShoot;

        void Start()
        {
            mouse = GameObject.FindGameObjectWithTag("mouse");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.V) && mouse.GetComponent<MouseCtrl>().IsOnTop())
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(_clipShoot);
                GameObject projectile = Instantiate(projectilePrefab) as GameObject;
                projectile.transform.position = transform.TransformPoint(Vector3.forward * 2.5f + Vector3.up * 3f);
                projectile.transform.rotation = transform.rotation;
            }
        }
    }
}

