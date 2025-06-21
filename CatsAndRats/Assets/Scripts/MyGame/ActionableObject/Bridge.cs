using System.Collections;
using UnityEngine;
using GameUtils.Core;

namespace MyGame.ActionableObject
{
    public class Bridge : Actionable
    {
        [SerializeField] GameObject rotationCenter;
        [SerializeField] Vector3 FinalState;
        [SerializeField] float animationDuration = 2f;

        [SerializeField] private GameObject DESTROY_PRJ;

        private bool isAnimating = false;
        private bool _finish = false;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_finish)
            {
//                Collider coll = transform.Find("DESTROY_PRJ")?.GetComponent<Collider>();
//               if (coll != null) coll.enabled = false;
                Destroy(DESTROY_PRJ);  
            }
        }

        public override void Action()
        {
            if (!isAnimating)
            {
                Debug.Log("Inizio abbassamento ponte");
                StartCoroutine(AnimateBridge());
            }
            
        }

        private IEnumerator AnimateBridge()
        {
            isAnimating = true;

            Quaternion initialRotation = rotationCenter.transform.localRotation;
            Quaternion targetRotation = Quaternion.Euler(FinalState);
            float elapsed = 0f;

            while (elapsed < animationDuration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / animationDuration);
                rotationCenter.transform.localRotation = Quaternion.Slerp(initialRotation, targetRotation, t);
                yield return null;
            }

            rotationCenter.transform.localRotation = targetRotation;
            Debug.Log("Ponte abbassato");
            isAnimating = false;
            _finish = true;
        }
    }
}

