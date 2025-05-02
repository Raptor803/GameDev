using UnityEngine;
namespace GameUtils.Mechanisms.Interactionable
{
    [AddComponentMenu("Mechanisms/CatButton")]
    public class CatButton : GameUtils.Core.TriggerAction
    {

        protected override void OnCatEnter()
        {
            throw new System.NotImplementedException();
        }
        protected override void OnCatExit()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnCatStaying()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ObjectToInteractWith.Action();
            }
        }

        protected override void Initialize()
        {
            throw new System.NotImplementedException();
        }


        protected override void OnMouseEnter()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnMouseExit()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnMouseStaying()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}
