using System.Collections;
using UnityEngine;


namespace MyGame.EnvObj
{
    public class Barrel : GameUtils.Core.TriggerOnTagEnter
    {
        [SerializeField] private AudioClip DestroySound;

        public override void Trigger(string tag)
        {
            //gameObject.GetComponent<AudioSource>().PlayOneShot(DestroySound);
            //Destroy(transform.parent.gameObject);
            StartCoroutine(DestroyAfterSound());

        }


        private IEnumerator DestroyAfterSound()
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(DestroySound);
            yield return new WaitForSeconds(DestroySound.length);

            Destroy(transform.parent.gameObject);
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

