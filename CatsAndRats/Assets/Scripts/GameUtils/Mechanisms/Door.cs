using UnityEngine;

public class Door : GameUtils.Core.ActionComponent
{
    [SerializeField] private float openAngle = 90f; // Angolo di apertura
    [SerializeField] private float speed = 2f; // Velocità di apertura
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    public override void Action()
    {
        Debug.Log("porta azionata");
        if (!isOpen)
        {
            StartCoroutine(openDoor());
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private System.Collections.IEnumerator openDoor()
    {
        isOpen = true;
        float elapsedTime = 0f;
        float duration = 1f / speed; // Tempo necessario per completare l'animazione

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(closedRotation, openRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = openRotation; // Assicura che la porta finisca esattamente nell'angolo giusto
    }
}
