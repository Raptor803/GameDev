using GameUtils.Core;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

// Cannon that spawn YarnBall projectiles each seconds
namespace MyGame.Mechanisms
{
    
    [AddComponentMenu(menuName: "MyScripts/SparaGomitoli")]
    public class YarnBallCannon : GameUtils.Core.TriggerOnTagEnter, IEnable
    {
        [SerializeField]
        public GameObject gomitoli;
        [SerializeField] protected float ShootDelay;
        [SerializeField] private AudioClip _clip_destroy_cannon;

        private bool _state = false;

        private float _timer = 0f;
        public override void Trigger(string tag)
        {
            StartCoroutine(DestroyAfterSound());
        }

        private void Update()
        {
            if (_state)
            {
                _timer += Time.deltaTime;
                if (_timer >= ShootDelay)
                {
                    Shoot();
                    _timer = 0f;
                }
            }
        }

        private void Shoot()
        {
            
            GameObject prj = Instantiate(gomitoli) as GameObject;
            prj.transform.position = transform.TransformPoint(Vector3.forward * 2.5f + Vector3.up * 3f);
            prj.transform.rotation = transform.rotation;

        }

        public void Enable()
        {
            _state = true;
        }

        public void Disable()
        {
            _state = false;
        }

        private IEnumerator DestroyAfterSound()
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(_clip_destroy_cannon);
            yield return new WaitForSeconds(_clip_destroy_cannon.length);

            Destroy(transform.parent.gameObject);
        }
    }
}