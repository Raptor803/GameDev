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

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public override void Action()
        {
            if (!isMoving)
            {
                StartCoroutine(MoveToZOffset());
            }
        }

        private IEnumerator MoveToZOffset()
        {
            isMoving = true;

            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(startPos.x, startPos.y, moveZOffset);

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
    }

}

