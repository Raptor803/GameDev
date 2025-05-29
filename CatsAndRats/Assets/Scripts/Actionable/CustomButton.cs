using UnityEngine;
using UnityEngine.InputSystem;

public class CustomButton : Actionable
{
    public GameObject agent;
    public Actionable target;
    public const float MAX_DISTANCE = 1f;
    public KeyCode activationKey = KeyCode.K;
    public bool needsClearance = false;

    public override void Action()
    {
        target.Action();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, agent.transform.position);
        if (distance < MAX_DISTANCE)
        {
            if (Input.GetKeyDown(activationKey))
            {
                if (!needsClearance || (needsClearance && HasClearance()))
                {
                    target.Action();   
                }
            }
        }
    }

    bool HasClearance()
    {
        // raycast from agent to transform and check if there are any obstacles in between
        // (cannot activate buttons through walls ;))
        RaycastHit hit;
        Vector3 direction = (target.transform.position - agent.transform.position).normalized;
        if (Physics.Raycast(agent.transform.position, direction, out hit, MAX_DISTANCE))
        {
            if (hit.collider.gameObject == target.gameObject)
            {
                return true; // Clear path to target
            }
        }
        return false; // Obstacle in the way
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == agent.tag)
        {
            GetComponent<Outline>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == agent.tag)
        {
            GetComponent<Outline>().enabled = false;
        }
    }   

}
