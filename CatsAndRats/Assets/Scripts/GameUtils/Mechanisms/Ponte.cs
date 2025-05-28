using UnityEngine;


namespace GameUtils.Mechanisms
{
    public class Ponte : Actionable
    {
        [SerializeField] GameObject rotationCenter;

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
            Debug.Log("ponte abbassato");
            rotationCenter.transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
    }
}

