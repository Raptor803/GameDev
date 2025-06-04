using UnityEngine;

public class BreathingText : MonoBehaviour
{
    private Vector3 minScale = new Vector3(0.95f, 0.95f, 0.95f);
    private Vector3 maxScale = new Vector3(1.05f, 1.05f, 1.05f);
    private float speed = 4f;

    private bool scalingUp = true;

    void Update()
    {
        if (scalingUp)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxScale, speed * Time.deltaTime);
            if (Vector3.Distance(transform.localScale, maxScale) < 0.01f)
                scalingUp = false;
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, minScale, speed * Time.deltaTime);
            if (Vector3.Distance(transform.localScale, minScale) < 0.01f)
                scalingUp = true;
        }
    }
}
