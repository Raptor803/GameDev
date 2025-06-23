using GameUtils.Core;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace MyGame.Mechanisms
{
    public class FireAreaStay : GameUtils.Core.TriggerOnTagStay
    {
        [SerializeField] private GameObject _fireObject;
        public override void Trigger(string tag)
        {
            if (_fireObject == null) return;

            IEnable enabler = _fireObject.GetComponent<IEnable>();
            if (enabler != null) enabler.Enable();
        }
    }
}

