/**
* MouseCtrl.cs
* 
* This script controls the mouse's interaction with the cat.
*/

using UnityEngine;

namespace MyGame.Controllers
{
    [AddComponentMenu(menuName: "MyScripts/Controllers/MouseCtrl")]
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(GravityComponent))]
    public class MouseCtrl : MonoBehaviour
    {
        private MovementController movementController;
        private GravityComponent gravityComponent;
        private CharacterController controller;

        private const float CAT_MAX_DISTANCE = 0.5f;
        private Vector3 ON_CAT_OFFSET = new Vector3(0, 0.28f, 0); // offset to position the mouse when it gets on the cat
        private Vector3 OFF_CAT_OFFSET = new Vector3(0, .28f, -.30f); // offset to position the mouse when it gets off the cat
        private bool onTop = false;
        public GameObject cat;
        public KeyCode catKey = KeyCode.F; // key to get on/off the cat

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            movementController = GetComponent<MovementController>();
            gravityComponent = GetComponent<GravityComponent>();
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckInteraction();
        }

        void CheckInteraction()
        {
            float catDistance = Vector3.Distance(transform.position, cat.transform.position);

            if (catDistance < CAT_MAX_DISTANCE && !onTop)
            {
                cat.GetComponentInChildren<Outline>().enabled = true;
            }
            else
            {
                cat.GetComponentInChildren<Outline>().enabled = false;
            }

            if (catDistance < CAT_MAX_DISTANCE && Input.GetKeyDown(catKey))
            {
                if (onTop)
                {
                    getOffCat();
                }
                else
                {
                    getOnCat();
                }
            }
        }

        void getOnCat()
        {
            gravityComponent.Deactivate();
            movementController.Deactivate();
            controller.enabled = false;

            transform.SetParent(cat.transform);
            transform.position = cat.transform.position + ON_CAT_OFFSET;

            transform.eulerAngles = cat.GetComponent<MovementController>().GetOrientation();

            onTop = true;
        }

        void getOffCat()
        {
            transform.SetParent(null);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            transform.position = cat.transform.position + OFF_CAT_OFFSET;

            controller.enabled = true;
            gravityComponent.Activate();
            movementController.Activate();
            onTop = false;
        }

        public bool IsOnTop()
        {
            return onTop;
        }

        public void DeactivateInput()
        {
            movementController.Deactivate();
        }
        public void ActivateInput()
        {
            movementController.Activate();
        }

    }


}
