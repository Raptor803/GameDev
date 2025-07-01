using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] public bool isFinishLine = false;

    void OnTriggerEnter(Collider other)
    {
        gameManager.TriggerGameOver(isFinishLine);
    }
}
