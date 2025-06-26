using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        gameManager.TriggerGameOver();
    }
}
