/**
* CannonController.cs
* 
* This script controls the cannon on top of the cat's back.
*/

using UnityEngine;

namespace MyGame.Controllers
{
    [AddComponentMenu(menuName: "MyScripts/Controllers/CannonController")]
    public class CannonController : MonoBehaviour
    {
        private GameObject mouse;
        public KeyCode fireKey = KeyCode.C;
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] AudioClip _clipShoot;

        void Start()
        {
            mouse = GameObject.FindGameObjectWithTag("mouse");
        }

        void Update()
        {
            if (Input.GetKeyDown(fireKey) && mouse.GetComponent<MouseCtrl>().IsOnTop())
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(_clipShoot);
                GameObject projectile = Instantiate(projectilePrefab) as GameObject;
                projectile.transform.position = transform.TransformPoint(Vector3.forward * 2.5f + Vector3.up * 3f);
                projectile.transform.rotation = transform.rotation;
            }
        }
    }
}

