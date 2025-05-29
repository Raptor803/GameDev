using UnityEngine;


namespace MyGame
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        void Update()
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
    }
}

