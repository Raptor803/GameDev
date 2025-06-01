using GameUtils.Core;
using System;
using UnityEngine;

namespace MyGame.ActionableObject
{
    public class OakStairs : Actionable
    {
        [SerializeField] float moveZOffset;
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
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, moveZOffset);
            ;
        }
    }

}

