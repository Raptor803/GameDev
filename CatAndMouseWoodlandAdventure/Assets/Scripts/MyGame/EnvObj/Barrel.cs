using System.Collections;
using UnityEngine;


namespace MyGame.EnvObj
{
    public class Barrel : GameUtils.Core.TriggerOnTagEnter
    {
        [SerializeField] private AudioClip DestroySound;

        public override void Trigger(string tag)
        {
            StartCoroutine(DestroyAfterSound());
        }


        private IEnumerator DestroyAfterSound()
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(DestroySound);
            yield return new WaitForSeconds(DestroySound.length);

            Destroy(transform.parent.gameObject);
        }
    }
}

