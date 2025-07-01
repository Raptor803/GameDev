using GameUtils.Core;
using UnityEngine;

// when tags exit an area that trigger an object, for exemple a YarnBallCannon turns off
namespace MyGame.Mechanisms
{
    public class FireAreaExit : TriggerOnTagExit
    {
        [SerializeField] private GameObject _fireObject;
        public override void Trigger(string tag)
        {
            if (_fireObject == null) return;

            IEnable enabler = _fireObject.GetComponent<IEnable>();
            if(enabler != null) enabler.Disable();
        }
    }

}
