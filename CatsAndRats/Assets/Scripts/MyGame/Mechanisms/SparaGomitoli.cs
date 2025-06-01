using GameUtils.Core;
using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


namespace MyGame.Mechanisms
{
    
    [AddComponentMenu(menuName: "stuffs/SparaGomitoli")]
    public class SparaGomitoli : GameUtils.Core.PriorityTriggerOntag
    {
        [SerializeField]
        public GameObject gomitoli;
        [SerializeField] protected float ShootDelay;
        private float _timer = 0f;
        public override void Trigger(string tag)
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= ShootDelay)
            {
                Shoot();
                _timer = 0f;
            }
        }

        private void Shoot()
        {
            GameObject prj = Instantiate(gomitoli) as GameObject;
            prj.transform.position = transform.TransformPoint(Vector3.forward * 2.5f + Vector3.up * 3f);
            prj.transform.rotation = transform.rotation;
        }
    }
}