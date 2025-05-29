using UnityEngine;


namespace GameUtils.Core
{
    public abstract class Actionable : MonoBehaviour, IAction
    {
        public virtual void Action()
        {
            print(gameObject + ".Action()");
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
