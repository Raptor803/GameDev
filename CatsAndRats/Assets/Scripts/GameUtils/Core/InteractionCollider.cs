using UnityEngine;
namespace GameUtils.Core
{
    public abstract class InteractionCollider : MonoBehaviour
    {
        protected bool active = true;

        public void Start()
        {
            Initialize();
        }

        public void Update()
        {
            if (active) OnUpdate();

        }

        public GameObject GetCat()
        {
            return GameObject.FindWithTag("cat");
        }

        public GameObject GetMouse()
        {
            return GameObject.FindWithTag("mouse");
        }

        public void deactivate()
        {
            active = false;
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("cat"))
            {
                Debug.Log("cat entered the trigger!");
                OnCatEnter();
            }
            if (other.CompareTag("mouse"))
            {
                Debug.Log("mouse entered the trigger!");
                OnMouseEnter();
            }
        }
        protected void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("cat"))
            {
                Debug.Log("cat entered the trigger!");
                OnCatExit();
            }
            if (other.CompareTag("mouse"))
            {
                Debug.Log("mouse entered the trigger!");
                OnMouseExit();
            }
        }

        protected void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("cat"))
            {
                Debug.Log("cat staying in the trigger!");
                OnCatStaying();
            }
            if (other.CompareTag("mouse"))
            {
                Debug.Log("mouse staying in the trigger!");
                OnMouseStaying();
            }
        }


        protected abstract void Initialize();

        protected abstract void OnCatEnter();
        protected abstract void OnMouseEnter();

        protected abstract void OnCatExit();
        protected abstract void OnMouseExit();

        protected abstract void OnCatStaying();
        protected abstract void OnMouseStaying();

        protected abstract void OnUpdate();
    }
}
