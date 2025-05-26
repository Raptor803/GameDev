using UnityEngine;
using UnityEngine.InputSystem;

public class CustomButton : MonoBehaviour, IAction
{
    public GameObject agent;
    public Actionable target;
    public const float MAX_DISTANCE = 1f;

    public void Action()
    {
        target.Action();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (Input.GetKeyDown(KeyCode.K) && distance < MAX_DISTANCE)
        {
            target.Action();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mouse"){
            GetComponent<Outline>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "mouse") {
            GetComponent<Outline>().enabled = false;
        }
    }

}
