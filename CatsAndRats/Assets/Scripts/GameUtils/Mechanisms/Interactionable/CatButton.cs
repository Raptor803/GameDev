using UnityEngine;
namespace GameUtils.Mechanisms.Interactionable
{
    /*
    * A button that can be interacted with by cat player.
    * Pressing the Button E will trigger the action.
    *
    * We can also ADD interaction with Mouse player.
    * But the idea is somthing that can be used only by a Cat.
    */

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

        protected override void OnDeactivate()
        {
            throw new System.NotImplementedException();
        }
    }
}
