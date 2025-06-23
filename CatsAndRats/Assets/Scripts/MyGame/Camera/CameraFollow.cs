using UnityEngine;


namespace MyGame
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public bool followX = true;
        public bool followY = true;
        public bool followZ = true;
        public Vector3 offset = new Vector3(0, 0, 0);

        void Update()
        {
            transform.position = new Vector3(
                followX ? target.position.x + offset.x : transform.position.x,
                followY ? target.position.y + offset.y : transform.position.y,
                followZ ? target.position.z + offset.z : transform.position.z);
        }
    }
}

