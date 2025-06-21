using GameUtils.Core;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace MyGame.Mechanisms
{
    public class FireAreaExit : TriggerOnTagExit
    {
        [SerializeField] private GameObject _fireObject;
        public override void Trigger(string tag)
        {
            IEnable enabler = _fireObject.GetComponent<IEnable>();
            enabler.Disable();
        }
    }

}
