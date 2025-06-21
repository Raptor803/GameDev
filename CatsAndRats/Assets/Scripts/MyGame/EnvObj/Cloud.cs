using UnityEngine;

namespace MyGame.EnvObj
{
    public class Cloud : GameUtils.Core.TriggerInteraction
    {
        private float _timer = 0f;
        private float _maxTime = 1f;

       protected override void OnCatStaying()
       {
            Debug.Log("staying");
            _timer += Time.deltaTime;
            if (_timer > _maxTime ) Destroy(transform.parent.gameObject );
       }
        protected override void OnCatExit()
        {
            _timer = 0f;
        }
    }
}

