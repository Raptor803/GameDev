using System.Collections;
using UnityEngine;

namespace MyGame.EnvObj
{
    public class Cloud : GameUtils.Core.TriggerInteraction
    {
        private float _timer = 0f;
        private float _maxTime = 1f;
        [SerializeField] private AudioClip DestroySound;
        private bool isCoroutineRunning = false;


        protected override void OnCatStaying()
        {
            Debug.Log("staying");
            _timer += Time.deltaTime;

            if (_timer > _maxTime) {
                //gameObject.GetComponent<AudioSource>().PlayOneShot(DestroySound;
                //Destroy(transform.parent.gameObject );
                if(!isCoroutineRunning) StartCoroutine(DestroyAfterSound());
            }

       }

        // coroutine to sync sound and destroy
        private IEnumerator DestroyAfterSound()
        {
            isCoroutineRunning = true;
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(DestroySound);
            yield return new WaitForSeconds(DestroySound.length);

            Destroy(transform.parent.gameObject);

            isCoroutineRunning=false;
        }
        protected override void OnCatExit()
        {
            _timer = 0f;
        }
    }
}

