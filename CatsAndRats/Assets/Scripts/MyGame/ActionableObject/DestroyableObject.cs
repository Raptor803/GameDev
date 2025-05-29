using UnityEngine;
using GameUtils.Core;

namespace MyGame.ActionableObject
{
    public class DestroyableObject : Actionable
    {
        public override void Action()
        {
            gameObject.SetActive(false);
        }

    }

}
