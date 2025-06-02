using UnityEngine;

namespace MyGame.EnvObj
{
    public class Cloud : GameUtils.Core.TriggerInteraction
    {
        private float _timer = 0f;
        private float _maxTime = 1f;

       protected override void OnCatStaying()
       {
            _timer += Time.deltaTime;
            if (_timer > _maxTime ) Destroy( gameObject );
       }
        protected override void OnCatExit()
        {
            _timer = 0f;
        }
    }
}

