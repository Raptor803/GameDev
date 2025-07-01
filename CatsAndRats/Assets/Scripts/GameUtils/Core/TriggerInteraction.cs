using UnityEngine;
namespace GameUtils.Core
{
    /*
    * this abstract class handles all the actions
    * we use when we enter/stay/exit a Unity collider (with isTrigger enabled)
    * extending this class allows to only implement the logic in the trigger
    * and not specify in every script the conditions enter/exit/stay and comparing the tag.
    */
    public abstract class TriggerInteraction : MonoBehaviour
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
            OnDeactivate();
        }



        protected void OnTriggerEnter(Collider other)
        {
            if(active) {
                if (other.CompareTag("cat"))
                {
                    //Debug.Log("cat entered the trigger!");
                    OnCatEnter();
                }
                if (other.CompareTag("mouse"))
                {
                    //Debug.Log("mouse entered the trigger!");
                    OnMouseEnter();
                }
            }
        }
        protected void OnTriggerExit(Collider other)
        {
            if (active)
            {
                if (other.CompareTag("cat"))
                {
                    //Debug.Log("cat entered the trigger!");
                    OnCatExit();
                }
                if (other.CompareTag("mouse"))
                {
                    //Debug.Log("mouse entered the trigger!");
                    OnMouseExit();
                }
            }
                 
        }

        protected void OnTriggerStay(Collider other)
        {
            if (active)
            {
                if (other.CompareTag("cat"))
                {
                    //Debug.Log("cat staying in the trigger!");
                    OnCatStaying();
                }
                if (other.CompareTag("mouse"))
                {
                    //Debug.Log("mouse staying in the trigger!");
                    OnMouseStaying();
                }
            }
        }


        protected virtual void Initialize() {}

        protected virtual void OnCatEnter() {}
        protected virtual void OnMouseEnter() {}

        protected virtual void OnCatExit() {}
        protected virtual void OnMouseExit() {}

        protected virtual void OnCatStaying() {}
        protected virtual void OnMouseStaying() {}

        protected virtual void OnUpdate() {}
        protected virtual void OnDeactivate() {}
    }
}
