using GameUtils.Core;
using System;
using System.Collections;
using UnityEngine;

namespace MyGame.ActionableObject
{
    public class OakStairs : Actionable
    {
        [SerializeField] float moveZOffset;
        private bool isMoving;
        private float moveDuration = 2f;

        private Vector3 _restartPosition;

        private Coroutine _coroutineNowUsed;
        [SerializeField] AudioClip _clip;

        void Start()
        {
            _restartPosition = transform.position;
        }

        public override void Action()
        {
            if (!isMoving)
            {
                _coroutineNowUsed = StartCoroutine(MoveToPosition(new Vector3(_restartPosition.x,_restartPosition.y,moveZOffset)));
            }
        }

        private IEnumerator MoveToPosition(Vector3 targetPosition)
        {
            isMoving = true;

            gameObject.GetComponent<AudioSource>().PlayOneShot(_clip);

            Vector3 startPos = transform.position;
            Vector3 endPos = targetPosition;

            float elapsed = 0f;

            while (elapsed < moveDuration)
            {
                float t = elapsed / moveDuration;
                float smoothT = Mathf.SmoothStep(0f, 1f, t);
                transform.position = Vector3.Lerp(startPos, endPos, smoothT);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = endPos;
            isMoving = false;
        }

        private void OnTriggerStay(Collider other)
        {
            if (isMoving) ResetPosition();
        }
        private void OnTriggerExit(Collider other)
        {
            if(isMoving) // restart it if is exited the trigger
                _coroutineNowUsed = StartCoroutine(MoveToPosition(new Vector3(_restartPosition.x, _restartPosition.y, moveZOffset)));
        }

        private void ResetPosition()
        {
            if (isMoving && _coroutineNowUsed != null)
            {
                // Pause the routine
                StopCoroutine(_coroutineNowUsed);
            }
   
        }

    }

}

